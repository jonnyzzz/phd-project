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

STDMETHODIMP CGraphResultImpl::GetResultMerger(IResultMerger** merger) {
	CGraphResultImpl::CreateInstance(merger);

	ATLASSERT(*merger != NULL);

	return S_OK;
}


STDMETHODIMP CGraphResultImpl::GetGraph(int index, void** graph) {
	for (Graphs::iterator it = graphs.begin(); 
		index > 0 && it != graphs.end(); index--, ++it);

	if (it != graphs.end()) {
		*graph = (void*)it->first;
		return S_OK;
	} else {
		*graph = NULL;
		return E_INVALIDARG;
	}
}


STDMETHODIMP CGraphResultImpl::GetCount(int* count) {
	*count = (int)graphs.size();
	return S_OK;
}

STDMETHODIMP CGraphResultImpl::GetGraphInfo(IGraphInfo** info) {
	IWritableGraphInfo* pinfo;
	CGraphInfoImpl::CreateInstance(&pinfo);

	ATLASSERT(pinfo != NULL);
	
	HRESULT hr;
	for (Graphs::iterator it = graphs.begin(); it != graphs.end(); it++) {
		hr = pinfo->AddGraph((void**)&it->first);
		
		ATLASSERT( SUCCEEDED(hr) );
		
		if (FAILED(hr)) break;
	}

	if (FAILED(hr)) {
		*info = NULL;
		pinfo->Release();
		return hr;
	} else {
		pinfo->QueryInterface(info);

		ATLASSERT(*info != NULL);

		return S_OK;
	}
}

STDMETHODIMP CGraphResultImpl::GetGraphInfoAt(int index, IGraphInfo** info) {
	void* graph;
	HRESULT hr = GetGraph(index, &graph);

	ATLASSERT( SUCCEEDED(hr) );

	if (FAILED(hr)) {
		return hr;
	} else {
		IWritableGraphInfo* pinfo;
		CGraphInfoImpl::CreateInstance(&pinfo);

		ATLASSERT(pinfo != NULL);

		hr = pinfo->AddGraph(&graph);
		
		ATLASSERT( SUCCEEDED(hr) );
        
		if (FAILED(hr)) {
			pinfo->Release();
			return hr;
		} else {
			pinfo->QueryInterface(info);

			ATLASSERT(*info != NULL);

			return S_OK;
		}
	}
}

STDMETHODIMP CGraphResultImpl::IsStrongComponent(VARIANT_BOOL* value) {
	if (graphs.size() == 0) return E_FAIL;

	for (Graphs::iterator it = graphs.begin(); it != graphs.end(); it++) {
		if (!it->second) {
			*value = FALSE;
			return S_OK;
		}
	}
	*value = TRUE;
	return S_OK;
}


STDMETHODIMP CGraphResultImpl::AddGraph(void** graph, VARIANT_BOOL isStrongComponent) {
	graphs.push_back(Item(*(Graph**)graph, (isStrongComponent==TRUE) ));
	return S_OK;
}


STDMETHODIMP CGraphResultImpl::AddResult(IResultBase* result) {

	VARIANT_BOOL res;
	CanAddResult(result, &res);

	if (!res) return E_INVALIDARG;

	IGraphResult* graphResult;
	result->QueryInterface(&graphResult);

	if (graphResult != NULL) {
		int count;
		VARIANT_BOOL comp;
		graphResult->GetCount(&count);
		graphResult->IsStrongComponent(&comp);

		for (int i=0; i<count; i++) {
			void* graph;
			graphResult->GetGraph(i, &graph);
			this->AddGraph(&graph, comp);
		}
		graphResult->Release();
		return S_OK;
	} else {
		return E_INVALIDARG;
	}
}

STDMETHODIMP CGraphResultImpl::CanAddResult(IResultBase* result, VARIANT_BOOL* value) {
	IGraphResult* graphResult;
	result->QueryInterface(&graphResult);

	bool answer = true;

	if (graphResult != NULL) {
		int count;
		graphResult->GetCount(&count);
		for (int i=0; i<count; i++) {
			Graph* graph;
			graphResult->GetGraph(i, (void**)&graph);
			if (!GraphAcceptConstraint(graph)) {
				answer = false;
				break;
			}
		}

		*value = (answer)?TRUE:FALSE;
		graphResult->Release();
	} else {
		*value = FALSE;
	}

	return S_OK;
}

STDMETHODIMP CGraphResultImpl::CreateResult(IResultBase** result) {
	((IResult*)this)->QueryInterface(result);
	ATLASSERT(result != NULL);
	return S_OK;
}


///////////////////////////////////////////////////////////////////////

bool CGraphResultImpl::GraphAcceptConstraint(Graph* graph) {

	for (Graphs::iterator it = graphs.begin(); it != graphs.end(); it++) {
		bool b = GraphAcceptConstraint(it->first, graph);
		if (!b) return false;
	}
	
	return true;
}

bool CGraphResultImpl::GraphAcceptConstraint(Graph* graph1, Graph* graph2) {
	if (graph1->getDimention() != graph2->getDimention()) return false;

	int dimension = graph1->getDimention();

	for (int i=0; i<dimension; i++) {
		if (graph1->getEps()[i] != graph2->getEps()[i] ||
			graph1->getGrid()[i] != graph2->getGrid()[i] ||
			graph1->getMin()[i] != graph2->getMin()[i] ||
			graph1->getMax()[i] != graph2->getMax()[i]
			) return false;
	}
	return true;
}