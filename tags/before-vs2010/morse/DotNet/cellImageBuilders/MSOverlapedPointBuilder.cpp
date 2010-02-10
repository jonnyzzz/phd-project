#include "stdafx.h"
#include "MSOverlapedPointBuilder.h"
#include "../SystemFunction/ISystemFunctionDerivate.h"
#include "../SystemFunction/SegmentProjectiveExtendedSystemFunction.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MSOverlapedPointBuilder::MSOverlapedPointBuilder(Graph* graph, 
		                    int* factor, 
							int* ks, 
							JDouble* offset1, 
							JDouble* offset2, 
							SegmentProjectiveExtendedSystemFunction* function, 
							ProgressBarInfo* info) : 
SIOverlapedPointBuilder(graph, factor, ks, offset1, offset2, function, info)
{
	function_dimension = function->getFunctionDimension();
	v_offset = function_dimension*function_dimension;

	value = new JDouble[graph->getDimention() +1];
}

MSOverlapedPointBuilder::~MSOverlapedPointBuilder(void)
{
	delete[] value;
    delete function;
}


void MSOverlapedPointBuilder::buildImage(Graph* graph, Node* source) {
    function->evaluate();

	for (int i=0; i<function_dimension; i++) {
		value[i] = output[i];
	}
	for (int i=function_dimension; i<2*function_dimension; i++) {
		value[i] = output[v_offset + i];
	} 

	graph->addEdgeWithOverlaping(source, value, offset1, offset2);
}
