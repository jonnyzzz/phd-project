// GraphComponents.cpp: implementation of the GraphComponents class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "GraphComponents.h"
#include "GraphException.h"
#include "Graph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

GraphComponents::GraphComponents()
{
	root = NULL;
	count = 0;
}

GraphComponents::~GraphComponents()
{
	while (root != NULL) {
		dataS* t = root;
		root = root->next;
		delete t;
	}
}


///////////////////////////////////////////////////////////////////////


void GraphComponents::addGraphAsComponent(Graph* graph) {
	dataS* s = new dataS;
	s->graph = graph;
	s->index = count++;
	s->next = root;
	root = s;
}

int GraphComponents::length() {
	return count;
}

Graph* GraphComponents::getAt(int i) {
	dataS* s = root;
	while (s != NULL && s->index != i) s=s->next;

	if (s == NULL) throw GraphException(GraphException_NoSuchResult);
	
	return (s==NULL)?NULL:s->graph;
}

///////////////////////////////////////////////////////

int GraphComponents::getDimension() {
	if (this->length() == 0) return 0;
	return this->getAt(0)->getDimention();
}

