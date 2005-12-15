#include "StdAfx.h"
#include ".\msadaptivepointgraph.h"

MSAdaptivePointGraph::MSAdaptivePointGraph(ISystemFunction* function, int dimension, size_t upperLimit) :
PointGraph(function, dimension, upperLimit)
{
}

MSAdaptivePointGraph::~MSAdaptivePointGraph(void)
{
}
