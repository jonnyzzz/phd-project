// MS2DRomAction.h : Declaration of the CMS2DRomAction

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"
#include "ComputationParameters.h"


// IMS2DRomAction
[
	object,
	uuid("27633F37-3573-46D6-B45D-78AE25616DAD"),
	dual,	helpstring("IMS2DRomAction Interface"),
	pointer_default(unique)
]
__interface IMS2DRomAction : IAction
{
};

// CMS2DRomAction

[
	coclass,
	threading(apartment),
	vi_progid("MorseKernel2.MS2DRomAction"),
	progid("MorseKernel2.MS2DRomAction.1"),
	version(1.0),
	uuid("8394D313-8E16-4A8D-9ECD-5C42F61601B1"),
	helpstring("MS2DRomAction Class")
]
class ATL_NO_VTABLE CMS2DRomAction : 
	public IMS2DRomAction,
    private ActionBaseImpl<IComputationParameters>
{
public:
	CMS2DRomAction();

	DECLARE_PROTECT_FINAL_CONSTRUCT()
        DECLARE_ACTION_BASE_IMPL()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:

    STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);

public:
    CComPtr<IUnknown> m_pUnkMarshaler;
    DECLARE_GET_CONTROLLING_UNKNOWN()

};

