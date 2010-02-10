// MSMethodAction.h : Declaration of the CMSMethodAction

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"
#include "ComputationParameters.h"
#include "PointMethodAction.h"

//IMSMethodAction
[
	object,
	uuid("729D2ADA-2C8A-453F-97FB-2A3F6409B117"),
	dual,	helpstring("IMS2Metadata Interface"),
	pointer_default(unique)
]
__interface IMSMethodAction : IPointMethodAction
{
};


// CMSMethodAction

[
	coclass,
	threading(apartment),
	vi_progid("MorseKernel2.MSMethodAction"),
	progid("MorseKernel2.MSMethodAction.1"),
	version(1.0),
	uuid("FD0149F7-8FE6-47FB-8BE9-64A16DB8247C"),
	helpstring("MSMethodAction Class")
]
class ATL_NO_VTABLE CMSMethodAction : 
    public IMSMethodAction,
    private ActionBaseImpl<IPointMethodParameters>
{
public:
	CMSMethodAction();

	DECLARE_PROTECT_FINAL_CONSTRUCT()
    DECLARE_ACTION_BASE_IMPL()

	HRESULT FinalConstruct();	
	void FinalRelease();

public:
    STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);
    STDMETHOD(GetDimensionForParameters)(IResultSet* resultSet, int* dim);

public:
    CComPtr<IUnknown> m_pUnkMarshaler;
    DECLARE_GET_CONTROLLING_UNKNOWN()

};

