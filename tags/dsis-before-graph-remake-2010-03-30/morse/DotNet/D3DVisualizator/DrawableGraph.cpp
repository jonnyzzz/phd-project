#include "StdAfx.h"
#include ".\drawablegraph.h"
#include ".\..\graph\graph.h"

DrawableGraph::DrawableGraph(Graph* graph) : graph(graph)
{
	dim[0] = 0;
	dim[1] = 1;
	dim[2] = 2;
	coordMax = 3;
}

DrawableGraph::~DrawableGraph(void)
{
}


Graph* DrawableGraph::getGraph() {
	return graph;
}

D3DXVECTOR3 DrawableGraph::getCoordinates(Node* node) {
	const JInt* cells = graph->getCells(node);

	JDouble x[3] = {0,0,0};

	for (int i=0; i<coordMax; i++) {
		x[i] = graph->toExternal(cells[i], i);
	}

	return D3DXVECTOR3((float)x[0], (float)x[1], (float)x[2]);
}

DWORD DrawableGraph::getColorDiffuse(Node*) {
	return 0xff0000;
}

DWORD DrawableGraph::getColorAmbient(Node* node){ 
	DWORD color = getColorDiffuse(node);

	int colorD = 0x5f;

	int a = (color >> 24) & 0xff;
	int r = (color >> 16) & 0xff;
	int g = (color >> 8) & 0xff;
	int b = (color     ) & 0xff;

	a = 0;
	r -= min(r, colorD);
	g -= min(g, colorD);
	b -= min(b, colorD);

	return (b & 0xff) + ( (g & 0xff) << 8) + ( (r & 0xff) << 16 );
}

D3DXVECTOR3 DrawableGraph::getEps() {
	if (coordMax == 3) {
		return D3DXVECTOR3((float)graph->getEps()[dim[0]], (float)graph->getEps()[dim[1]], (float)graph->getEps()[dim[2]]);
	} else if (coordMax == 2) {
		return D3DXVECTOR3((float)graph->getEps()[dim[0]], (float)graph->getEps()[dim[1]], 0.0f);
	} else {
		printf("!!!!!!!!!!!!!!!!!!!!!!!!!1 getEps Error!");
		return D3DXVECTOR3();
	}
}


D3DXVECTOR3 DrawableGraph::getMin() {
	return D3DXVECTOR3(
		(float)graph->getMin()[dim[0]],
		(float)graph->getMin()[dim[1]],
		(float)graph->getMin()[dim[2]]
		);
}

D3DXVECTOR3 DrawableGraph::getMax() {
	return D3DXVECTOR3(
		(float)graph->getMax()[dim[0]],
		(float)graph->getMax()[dim[1]],
		(float)graph->getMax()[dim[2]]
		);
}

D3DXVECTOR3 DrawableGraph::getMid() {
	return D3DXVECTOR3(getMin() + getMax())/2;
}

JDouble DrawableGraph::getMaxLength() {
	D3DXVECTOR3 v = D3DXVECTOR3( getMax() - getMin());
	int i=0;
	JDouble ans = (getMax()[i] - getMin()[i]) ;
	i = 1;
	if (ans < (getMax()[i] - getMin()[i])) ans = (getMax()[i] - getMin()[i]);
	i = 2;
	if (ans < (getMax()[i] - getMin()[i])) ans = (getMax()[i] - getMin()[i]);
	return ans;
}
	
