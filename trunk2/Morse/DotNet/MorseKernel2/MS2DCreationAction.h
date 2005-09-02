// MS2DCreationAction.h : Declaration of the CMS2DCreationAction

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"

// IMS2DCreationAction
[
	object,
	uuid("B56578FA-7E2F-4EDC-A2F0-1B3F9128F227"),
	dual,	helpstring("IMS2DCreationAction Interface"),
	pointer_default(unique)
]
__interface IMS2DCreationAction : IDispatch
{
};


[
	object,
	uuid("52E2BF5B-0E91-4588-8B56-D7B49EF8DE0B"),
	dual,
	pointer_default(unique)
]
__interface IMS2DCreationParameters : IParameters {
	[id(10)]
	HRESULT GetFactor([out, retval] int* factor);
};


// CMS2DCreationAction

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernel2.MS2DCreationAction"),
	progid("MorseKernel2.MS2DCreationAction.1"),
	version(1.0),
	uuid("69D041A3-98CE-44FD-A384-3EA929F27075"),
	helpstring("MS2DCreationAction Class")
]
class ATL_NO_VTABLE CMS2DCreationAction : 
	public IMS2DCreationAction
{
public:
	CMS2DCreationAction();
	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:
	STDMETHOD(SetActionParameters)(IParameters* pars);
	STDMETHOD(SetProgressBarInfo)(IProgressBarInfo* info);
	STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);



private:
    IProgressBarInfo* info;
    IMS2DCreationParameters* parameters;
};

