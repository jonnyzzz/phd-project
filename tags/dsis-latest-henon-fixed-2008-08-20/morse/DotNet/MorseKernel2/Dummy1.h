// Dummy1.h : Declaration of the CDummy1

#pragma once
#include "resource.h"       // main symbols
#include "PointMethodAction.h"
#include "ComputationParameters.h"
#include "IsolatedSetAction.h"
#include "MinimalLoopLocalizationAction.h"
#include "SIRomAction.h"
#include "SpectrumMetadata.h"
#include "SpectrumResult.h"


// IDummy1
[
	object,
	uuid("5896F6EB-CFBF-406C-A0FD-EA25367673D0"),
	dual,	helpstring("IDummy1 Interface"),
	pointer_default(unique)
]
__interface IDummy1 : IDispatch
{
};



// CDummy1

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.Dummy1"),
	progid("MorseKernel2.Dummy1.1"),
	version(1.0),
	uuid("62172280-D7A2-46C1-AF3D-E8762035048E"),
	helpstring("Dummy1 Class")
]
class ATL_NO_VTABLE CDummy1 : 
	public IDummy1,
	public IPointMethodParameters,
	public IIsolatedSetParameters,
	public IMinimalLoopLocalizationParameters
{
public:
	CDummy1()
	{
		m_pUnkMarshaler = NULL;
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()
	DECLARE_GET_CONTROLLING_UNKNOWN()

	HRESULT FinalConstruct()
	{
		return CoCreateFreeThreadedMarshaler(
			GetControllingUnknown(), &m_pUnkMarshaler.p);
	}

	void FinalRelease()
	{
		m_pUnkMarshaler.Release();
	}

	CComPtr<IUnknown> m_pUnkMarshaler;

public:


	// IPointMethodParameters Methods
public:
	STDMETHOD(GetFactor)(int  index, int * factor)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}
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

	// IComputationParameters Methods
public:
	STDMETHOD(GetFunction)(IFunction ** function)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}

	// IIsolatedSetParameters Methods
public:
	STDMETHOD(GetStartSet)(IGraphResult ** result)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}

	// IMinimalLoopLocalizationParameters Methods
public:
	STDMETHOD(GetCoordinate)(int  id, double * data)
	{
		// Add your function implementation here.
		return E_NOTIMPL;
	}

	// ISIRomActionParameters Methods
public:
};
