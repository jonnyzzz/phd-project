#include "StdAfx.h"
#include "../graph/graph.h"

#include ".\mspointbuilder.h"
#include "../SystemFunction/SegmentProjectiveExtendedSystemFunction.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MSPointBuilder::MSPointBuilder(Graph* graph, int* factor, int* ks, ISystemFunctionDerivate* function) : 
	SIPointBuilder(graph, factor, ks, new SegmentProjectiveExtendedSystemFunction(function))
{
    output = function->getOutput();
    ASSERT(function->hasDerivative());
    ASSERT(function->hasFunction());
}

MSPointBuilder::~MSPointBuilder(void)
{
    delete SIPointBuilder::function;
}


void MSPointBuilder::buildImage(Graph* graph, JInt* answer) {
    function->evaluate();

	graph->toInternal(output, answer);
}