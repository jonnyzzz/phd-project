#include "StdAfx.h"
#include ".\segmentprojectivebundlemscreationprocess.h"

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
    return -2.1;
}

double SegmentProjectiveBundleMSCreationProcess::getMax(int i) {
    return 2.1;
}