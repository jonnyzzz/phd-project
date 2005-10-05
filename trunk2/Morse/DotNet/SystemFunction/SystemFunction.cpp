#include "stdafx.h"
#include "SystemFunction.h"

#include "../calculator/FunctionContext.h"
#include "../calculator/FunctionDictionary.h"
#include "../calculator/FunctionNode.h"
#include "../calculator/FunctionNative.h"
#include "../calculator/SystemNative.h"
#include "../calculator/FunctionFactory.h"
#include "../calculator/FunctionFactoryParseException.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SystemFunction::SystemFunction(FunctionFactory* factory, int dimension, int iterations) : ISystemFunction(dimension, iterations)
{
    this->factory = factory;

    init();    
}

SystemFunction::~SystemFunction(void)
{
    for (SystemFunction::ComputationChain::iterator it = computationChain.begin(); it != computationChain.end(); it++) {
        delete *it;
    }
    for (SystemFunction::DoubleGarbage::iterator it = doubleGarbage.begin(); it != doubleGarbage.end(); it++) {
        delete[] *it;
    }

}

FunctionFactory* SystemFunction::getFactory() {
    return this->factory;
}


double* SystemFunction::getInput() {
    return computationChain.front()->getInput();
}

double* SystemFunction::getOutput() {
    return computationChain.back()->getOutput();
}

void SystemFunction::evaluate() {
    for (SystemFunction::ComputationChain::iterator it = computationChain.begin(); it != computationChain.end(); it++) {
        (*it)->evaluate();
    }
}
////////////////////////////////////////////////////////////////////////////////////

SystemNativeFunctions SystemFunction::createFunctionsList() {
    char buff[255];
    const char name[] = "y%d";

    SystemNativeFunctions funcs;
    for (int i=1; i<=dimension; i++) {
        sprintf(buff, name, i);
        FunctionNode* node = this->factory->getEquation(buff);
        if (node == NULL) {
            char b[512];
            sprintf(b, "Expected variable %s", buff);
            throw FunctionFactoryParseException(FunctionFactoryParseException_NoSuchEquation, b);
        }
        funcs.push_back(node->simplify());
        delete node;
    }
    return funcs;
}

SystemNativeVariables SystemFunction::createVariablesList() {
    char buff[255];
    const char name[] = "x%d";

    SystemNativeVariables vars;
    FunctionDictionary* dic = factory->getFunctionDictionary();
    
    for (int i=1; i<=dimension; i++) {
        sprintf(buff, name, i);        
        vars.push_back(dic->registerVariable(buff));
    };

    return vars;
}

double* SystemFunction::allocateDoubleArray(size_t len) {
    double* ret = new double[len];
    this->doubleGarbage.push_back(ret);
    return ret;
}

void SystemFunction::init() {

    SystemNativeVariables vars = this->createVariablesList();
    SystemNativeFunctions funcs = this->createFunctionsList();

    ASSERT(vars.size() == funcs.size());

    SystemNative* native = new SystemNative(funcs, vars, allocateDoubleArray(vars.size()*3), allocateDoubleArray(funcs.size()*3));
    computationChain.push_back(native);

    cout<<"Iterations = "<<iterations<<"\n";
    
    for (int i=1; i<iterations; i++) {
        native = new SystemNative(funcs, vars, computationChain.back()->getOutput(), allocateDoubleArray(funcs.size()*3));
        computationChain.push_back(native);
    }
    
    for (SystemNativeFunctions::iterator it = funcs.begin(); it != funcs.end(); it++) {
        delete *it;
    }
    
}

