#include "StdAfx.h"
#include ".\minimalloopfinderprocess.h"
#include "minimalLoopFinder.h"


MinimalLoopFinderProcess::MinimalLoopFinderProcess(double* coor, int dimension, ProgressBarInfo* pinfo) : AbstractProcess(pinfo)
{
	this->dimension = dimension;
	this->coord = new JDouble[dimension];
	this->cell = new JInt[dimension];
	memcpy(this->coord, coor, sizeof(JDouble)*dimension);
}

MinimalLoopFinderProcess::~MinimalLoopFinderProcess(void)
{
	delete[] this->coord;
	delete[] this->cell;
}



GraphSet MinimalLoopFinderProcess::results() {
	return graphSet;
}


void MinimalLoopFinderProcess::processNextGraph(Graph* graph) {
	ASSERT(graph->getDimention() == this->dimension);

	graph->toInternal(coord, cell);

	Node* node = graph->findNode(cell);

	if (node != NULL) {
		MinimalLoopFinder f;
		Graph* result = f.FindMinimalLoop(graph, node);
		if (result->getNumberOfNodes() == 0) {
			delete result;
		} else {
			graphSet.AddGraph( result );
		}
	}
}
