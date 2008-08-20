#pragma once

class GraphToCoordinates
{
public:
	GraphToCoordinates(void);
	~GraphToCoordinates(void);

public:
	Graph* createCut(Graph* graph, int dimX, int dimY, JDouble minX, JDouble maxX, JDouble minY, JDouble maxY, JInt gridX, JInt gridY);

private:
	
	void toFactor(Graph* graph, JInt& grid, int d, JInt& factor);
	JDouble Abs(JDouble x);
};
