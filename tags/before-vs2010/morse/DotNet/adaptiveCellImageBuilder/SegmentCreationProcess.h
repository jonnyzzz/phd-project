#pragma once
#include "../cellImageBuilders/AbstractProcess.h"

class SegmentCreationProcess : public AbstractProcess
{
public:
	SegmentCreationProcess(Graph* graph, JInt* factor, ProgressBarInfo* info);
	virtual ~SegmentCreationProcess(void);


public:
	virtual GraphSet results();
	virtual void processNextGraph(Graph* graph);


protected:
	void CreateGraph(Graph* graph);
	void ProcessNode(const JInt* coord);

private:
	Graph* graph_result;
	JInt* factor;
	JInt* p;
	JInt* b;

	const int dimensionBase;
	const int dimension;

};
