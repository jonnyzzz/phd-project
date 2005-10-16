#ifndef _CELLIMAGEBUILDERS_MS2DANGLEFUNCTION_H
#define _CELLIMAGEBUILDERS_MS2DANGLEFUNCTION_H

#include "ISystemFunction.h"
#include "ISystemFunctionDerivate.h"
#include "../graph/typedefs.h"

class MS2DAngleFunction :
    public ISystemFunction
{
public:
    MS2DAngleFunction(ISystemFunctionDerivate* function);
    virtual ~MS2DAngleFunction(void);

public:
    virtual double* getInput();
    virtual double* getOutput();

    virtual void evaluate();

    void evaluateFunction();
    double evaluateAngle();

public:
    virtual bool isNative() { return false;}
    virtual bool hasFunction() { return true;}
    virtual bool hasDerivative() { return false;}

private:
    ISystemFunctionDerivate* function;

    JDouble* input;
    JDouble* output;

    static const double cE;


private:
    double Abs(double x);
    double Atan(double v);
    double dF(int i, int j);
};

#endif //_CELLIMAGEBUILDERS_MS2DANGLEFUNCTION_H

