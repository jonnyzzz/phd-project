#pragma once
#include "abstractpointbuilder.h"

class Function;
class Graph;

class SIPointBuilder :
	public AbstractPointBuilder
{
public:
	SIPointBuilder(Graph* graph, int* factor, int* ks, Function* function, ProgressBarInfo* info = NULL);
	virtual ~SIPointBuilder(void);

protected:
	virtual void buildImage(Graph* coordinates, JInt* answer); 
	virtual JDouble* getFunctionX();	

protected:
	Function* function;
};
