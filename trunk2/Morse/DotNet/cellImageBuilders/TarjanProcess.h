#pragma once

#include "AbstractProcess.h"

class TarjanProcess : public AbstractProcess
{
public:
	TarjanProcess(bool resolveEdges, ProgressBarInfo *info);
	virtual ~TarjanProcess(void);

public:
	virtual void processNextGraph(Graph* graph);
	virtual GraphSet results();

private:
	bool needResolve;
	GraphSet graphSet;
};
