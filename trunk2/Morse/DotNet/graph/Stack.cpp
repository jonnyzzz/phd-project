// Stack.cpp: implementation of the Stack class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Graph.h"
#include "Stack.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

Stack::Stack(Graph* graph) : graph(graph), MemoryManager(sizeof(Stack::dataStack)*195232)
{
	root = NULL;
	this->flagID = graph->registerFlag();
}

Stack::~Stack()
{
	/*
	while (root != NULL) {
		dataStack* s = root;
		root = root->next;
		delete s;
	}
	*/
}


////////////////////////////////////////////////////////////////////////

void Stack::push(TarjanNode* node) {
	dataStack* s = Allocate<dataStack>();//new dataStack;
	s->next = root;
	s->node = node;
	root = s;
	graph->setFlag((Node*)node, flagID, true);
}

TarjanNode* Stack::top() {
	if (root == NULL) return NULL;
	return root->node;
}

TarjanNode* Stack::pop() {
	if (root == NULL) return NULL;

	TarjanNode* tmp = root->node;
	dataStack* s = root;

	root = root->next;
	//delete s;
	graph->setFlag((Node*)tmp, flagID, false);
	return tmp;
}


bool Stack::containsTest(TarjanNode* node) {
	
	dataStack* s = root;
	while ((s != NULL) && (s->node != node)) s=s->next;
	return (s!=NULL);
}

bool Stack::contains(TarjanNode* node) {
	if (graph->readFlag((Node*)node, flagID)) {
		//ASSERT(containsTest(node));
		return true;
	} else {
		//ASSERT(!containsTest(node));
		return false;
	}
	//return containsTest(node);
}
