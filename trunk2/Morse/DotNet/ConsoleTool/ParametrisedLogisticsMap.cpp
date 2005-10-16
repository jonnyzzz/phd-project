#include "stdafx.h"
#include "ParametrisedLogisticsMap.h"
#include "../graph/Graph.h"
#include "../graph/GraphUtil.h"
#include "../graph/FileStream.h"

#include <list>
using namespace std;

const int ParametrisedLogisticsMapFactory::Dim = 1;
double ParametrisedLogisticsMap::mju = 0;

ParametrisedLogisticsMap::ParametrisedLogisticsMap(void) : FunctionBase(1, 1)
{
}

ParametrisedLogisticsMap::ParametrisedLogisticsMap(double* in, double* out) : FunctionBase(1, 1, in, out)
{
}

ParametrisedLogisticsMap::~ParametrisedLogisticsMap(void)
{
}

void ParametrisedLogisticsMap::evaluate() {	
	output[0] = mju*input[0]*(1-input[0]);
}


Graph* ParametrisedLogisticsMapFactory::CreateGraph() {
	double _min[] = { 0};
	double _max[] = {1};
	int _grid[] = {10};

	Graph* g = new Graph(1, _min, _max, _grid, false);
	g->maximize();
	return g;
}

double ParametrisedLogisticsMap::derivate(double d) {
	return mju - 2*mju*d;
}


void ParametrisedLogisticsMapFactory::Dump() {
	cout<<"Logistics Map with parameter "<<ParametrisedLogisticsMap::mju<<endl;
}


void ParametrisedLogisticsMapFactory::SaveOnlyUnstable(double mju, Graph* graph, FileOutputStream& fs) {
	/*
	const int flagID = graph->registerFlag();

	typedef list<Node*> NodesList;
	NodeList path;
	NodeList current;

	stack.push_back(GraphNodeEnumerator(graph).next());

	for (NodesList::iterator it = path.begin(); it != path.end(); it++) {
		Node* node = *it;
		graph->setFlag(node, flagID, true);
		GraphEdgeEnumerator ee(graph, node);
		Node* to;
		while ((to = ee.nextTo()) != NULL) {
			if (!graph->readFlag(to, flagID)) {
							
	
			}
		}
	}


	Node* node;
	while ((node = ne.next())!= NULL) {
		double point;
		graph->toExternal(graph->getCells(node)[0], 0);


	}
	*/
	
	ParametrisedLogisticsMap::mju = mju;

	GraphNodeEnumerator ne(graph);
	Node* node;
	while (node = ne.next()) {
		if (graph->isLoop(node)) {
			double c = graph->toExternal(graph->getCells(node)[0], 0);

			double d = ParametrisedLogisticsMap::derivate(c);

			if (d < -1 || d > 1) {
				fs<<mju<<c;
				fs.stress();
			}
		}
	}

}