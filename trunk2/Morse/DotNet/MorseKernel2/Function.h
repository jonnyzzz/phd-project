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
	[id(3), local, hidden]
	HRESULT CreateGraph([out] void** graph);
	
	[id(4)]
	HRESULT GetEquations([out, retval] BSTR* equations);
	[id(5)]
	HRESULT GetDimension([out, retval] int* dimenstion);
	[id(6)]
	HRESULT GetIterations([out, retval] int* iterations);	
	
	[id(7)]
	HRESULT GetMinimum([in] int id, [out, retval] double* value);
	[id(8)]
	HRESULT GetMaximum([in] int id, [out, retval] double* value);
	[id(9)]
	HRESULT GetLipshitz([in] int id, [out, retval] double* value);
};


