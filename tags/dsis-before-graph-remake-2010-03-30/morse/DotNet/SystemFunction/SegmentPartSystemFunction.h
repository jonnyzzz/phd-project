#pragma once
#include "ISystemFunction.h"
#include "ISystemFunctionDerivate.h"
#include "segmentprojectiveextendedsystemfunctionbase.h"

class SegmentPartSystemFunction :
	public ISystemFunction,
	public SegmentProjectiveExtendedSystemFunctionBase
{
public:
	SegmentPartSystemFunction(ISystemFunctionDerivate* function);
	virtual ~SegmentPartSystemFunction(void);

public:
    virtual double* getInput();
    virtual double* getOutput(); //f1, f2, ...

    virtual void evaluate();

public:
	virtual bool isNative() {return true; }
	virtual bool hasFunction() {return true; }
	virtual bool hasDerivative(){ return false; }	

private:
	const int dimension;

	const ISystemFunction* function;

	double* input;
	double* output;

	double* finput;
	double* foutput;
};
