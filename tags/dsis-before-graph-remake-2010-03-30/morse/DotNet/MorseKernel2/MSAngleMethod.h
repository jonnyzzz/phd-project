// MSAngleMethod.h : Declaration of the CMSAngleMethod

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"
#include "ComputationParameters.h"
#include "AdaptiveMethodAction.h"

[
	object,
	uuid("87FF96BE-B389-4AFA-8B6C-89E2E9AFD50F"),
	dual,	helpstring("IAdaptiveBoxMethod Interface"),
	pointer_default(unique)
]
__interface IMSAngleMethod : IAdaptiveMethodAction
{
};



// CMSAngleMethod

[
	coclass,
	threading(apartment),
	vi_progid("MorseKernel2.MSAngleMethod"),
	progid("MorseKernel2.MSAngleMethod.1"),
	version(1.0),
	uuid("67446F52-3C7A-4019-84B6-4B2837860BC2"),
	helpstring("MSAngleMethod Class")
]
class ATL_NO_VTABLE CMSAngleMethod : 
	public IMSAngleMethod,
	private ActionBaseImpl<IAdaptiveMethodParameters>
{
public:
	CMSAngleMethod();

	DECLARE_PROTECT_FINAL_CONSTRUCT()
    DECLARE_ACTION_BASE_IMPL()

	HRESULT FinalConstruct();	
	void FinalRelease();

public:
	STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);

public:
    STDMETHOD(GetRecomendedPrecision)(IResultSet* in, int index, double* prec);
    STDMETHOD(GetDimension)(IResultSet* in, int* dim);

public:
    CComPtr<IUnknown> m_pUnkMarshaler;
    DECLARE_GET_CONTROLLING_UNKNOWN()

};

