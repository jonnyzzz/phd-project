#include "stdafx.h"
#include "ProjectionProcess.h"
#include "../graph/Graph.h"

ProjectionProcess::ProjectionProcess(JInt* devidors, int dimention, ProgressBarInfo* info) : AbstractProcess(info)
{
	this->devidors = new JInt[dimention];
	memcpy(this->devidors, devidors, sizeof(JInt)*dimention);
}

ProjectionProcess::~ProjectionProcess(void)
{
}

void  ProjectionProcess::processNextGraph(Graph* graph) {
	graphs.AddGraph(graph->Project(devidors));
}


GraphSet ProjectionProcess::results() {
	return graphs;
}