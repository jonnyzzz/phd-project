// MS2Metadata.h : Declaration of the CMS2Metadata

#pragma once
#include "resource.h"       // main symbols
#include "resultMetadata.h"
#include "ResultMetadataBase.h"
#include "GraphResult.h"
#include "ResultSet.h"


// IMS2Metadata
[
	object,
	uuid("5E5AEEE1-A73F-43C7-91A6-35249171D3C4"),
	dual,	helpstring("IMS2Metadata Interface"),
	pointer_default(unique)
]
__interface IMS2Metadata : IResultMetadata
{
    [id(10)]
    HRESULT GetSIGraphResult([out, retval] IResultSet** out);
    [id(11)]
    HRESULT SetSIGraphResult([in] IResultSet* in);
};



// CMS2Metadata

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernel2.MS2Metadata"),
	progid("MorseKernel2.MS2Metadata.1"),
	version(1.0),
	uuid("C18A9780-7C3A-4CA7-BD07-C8CE20EE8D6B"),
	helpstring("MS2Metadata Class")
]
class ATL_NO_VTABLE CMS2Metadata : 
	public IMS2Metadata,
    private ResultMetadataBase<IMS2Metadata, CMS2Metadata>
{
public:
	CMS2Metadata();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:

    STDMETHOD(EqualType)(IResultMetadata* metadata, VARIANT_BOOL* out);
    STDMETHOD(Clone)(IResultMetadata** out);

    STDMETHOD(GetSIGraphResult)(IResultSet** out);
    STDMETHOD(SetSIGraphResult)(IResultSet* in);

private:
    IResultSet* graphResult;
};

