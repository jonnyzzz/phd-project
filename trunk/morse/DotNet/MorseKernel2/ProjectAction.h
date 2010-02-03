// ProjectAction.h : Declaration of the CProjectAction

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "ActionBaseImpl.h"
#include "ComputationParameters.h"


// IProjectAction
[
	object,
	uuid("DD6571DF-3579-4F30-BB16-482CA0A104A4"),
	dual,	helpstring("IProjectAction Interface"),
	pointer_default(unique)
]
__interface IProjectAction : IAction
{
	[id(11)]
	HRESULT GetDimention([in] IResultSet* set, [out,retval] int* dim);
};

// IProjectActionParameters
[
	object,
	uuid("840AFB9E-F0B8-4601-8326-C101F192137D"),
	dual,	helpstring("IProjectAction Interface"),
	pointer_default(unique)
]
__interface IProjectActionParameters : IParameters
{
	[id(11)]
	HRESULT GetDevisor([in] int index, [out,retval] int* value);
};


// CProjectAction

[
	coclass,
	threading(apartment),
	vi_progid("MorseKernel2.ProjectAction"),
	progid("MorseKernel2.ProjectAction.1"),
	version(1.0),
	uuid("6BA86546-D41F-4AC5-A63F-71F7A6B61529"),
	helpstring("ProjectAction Class")
]
class ATL_NO_VTABLE CProjectAction : 
	public IProjectAction,
	private ActionBaseImpl<IProjectActionParameters>
{
public:
	CProjectAction();

	DECLARE_PROTECT_FINAL_CONSTRUCT()
	DECLARE_ACTION_BASE_IMPL()

	HRESULT FinalConstruct();	
	void FinalRelease();

public:

	STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);
	STDMETHOD(GetDimention)(IResultSet* set, int* dim);

public:
    CComPtr<IUnknown> m_pUnkMarshaler;
    DECLARE_GET_CONTROLLING_UNKNOWN()

};

