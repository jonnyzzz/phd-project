// Action.h : Declaration of the CAction

#pragma once
#include "resource.h"       // main symbols
#include "actionBase.h"
#include "Parameters.h"
#include "ProgressBarInfo.h"
#include "resultSet.h"

// IAction
[
	object,
	uuid("B94E10D8-08BD-405C-A435-0868DD86CD3C"),
	dual,	helpstring("IAction Interface"),
	pointer_default(unique)
]
__interface IAction : IActionBase
{
	[id(2)]
	HRESULT SetActionParameters([in] IParameters* parameters);
	[id(4)]
	HRESULT SetProgressBarInfo([in] IProgressBarInfo* pinfo);
	[id(5)]
	HRESULT CanDo([in] IResultSet* result, [out, retval] VARIANT_BOOL* can);
	[id(3)]
	HRESULT Do([in] IResultSet* input, [out, retval] IResultSet** output);

};

