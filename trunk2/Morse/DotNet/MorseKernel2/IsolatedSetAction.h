// IsolatedSetAction.h : Declaration of the CIsolatedSetAction

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "Parameters.h"
#include "GraphResult.h"

// IIsolatedSetAction
[
	object,
	uuid("787DC58F-CD39-4BE2-9B58-D5B99ADCFC4D"),
	dual,	helpstring("IIsolatedSetAction Interface"),
	pointer_default(unique)
]
__interface IIsolatedSetAction : IAction
{
};

[
	object,
	uuid("01C806AD-6003-4F5B-8405-AE3DD637D854"),
	dual,
	pointer_default(unique)
]
__interface IIsolatedSetParameters : IParameters {
	[id(22)]
	HRESULT GetStartSet([out, retval] IGraphResult** result);
};


// CIsolatedSetAction

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.IsolatedSetAction"),
	progid("MorseKernel2.IsolatedSetAction.1"),
	version(1.0),
	uuid("5345FB53-5138-4D28-A6FC-294DF9D0A1E9"),
	helpstring("IsolatedSetAction Class")
]
class ATL_NO_VTABLE CIsolatedSetAction : 
	public IIsolatedSetAction
{
public:
	CIsolatedSetAction();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

	//IAction
public:
	STDMETHOD(SetActionParameters)(IParameters* parameters);
	STDMETHOD(SetProgressBarInfo)(IProgressBarInfo* pinfo);
	STDMETHOD(CanDo)(IResultSet* resultSet, VARIANT_BOOL* result);
	STDMETHOD(Do)(IResultSet* input, IResultSet** output);

public:
	IIsolatedSetParameters* parameters;
	IProgressBarInfo* pinfo;

public:
    CComPtr<IUnknown> m_pUnkMarshaler;
    DECLARE_GET_CONTROLLING_UNKNOWN()

};

