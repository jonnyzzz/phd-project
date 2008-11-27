// MorseKernelVisualizationDirectGraph3D.cpp : Implementation of CMorseKernelVisualizationDirectGraph3D

#include "stdafx.h"
#include "MorseKernelVisualizationDirectGraph3D.h"
#include "../D3DVisualizator/D3DGraph3D.h"



// CMorseKernelVisualizationDirectGraph3D

CMorseKernelVisualizationDirectGraph3D::CMorseKernelVisualizationDirectGraph3D() 
{
	m_bWindowOnly = TRUE;
	m_hD3D = NULL;
}


LRESULT  CMorseKernelVisualizationDirectGraph3D::OnCreate(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/) 
{
	return S_OK;
}

void CMorseKernelVisualizationDirectGraph3D::Repaint() {

	PAINTSTRUCT ps;	
	CAxWindow wnd(m_hWnd);
	HDC hDC = wnd.BeginPaint(&ps);	
	RECT r;
	wnd.GetClientRect(&r);
	Rectangle(hDC, 0,0, r.right, r.bottom);	
	wnd.EndPaint(&ps); 

	D3DKernelException("Render");
	HRESULT hr;
	if (m_hD3D != NULL) {
		hr = m_hD3D->Render();

		if (FAILED(hr)) {
			m_hD3D->Dispose();
			delete m_hD3D;
			m_hD3D = NULL;
		}
	}
}

LRESULT CMorseKernelVisualizationDirectGraph3D::OnPaint(UINT, WPARAM, LPARAM, BOOL&) {
	
	Repaint();

	return 0L;
}


HRESULT CMorseKernelVisualizationDirectGraph3D::FinalConstruct() {
	return S_OK;
}


void CMorseKernelVisualizationDirectGraph3D::FinalRelease() {
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::SetGraph(void ** g) {
	Graph * graph = *(Graph**)g;

	if (m_hD3D != NULL) {
		m_hD3D->Dispose();
		delete m_hD3D;
	}

	m_hD3D = new D3DGraph3D();
	HRESULT hr = m_hD3D->Create(m_hWnd, new DrawableGraph(graph));
	
	Repaint();

	return hr;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::SetTestGraph() {
	JInt gq[] = {10,10,10};
	JDouble min[] = {0,0,0};
	JDouble max[] = {1,1,1};

	Graph* g = new Graph(3, min, max, gq);
	//g->maximize();

	int t[3];
	int &i = t[0];
	int &j = t[1];
	int &k = t[2];
    /*
	for (i=0; i<gq[0]; i++) {
		for (j=0; j<gq[1]; j++) {
			for (k=0; k<gq[2]; k++) {
				if (i <=j && j <= k) 
					g->browseTo(t);
			}
		}
	}
	g->maximize();
	*/
	i = 0; j = 0; k = 0; g->browseTo(t);
	
	i = 1; j = 0; k = 0; g->browseTo(t);
	i = 0; j = 1; k = 0; g->browseTo(t);
	i = 1; j = 1; k = 0; g->browseTo(t);
	/*
	i = 0; j = 0; k = 1; g->browseTo(t);
	i = 1; j = 0; k = 1; g->browseTo(t);
	i = 0; j = 1; k = 1; g->browseTo(t);
	i = 1; j = 1; k = 1; g->browseTo(t);

	i = 9; j = 9; k = 0; g->browseTo(t);
*/
	return SetGraph((void**)&g);
}


////////////////////////////////////////////////////////////////


STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::MoveFromEye(DOUBLE x, DOUBLE y, DOUBLE z) {
	if (m_hD3D != NULL) {
		m_hD3D->MoveEyeFrom((float)x, (float)y, (float)z);
		Repaint();
	}
	return S_OK;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::SetEyeFrom(FLOAT x, FLOAT y, FLOAT z) {
	if (m_hD3D != NULL) {
		m_hD3D->SetEyeFrom(x, y, z);
		Repaint();
	}
	return S_OK;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::SetEyeTo(FLOAT x, FLOAT y, FLOAT z) {
	if (m_hD3D != NULL) {
		m_hD3D->SetEyeTo(x, y, z);
		Repaint();
	}
	return S_OK;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::Rotate(FLOAT onX, FLOAT onY, FLOAT onZ) {
	if (m_hD3D != NULL) {
		m_hD3D->Rotate(onX, onY, onZ);
		Repaint();
	}
	return S_OK;
}	

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::CenterView() {
	if (m_hD3D != NULL) {
		m_hD3D->CenterView(2);
		Repaint();
	}
	return S_OK;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::MoveLeftAtom() {
	return E_NOTIMPL;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::MoveRightAtom() {
	return E_NOTIMPL;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::MoveUpAtom() {
	return E_NOTIMPL;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::MoveDownAtom() {
	return E_NOTIMPL;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::ZoomOutAtom() {
	if (m_hD3D != NULL) {
		m_hD3D->Zoom(2.0f);
		Repaint();
	}
	return S_OK;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph3D::ZoomInAtom() {
	if (m_hD3D != NULL) {
		m_hD3D->Zoom(0.5f);
		Repaint();
	}
	return S_OK;

}