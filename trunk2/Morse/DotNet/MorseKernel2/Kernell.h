// Kernell.h : Declaration of the CKernell

#pragma once
#include "resource.h"       // main symbols
#include "ActionAllocator.h"

// IKernell
[
	object,
	uuid("F2D78B39-D782-49DE-91B7-771CDA2ED0E0"),
	dual,	helpstring("IKernell Interface"),
	pointer_default(unique)
]
__interface IKernell : IDispatch
{
	[id(1)]
	HRESULT GetActionAllocator([out, retval] IActionAllocator** allocator);
};


// _IKernellEvents
[
	dispinterface,
	uuid("7458F939-BE83-4246-8AB8-0E26B56D34F3"),
	helpstring("_IKernellEvents Interface")
]
__interface IKernellEvents
{
};

/*
// CKernell

[
	coclass,
	threading("both"),
	event_source("com"),
	vi_progid("MorseKernel2.Kernell"),
	progid("MorseKernel2.Kernell.1"),
	version(1.0),
	uuid("D360F9E4-D501-4986-BC3A-5FD9B993F1EC"),
	helpstring("Kernell Class")
]
class ATL_NO_VTABLE CKernell : 
	public IKernell
{
public:
	CKernell()
	{
	}

	__event __interface IKernellEvents;

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

*/