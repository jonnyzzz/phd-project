#pragma once
#include "abstractgraphcreator.h"

class MSNormedCreationProcess :
	public AbstractGraphCreator
{
public:
	MSNormedCreationProcess(Graph* base, int* factor, ProgressBarInfo* info);
	virtual ~MSNormedCreationProcess(void);

protected:
	virtual JDouble getMin(int i);
	virtual JDouble getMax(int i);
    virtual int getNewDimension();
};
