// WritableGraphInfo.h : Declaration of the CWritableGraphInfo

#pragma once
#include "resource.h"       // main symbols


// IWritableGraphInfo
[
	object,
	uuid("5F89F9F3-AB8D-4129-A752-8A4258A8ECE9"),
	dual,	helpstring("IWritableGraphInfo Interface"),
	pointer_default(unique)
]
__interface IWritableGraphInfo : IDispatch
{
	[id(12), local, hidden]
	HRESULT AddGraph([in] void** graph);
};



