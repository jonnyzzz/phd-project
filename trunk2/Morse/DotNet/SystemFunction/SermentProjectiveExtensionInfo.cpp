#include "StdAfx.h"
#include ".\sermentprojectiveextensioninfo.h"
#include ".\SegmentProjectiveExtendedSystemFunction.h"
#include "../cellimagebuilders/SegmentProjectiveBundleMSCreationProcess.h"



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
    return NULL;
}

AbstractGraphCreator* SermentProjectiveExtensionInfo::graphExtender(Graph* graph, int* factor) {
    return new SegmentProjectiveBundleMSCreationProcess(graph, factor);
}
