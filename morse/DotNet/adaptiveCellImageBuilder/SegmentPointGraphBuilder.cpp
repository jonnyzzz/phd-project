#include "StdAfx.h"
#include ".\segmentpointgraphbuilder.h"
#include "PointGraph.h"

SegmentPointGraphBuilder::SegmentPointGraphBuilder(int ldim, int udim, const double* aeps, PointGraph* graph) :
ldim(ldim), udim(udim), dim(udim-ldim), graph(graph)
{
	eps = new double[dim];
	eps2 = new double[dim];

	for (int i=0; i<dim; i++) {
		eps[i] = aeps[ldim + i];
		eps2[i] = eps[i]/2;
	}
}

SegmentPointGraphBuilder::~SegmentPointGraphBuilder(void)
{
	delete[] eps;
	delete[] eps2;
}


void SegmentPointGraphBuilder::BuildInitialGraph(double* x, int index) {
	x = &x[ldim];

	if (dim == 2) { //segment for 2D
		index = 1-index;

		PointGraph::Node* n1 = graph->AddNode(x);
		x[index]+= eps[index];
        PointGraph::Node* n2 = graph->AddNode(x);
        graph->AddEdge(n1, n2);			
	} else if (dim == 3) {
		int index0;
		int index1;
		switch (index) {
			case 0:
				index0 = 1;
				index1 = 2;
				break;
			case 1:
				index0 = 0;
				index1 = 2;
				break;
			case 2:
				index0 = 0;
				index1 = 1;
				break;
			default:
				ATLASSERT(false);
				break;
		}

        PointGraph::Node* n00 = graph->AddNode(x);
        x[index0]+= eps[index0];
        PointGraph::Node* n10 = graph->AddNode(x);
        x[index0]-= eps[index0];
        x[index1]+= eps[index1];
        PointGraph::Node* n01 = graph->AddNode(x);
        x[index0]+= eps[index0];
        PointGraph::Node* n11 = graph->AddNode(x);
        x[index0]-= eps2[index0];
        x[index1]-= eps2[index1];
        PointGraph::Node* c = graph->AddNode(x);

        graph->AddEdge(n00, n10);
        graph->AddEdge(n10, n11);
        graph->AddEdge(n11, n01);
        graph->AddEdge(n01, n00);
        graph->AddEdge(n00, c);
        graph->AddEdge(n10, c);
        graph->AddEdge(n01, c);
        graph->AddEdge(n11, c);
	}
}