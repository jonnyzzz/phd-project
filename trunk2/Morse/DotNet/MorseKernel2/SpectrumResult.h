// SpectrumResult.h : Declaration of the CSpectrumResult

#pragma once
#include "resource.h"       // main symbols
#include "result.h"
#include "graphResult.h"

// ISpectrumResult
[
	object,
	uuid("2003DF4C-5367-4F11-A29C-447E7E45E5AA"),
	dual,	helpstring("ISpectrumResult Interface"),
	pointer_default(unique)
]
__interface ISpectrumResult : IResult
{
	[id(10)]
	HRESULT GetLowerBound([out, retval] double* data);
	[id(11)]
	HRESULT GetUpperBound([out, retval] double* data);
	[id(12)]
	HRESULT GetLowerLength([out, retval] int* data);
	[id(13)]
	HRESULT GetUpperLength([out, retval] int* data);
};


