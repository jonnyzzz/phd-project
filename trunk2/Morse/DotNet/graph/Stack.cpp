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

const int hashMax = 315691; //it probably is prime
const int hashBytes = 30;
const int hashLength = hashMax / hashBytes;

Stack::Stack(Graph* graph) : graph(graph)
{
	root = NULL;
	this->flagID = graph->registerFlag();
}

Stack::~Stack()
{
	while (root != NULL) {
		dataStack* s = root;
		root = root->next;
		delete s;
	}
}


////////////////////////////////////////////////////////////////////////

void Stack::push(Node* node) {
	dataStack* s = new dataStack;
	s->next = root;
	s->node = node;
	root = s;
	graph->setFlag(node, flagID, true);
}

Node* Stack::top() {
	if (root == NULL) return NULL;
	return root->node;
}

Node* Stack::pop() {
	if (root == NULL) return NULL;

	Node* tmp = root->node;
	dataStack* s = root;

	root = root->next;
	delete s;
	graph->setFlag(tmp, flagID, false);
	return tmp;
}


bool Stack::containsTest(Node* node) {
	
	dataStack* s = root;
	while ((s != NULL) && (s->node != node)) s=s->next;
	return (s!=NULL);
}

bool Stack::contains(Node* node) {
	if (graph->readFlag(node, flagID)) {
		ASSERT(containsTest(node));
		return true;
	} else {
		ASSERT(!containsTest(node));
		return false;
	}
	//return containsTest(node);
}