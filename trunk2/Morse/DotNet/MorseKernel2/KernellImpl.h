// KernellImpl.h : Declaration of the CKernellImpl

#pragma once
#include "resource.h"       // main symbols
#include "kernell.h"
#include "writableKernell.h"


// CKernellImpl

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.KernellImpl"),
	progid("MorseKernel2.KernellImpl.1"),
	version(1.0),
	uuid("96E908D0-29BD-423D-8CA8-9F4343C796A0"),
	helpstring("KernellImpl Class")
]
class ATL_NO_VTABLE CKernellImpl : 
	public IKernell,
	public IWritableKernell
{
public:
	CKernellImpl();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:

	//IKernell
	STDMETHOD(GetFunction)(IFunction** function);
	STDMETHOD(CreateInitialResult)(IResultBase** result);

	//IWritableKernell
	STDMETHOD(SetFunction)(IFunction* function);

private:
	IFunction* function;

};

