
#ifndef _CONSOLE_TOOL_FUNCTIONBASE_H
#define _CONSOLE_TOOL_FUNCTIONBASE_H

#include "../SystemFunction/ISystemFunction.h"
#include "../SystemFunction/ISystemFunctionDerivate.h"

class FunctionBase : public ISystemFunctionDerivate
{
public:
	FunctionBase(int dim, int iter);
	FunctionBase(int dim, int iter, double* input, double* output);
	virtual ~FunctionBase();

public:
    virtual double* getInput();
    virtual double* getOutput(); //f1, f2, ...

public:
	virtual int getFunctionDimension();

protected:
	double* input;
	double* output;

private:
	bool selfCreated;
	bool computeDerivate;

public:
	void ComputeDerivate(bool value);

protected:
    bool ComputeDerivate();

public:
	virtual bool isNative() {return true;};
	virtual bool hasFunction() {return true;};
	virtual bool hasDerivative() {return false;};	
};

#endif
