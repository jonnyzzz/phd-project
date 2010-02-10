#include "StdAfx.h"
#include ".\displayablecoordinatesystem.h"


const DWORD DisplayableCoordinateSystem::POINTVERTEX::FVF = D3DFVF_XYZ | D3DFVF_DIFFUSE;


DisplayableCoordinateSystem::DisplayableCoordinateSystem(void)
{
	vb = NULL;
	axisColor[0] = 0xff0000;
	axisColor[1] = 0x00ff00;
	axisColor[2] = 0x0000ff;
}

DisplayableCoordinateSystem::~DisplayableCoordinateSystem(void)
{
	Dispose();
}


HRESULT DisplayableCoordinateSystem::Create(LPDIRECT3DDEVICE8 d3d_device, D3DXVECTOR3 x[3]) {
	this->x[0] = x[0];
	this->x[1] = x[1];
	this->x[2] = x[2];

	this->d3d_device = d3d_device;

	return CreateVertexBuffer();
}


void DisplayableCoordinateSystem::Dispose() {
	if (vb != NULL) {
		vb->Release();
	}
}

/////////////////////////////////////////////////////////////////////////////////////

HRESULT DisplayableCoordinateSystem::Render() {
	HRESULT hr = initDevice();
	if (FAILED(hr)) return hr;

	hr = render();
	if (FAILED(hr)) return hr;

	return S_OK;
}


HRESULT DisplayableCoordinateSystem::initDevice() {
	HRESULT hr;	
	hr = d3d_device->SetRenderState( D3DRS_CULLMODE, D3DCULL_NONE );
	if (FAILED(hr)) return hr;
	hr = d3d_device->SetRenderState( D3DRS_LIGHTING, FALSE );
	if (FAILED(hr)) return hr;

	return S_OK;
}

HRESULT DisplayableCoordinateSystem::render() {

	HRESULT hr;

	printf("Coordinated Render Started\n");

	hr = d3d_device->SetStreamSource(0, vb, sizeof(POINTVERTEX));
	if (FAILED(hr)) return hr;

	hr = d3d_device->SetVertexShader(POINTVERTEX::FVF);
	if (FAILED(hr)) return hr;

	hr = d3d_device->DrawPrimitive(D3DPT_LINELIST, 0, 3);
	if (FAILED(hr)) return hr;

	return S_OK;
}


///////////////////////////////////////////////////////////////////////////////////


HRESULT DisplayableCoordinateSystem::CreateVertexBuffer() {
	const int factor = 6;
	HRESULT hr;
	POINTVERTEX* pv = NULL;

	hr = d3d_device->CreateVertexBuffer( factor * sizeof(POINTVERTEX), 
		D3DUSAGE_DYNAMIC | D3DUSAGE_WRITEONLY | D3DUSAGE_POINTS, 
		POINTVERTEX::FVF, D3DPOOL_DEFAULT, &vb );
	if (FAILED(hr)) {
		printf("Creation Failed: Parameters Of Creation: number = %d\n", factor);
		return hr;
	}

	hr = vb->Lock( 0, factor * sizeof(POINTVERTEX),
		(BYTE**) &pv, D3DLOCK_DISCARD );
	if (FAILED(hr)) {
		printf("Failed to create Lock created VertexBuffer\n");
		vb->Release();
		vb = NULL;
		return hr;
	}

	for (int i=0; i<3; i++) {
		pv->v = D3DXVECTOR3(0.0f, 0.0f, 0.0f);
		pv->color = axisColor[i];
		pv++;
		pv->v = D3DXVECTOR3(x[i][0], x[i][1], x[i][2])*100;
		pv->color = axisColor[i];
		pv++;
	}
	
	hr = vb->Unlock();	
	return hr;
}