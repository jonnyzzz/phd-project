// MSAngleMetadata.h : Declaration of the CMSAngleMetadata

#pragma once
#include "resource.h"       // main symbols
#include "ResultMetadata.h"
#include "ResultMetadataBase.h"
#include "GraphResult.h"
#include "ResultSet.h"
#include "MSMetadata.h"


// IMSAngleMetadata
[
	object,
	uuid("9C056BFB-EC29-4AD8-BBAF-18F6AB76EAA0"),
	dual,	helpstring("IMSAngleMetadata Interface"),
	pointer_default(unique)
]
__interface IMSAngleMetadata : IMSMetadata
{
};



// CMSAngleMetadata

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.MSAngleMetadata"),
	progid("MorseKernel2.MSAngleMetadata.1"),
	version(1.0),
	uuid("C9400229-3A87-43BA-9819-07EC65EBCD10"),
	helpstring("MSAngleMetadata Class")
]
class ATL_NO_VTABLE CMSAngleMetadata : 
	public IMSAngleMetadata,
	private ResultMetadataBase<IMSAngleMetadata, CMSAngleMetadata>
{
public:
	CMSAngleMetadata();

	DECLARE_PROTECT_FINAL_CONSTRUCT()
    DECLARE_RESULT_METADATA_DECLARE_BASE()

	HRESULT FinalConstruct();
	
	void FinalRelease();
};

