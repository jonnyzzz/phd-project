#include "stdafx.h"
#include "MSAdaptivePointGraphProcessor.h"
#include "PointGraph.h"
#include "PointGraphBuilder.h"
#include "MSAdaptivePointGraph.h"
#include "../SystemFunction/MSNormedFunction.h"
#include "IntersectingPointGraph.h"

#include "../graph/Graph.h"

MSAdaptivePointGraphProcessor::MSAdaptivePointGraphProcessor(Graph* graph, ISystemFunction* func, ISystemFunctionDerivate* dfunc, double* precision, size_t upperLimit)
: functionBase(func), graph(graph), dfunctionBase(dfunc)
{
	dimension = graph->getDimention();
	dimensionBase = dimension / 2;

	functionProj = new MSNormedFunction(dfunctionBase);

	pointGraphBase = new IntersectingPointGraph(graph, functionBase, dimensionBase, upperLimit);
	pointGraphProj = new MSAdaptivePointGraph(functionProj, dimensionBase, upperLimit);

	pointGraphBuilderBase = new PointGraphBuilder(0, dimensionBase, graph->getEps(), pointGraphBase);
	pointGraphBuilderProj = new PointGraphBuilder(dimensionBase, dimension, graph->getEps(), pointGraphProj);

	this->precision = new double[dimension];
	for (int i=0;i<dimension; i++) {
		this->precision[i] = precision[i];
	}

	overlap1 = this->precision;
	overlap2 = this->precision;

	dinput = dfunctionBase->getInput();

	x0 = new double[dimension];
	x = new double[dimension];
}

MSAdaptivePointGraphProcessor::~MSAdaptivePointGraphProcessor(void)
{
	delete[] precision;

	delete[] x;
	delete[] x0;

	delete pointGraphBase;
	delete pointGraphProj;
	
	delete pointGraphBuilderBase;
	delete pointGraphBuilderProj;
}



void MSAdaptivePointGraphProcessor::ProcessNode(Node* node) {
	
	pointGraphBase->Reset();
	pointGraphProj->Reset();

	for (int i=0; i<dimensionBase; i++) {
		dinput[i] = graph->toExternal(graph->getCells(node)[i],i) + graph->getEps()[i];
	}
	dfunctionBase->evaluate();

	for (int i=0; i<dimension; i++) {
		x[i] = graph->toExternal(graph->getCells(node)[i],i);
	}

	pointGraphBuilderBase->BuildInitialGraph(x);
	pointGraphBuilderProj->BuildInitialGraph(x);


	pointGraphBase->Dump(cout);
	pointGraphProj->Dump(cout);

	pointGraphBase->Iterate(precision);
	pointGraphProj->Iterate(&precision[dimensionBase]);

	const PointGraph::NodeList& listBase = pointGraphBase->Points();        
    for (PointGraph::NodeList::const_iterator itBase = listBase.begin(); itBase != listBase.end(); ++itBase) {
		const PointGraph::NodeList& listProj = pointGraphProj->Points();
		//cout<<"\nLength = "<<listProj.size()<<endl;
		for (PointGraph::NodeList::const_iterator itProj = listProj.begin(); itProj != listProj.end(); ++itProj) {
			AddCheckedNode(node, (*itBase)->valueCache, (*itProj)->valueCache);
		}
    }
}


void MSAdaptivePointGraphProcessor::Concatinate(const double* left, const double* right, double* x) {
	for (int i=0; i<dimensionBase; i++) {
		x[i] = *left++;
	} 
	for (int i=dimensionBase; i<dimension; i++) {
		x[i] = *right++;
	}
}


void MSAdaptivePointGraphProcessor::AddCheckedNode(Node* graphNode, double* base, double* proj) {
	Concatinate(base, proj, x0);

    graph->addEdgeWithOverlaping(graphNode, x0, overlap1, overlap2);
}
