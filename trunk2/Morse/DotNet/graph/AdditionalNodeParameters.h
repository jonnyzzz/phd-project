#pragma once

#include "Graph.h"

#include <hash_map>
using namespace stdext;

template <typename Data>
class AdditionalNodeParameters
{
private:
	typedef hash_map<Node*, Data*> Hash;

private:
	Graph* graph;

	Data* buffer;	
	Data* it;

	Hash hash;

public:
	AdditionalNodeParameters(Graph* graph) : graph(graph) {
		bufferLen = graph->getNumberOfNodes();
		it = buffer = new Data[bufferLen];
	}

	virtual ~AdditionalNodeParameters(void) {
		delete[] buffer;
	}

private:
	Data* allocateData(Node* node) {
		Data d = it++;
		d = Data();
		d.node = node;
		return &d;
	}

public:

	Data* getData(Node* node) {
		Data*& d = hash[node];
		if (d == NULL) {
			d = allocateData(node);
		}
		return d;
	};

};
