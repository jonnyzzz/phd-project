#pragma once
#include "imorsefunction.h"
#include "isystemfunctionderivate.h"

class SegmentProjectiveExtensionMorseFunction :
    public IMorseFunction
{
public:
    SegmentProjectiveExtensionMorseFunction(ISystemFunctionDerivate* derivate);
    virtual ~SegmentProjectiveExtensionMorseFunction(void);

private:
    double evaluation_result;
    double* output;
    double* doutput;
    double* input;
	double* vinput;
    int dimension;

public:
    virtual double* getInput();
    virtual double* getOutput(); //f1, f2, ...

    virtual void evaluate();

public:
    virtual bool isNative() {return true;}
    virtual bool hasFunction() {return false;}
    virtual bool hasDerivative() {return false;}

};
