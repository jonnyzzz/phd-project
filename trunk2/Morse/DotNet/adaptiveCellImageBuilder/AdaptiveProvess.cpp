#include "StdAfx.h"
#include ".\adaptiveprovess.h"
#include "..\graph\graphUtil.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


AdaptiveProvess::AdaptiveProvess(ISystemFunction* function, Graph* graph, JInt* division, double* precision, ProgressBarInfo* info)
: AdaptiveProcessBase(function, graph, division, precision, info)
{     
    processor = new PointGraphProcessor(this->resultGraph, function, dimension, precision);
}

AdaptiveProvess::~AdaptiveProvess(void)
{    
    delete processor;
}

void AdaptiveProvess::processResultNode(Node* node) {    
    processor->ProcessNode(node);
}