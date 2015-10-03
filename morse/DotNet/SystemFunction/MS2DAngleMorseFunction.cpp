#include "stdafx.h"
#include "MS2DAngleMorseFunction.h"
#include <cmath>
using namespace std;

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MS2DAngleMorseFunction::MS2DAngleMorseFunction(ISystemFunctionDerivate* function) : IMorseFunction(function)
{
    input = function->getInput();
    output = function->getOutput();
}

MS2DAngleMorseFunction::~MS2DAngleMorseFunction(void)
{
}


double* MS2DAngleMorseFunction::getInput() {
    return input;
}

double* MS2DAngleMorseFunction::getOutput() {
    return output;
}

double inline MS2DAngleMorseFunction::dF(int i, int j) {
    return output[2 + 2*i + j];
}

double inline MS2DAngleMorseFunction::Sqr(double x) {
    return x*x;
}

void MS2DAngleMorseFunction::evaluate() {
    function->evaluate();

    double angle = input[2];

    output[0] = 
        log(
        (
			Sqr( dF(0,0)*cos(angle)+dF(0,1)*sin(angle) ) +
			Sqr( dF(1,0)*cos(angle)+dF(1,1)*sin(angle) ) 
			)
        )/2;
};
