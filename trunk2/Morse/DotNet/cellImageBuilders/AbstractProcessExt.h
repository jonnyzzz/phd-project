#pragma once
#include "AbstractProcess.h"

class AbstractProcessExt :
	public AbstractProcess
{
public:
	AbstractProcessExt(Graph* graph, ProgressBarInfo* info);
	virtual ~AbstractProcessExt(void);


public:
	virtual Graph* result();
	virtual GraphSet results();


protected:
	Graph* graph_source;
	Graph* graph_result;

protected:
	void submitGraphResult(Graph* graph);
	JDouble sqr(JDouble x);


};
