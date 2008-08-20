// ComputationParameters.h : Declaration of the CComputationParameters

#pragma once
#include "resource.h"       // main symbols
#include "parameters.h"
#include "function.h"

// IComputationParameters
[
	object,
	uuid("AB57FCFD-2759-4E43-8095-34FD20EAAA8B"),
	dual,	helpstring("IComputationParameters Interface"),
	pointer_default(unique)
]
__interface IComputationParameters : IParameters
{
	[id(5)]
	HRESULT GetFunction([out, retval] IFunction** function);
};
