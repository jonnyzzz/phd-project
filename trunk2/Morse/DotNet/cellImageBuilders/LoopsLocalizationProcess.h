#pragma once
#include "AbstractProcess.h"

class LoopsLocalizationProcess :
	public AbstractProcess
{
public:
	LoopsLocalizationProcess(ProgressBarInfo* info);
	virtual ~LoopsLocalizationProcess(void);

public:
	virtual GraphSet results();
	virtual void processNextGraph(Graph* graph);		

private:
	GraphSet graphs;
};
