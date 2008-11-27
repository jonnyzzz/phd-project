// MSAngleRomProcess.h : Declaration of the CMSAngleRomProcess

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"
#include "ComputationParameters.h"


// IMSAngleRomProcess
[
	object,
	uuid("293FB7DB-0C75-4E8D-A2D2-DC4BC662C62F"),
	dual,	helpstring("IMSAngleRomProcess Interface"),
	pointer_default(unique)
]
__interface IMSAngleRomProcess : IAction
{
};



// CMSAngleRomProcess

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.MSAngleRomProcess"),
	progid("MorseKernel2.MSAngleRomProcess.1"),
	version(1.0),
	uuid("B86EA936-EB19-4A0A-A51D-6823E2A089AB"),
	helpstring("MSAngleRomProcess Class")
]
class ATL_NO_VTABLE CMSAngleRomProcess : 
	public IMSAngleRomProcess,
	private ActionBaseImpl<IComputationParameters>
{
public:
	CMSAngleRomProcess();

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

