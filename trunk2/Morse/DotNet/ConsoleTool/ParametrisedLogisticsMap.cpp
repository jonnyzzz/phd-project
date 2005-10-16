#include "stdafx.h"
#include "ParametrisedLogisticsMap.h"
#include "../graph/Graph.h"
#include "../graph/GraphUtil.h"
#include "../graph/FileStream.h"
#include "../graph/LoopIterator.h"

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

double ParametrisedLogisticsMap::f(double d) {
	return mju*d*(1-d);
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


double inline ParametrisedLogisticsMapFactory::Abs(double d) {
	return ( d > 0) ? d : -d;
}

void ParametrisedLogisticsMapFactory::SaveOnlyUnstable(double mju, Graph* graph, FileOutputStream& fs) {
	LoopIterator it(graph);

	LoopIterator::NodeLists lists = it.process();
	int loopsCnt = 0;
	int errorCnt = 0;

	ParametrisedLogisticsMap::mju = mju;

	const double eps = graph->getEps()[0]*2;

	for (LoopIterator::NodeLists::iterator it = lists.begin(); it != lists.end(); it++) {
		double dfs = 1;
		bool isTruePeriod = true;
		
		LoopIterator::NodeList::iterator first = it->begin();
		LoopIterator::NodeList::iterator second = (it->size() == 1) ? it->begin() : ++it->begin();

		double px = graph->toExternal(graph->getCells(*first)[0], 0);

		while (second != it->end()) {
			double x = graph->toExternal(graph->getCells(*second)[0], 0);
			double fx = ParametrisedLogisticsMap::f(px);
			double dfx = ParametrisedLogisticsMap::derivate(x);
			px = x;

			dfs *= dfx;

			if (!(Abs(x - fx) < eps)) {
				cout<<"Computational Error period Found"<<endl;
				isTruePeriod = false;
				errorCnt++;
				break;
			}

			loopsCnt++;

			first = second;
			second++;
		}

		if (isTruePeriod && (Abs(dfs) > 1 - eps)) {
			for (LoopIterator::NodeList::iterator itt = it->begin(); itt != it->end(); itt++) {
				fs<<mju<<graph->toExternal(graph->getCells(*itt)[0],0);
				fs.stress();
			}			
		}
		fs.stress();
	}

	cout<<"Truly loop found: "<<loopsCnt<<" Wrong loops :"<<errorCnt<<endl;
}










