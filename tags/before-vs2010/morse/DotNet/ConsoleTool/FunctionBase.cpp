#include "stdafx.h"
#include "FunctionBase.h"

FunctionBase::FunctionBase(int dim, int iter) : ISystemFunction(dim, iter)
{
	selfCreated = true;
	input = new double[dim*3];
	output = new double[dim*3];
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

int FunctionBase::getFunctionDimension(){
	return ISystemFunction::getFunctionDimension();
}

double* FunctionBase::getInput() {
	return input;
} 

double* FunctionBase::getOutput() {
	return output;
}


////////////////////////////////////////////////////////////////////////////////

FunctionBaseDerivate::FunctionBaseDerivate(int dim, int iter) : ISystemFunctionDerivate(dim + dim*dim, iter), dim(dim)
{
	dim = dim + dim*dim;
	selfCreated = true;
	input = new double[dim*3];
	output = new double[dim*3];
}

FunctionBaseDerivate::FunctionBaseDerivate(int dim, int iter, double* input, double* output) : ISystemFunctionDerivate(dim + dim*dim, iter), dim(dim) {
	this->selfCreated = false;
	this->input = input;
	this->output = output;
}

FunctionBaseDerivate::~FunctionBaseDerivate(void)
{
	if (!selfCreated) {
		delete[] input;
		delete[] output;
	}
}

int FunctionBaseDerivate::getFunctionDimension(){
	return dim;
}

double* FunctionBaseDerivate::getInput() {
	return input;
} 

double* FunctionBaseDerivate::getOutput() {
	return output;
}
