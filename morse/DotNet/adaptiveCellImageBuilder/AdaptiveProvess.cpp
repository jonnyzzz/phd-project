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
    processor = new PointGraphProcessor(this->resultGraph, function, dimension, precision, upperLimit);
}

AdaptiveProvess::~AdaptiveProvess(void)
{    
    delete processor;
}

void AdaptiveProvess::processResultNode(Node* node) {    
    processor->ProcessNode(node);
}