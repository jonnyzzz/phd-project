#include "StdAfx.h"
#include ".\abstractprocessext.h"
#include "../graph/graph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


AbstractProcessExt::AbstractProcessExt(Graph* graph, ProgressBarInfo* info) : \
graph_source(graph), graph_result(NULL), AbstractProcess(info)
{
}

AbstractProcessExt::~AbstractProcessExt(void)
{
}



Graph* AbstractProcessExt::result() {
	ASSERT(graph_result != NULL);
	//ASSERT(wasInitialized);
	return graph_result;
}

void AbstractProcessExt::submitGraphResult(Graph* graph) {
	ASSERT(graph_result == NULL);
	//ASSERT(wasInitialized);
	graph_result = graph;
}


JDouble AbstractProcessExt::sqr(JDouble x) {
	return x*x;
}


GraphSet AbstractProcessExt::results() {
	return GraphSet(result());
}
