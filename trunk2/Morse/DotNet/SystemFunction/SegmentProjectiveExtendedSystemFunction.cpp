#include "StdAfx.h"
#include ".\segmentprojectiveextendedsystemfunction.h"

SegmentProjectiveExtendedSystemFunction::SegmentProjectiveExtendedSystemFunction(ISystemFunctionDerivate* function)
:
    ISystemFunctionDerivate(
                  function->getDimension() + function->getFunctionDimension(), 
                  function->getIteration()
    ),
    function(function), 
    real_dimension(function->getFunctionDimension()),
    output(function->getOutput()),
    input(function->getInput()),
    function_dimension(function->getDimension())
{

}

SegmentProjectiveExtendedSystemFunction::~SegmentProjectiveExtendedSystemFunction(void)
{
}


double* SegmentProjectiveExtendedSystemFunction::getInput() {
    return input;
}

double* SegmentProjectiveExtendedSystemFunction::getOutput() {
    return output;
}

int SegmentProjectiveExtendedSystemFunction::getFunctionDimension() {
    return real_dimension;
}

void SegmentProjectiveExtendedSystemFunction::evaluate() {
    function->evaluate();
    computeEx(
        &input[function_dimension], 
        &output[real_dimension], 
        &output[function_dimension]
        );
}


///////////////////////////////////////////////////////////////////////////////////

double SegmentProjectiveExtendedSystemFunction::Abs(double x) {
    return (x>0)?x:-x;
}

void SegmentProjectiveExtendedSystemFunction::computeEx(double* v, double* d, double* output) {
    //v - vector v
    //d - differential vector
    //output - vector v

    int max = 0;
    for (int i=0; i<real_dimension; i++) {
        output[i] = 0;
        for (int j=0; j<real_dimension; j++) {
            output[i] += d[j*real_dimension + i] * v[j];
        }
        if (Abs(output[max]) < Abs(output[i])) {
            max = i;
        }
    }
    for (int i=0; i<real_dimension; i++) {
        output[i] /= output[max];
    }
}