#include "StdAfx.h"
#include ".\sermentprojectiveextensioninfo.h"
#include ".\SegmentProjectiveExtendedSystemFunction.h"
#include "../cellimagebuilders/SegmentProjectiveBundleMSCreationProcess.h"
#include "../cellimagebuilders/ProgressBarInfo.h"
#include "segmentprojectiveextensionmorsefunction.h"
#include "../graph_simplex/romfunction2n.h"
#include "../cellimagebuilders/mspointbuilder.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



SermentProjectiveExtensionInfo::SermentProjectiveExtensionInfo(ISystemFunctionDerivate* function) :
    IProjectiveExtensionInfo(function)
{	
	this->systemFunction = new SegmentProjectiveExtendedSystemFunction(function);
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

