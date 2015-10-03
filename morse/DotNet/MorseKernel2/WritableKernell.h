// WritableKernell.h : Declaration of the CWritableKernell

#pragma once
#include "resource.h"       // main symbols
#include "Function.h"

// IWritableKernell
[
	object,
	uuid("DB255DC6-645A-4D60-A7C6-5D3019C2DBB7"),
	dual,	helpstring("IWritableKernell Interface"),
	pointer_default(unique)
]
__interface IWritableKernell : IDispatch
{
	[id(11)]
	HRESULT SetFunction([in] IFunction* function);
};

