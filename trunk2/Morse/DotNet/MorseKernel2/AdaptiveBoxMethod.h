// AdaptiveBoxMethod.h : Declaration of the CAdaptiveBoxMethod

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"
#include "ComputationParameters.h"



// IAdaptiveBoxMethod
[
	object,
	uuid("20B6A0EB-2F40-4AA7-A066-0CC672BF1531"),
	dual,	helpstring("IAdaptiveBoxMethod Interface"),
	pointer_default(unique)
]
__interface IAdaptiveBoxMethod : IAction
{
    [id(110)]
    HRESULT GetDimensionFromParameters([in]IResultSet* in, [out,retval]int* demention);
    [id(111)]
    HRESULT GetRecomendedPrecision([in]IResultSet* in, [in]int id, [out,retval]double* prec);
};

// IAdaptiveBoxMethod
[
	object,
	uuid("AF4C5C56-DFE3-4DCE-9A4E-E48943F49F51"),
	dual,	helpstring("IAdaptiveBoxMethod Interface"),
	pointer_default(unique)
]
__interface IAdaptiveBoxParameters : IComputationParameters
{
    [id(11)]
    HRESULT GetFactor([in]int id, [out,retval]int* factor);
    [id(12)]
    HRESULT GetPrecision([in]int id, [out,retval]double* prec);

};



// CAdaptiveBoxMethod

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.AdaptiveBoxMethod"),
	progid("MorseKernel2.AdaptiveBoxMethod.1"),
	version(1.0),
	uuid("ACFA6EFC-A4B6-4BE9-A70B-3F74B724D3DD"),
	helpstring("AdaptiveBoxMethod Class")
]
class ATL_NO_VTABLE CAdaptiveBoxMethod : 
	public IAdaptiveBoxMethod,
    private ActionBaseImpl<IAdaptiveBoxParameters>
{
public:
	CAdaptiveBoxMethod();

    DECLARE_ACTION_BASE_IMPL()
	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();	
	void FinalRelease();

public:
    STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);

public:
    STDMETHOD(GetDimensionFromParameters)(IResultSet* in, int* dim);
    STDMETHOD(GetRecomendedPrecision)(IResultSet* in, int id, double* prec);
};

