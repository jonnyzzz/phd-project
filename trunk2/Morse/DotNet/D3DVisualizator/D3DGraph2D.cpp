#include "StdAfx.h"
#include ".\d3dgraph2d.h"
#include ".\DrawableSet.h"
#include ".\DrawableSetIterator.h"

const DWORD D3DGraph2D::POINTVERTEX::FVF = D3DFVF_XYZ | D3DFVF_DIFFUSE;

float inline D3DGraph2D::Max(float a, float b) {
	return (a>b)?a:b;
}

JDouble inline D3DGraph2D::Max(JDouble a, JDouble b) {
	printf(".");
	return (a>b)?a:b;
}

JDouble inline D3DGraph2D::Abs(JDouble x) {
	return (x>0)? x : -x;
}


D3DGraph2D::D3DGraph2D(void)
{
	eye_fov = D3DX_PI/4;
	drawableSet = NULL;
}

D3DGraph2D::~D3DGraph2D(void)
{
}



HRESULT D3DGraph2D::Create(HWND hwnd, DrawableSet* drawableSet) {
	HRESULT hr;
	hr = D3DKernel::Create(hwnd);
	if (FAILED(hr)) return hr;

	this->drawableSet = drawableSet;

	printf("before On Center\n");
	

	this->OnCenterView();

	printf("S_OK\n");

	return S_OK;
}



void D3DGraph2D::OnCenterView() {
	if (!is_initialized) return;

	zfactor = 1;
	float c[2];
	drawableSet->getLength(c);

	//float cx = (float)(graph->getMax()[dim1] - graph->getMin()[dim1]) /2 ;
	//float cy = (float)(graph->getMax()[dim2] - graph->getMin()[dim2]) /2 ;

	float cx = c[0]/2;
	float cy = c[1]/2;

	float z = -(((Max(cx, cy)) / tan(eye_fov/2))) * 1.03f;

	drawableSet->getMidPoint(eye_pos);
	//eye_pos[0] = (float)(graph->getMax()[dim1] + graph->getMin()[dim1])/2;
	//eye_pos[1] = (float)(graph->getMax()[dim2] + graph->getMin()[dim2])/2;
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

void D3DGraph2D::createVertex(DrawableSetIterator* it, JDouble* eps, POINTVERTEX* p) {
	const float Z = 0;		
	float x[3];	
	
	//printf("Inint\n");

	it->coordinate(x);	 //third coordinate is't used there, but needed for function call	

	//printf("Coordinate\n");

	float d[2];
	d[0] = (float)eps[0];
	d[1] = (float)eps[1];

	x[0] -= d[0]/2;
	x[1] -= d[0]/2;

	DWORD color = it->color();

	//printf("Color\n");

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

void D3DGraph2D::createEps(JDouble* eps) {
	RECT r;
	GetClientRect(d3d_hwnd, &r);
	JInt screen[2] = {r.right - r.left, r.bottom - r.top};
	JDouble geps[3];
	drawableSet->getEps(geps);

	JDouble len = this->Abs(eye_pos[2] / tan(eye_fov)); //length on axis

	printf("Eps: \n");
    for (int i=0; i<2; i++) {
		eps[i] = this->Max(geps[i], len/screen[i]*4);//(float)len/screen[i]*4; //

		printf("Eps[%d] = %f\n", i, (double)eps[i]);
		printf("Gps[%d] = %f\n", i, (double)geps[i]);
		printf("ZGps[%d] = %f\n", i, (double)(len/(double)screen[i]*4));
	}
	printf("\n");
}
//////////////////////////////////////////////////////////////////////////////

HRESULT D3DGraph2D::Render() {
	return D3DKernel::render();
}

HRESULT D3DGraph2D::renderPrimitive() {
	D3DKernelException("Rendering primitive");	
	HRESULT hr;

	DrawableSetIterator* it = drawableSet->iterator();

	POINTVERTEX point[6];

	JDouble eps[2];

	this->createEps(eps);

	hr = d3d_device->SetVertexShader(POINTVERTEX::FVF);
	if (FAILED(hr)) {
		D3DKernelException("FAILED to set FVF");
	}

	while (it->next()) {
		
		//printf("After first NEXT\n");

		ATLASSERT(it->current() != NULL);

		createVertex(it, eps, point);
		
		hr = d3d_device->DrawPrimitiveUP(D3DPT_TRIANGLELIST, 2, point, sizeof(POINTVERTEX)); 
		if (FAILED(hr)) {
			D3DKernelException("DrawPrimitiveUP failed!");
		}		
	}
	//printf("BEFORE DELETE\n");
	delete it;
	
	return S_OK;
}


bool D3DGraph2D::getMouseCoordinate(POINTS pt, MousePoint& fpoint) {
	if (drawableSet == NULL) return false;

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
	/*
	JInt zz[2];
	zz[dim1] = graph->toInternal(pt.x, dim1);
	zz[dim2] = graph->toInternal(pt.y, dim2);
	
	if (graph->getDimention()!= 2) {
		printf("Bad implementation!: Only 2d!");
		return NULL;
	}

	return drawableSet->findFirstNode(????);
	*/
	return NULL;
}




