#include "StdAfx.h"
#include ".\drawablesetiterator.h"
#include ".\DrawableSet.h"
#include "../graph/graphComponents.h"

#include <iostream>
using namespace std;


DrawableSetIterator::DrawableSetIterator(DrawableSet* set) : set(set)
{
	currentNode = 0;
	enumerator = NULL;
	cms = set->getGraphComponents();
	cache = NULL;
	reset();
}

DrawableSetIterator::~DrawableSetIterator(void)
{
	if (enumerator != NULL) {
		delete enumerator;
	}
}


void DrawableSetIterator::release() {		
	if (enumerator != NULL) {
		delete enumerator;
	}

	currentNode = 0;
}

void DrawableSetIterator::reset() {
	release();
	init();
}

void DrawableSetIterator::init() {
	if (enumerator != NULL) {
		delete enumerator;
	}
	enumerator = new GraphNodeEnumerator(cms->getAt(currentNode++));
}

bool DrawableSetIterator::next() {
	//cout<<"NEXT:Call\n";

	if (currentNode > cms->length()) return false;
	
	ATLASSERT(enumerator != NULL);

	//cout<<"befor enumerator->Next call\n";

	cache = enumerator->next();

	//cout<<"after enumerator->Next call\n";

	if (cache == NULL) {
		if (currentNode < cms->length()) {
			init();
			return next();
		} else return false;
	}
	return true;
}

Node* DrawableSetIterator::current() {
	return cache;
}

DWORD DrawableSetIterator::color() {
	//todo: implement call to set->???? to find a color color
	return 0x544345;
}

Graph* DrawableSetIterator::currentGraph() {
	if (enumerator == NULL) return NULL;
	return cms->getAt(currentNode-1);
}

void DrawableSetIterator::coordinate(float* array) {
	const int* axis = set->axisArray();
	Graph* graph = currentGraph();
	for (int i=0; i<set->getDimension(); i++) {
		array[i] = (float) (graph->toExternal(graph->getCells(current())[axis[i]], axis[i]) + graph->getEps()[axis[i]]/2);
	}
}

