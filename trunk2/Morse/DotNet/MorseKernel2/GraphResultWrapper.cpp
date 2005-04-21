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
	SmartInterface<IGraphResult> graphResult = resultSetIterator;

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


GraphResultGraphList::GraphResultGraphList(IResultMetadata* metadata) {
	CResultSetImpl::CreateInstance(resultSet.extract());
	ATLASSERT(resultSet != NULL);

	metadata->QueryInterface(this->metadata.extract());
	ATLASSERT(this->metadata != NULL);
}

GraphResultGraphList::~GraphResultGraphList() {
}

void GraphResultGraphList::AddGraph(Graph* graph, bool isComponent) {
	SmartInterface<IWritableGraphResult> result;
	CGraphResultImpl::CreateInstance(result.extract());

	HRESULT hr = result->SetGraph((void**)&graph, isComponent?VARIANT_TRUE:VARIANT_FALSE);
	ATLASSERT(SUCCEEDED(hr));

	hr = result->SetMetadata(metadata);
	ATLASSERT(SUCCEEDED(hr));

	SmartInterface<IResultBase> resultBase;
	result->QueryInterface(resultBase.extract());
	ATLASSERT(resultBase != NULL);

	hr = resultSet->AddResult(resultBase);
	ATLASSERT(SUCCEEDED(hr));
}

void GraphResultGraphList::AddGraphs(GraphSet& graphSet, bool isComponent) {
	for (GraphSetIterator it = graphSet.iterator(); it.HasNext(); it.Next()) {
		AddGraph(it, isComponent);
	}
}

void GraphResultGraphList::GetResultSet(IResultSet** resultSet) {
	this->resultSet->QueryInterface(resultSet);
	ATLASSERT(*resultSet != NULL);
}