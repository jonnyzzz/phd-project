#include "AbstractBoxProcess.h"

class SimpleBoxProcess :
	public AbstractBoxProcess
{
public:
	SimpleBoxProcess(Graph* graph, ISystemFunction* function, int* factor, ProgressBarInfo* pinfo, bool isInverted = false);
	virtual ~SimpleBoxProcess(void);



protected:
	virtual void processNodeAndImage(JDouble* value_min, JDouble* value_max, Node* node, Graph* graph_result);

private:
	bool isInverted;
};
