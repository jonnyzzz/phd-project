#pragma once
struct Node;
class Graph;
class Function;

#include "AbstractProcess.h"

class AbstractPointBuilder : public AbstractProcess
{
public:
	AbstractPointBuilder(Graph* graph, int* factor, int* ks, ProgressBarInfo* info = NULL);
	virtual ~AbstractPointBuilder();

public:
	virtual void start();
	virtual void processNextGraph(Graph* graph);	

//suxy design, but low implementation cost. Hope it will work quick.
protected:
	
	virtual void buildImage(Graph* coordinates, JInt* answer) = 0; 
	virtual JDouble* getFunctionX() = 0;


private:
	int* factor;
	int* ks;

	JDouble* x0;
	JDouble* min;
	JDouble* max;
	JDouble* eps;

	JInt* b;
	JInt* c;
	JInt* point;
	JInt* tpoint;

	Graph* graph;

protected:
	int dimension;
	JDouble* x;

private:
	Graph* createGraph();
	
	void buildNodeMultiplication(Node* node); //node from graph
	void buildNodeImage(Node* node); //node from dest
};
