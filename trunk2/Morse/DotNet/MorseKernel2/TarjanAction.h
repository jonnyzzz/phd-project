// TarjanAction.h : Declaration of the CTarjanAction

#pragma once
#include "resource.h"       // main symbols
#include "action.h"

// ITarjanAction
[
	object,
	uuid("FAFD82A9-346E-4BD7-8316-F16B105A4653"),
	dual,	helpstring("ITarjanAction Interface"),
	pointer_default(unique)
]
__interface ITarjanAction : IAction
{
};


[
	object,
	uuid("8DB63B4A-7E18-4328-9335-419C4CE5A4E5"),
	dual,
	helpstring("EmptyParameters"),
	pointer_default(unique)
]
__interface ITarjanParameters : IParameters
{
	[id(1)]
	HRESULT NeedEdgeResolve([out, retval] VARIANT_BOOL* result);
	//No options here
};


// CTarjanAction

[
	coclass,
	threading("free"),
	vi_progid("MorseKernel2.TarjanAction"),
	progid("MorseKernel2.TarjanAction.1"),
	version(1.0),
	uuid("76C75A0A-AC4C-4CA9-8A4E-D8283388C361"),
	helpstring("TarjanAction Class")
]
class ATL_NO_VTABLE CTarjanAction : 
	public ITarjanAction
{
public:
	CTarjanAction();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:

	STDMETHOD(SetActionParameters)(IParameters* pars);
	STDMETHOD(SetProgressBarInfo)(IProgressBarInfo* info);
	STDMETHOD(CanDo)(IResultBase* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultBase* in, IResultBase** out);
	

private:
	ITarjanParameters* parameters;
	IProgressBarInfo* info;
};
