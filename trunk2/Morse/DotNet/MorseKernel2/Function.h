// Function.h : Declaration of the CFunction

#pragma once
#include "resource.h"       // main symbols


// IFunction
[
	object,
	uuid("63B946E2-2AEE-4034-BA1C-1B4CFD68CEC0"),
	dual,	helpstring("IFunction Interface"),
	pointer_default(unique)
]
__interface IFunction : IDispatch
{
	[id(1), local, hidden]
	HRESULT GetSystemFunction([out] void** function);
	[id(2), local, hidden]
	HRESULT GetSystemFunctionDerivate([out] void** function);
	[id(3)]
	HRESULT GetEquations([out, retval] BSTR* equations);
	[id(4)]
	HRESULT GetDimension([out, retval] int* dimenstion);
	[id(5)]
	HRESULT GetIterations([out, retval] int* iterations);
	[id(6), local, hidden]
	HRESULT CreateGraph([out] void** graph);
};


