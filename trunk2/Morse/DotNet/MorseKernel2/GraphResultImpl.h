// GraphResultImpl.h : Declaration of the CGraphResultImpl

#pragma once
#include "resource.h"       // main symbols
#include "graphResult.h"
#include "WritableGraphResult.h"


#include <list>
using namespace std;

[
	object,
	dual,
	uuid("150237B9-7739-4882-87E1-8FE926A96AFF"),
	pointer_default(unique)
]
__interface IGraphResultImpl : IDispatch {

};


class Graph;

// CGraphResultImpl

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.GraphResultImpl"),
	progid("MorseKernel2.GraphResultImpl.1"),
	version(1.0),
	uuid("43037E6F-9884-4D5C-BB41-44D582888F9E"),
	helpstring("GraphResultImpl Class")
]
class ATL_NO_VTABLE CGraphResultImpl :
	public IGraphResultImpl,
	public IWritableGraphResult,
	public IGraphResult

{
public:
	CGraphResultImpl();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	void FinalRelease();

	//IResult
public:
	STDMETHOD(GetMetadata)(IResultMetadata** out);

	// IGraphResult Methods
public:
	STDMETHOD(GetGraph)(void ** graph);
	STDMETHOD(GetGraphInfo)(IGraphInfo ** info);
	STDMETHOD(IsStrongComponent)(VARIANT_BOOL * value);

	STDMETHOD(SaveText)(BSTR file);
	STDMETHOD(SaveGraph)(BSTR file);
	
	// IWritableGraphResult Methods
public:
	STDMETHOD(SetGraph)(void** graph, VARIANT_BOOL isStringComponent);
	STDMETHOD(SetMetadata)(IResultMetadata* in);

private:
	IResultMetadata* metadata;
	Graph* graph;
	bool isStongComponent;
};

