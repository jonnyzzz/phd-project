// MorseKernelVisualizationDirect3D.cpp : Implementation of CMorseKernelVisualizationDirect3D

#include "stdafx.h"
#include "MorseKernelVisualizationGraph2D.h"
#include "../D3DVisualizator/D3DGraph2D.h"


// CMorseKernelVisualizationDirect3D

CMorseKernelVisualizationDirectGraph2D::CMorseKernelVisualizationDirectGraph2D() {
	m_hD3D = NULL;
	m_bWindowOnly = TRUE;
}


LRESULT CMorseKernelVisualizationDirectGraph2D::OnCreate(UINT, WPARAM, LPARAM, BOOL&) 
{
	d3dWindow.Create(m_hWnd);
	return S_OK;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph2D::TranslateAccelerator(LPMSG pMsg) 
{
	return E_NOTIMPL;
}


HRESULT CMorseKernelVisualizationDirectGraph2D::FinalConstruct() {	
	return S_OK;
}

void CMorseKernelVisualizationDirectGraph2D::FinalRelease() {
	if (m_hD3D != NULL) {
		m_hD3D->Dispose();
		delete m_hD3D;
	}
}


//////////////////////////////////////////////////////////////////////////////

void CMorseKernelVisualizationDirectGraph2D::Repaint() {	
	DrawBorder2D();

	if (m_hD3D != NULL) {
		m_hD3D->Render();
	}	
};

LRESULT CMorseKernelVisualizationDirectGraph2D::OnPaint(UINT msg, WPARAM wparam, LPARAM lparam, BOOL&) {	
	printf("WM_PAINT component\n");
	
	Repaint();
		
	return 0L; 
}

void CMorseKernelVisualizationDirectGraph2D::DrawBorder2D() {
	PAINTSTRUCT ps;	
	CAxWindow wnd(m_hWnd);
	HDC hDC = wnd.BeginPaint(&ps);	
	RECT r;
	wnd.GetClientRect(&r);
	Rectangle(hDC, 0,0, r.right, r.bottom);	
	wnd.EndPaint(&ps); 
}

LRESULT CMorseKernelVisualizationDirectGraph2D::OnEnterMove(UINT msg, WPARAM w, LPARAM l, BOOL&) {
	return DefWindowProc(msg, w, l);	
}

LRESULT CMorseKernelVisualizationDirectGraph2D::OnSize(UINT msg, WPARAM w, LPARAM l, BOOL&) {
	return DefWindowProc(msg, w, l);
}
LRESULT CMorseKernelVisualizationDirectGraph2D::OnExitMove(UINT msg, WPARAM w, LPARAM l, BOOL&) {
	return DefWindowProc(msg, w, l);
}
LRESULT CMorseKernelVisualizationDirectGraph2D::OnMouseMove(UINT msg, WPARAM w, LPARAM l, BOOL&) {
	if (m_hD3D != NULL) {
		D3DGraph2D::MousePoint pt;
		m_hD3D->getMouseCoordinate(MAKEPOINTS(l), pt);
		__raise OnMouseMoveFloat(pt.x, pt.y, 0);
		Node* tmp = m_hD3D->getCurrentNode(pt);
		if (currentNode != tmp) {
			currentNode = tmp;
			__raise ActiveLoop(-1);
		}
	}

	return 0L;
}
LRESULT CMorseKernelVisualizationDirectGraph2D::OnClose(UINT msg, WPARAM w, LPARAM l, BOOL&) {
	return DefWindowProc(msg, w, l);
}


/////////////////

STDMETHODIMP CMorseKernelVisualizationDirectGraph2D::MoveLeftAtom() {
	if (m_hD3D == NULL) return S_OK;
	m_hD3D->OnMove(-1.0f, 0.0f, 1.0f);
	Repaint();
	return S_OK;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph2D::MoveRightAtom() {
	if (m_hD3D == NULL) return S_OK;
	m_hD3D->OnMove(1.0f, 0.0f, 1.0f);
	Repaint();
	return S_OK;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph2D::MoveUpAtom() {
	if (m_hD3D == NULL) return S_OK;
	m_hD3D->OnMove(0.0f, 1.0f, 1.0f);
	Repaint();
	return S_OK;
}
STDMETHODIMP CMorseKernelVisualizationDirectGraph2D::MoveDownAtom() {
	if (m_hD3D == NULL) return S_OK;
	m_hD3D->OnMove(0.0f, -1.0f, 1.0f);
	Repaint();
	return S_OK;
}
STDMETHODIMP CMorseKernelVisualizationDirectGraph2D::ZoomOutAtom() {
	if (m_hD3D == NULL) return S_OK;
	m_hD3D->OnMove(0.0f, 0.0f, 2.0f);
	Repaint();
	return S_OK;
}
STDMETHODIMP CMorseKernelVisualizationDirectGraph2D::ZoomInAtom() {
	if (m_hD3D == NULL) return S_OK;
	m_hD3D->OnMove(0.0f, 0.0f, 0.5f);
	Repaint();
	return S_OK;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph2D::CenterView() {
	if (m_hD3D == NULL) return S_OK;
	m_hD3D->OnCenterView();
	Repaint();
	return S_OK;
}

STDMETHODIMP CMorseKernelVisualizationDirectGraph2D::SetGraph(void ** pgraph) {
	Graph* graph = *(Graph**) pgraph;
	GraphColor* color = new GraphColor(); 

	printf("Set Graph: Nodes: %d\n", graph->getNumberOfNodes());

	if (m_hD3D != NULL) {
		m_hD3D->Dispose();
		delete m_hD3D;
	}

	m_hD3D = new D3DGraph2D();
				//HWND hwnd, Graph* graph, GraphColor* color, int dim1, int dim2);
	HRESULT hr = m_hD3D->Create(m_hWnd, graph, color, 0, 1);
	if (FAILED(hr)) {
		m_hD3D->Dispose();
		delete m_hD3D;
		m_hD3D = NULL;

		printf("D3DCreate failed! \n");

		return E_FAIL;
	}

	currentNode = NULL;

	Repaint();
			
	return S_OK;

}

STDMETHODIMP CMorseKernelVisualizationDirectGraph2D::SetTestGraph() {
	JInt grid[] = {50,50};
	JDouble gmax[] = {1,1};
	JDouble gmin[] = {-1,-1};
	Graph* g = new Graph(2, gmin, gmax, grid);
	g->maximize();

	//note: Memory leaks here!

	return SetGraph((void**)&g);
}