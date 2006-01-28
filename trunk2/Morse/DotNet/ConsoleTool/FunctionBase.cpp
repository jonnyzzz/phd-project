#include "stdafx.h"
#include "FunctionBase.h"

FunctionBase::FunctionBase(int dim, int iter) : ISystemFunctionDerivate(dim, iter)
{
	selfCreated = true;
	input = new double[dim*3];
	output = new double[dim*3];
	this->computeDerivate = false;
}

FunctionBase::FunctionBase(int dim, int iter, double* input, double* output) : ISystemFunctionDerivate(dim, iter) {
	this->selfCreated = false;
	this->input = input;
	this->output = output;
	this->computeDerivate = false;
}

FunctionBase::~FunctionBase(void)
{
	if (!selfCreated) {
		delete[] input;
		delete[] output;
	}
}

int FunctionBase::getFunctionDimension(){
	return getDimension();
}

void FunctionBase::ComputeDerivate(bool value) {
	this->computeDerivate = value;
}

bool FunctionBase::ComputeDerivate() {
	return this->computeDerivate;
}

double* FunctionBase::getInput() {
	return input;
} 

double* FunctionBase::getOutput() {
	return output;
}
