#pragma once

#include "ProgressBarInfo.h"
#include "../graph/graph.h"

class AbstractProcess 
{
public:
	AbstractProcess(Graph* graph, ProgressBarInfo* info);
	virtual ~AbstractProcess(void);

public:
	virtual Graph* result();
	virtual void processNextGraph(Graph* graph) = 0;
	virtual void start(); //needed to do some virtual initizlizations... due to features of c++ implementations^(

protected:
	Graph* graph_source;
	Graph* graph_result;
	ProgressBarInfo* info;

	void submitGraphResult(Graph* graph);

protected:
	JDouble sqr(JDouble x);
};
