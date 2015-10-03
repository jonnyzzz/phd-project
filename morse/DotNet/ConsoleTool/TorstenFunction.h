#include "../SystemFunction/ISystemFunctionDerivate.h"

class Graph;


class TorstenFunction :
	public ISystemFunction
{
public:
	TorstenFunction(void);
	TorstenFunction(double* input, double* output);
	virtual ~TorstenFunction(void);

public:
	virtual double* getInput() { return input;}
	virtual double* getOutput() {return output;} //f1, f2, ...

    virtual void evaluate();

public:
	virtual bool isNative() {return true;}
	virtual bool hasFunction() {return true;}
	virtual bool hasDerivative() {return false;}	

	virtual int getFunctionDimension();

private:
	double* input;
	double* output;
	bool selfCreated;

public:
	static double beta;
	static double d;
	static double m;
};

class TorstenFunctionDerivate : public ISystemFunctionDerivate {
public:
	TorstenFunctionDerivate();
	TorstenFunctionDerivate(double* input, double* output);
	virtual ~TorstenFunctionDerivate();
public:
	virtual double* getInput() { return input;}
	virtual double* getOutput() {return output;} //f1, f2, ...

    virtual void evaluate();

public:
	virtual bool isNative() {return true;}
	virtual bool hasFunction() {return true;}
	virtual bool hasDerivative() {return false;}	

	virtual int getFunctionDimension();

private:
	double* input;
	double* output;
	bool selfCreated;
public:
	static double beta;
	static double d;
	static double m;

};




class TorstenFactory {
public:
	ISystemFunction* Create(double* in, double* out) {
		return new TorstenFunction(in, out);
	}

	static const int Dim;	

	static Graph* CreateGraph();
	static Graph* CreateGraphEx();
	
	static void Dump();

};




