#pragma once

#include "graph.h"

class Graph;
struct Node;
struct Edge;
struct NodeEnumerator;
struct EdgeEnumerator;

class GraphNodeEnumerator {
private:
	NodeEnumerator* ne;
	Graph* graph;
public:
	GraphNodeEnumerator(Graph* graph) : graph(graph) {
		ne = graph->getNodeRoot();
	}
	~GraphNodeEnumerator() {
		graph->freeNodeEnumerator(ne);
	}

public:
	Node* next() {
		return graph->getNode(ne);
	}

    operator NodeEnumerator* () {
        return ne;
    }
};


class GraphEdgeEnumerator {
private:
	Graph* graph;
	EdgeEnumerator* ee;
public:
	GraphEdgeEnumerator(Graph* graph, Node* node) : graph(graph) {
		ee = graph->getEdgeRoot(node);
	}
	~GraphEdgeEnumerator() {
		graph->freeEdgeEnumerator(ee);
	}
public:
	Edge* next() {
		return graph->getEdge(ee);
	}

	Node* nextTo() {
		Edge* e = next();
		if (e == NULL) return NULL;
		return graph->getEdgeTo(e);
	}

    operator EdgeEnumerator* () {
        return ee;
    }
};
