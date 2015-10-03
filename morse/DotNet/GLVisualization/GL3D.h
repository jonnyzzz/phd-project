// GL3D.h : Declaration of the CGL3D
#pragma once
#include "resource.h"       // main symbols
#include <atlctl.h>

// IGL3D
[
	object,
	uuid(B1D47447-E686-41A7-9A02-6BC3CCFF0269),
	dual,
	helpstring("IGL3D Interface"),
	pointer_default(unique)
]
__interface IGL3D : public IDispatch
{
};


// _IGL3DEvents
[
	uuid("F37FCEE2-A358-41D1-BF3F-D19CAA7F7D01"),
	dispinterface,
	helpstring("_IGL3DEvents Interface")
]
__interface _IGL3DEvents
{
};

// CGL3D
[
	coclass,
	threading("apartment"),
	vi_progid("GLVisualization.GL3D"),
	progid("GLVisualization.GL3D.1"),
	version(1.0),
	uuid("F0160158-6F4D-4AD0-AC2B-C5773E2A1754"),
	helpstring("GL3D Class"),
	event_source("com"),
	support_error_info(IGL3D),
	registration_script("control.rgs")
]
class ATL_NO_VTABLE CGL3D : 
	public IGL3D,
	public IPersistStreamInitImpl<CGL3D>,
	public IOleControlImpl<CGL3D>,
	public IOleObjectImpl<CGL3D>,
	public IOleInPlaceActiveObjectImpl<CGL3D>,
	public IViewObjectExImpl<CGL3D>,
	public IOleInPlaceObjectWindowlessImpl<CGL3D>,
	public IPersistStorageImpl<CGL3D>,
	public ISpecifyPropertyPagesImpl<CGL3D>,
	public IQuickActivateImpl<CGL3D>,
	public IDataObjectImpl<CGL3D>,
	public CComControl<CGL3D>
{
public:

	CGL3D()
	{
	}

DECLARE_OLEMISC_STATUS(OLEMISC_RECOMPOSEONRESIZE | 
	OLEMISC_CANTLINKINSIDE | 
	OLEMISC_INSIDEOUT | 
	OLEMISC_ACTIVATEWHENVISIBLE | 
	OLEMISC_SETCLIENTSITEFIRST
)


BEGIN_PROP_MAP(CGL3D)
	PROP_DATA_ENTRY("_cx", m_sizeExtent.cx, VT_UI4)
	PROP_DATA_ENTRY("_cy", m_sizeExtent.cy, VT_UI4)
	// Example entries
	// PROP_ENTRY("Property Description", dispid, clsid)
	// PROP_PAGE(CLSID_StockColorPage)
END_PROP_MAP()


BEGIN_MSG_MAP(CGL3D)
	MESSAGE_HANDLER(WM_CREATE, OnCreate)
	MESSAGE_HANDLER(WM_PAINT, OnPaint)
	CHAIN_MSG_MAP(CComControl<CGL3D>)
	DEFAULT_REFLECTION_HANDLER()
END_MSG_MAP()
// Handler prototypes:
//  LRESULT MessageHandler(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
//  LRESULT CommandHandler(WORD wNotifyCode, WORD wID, HWND hWndCtl, BOOL& bHandled);
//  LRESULT NotifyHandler(int idCtrl, LPNMHDR pnmh, BOOL& bHandled);

	__event __interface _IGL3DEvents;
// IViewObjectEx
	DECLARE_VIEW_STATUS(VIEWSTATUS_SOLIDBKGND | VIEWSTATUS_OPAQUE)

// IGL3D
public:
	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	void FinalRelease();

public:
	LRESULT OnCreate(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
	LRESULT OnPaint(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);

//OpenGL Code

private:
	HGLRC glRC;

private:
	BOOL setPixelFormat(HDC hdc);
	void initializeGL();
	void resize();

	void createBox();
	void presentBox();



//Debugging
private:
	void ShowErrorMessage(LPCSTR message);
	void ShowErrorMessage(LPCSTR message, LPCSTR function, long line, LPCSTR file);
};