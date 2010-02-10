#include "StdAfx.h"
#include ".\d3dgraph3d.h"
#include ".\DisplayableCoordinateSystem.h"


const DWORD D3DGraph3D::FVF = D3DFVF_XYZ | D3DFVF_DIFFUSE | D3DFVF_NORMAL | D3DFVF_SPECULAR;
const int D3DGraph3D::ATOM = 36;
const int D3DGraph3D::POINTPERVERTEX = 3;
const D3DPRIMITIVETYPE D3DGraph3D::VERTEX = D3DPT_TRIANGLELIST;


D3DGraph3D::D3DGraph3D(void) : D3DKernel()
{
	//this->backColor = 0x000000;
	eye_fov = D3DX_PI/4;
	eye_from = D3DXVECTOR3(0, 0, -3);
	eye_to = D3DXVECTOR3(0, 0, -1);
	
	graph = NULL;
	coordinateSystem = NULL;
	renderList = NULL;
}

D3DGraph3D::~D3DGraph3D(void)
{
	this->Dispose();
}


HRESULT D3DGraph3D::Create(HWND hwnd, DrawableGraph* graph) {
	HRESULT hr = D3DKernel::Create(hwnd);

	if (FAILED(hr)) return hr;

	this->graph = graph;

	hr = this->createPointList();	

	if (FAILED(hr)) {
		D3DKernelException("Unable to fill VB!");
	}

	if (coordinateSystem != NULL) {
		coordinateSystem->Dispose();
		delete coordinateSystem;
	}

	D3DXVECTOR3 basis[] = {
			D3DXVECTOR3(1.0f, 0.0f, 0.0f),
			D3DXVECTOR3(0.0f, 1.0f, 0.0f),
			D3DXVECTOR3(0.0f, 0.0f, 1.0f),
		};


	coordinateSystem = new DisplayableCoordinateSystem();
	hr = coordinateSystem->Create(this->d3d_device, basis);
	
	if (FAILED(hr)) {
		D3DKernelException("Failed to create CoordinatesDiplay");		
		delete coordinateSystem;
		coordinateSystem = NULL;
		return hr;
	}

    CenterView();
	return hr;
}

HRESULT D3DGraph3D::Render() {
	return D3DKernel::render();
} 

HRESULT D3DGraph3D::initMatrices() {
	D3DXVECTOR3 vEyePt    = D3DXVECTOR3( eye_from[0], eye_from[1], eye_from[2]);
	D3DXVECTOR3 vLookatPt = D3DXVECTOR3( eye_to[0], eye_to[1], eye_to[2] );

	D3DXVECTOR3 direction = eye_from - eye_to;
	D3DXVECTOR3 vUpVec = D3DXVECTOR3( 0.0f, 1.0f, 0.0f );
	
	D3DXMATRIX  matWorld, matView, matProj;

	D3DXMatrixIdentity( &matWorld );

	D3DXMatrixLookAtRH( &matView, &vEyePt, &vLookatPt, &vUpVec );

	FLOAT fAspect = 1;// m_d3dsdBackBuffer.Width / (FLOAT)m_d3dsdBackBuffer.Height;
	FLOAT perspective = 1e5f;

	D3DXMatrixPerspectiveFovRH( &matProj, eye_fov, fAspect, 1/perspective, perspective );

	d3d_device->SetTransform( D3DTS_WORLD,      &matWorld );
	d3d_device->SetTransform( D3DTS_VIEW,       &matView );
	d3d_device->SetTransform( D3DTS_PROJECTION, &matProj );

	return S_OK;
}

HRESULT D3DGraph3D::initRenderSettiongAfterScene() {
	return S_OK;
}

HRESULT D3DGraph3D::initRenderSettings() {
	HRESULT hr = d3d_device->SetRenderState(D3DRS_CULLMODE, D3DCULL_NONE);
	if (FAILED(hr)) return hr;
	return initLight();
}


HRESULT D3DGraph3D::initLight() {

	HRESULT hr;
	
	D3DXVECTOR3 vecDir = D3DXVECTOR3(eye_to - eye_from);
    D3DLIGHT8 light;
    
	ZeroMemory( &light, sizeof(D3DLIGHT8) );
	light.Type       = D3DLIGHT_DIRECTIONAL;
    light.Diffuse.r  = 1.0f;
    light.Diffuse.g  = 1.0f;
    light.Diffuse.b  = 1.0f;
	light.Diffuse.a  = 0.0f;
		
	D3DXVec3Normalize( (D3DXVECTOR3*)&light.Direction, &vecDir );
    light.Range       = 1000.0f;
	light.Position = eye_from;

	hr = d3d_device->SetLight( 0, &light );
	if (FAILED(hr)) return hr;
    hr = d3d_device->LightEnable( 0, TRUE );
	if (FAILED(hr)) return hr;
	hr = d3d_device->SetRenderState( D3DRS_LIGHTING, TRUE );
	if (FAILED(hr)) return hr;

    // Finally, turn on some ambient light.
    hr = d3d_device->SetRenderState( D3DRS_AMBIENT, 0x00ffffff );
	if (FAILED(hr)) return hr;

	//D3DRS_SPECULARENABLE

	//D3DMATERIALCOLORSOURCE  D3DMCS_COLOR1 
	hr = d3d_device->SetRenderState( D3DRS_DIFFUSEMATERIALSOURCE, D3DMCS_COLOR1 );
	if (FAILED(hr)) return hr;
	hr = d3d_device->SetRenderState( D3DRS_AMBIENTMATERIALSOURCE, D3DMCS_COLOR2 );
	if (FAILED(hr)) return hr;
	

	return S_OK;
}

////////////////////////////////////////////////////////////////////////////

HRESULT D3DGraph3D::afterMatricesInitExtRender() {	
	HRESULT hr;
	if (coordinateSystem != NULL) {
		printf("Rendering Coordinates\n");

		hr = coordinateSystem->Render();
		if (FAILED(hr)) {
			printf("FAILED to Render Axis\n");
		}
	}

	return S_OK;
}


HRESULT D3DGraph3D::renderPrimitive() {
	D3DKernelException("Rendering primitive");

	d3d_device->SetVertexShader(FVF);
	d3d_device->DrawPrimitiveUP(VERTEX, renderList->count/POINTPERVERTEX, renderList->vb, sizeof(POINTVERTEX));				

	return S_OK;
}


///////////////////////////////////////////////////////////////////////////

int D3DGraph3D::addPoint(POINTVERTEX*& pv, Node* node, int axis, int direction) {	
	
	ATLASSERT(node != NULL);

	printf("%d %d %d %d\n", graph->getGraph()->getCells(node)[0], graph->getGraph()->getCells(node)[1], graph->getGraph()->getCells(node)[2], direction);

	D3DXVECTOR3 eps = graph->getEps();
	D3DXVECTOR3 d[] = {
						D3DXVECTOR3(eps[0], 0.0f, 0.0f),
						D3DXVECTOR3(0.0f, eps[1], 0.0f),
						D3DXVECTOR3(0.0f, 0.0f, eps[2])
					  };

	D3DXVECTOR3 x = graph->getCoordinates(node);
	D3DXVECTOR3 zero = D3DXVECTOR3( 0.0f, 0.0f, 0.0f);

	int ix[3];

	const int arr[ATOM/6][2] = {
						{0,0},
						{0,1},
						{1,0},

						{0,1},
						{1,0},
						{1,1}
					};

	switch( axis) {
		case 0:			
			ix[0] = 2;
			ix[1] = 1;
			ix[2] = 0;
			break;
		case 1:
			ix[0] = 0;
			ix[1] = 2;
			ix[2] = 1;
			break;
		case 2:
			ix[0] = 1;
			ix[1] = 0;
			ix[2] = 2;
			break;
	}

	int t[3] = {0,0,0};
	if (direction < 0) {
		x += d[ix[2]];
		t[ix[2]] = 1;
	}	

	DWORD colors[] =  {
		0xff0000,
		0x00ff00,
		0x0000ff,
		0xffff00,
		0xff00ff,
		0x00ffff
	};

	DWORD colorsA[] =  {
		0x770000,
		0x007700,
		0x000077,
		0x777700,
		0x770077,
		0x007777
	};


	DWORD colorDiffuse = graph->getColorDiffuse(node);
	DWORD colorAmbient = graph->getColorAmbient(node);
	

	for (int i=0; i<ATOM/6; i++) {
		pv->colorAmbient = colorAmbient;
		pv->colorDiffuse = colorDiffuse;

		t[ix[0]] = arr[i][0];
		t[ix[1]] = arr[i][1];

		
		pv->n = D3DXVECTOR3( (t[0]==0)?-1.0f:1.0f, (t[1]==0)?-1.0f:1.0f, (t[2]==0)?-1.0f:1.0f )/sqrtf(3);

		pv->v = x + (float)arr[i][0]*d[ix[0]] + (float)arr[i][1]*d[ix[1]];

		pv++;
	}

	return ATOM/6;
}

HRESULT D3DGraph3D::createPointList() {
	Graph* graph = this->graph->getGraph();

	JInt* coord = new JInt[3];
	coord[0] = coord[1] = coord[2] = 0;


	renderList = new RenderList();
	renderList->count = 0;
	POINTVERTEX* pv = renderList->vb = new POINTVERTEX[graph->getNumberOfNodes()*ATOM];

	int i,j;
	for (i=0; i<graph->getGrid()[0]; i++) {
		for (j=0; j<graph->getGrid()[1]; j++) {				
				coord[0] = i; coord[1] = j;
				renderList->count += processAxis(pv, 2, coord);
			}
		}
	

	for (i=0; i<graph->getGrid()[1]; i++) {
		for (j=0; j<graph->getGrid()[2]; j++) {				
				coord[1] = i; coord[2] = j;
				renderList->count += processAxis(pv, 0, coord);
			}
		}
	

	for (i=0; i<graph->getGrid()[0]; i++) {
		for (j=0; j<graph->getGrid()[2]; j++) {				
				coord[0] = i; coord[2] = j;
				renderList->count += processAxis(pv, 1, coord);
			}
		}
	
	
	printf("count = %d\n", renderList->count);

	return S_OK;
}

int D3DGraph3D::processAxis(POINTVERTEX*& pv, int axis, JInt* current) {
	if (axis >= 3) return 0;

	Graph* graph = this->graph->getGraph();
	JInt grid = graph->getGrid()[axis]; //!
	int count = 0;
    
	bool in_flag = false;
		
	for (current[axis] = 0; current[axis]<=grid; current[axis]++) {
		Node* node = graph->findNode(current);
		
		if (in_flag) {
			if (node == NULL) {
				current[axis]--;
				node = graph->findNode(current);
				ATLASSERT(node != NULL);
				count += addPoint(pv, node, axis, -1);
				in_flag = false;
				current[axis]++;
			} else {
				//do nothing
			}
		} else {
			if (node == NULL) {
				//do nothing
			} else {
				count += addPoint(pv, node, axis, 1);
				in_flag = true;
			}
		}
	}
	return count;
}

//////////////////////////////////////////////////////////


void D3DGraph3D::CenterView(int axis) {

	//eye_from = D3DXVECTOR3(-0.62f, 0.55f, -0.41f);
	//eye_to = D3DXVECTOR3(0.0f, 0.0f, 0.0f);
	//return;

	if (graph == NULL) return;

	int x = (axis+2) % 3;
	int y = (axis+1) % 3;
	int z = (axis) % 3;

	D3DXVECTOR3 center = graph->getMid();
	
	eye_from = eye_to = center;

	if (axis >= 0) {		
		eye_to[z] = graph->getMax()[z];
		eye_from[z] = (float)(graph->getMaxLength()/tan(eye_fov/2)/2*1.03 + eye_to[z]);
	} else {
		eye_to[z] = graph->getMin()[z];
		eye_from[z] = (float)(-graph->getMaxLength()/tan(eye_fov/2)/2*1.03 + eye_to[z]);
	}	
	printf("From : %f, %f, %f,\nTo : %f, %f, %f\n", eye_from[0], eye_from[1], eye_from[2], eye_to[0], eye_to[1], eye_to[2]);
}

void D3DGraph3D::MoveEyeFrom(float x, float y, float z) {
	eye_from -= NormalizeMoveVector( D3DXVECTOR3(x, y, z));

	printf("From : %f, %f, %f,\nTo : %f, %f, %f\n", eye_from[0], eye_from[1], eye_from[2], eye_to[0], eye_to[1], eye_to[2]);
}

D3DXVECTOR3 D3DGraph3D::NormalizeMoveVector(D3DXVECTOR3 v) {
	D3DXVECTOR3 d = eye_to-eye_from;
	float len = D3DXVec3Length(&d);
	
	return v*len/5.0f;
}

void D3DGraph3D::SetEyeFrom(float x, float y, float z) {
	eye_from = NormalizeMoveVector(D3DXVECTOR3(x, y, z));
}

void D3DGraph3D::SetEyeTo(float x, float y, float z) {
	eye_to = NormalizeMoveVector(D3DXVECTOR3(x, y, z));
}

void D3DGraph3D::Rotate(float onX, float onY, float onZ) {
	D3DXMATRIX rot;	
	D3DXMatrixIdentity(&rot);

	D3DXMatrixRotationYawPitchRoll(&rot, onY, onX, onZ);

	D3DXVECTOR4 ans;
	D3DXVec3Transform(&ans, &(eye_from - eye_to), &rot);
	
	eye_from = D3DXVECTOR3((float*)ans) + eye_to;
}

void D3DGraph3D::Zoom(float factor) {
	D3DXVECTOR3 dir = eye_from - eye_to;
	dir*=factor;
	eye_from = eye_to + dir;
}