#include "StdAfx.h"
#include ".\sipointbuilder.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SIPointBuilder::SIPointBuilder(Graph* graph, int* factor, int* ks, Function* function, ProgressBarInfo* info) :
AbstractPointBuilder(graph, factor, ks, info), function(function)
{
}

SIPointBuilder::~SIPointBuilder(void)
{
}


////////////////////////////////////////////////////////////////////////////////////////////


void SIPointBuilder::buildImage(Graph* graph_result, JInt* point) {
	for (int i=0; i<dimension; i++) {			
		point[i] = graph_result->toInternal(function->F(i), i);			
	}
}

JDouble* SIPointBuilder::getFunctionX() {
	return function->getVariables();
}
