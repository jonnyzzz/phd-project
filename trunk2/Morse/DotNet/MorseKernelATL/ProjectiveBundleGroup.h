// ProjectiveBundleGroup.h : Declaration of the CProjectiveBundleGroup

#pragma once
#include "resource.h"       // main symbols
#include "ProjectiveBundle.h"
#include "ProjectiveBundleGraph.h"
#include "MorseSpectrum.h"
#include "Kernel.h"
#include <list>

#include "GraphSaver.h"


// IProjectiveBundleGroup
[
	object,
	uuid("979E3895-84BD-489D-A0A9-C6C73D623CE2"),
	dual,	helpstring("IProjectiveBundleGroup Interface"),
	pointer_default(unique)
]
__interface IProjectiveBundleGroup : IProjectiveBundle
{
	[id(10)]
		HRESULT addNode([in]IProjectiveBundleGraph* bn);

	[id(11)]
		HRESULT removeNode([in] IProjectiveBundleGraph* img);	
};



// CProjectiveBundleGroup

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.ProjectiveBundleGroup"),
	progid("MorseKernelATL.ProjectiveBundleGroup.1"),
	version(1.0),
	uuid("520018A2-475A-4FB5-A780-E1291049BAB5"),
	helpstring("ProjectiveBundleGroup Class"),
]
class ATL_NO_VTABLE CProjectiveBundleGroup : 
	public IProjectiveBundleGroup,
//	public ISubdevidable,
	public ISubdevidablePoint,
//	public IMorsable,
	public IGroupNode,
	public IExportData,
	private GraphSaver
{
public:
	CProjectiveBundleGroup();
	
	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	
	void FinalRelease();
	

private:
	typedef list<IProjectiveBundleGraph*> ListProjectiveBundle;
	typedef ListProjectiveBundle::iterator ListProjectiveBundleIterator;

	ListProjectiveBundle nodeList;

private:
	GraphComponents* createGraphComponents();
	IKernel* kernel;
public:

	STDMETHOD(addNode)(IProjectiveBundleGraph* graph);
	STDMETHOD(removeNode)(IProjectiveBundleGraph* graph);
	STDMETHOD(nodeCount)(int* val);

	STDMETHOD(get_kernel)(IKernelPointer** pVal);
	STDMETHOD(putref_kernel)(IKernelPointer* newVal);

	STDMETHOD(acceptChilds)(void** data);

	STDMETHOD(graphInfo)(IGraphInfo** info);
	STDMETHOD(graphDimension)(int* value);

	STDMETHOD(Subdevide)(ISubdevideParams* params);
	STDMETHOD(SubdevidePoint)(ISubdevidePointParams* params);
	STDMETHOD(Morse)();

	STDMETHOD(ExportData)(BSTR fileName);
};

