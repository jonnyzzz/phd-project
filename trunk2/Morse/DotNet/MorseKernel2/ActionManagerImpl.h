// ActionManagerImpl.h : Declaration of the CActionManagerImpl

#pragma once
#include "resource.h"       // main symbols
#include "actionManager.h"

#include <list>
using namespace std;

// IActionManagerImpl
[
	object,
	uuid("E20C06D8-1C51-455C-B306-33D0635F1E52"),
	dual,	helpstring("IActionManagerImpl Interface"),
	pointer_default(unique)
]
__interface IWritableActionManager : IDispatch
{
	[id(11)]
	HRESULT AddAction([in] IActionBase* action);
};



// CActionManagerImpl

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernel2.ActionManagerImpl"),
	progid("MorseKernel2.ActionManagerImpl.1"),
	version(1.0),
	uuid("860DAF52-F263-4F92-A8BE-673E99A9959F"),
	helpstring("ActionManagerImpl Class")
]
class ATL_NO_VTABLE CActionManagerImpl : 
	public IActionManager,
	public IWritableActionManager
{
public:
	CActionManagerImpl();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:

	STDMETHOD(GetLength)(int* count);
	STDMETHOD(GetAction)(int index, IActionBase** action);

	STDMETHOD(AddAction)(IActionBase* action);


private:
	typedef list<IActionBase*> ActionsList;
	ActionsList actionsList;
};

