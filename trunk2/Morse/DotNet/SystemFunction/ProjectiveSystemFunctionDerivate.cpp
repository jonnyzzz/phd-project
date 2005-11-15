#include "stdafx.h"
#include "ProjectiveSystemFunctionDerivate.h"

ProjectiveSystemFunctionDerivate::ProjectiveSystemFunctionDerivate(ISystemFunctionDerivate* function) :
  ISystemFunctionDerivate(function->getDimension()*2, function->getIteration()), function(function), 
  dimension(function->getDimension()), 
  dstart(function->getDimension()),
  vstart(function->getDimension()*2+function->getDimension()),
  input(function->getInput()), output(function->getOutput())
{
}

ProjectiveSystemFunctionDerivate::~ProjectiveSystemFunctionDerivate(void)
{
}


double* ProjectiveSystemFunctionDerivate::getInput() {
    return input;
}

double* ProjectiveSystemFunctionDerivate::getOutput() {
    return output;
}

void ProjectiveSystemFunctionDerivate::evaluate() {    
    evaluateFunction();
    evaluateLinear();
}

void ProjectiveSystemFunctionDerivate::evaluateFunction() {
    function->evaluate();
}

ISystemFunctionDerivate* ProjectiveSystemFunctionDerivate::getInternalFunction() {
    return function;
}

void ProjectiveSystemFunctionDerivate::evaluateLinear() {
    double* v = &input[dimension];
    double* df = &output[dstart];
    double* o = &output[vstart];

    for (int i=0; i<dimension; i++) {
        o[i] = 0;            
        for (int j=0; j<dimension; j++) {
            o[i] += df[i*dimension + j] * v[j];
        }
    }
}

double inline ProjectiveSystemFunctionDerivate::Abs(double x) {
    return (x>0) ? x : -x;
}

double inline ProjectiveSystemFunctionDerivate::Max(double x, double y) {
    return (x>y)? x: y;
}


double ProjectiveSystemFunctionDerivate::encode(const double* input, double* output) {
    double v = input[0];
    for (int i=1; i<dimension; i++) {
        if (Abs(v) < Abs(input[i])) {
            v = input[i];
        }
    }

    for (int i=0; i<dimension; i++) {
        output[i] = input[i] / v;
    }
    return v;
}


}