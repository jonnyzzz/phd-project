#pragma once
#include "..\cellimagebuilders\abstractprocess.h"
#include "../SystemFunction/ISystemFunction.h"
#include "PointGraphProcessor.h"

class AdaptiveProcessBase :
    public AbstractProcess
{
public:
    AdaptiveProcessBase(ISystemFunction* function, Graph* graph, JInt* division, double* precision, ProgressBarInfo* info);
	virtual ~AdaptiveProcessBase(void);

public:
    virtual GraphSet results();
    virtual void processNextGraph(Graph* graph);

protected:
    void processNode(Graph* graph, Node* node);
    virtual void processResultNode(Node* node) = 0;
    
private:
    Graph* rootGraph;
    

protected:
    Graph* resultGraph;

    int* division;
    ISystemFunction* function;
    int dimension;
    double* precision;

private:
    JInt* x;
    JInt* b;    
};
