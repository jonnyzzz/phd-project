#include "StdAfx.h"
#include ".\d3dgraph2d.h"


const DWORD D3DGraph2D::POINTVERTEX::FVF = D3DFVF_XYZ | D3DFVF_DIFFUSE;

float inline D3DGraph2D::Max(float a, float b) {
	return (a>b)?a:b;
}

D3DGraph2D::D3DGraph2D(void)
{
	eye_fov = D3DX_PI/4;
	graph = NULL;
	color = NULL;
}

D3DGraph2D::~D3DGraph2D(void)
{
	if (color != NULL) 
		delete color;
}



HRESULT D3DGraph2D::Create(HWND hwnd, Graph* graph, GraphColor* color, int dim1, int dim2) {
	HRESULT hr;
	hr = D3DKernel::Create(hwnd);
	if (FAILED(hr)) return hr;
	this->graph = graph;
	this->color = color;
	this->dim1 = dim1;
	this->dim2 = dim2;
	this->OnCenterView();

	hr = this->createAndFillVertexBuffer();
	if (FAILED(hr)) {
		D3DKernelException("Failed to create vertex buffer for graph");
		return hr;
	}


	return S_OK;
}



void D3DGraph2D::OnCenterView() {
	if (!is_initialized) return;

	zfactor = 1;
	float cx = (float)(graph->getMax()[dim1] - graph->getMin()[dim1]) /2 ;
	float cy = (float)(graph->getMax()[dim2] - graph->getMin()[dim2]) /2 ;

	float z = -(((Max(cx, cy)) / tan(eye_fov/2))) * 1.03f;

	eye_pos[0] = (float)(graph->getMax()[dim1] + graph->getMin()[dim1])/2;
	eye_pos[1] = (float)(graph->getMax()[dim2] + graph->getMin()[dim2])/2;
	eye_pos[2] = z;

	printf("view: %f, %f, %f\n", eye_pos[0], eye_pos[1], eye_pos[2]);	
}

void D3DGraph2D::OnMove(float dx, float dy, float dz) {
	float k = 2*abs(eye_pos[2])*tan(eye_fov/2)/10;
	eye_pos[0] -= dx * k;
	eye_pos[1] -= dy * k;
	eye_pos[2] *= dz; //zoom implementation
	zfactor *= dz;

	Render();
}

float D3DGraph2D::getZoomFactor() {
	return zfactor;
}

///////////////////////////////////////////////////////////////////////////////////

HRESULT D3DGraph2D::initRenderSettings() {
	HRESULT hr;
	hr = d3d_device->SetRenderState( D3DRS_CULLMODE, D3DCULL_NONE );
	if (FAILED(hr)) return hr;
    hr = d3d_device->SetRenderState( D3DRS_LIGHTING, FALSE );
	if (FAILED(hr)) return hr;
	
	return S_OK;
}


HRESULT D3DGraph2D::initMatrices() {
	
	D3DXVECTOR3 vEyePt    = D3DXVECTOR3( eye_pos[0], eye_pos[1], eye_pos[2]);
    D3DXVECTOR3 vLookatPt = D3DXVECTOR3( eye_pos[0], eye_pos[1], 0.0f );
    D3DXVECTOR3 vUpVec    = D3DXVECTOR3( 0.0f, 1.0f, 0.0f );

    D3DXMATRIX  matWorld, matView, matProj;
    
    D3DXMatrixIdentity( &matWorld );

    D3DXMatrixLookAtLH( &matView, &vEyePt, &vLookatPt, &vUpVec );

    FLOAT fAspect = 1;// m_d3dsdBackBuffer.Width / (FLOAT)m_d3dsdBackBuffer.Height;
	FLOAT perspective = 1e5f;

	D3DXMatrixPerspectiveFovLH( &matProj, eye_fov, fAspect, 1/perspective, perspective );
    
    d3d_device->SetTransform( D3DTS_WORLD,      &matWorld );
    d3d_device->SetTransform( D3DTS_VIEW,       &matView );
    d3d_device->SetTransform( D3DTS_PROJECTION, &matProj );

	return S_OK;
}

/////////////////////////////////////////////////////////////////////////////

HRESULT D3DGraph2D::createAndFillVertexBuffer() {
	int point_max = d3d_caps.MaxPrimitiveCount / 6;
	if (point_max > graph->getNumberOfNodes()) {
		point_max = graph->getNumberOfNodes();
	}
	int count = 0;

	NodeEnumerator* ne = graph->getNodeRoot();
	Node* node;
	POINTVERTEX* pv;
	LPDIRECT3DVERTEXBUFFER8 vb = NULL;
	while (node = graph->getNode(ne)) {
		if (count == 0) {			
			HRESULT hr;
			hr = d3d_device->CreateVertexBuffer( point_max *  6	* sizeof(POINTVERTEX), 
				D3DUSAGE_DYNAMIC | D3DUSAGE_WRITEONLY | D3DUSAGE_POINTS, 
				POINTVERTEX::FVF, D3DPOOL_DEFAULT, &vb );
			if (FAILED(hr)) {
				D3DKernelException("Failed to create VertexBuffer");
				printf("Parameters Of Creation: number = %d\n", point_max);
				return hr;
			}

			hr = vb->Lock( 0, point_max * 6* sizeof(POINTVERTEX),
				(BYTE**) &pv, D3DLOCK_DISCARD );
			if (FAILED(hr)) {
				D3DKernelException("Failed to create Lock created VertexBuffer");
				return hr;
			}

			D3DKernelException("Vertex Buffer OK");
		}

		createVertex(node, pv);

		count++;

		if (count >= point_max) {
			vb->Unlock();
			RenderList rl;
			rl.vb = vb;
			rl.count = count;
			buffer.push_back(rl);
			vb = NULL;
		}    
	}
	graph->freeNodeEnumerator(ne);
	if (vb != NULL) {
		vb->Unlock();
		RenderList rl;
		rl.vb = vb;
		rl.count = count;
		buffer.push_back(rl);
		vb = NULL;
	}

	return S_OK;
}

void D3DGraph2D::createVertex(Node* node, POINTVERTEX*& p) {
	const float Z = 0;	
	const JInt* cells = (graph)->getCells(node);
	float x[2];
	x[0] = (float)graph->toExternal(cells[dim1], dim1);
	x[1] = (float)graph->toExternal(cells[dim2], dim2);
	float d[2];
	d[0] = (float)graph->getEps()[dim1];
	d[1] = (float)graph->getEps()[dim2];

	DWORD color = 0x34453d;//(*this->color)[node];

	//printf("c: %d %d \n", cells[0], cells[1]);

	(*p).v = D3DXVECTOR3(x[0], x[1], Z);
	(*p).color = color;
	p++;
	(*p).v = D3DXVECTOR3(x[0], x[1] + d[1], Z);
	(*p).color = color;
	p++;
	(*p).v = D3DXVECTOR3(x[0] + d[0], x[1], Z);
	(*p).color = color;
	p++;

	(*p).v = D3DXVECTOR3(x[0] + d[0], x[1], Z);
	(*p).color = color;
	p++;
	(*p).v = D3DXVECTOR3(x[0], x[1] + d[1], Z);
	(*p).color = color;
	p++;
	(*p).v = D3DXVECTOR3(x[0] + d[0], x[1] + d[1], Z);
	(*p).color = color;
	p++;
}

//////////////////////////////////////////////////////////////////////////////

HRESULT D3DGraph2D::Render() {
	return D3DKernel::render();
}

HRESULT D3DGraph2D::renderPrimitive() {
	D3DKernelException("Rendering primitive");
	printf("Number of VertexBuffers = %d\n", buffer.size());
	HRESULT hr;

	for (VertexList::iterator it = buffer.begin(); it != buffer.end(); it++) {

		D3DKernelException("Something to render found!");

		hr = d3d_device->SetStreamSource( 0, it->vb, sizeof(POINTVERTEX) );
		if (FAILED(hr)) {
			D3DKernelException("Unable to set Stream Source");
			return hr;
		}
		hr = d3d_device->SetVertexShader( POINTVERTEX::FVF );
		if (FAILED(hr)) {
			D3DKernelException("Unable to set VertexShaderType");
			return hr;
		}

		hr = d3d_device->DrawPrimitive( D3DPT_TRIANGLELIST, 0, 2*it->count);
		if (FAILED(hr)) {
			D3DKernelException("Failed to DrawPrimitive");
			return hr;
		}

		printf("Primitive to render = %d\n", it->count * 2);
	}

	return S_OK;
}


bool D3DGraph2D::getMouseCoordinate(POINTS pt, MousePoint& fpoint) {
	if (this->graph == NULL) return false;

	RECT obl;
	GetClientRect(d3d_hwnd, &obl);

	double z = abs(eye_pos[2]) * tan(eye_fov/2);
	
	double minX = (eye_pos[0] - z);
	double minY = (eye_pos[1] + z);

	double maxX = (eye_pos[0] + z);
	double maxY = (eye_pos[1] - z);

	double kx = (double)pt.x / (obl.right - obl.left);
	double ky = (double)pt.y / (obl.bottom - obl.top);

	JDouble x[2];

	x[0] = (minX + kx * (maxX - minX));
	x[1] = (minY + ky * (maxY - minY));

	fpoint.x = x[0];
	fpoint.y = x[1];

	return true;
}

Node* D3DGraph2D::getCurrentNode(MousePoint& pt) {

	JInt zz[2];
	zz[dim1] = graph->toInternal(pt.x, dim1);
	zz[dim2] = graph->toInternal(pt.y, dim2);
	
	if (graph->getDimention()!= 2) {
		printf("Bad implementation!: Only 2d!");
		return NULL;
	}

	return graph->findNode(zz);
}




