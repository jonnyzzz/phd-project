// ComputationResultWrapper.h : Declaration of the CComputationResultWrapper

#pragma once
#include "resource.h"       // main symbols
#include "nodebase.h"

// IComputationResultWrapper
[
	object,
	uuid("A1C8B730-B824-4A90-878A-27AB1D493208"),
	dual,	helpstring("IComputationResultWrapper Interface"),
	pointer_default(unique)
]
__interface IComputationResultWrapper : IDispatch
{
    [propputref, id(1)]
    HRESULT ComputationResult([in]IComputationResult* result);
    [propget, id(1)]
    HRESULT ComputationResult([out,retval]IComputationResult** result);
};



// CComputationResultWrapper

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.ComputationResultWrapper"),
	progid("MorseKernelATL.ComputationResultWrapp.1"),
	version(1.0),
	uuid("637D25DB-555B-4E11-941F-CE9070E114DA"),
	helpstring("ComputationResultWrapper Class")
]
class ATL_NO_VTABLE CComputationResultWrapper : 
	public IComputationResultWrapper
{
private:
    IComputationResult* result;

public:
	CComputationResultWrapper()
	{
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
        result = NULL;
		return S_OK;
	}
	
	void FinalRelease() 
	{
        SAFE_RELEASE(result);
	}

public:

    STDMETHOD(putref_ComputationResult)(IComputationResult* result) {
        SAFE_RELEASE(this->result);
        result->QueryInterface(&this->result);
        ATLASSERT(this->result != NULL);
        return S_OK;
    }

    STDMETHOD(get_ComputationResult)(IComputationResult** result) {
        this->result->QueryInterface(result);
        ATLASSERT(*result != NULL);
        return S_OK;
    }
};

