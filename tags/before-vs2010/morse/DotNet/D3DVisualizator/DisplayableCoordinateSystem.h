#pragma once

class DisplayableCoordinateSystem
{
public:
	DisplayableCoordinateSystem(void);
	virtual ~DisplayableCoordinateSystem(void);


public:
	HRESULT Create(LPDIRECT3DDEVICE8 d3d_device, D3DXVECTOR3 x[3]); 
	void Dispose();
	HRESULT Render();

protected:
	HRESULT initDevice();
	HRESULT render();
	

private:
	LPDIRECT3DDEVICE8 d3d_device;
	LPDIRECT3DVERTEXBUFFER8 vb;

	D3DXVECTOR3 x[3];

	DWORD axisColor[3];

private:
	struct POINTVERTEX {
		D3DXVECTOR3 v;
		DWORD color;

		static const DWORD FVF;
	};

protected:
	HRESULT CreateVertexBuffer();

};
