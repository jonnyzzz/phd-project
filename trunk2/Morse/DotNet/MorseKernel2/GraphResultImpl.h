// GraphResultImpl.h : Declaration of the CGraphResultImpl

#pragma once
#include "resource.h"       // main symbols
#include "graphResult.h"
#include "WritableGraphResult.h"
#include "ResultMerger.h"


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
	public IGraphResult,
	public IResultMerger

{
public:
	CGraphResultImpl();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	void FinalRelease();

	// IResult
public:
	STDMETHOD(GetResultMerger)(IResultMerger** merger);

	// IGraphResult Methods
public:
	STDMETHOD(GetGraph)(int  index, void ** graph);
	STDMETHOD(GetCount)(int * count);
	STDMETHOD(GetGraphInfo)(IGraphInfo ** info);
	STDMETHOD(GetGraphInfoAt)(int  index, IGraphInfo ** info);
	STDMETHOD(IsStrongComponent)(VARIANT_BOOL * value);
	

	// IWritableGraphResult Methods
public:
	STDMETHOD(AddGraph)(void** graph, VARIANT_BOOL isStringComponent);

	// IResultMerger
public:
	STDMETHOD(AddResult)(IResultBase* result);
	STDMETHOD(CanAddResult)(IResultBase* result, VARIANT_BOOL* value);
	STDMETHOD(CreateResult)(IResultBase** result);


private:
	typedef pair<Graph*, bool> Item;
	typedef list<Item> Graphs;

	Graphs graphs;

private:
	bool GraphAcceptConstraint(Graph* newGraph);
	bool GraphAcceptConstraint(Graph* graph1, Graph* graph2);
};

