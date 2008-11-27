#include "StdAfx.h"
#include "MSNormedProcess.h"
#include "MSAdaptivePointGraphProcessor.h"

MSNormedProcess::MSNormedProcess(ISystemFunction* function, ISystemFunctionDerivate* dfunction, Graph* graph, JInt* division, double* precision, ProgressBarInfo* info) :
AdaptiveProcessBase(function, graph, division, precision, info)
{
	msp = new MSAdaptivePointGraphProcessor(resultGraph, function, dfunction, precision, 0);
}

MSNormedProcess::~MSNormedProcess(void)
{
	delete msp;
}



void MSNormedProcess::processResultNode(Node* node) {
	msp->ProcessNode(node);
}
	