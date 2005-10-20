#ifndef _CELLIMAGEBUILDERS_ABSTRACTBOXPROCESS_H
#define _CELLIMAGEBUILDERS_ABSTRACTBOXPROCESS_H

#include "AbstractProcessExt.h"
#include "../SystemFunction/ISystemFunction.h"

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

	void vectorCopy(const JDouble* from, JDouble* to);

protected:
	const int dimension;
	const int dimension2;
	const int graphDimension;

	ISystemFunction* function;
	JDouble* input;
	JDouble* output;


private:
	const bool hasDerivate;

	JDouble* v0;
	JDouble* vx0;

protected:
	void setApproximationCenter();
	void evaluate();

protected:
	const double* getCurrentCenterValue();
	const double* getCurrentCenterPoint();


private:
	JDouble* eps2;
	JDouble* eps;
	JDouble* x0;
	JInt* b;
	JInt* a;
	JInt* point;
	JInt* pointT;

	JDouble* value_min;
	JDouble* value_max;

	int* factor;
};

#endif //_CELLIMAGEBUILDERS_ABSTRACTBOXPROCESS_H

