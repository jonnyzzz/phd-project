#pragma once
#include "direct3d\common\include\d3dapp.h"
#include "TextureManager.h"
#include "GraphRepresentator.h"


class D3DGrid :
	public CD3DApplication
{
private:
	struct CUSTOMVERTEX
	{
		D3DXVECTOR3 v;
		DWORD       diffuse;
		DWORD       specular;
		FLOAT       tu, tv;

		static const DWORD FVF;
	};

	VOID InitVertex( CUSTOMVERTEX* vtx, FLOAT x, FLOAT y, FLOAT z, FLOAT tu, FLOAT tv );
	DWORD VectortoRGBA( D3DXVECTOR3* v, FLOAT fHeight );

public:
	D3DGrid(HWND hwnd);
	virtual ~D3DGrid(void);

public:
	HRESULT virtual Create();

private:
    CD3DFont*          m_pFont;
    CUSTOMVERTEX       m_QuadVertices[4];
    LPDIRECT3DTEXTURE9 m_pCustomNormalMap;
    LPDIRECT3DTEXTURE9 m_pFileBasedNormalMap;
    D3DXVECTOR3        m_vLight;

    BOOL               m_bUseFileBasedTexture;
    BOOL               m_bShowNormalMap;

    HRESULT CreateFileBasedNormalMap();
    HRESULT CreateCustomNormalMap();
    HRESULT ConfirmDevice( D3DCAPS9*, DWORD, D3DFORMAT, D3DFORMAT );

public:
    LRESULT MsgProc( UINT uMsg, WPARAM wParam, LPARAM lParam );

protected:
    HRESULT OneTimeSceneInit();
    HRESULT InitDeviceObjects();
    HRESULT RestoreDeviceObjects();
    HRESULT InvalidateDeviceObjects();
    HRESULT DeleteDeviceObjects();
    HRESULT Render();
    HRESULT FrameMove();
    HRESULT FinalCleanup();

private:
//	TextureManager manager;
	GraphRepresentator grep;
	Node* cache;

public:
	GraphRepresentator& getRepersentator();

	void setGraphForLoopsColor(Graph* g);

	bool getSelectedNodeLoopLength(int* length);
	
};
