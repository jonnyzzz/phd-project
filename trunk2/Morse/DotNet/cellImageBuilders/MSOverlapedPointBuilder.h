#pragma once
#include "SIOverlapedPointBuilder.h"


class ISystemFunctionDerivate;

class MSOverlapedPointBuilder :
	public SIOverlapedPointBuilder
{
public:
	MSOverlapedPointBuilder(Graph* graph, 
		                    int* factor, 
							int* ks, 
							JDouble* offset1, 
							JDouble* offset2, 
							ISystemFunctionDerivate* function, 
							ProgressBarInfo* info);
	virtual ~MSOverlapedPointBuilder(void);


protected:
	virtual void buildImage(Graph* graph, Node* source); 

private:
	int function_dimension;
	int v_offset;
	JDouble* value;
};
