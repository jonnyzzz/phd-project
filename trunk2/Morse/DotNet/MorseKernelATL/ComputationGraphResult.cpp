// ComputationGraphResult.cpp : Implementation of CComputationGraphResult

#include "stdafx.h"
#include "kernel.h"
#include "ComputationGraphResult.h"


// CComputationGraphResult

CComputationGraphResult::CComputationGraphResult() {
	this->graph = NULL;
	this->node = NULL;
}

HRESULT CComputationGraphResult::FinalConstruct() {
	return S_OK;
}

void CComputationGraphResult::FinalRelease() {
	SAFE_DELETE(graph);
	SAFE_RELEASE(node);
}

STDMETHODIMP CComputationGraphResult::StrongComponents() {
	GraphComponents* cms = graph->localazeStrongComponents();
    
	node->acceptChilds((void**)&cms); //note: cms should be deleted by node object
	
	return S_OK;
}

STDMETHODIMP CComputationGraphResult::StrongComponentsEdges() {
	GraphComponents* cms = graph->localazeStrongComponents();
	for (int i=0; i<cms->length(); i++) {
		Graph* tmp = cms->getAt(i);
		tmp->resolveEdges(graph);
	}
	
	node->acceptChilds((void**)&cms); //note: cms should be deleted by node object

	return S_OK;
}

STDMETHODIMP CComputationGraphResult::Loops() {
	GraphComponents* cms = new GraphComponents();
	cms->addGraphAsComponent(graph->localizeLoops());

	node->acceptChilds((void**)&cms);

	return S_OK;
}

STDMETHODIMP CComputationGraphResult::setRootGraph(void ** agraph) {
	cout<<"Setting graph\n";
	Graph* graph = *(Graph**)agraph;
	
	SAFE_DELETE(this->graph);

	this->graph = graph;
	return S_OK;
}

STDMETHODIMP CComputationGraphResult::setGraphNode(IGraph* graphNode) {
	
    SAFE_RELEASE(this->node);

	graphNode->QueryInterface(&this->node);

	ATLASSERT(this->node != NULL);
	
	return S_OK;
}