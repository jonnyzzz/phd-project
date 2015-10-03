#include "StdAfx.h"
#include ".\pwindow.h"

#include <map>
using namespace std;

typedef map<HWND, PWindow*> WindowClasses;

WindowClasses windowClasses;

PWindow::PWindow(void)
{
    this->hWnd = NULL;
    this->parenthWnd = NULL;
    this->instance = NULL;
}

PWindow::~PWindow(void)
{
}


LRESULT CALLBACK WindowsProcedure(HWND hwnd, UINT msg, WPARAM wparam, LPARAM lparam);

bool PWindow::Create(HWND hWnd) {
    this->instance = (HINSTANCE) GetWindowLongPtr(hWnd, GWLP_HINSTANCE);
    return this->Create(this->instance, hWnd);
}

bool PWindow::Create(HINSTANCE instance, HWND parenthWnd) {    
    this->parenthWnd = parenthWnd;
    this->instance = instance;

       
    wndClass.cbClsExtra = 0;
	wndClass.cbWndExtra = 0;
    wndClass.hbrBackground = NULL; 
	wndClass.hCursor = NULL;
	wndClass.hIcon = NULL;
    wndClass.hInstance = instance;
    wndClass.lpfnWndProc = WindowsProcedure;
    wndClass.lpszClassName = "SomeClasSNameJ";
	wndClass.lpszMenuName = NULL;
    wndClass.style = CS_DBLCLKS | CS_HREDRAW | CS_VREDRAW; //CS_HREDRAW | CS_VREDRAW; // WS_CHILD ;// | WS_CLIPCHILDREN | WS_CLIPSIBLINGS  ;
    
    if (RegisterClass(&wndClass) != 0) {
        MessageBox(NULL, "Failed to register Class", 0, 0);
        return false;
    }

    MessageBox(NULL, "Alive!", NULL, 0);

    CREATESTRUCT cs;
    ZeroMemory(&cs, sizeof(cs));

    cs.hInstance = instance;
    cs.lpszClass = wndClass.lpszClassName;
    cs.style = WS_VISIBLE | WS_CHILD;

    this->hWnd = CreateWindow(
        wndClass.lpszClassName, 
        "Title", 
        WS_CHILD | WS_VISIBLE,
        1,
        1, 
        100,
        100,
        this->parenthWnd,
        NULL,
        wndClass.hInstance,
        &cs);

    MessageBox(NULL, "OK", NULL, 0);

    if (this->hWnd == NULL) MessageBox(NULL, "!!!!", NULL, 0);

    if (this->hWnd == NULL) return false;

    ShowWindow(hWnd, SW_SHOW);

    MessageBox(NULL, "Window was created sucessfully\n", NULL, 0);

    return true;
}

LRESULT CALLBACK WindowsProcedure(HWND hwnd, UINT msg, WPARAM wparam, LPARAM lparam) {
    MessageBox(NULL, "CallWindowProcedure", NULL, 0);

    return DefWindowProc(hwnd, msg, wparam, lparam);
}


void PWindow::Dispose() {
    
}
