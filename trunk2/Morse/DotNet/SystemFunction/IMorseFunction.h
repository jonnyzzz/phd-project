#pragma once
#include "isystemfunction.h"
#include "isystemfunctionderivate.h"

class IMorseFunction :
    public ISystemFunction
{
public:
    IMorseFunction(ISystemFunctionDerivate* function);
    virtual ~IMorseFunction(void);
};
