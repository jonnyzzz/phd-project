// ActionAllocator.h : Declaration of the CActionAllocator

#pragma once
#include "resource.h"       // main symbols
#include "node.h"
#include "ActionBase.h"
#include "ActionManager.h"
#include "ActionFactory.h"

#include <list>
using namespace std;

// IActionAllocator
[
	object,
	uuid("9D90D301-E998-4229-98C0-27C59690308D"),
	dual,	helpstring("IActionAllocator Interface"),
	pointer_default(unique)
]
__interface IActionAllocator : IDispatch
{
	[id(1)]
	HRESULT AllocateActionManager([in] INode* node, [out, retval] IActionManager** manager);
};

//IWritableActionAllocator
[
	object,
	uuid("BC2B7099-B5A6-4D0B-BDE0-DA027E87FF93"),
	dual,	helpstring("IActionAllocator Interface"),
	pointer_default(unique)
]
__interface IWritableActionAllocator : IDispatch {
	[id(2)]
	HRESULT RegisterActionFactory([in] IActionFactory* action);
};



// CActionAllocator

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernel2.ActionAllocator"),
	progid("MorseKernel2.ActionAllocator.1"),
	version(1.0),
	uuid("43EAE42D-D986-4DAB-9D7D-D4B725E77AB0"),
	helpstring("ActionAllocator Class")
]
class ATL_NO_VTABLE CActionAllocator : 
	public IActionAllocator,
	public IWritableActionAllocator
{
public:
	CActionAllocator();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:
	
	STDMETHOD(AllocateActionManager)(INode* forNode, IActionManager** manager);
	STDMETHOD(RegisterActionFactory)(IActionFactory* action);

private:
	typedef list<IActionFactory*> FactoryList;
	FactoryList factoryList;
};

