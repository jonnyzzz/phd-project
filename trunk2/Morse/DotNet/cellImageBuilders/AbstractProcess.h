#pragma once

#include "ProgressBarInfo.h"
#include "../graph/Graph.h"
#include "GraphSet.h"

class AbstractProcess 
{
public:
	AbstractProcess(ProgressBarInfo* info);
	virtual ~AbstractProcess(void);

public:
	virtual GraphSet results() = 0;
	virtual void processNextGraph(Graph* graph) = 0;
	//needed to do some virtual initizlizations... due to features of c++ implementations^(
	virtual void start(); 

protected:
	ProgressBarInfo* info;

private:
	bool wasInitialized;
};
