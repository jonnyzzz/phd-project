#pragma once
#include "AdaptiveProcessBase.h"

class MSAdaptivePointGraphProcessor;
class ISystemFunction;
class ISystemFunctionDerivate;


class MSNormedProcess :
	public AdaptiveProcessBase
{
public:
	MSNormedProcess(ISystemFunction* function, ISystemFunctionDerivate* dfunction, Graph* graph, JInt* division, double* precision, ProgressBarInfo* info);
	virtual ~MSNormedProcess(void);


protected:
	void processResultNode(Node* node);


private:
	MSAdaptivePointGraphProcessor* msp;
};
