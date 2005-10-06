#pragma once
#include "ISystemFunction.h"

template<class FunctionFactory, int cnt>
class IteratatedSystemFunction :
	public ISystemFunction
{
private:
	double data[cnt+1][FunctionFactory::Dim];
	ISystemFunction* funcs[cnt];

public:
	IteratatedSystemFunction() : ISystemFunction(FunctionFactory::Dim, cnt) {
		for (int i=0; i<cnt;i++) {
			funcs[i] = FunctionFactory().Create(data[i], data[i+1]);
		}
	}
	virtual ~IteratatedSystemFunction(void) {
		for (int i=0; i<cnt; i++) {
			delete funcs[i];
		}
	}


public:
	virtual double* getInput() { return data[0];} ;
	virtual double* getOutput() {return data[cnt];} //f1, f2, ...
	virtual void evaluate(){
		for (int i=0; i<cnt; i++) {
			funcs[i]->evaluate();
		}		
	};


public:
	virtual bool isNative() {return true;}
	virtual bool hasFunction() {return true;}
	virtual bool hasDerivative() {return false;}

};
