#pragma once
#include "isystemfunctionDerivate.h"

#include <list>
using namespace std;

#include "../calculator/FunctionFactory.h"
#include "../calculator/SystemNative.h"


class SystemFunctionDerivate :
    public ISystemFunctionDerivate
{
public:
    SystemFunctionDerivate(FunctionFactory* factory, int dimension, int iterations);

    virtual ~SystemFunctionDerivate(void);

public:
    virtual double* getInput(); //x1....xn
    virtual double* getOutput(); //f1...fn, df1f/dx1,df1/dx2,....,df2/dx1,df2/dx2,....

    virtual void evaluate();

    virtual int getFunctionDimension();

public:
    virtual bool isNative() { return true;}
    virtual bool hasFunction() { return true;}
    virtual bool hasDerivative() { return true;}

private:
    typedef list<SystemNative*> ComputationChain;
    typedef list<double*> DoubleGarbage;
    ComputationChain computationChain;
    DoubleGarbage doubleGarbage;

private:

    double* allocateDoubleArray(size_t size);

    SystemNativeFunctions createFunction();
    SystemNativeFunctions createFunctionDerivate();
    SystemNativeVariables createVariables();

    void matrixMUL(double* a, double* b);
    void matrixMUL(double* ret, double* a, double* b);


    void init();

private:
    int real_dimension;
    double* temp;

    FunctionFactory* factory;
};
