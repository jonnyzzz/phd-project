// GraphInfoImpl.cpp : Implementation of CGraphInfoImpl

#include "stdafx.h"
#include "GraphInfoImpl.h"
#include "../graph/graph.h"


// CGraphInfoImpl

CGraphInfoImpl::CGraphInfoImpl() {

}

HRESULT CGraphInfoImpl::FinalConstruct() {
	this->dimension = 0;
	return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CGraphInfoImpl::FinalRelease() {
    m_pUnkMarshaler.Release();
}



STDMETHODIMP CGraphInfoImpl::GetNodes(int * value) {
	if (graphSet.size() == 0) return E_FAIL;
	int val = 0;
	for (GraphSet::iterator it = graphSet.begin(); it != graphSet.end(); it++) {
		val += (*it)->getNumberOfNodes();
	}
	*value = val;

	return S_OK;

}


STDMETHODIMP CGraphInfoImpl::GetEdges(int* value) {
	if (graphSet.size() == 0) return E_FAIL;
	int val = 0;
	for (GraphSet::iterator it = graphSet.begin(); it != graphSet.end(); it++) {
		val += (*it)->getNumberOfArcs();
	}
	*value = val;

	return S_OK;
}

STDMETHODIMP CGraphInfoImpl::GetDimension(int* value) {
	if (graphSet.size() == 0) return E_FAIL;
	*value = dimension;
	return S_OK;
}

STDMETHODIMP CGraphInfoImpl::GetMinimum(int index, double* value) {
	if (graphSet.size() == 0) return E_FAIL;
	if (index < 0 || index > dimension) return E_INVALIDARG;

	*value = graphSet.front()->getMin()[index];
	return S_OK;
}

STDMETHODIMP CGraphInfoImpl::GetMaximum(int index, double* value) {
	if (graphSet.size() == 0) return E_FAIL;
	if (index < 0 || index > dimension) return E_INVALIDARG;

	*value = graphSet.front()->getMax()[index];
	return S_OK;
}

STDMETHODIMP CGraphInfoImpl::GetGridNumber(int index, int* value) {
	if (graphSet.size() == 0) return E_FAIL;
	if (index < 0 || index > dimension) return E_INVALIDARG;

	*value = graphSet.front()->getGrid()[index];

	return S_OK;
}

STDMETHODIMP CGraphInfoImpl::GetGridSize(int index, double* value) {
	if (graphSet.size() == 0) return E_FAIL;
	if (index < 0 || index > dimension) return E_INVALIDARG;
	*value = graphSet.front()->getEps()[index];
	return S_OK;
}

STDMETHODIMP CGraphInfoImpl::AddGraph(void** agraph) {
	Graph* graph = *(Graph**)agraph;
	graphSet.push_back(graph);
	this->dimension = graph->getDimention();
	return S_OK;
}
