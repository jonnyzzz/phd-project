// WritableGraphResult.h : Declaration of the CWritableGraphResult

#pragma once
#include "resource.h"       // main symbols
#include "resultMetadata.h"

// IWritableGraphResult
[
	object,
	uuid("6ED8D0EA-3E9C-441A-96C6-EEB2AFCBE27D"),
	dual,	helpstring("IWritableGraphResult Interface"),
	pointer_default(unique)
]
__interface IWritableGraphResult : IDispatch
{
	[id(20), local, hidden]
	HRESULT SetGraph([in]void** graph, [in]VARIANT_BOOL isStrongComponent);
	[id(21)]
	HRESULT SetMetadata([in] IResultMetadata* metadata);

	[id(22)]
	HRESULT SetGraphFromFile([in] BSTR file, [in]VARIANT_BOOL isStrongComponent);
};

