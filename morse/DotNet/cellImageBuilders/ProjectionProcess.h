#include "AbstractProcess.h"

class ProjectionProcess :
	public AbstractProcess
{
public:
	ProjectionProcess(JInt* devidors, int dimention, ProgressBarInfo* info);
	virtual ~ProjectionProcess(void);

public:
	virtual GraphSet results();
	virtual void processNextGraph(Graph* graph);

private:
	GraphSet graphs;
	JInt* devidors;
};
