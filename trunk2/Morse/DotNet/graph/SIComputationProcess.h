// SIComputationProcess.h: interface for the SIComputationProcess class.
//
//////////////////////////////////////////////////////////////////////
#pragma once


struct Node;
class Graph;
class Function;

class SIComputationProcess  
{
public:
	SIComputationProcess(Function* function, Graph* graph, JInt* factor);
	virtual ~SIComputationProcess();

public:
	void nextStep(Graph* graph);
	Graph* getComputationResult();

private:
	Graph* createGraph();
	
	void buildNodeMultiplication(Node* node); //node from graph
	void buildNodeImage(Node* node); //node from dest

protected:
	int dimention;
	JInt* factor;

	JDouble* x;
	JDouble* x0;
	JDouble* min;
	JDouble* max;

	JInt* b;
	JInt* c;
	JInt* point;

	Graph* dest;
	Graph* graph;

	Function* function;
};
