// GraphResult.h : Declaration of the CGraphResult

#pragma once
#include "resource.h"       // main symbols
#include "result.h"
#include "graphInfo.h"

// IGraphResult
[
	object,
	uuid("6E606370-04E2-4BCB-852C-313A7D4BAD15"),
	dual,	helpstring("IGraphResult Interface"),
	pointer_default(unique)
]
__interface IGraphResult : IResult
{	
	[id(10), local, hidden]
	HRESULT GetGraph([out] void** graph);	
	[id(12)]
	HRESULT GetGraphInfo([out, retval] IGraphInfo** info);
	[id(13)]
	HRESULT IsStrongComponent([out, retval] VARIANT_BOOL* value);	
	[id(14)]
	HRESULT SaveText([in] BSTR file);
	[id(15)]
	HRESULT SaveGraph([in] BSTR file);
};
