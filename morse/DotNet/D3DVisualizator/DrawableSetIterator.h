#pragma once

#include "../graph/graphUtil.h"

class DrawableSet;


class DrawableSetIterator {
public:
	DrawableSetIterator(DrawableSet* set);
	virtual ~DrawableSetIterator();

public:
	void reset();

	Node* current();
	DWORD color();
	bool next();

	void coordinate(float* array); //length <= 3! center of point!

private:
	void release();
	void init();

	Graph* currentGraph();


private:
	DrawableSet* set;

	GraphComponents* cms;
	
	Node* cache;
	GraphNodeEnumerator* enumerator;

	int currentNode;
};