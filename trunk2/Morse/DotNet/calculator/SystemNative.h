#pragma once

#include "FunctionNode.h"
#include "FunctionNative.h"

#include <list>
typedef list<FunctionNode*> SystemNativeFunctions;
typedef FunctionNativeVariableSequence SystemNativeVariables;


class SystemNative
{
public:
    SystemNative(SystemNativeFunctions& funcnction, SystemNativeVariables& variables, double* input, double* output);
    virtual ~SystemNative(void);

public:
    void evaluate();

    double* getInput();
    double* getOutput();

private:
    typedef list<FunctionNative*> FunctionNatives;

private:
    double* input;
    double* output;

    SystemNativeFunctions functions;
    SystemNativeVariables variables;
    FunctionNatives natives;

};
