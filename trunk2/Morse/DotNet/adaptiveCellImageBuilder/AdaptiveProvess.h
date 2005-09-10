#pragma once
#include "..\cellimagebuilders\abstractprocess.h"
#include "../SystemFunction/ISystemFunction.h"
#include "PointGraphProcessor.h"
#include "AdaptiveProcessBase.h"

class AdaptiveProvess :
    public AdaptiveProcessBase
{
public:
    AdaptiveProvess(ISystemFunction* function, Graph* graph, JInt* division, double* precision, ProgressBarInfo* info);
	virtual ~AdaptiveProvess(void);

protected:
    virtual void processResultNode(Node* node);

private:
    PointGraphProcessor* processor;
};