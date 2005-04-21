// Dummy2.h : Declaration of the CDummy2

#pragma once
#include "resource.h"       // main symbols
#include "ComputationParameters.h"
#include "SIRomAction.h"


// IDummy2
[
	object,
	uuid("880BF42F-A1E3-4FA8-87AD-FB8D96F275A0"),
	dual,	helpstring("IDummy2 Interface"),
	pointer_default(unique)
]
__interface IDummy2 : IDispatch
{
};



// CDummy2

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernel2.Dummy2"),
	progid("MorseKernel2.Dummy2.1"),
	version(1.0),
	uuid("F47CA110-2F50-43F2-BB91-455C9FCE6B96"),
	helpstring("Dummy2 Class")
]
class ATL_NO_VTABLE CDummy2 : 
	public IDummy2,
	public ISIRomActionParameters,
	public IComputationParameters
{
public:
	CDummy2()
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


	// ISIRomActionParameters Methods
public:

	// IComputationParameters Methods
public:
	STDMETHOD(GetFunction)(IFunction ** function)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
};

