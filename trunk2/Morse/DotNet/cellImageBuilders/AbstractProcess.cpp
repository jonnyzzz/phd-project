#include "StdAfx.h"
#include ".\abstractprocess.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



AbstractProcess::AbstractProcess(Graph* graph, ProgressBarInfo* info) : graph_source(graph), graph_result(NULL), info(info)
{
	wasInitialized = false;
}

AbstractProcess::~AbstractProcess(void)
{
}


Graph* AbstractProcess::result() {
	ASSERT(graph_result != NULL);
	ASSERT(wasInitialized);
	return graph_result;
}


void AbstractProcess::submitGraphResult(Graph* graph) {
	ASSERT(graph_result == NULL);
	ASSERT(wasInitialized);
	graph_result = graph;
}

void AbstractProcess::start() {
	wasInitialized = true;
}


JDouble AbstractProcess::sqr(JDouble x) {
	return x*x;
}