#pragma once
#include "iprojectiveextensioninfo.h"

class ProgressBarInfo;


class SermentProjectiveExtensionInfo :
    public IProjectiveExtensionInfo
{
public:
    SermentProjectiveExtensionInfo(ISystemFunctionDerivate* function);
    virtual ~SermentProjectiveExtensionInfo(void);


public:
    virtual AbstractGraphCreator* graphExtender(Graph* graph, int* factor, ProgressBarInfo* info);
    virtual int extendedGraphDimension();

    virtual ISystemFunctionDerivate* systemFunction();
    virtual IMorseFunction* morseFunction();
};
