// Dummy3.h : Declaration of the CDummy3

#pragma once
#include "resource.h"       // main symbols
#include "AdaptiveMethodAction.h"
#include "ComputationParameters.h"
#include "MS2DCreationAction.h"


// IDummy3
[
	object,
	uuid("506F850B-7CBA-4A7F-A16D-25B3D104F7BE"),
	dual,	helpstring("IDummy3 Interface"),
	pointer_default(unique)
]
__interface IDummy3 : IDispatch
{
};



// CDummy3

[
    coclass,
    threading("apartment"),
    vi_progid("MorseKernel2.Dummy3"),
    progid("MorseKernel2.Dummy3.1"),
    version(1.0),
    uuid("8E730EE1-B837-42E1-BB4E-3D5F9954FEA1"),
    helpstring("Dummy3 Class")
]
class ATL_NO_VTABLE CDummy3 : 
    public IDummy3,
    public IAdaptiveMethodParameters,
    public IComputationParameters,
    public IMS2DCreationParameters
{
public:
    CDummy3()
    {
    }


    DECLARE_PROTECT_FINAL_CONSTRUCT()

    HRESULT FinalConstruct()
    {
        return S_OK;
    }

    void FinalRelease() 
    {
    }

public:


    // IAdaptiveMethodParameters Methods
public:
    STDMETHOD(GetFactor)(int  index, int * factor)
    {
        // Add your function implementation here.
        return E_NOTIMPL;
    }
    STDMETHOD(GetPrecision)(int i, double * prec)
    {
        // Add your function implementation here.
        return E_NOTIMPL;
    }

    STDMETHOD(GetUpperLimit)(int* out) {
        return E_NOTIMPL;
    }

    // IComputationParameters Methods
public:
    STDMETHOD(GetFunction)(IFunction ** function)
    {
        // Add your function implementation here.
        return E_NOTIMPL;
    }

    // IMS2DCreationParameters Methods
public:
    STDMETHOD(GetFactor)(int * factor)
    {
        // Add your function implementation here.
        return E_NOTIMPL;
    }
};

