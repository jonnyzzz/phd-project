// PersistantManager.h : Declaration of the CPersistantManager

#pragma once
#include "resource.h"       // main symbols
#include "Result.h"


// IPersistantManager
[
	object,
	uuid("7750D060-BA83-45FE-8E6C-C8437F7340E8"),
	dual,	helpstring("IPersistantManager Interface"),
	pointer_default(unique)
]
__interface IResultPersistantManager : IDispatch
{
//	[id(1)]
//	HRESULT SaveResult([in] BSTR file, [in] IResult* result);
//	[id(2)]
//	HRESULT LoadResult([in] BSTR file, [out] IResult** result);
};

[
	object,
	uuid("40D91BB9-1AFF-43CE-B0D8-ED857119D0B7"),
	dual,	helpstring("IPersistantManager Interface"),
	pointer_default(unique)
]
__interface IMetadataPersistantManager : IDispatch
{
//	[id(1)]
//	HRESULT SaveMetadata([in] BSTR file, [in] IResultMetadata* metadata);
//	[id(2)]
//	HRESULT LoadMetadata([in] BSTR file, [out] IResultMetadata** metadata);
};


// CPersistantManager

[
	coclass,
	threading(apartment),
	vi_progid("MorseKernel2.PersistantManager"),
	progid("MorseKernel2.PersistantManager.1"),
	version(1.0),
	uuid("54D9CE4E-C1BD-46D2-A7FD-64B5A04A7CBD"),
	helpstring("PersistantManager Class")
]
class ATL_NO_VTABLE CPersistantManager : 
	public IResultPersistantManager,
	public IMetadataPersistantManager
{
public:	
	CPersistantManager();

	DECLARE_PROTECT_FINAL_CONSTRUCT()
	DECLARE_GET_CONTROLLING_UNKNOWN()

	HRESULT FinalConstruct();
	void FinalRelease();

	CComPtr<IUnknown> m_pUnkMarshaler;

public:


};

