// BoxMethodAction.h : Declaration of the CBoxMethodAction

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "ComputationParameters.h"

// IBoxMethodAction
[
	object,
	uuid("586FAD2F-D9E4-4A30-A925-345C7E1BDC56"),
	dual,	helpstring("IBoxMethodAction Interface"),
	pointer_default(unique)
]
__interface IBoxMethodAction : IAction
{
};


[
	object,
	uuid("EF3F28E7-DA5A-4294-9C12-656D0B7CB74A"),
	dual,
	pointer_default(unique)
]
__interface IBoxMethodParameters : IComputationParameters {
	[id(10)]
	HRESULT GetFactor([in] int index, [out, retval] int* factor);
	[id(11)]
	HRESULT UseDerivate([out, retval] VARIANT_BOOL* out);
};


// CBoxMethodAction

[
	coclass,
	threading("free"),
	vi_progid("MorseKernel2.BoxMethodAction"),
	progid("MorseKernel2.BoxMethodAction.1"),
	version(1.0),
	uuid("FDA0C930-C1F5-40C0-A0B6-A978CDA93F50"),
	helpstring("BoxMethodAction Class")
]
class ATL_NO_VTABLE CBoxMethodAction : 
	public IBoxMethodAction
{
public:
	CBoxMethodAction();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:
	STDMETHOD(SetActionParameters)(IParameters* pars);
	STDMETHOD(SetProgressBarInfo)(IProgressBarInfo* info);
	STDMETHOD(CanDo)(IResultBase* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultBase* in, IResultBase** out);
	
private:
	IProgressBarInfo* info;
	IBoxMethodParameters* parameters;



};

