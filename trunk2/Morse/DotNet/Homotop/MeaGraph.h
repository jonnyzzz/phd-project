#pragma once

#include "meanode.h"

class MeaGraph
{
public:
	MeaGraph(void);

	virtual int getNodeCount() const =0;
	virtual MeaNode& addNode() = 0;
	virtual	MeaNode* findNode(Node* hisNode) =0;
	virtual MeaNode* begetNode(Node* hisNode)=0;
	~MeaGraph(void);
};
