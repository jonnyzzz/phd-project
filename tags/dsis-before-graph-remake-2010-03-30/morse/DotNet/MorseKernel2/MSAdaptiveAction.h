// MSAdaptiveAction.h : Declaration of the CMSAdaptiveAction

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"
#include "ComputationParameters.h"
#include "PointMethodAction.h"
#include "AdaptiveMethodAction.h"

[
	object,
	uuid("3D182C96-79B3-40FA-9FBA-9A384E9B3DF6"),
	dual,	helpstring("IAdaptiveBoxMethod Interface"),
	pointer_default(unique)
]
__interface IMSAdaptiveMethod : IAdaptiveMethodAction
{
};



// CMSAdaptiveAction

[
	coclass,
	threading(apartment),
	vi_progid("MorseKernel2.MSAdaptiveAction"),
	progid("MorseKernel2.MSAdaptiveAction.1"),
	version(1.0),
	uuid("8AB4B68E-C39E-4FD9-8466-1B88F524BD9D"),
	helpstring("MSAdaptiveAction Class")
]
class ATL_NO_VTABLE CMSAdaptiveAction : 
	public IMSAdaptiveMethod,
	private ActionBaseImpl<IAdaptiveMethodParameters>
{
public:
	CMSAdaptiveAction();
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

