#pragma once
#include "abstractpointbuilder.h"

class Function;
class Graph;

class SIPointBuilder :
	public AbstractPointBuilder
{
public:
	SIPointBuilder(Graph* graph, int* factor, int* ks, ISystemFunction* function, ProgressBarInfo* info = NULL);
	virtual ~SIPointBuilder(void);

protected:
	virtual void buildImage(Graph* coordinates, JInt* answer); 
	virtual JDouble* getFunctionX();	

protected:
    ISystemFunction* function;

    double* input;
    double* output;
};
