// ProjectiveBundleGraph.h : Declaration of the CProjectiveBundleGraph

#pragma once
#include "resource.h"       // main symbols
#include "ProjectiveBundle.h"
#include "GraphSaver.h"

// IProjectiveBundleGraph
[
	object,
	uuid("9A232764-6785-421F-811A-D47B6F3BC9BE"),
	dual,	helpstring("IProjectiveBundleGraph Interface"),
	pointer_default(unique)
]
__interface IProjectiveBundleGraph : IProjectiveBundle
{
	[id(10), local, hidden]
		HRESULT setGraph([in] void* graph);
	[id(11), local, hidden]
		HRESULT getGraph([out] void** graph);
};



// CProjectiveBundleGraph

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.ProjectiveBundleGraph"),
	progid("MorseKernelATL.ProjectiveBundleGraph.1"),
	version(1.0),
	uuid("0FF20A2F-2518-4146-838A-EB5C0B42DD7B"),
	helpstring("ProjectiveBundleGraph Class"),
	event_source("com")
]
class ATL_NO_VTABLE CProjectiveBundleGraph : 
	public IProjectiveBundleGraph,
	public ISubdevidable,
	public ISubdevidablePoint,
	public IMorsable,
	public IExportData,
	private GraphSaver
{
public:
	CProjectiveBundleGraph();	

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();
	
	__event __interface AbstractEvent;
	__event __interface IProjectiveBundleEvents;

private:
	IKernel* kernel;
	Graph* graph;
public:

		
	STDMETHOD(setGraph)(void* graph);
	STDMETHOD(getGraph)(void** graph);

	STDMETHOD(get_kernel)(IKernel** pVal);
	STDMETHOD(putref_kernel)(IKernel* newVal);

	STDMETHOD(acceptChilds)(void** data) { return S_OK;}

	STDMETHOD(graphInfo)(IGraphInfo** info);
	STDMETHOD(graphDimension)(int* value);

	STDMETHOD(Subdevide)(ISubdevideParams* params);
	STDMETHOD(SubdevidePoint)(ISubdevidePointParams* params);
	STDMETHOD(Morse)();

	STDMETHOD(ExportData)(BSTR fileNAme);
};

