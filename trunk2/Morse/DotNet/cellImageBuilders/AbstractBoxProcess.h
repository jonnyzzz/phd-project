#pragma once
#include "abstractprocessExt.h"
#include "../systemfunction/systemfunction.h"

class AbstractBoxProcess :
	public AbstractProcessExt
{
public:
	AbstractBoxProcess(Graph* graph, ISystemFunction* function, int* factor, ProgressBarInfo* pinfo);
	virtual ~AbstractBoxProcess(void);


public:
	virtual void processNextGraph(Graph* graph);
	virtual void start();

protected:
	virtual void processNodeAndImage(JDouble* value_min, JDouble* value_max, Node* node, Graph* graph_result) = 0;


protected:
	Graph* createGraph();


	void multiplyNode(Node* original, Graph* graph);
	void processNode(Node* node, Graph* graph_result);

	void vectorCopy(JDouble* from, JDouble* to);

protected:
	int dimension;
	int dimension2;

	ISystemFunction* function;
	JDouble* input;
	JDouble* output;


private:
	bool hasDerivate;

	JDouble* v0;

private:
	void setApproximationCenter();
	void evaluate();



private:
	JDouble* eps2;
	JDouble* x0;
	JInt* b;
	JInt* a;
	JInt* point;
	JInt* pointT;

	JDouble* value_min;
	JDouble* value_max;

	int* factor;
};
