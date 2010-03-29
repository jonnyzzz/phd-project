#include "AbstractProcess.h"

class StableLocalizationProcess :
	public AbstractProcess
{
public:
	StableLocalizationProcess(ProgressBarInfo* info);
	virtual ~StableLocalizationProcess(void);


public:
	virtual GraphSet results();
	virtual void processNextGraph(Graph* graph);

private:
	GraphSet graphSet;
};


















