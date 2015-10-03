#include "stdafx.h"
#include "ISystemFunctionDerivate.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


ISystemFunctionDerivate::ISystemFunctionDerivate(int dimension, int iterations) : ISystemFunction(dimension, iterations)
{
}

ISystemFunctionDerivate::~ISystemFunctionDerivate(void)
{
}
