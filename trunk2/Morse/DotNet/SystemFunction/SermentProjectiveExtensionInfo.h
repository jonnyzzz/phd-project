#pragma once
#include "iprojectiveextensioninfo.h"

class ProgressBarInfo;
class SegmentProjectiveExtendedSystemFunction;
class SegmentProjectiveExtensionMorseFunction;


class SermentProjectiveExtensionInfo :
    public IProjectiveExtensionInfo
{
public:
    SermentProjectiveExtensionInfo(ISystemFunctionDerivate* function);
    virtual ~SermentProjectiveExtensionInfo(void);


public:
    virtual AbstractGraphCreator* graphExtender(Graph* graph, int* factor, ProgressBarInfo* info);
	virtual AbstractProcess* nextStepProcess(Graph* graph, int* factor, int* ks, ProgressBarInfo* info);
	virtual CRom* morse(Graph* graph);

    virtual int extendedGraphDimension();
	/*
    virtual ISystemFunctionDerivate* systemFunction();
    virtual IMorseFunction* morseFunction();
	*/


private: 
	SegmentProjectiveExtendedSystemFunction* systemFunction;
	SegmentProjectiveExtensionMorseFunction* morseFunction;
};
