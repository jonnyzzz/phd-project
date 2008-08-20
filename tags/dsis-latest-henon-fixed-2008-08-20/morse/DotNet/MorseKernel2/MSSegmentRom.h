// MSSegmentRom.h : Declaration of the CMSSegmentRom

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"
#include "ComputationParameters.h"


// IMSSegmentRom
[
	object,
	uuid("A5FEE589-2AE6-4F6F-8327-E531D2269F50"),
	dual,	helpstring("IMSSegmentRom Interface"),
	pointer_default(unique)
]
__interface IMSSegmentRom : IAction
{
};



// CMSSegmentRom

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.MSSegmentRom"),
	progid("MorseKernel2.MSSegmentRom.1"),
	version(1.0),
	uuid("91A82ACA-C380-49C9-8A38-BBD68858100B"),
	helpstring("MSSegmentRom Class")
]
class ATL_NO_VTABLE CMSSegmentRom : 
	public IMSSegmentRom,
    private ActionBaseImpl<IComputationParameters>
{
public:
	CMSSegmentRom();

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

