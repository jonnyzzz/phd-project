// Stack.h: interface for the Stack class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_STACK_H__9AD856CD_279E_4297_B688_8C24CAA29BC1__INCLUDED_)
#define AFX_STACK_H__9AD856CD_279E_4297_B688_8C24CAA29BC1__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

struct Node;

class Stack  
{
public:
	Stack(Graph* graph);
	virtual ~Stack();

public:
	void push(Node*);
	Node* pop();
	Node* top();

	bool contains(Node*);

private:
	struct dataStack {
		Node* node;
		dataStack* next;
	};

	dataStack* root;
    Graph* graph;
};

#endif // !defined(AFX_STACK_H__9AD856CD_279E_4297_B688_8C24CAA29BC1__INCLUDED_)
