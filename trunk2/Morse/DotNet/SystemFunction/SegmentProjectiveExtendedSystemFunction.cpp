#include "stdafx.h"
#include "SegmentProjectiveExtendedSystemFunction.h"
#include "SegmentPartSystemFunction.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SegmentProjectiveExtendedSystemFunction::SegmentProjectiveExtendedSystemFunction(ISystemFunctionDerivate* function, ISystemFunction* base)
:
    ISystemFunctionDerivate(
                  function->getDimension() + function->getFunctionDimension(), 
                  function->getIteration()
    ),
    function(function), 
    real_dimension(function->getFunctionDimension()),
    input(function->getInput()),
    output(function->getOutput()),
    function_dimension(function->getDimension()),
	SegmentProjectiveExtendedSystemFunctionBase(function->getFunctionDimension()),
	base(base),
	projective(new SegmentPartSystemFunction(function))	
{

}

SegmentProjectiveExtendedSystemFunction::~SegmentProjectiveExtendedSystemFunction(void)
{
	delete projective;
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


ISystemFunction* SegmentProjectiveExtendedSystemFunction::GetBaseFunction() {
	return this->base;
}


void SegmentProjectiveExtendedSystemFunction::SetProjectiveCenter() {
	function->evaluate();
}

ISystemFunction* SegmentProjectiveExtendedSystemFunction::GetProjectiveFunction() {
	return this->projective;
}
