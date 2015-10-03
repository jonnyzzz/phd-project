#include "stdafx.h"
#include "MSNormedFunction.h"
#include "math.h"

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

void inline MSNormedFunction::MakeZeroIfNeeded(double& x) {
	if (Abs(x) <= 1e-9) x = 0;	
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

	l = sqrt(l);

	//first variable should be positive to make
	//equivalence relationship
	//for (int i=dimension-1; i>=0; i--) {
	//	MakeZeroIfNeeded(output[i]);
    //
	//	if (output[i] > 0) {
	//		break;
	//	} else if (output[i] < 0) {
	//		l = -l;
	//		break;
	//	}		
	//}	

	int maxIndex = 0;
	for (int i=1; i<dimension; i++) {
		if (Abs(output[i]) > Abs(output[maxIndex])) {
			maxIndex = i;
		}
	}

	if (output[maxIndex] < 0) 
		l = -l;

	//norming phase
	for (int i=0; i<dimension; i++) {
		output[i] /= l;
		MakeZeroIfNeeded(output[i]);
	}
}


double MSNormedFunction::Abs(double x) {
	return (x > 0) ? x : -x;
}
