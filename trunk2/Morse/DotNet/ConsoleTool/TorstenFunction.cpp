#include "stdafx.h"
#include "TorstenFunction.h"
#include "../graph/Graph.h"
#include <math.h>

#define TORSTEN_EXP

double TorstenFunction::beta = 6.25;
double TorstenFunction::d = 0.5;
double TorstenFunction::m = 3.5;
const int TorstenFactory::Dim = 2;

TorstenFunction::TorstenFunction(void) : ISystemFunction(2,1)
{
	selfCreated = true;
	input = new double[6];
	output = new double[6];
}

TorstenFunction::TorstenFunction(double* input, double* output) : ISystemFunction(2,1), input(input), output(output)
{
	selfCreated = false;
}


TorstenFunction::~TorstenFunction(void)
{
	if (selfCreated) {
		delete[] input;
		delete[] output;
	}
}


void TorstenFunction::evaluate() {
	double& f1 = output[0];
	double& f2 = output[1];

	double& x = input[0];
	double& y = input[1];
#ifdef TORSTEN_NOEXP
	f1=log(beta)+x-exp(y)-log(1+exp(x));
    f2=log(m*exp(x)*(1-exp(-exp(y)))+(1-d)*exp(y));
#endif
#ifdef TORSTEN_EXP
	f1=log(beta)+x-exp(y)-log(1+exp(x)*exp(-exp(y)));
	f2=log(m*exp(x)*(1-exp(-exp(y)))+(1-d)*exp(y));
#endif
}


Graph* TorstenFactory::CreateGraph() {
	double _min[] = { -60, -25};
	double _max[] = {15, 10};
	int _grid[] = {10,10};

	Graph* g = new Graph(2, _min, _max, _grid, false);
	g->maximize();

	return g;
}


void TorstenFactory::Dump() {
	cout<<"torsten's function with"<<endl<<"beta="<<TorstenFunction::beta<<" m="<<TorstenFunction::m<<" d="<<TorstenFunction::d<<endl<<endl;
}
