// Stack.cpp: implementation of the Stack class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Stack.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

Stack::Stack()
{
	root = NULL;
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
	return tmp;
}


bool Stack::contains(Node* node) {
	dataStack* s = root;
	while ((s != NULL) && (s->node != node)) s=s->next;
	return s!=NULL;
}
