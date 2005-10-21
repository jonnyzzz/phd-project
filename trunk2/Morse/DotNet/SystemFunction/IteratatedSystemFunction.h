#include "ISystemFunction.h"

template<class Function>
class IteratatedSystemFunction :
	public ISystemFunction
{

private:
	double** data;//[cnt+1][dim*5];
	Function** funcs;//[cnt];
	const int cnt;

public:
	IteratatedSystemFunction(int cnt) : ISystemFunction(Function().getFunctionDimension(), cnt), cnt(cnt) {
		ASSERT(Function().hasDerivate() == false);
		funcs = new Function*[cnt];
		data = new double*[cnt+1];
		for (int i=0; i<=cnt;i++) 
			data[i] = new double[getDimension()*5];
		for (int i=0; i<cnt;i++)
			funcs[i] = new Function(data[i], data[i+1]);
	}
	virtual ~IteratatedSystemFunction(void) {
		for (int i=0; i<cnt; i++) {
			delete funcs[i];
			delete[] data[i];
		}
		delete[] data[cnt];
		delete[] data;
		delete[] funcs;
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

