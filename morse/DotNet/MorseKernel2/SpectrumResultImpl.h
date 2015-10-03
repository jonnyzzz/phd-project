// SpectrumResultImpl.h : Declaration of the CSpectrumResultImpl

#pragma once
#include "resource.h"       // main symbols
#include "spectrumresult.h"
#include "writablespectrum.h"
#include "smartinterface.h"

// CSpectrumResultImpl

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.SpectrumResultImpl"),
	progid("MorseKernel2.SpectrumResultImpl.1"),
	version(1.0),
	uuid("45FBC041-D2C1-495D-8CC9-58019691E9CC"),
	helpstring("SpectrumResultImpl Class")
]
class ATL_NO_VTABLE CSpectrumResultImpl : 
	public ISpectrumResult,
	public IWritableSpectrumResult
{
public:
	CSpectrumResultImpl();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:
	
	//ISpectrumResult
	STDMETHOD(GetLowerBound)(double* data);	
	STDMETHOD(GetUpperBound)(double* data);	
	STDMETHOD(GetLowerLength)(int* data);	
	STDMETHOD(GetUpperLength)(int* data);		
	STDMETHOD(GetMetadata)(IResultMetadata** data);

	//IWritableResult
	STDMETHOD(SetLowerBound)(double data);
	STDMETHOD(SetUpperBound)(double data);
	STDMETHOD(SetLowerLength)(int data);
	STDMETHOD(SetUpperLength)(int data);
	STDMETHOD(SetMetadata)(IResultMetadata* data);

private:
	SmartInterface<IResultMetadata> metadata;
	double lowerBound;
	double upperBound;
	int lowerLength;
	int upperLength;

public:
    CComPtr<IUnknown> m_pUnkMarshaler;
    DECLARE_GET_CONTROLLING_UNKNOWN()

};

