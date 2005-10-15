#include "stdafx.h"
#include "ParametrisedLogisticsMap.h"
#include "../graph/Graph.h"

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


void ParametrisedLogisticsMapFactory::Dump() {
	cout<<"Logistics Map with parameter "<<ParametrisedLogisticsMap::mju<<endl;
}

