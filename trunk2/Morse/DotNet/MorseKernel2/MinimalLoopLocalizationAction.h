// MinimalLoopLocalizationAction.h : Declaration of the CMinimalLoopLocalizationAction

#pragma once
#include "resource.h"       // main symbols
#include "action.h"
#include "parameters.h"

// IMinimalLoopLocalizationAction
[
	object,
	uuid("9FFB9554-2D64-45EE-9F79-B31098FF8512"),
	dual,	helpstring("IMinimalLoopLocalizationAction Interface"),
	pointer_default(unique)
]
__interface IMinimalLoopLocalizationAction : IAction
{
	[id(44)]
	HRESULT GetDimension([in]IResultSet* resultSet, [out, retval]int* dimension);
};


[
	object,
	uuid("B90D3C01-F6F8-4D06-8E01-C12C6D51F70A"),
	dual,
	pointer_default(unique)
]
__interface IMinimalLoopLocalizationParameters : IParameters {
	[id(10)]
	HRESULT GetCoordinate([in] int id, [out, retval] double* data);
};

// CMinimalLoopLocalizationAction

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.MinimalLoopLocalizationAct"),
	progid("MorseKernel2.MinimalLoopLocalizationA.1"),
	version(1.0),
	uuid("7D81B505-C5D6-4AEF-83EF-CFAF07767898"),
	helpstring("MinimalLoopLocalizationAction Class")
]
class ATL_NO_VTABLE CMinimalLoopLocalizationAction : 
	public IMinimalLoopLocalizationAction
{
public:
	CMinimalLoopLocalizationAction();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:

	//IAction
public:
	STDMETHOD(SetActionParameters)(IParameters* parameters);
	STDMETHOD(SetProgressBarInfo)(IProgressBarInfo* pinfo);
	STDMETHOD(CanDo)(IResultSet* resultSet, VARIANT_BOOL* result);
	STDMETHOD(Do)(IResultSet* input, IResultSet** output);

	//IMinimalLoopLocalizationAction
public:
	STDMETHOD(GetDimension)(IResultSet* resultSet, int* result);

private:
	IProgressBarInfo* pinfo;
	IMinimalLoopLocalizationParameters* parameters;
};

