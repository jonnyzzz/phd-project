#include "stdafx.h"
#include "MSAngleFunction.h"
#include "math.h"

MSAngleFunction::MSAngleFunction(ISystemFunctionDerivate* function) : 
function(function), dimension(function->getFunctionDimension()),
ISystemFunction(function->getFunctionDimension()-1, 1)
{
	ASSERT(dimension == 3);

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

    for (int i=0; i<dimension; i++) {
        tmp[i] = 0;
        for (int j=0; j<dimension; j++) {
            tmp[i] += fdoutput[i*dimension + j] * v[j];
        }   
    }	
	output[0] = Atan2(tmp[1], tmp[0]);
	output[1] = Atan2(Abs(tmp[2]), sqrt(tmp[1]*tmp[1] + tmp[0]*tmp[0]));
}


double MSAngleFunction::Abs(double x) {
	return (x > 0) ? x : -x;
}

double MSAngleFunction::Atan2(double y, double x) {
	return atan2(y, x);
}