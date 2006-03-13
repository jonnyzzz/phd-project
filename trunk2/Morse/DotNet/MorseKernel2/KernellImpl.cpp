// KernellImpl.cpp : Implementation of CKernellImpl

#include "stdafx.h"
#include "KernellImpl.h"
#include "../Graph/Graph.h"
#include "GraphResultImpl.h"
#include "SymbolicImageMetadata.h"
#include "SmartInterface.h"
#include "GraphResultWrapper.h"

// CKernellImpl

CKernellImpl::CKernellImpl() {
}

HRESULT CKernellImpl::FinalConstruct() {
	function = NULL;
	return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CKernellImpl::FinalRelease() {
	SAFE_RELEASE(function);
    m_pUnkMarshaler.Release();
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

STDMETHODIMP CKernellImpl::CreateInitialResultSet(IResultSet** result) {
	
	ATLASSERT(this->function != NULL);

	SmartInterface<ISymbolicImageMetadata> metadata;
	CSymbolicImageMetadata::CreateInstance(metadata.extract());
	ATLASSERT(metadata != NULL);

	GraphResultGraphList lst(metadata);

	Graph* graph;
	HRESULT hr = function->CreateGraph((void**)&graph);
	ATLASSERT(SUCCEEDED(hr));

	graph->maximize();

	lst.AddGraph(graph, false);

	lst.GetResultSet(result);
	ATLASSERT(*result != NULL);
	
	return S_OK;
}