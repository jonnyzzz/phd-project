#pragma once
#include "abstractboxprocess.h"

class SimpleBoxProcess :
	public AbstractBoxProcess
{
public:
	SimpleBoxProcess(Graph* graph, ISystemFunction* function, int* factor, ProgressBarInfo* pinfo);
	virtual ~SimpleBoxProcess(void);



protected:
	virtual void processNodeAndImage(JDouble* value_min, JDouble* value_max, Node* node, Graph* graph_result);
};
