#pragma once

class Graph;
class NodeMultiplicator;
struct NodeEnumerator;
struct Node;

class GraphMultiplicator
{
public:
	GraphMultiplicator(Graph* graph, int* factors);
	virtual ~GraphMultiplicator(void);

public:
	void setCoordinatePointer(JDouble* c);
	Node* currentNode();
	
	bool next();

private:
	Graph* graph;
	int dimension;
   
	Node* node;
	NodeEnumerator* nodeEnumerator;

	NodeMultiplicator* nodeMultiplicator;

	JDouble* x0;

private:
	void init();
	void init_center();

private:
	bool next_node();
	bool next_point();

};