#pragma once

#include "AdaptiveProcessBase.h"

class MSAnglePointGraphProcessor;
class ISystemFunction;
class ISystemFunctionDerivate;


class MSAngleProcess :
	public AdaptiveProcessBase
{
public:
	MSAngleProcess(ISystemFunction* function, ISystemFunctionDerivate* dfunction, Graph* graph, JInt* division, double* precision, ProgressBarInfo* info);
	virtual ~MSAngleProcess(void);


protected:
	void processResultNode(Node* node);


private:
	MSAnglePointGraphProcessor* msp;
};
