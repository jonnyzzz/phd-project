#pragma once


class FunctionNative;
class FunctionFactory;


class OptimizedFunction
{
public:
	static const char FunctionName[];
	static const char VariableName[];

public:
	OptimizedFunction(FunctionFactory* factory);
	virtual ~OptimizedFunction(void);

private:
	FunctionFactory* factory;

	uchar** function;
	uchar*** dfunction;

	int dimension;

	double* variable;

private:
	double call(uchar* address);
	
	uchar* writeCallFunction(uchar* code, void* function);
	uchar* compileDWord(uchar* code, uint value);


};
