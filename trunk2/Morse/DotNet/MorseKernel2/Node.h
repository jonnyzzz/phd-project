// Node.h : Declaration of the CNode

#pragma once
#include "resource.h"       // main symbols
#include "ActionManager.h"
#include "result.h"

// INode
[
	object,
	uuid("D3BEDA0D-1771-4493-BB5C-E93384792B2A"),
	dual,	helpstring("INode Interface"),
	pointer_default(unique)
]
__interface INode : IDispatch
{
	[id(1)]
	HRESULT GetActionManager([out, retval] IActionManager** manager);
	[id(2)]
	HRESULT GetResult([out, retval] IResult** result);
};

