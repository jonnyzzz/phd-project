#include "IMorseFunction.h"
#include "ISystemFunctionDerivate.h"

class MS2DAngleMorseFunction :
    public IMorseFunction
{
public:
    MS2DAngleMorseFunction(ISystemFunctionDerivate* function);
    virtual ~MS2DAngleMorseFunction(void);

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

private:
    double dF(int x, int y);
    double Sqr(double x);
};
