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
	SIPointBuilder(graph, factor, ks, /*new SegmentProjectiveExtendedSystemFunction*/(function))
{
    output = function->getOutput();
    ASSERT(function->hasDerivative());
    ASSERT(function->hasFunction());

	cout<<"Function = "<<function->getDimension()<<"\n";
	cout<<"Graph = "<<graph->getDimention()<<"\n";

	function_dimension = function->getFunctionDimension();
	v_offset = function_dimension * function_dimension;

	cout<<"Function Dimension = "<<function_dimension<<"\n";
	cout<<"V_offset = "<<v_offset<<"\n";
}

MSPointBuilder::~MSPointBuilder(void)
{
    //delete SIPointBuilder::function;
}


void MSPointBuilder::buildImage(Graph* graph, JInt* answer) {
    function->evaluate();

	for (int i=0; i<function_dimension; i++) {
		answer[i] = graph->toInternal(output[i], i);
		
		//answer[i + function_dimension] = graph->toInternal(output[v_offset+i], i+function_dimension);
	}
	for (int i=function_dimension; i<2*function_dimension; i++) {
		cout<<"v["<<i-function_dimension<<"] = "<<output[v_offset+i]<<"\n";
		answer[i] = graph->toInternal(output[v_offset + i], i);
	} 
	cout<<"\n";
	//graph->toInternal(output, answer);
}