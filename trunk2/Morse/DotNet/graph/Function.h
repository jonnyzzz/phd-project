#pragma once


class FunctionFacory;
class FunctionNative;


class Function
{
public:
	Function(FunctionFactory* factory, int dimension, int iterations = 1);
	virtual ~Function(void);

public:
	JDouble* getVariables();
	
	JDouble F(int f);
	void	F(JDouble* value);

	JDouble dF(int f, int x);
	void	dF(JDouble* f, JDouble** data);
	void	dF(JDouble** data);

	void t();
	JDouble tF(int f);
	JDouble tdF(int f, int x);

	int getDimension();

private:
	//new implementation
	JDouble iF(int f);
	void iF(JDouble* value);

	JDouble idF(int f, int x);
	void idF(JDouble** value);

public:
	void print();

private:
	FunctionNative** nativeF;
	FunctionNative*** nativeDF;

	FunctionFactory* factory;

	int dimension;
	int iterations;

	JDouble* variables;

	JDouble* x0;
	JDouble** d0;
	JDouble* f0;
	JDouble* ans;
	JDouble** ansD;
	JDouble** ansDD;
	JDouble** ansT;
	JDouble* gx;

public:
	static const char FunctionName[];
	static const char VariableName[];

private: 
	void test();

};

