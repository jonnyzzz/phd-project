#include "stdafx.h"
#include "SegmentProjectiveBundleMSCreationProcess.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SegmentProjectiveBundleMSCreationProcess::SegmentProjectiveBundleMSCreationProcess(Graph* graph, int* factor, ProgressBarInfo* info)
:
    AbstractGraphCreator(graph, factor, info)
{
}

SegmentProjectiveBundleMSCreationProcess::~SegmentProjectiveBundleMSCreationProcess(void)
{
}


int SegmentProjectiveBundleMSCreationProcess::getNewDimension() {    
    return 2*this->graph_source->getDimention();
}

double SegmentProjectiveBundleMSCreationProcess::getMin(int i) {
    return -1;
}

double SegmentProjectiveBundleMSCreationProcess::getMax(int i) {
    return 1;
}
