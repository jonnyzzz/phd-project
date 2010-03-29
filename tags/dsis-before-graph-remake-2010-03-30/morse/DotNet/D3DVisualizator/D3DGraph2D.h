#pragma once

#include <list>
using namespace std;


#include <hash_map>
using namespace stdext;


#include "d3dkernel.h"
#include "../graph/graph.h"

#include "DrawableSet.h"


class D3DGraph2D :
	public D3DKernel
{
public:
	D3DGraph2D(void);
	virtual ~D3DGraph2D(void);


public:
	HRESULT Create(HWND hwnd, DrawableSet* drawableSet);
	
	HRESULT Render();

protected:
	virtual HRESULT initRenderSettings();
	virtual HRESULT initMatrices();
	virtual HRESULT renderPrimitive();

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

private:
	float Max(float x, float xx);
	JDouble Max(JDouble x, JDouble y);
	JDouble Abs(JDouble x);
	
	void createVertex(DrawableSetIterator* it, JDouble* eps, POINTVERTEX* p);
	void createEps(JDouble* eps);



public: 
	struct MousePoint {
		double x;
		double y;
	};
	bool getMouseCoordinate(POINTS point, MousePoint& fpoint);
	Node* getCurrentNode(MousePoint& pt);

private:
	DrawableSet* drawableSet;
};
