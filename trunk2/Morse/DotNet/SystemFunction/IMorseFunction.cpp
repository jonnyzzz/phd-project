#include "StdAfx.h"
#include ".\imorsefunction.h"

IMorseFunction::IMorseFunction(ISystemFunctionDerivate* function) : 
    ISystemFunction(1, 1)
{
    this->function = function;
}

IMorseFunction::~IMorseFunction(void)
{
}
