#pragma once
#include "isystemfunction.h"

class ISystemFunctionDerivate :
    public ISystemFunction
{
public:

    ISystemFunctionDerivate(int dimension, int iterations);
    virtual ~ISystemFunctionDerivate(void);


public:

     virtual int getFunctionDimension() = 0;
};
