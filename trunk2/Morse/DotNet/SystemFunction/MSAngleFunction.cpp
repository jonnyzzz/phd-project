#include "stdafx.h"
#include "MSAngleFunction.h"
#include "math.h"


MSAngleFunction::MSAngleFunction(ISystemFunctionDerivate* function) : 
function(function), dimension(function->getFunctionDimension()),
ISystemFunction(function->getFunctionDimension()-1, 1)
{
	input = new double[dimension];
	output = new double[dimension];
	tmp = new double[dimension];
	v = new double[dimension];

	finput = function->getInput();
	foutput = function->getOutput();
	fdoutput = &foutput[dimension];
}

MSAngleFunction::~MSAngleFunction(void)
{
	delete[] input;
	delete[] output;
	delete[] tmp;
	delete[] v;
}

double* MSAngleFunction::getInput() {
	return input;
}

double* MSAngleFunction::getOutput() {
	return output;
}


void MSAngleFunction::evaluate() {

	//this is not a finished code!
	ATLASSERT(false);

    for (int i=0; i<dimension; i++) {
        tmp[i] = 0;
        for (int j=0; j<dimension; j++) {
            tmp[i] += fdoutput[i*dimension + j] * v[j];
        }   
    }
	
	double len = tmp[0]*tmp[0];
	output[0] = Atan2(tmp[1], tmp[0]);
	len += tmp[1]*tmp[1];

	int index;
	for (index = 2; index < dimension; index ++) {		
		output[index-1] = Atan2(tmp[index], sqrt(len));
		len += tmp[index]*tmp[index];
	}

	//here we need to have angles from -pi to pi for xy
	//and -pi2 to pi2 for xy.. to z axes
	for (index = dimension-1; index>=0; index--) {		
		double t = Abs(output[index]);
		if (t >= 1e-8) {
			output[index] = t;
			break;
		}
	}
}


double MSAngleFunction::Abs(double x) {
	return (x > 0) ? x : -x;
}

double MSAngleFunction::Atan2(double y, double x) {
	return atan2(y, x);
}
