#pragma once


class Graph;
class IMorseFunction;
class ISystemFunction;
class AbstractGraphCreator;
class ISystemFunctionDerivate;
class ProgressBarInfo;
class AbstractProcess;
class CRom;

class IProjectiveExtensionInfo
{
public:
    IProjectiveExtensionInfo(ISystemFunctionDerivate* function);
    virtual ~IProjectiveExtensionInfo(void);

public:

	virtual int extendedGraphDimension() = 0;

    virtual AbstractGraphCreator* graphExtender(Graph* graph, int* factor, ProgressBarInfo* info) = 0;
	virtual AbstractProcess* nextStepProcess(Graph* graph, int* factor, int* ks, ProgressBarInfo* info) = 0;
	virtual AbstractProcess* nextStepProcess(Graph* graph, int* factor, int* ks, double* offset1, double* offset2, ProgressBarInfo* info) = 0;
	virtual CRom* morse(Graph* graph) = 0;

	/*
    virtual IMorseFunction* morseFunction() = 0;
    virtual ISystemFunctionDerivate* systemFunction() = 0;
	*/    

protected:
    ISystemFunctionDerivate* function;
};
