#ifndef _CELLIMAGEBUILDERS_ABSTRACTPROCESSEXT_H
#define _CELLIMAGEBUILDERS_ABSTRACTPROCESSEXT_H

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

#endif //#ifndef _CELLIMAGEBUILDERS_ABSTRACTPROCESSEXT_H
