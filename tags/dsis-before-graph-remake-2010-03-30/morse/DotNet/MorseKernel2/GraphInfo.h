// GraphInfo.h : Declaration of the CGraphInfo

#pragma once
#include "resource.h"       // main symbols
#include "ResultInfo.h"

// IGraphInfo
[
	object,
	uuid("0641C669-B362-48C9-8B73-D02B6E252A9D"),
	dual,	helpstring("IGraphInfo Interface"),
	pointer_default(unique)
]
__interface IGraphInfo : IDispatch
{
	[id(1)]
	HRESULT GetNodes([out, retval] int* value);
	[id(2)]
	HRESULT GetEdges([out, retval] int* value);
	[id(3)]
	HRESULT GetDimension([out, retval] int* value);
	[id(4)]
	HRESULT GetMinimum([in] int index, [out, retval] double* value);
	[id(5)]
	HRESULT GetMaximum([in] int index, [out, retval] double* value);
	[id(6)]
	HRESULT GetGridNumber([in] int index, [out, retval] int* value);
	[id(7)]
	HRESULT GetGridSize([in] int index, [out, retval] double* value);
};


