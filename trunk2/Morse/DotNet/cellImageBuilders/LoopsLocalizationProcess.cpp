#include "StdAfx.h"
#include ".\loopslocalizationprocess.h"

LoopsLocalizationProcess::LoopsLocalizationProcess(ProgressBarInfo* info) : AbstractProcess(info)
{
}

LoopsLocalizationProcess::~LoopsLocalizationProcess(void)
{
}


void LoopsLocalizationProcess::processNextGraph(Graph* graph) {
	graphs.AddGraph(graph->localizeLoops());
}


GraphSet LoopsLocalizationProcess::results() {
	return graphs;
}