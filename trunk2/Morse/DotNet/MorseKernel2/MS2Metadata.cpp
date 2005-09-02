// MS2Metadata.cpp : Implementation of CMS2Metadata

#include "stdafx.h"
#include "MS2Metadata.h"


// CMS2Metadata

CMS2Metadata::CMS2Metadata() {
    graphResult = NULL;
}

HRESULT CMS2Metadata::FinalConstruct() {
    return S_OK;
}

void CMS2Metadata::FinalRelease() {
    SAFE_RELEASE(graphResult);
}


STDMETHODIMP CMS2Metadata::EqualType(IResultMetadata* metadata, VARIANT_BOOL* out) {
    return _MetadataBase_EqualType(metadata, out);
}


STDMETHODIMP CMS2Metadata::Clone(IResultMetadata **out) {
    _MetadataBase_Clone(out);

    SmartInterface<IMS2Metadata> myData;
    (*out)->QueryInterface(myData.extract());

    myData->SetSIGraphResult(graphResult);

    return S_OK;
}   


STDMETHODIMP CMS2Metadata::GetSIGraphResult(IGraphResult** out) {
    graphResult->QueryInterface(out);
    ATLASSERT(*out != NULL);
    return S_OK;
}


STDMETHODIMP CMS2Metadata::SetSIGraphResult(IGraphResult* in) {
    SAFE_RELEASE(graphResult);
    in->QueryInterface(&graphResult);
    ATLASSERT(graphResult != NULL);
    return S_OK;
}