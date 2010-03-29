#pragma once

#include "stdafx.h"

class D3DKernel
{
public:
	D3DKernel();
	virtual ~D3DKernel();

public:
	HRESULT Create(HWND hwnd);
	void	Dispose();

protected:
	bool is_initialized;
	
private:
	
	HRESULT createD3DObject();
	
	HRESULT createD3DDevice();
	
	HRESULT createD3DDevice(D3DDEVTYPE type, DWORD behaviour);

protected:
	HRESULT render();

protected:
	DWORD backColor;

	HWND d3d_hwnd;
	LPDIRECT3D8 d3d;
	LPDIRECT3DDEVICE8 d3d_device;
	D3DCAPS8 d3d_caps;


protected:
	virtual HRESULT initRenderSettings() {return S_OK;};
	virtual HRESULT initMatrices() {return S_OK;};
	virtual HRESULT renderPrimitive() {return S_OK;};
	virtual HRESULT afterMatricesInitExtRender() {return S_OK;};
	virtual HRESULT initRenderSettiongAfterScene() {return S_OK;};	
};



class D3DKernelException
{
public: 
	D3DKernelException(const char* message, bool is_exception = true);

	const char* getMessage() const;

public:
	static void setExternalBuffer(char* buffer);
	static char* getExternalBuffer();


private:
	const char* message;

	static char* buffer;
	static char* pointer;

};
