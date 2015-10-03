#include "stdafx.h"
#include "StableLocalizationProcess.h"
#include "../graph/Graph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


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