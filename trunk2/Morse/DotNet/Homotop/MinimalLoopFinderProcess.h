#pragma once
#include "../cellImageBuilders/AbstractProcess.h"

class MinimalLoopFinderProcess : public AbstractProcess
{
public:
	MinimalLoopFinderProcess(JDouble* coord, int dimension, ProgressBarInfo* pinfo);
	virtual ~MinimalLoopFinderProcess(void);


public:
	virtual GraphSet results();
	virtual void processNextGraph(Graph* graph);

private:
	GraphSet graphSet;
	int dimension;
	JDouble* coord;
	JInt* cell;
};
