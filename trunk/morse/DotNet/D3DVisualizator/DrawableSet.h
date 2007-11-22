#pragma once

#include "../graph/graph.h"


class DrawableSetIterator;

class DrawableSet
{
public:
	enum AXIS {
		AXIS_X,
		AXIS_Y,
		AXIS_Z
	};

public:
	DrawableSet(GraphComponents* cms); //deletes only cms, not it contents	
	virtual ~DrawableSet(void);

public:

	DWORD getAxisColor(AXIS axis);
	int getDimension();

	GraphComponents* getGraphComponents();

	const int* axisArray();

	DrawableSetIterator* iterator();

public:
	void getEps(JDouble* eps);
	void getGrid(JInt* grid);
	JInt getMaxGrid();
	
	void getLength(float* lens);
	void getMidPoint(float* mid);

	Node* findFirstNode(float* coordinate);
	

private:
	GraphComponents* cms;
	int dimension;

	int* axisArrayData;
};