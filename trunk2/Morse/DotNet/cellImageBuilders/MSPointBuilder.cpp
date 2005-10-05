#include "stdafx.h"
#include "../graph/Graph.h"

#include "MSPointBuilder.h"
#include "../SystemFunction/SegmentProjectiveExtendedSystemFunction.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MSPointBuilder::MSPointBuilder(Graph* graph, int* factor, int* ks, ISystemFunctionDerivate* function, ProgressBarInfo* info) : 
	SIPointBuilder(graph, factor, ks, /*new SegmentProjectiveExtendedSystemFunction*/(function), info )
{
    output = function->getOutput();
    ASSERT(function->hasDerivative());
    ASSERT(function->hasFunction());

	function_dimension = function->getFunctionDimension();
	v_offset = function_dimension * function_dimension;
}

MSPointBuilder::~MSPointBuilder(void)
{
}


void MSPointBuilder::buildImage(Graph* graph, Node* source) {
    function->evaluate();

	for (int i=0; i<function_dimension; i++) {
		point[i] = graph->toInternal(output[i], i);
	}
	for (int i=function_dimension; i<2*function_dimension; i++) {
		point[i] = graph->toInternal(output[v_offset + i], i);
	} 

	addEdge(graph, source, point);
}