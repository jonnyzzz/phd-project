#include "stdafx.h"
#include "TorstenFunction.h"
#include "../graph/Graph.h"
#include <math.h>

#define TORSTEN_EXP
#define TORSTEN_DERIVATE

double TorstenFunction::beta = 6.25;
double TorstenFunction::d = 0.5;
double TorstenFunction::m = 3.5;
const int TorstenFactory::Dim = 2;

TorstenFunction::TorstenFunction(void) : ISystemFunctionDerivate(2,1)
{
	selfCreated = true;
	input = new double[6];
	output = new double[6];
}

TorstenFunction::TorstenFunction(double* input, double* output) : ISystemFunctionDerivate(2,1), input(input), output(output)
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

#ifdef TORSTEN_DERIVATE
	double& f1x = output[2];
	double& f1y = output[3];
	double& f2x = output[4];
	double& f2y = output[5];
#endif

	double& x = input[0];
	double& y = input[1];
#ifdef TORSTEN_NOEXP
	f1=log(beta)+x-exp(y)-log(1+exp(x));
    f2=log(m*exp(x)*(1-exp(-exp(y)))+(1-d)*exp(y));

#ifdef TORSTEN_DERIVATE
	f1x = 1-exp(x)/(1+exp(x));
	f1y = -exp(y);
	f2x = m*exp(x)*(1-exp(-exp(y)))/(m*exp(x)*(1-exp(-exp(y)))+(1-d)*exp(y))
    f2y = m*exp(x)*exp(y)*exp(-exp(y))+(1-d)*exp(y))/(m*exp(x)*(1-exp(-exp(y)))+(1-d)*exp(y));
#endif
#endif
#ifdef TORSTEN_EXP
	f1=log(beta)+x-exp(y)-log(1+exp(x)*exp(-exp(y)));
	f2=log(m*exp(x)*(1-exp(-exp(y)))+(1-d)*exp(y));
#ifdef TORSTEN_DERIVATE
	f1x = 1-exp(x)*exp(-exp(y))/(1+exp(x)*exp(-exp(y)));
	f1y = -exp(y)+exp(x)*exp(y)*exp(-exp(y))/(1+exp(x)*exp(-exp(y)));
	f2x = m*exp(x)*(1-exp(-exp(y)))/(m*exp(x)*(1-exp(-exp(y)))+(1-d)*exp(y))
    f2y = m*exp(x)*exp(y)*exp(-exp(y))+(1-d)*exp(y))/(m*exp(x)*(1-exp(-exp(y)))+(1-d)*exp(y));
#endif
#endif
}


int TorstenFunction::getFunctionDimension() {
	return TorstenFactory::Dim;
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
