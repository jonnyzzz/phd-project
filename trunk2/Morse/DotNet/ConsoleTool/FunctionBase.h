
#ifndef _CONSOLE_TOOL_FUNCTIONBASE_H
#define _CONSOLE_TOOL_FUNCTIONBASE_H

#include "../SystemFunction/ISystemFunction.h"

class FunctionBase : public ISystemFunction
{
public:
	FunctionBase(int dim, int iter);
	FunctionBase(int dim, int iter, double* input, double* output);
	virtual ~FunctionBase();

public:
    virtual double* getInput();
    virtual double* getOutput(); //f1, f2, ...

protected:
	double* input;
	double* output;

private:
	bool selfCreated;
};

#endif
