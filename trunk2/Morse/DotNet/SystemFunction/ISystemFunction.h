#pragma once

class ISystemFunction
{
public:
    ISystemFunction(int dimension, int iterations);
    virtual ~ISystemFunction(void);

public:
    virtual int getDimension();
    virtual int getIteration();


    virtual double* getInput() = 0;
    virtual double* getOutput() = 0; //f1, f2, ...

    virtual void evaluate() = 0;

public:
    virtual bool isNative() = 0;
    virtual bool hasFunction() = 0;
    virtual bool hasDerivative() = 0;	

protected:
    int dimension;
    int iterations;
};
