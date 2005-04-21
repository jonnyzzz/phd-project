// SpectrumMetadata.h : Declaration of the CSpectrumMetadata

#pragma once
#include "resource.h"       // main symbols
#include "resultMetadata.h"
#include "ResultMetadataBase.h"
// ISpectrumMetadata
[
	object,
	uuid("139E4822-4DF9-44B1-8825-FAD074492505"),
	dual,	helpstring("ISpectrumMetadata Interface"),
	pointer_default(unique)
]
__interface ISpectrumMetadata : IResultMetadata
{
};



// CSpectrumMetadata

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.SpectrumMetadata"),
	progid("MorseKernel2.SpectrumMetadata.1"),
	version(1.0),
	uuid("3855504A-AE6E-4601-B6E5-026F7E073D9B"),
	helpstring("SpectrumMetadata Class")
]
class ATL_NO_VTABLE CSpectrumMetadata : 
	public ISpectrumMetadata,
	private ResultMetadataBase<ISpectrumMetadata, CSpectrumMetadata>
{
public:
	CSpectrumMetadata()
	{
		m_pUnkMarshaler = NULL;
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()
	DECLARE_GET_CONTROLLING_UNKNOWN()
	DECLARE_RESULT_METADATA_DECLARE_BASE()

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

};

