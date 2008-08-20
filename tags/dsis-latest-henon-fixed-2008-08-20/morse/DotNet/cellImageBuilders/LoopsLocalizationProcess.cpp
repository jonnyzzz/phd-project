#include "stdafx.h"
#include "LoopsLocalizationProcess.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


LoopsLocalizationProcess::LoopsLocalizationProcess(ProgressBarInfo* info) : AbstractProcess(info)
{
}

LoopsLocalizationProcess::~LoopsLocalizationProcess(void)
{
}


void LoopsLocalizationProcess::processNextGraph(Graph* graph) {
	graphs.AddGraph(graph->localizeLoops(info));
}


GraphSet LoopsLocalizationProcess::results() {
	return graphs;
}
