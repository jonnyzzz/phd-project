#include "StdAfx.h"
#include ".\graphsaver.h"
#include <fstream>
using namespace std;

GraphSaver::GraphSaver(void)
{
}

GraphSaver::~GraphSaver(void)
{
}

bool GraphSaver::openFile(CString file, ofstream& o) {
	o.open(file);
	if (!o.is_open()) return false;
	return true;
}

HRESULT GraphSaver::SaveGraphToFile(Graph* graph, CString fileName) {

	ofstream o;
	if (!openFile(fileName, o)) return E_FAIL;

	CString out;
	AppendGraphToString(graph, out);
	
	o << out;
	o.close();
	return S_OK;
}


HRESULT GraphSaver::SaveGraphToFile(GraphComponents* cms, CString fileName) {
	ofstream o;
	if (!openFile(fileName, o)) return E_FAIL;

	CString out;

	for (int i=0; i< cms->length(); i++) {
		AppendGraphToString(cms->getAt(i), out);
	}

	o << out;
	o.close();

	return S_OK;
}

void GraphSaver::AppendGraphToString(Graph* graph, CString& out) {
	const CString nFormatAtom = "%f ";
	const CString nFormatEndLine = "\n";
	
	CString tmp;
	int dim = graph->getDimention();
	
	NodeEnumerator* ne = graph->getNodeRoot();
	Node* node;
	while (node = graph->getNode(ne)) {
		for (int i=0; i<dim; i++) {
			double d = graph->toExternal(graph->getCells(node)[i],i);
			tmp.Format(nFormatAtom, d);
			out += tmp;
		}
		out += nFormatEndLine;
	}
}
