#include "StdAfx.h"
#include ".\tarjanprocess.h"
#include "graphSet.h"

TarjanProcess::TarjanProcess(bool needResolve, ProgressBarInfo* info) : 
AbstractProcess(info), needResolve(needResolve)
{
}

TarjanProcess::~TarjanProcess(void)
{
}


void TarjanProcess::processNextGraph(Graph* graph) {
	GraphSet components = graph->localazeStrongComponents();

	if (needResolve) {
		for (GraphSetIterator it = components.iterator(); it.HasNext(); it.Next()) {
			it->resolveEdges(graph);
		}
	}

	graphSet.AddGraph(components);	
}

GraphSet TarjanProcess::results() {
	return graphSet;
}