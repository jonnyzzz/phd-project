#include "StdAfx.h"
#include ".\segmentpartsystemfunction.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SegmentPartSystemFunction::SegmentPartSystemFunction(ISystemFunctionDerivate* function) 
: function(function), 
  dimension(function->getFunctionDimension()),
  finput(function->getInput()),
  foutput(function->getOutput()),  
  SegmentProjectiveExtendedSystemFunctionBase(function->getFunctionDimension()),
  ISystemFunction(function->getFunctionDimension(), 1)
{
	input = new double[dimension*3];
	output = new double[dimension*3];
}

SegmentPartSystemFunction::~SegmentPartSystemFunction(void)
{
	delete[] input;
	delete[] output;
}


double* SegmentPartSystemFunction::getInput() {
	return input;
}

double* SegmentPartSystemFunction::getOutput() {
	return output;
}


void SegmentPartSystemFunction::evaluate() {
	computeEx(
        input, 
        &foutput[dimension], 
        output
        );	
}