#include "stdafx.h"
#include "SIOverlapedPointBuilder.h"
#include "../graph/Graph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SIOverlapedPointBuilder::SIOverlapedPointBuilder(Graph* graph, int* factor, int* ks, JDouble* poffset1, JDouble* poffset2, ISystemFunction* function, ProgressBarInfo* info)
: 
AbstractPointBuilder(graph, factor, ks, info), function(function)
{
	offset1 = new JDouble[dimension];
	offset2 = new JDouble[dimension];

	cout<<"\n\n\noverlaped :\n";
	for (int i=0l; i<dimension; i++) {
		offset1[i] = graph->getEps()[i]*poffset1[i];
		offset2[i] = graph->getEps()[i]*(1 - poffset2[i]);
		cout<<offset1[i]<<"\t"<<offset2[i]<<"\t"<<graph->getEps()[i]<<"\n";
	}
	cout<<"\n\n\n";
	this->output = function->getOutput();
}

SIOverlapedPointBuilder::~SIOverlapedPointBuilder(void)
{
	delete[] offset1;
	delete[] offset2;
}


JDouble* SIOverlapedPointBuilder::getFunctionX() {
	return function->getInput();
}



void SIOverlapedPointBuilder::buildImage(Graph* graph, Node* source) {
	function->evaluate();

	graph->addEdgeWithOverlaping(source, output, offset1, offset2);
}