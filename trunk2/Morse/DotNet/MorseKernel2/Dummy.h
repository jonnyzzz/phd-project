// Dummy.h : Declaration of the CDummy

#pragma once
#include "resource.h"       // main symbols
#include "Function.h"
#include "Action.h"


// IDummy
[
	object,
	uuid("0A8C775B-8E19-4642-B2D7-5BBB437B7B97"),
	dual,	helpstring("IDummy Interface"),
	pointer_default(unique)
]
__interface IDummy : IDispatch
{
};



// CDummy

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernel2.Dummy"),
	progid("MorseKernel2.Dummy.1"),
	version(1.0),
	uuid("8C3F6AAB-F725-4C70-A92A-7E4BD2A30C23"),
	helpstring("Dummy Class")
]
class ATL_NO_VTABLE CDummy : 
	public IDummy
{
public:
	CDummy()
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


};

