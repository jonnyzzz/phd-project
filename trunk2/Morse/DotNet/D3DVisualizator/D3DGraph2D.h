#pragma once

#include <list>
using namespace std;


#include <hash_map>
using namespace stdext;


#include "d3dkernel.h"
#include "../graph/graph.h"

typedef hash_map<Node*, DWORD> GraphColor;

class D3DGraph2D :
	public D3DKernel
{
public:
	D3DGraph2D(void);
	virtual ~D3DGraph2D(void);


public:
	HRESULT Create(HWND hwnd, Graph* graph, GraphColor* color, int dim1, int dim2);
	
	HRESULT Render();

protected:
	virtual HRESULT initRenderSettings();
	virtual HRESULT initMatrices();
	virtual HRESULT renderPrimitive();

protected:
	HRESULT createAndFillVertexBuffer();

	struct RenderList {
		LPDIRECT3DVERTEXBUFFER8 vb;
		int count;
	};

	typedef list< RenderList > VertexList;
	VertexList buffer;
	


public:
	void OnCenterView();
	void OnMove(float dx, float dy, float dz);
	float getZoomFactor();
	

private:
	struct POINTVERTEX
	{
		D3DXVECTOR3 v;
		D3DCOLOR    color;

		static const DWORD FVF;
	};
	
	D3DXVECTOR3 eye_pos;
	float eye_fov;
	float zfactor;

protected:
	int dim1;
	int dim2;
	Graph* graph;
	GraphColor* color;

private:
	float Max(float x, float xx);
		void createVertex(Node* node, POINTVERTEX*& pv);


public: 
	struct MousePoint {
		double x;
		double y;
	};
	bool getMouseCoordinate(POINTS point, MousePoint& fpoint);
	Node* getCurrentNode(MousePoint& pt);
};
