#pragma once
#include "abstractgraphcreator.h"

class MSAngleCreationProcess :
	public AbstractGraphCreator
{
public:
	MSAngleCreationProcess(Graph* base, int* factor, ProgressBarInfo* info);;
	virtual ~MSAngleCreationProcess(void);

protected:
	virtual JDouble getMin(int i);
	virtual JDouble getMax(int i);
    virtual int getNewDimension();

};
