// Dummy.h : Declaration of the CDummy

#pragma once
#include "resource.h"       // main symbols
#include "Function.h"
#include "Action.h"
#include "Result.h"
#include "ResultBase.h"
#include "ResultSet.h"
#include "BoxMethodAction.h"
#include "TarjanAction.h"
#include "ComputationParameters.h"
#include "PointMethodAction.h"


// IDummy
[
	object,
	uuid("0A8C775B-8E19-4642-B2D7-5BBB437B7B97"),
	dual,	helpstring("IDummy Interface"),
	pointer_default(unique)
]
__interface IDummy : IDispatch
{
};



// CDummy

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.Dummy"),
	progid("MorseKernel2.Dummy.1"),
	version(1.0),
	uuid("8C3F6AAB-F725-4C70-A92A-7E4BD2A30C23"),
	helpstring("Dummy Class")
]
class ATL_NO_VTABLE CDummy : 
	public IDummy,
	public IAction,
	public IResult,
	public IResultBase,
	public IResultSet,
	public IFunction,
	public IBoxMethodParameters,
	public ITarjanParameters
{
public:
	CDummy()
	{
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease() 
	{
	}

public:



	// IAction Methods
public:
	STDMETHOD(SetActionParameters)(IParameters * parameters)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(SetProgressBarInfo)(IProgressBarInfo * pinfo)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(CanDo)(IResultSet * result, VARIANT_BOOL * can)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(Do)(IResultSet * input, IResultSet ** output)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}

	// IResult Methods
public:
	STDMETHOD(GetMetadata)(IResultMetadata** out) {
		return E_NOTIMPL;
	}

	// IResultBase Methods
public:

	// IResultSet Methods
public:
	STDMETHOD(GetCount)(int * count)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(GetResult)(int  index, IResultBase ** result)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}

	// IFunction Methods
public:
	STDMETHOD(GetSystemFunction)(void ** function)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(GetSystemFunctionDerivate)(void ** function)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(GetEquations)(BSTR * equations)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(GetDimension)(int * dimenstion)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(GetIterations)(int * iterations)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(CreateGraph)(void ** graph)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}

	// IBoxMethodParameters Methods
public:
	STDMETHOD(GetFactor)(int  index, int * factor)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(UseDerivate)(VARIANT_BOOL * out)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}

	// ITarjanParameters Methods
public:
	STDMETHOD(NeedEdgeResolve)(VARIANT_BOOL * result)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}

	// IComputationParameters Methods
public:
	STDMETHOD(GetFunction)(IFunction ** function)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}

	// IPointMethodParameters Methods
public:
	STDMETHOD(GetPoints)(int  index, int * ks)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(UseOffsets)(VARIANT_BOOL * data)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
	STDMETHOD(GetOffset)(int  index, double * offset1, double * offset2)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
};

