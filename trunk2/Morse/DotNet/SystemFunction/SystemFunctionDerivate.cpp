#include "StdAfx.h"
#include ".\systemfunctionderivate.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SystemFunctionDerivate::SystemFunctionDerivate(FunctionFactory* factory, int dimension, int iterations) :
ISystemFunctionDerivate(dimension*dimension + dimension, iterations), factory(factory), real_dimension(dimension)  
{
    init();    
}

SystemFunctionDerivate::~SystemFunctionDerivate(void)
{
    for (SystemFunctionDerivate::ComputationChain::iterator it = computationChain.begin();
        it != computationChain.end(); it++) {
            delete *it;
    }
    for (SystemFunctionDerivate::DoubleGarbage::iterator it = doubleGarbage.begin();
        it != doubleGarbage.end(); it++) {
            delete[] *it;
    }
}



double* SystemFunctionDerivate::getInput() {
    return computationChain.front()->getInput();
}

double* SystemFunctionDerivate::getOutput() {
    return computationChain.back()->getOutput();
}


void SystemFunctionDerivate::evaluate() {
    computationChain.front()->evaluate();
    for (SystemFunctionDerivate::ComputationChain::iterator it = ++computationChain.begin();
        it != computationChain.end(); it++) {
            (*it)->evaluate();
            matrixMUL(&(*it)->getOutput()[real_dimension], &(*it)->getInput()[real_dimension]);
    }
}

int SystemFunctionDerivate::getFunctionDimension() {
    return real_dimension;
}   


//////////////////////////////////////////////////////////////////////////////////////////

double* SystemFunctionDerivate::allocateDoubleArray(size_t size) {
    double* ret = new double[size];
    doubleGarbage.push_back(ret);
    return ret;
}

SystemNativeFunctions SystemFunctionDerivate::createFunction() {
    char buff[255];
    const char fname[] = "y%d";

    SystemNativeFunctions funcs;

    for (int i=1; i<=real_dimension; i++) {
        sprintf(buff, fname, i);
        FunctionNode* node = factory->getEquation(buff);
        funcs.push_back(node->simplify());
        delete node;
    }
    return funcs;
}

SystemNativeVariables SystemFunctionDerivate::createVariables() {
    char buff[255];
    const char name[] = "x%d";

    SystemNativeVariables vars;
    FunctionDictionary* dic = factory->getFunctionDictionary();
    
    for (int i=1; i<=real_dimension; i++) {
        sprintf(buff, name, i);        
        vars.push_back(dic->registerVariable(buff));
    };

    return vars;
}

SystemNativeFunctions SystemFunctionDerivate::createFunctionDerivate() {
    SystemNativeFunctions ret;
    SystemNativeFunctions funcs = this->createFunction();
    SystemNativeVariables vars = this->createVariables();
    ret = funcs;

    for (SystemNativeFunctions::iterator fit = funcs.begin(); fit != funcs.end(); fit++) {
        for (SystemNativeVariables::iterator nit = vars.begin(); nit != vars.end(); nit++) {
            FunctionNode* node = (*fit)->diff(*nit);
            ret.push_back(node->simplify());
            delete node;
        }
    }

    return ret;
}


void SystemFunctionDerivate::init() {
    SystemNativeFunctions funcs = this->createFunctionDerivate();
    SystemNativeVariables vars = this->createVariables();

    SystemNative* native = new SystemNative(funcs, vars, allocateDoubleArray(vars.size()*3), allocateDoubleArray(funcs.size()*3));

    computationChain.push_back(native);

    for (int i=1; i<iterations; i++) {
        native = new SystemNative(funcs, vars, computationChain.back()->getOutput(), allocateDoubleArray(funcs.size()*3));
        computationChain.push_back(native);
    }
    temp = allocateDoubleArray(this->dimension*3);

    for (SystemNativeFunctions::iterator it = funcs.begin(); it != funcs.end(); it++) {
        delete *it;
    }
}


void SystemFunctionDerivate::matrixMUL(double *l, double* r) {
    memcpy(temp, l, sizeof(double)*real_dimension*real_dimension);   
    matrixMUL(l, temp, r);
}


void SystemFunctionDerivate::matrixMUL(double* ret, double* a, double*b) {
    for (int i=0; i<real_dimension; i++) {
        for (int j=0; j<real_dimension; j++) {
            ret[i*real_dimension+j] = 0;
            for (int k = 0; k<real_dimension; k++) {
                ret[i*real_dimension+j] += a[k*real_dimension + j] * b[i*real_dimension + k];
            }
        }
    }
}