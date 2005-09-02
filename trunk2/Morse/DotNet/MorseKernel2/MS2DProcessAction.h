// MS2DProcessAction.h : Declaration of the CMS2DProcessAction

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"
#include "ComputationParameters.h"


// IMS2DProcessAction
[
	object,
	uuid("F8F384DC-FF2E-48B5-9FB3-958A828554C5"),
	dual,	helpstring("IMS2DProcessAction Interface"),
	pointer_default(unique)
]
__interface IMS2DProcessAction : IAction
{
};


[
	object,
	uuid("9FAD2A0A-2208-4F26-ABF7-01CEFE67B738"),
	dual,	helpstring("IMS2DProcessAction Interface"),
	pointer_default(unique)
]
__interface IMS2DProcessParameters : IComputationParameters
{
    [id(14)]
    HRESULT GetFactor([out, retval] int* factor);
};



// CMS2DProcessAction

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernel2.MS2DProcessAction"),
	progid("MorseKernel2.MS2DProcessAction.1"),
	version(1.0),
	uuid("A1BF0187-E515-4B73-9F0E-7CB55F74243B"),
	helpstring("MS2DProcessAction Class")
]
class ATL_NO_VTABLE CMS2DProcessAction : 
	public IMS2DProcessAction,
    private ActionBaseImpl<IMS2DProcessParameters>
{
public:
	CMS2DProcessAction();

    DECLARE_ACTION_BASE_IMPL()
	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();	
	void FinalRelease();

public:

    STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);
	
};

