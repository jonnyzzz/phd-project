#include "StdAfx.h"
#include ".\d3dkernel.h"



D3DKernel::D3DKernel(void)
{
	is_initialized = false;
	backColor = 0xffffff;
	d3d = NULL;
	d3d_device = NULL;
	d3d_hwnd = NULL;
}

D3DKernel::~D3DKernel(void)
{
}



HRESULT D3DKernel::Create(HWND hwnd) {
	if (this->is_initialized) {
		D3DKernelException("D3D Allready Created");
		return E_FAIL;
	}

	this->d3d_hwnd = hwnd;

	HRESULT hr;

	hr = createD3DObject();
	if (FAILED(hr)) {
		D3DKernelException("Failed to create D3D Object");
		return hr;
	}


	if (FAILED(createD3DDevice())) {
		D3DKernelException("Failed to create IDirect3DDevice8");
		return E_FAIL;
	}


	is_initialized = true;
    return S_OK;
}
                   
HRESULT D3DKernel::createD3DObject() {
	this->d3d = Direct3DCreate8(D3D_SDK_VERSION);
	if (d3d == NULL) {
		D3DKernelException("Failed To Create IDirect3D8 Object");
		return E_FAIL;
	}
	return S_OK;
}


HRESULT D3DKernel::createD3DDevice(D3DDEVTYPE type, DWORD behave) {
	HRESULT hr;

	D3DDISPLAYMODE d3ddm;
	hr = d3d->GetAdapterDisplayMode( D3DADAPTER_DEFAULT, &d3ddm );

	if (FAILED( hr ) )
	{
		D3DKernelException("Unable to get Adapter mode from IDirect3D9");
		return hr;
	}

	D3DPRESENT_PARAMETERS d3dpp; 
	ZeroMemory( &d3dpp, sizeof(d3dpp) );

	RECT r;
	GetClientRect(d3d_hwnd, &r);		

	d3dpp.Windowed = TRUE;
	d3dpp.hDeviceWindow = d3d_hwnd;
	d3dpp.BackBufferFormat = d3ddm.Format;
	d3dpp.BackBufferHeight = r.bottom - r.top;
	d3dpp.BackBufferWidth = r.right - r.left;
	d3dpp.BackBufferCount = 1;	
	d3dpp.SwapEffect = D3DSWAPEFFECT_DISCARD;
	d3dpp.EnableAutoDepthStencil = TRUE;
	d3dpp.AutoDepthStencilFormat = D3DFMT_D32;

	hr = d3d->CreateDevice(
		  D3DADAPTER_DEFAULT,
		  type,
		  d3d_hwnd,
		  D3DCREATE_MULTITHREADED | behave,
		  &d3dpp,
		  &this->d3d_device
		  );

	switch (hr) {
		case S_OK:
			D3DKernelException("Success!");
			break;
		case D3DERR_INVALIDCALL:
			D3DKernelException("Failed: Invalid Call: D3DERR_INVALIDCALL");
			break;
		case D3DERR_NOTAVAILABLE:
			D3DKernelException("Failed: Not Available: D3DERR_NOTAVAILABLE");
			break;
		case D3DERR_OUTOFVIDEOMEMORY:
			D3DKernelException("Failed: Not Video Memory: D3DERR_NOTAVAILABLE");
			break;
		default:
			D3DKernelException("Other exception");
			break;
	}

	D3DKernelException("\n");

	return hr;
}

HRESULT D3DKernel::createD3DDevice() {
	HRESULT hr;

/*
	D3DKernelException("Create HAL, HARDWARE_VERTEX_PROCESSING");
	hr = this->createD3DDevice(D3DDEVTYPE_HAL, D3DCREATE_HARDWARE_VERTEXPROCESSING);	
	if (SUCCEEDED(hr)) return hr;

	D3DKernelException("Create HAL, SOFTWARE_VERTEX_PROCESSING");
	hr = this->createD3DDevice(D3DDEVTYPE_HAL, D3DCREATE_SOFTWARE_VERTEXPROCESSING);
	if (SUCCEEDED(hr)) return hr;
	
	D3DKernelException("Create REF, HARDWARE_VERTEX_PROCESSING");
	hr = this->createD3DDevice(D3DDEVTYPE_REF, D3DCREATE_HARDWARE_VERTEXPROCESSING);
	if (SUCCEEDED(hr)) return hr;
*/
	D3DKernelException("Create REF, SOFTWARE_VERTEX_PROCESSING");
	hr = this->createD3DDevice(D3DDEVTYPE_REF, D3DCREATE_SOFTWARE_VERTEXPROCESSING);	

	
	if (FAILED(hr)) {
		D3DKernelException("Unable to Found suitable D3DDevice. Probably there is no video drivers in the system");
	}

	if (SUCCEEDED(hr)) {	
		d3d_device->GetDeviceCaps(&d3d_caps);

		char buff[255];	
		sprintf(buff, "MaxPrimitiveCount = %d", d3d_caps.MaxPrimitiveCount);
		D3DKernelException((char*)buff);
	}
	
	return hr;
}

/////////////////////////////////////////////////////////////////////////////////


HRESULT D3DKernel::render() {
	if (!is_initialized)
		return E_FAIL;

	HRESULT hr;

	hr = d3d_device->SetRenderState(D3DRS_ZENABLE, TRUE);
	if (FAILED(hr)) {
		is_initialized = false;
		return hr;
	}
	hr = d3d_device->SetRenderState(D3DRS_ZWRITEENABLE, TRUE);
	if (FAILED(hr)) {
		is_initialized = false;
		return hr;
	}

	d3d_device->Clear( 0, NULL, D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER , backColor, 1.0f, 0 );

	hr = initMatrices();
	if (FAILED(hr)) {
		is_initialized = false;
		return hr;
	}

	hr = afterMatricesInitExtRender();
	if (FAILED(hr)) {
		is_initialized = false;
		return hr;
	}

	hr = initRenderSettings();
	if (FAILED(hr)) {
		is_initialized = false;
		return hr;
	}

	///////////// begin scene
	hr = d3d_device->BeginScene();
	if (FAILED(hr)) {
		is_initialized = false;
		return hr;
	}
	
	hr = initRenderSettiongAfterScene();
	if (FAILED(hr)) {
		is_initialized = false;
		return hr;
	}


	hr = renderPrimitive();
	if (FAILED(hr)) {
		is_initialized = false;
		return hr;
	}

	hr = d3d_device->EndScene();
	if (FAILED(hr)) {
		is_initialized = false;
		return hr;
	}

	hr = d3d_device->Present(NULL, NULL, NULL, NULL);
	if (FAILED(hr)) {
		is_initialized = false;
		return hr;
	}

	return S_OK;
}

/////////////////////////////////////////////////////////////////////////////////

void D3DKernel::Dispose() {
	if (this->d3d_device != NULL) {
		d3d_device->Release();
	}
	if (this->d3d != NULL) {
		d3d->Release();
	}
	is_initialized = false;
}


//////////////////////////////////////////////////////////////////////////////

D3DKernelException::D3DKernelException(const char* message, bool is_exception) {
	printf("D3DKernelException: %s \n", message);
	this->message = message;

	if (buffer != NULL) {
		int t = sprintf(pointer, "%s\n", message);
		pointer += (t>0)?t:0;
	}
}

const char* D3DKernelException::getMessage() const {
	return message;
}

char* D3DKernelException::buffer = NULL;
char* D3DKernelException::pointer = NULL;

void D3DKernelException::setExternalBuffer(char* buffer) {
	D3DKernelException::buffer = buffer;
	D3DKernelException::pointer = buffer;

	pointer += sprintf(pointer, "Exception call dump:\n");
}

char* D3DKernelException::getExternalBuffer() {
	return buffer;
}