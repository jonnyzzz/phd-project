#pragma once
#include "iprojectiveextensioninfo.h"

class SermentProjectiveExtensionInfo :
    public IProjectiveExtensionInfo
{
public:
    SermentProjectiveExtensionInfo(ISystemFunctionDerivate* function);
    virtual ~SermentProjectiveExtensionInfo(void);


public:
    virtual AbstractGraphCreator* graphExtender(Graph* graph, int* factor);
    virtual int extendedGraphDimension();

    virtual ISystemFunctionDerivate* systemFunction();
    virtual IMorseFunction* morseFunction();
};
