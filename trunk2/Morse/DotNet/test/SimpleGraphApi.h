#pragma once

class Graph;
struct Node;

class SimpleGraphApi
{
public:
	SimpleGraphApi(void);
	~SimpleGraphApi(void);

private:
	Graph* graph;

public:

	void reset();

	Graph* getGraph();
	Node* to(int id);
	void to(int i1, int i2);
	void to(Node* n1, Node* n2);


};
