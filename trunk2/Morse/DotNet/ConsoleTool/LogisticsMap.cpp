#include "stdafx.h"
#include "LogisticsMap.h"
#include "../graph/Graph.h"

const int LogisticsMapFactory::Dim = 2;

LogisticsMap::LogisticsMap(void) : FunctionBase(2, 1)
{
}

LogisticsMap::LogisticsMap(double* in, double* out) : FunctionBase(2, 1, in, out)
{
}


LogisticsMap::~LogisticsMap(void)
{
}

void LogisticsMap::evaluate() {
	output[0] = input[0];
	output[1] = input[0]*input[1]*(1-input[1]);
}


Graph* LogisticsMapFactory::CreateGraph() {
	double _min[] = { 2, 0};
	double _max[] = {4, 1};
	int _grid[] = {10,10};

	Graph* g = new Graph(2, _min, _max, _grid, false);
	g->maximize();

	return g;
}