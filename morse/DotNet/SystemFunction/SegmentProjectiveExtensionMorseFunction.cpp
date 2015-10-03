#include "stdafx.h"
#include "SegmentProjectiveExtensionMorseFunction.h"
#include <math.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SegmentProjectiveExtensionMorseFunction::SegmentProjectiveExtensionMorseFunction(ISystemFunctionDerivate* function) :
IMorseFunction(function)
{
	this->dimension = function->getFunctionDimension();

    this->output = function->getOutput();    
    this->doutput = &this->output[dimension];

    this->input = function->getInput();
	this->vinput = &this->input[dimension];

	cout<<"Dimenstion = "<<dimension<<"\n";
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

double SegmentProjectiveExtensionMorseFunction::Abs(double x) {
	return x > 0 ? x : -x;
}

void SegmentProjectiveExtensionMorseFunction::evaluate() {
    function->evaluate();
    evaluation_result = 0;

    double norm = 0;
    for (int i=0; i<dimension; i++) {
        norm += this->vinput[i] * this->vinput[i];
    }
    for (int i=0; i<dimension; i++) {
        double tmp = 0;        
        for (int j=0; j<dimension; j++) {
            tmp += doutput[i*dimension + j] * this->vinput[j];
        }
        evaluation_result += tmp*tmp;
    }

	//cout<<"Eval = "<<evaluation_result<<"\n";
	//cout<<"NormV = "<<norm<<"\n";

    evaluation_result = log(evaluation_result/norm)/2;
}
