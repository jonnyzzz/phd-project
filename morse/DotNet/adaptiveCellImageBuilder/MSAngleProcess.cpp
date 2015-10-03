#include "StdAfx.h"
#include "MSAngleProcess.h"
#include "MSAnglePointGraphProcessor.h"


MSAngleProcess::MSAngleProcess(ISystemFunction* function, ISystemFunctionDerivate* dfunction, Graph* graph, JInt* division, double* precision, size_t upperBase, size_t upperProj, ProgressBarInfo* info) :
AdaptiveProcessBase(function, graph, division, precision, info)
{
	msp = new MSAnglePointGraphProcessor(resultGraph, function, dfunction, precision, upperBase, upperProj);
}


MSAngleProcess::MSAngleProcess(ISystemFunction* function, ISystemFunctionDerivate* dfunction, Graph* graph, JInt* division, double* precision, ProgressBarInfo* info) :
AdaptiveProcessBase(function, graph, division, precision, info)
{
	msp = new MSAnglePointGraphProcessor(resultGraph, function, dfunction, precision, 0, 0);
}

MSAngleProcess::~MSAngleProcess(void)
{
	delete msp;
}

void MSAngleProcess::processResultNode(Node* node) {
	msp->ProcessNode(node);
}
	