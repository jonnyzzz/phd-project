// MorseSpectrum.h : Declaration of the CMorseSpectrum

#pragma once
#include "resource.h"       // main symbols
#include "NodeBase.h"

// IMorseSpectrum
[
	object,
	uuid("E9A021D4-77A7-458E-BB1F-2F84DF48B982"),
	dual,	helpstring("IMorseSpectrum Interface"),
	pointer_default(unique)
]
__interface IMorseSpectrum : IKernelNode
{

	[propget, id(1), helpstring("property lowerBound")] 
		HRESULT lowerBound([out, retval] DOUBLE* pVal);
	[propput, id(1), helpstring("property lowerBound")] 
		HRESULT lowerBound([in] DOUBLE pVal);
	[propget, id(2), helpstring("property lowerBound")] 
		HRESULT upperBound([out, retval] DOUBLE* pVal);
	[propput, id(2), helpstring("property lowerBound")] 
		HRESULT upperBound([in] DOUBLE pVal);	
		[propget, id(3), helpstring("property lowerLength")] HRESULT lowerLength([out, retval] LONG* pVal);
		[propput, id(3), helpstring("property lowerLength")] HRESULT lowerLength([in] LONG newVal);
		[propget, id(4), helpstring("property upperLength")] HRESULT upperLength([out, retval] LONG* pVal);
		[propput, id(4), helpstring("property upperLength")] HRESULT upperLength([in] LONG newVal);
};



// CMorseSpectrum

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.MorseSpectrum"),
	progid("MorseKernelATL.MorseSpectrum.1"),
	version(1.0),
	uuid("BF5438F7-B6B4-457C-843E-C46539C7A2F7"),
	helpstring("MorseSpectrum Class")
]
class ATL_NO_VTABLE CMorseSpectrum : 
	public IMorseSpectrum
{
public:
	CMorseSpectrum()
	{
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();
	
private:
	double lower;
	double upper;

	LONG lowerLength;
	LONG upperLength;

public:

	STDMETHOD(get_lowerBound)(DOUBLE* pVal);
	STDMETHOD(put_lowerBound)(DOUBLE pVal);
	STDMETHOD(get_upperBound)(DOUBLE* pVal);
	STDMETHOD(put_upperBound)(DOUBLE pVal);
	STDMETHOD(get_lowerLength)(LONG* pVal);
	STDMETHOD(put_lowerLength)(LONG newVal);
	STDMETHOD(get_upperLength)(LONG* pVal);
	STDMETHOD(put_upperLength)(LONG newVal);
};

