#include "stdafx.h"
#include "FunctionBase.h"

FunctionBase::FunctionBase(int dim, int iter) : ISystemFunction(dim, iter)
{
	selfCreated = true;
	input = new double[dim];
	output = new double[dim];
}

FunctionBase::FunctionBase(int dim, int iter, double* input, double* output) : ISystemFunction(dim, iter) {
	this->selfCreated = false;
	this->input = input;
	this->output = output;
}

FunctionBase::~FunctionBase(void)
{
	if (!selfCreated) {
		delete[] input;
		delete[] output;
	}
}


double* FunctionBase::getInput() {
	return input;
} 

double* FunctionBase::getOutput() {
	return output;
}