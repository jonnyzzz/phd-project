#include "StdAfx.h"
#include ".\msoverlapedpointbuilder.h"
#include "../systemfunction/isystemfunctionderivate.h"

MSOverlapedPointBuilder::MSOverlapedPointBuilder(Graph* graph, 
		                    int* factor, 
							int* ks, 
							JDouble* offset1, 
							JDouble* offset2, 
							ISystemFunctionDerivate* function, 
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