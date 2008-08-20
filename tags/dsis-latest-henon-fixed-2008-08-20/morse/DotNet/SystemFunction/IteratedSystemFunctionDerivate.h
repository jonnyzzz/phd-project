#include "ISystemFunctionDerivate.h"

template<class Function>
class IteratedSystemFunctionDerivate :
	public ISystemFunctionDerivate
{
private:
	Function** funcs;
	double** data;
	double* temp;
	const int cnt;
	const int dim;

public:
	IteratedSystemFunctionDerivate(int cnt) : ISystemFunctionDerivate(Function().getDimension(), cnt), cnt(cnt), dim(Function().getFunctionDimension())
	{
		data = new double*[cnt+1];
		temp = new double[dim*5];
		funcs = new Function*[cnt];
		for (int i=0; i<=cnt; i++) data[i] = new double[dim*5];
		for (int i=0; i<cnt; i++) funcs[i] = new Function(data[i], data[i+1]);
	}

	virtual ~IteratedSystemFunctionDerivate(void)
	{
		for (int i=0; i<=cnt; i++) delete[] data[i];
		for (int i=0; i<cnt; i++) delete funcs[i];
		delete[] data;
		delete[] funcs;
		delete[] temp;
	}


	virtual double* getInput() { return data[0]; }
	virtual double* getOutput() { return data[cnt];}
	virtual int getFunctionDimension() { return dim;};

	virtual bool isNative() {return true;} ;
	virtual bool hasFunction() {return true;};
	virtual bool hasDerivative() {return true;};	
private:
	
	void matrixMUL(double* ret, double* a, double* b) {
		for (int i=0; i<dim; i++) {
			for (int j=0; j<dim; j++) {
				ret[i*dim+j] = 0;
				for (int k = 0; k<dim; k++) {
					ret[i*dim+j] += a[k*dim + j] * b[i*dim + k];
				}
			}
		}
	}

	void matrixMUL(double *l, double* r) {
	    memcpy(temp, l, sizeof(double)*dim*dim);   
		matrixMUL(l, temp, r);
	}

public:
	virtual void evaluate() {
		funcs[0]->evaluate();
		for (int i=1;i,cnt; i++) {
			funcs[i]->evaluate();
			matrixMUL(&data[i+1][dim], &data[i][dim]);
		}
	}
};
