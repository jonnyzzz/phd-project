#include "StdAfx.h"
#include ".\graphsaver.h"
#include "../graph/graph.h"
#include "../graph/filestream.h"
#include <fstream>
using namespace std;

GraphSaver::GraphSaver(void)
{
}

GraphSaver::~GraphSaver(void)
{
}

HRESULT GraphSaver::SaveGraphToFile(Graph* graph, CString fileName) {

	GraphComponents cms;
	cms.addGraphAsComponent(graph);
	return SaveGraphToFile(&cms, fileName);
}


HRESULT GraphSaver::SaveGraphToFile(GraphComponents* cms, CString fileName) {
	FileOutputStream o(fileName);

	for (int i=0; i< cms->length(); i++) {
		SaveGraph(cms->getAt(i), o);
	}

	return S_OK;
}


void GraphSaver::SaveGraph(Graph* graph, FileOutputStream& o) {
	saveGraphAsPoints(o, graph);
}