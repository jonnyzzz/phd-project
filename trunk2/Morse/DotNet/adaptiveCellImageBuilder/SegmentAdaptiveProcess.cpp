#include "stdafx.h"
#include "..\graph\graphUtil.h"
#include "SegmentAdaptiveProcess.h"
#include "SegmentPointGraph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SegmentAdaptiveProcess::SegmentAdaptiveProcess(SegmentProjectiveExtendedSystemFunction* function, Graph* graph, JInt* division, double* precision, size_t upperLimit, ProgressBarInfo* info)
: AdaptiveProcessBase(function, graph, division, precision, info)
{	
	processor = new SegmentPointGraphProcessor(this->resultGraph, function, graph->getDimention(), precision, upperLimit);
}

SegmentAdaptiveProcess::~SegmentAdaptiveProcess(void)
{
	delete processor;
}

void SegmentAdaptiveProcess::processResultNode(Node* node) {    
    processor->ProcessNode(node);
}
