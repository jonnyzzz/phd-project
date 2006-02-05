// ResultMetadata.h : Declaration of the CResultMetadata

#pragma once
#include "resource.h"       // main symbols


// IResultMetadata
[
	object,
	uuid("A8E4F6FF-93DA-489A-A6C3-22A5884932C9"),
	dual,	helpstring("IResultMetadata Interface"),
	pointer_default(unique)
]
__interface IResultMetadata : IDispatch
{
	[id(20)]
	HRESULT EqualType([in] IResultMetadata* metadata, [out, retval] VARIANT_BOOL* out);
	[id(21)]
	HRESULT Clone([out, retval] IResultMetadata** metadata);

	[id(19)]
	HRESULT GetTypeName([out,retval] BSTR* name);

};
