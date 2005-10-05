// LoopsLocalizationAction.h : Declaration of the CLoopsLocalizationAction

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"


// ILoopsLocalizationAction
[
	object,
	uuid("7EC2A3FE-E845-4FAC-9E24-8A5101C2E922"),
	dual,	helpstring("ILoopsLocalizationAction Interface"),
	pointer_default(unique)
]
__interface ILoopsLocalizationAction : IAction
{
};



// CLoopsLocalizationAction

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.LoopsLocalizationAction"),
	progid("MorseKernel2.LoopsLocalizationAction.1"),
	version(1.0),
	uuid("7D61797D-1EB0-477F-B93D-10B854DC5F53"),
	helpstring("LoopsLocalizationAction Class")
]
class ATL_NO_VTABLE CLoopsLocalizationAction : 
	public ILoopsLocalizationAction,
	private ActionBaseImpl<IParameters>
{
public:
	CLoopsLocalizationAction();


	DECLARE_PROTECT_FINAL_CONSTRUCT()
	DECLARE_ACTION_BASE_IMPL()

	HRESULT FinalConstruct();	
	void FinalRelease();

public:

	STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);

};

