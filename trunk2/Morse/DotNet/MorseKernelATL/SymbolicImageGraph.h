// SymbolicImageGraph.h : Declaration of the CSymbolicImageGraph

#pragma once
#include "resource.h"       // main symbols
#include "SymbolicImage.h"
#include "GraphSaver.h"

// ISymbolicImageGraph
[
	object,
	uuid("9ACF69A8-E19E-424A-AEAB-A1573408F0AE"),
	dual,	helpstring("ISymbolicImageGraph Interface"),
	pointer_default(unique)
]
__interface ISymbolicImageGraph : ISymbolicImage
{
	
	[id(10), local, hidden]
		HRESULT setGraph([in] void* graph);
	[id(11), local, hidden]
		HRESULT getGraph([out]void** graph);		
};



// CSymbolicImageGraph

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.SymbolicImageGraph"),
	progid("MorseKernelATL.SymbolicImageGraph.1"),
	version(1.0),
	uuid("A3AE65EC-004B-4CA9-937B-12565400662C"),
	helpstring("SymbolicImageGraph Class"),
]
class ATL_NO_VTABLE CSymbolicImageGraph : 
	public ISymbolicImageGraph,
	public ISubdevidable,
	public ISubdevidablePoint,
//	public IExtendable,
	public IExportData,
	private GraphSaver
{
public:
	CSymbolicImageGraph();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease(); 

private:
	Graph* graph;
	IKernel* kernel;

public:
    STDMETHOD(get_kernel)(IKernelPointer** pVal);
    STDMETHOD(putref_kernel)(IKernelPointer* newVal);
	
	STDMETHOD(graphDimension)(int* value);
	STDMETHOD(graphInfo)(IGraphInfo** info);

	STDMETHOD(getGraph)(void **graph);
	STDMETHOD(setGraph)(void * graph);

	STDMETHOD(acceptChilds)(void** data);

	STDMETHOD(Subdevide)(ISubdevideParams* params);
	STDMETHOD(SubdevidePoint)(ISubdevidePointParams* params);
	STDMETHOD(Extend)(IExtendableParams* params); 

	STDMETHOD(NewDimension)(int* value);

	STDMETHOD(ExportData)(BSTR file);

private:

	Function* getFunction();
};

