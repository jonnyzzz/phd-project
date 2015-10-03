// MS2Metadata.cpp : Implementation of CMS2Metadata

#include "stdafx.h"
#include "MS2Metadata.h"


// CMS2Metadata

CMS2Metadata::CMS2Metadata() {
}

HRESULT CMS2Metadata::FinalConstruct() {
    return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CMS2Metadata::FinalRelease() {
    m_pUnkMarshaler.Release();
}


STDMETHODIMP CMS2Metadata::EqualType(IResultMetadata* metadata, VARIANT_BOOL* out) {
    return _MetadataBase_EqualType(metadata, out);
}


STDMETHODIMP CMS2Metadata::Clone(IResultMetadata **out) {
    _MetadataBase_Clone(out);

    SmartInterface<IMS2Metadata> myData;
    (*out)->QueryInterface(myData.extract());

    HRESULT hr;
    VARIANT_BOOL hasSI;
    hr = HasSIGraphResult(&hasSI);
    ATLASSERT(SUCCEEDED(hr));

    if (hasSI == VARIANT_TRUE) {
        myData->SetSIGraphResult(graphResult);
    }

    return S_OK;
}   

STDMETHODIMP CMS2Metadata::GetTypeName(BSTR* name) {
	return _MetadataBase_GetTypeName(name);
}

STDMETHODIMP CMS2Metadata::GetSIGraphResult(IResultSet** out) {
    if (graphResult == NULL) {
        *out = NULL;
    } else {
        graphResult->QueryInterface(out);
        ATLASSERT(*out != NULL);
    }
    return S_OK;
}


STDMETHODIMP CMS2Metadata::SetSIGraphResult(IResultSet* in) {
    if (in == NULL) {
        graphResult.reset();
    } else {
        in->QueryInterface(graphResult.extract());
        ATLASSERT(graphResult != NULL);
    }
    return S_OK;
}

STDMETHODIMP CMS2Metadata::HasSIGraphResult(VARIANT_BOOL* out) {
    *out = graphResult == NULL ? VARIANT_FALSE : VARIANT_TRUE;
    return S_OK;
}