#include "StdAfx.h"
#include ".\graphresultwrapper.h"
#include "../cellimagebuilders/abstractProcess.h"

GraphResultGraphIterator::GraphResultGraphIterator(IGraphResult* result) {
	result->QueryInterface(&this->result);

	ATLASSERT(this->result != NULL);
	
	index = 0;
}

GraphResultGraphIterator::~GraphResultGraphIterator() {
	result->Release();
}


bool GraphResultGraphIterator::hasNext() {
	int last;
	result->GetCount(&last);

	return (index < last);
}

Graph* GraphResultGraphIterator::Current() {

	ATLASSERT(hasNext());

	HRESULT hr;
	Graph* graph;
	hr = result->GetGraph(index, (void**)&graph);

	ATLASSERT(SUCCEEDED(hr));
	ATLASSERT(graph != NULL);

	return graph;
}

void GraphResultGraphIterator::Next() {
	ATLASSERT(hasNext());

	index++;
}


Graph* GraphResultGraphIterator::operator ->() {
	return this->Current();
}

GraphResultGraphIterator::operator Graph *() {
	return Current();
}
//////////////////////////////////////////////////////////////////////////


GraphResultGraphList::GraphResultGraphList(IWritableGraphResult* result) {
	result->QueryInterface(&this->result);
	ATLASSERT(this->result != NULL);
}

GraphResultGraphList::~GraphResultGraphList() {
	result->Release();
}

void GraphResultGraphList::AddGraph(Graph* graph, bool isComponent) {
	HRESULT hr = result->AddGraph((void**)&graph, isComponent?TRUE:FALSE);

	ATLASSERT(SUCCEEDED(hr));

}


///////////////////////////////////////////////////////////////////////////


void GraphResultUtil::PerformProcess(AbstractProcess* process, IGraphResult* input, IWritableGraphResult* output, bool isStrongComponent) {
	process->start();

	for (GraphResultGraphIterator it(input); it.hasNext(); it.Next()) {
		process->processNextGraph(it);
	}

	GraphResultGraphList lst(output);
	lst.AddGraph(process->result(), isStrongComponent);
}