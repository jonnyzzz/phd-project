#include "stdafx.h"
#include "..\graph\graphUtil.h"
#include "SegmentAdaptiveProcess.h"
#include "SegmentPointGraph.h"

SegmentAdaptiveProcess::SegmentAdaptiveProcess(SegmentProjectiveExtendedSystemFunction* function, Graph* graph, JInt* division, double* precision, size_t upperLimit, ProgressBarInfo* info)
: AdaptiveProcessBase(function, graph, division, precision, info)
{
	pointGraph = new SegmentPointGraph(graph, function, graph->getDimention(), upperLimit);
	processor = new PointGraphProcessor(pointGraph, graph, function, graph->getDimention(), precision, upperLimit);
}

SegmentAdaptiveProcess::~SegmentAdaptiveProcess(void)
{
	delete pointGraph;
	delete processor;
}

void SegmentAdaptiveProcess::processResultNode(Node* node) {    
    processor->ProcessNode(node);
}
