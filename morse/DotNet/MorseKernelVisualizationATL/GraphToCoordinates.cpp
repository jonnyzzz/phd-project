#include "StdAfx.h"
#include ".\graphtocoordinates.h"

GraphToCoordinates::GraphToCoordinates(void)
{
}

GraphToCoordinates::~GraphToCoordinates(void)
{
}

JDouble inline GraphToCoordinates::Abs(JDouble x) {
	return (x>0)?x:-x;
}

void GraphToCoordinates::toFactor(Graph* graph, JInt& grid, int d, JInt& factor) {
	JInt gridGraph = graph->getGrid()[d];

	factor = 2;
	while (gridGraph / factor < grid) factor++;
	factor--;

	grid = gridGraph / factor + 1;   //+1 to be shure that's ok
}


Graph* GraphToCoordinates::createCut(Graph* graph, int dimX, int dimY, JDouble minX, JDouble maxX, JDouble minY, JDouble maxY, JInt gridX, JInt gridY) {
	
	JInt factor[2];
	toFactor(graph, gridX, 0, factor[0]);
	toFactor(graph, gridY, 1, factor[1]);

	JDouble zmin[] = {minX, minY};
	JDouble zmax[] = {maxX, maxY};
	JInt zg[] = {gridX, gridY};
	
	
	Graph* result = new Graph(2, zmin, zmax, zg);
	
	NodeEnumerator* ne = graph->getNodeRoot();
	Node* node;
	JInt x[2];
    while (node = graph->getNode(ne)) {
		x[0] = graph->getCells(node)[0] / factor[0];
		x[1] = graph->getCells(node)[1] / factor[1];

		result->browseTo(x);
	}
	graph->freeNodeEnumerator(ne);

	return result;
}