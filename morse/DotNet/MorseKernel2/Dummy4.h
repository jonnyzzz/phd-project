// Dummy4.h : Declaration of the CDummy4

#pragma once
#include "resource.h"       // main symbols
#include "MS2DProcessAction.h"
#include "ComputationParameters.h"
#include "AdaptiveBoxMethod.h"
#include "MSCreationProcess.h"


// IDummy4
[
	object,
	uuid("4D810CEE-9913-438E-9883-BC055371B174"),
	dual,	helpstring("IDummy4 Interface"),
	pointer_default(unique)
]
__interface IDummy4 : IDispatch
{
};



// CDummy4

[
    coclass,
    threading("both"),
    vi_progid("MorseKernel2.Dummy4"),
    progid("MorseKernel2.Dummy4.1"),
    version(1.0),
    uuid("365CB059-BEBE-4707-8475-67724C3DF50A"),
    helpstring("Dummy4 Class")
]
class ATL_NO_VTABLE CDummy4 : 
    public IDummy4,
    public IMS2DProcessParameters,
    public IComputationParameters,
    public IAdaptiveBoxParameters,
    public IMSCreationParameters
{
public:
    CDummy4()
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


    // IMS2DProcessParameters Methods
public:
    STDMETHOD(GetFactor)(int * factor)
    {
        // Add your function implementation here.
        return E_NOTIMPL;
    }

    // IComputationParameters Methods
public:
    STDMETHOD(GetFunction)(IFunction ** function)
    {
        // Add your function implementation here.
        return E_NOTIMPL;
    }

    // IAdaptiveBoxParameters Methods
public:
    STDMETHOD(GetFactor)(int  id, int * factor)
    {
        // Add your function implementation here.
        return E_NOTIMPL;
    }
    STDMETHOD(GetPrecision)(int  id, double * prec)
    {
        // Add your function implementation here.
        return E_NOTIMPL;
    }

    // IMSCreationParameters Methods
public:
};

