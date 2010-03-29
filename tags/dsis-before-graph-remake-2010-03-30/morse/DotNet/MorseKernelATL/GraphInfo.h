// GraphInfo.h : Declaration of the CGraphInfo

#pragma once
#include "resource.h"       // main symbols

class Graph;
// IGraphInfo
[
	object,
	uuid("CE2B6190-CBC5-4104-A0E0-D7B3FE567867"),
	dual,	helpstring("IGraphInfo Interface"),
	pointer_default(unique)
]
__interface IGraphInfo : IDispatch
{
	[id(1)]
		HRESULT dimension([out, retval] LONG* dimension);
	[id(2)]
		HRESULT gridNumber([in] LONG id, [out, retval] LONG* grid);
	[id(3)]
		HRESULT gridSize([in] LONG id, [out, retval] DOUBLE* size);
	[id(4)]
		HRESULT spaceMin([in] LONG id, [out, retval] DOUBLE* size);
	[id(5)]
		HRESULT spaceMax([in] LONG id, [out, retval] DOUBLE* size);
	[id(6)]
		HRESULT edges([out,retval] LONG* num);
	[id(7)]
		HRESULT nodes([out, retval] LONG* num);


	[id(8), local, hidden]
		HRESULT setGraph([in] void** graph);

	[id(9), local, hidden]
		HRESULT setGraphComponents([in] void** gcmps);
};



// CGraphInfo

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.GraphInfo"),
	progid("MorseKernelATL.GraphInfo.1"),
	version(1.0),
	uuid("A7C5C80A-DA2F-4900-8042-9EBA1C1B0F4B"),
	helpstring("GraphInfo Class")
]
class ATL_NO_VTABLE CGraphInfo : 
	public IGraphInfo
{
public:
	CGraphInfo()
	{
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();


private:
	void initDimension();
	bool verify(LONG dimention);
	GraphComponents* gcms;

	int dim;

public:

	STDMETHOD(dimension)(LONG* dimension);
	STDMETHOD(gridNumber)(LONG id, LONG* grid);
	STDMETHOD(gridSize)(LONG id, DOUBLE* size);
	STDMETHOD(spaceMin)(LONG id, DOUBLE* val);
	STDMETHOD(spaceMax)(LONG id, DOUBLE* val);
	STDMETHOD(edges)(LONG* num);
	STDMETHOD(nodes)(LONG* num);

	STDMETHOD(setGraph)(void** graph);
	STDMETHOD(setGraphComponents)(void** gcms);

};

