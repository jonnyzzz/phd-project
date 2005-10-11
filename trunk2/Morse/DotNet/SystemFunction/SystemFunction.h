#include "ISystemFunction.h"

#include <list>
using namespace std;

#include "../calculator/FunctionFactory.h"
#include "../calculator/SystemNative.h"

class SystemFunction :
    public ISystemFunction
{
public:
    SystemFunction(FunctionFactory* factory, int dimension, int iterations = 1);
    virtual ~SystemFunction(void);

public:
    virtual FunctionFactory* getFactory();

    virtual double* getInput();
    virtual double* getOutput();
    
    virtual void evaluate();

public:
    virtual bool isNative() { return true;}
    virtual bool hasFunction() { return true;}
    virtual bool hasDerivative() { return false;}

private:
    typedef list<SystemNative*> ComputationChain;
    typedef list<double*> DoubleGarbage;

private:
    ComputationChain computationChain;
    DoubleGarbage doubleGarbage;
    
    FunctionFactory* factory;
    
private:
    SystemNativeFunctions createFunctionsList();
    SystemNativeVariables createVariablesList();

    double* allocateDoubleArray(size_t len);

    void init();
};
