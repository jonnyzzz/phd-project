#include "time.h"
#include "stdafx.h"
#include <fstream>
#include <list>
using namespace std;
#include "../graph/GraphUtil.h"

#include "../graph/AdditionalNodeParameters.h"

typedef list<Node*> NodesList;

class Value {
public:
	double value;
	Value() {
		value = rand()/RAND_MAX*2-1;
	}
};

struct Extr {
	NodesList loop;
	double value;
};

typedef list<Extr> Extrs;


Extrs minLoops;
Extrs maxLoops;

Graph* g;
AdditionalNodeParameters<Value>* params;


double GetValue(Node* node) {
	return params->getData(node)->value;
}

void UpdateGraph(Node* node, Node* stop, NodesList& list) {

	for (NodesList::iterator it = list.begin(); it != list.end(); it++) {
		if (*it == node && *it != list.back()) return;
	}

	if (node == stop && list.size() != 0) {
		double v = 0;
		int cnt = 0;
		for (NodesList::iterator it = list.begin(); it != list.end(); it++){
			cnt ++;
			v += GetValue(*it);
		}
		v /= cnt;

		if (minLoops.size() == 0 || v < minLoops.front().value) {
			Extr e;
			e.value = v;
			e.loop = list;
			minLoops.clear();
			minLoops.push_back(e);
		} else
		if (maxLoops.size() == 0 || v > maxLoops.front().value) {
			Extr e;
			e.value = v;
			e.loop = list;
			maxLoops.clear();
			maxLoops.push_back(e);
		} else if (minLoops.size() == 0 || v == minLoops.front().value) {
			Extr e;
			e.value = v;
			e.loop = list;			
			minLoops.push_back(e);
		} else if (maxLoops.size() == 0 || v == maxLoops.front().value) {
			Extr e;
			e.value = v;
			e.loop = list;			
			maxLoops.push_back(e);
		}

		return;
	}
	
	list.push_back(node);

	GraphEdgeEnumerator ee(g, node);
	Node* e;
	while (e = ee.nextTo()) {		
		UpdateGraph(e, stop, list);
	}

	list.pop_back();
}


int getNextNumber() {
	int v = rand();
	return v>0?v:-v;
}


void addNewEdge(int node1, int node2) {
	Node* node;
	g->browseTo(node = g->browseTo(&node1), g->browseTo(&node2));

	NodesList list;

	UpdateGraph(node, node, list);
}


void SaveGraph() {
	ofstream o;
	o.open("g:\\test");

	GraphNodeEnumerator e(g);
	Node* node;
	while (node = e.next()) {
		o<< g->getCells(node)[0]<<"\t"<< params->getData(node)->value;

		GraphEdgeEnumerator ee(g, node);
		Node* n;
		while (n = ee.nextTo()) {
			o<<"\t"<<g->getCells(n)[0];
		}
		o<<"\n";
	}

	o<<"\n\n\n";
	o<<"min:\n";

	{
		for (Extrs::iterator it = minLoops.begin(); it != minLoops.end(); it++) {
			o<<(*it).value;
			for (NodesList::iterator itt = (*it).loop.begin(); itt != (*it).loop.end(); itt++) {
				o<<g->getCells(*itt)[0]<<"\t";
			}
			o<<"\n";
		}
	}

	o<<"\n\n\n";
	o<<"max:\n";

	{
		for (Extrs::iterator it = maxLoops.begin(); it != maxLoops.end(); it++) {
			o<<(*it).value;
			for (NodesList::iterator itt = (*it).loop.begin(); itt != (*it).loop.end(); itt++) {
				o<<g->getCells(*itt)[0]<<"\t";
			}
			o<<"\n";
		}
	}

	o.close();
}	



void generateGraph(int nodes, int edges) {
	g = createTestGraph(10000);
	params = new AdditionalNodeParameters<Value>(g);
	
	for (int i=0; i<nodes; i++) {
		g->browseTo(&i);
	}


	for (i=0; i<edges; i++) {
		addNewEdge(getNextNumber()%nodes, getNextNumber()%nodes);
	}

	SaveGraph();
	
}


void main(int argc, char** argv) {	
	
    srand( (unsigned)time( NULL ) );
	generateGraph(10, 10);

}