// ProgressBarInfo.h : Declaration of the CProgressBarInfo

#pragma once
#include "resource.h"       // main symbols


// IProgressBarInfo
[
	object,
	uuid("54E003E2-EAA0-4321-9A14-31CF8E5BCB84"),
	dual,	helpstring("IProgressBarInfo Interface"),
	pointer_default(unique)
]
__interface IProgressBarInfo : IDispatch
{
	[id(1)]
		HRESULT Length([out, retval] int* length);
	[id(2)]
		HRESULT Next();
	[id(3)]
		HRESULT NeedStop([out, retval] VARIANT_BOOL* stop);
	[id(4)]
		HRESULT Start();
	[id(5)]
		HRESULT Finish();

};

