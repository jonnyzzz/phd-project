// GraphResultImpl.h : Declaration of the CGraphResultImpl

#pragma once
#include "resource.h"       // main symbols
#include "graphResult.h"
#include "WritableGraphResult.h"


#include <list>
using namespace std;

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
	public IWritableGraphResult,
	public IGraphResult

{
public:
	CGraphResultImpl();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	void FinalRelease();

	// IGraphResult Methods
public:
	STDMETHOD(GetGraph)(void ** graph);
	STDMETHOD(GetGraphInfo)(IGraphInfo ** info);
	STDMETHOD(IsStrongComponent)(VARIANT_BOOL * value);
	
	// IWritableGraphResult Methods
public:
	STDMETHOD(SetGraph)(void** graph, VARIANT_BOOL isStringComponent);

private:
	Graph* graph;
	bool isStongComponent;

};

