// KernellImpl.cpp : Implementation of CKernellImpl

#include "stdafx.h"
#include "KernellImpl.h"
#include "../Graph/Graph.h"
#include "GraphResultImpl.h"

// CKernellImpl

CKernellImpl::CKernellImpl() {
}

HRESULT CKernellImpl::FinalConstruct() {
	function = NULL;
	return S_OK;
}

void CKernellImpl::FinalRelease() {
	SAFE_RELEASE(function);
}


STDMETHODIMP CKernellImpl::GetFunction(IFunction** function) {
	if (this->function == NULL) {
		*function = NULL;
		return E_FAIL;
	} else {
		this->function->QueryInterface(function);
		ATLASSERT(*function != NULL);
		return S_OK;
	}
}


STDMETHODIMP CKernellImpl::SetFunction(IFunction* function) {
	SAFE_RELEASE(this->function);
	function->QueryInterface(&this->function);
	ATLASSERT(this->function != NULL);
	return S_OK;
}

STDMETHODIMP CKernellImpl::CreateInitialResult(IResultBase** result) {
	if (function == NULL) {
		*result = NULL;
		return E_FAIL;
	} else {
		IWritableGraphResult* graphResult;
		CGraphResultImpl::CreateInstance(&graphResult);
		ATLASSERT(graphResult != NULL);

		Graph* graph;
		HRESULT hr = function->CreateGraph((void**)&graph);
		if (FAILED(hr)) {
			*result = NULL;
			return hr;
		}

		graph->maximize();

		graphResult->SetGraph((void**)&graph, FALSE);

		graphResult->QueryInterface(result);
		ATLASSERT(*result != NULL);

		graphResult->Release();

		return S_OK;
	}
}