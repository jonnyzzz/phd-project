// GraphResultImpl.cpp : Implementation of CGraphResultImpl

#include "stdafx.h"
#include "GraphResultImpl.h"
#include "GraphInfoImpl.h"
#include "../graph/graph.h"


// CGraphResultImpl


CGraphResultImpl::CGraphResultImpl() {

}


HRESULT CGraphResultImpl::FinalConstruct() {
	return S_OK;
}


void CGraphResultImpl::FinalRelease() {
}

STDMETHODIMP CGraphResultImpl::GetGraph(void** graph) {
	ATLASSERT(this->graph != NULL);

	*graph = (void*)this->graph;
	
	return S_OK;
}


STDMETHODIMP CGraphResultImpl::GetGraphInfo(IGraphInfo** info) {
	IWritableGraphInfo* pinfo;
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
