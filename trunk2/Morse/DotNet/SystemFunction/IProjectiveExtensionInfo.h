#pragma once


class Graph;
class IMorseFunction;
class ISystemFunction;
class AbstractGraphCreator;
class ISystemFunctionDerivate;

class IProjectiveExtensionInfo
{
public:
    IProjectiveExtensionInfo(ISystemFunctionDerivate* function);
    virtual ~IProjectiveExtensionInfo(void);

public:
    virtual int extendedGraphDimension() = 0;
    virtual AbstractGraphCreator* graphExtender(Graph* graph, int* factor) = 0;

    virtual IMorseFunction* morseFunction() = 0;
    virtual ISystemFunctionDerivate* systemFunction() = 0;
    

protected:
    ISystemFunctionDerivate* function;
};
