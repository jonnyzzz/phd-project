#include "StdAfx.h"
#include ".\sermentprojectiveextensioninfo.h"
#include ".\SegmentProjectiveExtendedSystemFunction.h"
#include "../cellimagebuilders/SegmentProjectiveBundleMSCreationProcess.h"
#include "../cellimagebuilders/ProgressBarInfo.h"
#include "segmentprojectiveextensionmorsefunction.h"



SermentProjectiveExtensionInfo::SermentProjectiveExtensionInfo(ISystemFunctionDerivate* function) :
    IProjectiveExtensionInfo(function)
{
}

SermentProjectiveExtensionInfo::~SermentProjectiveExtensionInfo(void)
{
}



ISystemFunctionDerivate* SermentProjectiveExtensionInfo::systemFunction() {
    return new SegmentProjectiveExtendedSystemFunction(function);
}

int SermentProjectiveExtensionInfo::extendedGraphDimension() {
    return 2*function->getFunctionDimension();
}

IMorseFunction* SermentProjectiveExtensionInfo::morseFunction() {
    return new SegmentProjectiveExtensionMorseFunction(function);
}

AbstractGraphCreator* SermentProjectiveExtensionInfo::graphExtender(Graph* graph, int* factor, ProgressBarInfo* info) {
    return new SegmentProjectiveBundleMSCreationProcess(graph, factor, info);
}
