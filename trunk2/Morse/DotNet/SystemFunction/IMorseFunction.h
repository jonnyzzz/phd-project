#pragma once
#include "ISystemFunction.h"
#include "ISystemFunctionDerivate.h"

class IMorseFunction :
    public ISystemFunction
{
public:
    IMorseFunction(ISystemFunctionDerivate* function);
    virtual ~IMorseFunction(void);

protected:
    ISystemFunctionDerivate* function;
};
