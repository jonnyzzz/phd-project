#include "stdafx.h"
#include "SimpleBoxProcess.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SimpleBoxProcess::SimpleBoxProcess(Graph* graph, ISystemFunction* function, int* factor, ProgressBarInfo* pinfo)
: AbstractBoxProcess(graph, function, factor, pinfo)
{
}

SimpleBoxProcess::~SimpleBoxProcess(void)
{
}



void SimpleBoxProcess::processNodeAndImage(JDouble* value_min, JDouble* value_max, Node* node, Graph* graph) {
	graph->addEdges(node, value_min, value_max);
}
