#include "ISystemFunction.h"
#include "ISystemFunctionDerivate.h"


class MSNormedFunction :
	public ISystemFunction
{
public:
	MSNormedFunction(ISystemFunctionDerivate* function);
	virtual ~MSNormedFunction(void);


public:
    virtual double* getInput();
    virtual double* getOutput(); //f1, f2, ...

    virtual void evaluate();

public:
	virtual bool isNative() { return true; }
	virtual bool hasFunction() { return false; }
	virtual bool hasDerivative() { return false; }

private:
	double Abs(double x);

	void MakeZeroIfNeeded(double& x);

private:
	ISystemFunctionDerivate* function;

	int dimension;

	double* input;
	double* output;
	double* tmp;
	double* v;

	double* finput;
	double* foutput;
	double* fdoutput;

};