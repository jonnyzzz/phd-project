#pragma once
#include "AbstractPointBuilder.h"

class Function;
class Graph;
struct Node;
class ProgressBarInfo;
class ISystemFunction;

class SIPointBuilder :
	public AbstractPointBuilder
{
public:
	SIPointBuilder(Graph* graph, int* factor, int* ks, ISystemFunction* function, ProgressBarInfo* info);
	virtual ~SIPointBuilder(void);

protected:
	virtual void buildImage(Graph* coordinates, Node* source); 
	virtual JDouble* getFunctionX();	

	void addEdge(Graph* graph, Node* source, JInt* to);

protected:
    ISystemFunction* function;

    double* input;
    double* output;

	JInt* point;
};
