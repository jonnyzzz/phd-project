#include "StdAfx.h"
#include ".\abstractprocess.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



AbstractProcess::AbstractProcess(Graph* graph, ProgressBarInfo* info) : graph_source(graph), graph_result(NULL), info(info)
{

}

AbstractProcess::~AbstractProcess(void)
{
}


Graph* AbstractProcess::result() {
	VERIFY(graph_result != NULL);
	return graph_result;
}


void AbstractProcess::submitGraphResult(Graph* graph) {
	VERIFY(graph_result == NULL);
	graph_result = graph;
}

void AbstractProcess::start() {
}


JDouble AbstractProcess::sqr(JDouble x) {
	return x*x;
}