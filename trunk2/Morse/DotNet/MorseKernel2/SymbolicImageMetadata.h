// SymbolicImageMetadata.h : Declaration of the CSymbolicImageMetadata

#pragma once
#include "resource.h"       // main symbols
#include "ResultMetadata.h"

// ISymbolicImageMetadata
[
	object,
	uuid("24EEB65B-81FF-42EA-8521-6B3F62665F84"),
	dual,	helpstring("ISymbolicImageMetadata Interface"),
	pointer_default(unique)
]
__interface ISymbolicImageMetadata : IResultMetadata
{
};



// CSymbolicImageMetadata

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernel2.SymbolicImageMetadata"),
	progid("MorseKernel2.SymbolicImageMetadata.1"),
	version(1.0),
	uuid("A5D5EA06-663E-4755-A3E7-A536E83B5AC2"),
	helpstring("SymbolicImageMetadata Class")
]
class ATL_NO_VTABLE CSymbolicImageMetadata : 
	public ISymbolicImageMetadata
{
public:
	CSymbolicImageMetadata();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();


	//IResultMetadata
public:
	STDMETHOD(EqualType)(IResultMetadata* metadata, VARIANT_BOOL* out);
	STDMETHOD(Clone)(IResultMetadata** out);




};

