// PointMethodAction.h : Declaration of the CPointMethodAction

#pragma once
#include "resource.h"       // main symbols
#include "Action.h"
#include "computationParameters.h"

// IPointMethodAction
[
	object,
	uuid("1B1FF1EE-4EB6-4F0A-B6AB-CCBFFA28B9F0"),
	dual,	helpstring("IPointMethodAction Interface"),
	pointer_default(unique)
]
__interface IPointMethodAction : IAction
{
	[id(110)]
	HRESULT GetDimensionForParameters([in] IResultSet* resultSet, [out, retval] int* dimension);
};


[
	object,
	uuid("ADCEDDBC-441A-479D-8E7A-706921DA82AC"),
	dual,
	pointer_default(unique)
]
__interface IPointMethodParameters : IComputationParameters {
	[id(10)]
	HRESULT GetFactor([in] int index, [out, retval] int* factor);
	[id(11)]
	HRESULT GetPoints([in] int index, [out, retval] int* ks);
	[id(12)]
	HRESULT UseOffsets([out, retval] VARIANT_BOOL* data);
	[id(13)]
	HRESULT GetOffset([in] int index, [out] double* offset1, [out] double* offset2);
};


// CPointMethodAction

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernel2.PointMethodAction"),
	progid("MorseKernel2.PointMethodAction.1"),
	version(1.0),
	uuid("A1A0ABCD-1591-4846-88A0-10AF62560C37"),
	helpstring("PointMethodAction Class")
]
class ATL_NO_VTABLE CPointMethodAction : 
	public IPointMethodAction
{
public:
	CPointMethodAction();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:
		//IBoxMethodParameters
public:
	STDMETHOD(GetDimensionForParameters)(IResultSet* resultSet, int* dimension);

public:
	STDMETHOD(SetActionParameters)(IParameters* pars);
	STDMETHOD(SetProgressBarInfo)(IProgressBarInfo* info);
	STDMETHOD(CanDo)(IResultSet* in, VARIANT_BOOL* out);
	STDMETHOD(Do)(IResultSet* in, IResultSet** out);
	
private:
	IProgressBarInfo* info;
	IPointMethodParameters* parameters;

};

