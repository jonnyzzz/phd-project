#pragma once

class MeaGraph;
class Graph;
struct Node;
class MeaNode;

#include "MeaNode.h"


class IsolatingSetProcess : public AbstractProcess
{
public:
	IsolatingSetProcess(Graph* graphSource, Node* startNode);
	virtual ~IsolatingSetProcess(void);

public:
	virtual void processNextGraph(Graph* graph);
	virtual void start(void);

private:
	Node* myStartNode;
	MeaNodeSet runProcess(MeaNode& startNode);
	void importData(MeaNodeSet from, Graph* into);
};
