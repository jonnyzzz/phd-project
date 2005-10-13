#include "stdafx.h"
#include "StableLocalizationProcess.h"
#include "../graph/Graph.h"

StableLocalizationProcess::StableLocalizationProcess(ProgressBarInfo* info) : AbstractProcess(info)
{
}

StableLocalizationProcess::~StableLocalizationProcess(void)
{
}



GraphSet StableLocalizationProcess::results() {
	return graphSet;
}

void StableLocalizationProcess::processNextGraph(Graph* graph) {
	graphSet.AddGraph(graph->stableLocalization());
}