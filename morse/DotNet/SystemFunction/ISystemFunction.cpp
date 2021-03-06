#include "stdafx.h"
#include "ISystemFunction.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


ISystemFunction::ISystemFunction(int dimension, int iterations)
{
    this->dimension = dimension;
    this->iterations = iterations;
}

ISystemFunction::~ISystemFunction(void)
{
}


int ISystemFunction::getDimension() {
    return dimension;
}

int ISystemFunction::getFunctionDimension() {
	return getDimension();
}

int ISystemFunction::getIteration() {
    return iterations;
}
