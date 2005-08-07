#pragma once
#include "..\cellimagebuilders\abstractprocess.h"
#include "../SystemFunction/ISystemFunction.h"
#include "PointGraphProcessor.h"

class AdaptiveProvess :
	public AbstractProcess
{
public:
    AdaptiveProvess(ISystemFunction* function, Graph* graph, JInt* division, double precision, ProgressBarInfo* info);
	virtual ~AdaptiveProvess(void);

public:
    virtual GraphSet results();
    virtual void processNextGraph(Graph* graph);


protected:
    void processNode(Graph* graph, Node* node);
    void processResultNode(Node* node);
    
private:
    Graph* rootGraph;
    Graph* resultGraph;

    int* division;
    ISystemFunction* function;
    int dimension;

private:
    JInt* x;
    JInt* b;

    PointGraphProcessor* processor;
};
