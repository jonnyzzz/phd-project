// MSSegmentMetadata.h : Declaration of the CMSSegmentMetadata

#pragma once
#include "resource.h"       // main symbols
#include "ResultMetadata.h"
#include "ResultMetadataBase.h"
#include "GraphResult.h"
#include "ResultSet.h"
#include "MSMetadata.h"

// IMSSegmentMetadata
[
	object,
	uuid("EC1007B0-EB8F-4234-85D1-31518BBBEE58"),
	dual,	helpstring("IMSSegmentMetadata Interface"),
	pointer_default(unique)
]
__interface IMSSegmentMetadata : IMSMetadata
{
};



// CMSSegmentMetadata

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.MSSegmentMetadata"),
	progid("MorseKernel2.MSSegmentMetadata.1"),
	version(1.0),
	uuid("2EC18A59-16F4-4532-BCE8-360B777D68AF"),
	helpstring("MSSegmentMetadata Class")
]
class ATL_NO_VTABLE CMSSegmentMetadata : 
	public IMSSegmentMetadata,
    private ResultMetadataBase<IMSSegmentMetadata, CMSSegmentMetadata>
{
public:
	CMSSegmentMetadata();

	DECLARE_PROTECT_FINAL_CONSTRUCT()
    DECLARE_RESULT_METADATA_DECLARE_BASE()

	HRESULT FinalConstruct();
	void FinalRelease();

public:

};

