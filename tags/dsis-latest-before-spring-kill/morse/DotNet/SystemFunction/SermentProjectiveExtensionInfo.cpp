#include "stdafx.h"
#include "SermentProjectiveExtensionInfo.h"
#include "SegmentProjectiveExtendedSystemFunction.h"
#include "../cellImageBuilders/SegmentProjectiveBundleMSCreationProcess.h"
#include "../cellImageBuilders/ProgressBarInfo.h"
#include "SegmentProjectiveExtensionMorseFunction.h"
#include "../graph_simplex/RomFunction2N.h"
#include "../cellImageBuilders/MSPointBuilder.h"
#include "../cellImageBuilders/MSOverlapedPointBuilder.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



SermentProjectiveExtensionInfo::SermentProjectiveExtensionInfo(ISystemFunctionDerivate* function) :
    IProjectiveExtensionInfo(function)
{	
	this->systemFunction = new SegmentProjectiveExtendedSystemFunction(function, function);
	this->morseFunction = new SegmentProjectiveExtensionMorseFunction(function);
}

SermentProjectiveExtensionInfo::~SermentProjectiveExtensionInfo(void)
{
	delete this->systemFunction;
	delete this->morseFunction;
}

AbstractProcess* SermentProjectiveExtensionInfo::nextStepProcess(Graph* graph, int* factor, int* ks, ProgressBarInfo* info) {
	MSPointBuilder* pb = new MSPointBuilder(graph, factor, ks, systemFunction, info);
	return pb;
}

AbstractProcess* SermentProjectiveExtensionInfo::nextStepProcess(Graph* graph, int* factor, int* ks, double* offset1, double* offset2, ProgressBarInfo* info) {
	bool hasOverlaping = false;
	for (int i=0; i<graph->getDimention(); i++) {
		if (offset1[i] > 0 || offset2[i] > 0) {
			hasOverlaping = true;
			break;
		}
	}

	if (!hasOverlaping) {
		cout<<"\n\nStandard MSProjectiveExtension\n\n";
		return nextStepProcess(graph, factor, ks, info);
	} else {
		cout<<"\n\nOverlaped MSProjectiveExtension\n\n";
		return new MSOverlapedPointBuilder(graph, factor, ks, offset1, offset2, systemFunction, info);
	}
}


AbstractGraphCreator* SermentProjectiveExtensionInfo::graphExtender(Graph* graph, int* factor, ProgressBarInfo* info) {
    return new SegmentProjectiveBundleMSCreationProcess(graph, factor, info);
}

CRom* SermentProjectiveExtensionInfo::morse(Graph* graph) {
	CRomFunction2N* function = new CRomFunction2N(morseFunction, graph);
	return function;
}


int SermentProjectiveExtensionInfo::extendedGraphDimension() {
    return 2*function->getFunctionDimension();
}


//only for test project. 
ISystemFunctionDerivate* SermentProjectiveExtensionInfo::getSystemFunction() {
	return new SegmentProjectiveExtendedSystemFunction(function, NULL);
}
