#pragma once
#include "meagraph.h"
#include "stdafx.h"
#include <vector> 
class MeaGraphImpl :
	public MeaGraph
{
public:
	MeaGraphImpl(void);
	MeaGraphImpl(Graph* graph);
	~MeaGraphImpl(void);

public:
	virtual int getNodeCount() const;
	virtual MeaNode& addNode();
	MeaNode* findNode(Node* hisNode);
	virtual MeaNode* begetNode(Node* hisNode);
private:
	Graph* myGraph;
	int myNodeCounter;
	vector<MeaNode*> myNodes;
	bool isExternalGraph;

	MeaNode* wrapNode(Node* hisNode); 

};
