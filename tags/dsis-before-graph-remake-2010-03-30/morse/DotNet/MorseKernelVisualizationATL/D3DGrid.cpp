#include "StdAfx.h"
#include ".\d3dgrid.h"
#include "GraphEx.h"

const DWORD D3DGrid::CUSTOMVERTEX::FVF = D3DFVF_XYZ | D3DFVF_DIFFUSE | D3DFVF_SPECULAR | D3DFVF_TEX1;

D3DGrid::D3DGrid(HWND hwnd) : CD3DApplication(hwnd)
{
	m_strWindowTitle  = _T("DotProduct3: BumpMapping Technique");
    m_d3dEnumeration.AppUsesDepthBuffer = FALSE;

    m_pFont                = new CD3DFont( _T("Arial"), 12, D3DFONT_BOLD );

    m_bUseFileBasedTexture = FALSE;
    m_bShowNormalMap       = FALSE;

    m_pCustomNormalMap     = NULL;
    m_pFileBasedNormalMap  = NULL;
}

D3DGrid::~D3DGrid(void)
{
}



HRESULT D3DGrid::Create() {
	HRESULT hr = CD3DApplication::Create(NULL);

	if (FAILED(hr)) return hr;
/*
	JInt zg[] = {5,5};
	JDouble zmin[] = {0,0};
	JDouble zmax[] = {1,1};
	Graph* g = new Graph(2, zmin, zmax, zg);
	g->maximize();

	grep.SetGraph(new GraphEx(g));
	NodeEnumerator* ne = g->getNodeRoot();

	grep.HighLightNode(g->getNode(ne));
	g->freeNodeEnumerator(ne);
*/
	return S_OK;
}

//-----------------------------------------------------------------------------
// Name: VectortoRGBA()
// Desc: Turns a normalized vector into RGBA form. Used to encode vectors into
//       a height map. 
//-----------------------------------------------------------------------------
DWORD D3DGrid::VectortoRGBA( D3DXVECTOR3* v, FLOAT fHeight )
{
    DWORD r = (DWORD)( 127.0f * v->x + 128.0f );
    DWORD g = (DWORD)( 127.0f * v->y + 128.0f );
    DWORD b = (DWORD)( 127.0f * v->z + 128.0f );
    DWORD a = (DWORD)( 255.0f * fHeight );
    
    return( (a<<24L) + (r<<16L) + (g<<8L) + (b<<0L) );
}




//-----------------------------------------------------------------------------
// Name: InitVertex()
// Desc: Initializes a vertex
//-----------------------------------------------------------------------------
VOID D3DGrid::InitVertex( CUSTOMVERTEX* vtx, FLOAT x, FLOAT y, FLOAT z, FLOAT tu, FLOAT tv )
{
    D3DXVECTOR3 v(1,1,1);
    D3DXVec3Normalize( &v, &v );
    vtx[0].v        = D3DXVECTOR3( x, y, z );
    vtx[0].diffuse  = VectortoRGBA( &v, 1.0f );
    vtx[0].specular = 0x40400000;
    vtx[0].tu       = tu;
    vtx[0].tv       = tv;
}
    

//-----------------------------------------------------------------------------
// Name: OneTimeSceneInit()
// Desc: Called during initial app startup, this function performs all the
//       permanent initialization.
//-----------------------------------------------------------------------------
HRESULT D3DGrid::OneTimeSceneInit()
{
    InitVertex( &m_QuadVertices[0],-1.0f,-1.0f,-1.0f, 0.0f, 0.0f );
    InitVertex( &m_QuadVertices[1], 1.0f,-1.0f,-1.0f, 1.0f, 0.0f );
    InitVertex( &m_QuadVertices[2],-1.0f, 1.0f,-1.0f, 0.0f, 1.0f );
    InitVertex( &m_QuadVertices[3], 1.0f, 1.0f,-1.0f, 1.0f, 1.0f );

    m_vLight = D3DXVECTOR3( 0.0f, 0.0f, 1.0f );

    return S_OK;
}




//-----------------------------------------------------------------------------
// Name: FrameMove()
// Desc: Called once per frame, the call is the entry point for animating
//       the scene.
//-----------------------------------------------------------------------------
HRESULT D3DGrid::FrameMove()
{
    // Compute the light vector from the cursor position
    if( GetFocus() )
    {
        POINT pt;
        GetCursorPos( &pt );
        ScreenToClient( m_hWnd, &pt );

        m_vLight.x = -( ( ( 2.0f * pt.x ) / m_d3dsdBackBuffer.Width ) - 1 );
        m_vLight.y = -( ( ( 2.0f * pt.y ) / m_d3dsdBackBuffer.Height ) - 1 );
        m_vLight.z = 0.0f;

        if( D3DXVec3Length( &m_vLight ) > 1.0f )
            D3DXVec3Normalize( &m_vLight, &m_vLight );
        else
            m_vLight.z = sqrtf( 1.0f - m_vLight.x*m_vLight.x
                                     - m_vLight.y*m_vLight.y );
    }

    return S_OK;
}




//-----------------------------------------------------------------------------
// Name: Render()
// Desc: Called once per frame, the call is the entry point for 3d
//       rendering. This function sets up render states, clears the
//       viewport, and renders the scene.
//-----------------------------------------------------------------------------
HRESULT D3DGrid::Render()
{
    // Clear the render target
    m_pd3dDevice->Clear( 0L, NULL, D3DCLEAR_TARGET, 0xffffff, 1.0f, 0L );

    // Begin the scene
    if( SUCCEEDED( m_pd3dDevice->BeginScene() ) )
    {
		/*
        // Store the light vector, so it can be referenced in D3DTA_TFACTOR
        DWORD dwFactor = VectortoRGBA( &m_vLight, 0.0f );
        m_pd3dDevice->SetRenderState( D3DRS_TEXTUREFACTOR, dwFactor );

        // Modulate the texture (the normal map) with the light vector (stored
        // above in the texture factor)
        m_pd3dDevice->SetTextureStageState( 0, D3DTSS_COLORARG1, D3DTA_TEXTURE );
        m_pd3dDevice->SetTextureStageState( 0, D3DTSS_COLOROP,   D3DTOP_DOTPRODUCT3 );
        m_pd3dDevice->SetTextureStageState( 0, D3DTSS_COLORARG2, D3DTA_TFACTOR );

        // If user wants to see the normal map, override the above renderstates and
        // simply show the texture
        if( TRUE == m_bShowNormalMap )
            m_pd3dDevice->SetTextureStageState( 0, D3DTSS_COLOROP, D3DTOP_SELECTARG1 );

        // Select which normal map to use
        if( m_bUseFileBasedTexture )
            m_pd3dDevice->SetTexture( 0, m_pFileBasedNormalMap );
        else
            m_pd3dDevice->SetTexture( 0, m_pCustomNormalMap );

        // Draw the bumpmapped quad
        m_pd3dDevice->SetFVF( CUSTOMVERTEX::FVF );
        m_pd3dDevice->DrawPrimitiveUP( D3DPT_TRIANGLESTRIP, 2, m_QuadVertices, 
                                       sizeof(CUSTOMVERTEX) );

        // Output statistics
        m_pFont->DrawText( 2,  0, D3DCOLOR_ARGB(255,255,255,0), m_strFrameStats );
        m_pFont->DrawText( 2, 20, D3DCOLOR_ARGB(255,255,255,0), m_strDeviceStats );

        // End the scene.
		*/

		grep.Render(m_pd3dDevice);

        m_pd3dDevice->EndScene();
    }

    return S_OK;
}





//-----------------------------------------------------------------------------
// Name: 
// Desc: 
//-----------------------------------------------------------------------------
HRESULT D3DGrid::CreateFileBasedNormalMap()
{
    HRESULT hr = S_OK;
    LPDIRECT3DTEXTURE9 pFileBasedNormalMapSource = NULL;

    // Load the texture from a file
    if( FAILED( hr = D3DUtil_CreateTexture( m_pd3dDevice, _T("EarthBump.bmp"), 
                                            &pFileBasedNormalMapSource, 
                                            D3DFMT_A8R8G8B8 ) ) )
    {
        return D3DAPPERR_MEDIANOTFOUND;
    }

    D3DSURFACE_DESC desc;
    pFileBasedNormalMapSource->GetLevelDesc( 0, &desc );    

    if( FAILED( hr = D3DXCreateTexture( m_pd3dDevice, desc.Width, desc.Height, 
        pFileBasedNormalMapSource->GetLevelCount(), 0, 
        D3DFMT_A8R8G8B8, D3DPOOL_MANAGED, &m_pFileBasedNormalMap ) ) )
    {
        goto End;
    }

    if( FAILED( hr = D3DXComputeNormalMap( m_pFileBasedNormalMap, pFileBasedNormalMapSource,
        NULL, 0, D3DX_CHANNEL_RED, 1.0f ) ) )
    {
        goto End;
    }

End:
    SAFE_RELEASE( pFileBasedNormalMapSource );
    return hr;
}








//-----------------------------------------------------------------------------
// Name: 
// Desc: 
//-----------------------------------------------------------------------------
HRESULT D3DGrid::CreateCustomNormalMap()
{
    DWORD   dwWidth  = 512;
    DWORD   dwHeight = 512;
    HRESULT hr;

    // Create a 32-bit texture for the custom normal map
    hr = m_pd3dDevice->CreateTexture( dwWidth, dwHeight, 1, 
                                      0 /* Usage */, 
                                      D3DFMT_A8R8G8B8, D3DPOOL_MANAGED, 
                                      &m_pCustomNormalMap, NULL );
    if( FAILED(hr) )
        return hr;

    // Lock the texture to fill it with our custom image
    D3DLOCKED_RECT d3dlr;
    if( FAILED( m_pCustomNormalMap->LockRect( 0, &d3dlr, 0, 0 ) ) )
        return E_FAIL;
    DWORD* pPixel = (DWORD*)d3dlr.pBits;

    // Fill each pixel
    for( DWORD j=0; j<dwHeight; j++  )
    {
        for( DWORD i=0; i<dwWidth; i++ )
        {
            FLOAT xp = ( (5.0f*i) / (dwWidth-1)  );
            FLOAT yp = ( (5.0f*j) / (dwHeight-1) );
            FLOAT x  = 2*(xp-floorf(xp))-1;
            FLOAT y  = 2*(yp-floorf(yp))-1;
            FLOAT z  = sqrtf( 1.0f - x*x - y*y );

            // Make image of raised circle. Outside of circle is gray
            if( (x*x + y*y) <= 1.0f )
            {
                D3DXVECTOR3 vVector( x, y, z );
                *pPixel++ = VectortoRGBA( &vVector, 1.0f );
            }
            else
                *pPixel++ = 0x80808080;
        }
    }

    // Unlock the map and return successful
    m_pCustomNormalMap->UnlockRect(0);

    return S_OK;
}




//-----------------------------------------------------------------------------
// Name: InitDeviceObjects()
// Desc: Initialize scene objects.
//-----------------------------------------------------------------------------
HRESULT D3DGrid::InitDeviceObjects()
{
//    HRESULT hr;

    m_pFont->InitDeviceObjects( m_pd3dDevice );
/*
    // Create the normal maps
    if( FAILED( hr = CreateFileBasedNormalMap() ) )
        return hr;
    if( FAILED( hr = CreateCustomNormalMap() ) )
        return hr;
*/
	grep.InitDevice(m_pd3dDevice);

	/*
    // Set menu states
    CheckMenuItem( GetMenu(m_hWnd), IDM_USEFILEBASEDTEXTURE,
                   m_bUseFileBasedTexture ? MF_CHECKED : MF_UNCHECKED );
    CheckMenuItem( GetMenu(m_hWnd), IDM_USECUSTOMTEXTURE,
                   m_bUseFileBasedTexture ? MF_UNCHECKED : MF_CHECKED );
    CheckMenuItem( GetMenu(m_hWnd), IDM_SHOWNORMALMAP,    
                   m_bShowNormalMap ? MF_CHECKED : MF_UNCHECKED );

   */

    return S_OK;
}




//-----------------------------------------------------------------------------
// Name: RestoreDeviceObjects()
// Desc: Initialize scene objects.
//-----------------------------------------------------------------------------
HRESULT D3DGrid::RestoreDeviceObjects()
{
    m_pFont->RestoreDeviceObjects();

    // Set the transform matrices
    D3DXVECTOR3 vEyePt    = D3DXVECTOR3( 0.0f, 0.0f, 2.0f );
    D3DXVECTOR3 vLookatPt = D3DXVECTOR3( 0.0f, 0.0f, 0.0f );
    D3DXVECTOR3 vUpVec    = D3DXVECTOR3( 0.0f, 1.0f, 0.0f );
    D3DXMATRIXA16  matWorld, matView, matProj;
    
    D3DXMatrixIdentity( &matWorld );
    D3DXMatrixLookAtLH( &matView, &vEyePt, &vLookatPt, &vUpVec );
    FLOAT fAspect = m_d3dsdBackBuffer.Width / (FLOAT)m_d3dsdBackBuffer.Height;
    D3DXMatrixPerspectiveFovLH( &matProj, D3DX_PI/4, fAspect, 1.0f, 500.0f );
    
    m_pd3dDevice->SetTransform( D3DTS_WORLD,      &matWorld );
    m_pd3dDevice->SetTransform( D3DTS_VIEW,       &matView );
    m_pd3dDevice->SetTransform( D3DTS_PROJECTION, &matProj );
    
    // Set misc render states
    m_pd3dDevice->SetSamplerState( 0, D3DSAMP_MINFILTER, D3DTEXF_LINEAR );
    m_pd3dDevice->SetSamplerState( 0, D3DSAMP_MAGFILTER, D3DTEXF_LINEAR );
    m_pd3dDevice->SetRenderState( D3DRS_LIGHTING, FALSE );

	grep.InitDevice(m_pd3dDevice);

    return S_OK;
}




//-----------------------------------------------------------------------------
// Name: InvalidateDeviceObjects()
// Desc: Called when the app is exiting, or the device is being changed,
//       this function deletes any device dependent objects.
//-----------------------------------------------------------------------------
HRESULT D3DGrid::InvalidateDeviceObjects()
{
	grep.InitDevice(m_pd3dDevice);
    m_pFont->InvalidateDeviceObjects();
    return S_OK;
}




//-----------------------------------------------------------------------------
// Name: DeleteDeviceObjects()
// Desc: Called when the app is exiting, or the device is being changed,
//       this function deletes any device dependent objects.
//-----------------------------------------------------------------------------
HRESULT D3DGrid::DeleteDeviceObjects()
{
    m_pFont->DeleteDeviceObjects();
    SAFE_RELEASE( m_pFileBasedNormalMap );
    SAFE_RELEASE( m_pCustomNormalMap );

    return S_OK;
}




//-----------------------------------------------------------------------------
// Name: FinalCleanup()
// Desc: Called before the app exits, this function gives the app the chance
//       to cleanup after itself.
//-----------------------------------------------------------------------------
HRESULT D3DGrid::FinalCleanup()
{
    SAFE_DELETE( m_pFont );
    return S_OK;
}




//-----------------------------------------------------------------------------
// Name: ConfirmDevice()
// Desc: Called during device initialization, this code checks the device
//       for some minimum set of capabilities
//-----------------------------------------------------------------------------
HRESULT D3DGrid::ConfirmDevice( D3DCAPS9* pCaps, DWORD dwBehavior, 
                                          D3DFORMAT adapterFormat, D3DFORMAT backBufferFormat )
{

    //if( pCaps->TextureOpCaps & D3DTEXOPCAPS_DOTPRODUCT3 )
        return S_OK;
    
   // return E_FAIL;
}




//-----------------------------------------------------------------------------
// Name: MsgProc()
// Desc: Message proc function to handle key and menu input
//-----------------------------------------------------------------------------
LRESULT D3DGrid::MsgProc( UINT uMsg, WPARAM wParam,
                                    LPARAM lParam )
{
	switch (uMsg) {
		case WM_MOUSEMOVE:
			POINTS p = MAKEPOINTS(lParam);
			RECT r;
			CAxWindow wnd(m_hWnd);
			wnd.GetClientRect(&r);			
			if (grep.HighLightNode(grep.GetNodeBy(p, r))) 	
				Repaint();

			break;
	}
	return CD3DApplication::MsgProc( m_hWnd, uMsg, wParam, lParam );
}


GraphRepresentator& D3DGrid::getRepersentator() {
	return grep;
}

void D3DGrid::setGraphForLoopsColor(Graph* g) {
	printf("in workds: numNodes %d \n", g->getNumberOfNodes());
	grep.SetGraph(new GraphEx(g));
	Repaint();
}

bool D3DGrid::getSelectedNodeLoopLength(int* length) {
	Node* node = grep.getActiveNode();
	
	printf("PreEvent\n");

	if (node == NULL || node == cache) return false;

	cache = node;

	*length = grep.getGraphEx()[node]->minLoopLength;

	return true;
}
