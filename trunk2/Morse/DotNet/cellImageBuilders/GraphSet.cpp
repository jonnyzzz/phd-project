#include "stdafx.h"
#include "GraphSet.h"
#include "../graph/Graph.h"
#include "../graph/GraphComponents.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


GraphSet::GraphSet() {
}

GraphSet::GraphSet(GraphComponents* cms) {
	copyFrom(cms);
}

GraphSet::GraphSet(Graph* graph) {
	graphList.push_back(graph);
}

GraphSet::GraphSet(const GraphSet& graphSet) {
	this->graphList.clear();
	copyFrom(graphSet);
}

GraphSet::~GraphSet() {

}


int GraphSet::Length() {
	return (int)graphList.size();
}

Graph* GraphSet::operator [](int index) {
	GraphList::iterator it;
	for (it = graphList.begin(); index>0; index--) it++;

	ATLASSERT(it != graphList.end());

	return *it;
}


void GraphSet::AddGraph(Graph* graph) {
	graphList.push_back(graph);
}

void GraphSet::AddGraph(GraphComponents* cms) {
	copyFrom(cms);
}

void GraphSet::AddGraph(const GraphSet& graphSet) {
	copyFrom(graphSet);
}

void GraphSet::copyFrom(const GraphSet& graphSet) {
	for (GraphList::const_iterator it = graphSet.graphList.begin(); it != graphSet.graphList.end(); it++) {
		graphList.push_back(*it);
	}
}

void GraphSet::DeleteGraphs() {
	for (GraphList::const_iterator it = graphList.begin(); it != graphList.end(); it++) {
		delete *it;
	}
	graphList.clear();
}

void GraphSet::Clear() {
	graphList.clear();
}

void GraphSet::copyFrom(GraphComponents* cms) {
	for (int i=0; i<cms->length(); i++) {
		graphList.push_back(cms->getAt(i));
	}
}


GraphSet& GraphSet::operator =(const GraphSet& graphSet) {
	this->graphList.clear();
	copyFrom(graphSet);

	return *this;
}

GraphSetIterator GraphSet::iterator() {
	return GraphSetIterator(*this);
}


///////////////////////////////////////////////////////////////

GraphSetIterator::GraphSetIterator(const GraphSet& graphSet) : 
	graphSet(graphSet), index(0) 
{

}

bool GraphSetIterator::HasNext() {
	return index < graphSet.Length();
}

Graph* GraphSetIterator::Current() {
	return graphSet[index];
}

Graph* GraphSetIterator::operator ->() {
	return Current();
}

GraphSetIterator::operator Graph *() {
	return Current();
}

void GraphSetIterator::Next() {
	index++;
}
