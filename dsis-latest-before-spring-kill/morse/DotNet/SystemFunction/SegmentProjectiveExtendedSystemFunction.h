#pragma once
#include "ISystemFunctionDerivate.h"
#include "segmentprojectiveextendedsystemfunctionbase.h"

class SegmentProjectiveExtendedSystemFunction :
    public ISystemFunctionDerivate, 
	public SegmentProjectiveExtendedSystemFunctionBase
{
public:
	SegmentProjectiveExtendedSystemFunction(ISystemFunctionDerivate* function, ISystemFunction* baseFunction);
    virtual ~SegmentProjectiveExtendedSystemFunction(void);

public:
    virtual double* getInput();
    virtual double* getOutput();

    virtual void evaluate();
    virtual int getFunctionDimension();

public:
	ISystemFunction* GetBaseFunction();	
	ISystemFunction* GetProjectiveFunction();

	void SetProjectiveCenter();

public:
    virtual bool isNative() { return true; }
    virtual bool hasFunction() { return true; }
    virtual bool hasDerivative() { return true; }

private:
	int real_dimension;

	ISystemFunction* base;
    ISystemFunctionDerivate* function;
	ISystemFunction* projective;
    

    double* input;
    double* output;

    int function_dimension;

};
