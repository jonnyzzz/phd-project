#pragma once

#ifndef _ISYSTEMFUNCTIONDERIVATE_h
#define _ISYSTEMFUNCTIONDERIVATE_h

#include "ISystemFunction.h"

class ISystemFunctionDerivate :
    public ISystemFunction
{
public:

    ISystemFunctionDerivate(int dimension, int iterations);
    virtual ~ISystemFunctionDerivate(void);


public:
     virtual int getFunctionDimension() = 0;
};

#endif
