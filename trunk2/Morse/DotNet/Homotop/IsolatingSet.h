#pragma once

#include "../cellImageBuilders/AbstractProcessExt.h"
#include <list>
using namespace std;


class IsolatingSetProcess : public AbstractProcessExt
{
public:
	IsolatingSetProcess(Graph* graphSource, Graph* startGraph, ProgressBarInfo* info);
	virtual ~IsolatingSetProcess(void);

public:
	virtual void processNextGraph(Graph* graph);
	virtual void start(void);

private:
	Graph* startGraph;

private:
	typedef list<Node*> NodeList;

private:
	bool processTaskList(NodeList* lst, Graph* graph);
	bool processNode(Node* node, NodeList* lst, Graph* graph);
};
