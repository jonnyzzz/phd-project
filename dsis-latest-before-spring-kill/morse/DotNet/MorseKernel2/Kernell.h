// Kernell.h : Declaration of the CKernell

#pragma once
#include "resource.h"       // main symbols
#include "Function.h"
#include "resultSet.h"

// IKernell
[
	object,
	uuid("F2D78B39-D782-49DE-91B7-771CDA2ED0E0"),
	dual,	helpstring("IKernell Interface"),
	pointer_default(unique)
]
__interface IKernell : IDispatch
{
	[id(3)]
	HRESULT GetFunction([out, retval] IFunction** function);
	[id(4)]
	HRESULT CreateInitialResultSet([out, retval] IResultSet** result);
};
