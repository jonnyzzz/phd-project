// SpectrumResultImpl.cpp : Implementation of CSpectrumResultImpl

#include "stdafx.h"
#include "SpectrumResultImpl.h"


// CSpectrumResultImpl

CSpectrumResultImpl::CSpectrumResultImpl() {

}


HRESULT CSpectrumResultImpl::FinalConstruct() {
	return S_OK;
}

void CSpectrumResultImpl::FinalRelease() {

}


STDMETHODIMP CSpectrumResultImpl::GetLowerBound(double* data) {
	*data = lowerBound;
	return S_OK;
}

STDMETHODIMP CSpectrumResultImpl::GetUpperBound(double* data) {
	*data = upperBound;
	return S_OK;
}

STDMETHODIMP CSpectrumResultImpl::GetLowerLength(int *data) {
	*data = lowerLength;
	return S_OK;
}

STDMETHODIMP CSpectrumResultImpl::GetUpperLength(int* data) {
	*data = upperLength;
	return S_OK;
}

STDMETHODIMP CSpectrumResultImpl::GetMetadata(IResultMetadata** out) {
	if (metadata != NULL) {
		metadata->QueryInterface(out);
		ATLASSERT(*out != NULL);
		return S_OK;
	}
	return E_FAIL;
}



STDMETHODIMP CSpectrumResultImpl::SetLowerBound(double data) {
	this->lowerBound = data;
	return S_OK;
}

STDMETHODIMP CSpectrumResultImpl::SetUpperBound(double data) {
	this->upperBound = data;
	return S_OK;
}

STDMETHODIMP CSpectrumResultImpl::SetLowerLength(int data) {
	this->lowerLength = data;
	return S_OK;
}

STDMETHODIMP CSpectrumResultImpl::SetUpperLength(int data) {
	this->upperLength = data;
	return S_OK;
}

STDMETHODIMP CSpectrumResultImpl::SetMetadata(IResultMetadata* data) {
	data->QueryInterface(metadata.extract());
	ATLASSERT(metadata != NULL);
	return S_OK;
}
