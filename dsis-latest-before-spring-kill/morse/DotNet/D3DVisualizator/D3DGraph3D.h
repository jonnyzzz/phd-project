#pragma once
#include "d3dkernel.h"

#include "DrawableGraph.h"
#include <list>
using namespace std;

#include ".\..\graph\graph.h"

class DisplayableCoordinateSystem;

class D3DGraph3D :
	public D3DKernel
{
public:
	D3DGraph3D(void);
	virtual ~D3DGraph3D(void);


public:
	HRESULT Create(HWND hwnd, DrawableGraph* drawableGraph);
	HRESULT Render();


protected:
	virtual HRESULT initRenderSettings();
	virtual HRESULT initMatrices();
	virtual HRESULT renderPrimitive();
	virtual HRESULT afterMatricesInitExtRender();
	virtual HRESULT initRenderSettiongAfterScene();

	HRESULT initLight();


private:
	struct POINTVERTEX
	{
		D3DXVECTOR3 v;
		D3DXVECTOR3 n;
		D3DCOLOR    colorDiffuse;
		D3DCOLOR	colorAmbient;
	};

	static const DWORD FVF;
	static const int ATOM;
	static const D3DPRIMITIVETYPE VERTEX;
	static const int POINTPERVERTEX;

private:
	struct RenderList {
		POINTVERTEX* vb;
		int count;

	};

	RenderList* renderList;

private:
	int addPoint(POINTVERTEX*& pv, Node* node, int axis, int direction);
	int processAxis(POINTVERTEX*& pv, int axis, JInt* current);

	HRESULT createPointList();


private:
	DrawableGraph* graph;
	DisplayableCoordinateSystem* coordinateSystem;

	D3DXVECTOR3 eye_from;
	D3DXVECTOR3 eye_to;	
	float eye_fov;

public:

	void CenterView(int axis = 2);
	void MoveEyeFrom(float x, float y, float z);

	void SetEyeFrom(float x, float y, float z);
	void SetEyeTo(float x, float y, float z);

	void Zoom(float factor);

	void Rotate(float onX, float onY, float onZ);

private:
	D3DXVECTOR3 NormalizeMoveVector(D3DXVECTOR3 v);
};
