// AdaptiveMethodAction.h : Declaration of the CAdaptiveMethodAction

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "ComputationParameters.h"

// IAdaptiveMethodAction
[
	object,
	uuid("6EBF68E3-4686-40C8-9F63-3ABC3504923A"),
	dual,	helpstring("IAdaptiveMethodAction Interface"),
	pointer_default(unique)
]
__interface IAdaptiveMethodAction : IAction
{
    [id(110)]
    HRESULT GetRecomendedPrecision([in] IResultSet* in, [in] int index, [out, retval] double* prec);
    [id(111)]
    HRESULT GetDimension([in] IResultSet* in, [out, retval] int* dim);
};

[
    object,
    uuid("554362EE-42C4-48EB-B5C3-8C10273D73B5"),
    dual,
    pointer_default(unique)
]
__interface IAdaptiveMethodParameters : IComputationParameters {
    [id(10)]
    HRESULT GetFactor([in] int index, [out, retval] int* factor);
    [id(11)]
    HRESULT GetPrecision([in] int index, [out, retval] double* prec);
    [id(12)]
    HRESULT GetUpperLimit([out, retval] int* out);
};


// CAdaptiveMethodAction

[
	coclass,
	threading(apartment),
	vi_progid("MorseKernel2.AdaptiveMethodAction"),
	progid("MorseKernel2.AdaptiveMethodAction.1"),
	version(1.0),
	uuid("92548416-C178-460D-A026-3EADF256E19F"),
	helpstring("AdaptiveMethodAction Class")
]
class ATL_NO_VTABLE CAdaptiveMethodAction : 
	public IAdaptiveMethodAction
{
public:
	CAdaptiveMethodAction();
	
	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
		
	void FinalRelease(); 

public:
    CComPtr<IUnknown> m_pUnkMarshaler;
    DECLARE_GET_CONTROLLING_UNKNOWN()


public:
	STDMETHOD(SetActionParameters)(IParameters* pars);
	STDMETHOD(SetProgressBarInfo)(IProgressBarInfo* info);
	STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);

public:
    STDMETHOD(GetRecomendedPrecision)(IResultSet* in, int index, double* prec);
    STDMETHOD(GetDimension)(IResultSet* in, int* dim);


private:
    IProgressBarInfo* info;
    IAdaptiveMethodParameters* parameters;
};

