// ResultSet.h : Declaration of the CResultSet

#pragma once
#include "resource.h"       // main symbols
#include "resultBase.h"

// IResultSet
[
	object,
	uuid("5498E339-8014-4366-9092-13EB8AD35E1D"),
	dual,	helpstring("IResultSet Interface"),
	pointer_default(unique)
]
__interface IResultSet : IDispatch
{
	[id(1)]
	HRESULT GetCount([out, retval] int* count);

	[id(2)]
	HRESULT GetResult([in] int index, [out, retval] IResultBase** result);
};

