// SymbolicImageMetadata.cpp : Implementation of CSymbolicImageMetadata

#include "stdafx.h"
#include "SymbolicImageMetadata.h"


// CSymbolicImageMetadata



CSymbolicImageMetadata::CSymbolicImageMetadata() {

}

HRESULT CSymbolicImageMetadata::FinalConstruct() {
	return S_OK;
}

void CSymbolicImageMetadata::FinalRelease() {
}



STDMETHODIMP CSymbolicImageMetadata::EqualType(IResultMetadata* metadata, VARIANT_BOOL* out) {
	ISymbolicImageMetadata* data;
	metadata->QueryInterface(&data);

	if (data != NULL) {
		*out = TRUE;
		data->Release();
	} else {
		*out = FALSE;
	}
	return S_OK;
}

STDMETHODIMP CSymbolicImageMetadata::Clone(IResultMetadata** out) {
	CSymbolicImageMetadata::CreateInstance(out);
	ATLASSERT(*out != NULL);
	return S_OK;
}