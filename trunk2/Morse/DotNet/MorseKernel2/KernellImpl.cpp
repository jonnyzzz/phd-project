// KernellImpl.cpp : Implementation of CKernellImpl

#include "stdafx.h"
#include "KernellImpl.h"
#include "../Graph/Graph.h"
#include "GraphResultImpl.h"
#include "SymbolicImageMetadata.h"
#include "SmartInterface.h"

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
	ATLASSERT(this->function != NULL);

	this->function->QueryInterface(function);
	ATLASSERT(*function != NULL);
	return S_OK;
}


STDMETHODIMP CKernellImpl::SetFunction(IFunction* function) {
	SAFE_RELEASE(this->function);
	function->QueryInterface(&this->function);
	ATLASSERT(this->function != NULL);
	return S_OK;
}

STDMETHODIMP CKernellImpl::CreateInitialResult(IResultBase** result) {
	
	ATLASSERT(this->function != NULL);

	SmartInterface<IWritableGraphResult> graphResult;
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

	SmartInterface<ISymbolicImageMetadata> metadata;
	CSymbolicImageMetadata::CreateInstance(&metadata);
	ATLASSERT(metadata != NULL);

	graphResult->SetMetadata(metadata);

	graphResult->QueryInterface(result);
	ATLASSERT(*result != NULL);
	
	return S_OK;
}