#include "StdAfx.h"
#include ".\simplegraphapi.h"

SimpleGraphApi::SimpleGraphApi(void)
{
	reset();
}


SimpleGraphApi::~SimpleGraphApi(void)
{
	delete graph;
}



Node* SimpleGraphApi::to(int id) {
	return graph->browseTo(&id);
}

void SimpleGraphApi::to(Node* n1, Node* n2) {
	graph->browseTo(n1, n2);
}

void SimpleGraphApi::to(int i1, int i2) {
	to(to(i1), to(i2));
}

void SimpleGraphApi::reset() {
	JDouble dmin[] = {0};
	JDouble dmax[] = {1};
	JInt	gdir[] = {1000};
	this->graph = new Graph(1, dmin, dmax, gdir);
}

Graph* SimpleGraphApi::getGraph() {
	return graph;
}