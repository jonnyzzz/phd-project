// GraphResultImpl.cpp : Implementation of CGraphResultImpl

#include "stdafx.h"
#include "GraphResultImpl.h"
#include "GraphInfoImpl.h"
#include "../graph/graph.h"
#include "SmartInterface.h"
#include "../graph/fileStream.h"

// CGraphResultImpl


CGraphResultImpl::CGraphResultImpl() {

}


HRESULT CGraphResultImpl::FinalConstruct() {
	this->graph = NULL;
	this->metadata = NULL;
	return S_OK;
}


void CGraphResultImpl::FinalRelease() {
	SAFE_DELETE(this->graph);
	SAFE_RELEASE(this->metadata);
}


STDMETHODIMP CGraphResultImpl::GetMetadata(IResultMetadata** out) {
	ATLASSERT(metadata != NULL);
	metadata->QueryInterface(out);
	ATLASSERT(*out != NULL);
	return S_OK;
}



STDMETHODIMP CGraphResultImpl::GetGraph(void** graph) {
	ATLASSERT(this->graph != NULL);

	*graph = (void*)this->graph;
	
	return S_OK;
}


STDMETHODIMP CGraphResultImpl::GetGraphInfo(IGraphInfo** info) {
	SmartInterface<IWritableGraphInfo> pinfo;
	CGraphInfoImpl::CreateInstance(&pinfo);

	ATLASSERT(pinfo != NULL);
	
	HRESULT hr = pinfo->AddGraph((void**)&this->graph);
	
	ATLASSERT( SUCCEEDED(hr) );

	pinfo->QueryInterface(info);
	ATLASSERT(*info != NULL);

	return S_OK;

}


STDMETHODIMP CGraphResultImpl::IsStrongComponent(VARIANT_BOOL* value) {
	ATLASSERT(this->graph != NULL);
	*value = isStongComponent?TRUE:FALSE;

	return S_OK;
}


STDMETHODIMP CGraphResultImpl::SetGraph(void** graph, VARIANT_BOOL isStrongComponent) {
	SAFE_DELETE(this->graph);
	this->graph = *(Graph**)graph;
	this->isStongComponent = (isStrongComponent == TRUE)?true:false;

	return S_OK;
}

STDMETHODIMP CGraphResultImpl::SetMetadata(IResultMetadata* in) {
	SAFE_RELEASE(metadata);

	in->QueryInterface(&metadata);

	ATLASSERT(metadata != NULL);

	return S_OK;
}


STDMETHODIMP CGraphResultImpl::SaveText(BSTR file) {
	CString fileName(file);

	FileOutputStream out(fileName);
	if (!out.EnshureOpened()) return E_FAIL;


	saveGraphAsPoints(out, this->graph);

	return S_OK;
}

STDMETHODIMP CGraphResultImpl::SaveGraph(BSTR file) {
	CString fileName(file);

	FileOutputStream out(fileName);
	if (!out.EnshureOpened()) return E_FAIL;

	saveGraph(out, this->graph);

	return S_OK;
}

