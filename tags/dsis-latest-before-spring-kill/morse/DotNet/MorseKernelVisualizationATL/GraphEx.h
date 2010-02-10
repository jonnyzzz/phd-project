#pragma once

#include <list>
using namespace std;


#include <hash_map>
using namespace stdext;




class GraphEx
{
public:
	GraphEx(Graph* graph);
	virtual ~GraphEx(void);

public:
	Graph* getGraph();

public:
	struct NodeInfo {
		int minLoopLength;

		NodeInfo();
	};

public:
	NodeInfo* operator[] (Node* node);
	operator Graph*();


private:
	typedef hash_map<Node*, NodeInfo*> NodeInfos;

	NodeInfos nodeMap;
	NodeInfo* nodesInfo;
	NodeInfo* newNodeInfo;

	Graph* graph;

private:
	void parseGraph();

private:

	typedef list<Node*> WideSearchQueue;


	void analizeQueue(Graph* graph, Node* node);

	NodeInfo* getNode(Node* node);

};
