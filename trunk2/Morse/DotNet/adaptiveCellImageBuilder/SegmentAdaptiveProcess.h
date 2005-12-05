#pragma once
#include "AdaptiveProcessBase.h"
#include "../SystemFunction/SegmentProjectiveExtendedSystemFunction.h"
#include "SegmentPointGraphProcessor.h"
#include "PointGraph.h"


class SegmentAdaptiveProcess :
	public AdaptiveProcessBase
{
public:
	SegmentAdaptiveProcess(SegmentProjectiveExtendedSystemFunction* function, Graph* graph, JInt* division, double* precision, size_t upperLimit, ProgressBarInfo* info);
	virtual ~SegmentAdaptiveProcess(void);

protected:
    virtual void processResultNode(Node* node);

private:
	SegmentPointGraphProcessor* processor;
};
