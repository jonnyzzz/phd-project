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
	return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}


void CGraphResultImpl::FinalRelease() {
	SAFE_DELETE(this->graph);
	SAFE_RELEASE(this->metadata);
    m_pUnkMarshaler.Release();
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
	CGraphInfoImpl::CreateInstance(pinfo.extract());

	ATLASSERT(pinfo != NULL);
	
	HRESULT hr = pinfo->AddGraph((void**)&this->graph);
	
	ATLASSERT( SUCCEEDED(hr) );

	pinfo->QueryInterface(info);
	ATLASSERT(*info != NULL);

	return S_OK;

}


STDMETHODIMP CGraphResultImpl::IsStrongComponent(VARIANT_BOOL* value) {
	ATLASSERT(this->graph != NULL);
	*value = isStongComponent?VARIANT_TRUE:VARIANT_FALSE;

	cout<<"\n\nisStrongConpSet: Get ";
	if (this->isStongComponent) {
		cout<<"TRUE";
	} else {
		cout<<"FALSE";
	}
	cout<<" \n\n";

	return S_OK;
}


STDMETHODIMP CGraphResultImpl::SetGraph(void** graph, VARIANT_BOOL isStrongComponent) {
	SAFE_DELETE(this->graph);
	this->graph = *(Graph**)graph;
	this->isStongComponent = (isStrongComponent == VARIANT_TRUE)?true:false;

	cout<<"\n\nisStrongConpSet: ";
	if (this->isStongComponent) {
		cout<<"TRUE";
	} else {
		cout<<"FALSE";
	}
	cout<<" \n\n";

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


	Graph::saveGraphAsPoints(out, this->graph);

	return S_OK;
}

STDMETHODIMP CGraphResultImpl::SaveGraph(BSTR file) {
	CString fileName(file);

	FileOutputStream out(fileName);
	if (!out.EnshureOpened()) return E_FAIL;

	Graph::saveGraph(out, this->graph);

	return S_OK;
}

STDMETHODIMP CGraphResultImpl::SetGraphFromFile(BSTR file, VARIANT_BOOL isStrong) {
	CString filename(file);

	FileInputStream in(filename);
	if (!in.EnshureOpened()) return E_FAIL;

	Graph* graph = Graph::createGraph(in);

	HRESULT hr = SetGraph((void**)&graph, isStrong);

	if (FAILED(hr)) {
		delete graph;
	}

	return hr;
}