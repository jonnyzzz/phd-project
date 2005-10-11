#include "ISystemFunctionDerivate.h"

class SegmentProjectiveExtendedSystemFunction :
    public ISystemFunctionDerivate
{
public:
    SegmentProjectiveExtendedSystemFunction(ISystemFunctionDerivate* function);
    virtual ~SegmentProjectiveExtendedSystemFunction(void);

public:
    virtual double* getInput();
    virtual double* getOutput();

    virtual void evaluate();
    virtual int getFunctionDimension();

public:
    virtual bool isNative() { return true; }
    virtual bool hasFunction() { return true; }
    virtual bool hasDerivative() { return true; }

private:
    ISystemFunction* function;
    int real_dimension;

private:
    void computeEx(double* v, double* d, double* output);
    double Abs(double x);

    double* input;
    double* output;

    int function_dimension;

};
