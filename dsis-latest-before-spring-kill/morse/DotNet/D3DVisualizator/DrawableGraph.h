#pragma once

#include ".\..\graph\graph.h"

class DrawableGraph
{
public:
	DrawableGraph(Graph* graph);
	virtual ~DrawableGraph(void);


public:
	Graph* getGraph();
	D3DXVECTOR3 getCoordinates(Node* node);
	D3DXVECTOR3 getEps();

	DWORD getColorDiffuse(Node* node);
	DWORD getColorAmbient(Node* node);

	D3DXVECTOR3 getMin();
	D3DXVECTOR3 getMax();
	D3DXVECTOR3 getMid();

	JDouble getMaxLength();


private:
	Graph* graph;

	int dim[3];
	int coordMax;
};
