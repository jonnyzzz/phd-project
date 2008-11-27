// WritableResultSet.h : Declaration of the CWritableResultSet

#pragma once
#include "resource.h"       // main symbols
#include "resultBase.h"

// IWritableResultSet
[
	object,
	uuid("A56A15AC-EAC4-4D8B-92FC-84CF84FC4F16"),
	dual,	helpstring("IWritableResultSet Interface"),
	pointer_default(unique)
]
__interface IWritableResultSet : IDispatch
{
	[id(5)]
	HRESULT AddResult([in] IResultBase* result);
};

