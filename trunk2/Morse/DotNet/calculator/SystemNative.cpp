#include "StdAfx.h"
#include ".\systemnative.h"

SystemNative::SystemNative(SystemNativeFunctions& functions, SystemNativeVariables& variables, double* input, double* output)
{
    this->input = input;
    this->output = output;

    this->functions = SystemNativeFunctions(functions);
    this->variables = SystemNativeVariables(variables);

    //in case of inconsystencies exception will be thrown by FunctionNative class
    for (SystemNativeFunctions::iterator it = functions.begin(); it!= functions.end(); it++) {
        this->natives.push_back(new FunctionNative((*it)->simplify(), variables, input));
    }

}

SystemNative::~SystemNative(void)
{
    for(SystemNative::FunctionNatives::iterator it = natives.begin(); it != natives.end(); it++) {
        delete *it;
    }
}


void SystemNative::evaluate() {
    int i=0;
    for (SystemNative::FunctionNatives::iterator it = natives.begin(); it != natives.end(); it++, i++) {
        output[i] = (*it)->evaluate();
    }
}

double* SystemNative::getInput() {
    return input;
}

double* SystemNative::getOutput() {
    return output;
}