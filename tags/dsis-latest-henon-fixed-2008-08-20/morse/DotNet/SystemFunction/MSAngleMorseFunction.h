#pragma once
#include "ISystemFunctionDerivate.h"
#include "IMorseFunction.h"

class MSAngleMorseFunction :
    public IMorseFunction
{
public:
    MSAngleMorseFunction(ISystemFunctionDerivate* function);
    virtual ~MSAngleMorseFunction(void);

    virtual double* getInput();
    virtual double* getOutput(); //f1, f2, ...

    virtual void evaluate();

public:
    virtual bool isNative() {return true;}
    virtual bool hasFunction() {return false;}
    virtual bool hasDerivative() {return false;}

private:
    double* input;
    double* output;

	double* tmp;
	double* v;
	double* fdoutput;

	const int f_dimension;

private:
    double Sqr(double x);
};
