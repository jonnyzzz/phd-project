// GraphInfoImpl.h : Declaration of the CGraphInfoImpl

#pragma once
#include "resource.h"       // main symbols
#include "graphInfo.h"
#include "writableGraphInfo.h"

#include <list>
using namespace std;
class Graph;

[
	object,
	dual,
	uuid("E8AC201A-48EE-4CC4-A7D3-D075C3016104"),
	pointer_default(unique)
]
__interface IGraphInfoImpl : IDispatch {

};


// CGraphInfoImpl

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.GraphInfoImpl"),
	progid("MorseKernel2.GraphInfoImpl.1"),
	version(1.0),
	uuid("1FCB1E52-C321-4E44-8BA6-83DA8C532365"),
	helpstring("GraphInfoImpvffffl Class")	
]
class ATL_NO_VTABLE CGraphInfoImpl :
	public IGraphInfoImpl,
	public IWritableGraphInfo,
	public IGraphInfo
{
public:
	CGraphInfoImpl();


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();	
	void FinalRelease();

public:
	STDMETHOD(GetNodes)(int* value);
	STDMETHOD(GetEdges)(int* value);
	STDMETHOD(GetDimension)(int* value);
	STDMETHOD(GetMinimum)(int index, double* value);
	STDMETHOD(GetMaximum)(int index, double* value);
	STDMETHOD(GetGridSize)(int index, double* value);
	STDMETHOD(GetGridNumber)(int index, int* value);

	STDMETHOD(AddGraph)(void** graph);
	

private:
	typedef list<Graph*> GraphSet;
	GraphSet graphSet;

	int dimension;
};

