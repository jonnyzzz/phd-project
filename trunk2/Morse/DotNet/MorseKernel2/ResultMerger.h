// ResultMerger.h : Declaration of the CResultMerger

#pragma once
#include "resource.h"       // main symbols
#include "ResultBase.h"


// IResultMerger
[
	object,
	uuid("4D5B2A01-1CC2-4D56-A8D7-67C730A057ED"),
	dual,	helpstring("IResultMerger Interface"),
	pointer_default(unique)
]
__interface IResultMerger : IDispatch
{
	[id(31)]
	HRESULT AddResult([in] IResultBase* result);

	[id(32)]
	HRESULT CanAddResult([in] IResultBase* result, [out, retval] VARIANT_BOOL* value);

	[id(33)]
	HRESULT CreateResult([out, retval] IResultBase** result);
};
