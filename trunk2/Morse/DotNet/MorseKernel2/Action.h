// Action.h : Declaration of the CAction

#pragma once
#include "resource.h"       // main symbols
#include "actionBase.h"
#include "result.h"
#include "actionManager.h"
#include "Parameters.h"
#include "ProgressBarInfo.h"

// IAction
[
	object,
	uuid("B94E10D8-08BD-405C-A435-0868DD86CD3C"),
	dual,	helpstring("IAction Interface"),
	pointer_default(unique)
]
__interface IAction : IActionBase
{
	[id(1)]
	HRESULT GetNextActionManager([out, retval] IActionManager** manager);
	[id(2)]
	HRESULT SetActionParameters([in] IParameters* parameters);
	[id(3)]
	HRESULT Do([in] IResult* input, [out, retval] IResult** output);
	[id(4)]
	HRESULT SetProgressBarInfo([in] IProgressBarInfo* pinfo);
};

