#pragma once
#include "abstractpointbuilder.h"

class SIOverlapedPointBuilder :
	public AbstractPointBuilder
{
public:
	//offsets in percent
	SIOverlapedPointBuilder(Graph* graph, 
		                    int* factor, 
							int* ks, 
							JDouble* offset1, 
							JDouble* offset2, 
							ISystemFunction* function, 
							ProgressBarInfo* info);
	virtual ~SIOverlapedPointBuilder(void);

protected:
	virtual void buildImage(Graph* graph, Node* source); 
	virtual JDouble* getFunctionX();

private:
	JDouble* offset1;
	JDouble* offset2;

	JDouble* output;

	ISystemFunction* function;
};
