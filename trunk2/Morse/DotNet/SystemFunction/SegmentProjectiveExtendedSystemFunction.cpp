#include "StdAfx.h"
#include ".\segmentprojectiveextendedsystemfunction.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


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
        &input[real_dimension], 
        &output[real_dimension], 
        &output[function_dimension]
        );
}


///////////////////////////////////////////////////////////////////////////////////

double inline SegmentProjectiveExtendedSystemFunction::Abs(double x) {
    return (x>0)?x:-x;
}

void SegmentProjectiveExtendedSystemFunction::computeEx(double* v, double* d, double* output) {
    //v - vector v
    //d - differential vector
    //output - vector v

	//cout<<"real dim = "<<real_dimension<<"\n";

    int amax = 0;
    for (int i=0; i<real_dimension; i++) {
        output[i] = 0;
        for (int j=0; j<real_dimension; j++) {
            output[i] += d[i*real_dimension + j] * v[j];
        }
        if (Abs(output[amax]) < Abs(output[i])) {
            amax = i;
        }
    }

	//cout<<"max = "<<amax<<"\n";

    for (int i=0; i<real_dimension; i++) {
       output[i] /= output[amax];
    }
}