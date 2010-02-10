// WritableSpectrum.h : Declaration of the CWritableSpectrum

#pragma once
#include "resource.h"       // main symbols
#include "resultmetadata.h"

// IWritableSpectrum
[
	object,
	uuid("80B6D423-1E6D-4236-B187-FFDEC3A2A139"),
	dual,	helpstring("IWritableSpectrum Interface"),
	pointer_default(unique)
]
__interface IWritableSpectrumResult : IDispatch
{
	[id(20)]
	HRESULT SetLowerBound([in] double data);
	[id(21)]
	HRESULT SetUpperBound([in] double data);
	[id(22)]
	HRESULT SetLowerLength([in] int data);
	[id(23)]
	HRESULT SetUpperLength([in] int data);
	[id(24)]
	HRESULT SetMetadata([in] IResultMetadata* data);
};

