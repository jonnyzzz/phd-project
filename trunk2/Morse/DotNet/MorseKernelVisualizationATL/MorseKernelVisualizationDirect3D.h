// MorseKernelVisualizationDirect3D.h : Declaration of the CMorseKernelVisualizationDirect3D
#pragma once
#include "resource.h"       // main symbols

// IMorseKernelVisualizationDirect3D
[
	object,
	uuid("35435412-4462-4A3D-A9C8-CEB11AC900EE"),
	dual,
	helpstring("IMorseKernelVisualizationDirect3D Interface"),
	pointer_default(unique)
]
__interface IMorseKernelVisualizationDirect3D : public IDispatch
{
	[id(1)]
	HRESULT MoveLeftAtom();
	[id(2)]
	HRESULT MoveRightAtom();
	[id(3)]
	HRESULT MoveUpAtom();
	[id(4)]
	HRESULT MoveDownAtom();
	[id(5)]
	HRESULT ZoomOutAtom();
	[id(6)]
	HRESULT ZoomInAtom();
	[id(7)]
	HRESULT CenterView();
	
	[id(8), local]
	HRESULT SetGraph([in]void** graph);

	[id(9)]
	HRESULT SetTestGraph();

};


// _IMorseKernelVisualizationDirect3DEvents
[
	uuid("FE6F9A99-FF69-44D9-89AD-685E6C7303CA"),
	dispinterface,
	helpstring("_IMorseKernelVisualizationDirect3DEvents Interface")
]
__interface _IMorseKernelVisualizationDirect3DEvents
{
	[id(1)]
	HRESULT ActiveLoop([in]int length);

	[id(2)]
	HRESULT OnMouseMoveFloat([in] double x1, [in] double x2, [in] double x3);
};

