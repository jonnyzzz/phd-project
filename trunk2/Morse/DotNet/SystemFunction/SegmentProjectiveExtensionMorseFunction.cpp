#include "StdAfx.h"
#include ".\segmentprojectiveextensionmorsefunction.h"
#include <math.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SegmentProjectiveExtensionMorseFunction::SegmentProjectiveExtensionMorseFunction(ISystemFunctionDerivate* function) :
IMorseFunction(function)
{
    this->output = function->getOutput();
    this->dimension = function->getFunctionDimension();
    this->doutput = &this->output[dimension];
    this->input = function->getInput();
}

SegmentProjectiveExtensionMorseFunction::~SegmentProjectiveExtensionMorseFunction(void)
{
}


double* SegmentProjectiveExtensionMorseFunction::getInput() {
    return input;
}

double* SegmentProjectiveExtensionMorseFunction::getOutput() {
    return &evaluation_result;
}


void SegmentProjectiveExtensionMorseFunction::evaluate() {
    function->evaluate();
    evaluation_result = 0;

    double norm = 0;
    for (int i=0; i<dimension; i++) {
        norm += this->input[dimension + i] * this->input[dimension + i];
    }
    for (int i=0; i<dimension; i++) {
        double tmp = 0;        
        for (int j=0; j<dimension; j++) {
            tmp += doutput[i*dimension + j] * this->input[dimension + j];
        }
        evaluation_result += tmp*tmp;
    }
    evaluation_result = log(evaluation_result/norm)/2;
}