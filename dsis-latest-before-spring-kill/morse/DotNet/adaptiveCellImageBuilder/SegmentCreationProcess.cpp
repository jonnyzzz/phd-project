#include "StdAfx.h"
#include "SegmentCreationProcess.h"
#include "../graph/GraphUtil.h"

SegmentCreationProcess::SegmentCreationProcess(Graph* graph, JInt* factor, ProgressBarInfo* pinfo)
: AbstractProcess(info), dimensionBase(graph->getDimention()), dimension(2*graph->getDimention())
{
	this->factor = new JInt[dimension];
	this->p = new JInt[dimension];
	this->b = new JInt[dimension+1];
	for (int i=0; i<dimension; i++) {
		this->factor[i] = factor[i];
	}
	CreateGraph(graph);
}

SegmentCreationProcess::~SegmentCreationProcess(void)
{
	delete[] factor;
	delete[] p;
	delete[] b;
}


GraphSet SegmentCreationProcess::results() {
	return GraphSet(graph_result);
}

void SegmentCreationProcess::CreateGraph(Graph* graph) {
	JInt* grid = new JInt[dimension];
	JDouble* left = new JDouble[dimension];
	JDouble* right = new JDouble[dimension];

	int fact = 1;

	for (int i=0; i<dimensionBase; i++) {
		grid[i] = graph->getGrid()[i] * factor[i];
		left[i] = graph->getMin()[i];
		right[i] = graph->getMax()[i];
		fact *= factor[i];
	}
	for (int i=dimensionBase;i<dimension; i++) {
		grid[i] = factor[i];
		left[i] = -1;
		right[i] = 1;
		fact *= factor[i];
	}

	graph_result = new Graph(dimension, left, right, grid, false, Graph::getNodeHashMax(fact*graph->getNumberOfNodes()), 1);
}

void SegmentCreationProcess::processNextGraph(Graph* graph) {

	GraphNodeEnumerator ne(graph);
	Node* node;
	while ((node = ne.next()) != NULL) {
		ProcessNode(graph->getCells(node));
	}
}


void SegmentCreationProcess::ProcessNode(const JInt* coord) {

	for (int i=0;i<=dimension; b[i++] = 0);

	while (b[dimension] == 0){
		bool isOk = false;
		for (int i=dimensionBase; i<dimension; i++) {
			p[i] = b[i];
			if (p[i] == factor[i]-1) isOk = true;
		}
		if (isOk) {
			for (int i=0; i<dimensionBase; i++) {
				p[i] = coord[i]*factor[i] + b[i];
			}

			graph_result->browseTo(p);
		}
		b[0]++;
		for (int i=0; i<dimension; i++) {
			if (b[i] >= factor[i]) {
				b[i] = 0;
				b[i+1] ++;
			} else {
				break;
			}
		}
	}
}