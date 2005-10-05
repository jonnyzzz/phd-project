#include "stdafx.h"
#include "SIPointBuilder.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SIPointBuilder::SIPointBuilder(Graph* graph, int* factor, int* ks, ISystemFunction* function, ProgressBarInfo* info) :
AbstractPointBuilder(graph, factor, ks, info), function(function)
{
    input = function->getInput();
    output = function->getOutput();

	point = new JInt[dimension + 1];

    ASSERT(function->hasFunction());
}

SIPointBuilder::~SIPointBuilder(void)
{
	delete[] point;
}


////////////////////////////////////////////////////////////////////////////////////////////


void SIPointBuilder::buildImage(Graph* graph_result, Node* source) {
    function->evaluate();
    graph_result->toInternal(this->output, point);

	addEdge(graph_result, source, point);
}

JDouble* SIPointBuilder::getFunctionX() {
    return input;
}


void SIPointBuilder::addEdge(Graph* graph, Node* source, JInt* to) {
	Node* dest = graph->browseTo(to);
	if (dest != NULL) {
		graph->browseTo(source, dest);
	}
}