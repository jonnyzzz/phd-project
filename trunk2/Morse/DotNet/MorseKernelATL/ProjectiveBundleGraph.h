// ProjectiveBundleGraph.h : Declaration of the CProjectiveBundleGraph

#pragma once
#include "resource.h"       // main symbols
#include "ProjectiveBundle.h"
#include "GraphSaver.h"
#include "ComputationGraphResult.h"

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
]
class ATL_NO_VTABLE CProjectiveBundleGraph : 
	public IProjectiveBundleGraph,
//	public ISubdevidable,
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
	
private:
	IKernel* kernel;
	Graph* graph;
public:

    //IProjectiveBundleGraph		
	STDMETHOD(setGraph)(void* graph);
	STDMETHOD(getGraph)(void** graph);

    //IKernelNode
	STDMETHOD(get_kernel)(IKernelPointer** pVal);
	STDMETHOD(putref_kernel)(IKernelPointer* newVal);

    //IGraph
	STDMETHOD(acceptChilds)(void** data);
	STDMETHOD(graphInfo)(IGraphInfo** info);
	STDMETHOD(graphDimension)(int* value);

    //ISubdevidable
	STDMETHOD(Subdevide)(ISubdevideParams* params);

    //ISubdevidablePoint
	STDMETHOD(SubdevidePoint)(ISubdevidePointParams* params);
	
    //IMorsable
    STDMETHOD(Morse)();

    //IExportable
	STDMETHOD(ExportData)(BSTR fileNAme);

private:
	IProjectiveExtensionInfo* getProjectiveExtensionInfo();
};

