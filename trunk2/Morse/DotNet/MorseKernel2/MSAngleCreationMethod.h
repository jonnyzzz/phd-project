// MSAngleCreationMethod.h : Declaration of the CMSAngleCreationMethod

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"
#include "ComputationParameters.h"
#include "MSCreationProcess.h"

[
	object,
	uuid("4158B932-72E7-46DA-A98C-959B0C9A101E"),
	dual,	helpstring("IAdaptiveBoxMethod Interface"),
	pointer_default(unique)
]
__interface IMSAngleCreationMethod : IMSCreationProcess
{
};



// CMSAngleCreationMethod

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.MSAngleCreationMethod"),
	progid("MorseKernel2.MSAngleCreationMethod.1"),
	version(1.0),
	uuid("7CF17A33-3F8B-4BDB-A694-F18DE6355B6D"),
	helpstring("MSAngleCreationMethod Class")
]
class ATL_NO_VTABLE CMSAngleCreationMethod : 
	public IMSAngleCreationMethod,
	private ActionBaseImpl<IMSCreationParameters>
{
public:
	CMSAngleCreationMethod();

	DECLARE_PROTECT_FINAL_CONSTRUCT()
	DECLARE_ACTION_BASE_IMPL()

	HRESULT FinalConstruct();
	void FinalRelease();

public:
    STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);
    STDMETHOD(GetDimension)(IResultSet* set, int* dim);

public:
    CComPtr<IUnknown> m_pUnkMarshaler;
    DECLARE_GET_CONTROLLING_UNKNOWN()

};

