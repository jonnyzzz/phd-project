#pragma once
#include "ISystemFunctionDerivate.h"

class ProjectiveSystemFunctionDerivate :
    public ISystemFunctionDerivate
{
public:
    ProjectiveSystemFunctionDerivate(ISystemFunctionDerivate* derivate);
    virtual ~ProjectiveSystemFunctionDerivate(void);

public:
    virtual int getFunctionDimension() = 0;

    virtual double* getInput();
    virtual double* getOutput(); //f1, f2, ...

    virtual void evaluate();

    void evaluateFunction();
    void evaluateLinear();

    double encode(const double* input, double* output);

    ISystemFunctionDerivate* getInternalFunction();

public:
    virtual bool isNative() { return true; }
    virtual bool hasFunction() { return true; }
    virtual bool hasDerivative() {return true; }	


private:
    double* input;
    double* output;

    int dimension;
    int dstart;
    int vstart;

    ISystemFunctionDerivate* function;

private:
    double Abs(double d);
    double Max(double x, double y);

};
