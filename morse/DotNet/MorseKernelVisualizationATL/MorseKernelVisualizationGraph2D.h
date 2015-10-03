#pragma once

#include "MorseKernelVisualizationDirect3D.h"

class D3DGraph2D;

// IMorseKernelVisualizationDirectGraph2D
[
	object,
	uuid("31146F99-AA89-4E63-94B2-CFF1358E46ED"),
	dual,
	helpstring("IMorseKernelVisualizationDirectGraph2D Interface"),
	pointer_default(unique)
]
__interface IMorseKernelVisualizationDirectGraph2D : public IMorseKernelVisualizationDirect3D
{
};


// CMorseKernelVisualizationDirectGraph2D
[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelVisualizationATL.MorseKernel"),
	progid("MorseKernelVisualizationATL.MorseKern.1"),
	version(1.0),
	uuid("2BBDCC1B-8356-4536-9C86-0CBABD9158B0"),
	helpstring("MorseKernelVisualizationDirect3D Class"),
	event_source("com"),
	registration_script("control.rgs")
]
class ATL_NO_VTABLE CMorseKernelVisualizationDirectGraph2D : 
	public IMorseKernelVisualizationDirectGraph2D,	
	public IPersistStreamInitImpl<CMorseKernelVisualizationDirectGraph2D>,
	public IOleControlImpl<CMorseKernelVisualizationDirectGraph2D>,
	public IOleObjectImpl<CMorseKernelVisualizationDirectGraph2D>,
	public IOleInPlaceActiveObjectImpl<CMorseKernelVisualizationDirectGraph2D>,
	public IViewObjectExImpl<CMorseKernelVisualizationDirectGraph2D>,
	public IOleInPlaceObjectWindowlessImpl<CMorseKernelVisualizationDirectGraph2D>,
	public CComControl<CMorseKernelVisualizationDirectGraph2D>
{
public:

//construction
	CMorseKernelVisualizationDirectGraph2D();


//macros
DECLARE_OLEMISC_STATUS(OLEMISC_RECOMPOSEONRESIZE | 
	OLEMISC_CANTLINKINSIDE | 
	OLEMISC_INSIDEOUT | 
	OLEMISC_ACTIVATEWHENVISIBLE | 
	OLEMISC_SETCLIENTSITEFIRST
)


BEGIN_PROP_MAP(CMorseKernelVisualizationDirectGraph2D)
	PROP_DATA_ENTRY("_cx", m_sizeExtent.cx, VT_UI4)
	PROP_DATA_ENTRY("_cy", m_sizeExtent.cy, VT_UI4)
	// Example entries
	// PROP_ENTRY("Property Description", dispid, clsid)
	// PROP_PAGE(CLSID_StockColorPage)
END_PROP_MAP()


BEGIN_MSG_MAP(CMorseKernelVisualizationDirectGraph2D)
	MESSAGE_HANDLER(WM_CREATE, OnCreate)
	MESSAGE_HANDLER(WM_PAINT, OnPaint)
	
	MESSAGE_HANDLER(WM_ENTERSIZEMOVE, OnEnterMove)
	MESSAGE_HANDLER(WM_SIZE, OnSize)
	MESSAGE_HANDLER(WM_EXITSIZEMOVE, OnExitMove)
	MESSAGE_HANDLER(WM_MOUSEMOVE, OnMouseMove)
	MESSAGE_HANDLER(WM_CLOSE, OnClose)

	CHAIN_MSG_MAP(CComControl<CMorseKernelVisualizationDirectGraph2D>)
	DEFAULT_REFLECTION_HANDLER()
END_MSG_MAP()


// Handler prototypes:
//  LRESULT MessageHandler(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
//  LRESULT CommandHandler(WORD wNotifyCode, WORD wID, HWND hWndCtl, BOOL& bHandled);
//  LRESULT NotifyHandler(int idCtrl, LPNMHDR pnmh, BOOL& bHandled);

 	__event __interface _IMorseKernelVisualizationDirect3DEvents;
// IViewObjectEx
	DECLARE_VIEW_STATUS(VIEWSTATUS_SOLIDBKGND | VIEWSTATUS_OPAQUE)


// IMorseKernelVisualizationDirect3D

	LRESULT OnCreate(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/);
	LRESULT OnPaint(UINT, WPARAM, LPARAM, BOOL&);
	LRESULT OnEnterMove(UINT, WPARAM, LPARAM, BOOL&);
	LRESULT OnSize(UINT, WPARAM, LPARAM, BOOL&);
	LRESULT OnExitMove(UINT, WPARAM, LPARAM, BOOL&);
	LRESULT OnMouseMove(UINT, WPARAM, LPARAM, BOOL&);
	LRESULT OnClose(UINT, WPARAM, LPARAM, BOOL&);

	void DrawBorder2D();
	void Repaint();

	STDMETHOD(TranslateAccelerator)(LPMSG pMsg);

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease(); 


	//D3D
	D3DGraph2D* m_hD3D;
	CAxWindow d3dWindow;
	Node* currentNode;

public:
	STDMETHOD(MoveLeftAtom)();
	STDMETHOD(MoveRightAtom)();
	STDMETHOD(MoveUpAtom)();
	STDMETHOD(MoveDownAtom)();
	STDMETHOD(ZoomOutAtom)();
	STDMETHOD(ZoomInAtom)();
	STDMETHOD(CenterView)();

public:
	STDMETHOD(SetGraph)(void** graph);

	STDMETHOD(SetTestGraph)();
};

