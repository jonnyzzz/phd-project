#include "StdAfx.h"
#include ".\ms2danglefunction.h"

MS2DAngleFunction::MS2DAngleFunction(ISystemFunctionDerivate* function)
: function(function), ISystemFunction(3, 1)
{
    VERIFY(function->getDimension() == 2);
    input = function->getInput();
    output = function->getOutput();
}

MS2DAngleFunction::~MS2DAngleFunction(void)
{    
}


double* MS2DAngleFunction::getInput() {
    return input;
}

double* MS2DAngleFunction::getOutput() {
    return output;
}

double inline MS2DAngleFunction::Abs(double x) {
    return (x>0)?x:-x;
}

double inline MS2DAngleFunction::Atan(double v) {
    return atan(v);
}

const double MS2DAngleFunction::cE = 1e-8;

double inline MS2DAngleFunction::dF(int i, int j) {
    return output[2 + 2*i + j];
}

void MS2DAngleFunction::evaluate() {
    evaluateFunction();
    evaluateAngle();
}

void MS2DAngleFunction::evaluateFunction() {
    function->evaluate();
}

double MS2DAngleFunction::evaluateAngle() {
    double alpha = input[2];

    if ( Abs(alpha - M_PI_2) < cE){ //alpha=+-PI/2
        double d01;
        if ( Abs(d01 = dF(0,1)) < cE ){
            if ( Abs( dF(1,1) )<cE ){ 
                double d00;
                if (Abs( d00 = dF(0,0) )<cE){ // 0/0 constant expression
                    output[2] = M_PI_2;                    
                } else {
                    output[2] = Atan(dF(1,0)/d00);
                }
            } else {
                output[2] = M_PI_2;
            }
        } else {
            output[2] = Atan(dF(1,1) / d01);
        }
    }else {
        double d = dF(0,0)+ dF(0,1) * tan(alpha);
        if (Abs(d) < cE){
            output[2] = M_PI_2;       
        } else {
            output[2] = Atan( (dF(1,0)+dF(1,1) * tan(alpha))/d);
        }
    }

    return output[2];
}
