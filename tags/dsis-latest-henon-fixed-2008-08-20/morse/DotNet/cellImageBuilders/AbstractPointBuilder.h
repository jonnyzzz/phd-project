#ifndef _CELLIMAGEBUILDERS_ABSTRACTPOINTBUILDER_H
#define _CELLIMAGEBUILDERS_ABSTRACTPOINTBUILDER_H

struct Node;
class Graph;
class Function;

#include "AbstractProcessExt.h"

class AbstractPointBuilder : public AbstractProcessExt
{
public:
	AbstractPointBuilder(Graph* graph, int* factor, int* ks, ProgressBarInfo* info);
	virtual ~AbstractPointBuilder();

public:
	virtual void start();
	virtual void processNextGraph(Graph* graph);	

//suxy design, but low implementation cost. Hope it will work quick.
protected:
	
	virtual void buildImage(Graph* graph, Node* source) = 0; 	
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

#endif //_CELLIMAGEBUILDERS_ABSTRACTPOINTBUILDER_H
