#include "StdAfx.h"
#include ".\msuniversalpointbuilder.h"
#include ".\MS2PointBuilder.h"
#include ".\MS3PointBuilder.h"

MSUniversalPointBuilder::MSUniversalPointBuilder(Graph* graph, Function* function, JInt* factor, JInt* ks) :
function(function), ks(ks), factor(factor), AbstractProcess(graph)
{
	process = createProcess(graph_source);
}

MSUniversalPointBuilder::~MSUniversalPointBuilder(void)
{
	if (process != NULL) 
		delete process;
}


void MSUniversalPointBuilder::start() {
	process->start();
}


void MSUniversalPointBuilder::processNextGraph(Graph* graph) {
	if (!needSameProcess(graph)) throw MSUniversalPointBuilderGraphNoMatchERxception();
	process->processNextGraph(graph);
}

Graph* MSUniversalPointBuilder::result() {
	return process->result();
}


AbstractProcess* MSUniversalPointBuilder::createProcess(Graph* graph) {
	switch (graph->getDimention()) {
		case 3: //2+1
			return new MS2PointBuilder(graph_source, factor, ks, function);
		case 5:
			return new MS3PointBuilder(graph_source, factor, ks, function);
		default:
			throw MSUniversalPointBuilderGraphNoMatchERxception();
			return NULL;
	}
}

bool MSUniversalPointBuilder::needSameProcess(Graph* graph) {
	return graph->getDimention() == graph_source->getDimention();
}