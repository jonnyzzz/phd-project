#include "StdAfx.h"
#include ".\msanglemorsefunction.h"
#include <cmath>
using namespace std;

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MSAngleMorseFunction::MSAngleMorseFunction(ISystemFunctionDerivate* function) : IMorseFunction(function),
f_dimension(function->getFunctionDimension())
{
    input = function->getInput();
    output = function->getOutput();

	fdoutput = &output[f_dimension];
	tmp = new double[f_dimension*2];
	v = new double[f_dimension*2];

	ASSERT(f_dimension == 3);
}

MSAngleMorseFunction::~MSAngleMorseFunction(void)
{
	delete[] tmp;
	delete[] v;
}


double* MSAngleMorseFunction::getInput() {
    return input;
}

double* MSAngleMorseFunction::getOutput() {
    return output;
}

double inline MSAngleMorseFunction::Sqr(double x) {
    return x*x;
}

void MSAngleMorseFunction::evaluate() {
    function->evaluate();

	double cs = cos(input[f_dimension+1]);
	v[0] = cos(input[f_dimension]) * cs;
	v[1] = sin(input[f_dimension]) * cs;
	v[2] = sin(input[f_dimension+1]);

	double norm = 0;
	for (int i=0; i<f_dimension; i++) {
        tmp[i] = 0;
        for (int j=0; j<f_dimension; j++) {
            tmp[i] += fdoutput[i*f_dimension + j] * v[j];
        }   
		norm += Sqr(tmp[i]);
    }	

    output[0] = log( norm )/2;
};
