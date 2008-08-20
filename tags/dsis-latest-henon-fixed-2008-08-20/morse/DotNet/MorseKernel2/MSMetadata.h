// MSMetadata.h : Declaration of the CMSMetadata

#pragma once
#include "resource.h"       // main symbols
#include "ResultMetadata.h"
#include "ResultMetadataBase.h"
#include "GraphResult.h"
#include "ResultSet.h"


// IMSMetadata
[
	object,
	uuid("9FC179BA-4641-46FF-8F8B-D277C1035964"),
	dual,	helpstring("IMSMetadata Interface"),
	pointer_default(unique)
]
__interface IMSMetadata : IResultMetadata
{
};



// CMSMetadata

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.MSMetadata"),
	progid("MorseKernel2.MSMetadata.1"),
	version(1.0),
	uuid("C6CD341D-6AFD-48E2-8711-643D3ED2377A"),
	helpstring("MSMetadata Class")
]
class ATL_NO_VTABLE CMSMetadata : 
	public IMSMetadata,
    private ResultMetadataBase<IMSMetadata, CMSMetadata>
{
public:
	CMSMetadata();

	DECLARE_PROTECT_FINAL_CONSTRUCT()
    DECLARE_RESULT_METADATA_DECLARE_BASE()

	HRESULT FinalConstruct();
	void FinalRelease();

public:
    CComPtr<IUnknown> m_pUnkMarshaler;
    DECLARE_GET_CONTROLLING_UNKNOWN()


};

