#pragma once

#include "sipointbuilder.h"
#include "../systemFunction/ISystemFunctionDerivate.h"


class MSPointBuilder :  public SIPointBuilder
{
   
public:
	MSPointBuilder(Graph* graph, int* factor, int* ks, ISystemFunctionDerivate* function);
	virtual ~MSPointBuilder(void);

protected:
	virtual void buildImage(Graph* coordinates, JInt* answer);	

private:
    double* output;
};
