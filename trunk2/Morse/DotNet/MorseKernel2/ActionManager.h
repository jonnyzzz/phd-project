// ActionManager.h : Declaration of the CActionManager

#pragma once
#include "resource.h"       // main symbols
#include "ActionBase.h"


// IActionManager
[
	object,
	uuid("5EB44493-8FF9-486A-8ABD-09B9F232628A"),
	dual,	helpstring("IActionManager Interface"),
	pointer_default(unique)
]
__interface IActionManager : IDispatch
{
	[id(1)]
	HRESULT GetLength([in] int* count);
	[id(2)]
	HRESULT GetAction([in] int index, [out, retval] IActionBase** action);
};


