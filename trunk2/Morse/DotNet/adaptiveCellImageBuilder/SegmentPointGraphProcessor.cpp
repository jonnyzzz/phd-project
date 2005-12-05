#include "StdAfx.h"
#include ".\segmentpointgraphprocessor.h"

#include "IntersectingPointGraph.h"
#include "SegmentPointGraph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SegmentPointGraphProcessor::SegmentPointGraphProcessor(Graph* graph, SegmentProjectiveExtendedSystemFunction *function, int dimension, double* precision, size_t upperLimit)
: graph(graph), 
  function(function),
  input(function->getInput()),
  output(function->getOutput()),
  dimension(dimension), 
  dimensionBase(dimension / 2),
  pointGraphBase(new IntersectingPointGraph(graph, function->GetBaseFunction(), dimensionBase, upperLimit)),
  pointGraphProj(new SegmentPointGraph(graph, function->GetProjectiveFunction(), dimensionBase, upperLimit)),
  pointGraphBuilderBase(0, dimensionBase, graph->getEps(), *pointGraphBase),
  pointGraphBuilderProj(dimensionBase, dimension, graph->getEps(), *pointGraphProj)
{
	ATLASSERT(dimensionBase > 0 && dimensionBase < dimension);

    x = new JDouble[dimension];
    x0 = new JDouble[dimension];
    b = new JInt[dimension+1];
    a = new JInt[dimension+1];
    overlap1 = new JDouble[dimension];
    overlap2 = new JDouble[dimension];
    this->precision = new JDouble[dimension];
    for (int i=0; i<dimension; i++) {
        this->precision[i] = precision[i];
        overlap1[i] = precision[i];
        overlap2[i] = precision[i];
    }    
    radius = new JDouble[dimension];
}

SegmentPointGraphProcessor::~SegmentPointGraphProcessor(void)
{
	delete[] x;
	delete[] x0;
	delete[] b;
	delete[] a;
	delete[] overlap1;
	delete[] overlap2;
	delete[] precision;
	delete[] radius;
	delete pointGraphBase;
	delete pointGraphProj;
}


void SegmentPointGraphProcessor::ProcessNode(Node* node) {
	pointGraphBase->Reset();
	pointGraphProj->Reset();

	cout<<"Node : ";
	for (int i=0; i<dimension; i++) {
        input[i] = graph->toExternal(graph->getCells(node)[i],i) + graph->getEps()[i]/2;
		cout<<input[i]<<" ";
    }
	cout<<endl;

	function->SetProjectiveCenter();

    for (int i=0; i<dimension; i++) {
        x[i] = graph->toExternal(graph->getCells(node)[i],i);		
    }   
    pointGraphBuilderBase.BuildInitialGraph(x);
	pointGraphBuilderProj.BuildInitialGraph(x);
    
	bool baseResult = pointGraphBase->Iterate(precision);
	bool projResult = pointGraphProj->Iterate(&precision[dimensionBase]);


	if (baseResult && projResult) {
		const PointGraph::NodeList& listBase = pointGraphBase->Points();        
        for (PointGraph::NodeList::const_iterator itBase = listBase.begin(); itBase != listBase.end(); ++itBase) {
			const PointGraph::NodeList& listProj = pointGraphProj->Points();
			for (PointGraph::NodeList::const_iterator itProj = listProj.begin(); itProj != listProj.end(); ++itProj) {
				AddCheckedNode(node, (*itBase)->valueCache, (*itProj)->valueCache);
			}
        }
	} else {
		const PointGraph::NodeList& listBase = pointGraphBase->Points();        
        for (PointGraph::NodeList::const_iterator itBase = listBase.begin(); itBase != listBase.end(); ++itBase) {
			const PointGraph::NodeList& listProj = pointGraphProj->Points();
			for (PointGraph::NodeList::const_iterator itProj = listProj.begin(); itProj != listProj.end(); ++itProj) {

				if (pointGraphBase->IsCheckedNode(*itBase) && pointGraphProj->IsCheckedNode(*itProj)) {
					AddCheckedNode(node, (*itBase)->valueCache, (*itProj)->valueCache);
				} else { 
					AddNonCheckedNode(node, (*itBase), (*itProj));
				}
			}
        }
	}
}


void SegmentPointGraphProcessor::AddCheckedNode(Node* graphNode, double* base, double* proj) {
	memcpy(x, base, sizeof(double)*dimensionBase);
	memcpy(&x[dimensionBase], proj, sizeof(double)*dimensionBase);

	/*
	cout<<"--->to :";
	for (int i=0; i<dimension; i++) {
		cout<<x[i]<<" ";
	}
	cout<<endl;
	//*/

    graph->addEdgeWithOverlaping(graphNode, x, overlap1, overlap2);
}

void SegmentPointGraphProcessor::AddNonCheckedNode(Node* node, PointGraph::Node* base, PointGraph::Node* proj) {
	memcpy(x, base->valueCache, sizeof(double)*dimensionBase);
	memcpy(&x[dimensionBase], proj->valueCache, sizeof(double)*dimensionBase);

	pointGraphBase->NodeLength(base, radius);
	pointGraphProj->NodeLength(proj, &radius[dimensionBase]);

    graph->addEdgesRadius(node, x, radius);
}
