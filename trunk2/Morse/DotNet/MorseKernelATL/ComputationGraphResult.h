// ComputationGraphResult.h : Declaration of the CComputationGraphResult

#pragma once
#include "resource.h"       // main symbols

#include "nodebase.h"

class Graph;

// IComputationGraphResultExt
[
	object,
	uuid("A16233C4-8412-43B1-B8FB-C339F86EFB55"),
	dual,	helpstring("IComputationGraphResultExt Interface"),
	pointer_default(unique)
]
__interface IComputationGraphResultExt : IComputationGraphResult
{
	[id(101), local, hidden]
		HRESULT setRootGraph([in] void** graph);
	[id(102), local, hidden]
		HRESULT setGraphNode([in] IGraph* node);
};


// CComputationGraphResult

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.ComputationGraphResult"),
	progid("MorseKernelATL.ComputationGraphResult.1"),
	version(1.0),
	uuid("83FCA237-5E87-49D4-81EE-95BC812422FE"),
	helpstring("ComputationGraphResult Class")
]
class ATL_NO_VTABLE CComputationGraphResult : 
	public IComputationGraphResultExt
{
public:
	CComputationGraphResult();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

private:
	Graph* graph;
	IGraph* node;

public:
	STDMETHOD( StrongComponents) ();
	STDMETHOD( StrongComponentsEdges) ();
	STDMETHOD( Loops) ();
	STDMETHOD( setRootGraph) (void ** graph);
	STDMETHOD( setGraphNode) (IGraph* graphNode);
};