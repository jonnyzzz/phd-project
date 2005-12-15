#include "stdafx.h"
#include "MSNormedFunction.h"

MSNormedFunction::MSNormedFunction(ISystemFunctionDerivate* function) : 
function(function), dimension(function->getFunctionDimension()),
ISystemFunction(function->getFunctionDimension(), 1)
{
	input = new double[dimension];
	output = new double[dimension];

	fdoutput = function->getOutput() + dimension;
}

MSNormedFunction::~MSNormedFunction(void)
{
	delete[] input;
	delete[] output;
}

double* MSNormedFunction::getInput() {
	return input;
}

double* MSNormedFunction::getOutput() {
	return output;
}


void MSNormedFunction::evaluate() {
	double l = 0;
	for (int i=0; i<dimension; i++) {
		double t = 0;        
        for (int j=0; j<dimension; j++) {
            t += fdoutput[i*dimension + j] * input[j];
        }   
		output[i] = t;
		l += t*t;
    }

	//first variable should be positive to make
	//equivalence relationship
	for (int i=dimension-1; i>=0; i++) {
		double t = Abs(output[i]);
		if (t >= 1e-8) {
			if (output[i] < 0) {
				output[i] = t;
				l = -l;
			}
			break;
		} 
	}	

	//norming phase
	for (int i=0; i<dimension; i++) {
		output[i] /= l;
	}
}


double MSNormedFunction::Abs(double x) {
	return (x > 0) ? x : -x;
}
