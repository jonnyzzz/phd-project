#include "ISystemFunction.h"
#include "ISystemFunctionDerivate.h"


class MSAngleFunction :
	public ISystemFunction
{
public:
	MSAngleFunction(ISystemFunctionDerivate* function);
	virtual ~MSAngleFunction(void);

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
	double Atan2(double y, double x);


private:
	ISystemFunctionDerivate* function;

	int dimension;

	double* input;
	double* output;

	double* tmp;
	double* v;

	double* fdoutput;
	double* finput;
	double* foutput;


};