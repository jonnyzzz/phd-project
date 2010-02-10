#pragma once
#include "../graph/graph.h"
#include <d3dx9.h>
#include "TextureManager.h"
#include "GraphEx.h"

#include <list>
using namespace std;

class GraphRepresentator
{
public:
	GraphRepresentator();
	~GraphRepresentator();

private:

	struct POINTVERTEX
	{
		D3DXVECTOR3 v;
		D3DCOLOR    color;

		static const DWORD FVF;
	};

	int numPoints;
	POINTVERTEX* points;
	POINTVERTEX* highPoints;
	int numHighPoints;

	LPDIRECT3DVERTEXBUFFER9 vb;
	LPDIRECT3DVERTEXBUFFER9 highVB;

	GraphEx* graph;
	TextureManager tm;

	bool needInit;
	bool needInitHigh;

private:
	void FillPOINTVERTEX();

public:
	HRESULT InitDevice(LPDIRECT3DDEVICE9 device);

	HRESULT Render(LPDIRECT3DDEVICE9 device);

	HRESULT SetGraph(GraphEx* graph);	
	

	Node* GetNodeBy(POINTS& pt, RECT& obl);
	bool  HighLightNode(Node* node);

private:
	Node* nodeHighLight;


protected:

	HRESULT SetMatrices(LPDIRECT3DDEVICE9 device);
	HRESULT InitDevice(LPDIRECT3DDEVICE9 device, POINTVERTEX* points, int count, LPDIRECT3DVERTEXBUFFER9* vb);

	void FillNode(Node* node, POINTVERTEX*& v, DWORD color);
	

protected:
	D3DXVECTOR3 eye_pos;
	float fov;

public:
	void toCenter();
	void move(float dx, float dy, float dz);

	GraphEx& getGraphEx();
	Node* getActiveNode();

private:
	JInt Max (JInt a, JInt b);
	float Max (float a, float b);

};
