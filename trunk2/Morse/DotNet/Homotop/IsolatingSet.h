#pragma once

class MeaGraph;
class Graph;
struct Node;
class MeaNode;
class ProgressBarInfo;

#include "MeaNode.h"


class IsolatingSetProcess : public AbstractProcess
{
public:
	IsolatingSetProcess(Graph* graphSource, Node* startNode, ProgressBarInfo* info);
	virtual ~IsolatingSetProcess(void);

public:
	virtual void processNextGraph(Graph* graph);
	virtual void start(void);

private:
	Node* myStartNode;
	MeaNodeSet runProcess(MeaNode& startNode);
	void importData(MeaNodeSet from, Graph* into);
};
