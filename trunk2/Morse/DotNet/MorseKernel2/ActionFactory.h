// ActionFactory.h : Declaration of the CActionFactory

#pragma once
#include "resource.h"       // main symbols
#include "ActionBase.h"
#include "Node.h"

// IActionFactory
[
	object,
	uuid("35F624D3-EB6C-4F79-AB1E-C01795A08C5A"),
	dual,	helpstring("IActionFactory Interface"),
	pointer_default(unique)
]
__interface IActionFactory : IDispatch
{
	[id(1)]
	HRESULT CanCreateActionFromNode([in] INode* node, [out, retval] VARIANT_BOOL* result);

	[id(2), helpstring("Try to create action for such node. Returns NULL is it's imposible")]
	HRESULT CreateActionFromNode([in] INode* node, [out, retval] IActionBase** action);

	[id(3)]
	HRESULT CanCreateActionFromAction([in] IActionBase* action, [out, retval] VARIANT_BOOL* result);

	[id(4)]
	HRESULT CreateActionFromAction([in] IActionBase* action, [out, retval] IActionBase** result);
};



