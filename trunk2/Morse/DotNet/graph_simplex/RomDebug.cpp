#include "StdAfx.h"
#include ".\romdebug.h"
#include <fstream>

CRomDebug::CRomDebug(Graph* graph, const Values& values) : 
CRom(graph), values(values)
{		
}

CRomDebug::~CRomDebug(void)
{
}


double CRomDebug::cost(Node* node) {
	return values[node] * factor;
}



CRomDebug::ExGraph CRomDebug::createFromFile(const char* file) {
	ifstream f;
	f.open(file);
	int mx;	
	f>>mx;

	ExGraph e;
	JDouble min[] = {0};
	JDouble max[] = {mx+1};
	JInt   grid[] = {mx+1};

	Graph* g = new Graph(1, min, max, grid);
	e.graph = g;

	for (int i=0; i<mx; i++) {
		int id;
		double v;
		int t;

		f>>id>>v>>t;

		Node* node = g->browseTo(&id);
		e.values[node] = v;

		for (int j=0; j<t; j++) {
			int p;
			f>>p;
			g->browseTo(node, g->browseTo(&p));
		}
	}
	
	f.close();

	return e;
}