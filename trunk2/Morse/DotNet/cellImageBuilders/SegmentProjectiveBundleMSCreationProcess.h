#pragma once
#include "AbstractGraphCreator.h"

class SegmentProjectiveBundleMSCreationProcess :
    public AbstractGraphCreator
{
public:
    SegmentProjectiveBundleMSCreationProcess(Graph* graph, int* factor, ProgressBarInfo* info);
    virtual ~SegmentProjectiveBundleMSCreationProcess(void);

public:
    virtual double getMax(int i);
    virtual double getMin(int i);
    virtual int getNewDimension();
};
