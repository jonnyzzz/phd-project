#pragma once

class Graph;
struct Node;

#include <list>
using namespace std;

class MinimalLoopFinder
{
public:
	MinimalLoopFinder();
	~MinimalLoopFinder();

private:
	struct NodeEx {
		Node* node;
		NodeEx* parent;
	};
	
private:
	int graphUsedFlag;

private:
	typedef list<NodeEx*> NodeExList;
	typedef list<NodeEx*> NodeExs;

private:
	NodeExs heap;
	NodeEx* current;
	NodeEx* last;

private:
	NodeEx* newNodeEx(Node* node, NodeEx* parent);
	void InitHeap();
	void DisposeHeap();

private:
	bool nextStep(NodeExList& in, NodeExList& out, Node* root, Graph* graph);

public:
	Graph* FindMinimalLoop(Graph* graph, Node* node);

};
