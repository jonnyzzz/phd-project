#pragma once

class Function;
class Graph;
struct Node;

class MS2ComputationProcess
{
public:
	MS2ComputationProcess(Function* function, Graph* graph, JInt* factor);	
	virtual ~MS2ComputationProcess(void);

public:
	void nextStep(Graph* graph);
	Graph* getResult();

private:
	Graph* parent;
	Graph* result;
	Graph* graph;

	Function* function;

	JInt* factor;

private:
	JDouble* x;
	JDouble* v;
	JDouble* x0;
	JDouble* min;
	JDouble* max;

	JInt* b;
	JInt* c;
	JInt* point;

	int fDimension;
	int dimension;

private:
	Graph* createGraph();

	int Factor(int i);

	JDouble tR(); //atan2(Df(x)v)

	void buildNodeMultiplication(Node* node);
	void buildNodeImage(Node* node);	

private:
	JDouble Abs(JDouble x);
};
