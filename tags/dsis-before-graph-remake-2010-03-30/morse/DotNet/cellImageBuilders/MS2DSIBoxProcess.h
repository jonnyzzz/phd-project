#include "AbstractProcessExt.h"
#include "../SystemFunction/MS2DAngleFunction.h" 
#include "AbstractBoxProcess.h"


class MS2DSIBoxProcess :
	public AbstractBoxProcess
{
public:
	MS2DSIBoxProcess(MS2DAngleFunction* function, Graph* original, int* factor, ProgressBarInfo* info);
	virtual ~MS2DSIBoxProcess(void);
    

public:
	virtual void processNodeAndImage(JDouble* value_min, JDouble* value_max, Node* node, Graph* graph_result);


private:
	const double* const centerOutput;
	MS2DAngleFunction* function;
};
