#include "stdafx.h"
#include "TarjanProcess.h"
#include "GraphSet.h"
#include "../graph/GraphComponents.h"
#include "../graph/Graph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


TarjanProcess::TarjanProcess(bool needResolve, ProgressBarInfo* info) : 
AbstractProcess(info), needResolve(needResolve)
{
}

TarjanProcess::~TarjanProcess(void)
{
}


void TarjanProcess::processNextGraph(Graph* graph) {
	GraphComponents* cms = graph->localazeStrongComponents();
	GraphSet components(cms);
	delete cms;

	if (needResolve) {
		for (GraphSetIterator it = components.iterator(); it.HasNext(); it.Next()) {
			it->resolveEdges(graph);
		}
	}

	this->graphSet.AddGraph(components);	
}

GraphSet TarjanProcess::results() {
	return graphSet;
}
