#pragma once

#include "../cellImageBuilders/AbstractProcessExt.h"


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
	void processTaskList(NodeList& lst, Graph* graph);
	void processNode(Node* node, NodeList& lst, Graph* graph);
};
