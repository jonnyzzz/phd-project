#include "StdAfx.h"
#include ".\graphrepresentator.h"

const DWORD GraphRepresentator::POINTVERTEX::FVF = D3DFVF_XYZ | D3DFVF_DIFFUSE;

inline DWORD FtoDW( FLOAT f ) { return *((DWORD*)&f); }

GraphRepresentator::GraphRepresentator() {
	points = NULL;
	highPoints = NULL;
	needInit = true;
	numPoints = 0;
	vb = NULL;
	highVB = NULL;
	needInitHigh = true;
	numHighPoints = 0;
	graph = NULL;
	fov = D3DX_PI/4;
	nodeHighLight = NULL;
}

GraphRepresentator::~GraphRepresentator(void)
{
}

HRESULT GraphRepresentator::SetGraph(GraphEx* graph) {
	this->graph = graph;	
	FillPOINTVERTEX();
	toCenter(); 
	needInit = true;	
	return S_OK;
}


void GraphRepresentator::FillNode(Node* node, POINTVERTEX*& p, DWORD color) {
		const float Z = 0;
		const Graph* graph = *this->graph;
		const JInt* cells = (graph)->getCells(node);
		float x[2];
		x[0] = (float)graph->toExternal(cells[0], 0);
		x[1] = (float)graph->toExternal(cells[1], 1);
		float d[2];
		d[0] = (float)graph->getEps()[0];
		d[1] = (float)graph->getEps()[1];

		printf("c: %d %d \n", cells[0], cells[1]);
		
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

class color {
	DWORD clr;
	DWORD seed;
public:
	color() : clr(0x808080), seed(0x150925) {};

	DWORD next () {
		clr += seed;		
		clr &= 0xffffff;
		printf("...");
		return clr;
	}

	operator DWORD() {
		return clr;
	}
};

color clr;

void GraphRepresentator::FillPOINTVERTEX() {

	if (points != NULL) 
		delete[] points;


	const DWORD color = 0x808080;
	int num = graph->getGraph()->getNumberOfNodes();
	points = new POINTVERTEX[num*6];

	POINTVERTEX* p = points;

	NodeEnumerator* ne = graph->getGraph()->getNodeRoot();
	Node* node;
	numPoints = 0;
	while (node = graph->getGraph()->getNode(ne)) {				
		FillNode(node, p, tm.CreateTextureByID((*graph)[node]->minLoopLength));		
		numPoints++;
	}
	graph->getGraph()->freeNodeEnumerator(ne);

	printf("Init complete. %d points\n", numPoints);
	
	ATLVERIFY(numPoints <= num);
}

HRESULT GraphRepresentator::InitDevice(LPDIRECT3DDEVICE9 device) {
	if (needInit) {
		InitDevice(device, points, numPoints, &vb);
		needInit = false;
	}
	if (needInitHigh) {
		InitDevice(device, highPoints, numHighPoints, &highVB);
		needInitHigh = false;
	}

	return S_OK;
}

HRESULT GraphRepresentator::InitDevice(LPDIRECT3DDEVICE9 pd3dDevice, POINTVERTEX* points, int count, LPDIRECT3DVERTEXBUFFER9* vb) {

	printf("Inininting device\n");

	if (count == 0) 
		return S_OK;

	if (*vb != NULL)
		(*vb)->Release();

	HRESULT hr;

	hr = pd3dDevice->CreateVertexBuffer( count *6	* sizeof(POINTVERTEX), 
						D3DUSAGE_DYNAMIC | D3DUSAGE_WRITEONLY | D3DUSAGE_POINTS, 
						POINTVERTEX::FVF, D3DPOOL_DEFAULT, vb, NULL );
    if(FAILED(hr))
	{
        return E_FAIL;
	}

	POINTVERTEX* pv = NULL;

	hr = (*vb)->Lock( 0, count * 6* sizeof(POINTVERTEX),
					(void**) &pv, D3DLOCK_DISCARD );
	if( FAILED( hr ) )
    {
		return hr;
    }

	ATLVERIFY(pv != NULL);

	memcpy(pv, points, count *6* sizeof(POINTVERTEX));
	(*vb)->Unlock();
	
	return S_OK;
}


HRESULT GraphRepresentator::Render(LPDIRECT3DDEVICE9 pd3dDevice) {
	HRESULT hr;

	if (needInit || needInitHigh) {
		if (FAILED(hr = InitDevice(pd3dDevice))) {
			return hr;
		}
	}

	SetMatrices(pd3dDevice);

	printf("Rendering GraphRepresentation\n");

	D3DVIEWPORT9 p;
	hr = pd3dDevice->GetViewport(&p);
	if (FAILED(hr)) {
		return hr;
	}

	/*
    // Set the render states for using point sprites
    pd3dDevice->SetRenderState( D3DRS_POINTSPRITEENABLE, TRUE );
    pd3dDevice->SetRenderState( D3DRS_POINTSCALEENABLE,  FALSE );
    pd3dDevice->SetRenderState( D3DRS_POINTSIZE,     FtoDW(10.00f) );
    pd3dDevice->SetRenderState( D3DRS_POINTSIZE_MIN, FtoDW(10.00f) );	
	pd3dDevice->SetRenderState( D3DRS_POINTSCALE_A,  FtoDW(0.500f) );// 2.00f/p.Height/p.Height));
    pd3dDevice->SetRenderState( D3DRS_POINTSCALE_B,  FtoDW(0.00f) );
    pd3dDevice->SetRenderState( D3DRS_POINTSCALE_C,  FtoDW(0.00f) );
	*/

    // Set up the vertex buffer to be rendered
    pd3dDevice->SetStreamSource( 0, vb, 0, sizeof(POINTVERTEX) );
    pd3dDevice->SetFVF( POINTVERTEX::FVF );
	
	hr = pd3dDevice->DrawPrimitive( D3DPT_TRIANGLELIST, 0, 2*numPoints);
	if(FAILED(hr))
		return hr;

	if (numHighPoints > 0 && highVB != NULL) {
		pd3dDevice->SetStreamSource(0, highVB, 0, sizeof(POINTVERTEX));
		pd3dDevice->SetFVF( POINTVERTEX::FVF);

		hr = pd3dDevice->DrawPrimitive( D3DPT_TRIANGLELIST, 0, 2*numHighPoints);
		if(FAILED(hr))
			return hr;
	}

	/*
	pd3dDevice->SetRenderState( D3DRS_POINTSPRITEENABLE, FALSE );
	pd3dDevice->SetRenderState( D3DRS_POINTSCALEENABLE,  FALSE );
	*/

	return S_OK;
}


Node* GraphRepresentator::GetNodeBy(POINTS& pt, RECT& obl) {
	if (graph == NULL) return NULL;

	double z = abs(eye_pos[2]) * tan(fov/2);
	
	double minX = (eye_pos[0] - z);
	double minY = (eye_pos[1] + z);

	double maxX = (eye_pos[0] + z);
	double maxY = (eye_pos[1] - z);

	double kx = (double)pt.x / (obl.right - obl.left);
	double ky = (double)pt.y / (obl.bottom - obl.top);

	JDouble x[2];

	x[0] = (minX + kx * (maxX - minX));
	x[1] = (minY + ky * (maxY - minY));

	JInt zz[2];
	zz[0] = graph->getGraph()->toInternal(x[0], 0);
	zz[1] = graph->getGraph()->toInternal(x[1], 1);

	printf("%f %f \n", x[0], x[1]);
	printf("%d %d \n", zz[0], zz[1]);

	return graph->getGraph()->findNode(zz);
}

bool GraphRepresentator::HighLightNode(Node* node) {

	if (nodeHighLight == node) {
		return false;
	}

	nodeHighLight = node;

	if (node == NULL) {
		printf("Null node\n");
		return false;
	}

	if (highPoints != NULL) {
		delete[] highPoints;
	}

	highPoints = new POINTVERTEX[1*6];
	
	POINTVERTEX* p = highPoints;

	FillNode(node, p, 0xffffff);
	numHighPoints = 1;
    
	needInitHigh = true;

	return true;
}

void GraphRepresentator::toCenter() {
	if (graph != NULL) {
		Graph* graph = *this->graph;
		float cx = (float)(graph->getMax()[0] - graph->getMin()[0]) /2 ;
		float cy = (float)(graph->getMax()[1] - graph->getMin()[1]) /2 ;

		float z = -(((Max(cx, cy)) / tan(fov/2))) * 1.03f;

		eye_pos[0] = (float)(graph->getMax()[1] + graph->getMin()[1])/2;
		eye_pos[1] = (float)(graph->getMax()[1] + graph->getMin()[1])/2;
		eye_pos[2] = z;
	}
}

void GraphRepresentator::move(float dx, float dy, float dz) {
	float k = 2*abs(eye_pos[2])*tan(fov/2)/10;
	eye_pos[0] -= dx * k;
	eye_pos[1] -= dy * k;
	eye_pos[2] *= dz; //zoom implementation
}

HRESULT GraphRepresentator::SetMatrices(LPDIRECT3DDEVICE9 device) {

	D3DXVECTOR3 vEyePt    = D3DXVECTOR3( eye_pos[0], eye_pos[1], eye_pos[2]);
    D3DXVECTOR3 vLookatPt = D3DXVECTOR3( eye_pos[0], eye_pos[1], 0.0f );
    D3DXVECTOR3 vUpVec    = D3DXVECTOR3( 0.0f, 1.0f, 0.0f );

    D3DXMATRIXA16  matWorld, matView, matProj;
    
    D3DXMatrixIdentity( &matWorld );

    D3DXMatrixLookAtLH( &matView, &vEyePt, &vLookatPt, &vUpVec );

    FLOAT fAspect = 1;// m_d3dsdBackBuffer.Width / (FLOAT)m_d3dsdBackBuffer.Height;

    D3DXMatrixPerspectiveFovLH( &matProj, fov, fAspect, 500.0e-10f, 500.0e10f );
    
    //device->SetTransform( D3DTS_WORLD,      &matWorld );
    device->SetTransform( D3DTS_VIEW,       &matView );
    device->SetTransform( D3DTS_PROJECTION, &matProj );

	return S_OK;
}


JInt inline GraphRepresentator::Max(JInt a, JInt b) {
	return (a>b)?a:b;
}

float inline GraphRepresentator::Max(float a, float b) {
	return (a>b)?a:b;
}


GraphEx& GraphRepresentator::getGraphEx() {
	return *graph;
}

Node* GraphRepresentator::getActiveNode() {
	return nodeHighLight;
}