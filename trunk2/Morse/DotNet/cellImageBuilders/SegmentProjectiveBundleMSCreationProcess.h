#pragma once
#include "abstractgraphcreator.h"

class SegmentProjectiveBundleMSCreationProcess :
    public AbstractGraphCreator
{
public:
    SegmentProjectiveBundleMSCreationProcess(Graph* graph, int* factor);
    virtual ~SegmentProjectiveBundleMSCreationProcess(void);

public:
    virtual double getMax(int i);
    virtual double getMin(int i);
    virtual int getNewDimension();
};
