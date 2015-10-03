// WritableFunction.h : Declaration of the CWritableFunction

#pragma once
#include "resource.h"       // main symbols


// IWritableFunction
[
	object,
	uuid("9B3DA2D8-E279-4552-99F4-13AA066642D5"),
	dual,	helpstring("IWritableFunction Interface"),
	pointer_default(unique)
]
__interface IWritableFunction : IDispatch
{
	[id(11)]
	HRESULT SetEquations([in] BSTR equations);
	[id(12)]
	HRESULT GetLastError([out, retval] BSTR* message);
};


