#include "StdAfx.h"
#include ".\isystemfunction.h"

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

int ISystemFunction::getIteration() {
    return iterations;
}
