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
	this->graph = new Graph(1, dmin, dmax, gdir, true);
}

Graph* SimpleGraphApi::getGraph() {
	return graph;
}

int SimpleGraphApi::extract(Node* node) {
	return graph->getCells(node)[0];
}

void SimpleGraphApi::Dump() {
	GraphNodeEnumerator ee(graph);
	Node* node;
	cout<<endl;
	while ((node = ee.next()) != NULL) {
		cout<<extract(node)<<" : ";
		Node* to;
		for (GraphEdgeEnumerator ee(graph, node); (to = ee.nextTo())!= NULL;) {
			cout<<extract(to)<<" ";
		}
		cout<<endl;
	}
	cout<<endl;
}