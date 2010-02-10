#pragma once
#include "smartInterface.h"

template<class IInheritor, class CInheritor>
class ResultMetadataBase
{

public:
	HRESULT _MetadataBase_EqualType(IResultMetadata* metadata, VARIANT_BOOL* out) {
		SmartInterface<IInheritor> data;
		metadata->QueryInterface(data.extract());

		if (data != NULL) {
			*out = VARIANT_TRUE;
		} else {
			*out = VARIANT_FALSE;
		}
		return S_OK;
	}

	HRESULT _MetadataBase_Clone(IResultMetadata** out) {
		CInheritor::CreateInstance(out);
		ATLASSERT(*out != NULL);
		return S_OK;
	}

	HRESULT _MetadataBase_GetTypeName(BSTR* str) {
		CString string = "NOT_IMPL";
		if (str == NULL) 
			return E_FAIL;
		*str = string.AllocSysString();
		return E_NOTIMPL;
	}
};


#define DECLARE_RESULT_METADATA_DECLARE_BASE()  \
	public: \
 STDMETHOD(EqualType)(IResultMetadata* metadata, VARIANT_BOOL* out) { return _MetadataBase_EqualType(metadata, out); } \
 STDMETHOD(Clone)(IResultMetadata** out) { return _MetadataBase_Clone(out);}  \
 STDMETHOD(GetTypeName)(BSTR* data) { return _MetadataBase_GetTypeName(data); }