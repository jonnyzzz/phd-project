#include "StdAfx.h"
#include ".\adaptiveprovess.h"
#include "..\graph\graphUtil.h"
#include "IntersectingPointGraph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


AdaptiveProvess::AdaptiveProvess(ISystemFunction* function, Graph* graph, JInt* division, double* precision, size_t upperLimit, ProgressBarInfo* info)
: AdaptiveProcessBase(function, graph, division, precision, info)
{   
	pointGraph = new IntersectingPointGraph(graph, function, dimension, upperLimit);
    processor = new PointGraphProcessor(pointGraph, this->resultGraph, function, dimension, precision, upperLimit);
}

AdaptiveProvess::~AdaptiveProvess(void)
{    
	delete pointGraph;
    delete processor;
}

void AdaptiveProvess::processResultNode(Node* node) {    
    processor->ProcessNode(node);
}