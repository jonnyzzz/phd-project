// MSCreationProcess.h : Declaration of the CMSCreationProcess

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"
#include "ComputationParameters.h"
#include "PointMethodAction.h"


// IMSCreationProcess
[
	object,
	uuid("03982D3C-F495-4B48-AD40-9E14C6B34387"),
	dual,	helpstring("IMSCreationProcess Interface"),
	pointer_default(unique)
]
__interface IMSCreationProcess : IAction
{
    [id(10)]
    HRESULT GetDimension([in]IResultSet* set, [out, retval] int* dim);
};


[
	object,
	uuid("FF53DE10-042E-4444-9D72-81FB5120DF2B"),
	dual,
	pointer_default(unique)
]
__interface IMSCreationParameters : IParameters {
	[id(10)]
	HRESULT GetFactor([in] int index, [out, retval] int* factor);
};



// CMSCreationProcess

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.MSCreationProcess"),
	progid("MorseKernel2.MSCreationProcess.1"),
	version(1.0),
	uuid("533A73C2-C47D-43CA-9DE4-73E2FA1981B9"),
	helpstring("MSCreationProcess Class")
]
class ATL_NO_VTABLE CMSCreationProcess : 
	public IMSCreationProcess,
    private ActionBaseImpl<IMSCreationParameters>
{
public:
	CMSCreationProcess();
	DECLARE_PROTECT_FINAL_CONSTRUCT()
    DECLARE_ACTION_BASE_IMPL()

	HRESULT FinalConstruct();
	void FinalRelease();

public:
    STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);
    STDMETHOD(GetDimension)(IResultSet* set, int* dim);

};

