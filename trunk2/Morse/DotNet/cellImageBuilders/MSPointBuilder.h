#pragma once

#include "sipointbuilder.h"
#include "../systemFunction/ISystemFunctionDerivate.h"
#include "ProgressBarInfo.h"


class MSPointBuilder :  public SIPointBuilder
{
   
public:
	MSPointBuilder(Graph* graph, int* factor, int* ks, ISystemFunctionDerivate* function, ProgressBarInfo* info);
	virtual ~MSPointBuilder(void);

protected:
	virtual void buildImage(Graph* coordinates, JInt* answer);	

private:
    double* output;
	int function_dimension;
	int v_offset;
};
