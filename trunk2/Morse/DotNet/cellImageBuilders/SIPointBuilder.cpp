#include "StdAfx.h"
#include ".\sipointbuilder.h"

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

    ASSERT(function->hasFunction());
}

SIPointBuilder::~SIPointBuilder(void)
{
}


////////////////////////////////////////////////////////////////////////////////////////////


void SIPointBuilder::buildImage(Graph* graph_result, JInt* point) {
    function->evaluate();
    graph_result->toInternal(this->output, point);
}

JDouble* SIPointBuilder::getFunctionX() {
    return input;
}
