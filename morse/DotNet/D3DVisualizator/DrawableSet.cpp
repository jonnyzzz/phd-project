#include "StdAfx.h"
#include ".\drawableset.h"
#include "../graph/GraphComponents.h"
#include ".\DrawableSetIterator.h"

DrawableSet::DrawableSet(GraphComponents* cms) : cms(cms)
{
	ATLASSERT(cms->length() != 0);

	this->dimension = cms->getDimension();
	axisArrayData = new int[3];
	axisArrayData[0] = 0;
	axisArrayData[1] = 1;
	axisArrayData[2] = 2;

}

DrawableSet::~DrawableSet(void)
{
	delete cms;
}


int DrawableSet::getDimension() {
	return dimension % 3;
}

DWORD DrawableSet::getAxisColor(AXIS axis) {
	//todo: implement interaction with ColorInterface from myATL
	switch (axis) {
		case AXIS_X:
			return 0x0000ff;
		case AXIS_Y:
			return 0x00ff00;
		case AXIS_Z:
			return 0xff0000;
		default:
			return 0x0;
	}
}

const int* DrawableSet::axisArray() {
	return axisArrayData;
}

GraphComponents* DrawableSet::getGraphComponents() {
	return cms;
}

DrawableSetIterator* DrawableSet::iterator() {
	return new DrawableSetIterator(this);
}

///////////////////////////////////////////////////////////////////

void DrawableSet::getEps(JDouble* eps) {
	Graph* graph = cms->getAt(0);

	printf("G Eps:\n");
	for (int i=0; i<getDimension(); i++) {
		eps[i] = graph->getEps()[axisArrayData[i]];
		printf("eps[%d] = %f\n", i, eps[i]);
	}	
}

void DrawableSet::getGrid(JInt* grid) {
	Graph* graph = cms->getAt(0);

	for (int i=0; i<getDimension(); i++) {
		grid[i] = graph->getGrid()[axisArrayData[i]];
	}
}

void DrawableSet::getLength(float* len) {
	Graph* graph = cms->getAt(0);
	for (int i=0; i<getDimension(); i++) {
		len[i] =(float) ( graph->getMax()[axisArrayData[i]] - graph->getMin()[axisArrayData[i]]);
	}
}

void DrawableSet::getMidPoint(float* mid) {
	Graph* graph = cms->getAt(0);
	for (int i=0; i<getDimension(); i++) {
		mid[i] =(float) ( graph->getMax()[axisArrayData[i]] + graph->getMin()[axisArrayData[i]])/2;
	}
}

Node* DrawableSet::findFirstNode(float*) {
	return NULL;
}




