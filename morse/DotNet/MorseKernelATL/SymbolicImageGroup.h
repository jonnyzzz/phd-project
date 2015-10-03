// SymbolicImageGroup.h : Declaration of the CSymbolicImageGroup

#pragma once
#include "resource.h"       // main symbols
#include "SymbolicImage.h"
#include "SymbolicImageGraph.h"
#include <list>

#include "GraphInfo.h"
#include "GraphSaver.h"
#include "ActionPerformerBase.h"

// ISymbolicImageGroup
[
	object,
	uuid("148EBD9B-8DB6-44DF-8148-0F71F2B07890"),
	dual,	helpstring("ISymbolicImageGroup Interface"),
	pointer_default(unique)
]
__interface ISymbolicImageGroup : ISymbolicImage
{
	[id(10), helpstring("Add an ISymbolicImage object to a collection")]
		HRESULT addNode([in]ISymbolicImageGraph* img);

	[id(11)]
		HRESULT removeNode([in] ISymbolicImageGraph* img);
};



// CSymbolicImageGroup

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.SymbolicImageGroup"),
	progid("MorseKernelATL.SymbolicImageGroup.1"),
	version(1.0),
	uuid("00414483-2F27-43B5-B7A6-68A9E9674CC9"),
	helpstring("SymbolicImageGroup Class")
]
class ATL_NO_VTABLE CSymbolicImageGroup : 
	public ISymbolicImageGroup,
	public ISubdevidable,
	public ISubdevidablePoint,
	public IExtendable,
    public IComputationExtendingResult,
	public IGroupNode,
	public IExportData,
	private GraphSaver,
	private ActionPerformerBase
{
public:
	CSymbolicImageGroup();


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease(); 


private:
	typedef list<ISymbolicImageGraph*> ISymbolicImageList;
	typedef ISymbolicImageList::iterator ISymbolicImageListIterator;

	ISymbolicImageList nodeList;
	IKernel* kernel;
	
private:
	GraphComponents* createGraphComponents();

public:

    //IGroupNode
	STDMETHOD(addNode)(ISymbolicImageGraph* im);
	STDMETHOD(removeNode)(ISymbolicImageGraph* im);
	STDMETHOD(nodeCount)(int* val);
	STDMETHOD(getNode)(int index, IKernelNode** node);


    //IKernelNode
    STDMETHOD(get_kernel)(IKernelPointer** pVal);
    STDMETHOD(putref_kernel)(IKernelPointer* newVal);	

    //IGraphNode
	STDMETHOD(acceptChilds)(void** data);
	STDMETHOD(graphInfo)(IGraphInfo** info);
	STDMETHOD(graphDimension)(int* val);

    //ISubdevidable
	STDMETHOD(Subdevide)(ISubdevideParams* params);

    //ISubdevidablePoint
	STDMETHOD(SubdevidePoint)(ISubdevidePointParams* params);

    //IExtendable
	STDMETHOD(Extend)();

    //IComputationExtendingResult
    STDMETHOD(PointMethodProjectiveExtension)(IExtendablePointParams* params);
    STDMETHOD(PointMethodProjectiveExtensionDimension)(int* dim);


    //IExportable
	STDMETHOD(ExportData)(BSTR fileName);


	
};