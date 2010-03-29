// MorseKernelVisualizationDirectGraph3D.h : Declaration of the CMorseKernelVisualizationDirectGraph3D
#pragma once
#include "resource.h"       // main symbols

#include "MorseKernelVisualizationDirect3D.h"

class D3DGraph3D;


// IMorseKernelVisualizationDirectGraph3D
[
	object,
	uuid(ADE7B805-2B13-46CC-9F90-7E4E6D1B9384),
	dual,
	helpstring("IMorseKernelVisualizationDirectGraph3D Interface"),
	pointer_default(unique)
]
__interface IMorseKernelVisualizationDirectGraph3D : public IMorseKernelVisualizationDirect3D
{
	[id(54)]
		HRESULT MoveFromEye([in]DOUBLE x, [in] DOUBLE y, [in] DOUBLE z);

	[id(55)]
		HRESULT SetEyeFrom([in]FLOAT x, [in]FLOAT y, [in] FLOAT z);
	[id(56)]
	    HRESULT SetEyeTo([in] FLOAT x, [in]FLOAT y, [in] FLOAT z);
	[id(57)]
		HRESULT Rotate([in] FLOAT onX, [in] FLOAT onY, [in] FLOAT onZ);
};


// CMorseKernelVisualizationDirectGraph3D
[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelVisualizationATL.MorseKernel"),
	progid("MorseKernelVisualizationATL.MorseKern.1"),
	version(1.1),
	uuid("3CF9772B-CC75-4596-A5EC-903D6ABD4983"),
	helpstring("MorseKernelVisualizationDirectGraph3D Class"),	
	event_source("com"),
	registration_script("control.rgs")
]
class ATL_NO_VTABLE CMorseKernelVisualizationDirectGraph3D : 	
	public IMorseKernelVisualizationDirectGraph3D,
	public IPersistStreamInitImpl<CMorseKernelVisualizationDirectGraph3D>,
	public IOleControlImpl<CMorseKernelVisualizationDirectGraph3D>,
	public IOleObjectImpl<CMorseKernelVisualizationDirectGraph3D>,
	public IOleInPlaceActiveObjectImpl<CMorseKernelVisualizationDirectGraph3D>,	
	public IViewObjectExImpl<CMorseKernelVisualizationDirectGraph3D>,
	public IOleInPlaceObjectWindowlessImpl<CMorseKernelVisualizationDirectGraph3D>,	
	public CComControl<CMorseKernelVisualizationDirectGraph3D>
{
public:

	__event __interface _IMorseKernelVisualizationDirect3DEvents;

	CMorseKernelVisualizationDirectGraph3D();
	

DECLARE_OLEMISC_STATUS(OLEMISC_RECOMPOSEONRESIZE | 
	OLEMISC_CANTLINKINSIDE | 
	OLEMISC_INSIDEOUT | 
	OLEMISC_ACTIVATEWHENVISIBLE | 
	OLEMISC_SETCLIENTSITEFIRST
)


BEGIN_PROP_MAP(CMorseKernelVisualizationDirectGraph3D)
	PROP_DATA_ENTRY("_cx", m_sizeExtent.cx, VT_UI4)
	PROP_DATA_ENTRY("_cy", m_sizeExtent.cy, VT_UI4)
END_PROP_MAP()


BEGIN_MSG_MAP(CMorseKernelVisualizationDirectGraph3D)
	MESSAGE_HANDLER(WM_CREATE, OnCreate)
	MESSAGE_HANDLER(WM_PAINT, OnPaint)


	CHAIN_MSG_MAP(CComControl<CMorseKernelVisualizationDirectGraph3D>)

	DEFAULT_REFLECTION_HANDLER()
END_MSG_MAP()

// IViewObjectEx
	DECLARE_VIEW_STATUS(VIEWSTATUS_SOLIDBKGND | VIEWSTATUS_OPAQUE)

// IMorseKernelVisualizationDirectGraph3D

	LRESULT OnCreate(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/);
	LRESULT OnPaint(UINT, WPARAM, LPARAM, BOOL&);


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();	
	void FinalRelease();

public:
	STDMETHOD(MoveLeftAtom)();
	STDMETHOD(MoveRightAtom)();
	STDMETHOD(MoveUpAtom)();
	STDMETHOD(MoveDownAtom)();
	STDMETHOD(ZoomOutAtom)();
	STDMETHOD(ZoomInAtom)();
	STDMETHOD(CenterView)();

	STDMETHOD(MoveFromEye) (DOUBLE x, DOUBLE y, DOUBLE z);
	STDMETHOD(SetEyeFrom) (FLOAT x, FLOAT y, FLOAT z);
	STDMETHOD(SetEyeTo) (FLOAT x, FLOAT y, FLOAT z);
	STDMETHOD(Rotate) (FLOAT onX, FLOAT onY, FLOAT onZ);

public:
	STDMETHOD(SetGraph)(void **);
	STDMETHOD(SetTestGraph) ();


private:
	void Repaint();


private:
	D3DGraph3D* m_hD3D;


};

