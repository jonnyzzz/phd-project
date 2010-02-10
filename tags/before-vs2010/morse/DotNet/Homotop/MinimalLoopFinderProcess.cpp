#include "StdAfx.h"
#include ".\minimalloopfinderprocess.h"
#include "minimalLoopFinder.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MinimalLoopFinderProcess::MinimalLoopFinderProcess(double* coor, int dimension, ProgressBarInfo* pinfo) : AbstractProcess(pinfo)
{
	this->dimension = dimension;
	this->coord = new JDouble[dimension];
	this->cell = new JInt[dimension];
	memcpy(this->coord, coor, sizeof(JDouble)*dimension);
	graph_result = NULL;
}

MinimalLoopFinderProcess::~MinimalLoopFinderProcess(void)
{
	delete[] this->coord;
	delete[] this->cell;
}



GraphSet MinimalLoopFinderProcess::results() {
	if (graph_result != NULL && graph_result->getNumberOfNodes() != 0 ) {
		return GraphSet(graph_result);
	} else {
		return GraphSet();
	}
}


void MinimalLoopFinderProcess::processNextGraph(Graph* graph) {
	ASSERT(graph->getDimention() == this->dimension);

	graph->toInternal(coord, cell);

	Node* node = graph->findNode(cell);



	if (node != NULL) {
		cout<<"Node found in graph\n";
		MinimalLoopFinder f;
		if (graph_result == NULL) {
			graph_result = f.FindMinimalLoop(graph, node);
		} else {
			f.FindMinimalLoop(graph, node, graph_result);
		}		
	} else {
		cout<<"Node not found in graph\n";
	}
}
