// Stack.h: interface for the Stack class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_STACK_H__9AD856CD_279E_4297_B688_8C24CAA29BC1__INCLUDED_)
#define AFX_STACK_H__9AD856CD_279E_4297_B688_8C24CAA29BC1__INCLUDED_

#if _MSC_VER > 1000
#pragma once     
#endif // _MSC_VER > 1000

struct TarjanNode;

#include "MemoryManager.h"

class Stack  : private MemoryManager
{
public:
	Stack(Graph* graph);
	virtual ~Stack();

public:
	void push(TarjanNode*);
	TarjanNode* pop();
	TarjanNode* top();

	bool contains(TarjanNode*);

private:
	bool containsTest(TarjanNode*);

private:
	struct dataStack {
		TarjanNode* node;
		dataStack* next;
	};

	dataStack* root;
    Graph* graph;

	int flagID;
};

#endif // !defined(AFX_STACK_H__9AD856CD_279E_4297_B688_8C24CAA29BC1__INCLUDED_)
