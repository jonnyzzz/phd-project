#pragma once

class Graph;
struct Node;


class MS2CreationComputationProcess
{
public:
	MS2CreationComputationProcess(Graph* graph, int factorSI, int factorMS);
	
	virtual ~MS2CreationComputationProcess(void);

public:
	Graph* getResult();
	void nextStep(Graph* graph);

private:
	Graph* result;
	Graph* parent;
	Graph* graph;
	JInt* point;
	JInt* b;

	int factorMS;
	int factorSI;

	int dimension;
	int newDimension;

private:
	Graph* createGraph();
	int Factor(int i);

	void buildNodeMultiplication(Node* node);

	

};
