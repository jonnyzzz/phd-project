#pragma once

/*

This code will fail if number of nodes in graph changed.

*/

#include <hash_map>
using namespace stdext;

#include "Graph.h"

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
	int bufferLen;

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
		Data* d = new(it++) Data();
		return d;
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
