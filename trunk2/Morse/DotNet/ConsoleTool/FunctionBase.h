
#ifndef _CONSOLE_TOOL_FUNCTIONBASE_H
#define _CONSOLE_TOOL_FUNCTIONBASE_H

#include "../SystemFunction/ISystemFunction.h"
#include "../SystemFunction/ISystemFunctionDerivate.h"

class FunctionBase : public ISystemFunction
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

public:
	virtual bool isNative() {return true;};
	virtual bool hasFunction() {return true;};
	virtual bool hasDerivative() {return false;};	
};

class FunctionBaseDerivate : public ISystemFunctionDerivate
{
public:
	FunctionBaseDerivate(int dim, int iter);
	FunctionBaseDerivate(int dim, int iter, double* input, double* output);
	virtual ~FunctionBaseDerivate();

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
	int dim;

public:
	virtual bool isNative() {return true;};
	virtual bool hasFunction() {return true;};
	virtual bool hasDerivative() {return true;};	
};


#endif
