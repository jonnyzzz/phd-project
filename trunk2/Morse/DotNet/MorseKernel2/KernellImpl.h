// KernellImpl.h : Declaration of the CKernellImpl

#pragma once
#include "resource.h"       // main symbols
#include "kernell.h"
#include "writableKernell.h"

[
	object,
	dual,
	uuid("0667C597-8C23-4B74-A298-821DB594ED01"),
	pointer_default(unique)
]
__interface IKernellImpl : IWritableKernell {

};


// CKernellImpl

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.KernellImpl"),
	progid("MorseKernel2.KernellImpl.1"),
	version(1.1),
	uuid("96E908D0-29BD-423D-8CA8-9F4343C796A0"),
	helpstring("KernellImpl Class")
]
class ATL_NO_VTABLE CKernellImpl :
	public IKernellImpl, 
	public IKernell
{
public:
	CKernellImpl();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:

	//IKernell
	STDMETHOD(GetFunction)(IFunction** function);
	STDMETHOD(CreateInitialResultSet)(IResultSet** result);

	//IWritableKernell
	STDMETHOD(SetFunction)(IFunction* function);

private:
	IFunction* function;

};

