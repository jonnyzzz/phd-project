#include "StdAfx.h"
#include ".\imorsefunction.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


IMorseFunction::IMorseFunction(ISystemFunctionDerivate* function) : 
    ISystemFunction(1, 1)
{
    this->function = function;
}

IMorseFunction::~IMorseFunction(void)
{
}
