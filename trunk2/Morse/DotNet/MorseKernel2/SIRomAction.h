// SIRomAction.h : Declaration of the CSIRomAction

#pragma once
#include "resource.h"       // main symbols
#include "result.h"
#include "Action.h"
#include "ActionBaseImpl.h"
#include "parameters.h"
#include "computationParameters.h"

// ISIRomAction
[
	object,
	uuid("9CF385EA-26DB-4A19-AB20-5E735654D469"),
	dual,	helpstring("ISIRomAction Interface"),
	pointer_default(unique)
]
__interface ISIRomActionParameters : IComputationParameters
{
};

// ISIRomAction
[
	object,
	uuid("44DAD8BF-971F-485D-86C5-45FD1F67ACFE"),
	dual,	helpstring("ISIRomAction Interface"),
	pointer_default(unique)
]
__interface ISIRomAction : IAction
{
};


// CSIRomAction

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.SIRomAction"),
	progid("MorseKernel2.SIRomAction.1"),
	version(1.0),
	uuid("8C4D17D1-3A75-4E95-8D6F-CF58743A12BD"),
	helpstring("SIRomAction Class")
]
class ATL_NO_VTABLE CSIRomAction : 
	public ISIRomAction,
	private ActionBaseImpl<ISIRomActionParameters>
{
public:
	CSIRomAction();


	DECLARE_PROTECT_FINAL_CONSTRUCT()
	DECLARE_ACTION_BASE_IMPL()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:
	STDMETHOD(CanDo)(IResultSet* result, VARIANT_BOOL* can);
	STDMETHOD(Do)(IResultSet* input, IResultSet** output);


private:
	

};

