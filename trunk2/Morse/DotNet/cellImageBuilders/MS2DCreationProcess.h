#pragma once

#include "AbstractGraphCreator.h"

class MS2DCreationProcess : public AbstractGraphCreator
{
public:
	MS2DCreationProcess(Graph* graph, int* factor, ProgressBarInfo* info);
	virtual ~MS2DCreationProcess(void);

protected:
	virtual JDouble getMax(int i);
	virtual JDouble getMin(int i);
    virtual int getNewDimension();

};
