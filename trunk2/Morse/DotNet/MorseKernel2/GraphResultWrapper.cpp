#include "StdAfx.h"
#include ".\graphresultwrapper.h"
#include "resultSetImpl.h"
#include "graphResultImpl.h"
#include "../cellimagebuilders/abstractProcess.h"
#include "../cellImageBuilders/graphSet.h"


GraphResultGraphIterator::GraphResultGraphIterator(IResultSet* result) :
	resultSetIterator(result)	
{
	
}

GraphResultGraphIterator::~GraphResultGraphIterator() {
}


bool GraphResultGraphIterator::HasNext() {
	return resultSetIterator.HasNext();
}

Graph* GraphResultGraphIterator::Current() {
	IGraphResult* graphResult = resultSetIterator;

	Graph* graph;
	HRESULT hr = graphResult->GetGraph((void**)&graph);

	ATLASSERT(graph != NULL);
	ATLASSERT(SUCCEEDED(hr));

	return graph;
}

void GraphResultGraphIterator::Next() {
	resultSetIterator.Next();
}


Graph* GraphResultGraphIterator::operator ->() {
	return this->Current();
}

GraphResultGraphIterator::operator Graph *() {
	return Current();
}
//////////////////////////////////////////////////////////////////////////


GraphResultGraphList::GraphResultGraphList() {
	CResultSetImpl::CreateInstance(&resultSet);
	ATLASSERT(resultSet != NULL);
}

GraphResultGraphList::~GraphResultGraphList() {
	resultSet->Release();
}

void GraphResultGraphList::AddGraph(Graph* graph, bool isComponent) {
	IWritableGraphResult* result;
	CGraphResultImpl::CreateInstance(&result);

	HRESULT hr = result->SetGraph((void**)&graph, isComponent?TRUE:FALSE);
	ATLASSERT(SUCCEEDED(hr));

	IResultBase* resultBase;
	result->QueryInterface(&resultBase);
	ATLASSERT(resultBase != NULL);

	hr = resultSet->AddResult(resultBase);
	ATLASSERT(SUCCEEDED(hr));
	result->Release();
	resultBase->Release();
}

void GraphResultGraphList::AddGraphs(GraphSet& graphSet, bool isComponent) {
	for (GraphSetIterator it = graphSet.iterator(); it.HasNext(); it.Next()) {
		AddGraph(it, isComponent);
	}
}

IResultSet* GraphResultGraphList::GetResultSet() {
	IResultSet* result;
	resultSet->QueryInterface(&result);

	ATLASSERT(result != NULL);

	return result;
}