// GL3D.cpp : Implementation of CGL3D
#include "stdafx.h"
#include <gl/gl.h>
#include <gl/glu.h>

#include "GL3D.h"

#define SHOWERROR(x) {ShowErrorMessage(x, __FUNCTION__, __LINE__, __FILE__);};

// CGL3D

HRESULT CGL3D::FinalConstruct() {
	glRC = NULL;
	return S_OK;
}

void CGL3D::FinalRelease() {

}

LRESULT CGL3D::OnPaint(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled) {	
	/*
	PAINTSTRUCT ps;	
	CAxWindow wnd(m_hWnd);
	HDC hDC = wnd.BeginPaint(&ps);	
	RECT r;
	wnd.GetClientRect(&r);
	Rectangle(hDC, 0,0, r.right, r.bottom);	
	wnd.EndPaint(&ps); 

	bHandled = TRUE;
	*/

    glClear( GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT ); 
 
	
    glPushMatrix(); 
	
	glColor3f(1.0, 1.0, 1.0);
	presentBox();
 
    glPopMatrix(); 
	
	
	SwapBuffers(GetWindowDC());   

	return 0L;
}

LRESULT CGL3D::OnCreate(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled) {
	HDC hdc = this->GetWindowDC();
	RECT r;
	GetClientRect(&r);

	setPixelFormat(hdc);
	initializeGL();
	createBox();

	bHandled = false;
	return 0L;
}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Debugging

void CGL3D::ShowErrorMessage(LPCSTR message) {
    TCHAR szBuf[800]; 
    LPVOID lpMsgBuf;
    DWORD dw = GetLastError(); 

    FormatMessage(
        FORMAT_MESSAGE_ALLOCATE_BUFFER | 
        FORMAT_MESSAGE_FROM_SYSTEM,
        NULL,
        dw,
        MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
        (LPTSTR) &lpMsgBuf,
        0, NULL );

    wsprintf(szBuf, 
		"%s\n failed with error %d: %s", message, 
        dw, lpMsgBuf); 
 
    MessageBox(szBuf, "Error", MB_OK); 

    LocalFree(lpMsgBuf);
}

void CGL3D::ShowErrorMessage(LPCSTR message, LPCSTR function, long line, LPCSTR file) {
    TCHAR szBuf[800]; 
    LPVOID lpMsgBuf;
    DWORD dw = GetLastError(); 

    FormatMessage(
        FORMAT_MESSAGE_ALLOCATE_BUFFER | 
        FORMAT_MESSAGE_FROM_SYSTEM,
        NULL,
        dw,
        MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
        (LPTSTR) &lpMsgBuf,
        0, NULL );

    wsprintf(szBuf, 
		"%s(%s - %s at %d) \n failed with error %d: %s", 
		message, file, function, line, 
        dw, lpMsgBuf); 
 
    MessageBox(szBuf, "Error", MB_OK); 

    LocalFree(lpMsgBuf);
}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// OpenGL

BOOL CGL3D::setPixelFormat(HDC hdc) 
{ 
    PIXELFORMATDESCRIPTOR pfd, *ppfd; 
    int pixelformat; 
 
    ppfd = &pfd; 
 
    ppfd->nSize = sizeof(PIXELFORMATDESCRIPTOR); 
    ppfd->nVersion = 1; 
    ppfd->dwFlags = PFD_DRAW_TO_WINDOW | PFD_SUPPORT_OPENGL |  
                        PFD_DOUBLEBUFFER; 
    ppfd->dwLayerMask = PFD_MAIN_PLANE; 
    ppfd->iPixelType = PFD_TYPE_COLORINDEX; 
    ppfd->cColorBits = 8; 
    ppfd->cDepthBits = 16; 
    ppfd->cAccumBits = 0; 
    ppfd->cStencilBits = 0; 
 
    pixelformat = ChoosePixelFormat(hdc, ppfd); 
 
    if ( (pixelformat = ChoosePixelFormat(hdc, ppfd)) == 0 ) 
    { 
		SHOWERROR("ChoosePixelFormat failed"); 
        return FALSE; 
    } 
 
    if (SetPixelFormat(hdc, pixelformat, ppfd) == FALSE) 
    { 
        SHOWERROR("SetPixelFormat failed"); 
        return FALSE; 
    } 
 
    return TRUE; 
} 


void CGL3D::initializeGL() 
{ 
	 HDC hdc = GetWindowDC();
 	 glRC = wglCreateContext(hdc); 
     wglMakeCurrent(hdc, glRC); 

    //glClearIndex( (GLfloat)BLACK_INDEX); 
    glClearDepth( 1.0 ); 
 
    glEnable(GL_DEPTH_TEST); 
 
    resize();
}


void CGL3D::resize() 
{ 
	RECT r;
	GetClientRect(&r);
    
	GLsizei height = r.bottom - r.top;
	GLsizei width = r.right - r.left;

    GLfloat aspect; 
 
	glViewport( r.left, r.top, width, height ); 
 
    aspect = (GLfloat) width / height; 
 
    glMatrixMode( GL_PROJECTION ); 
    glLoadIdentity(); 
    gluPerspective( 45.0, aspect, 3.0, 7.0 ); 
    glMatrixMode( GL_MODELVIEW ); 
}     


///////////////////////////////////////////////////////////////////////////////////////////////////
// Data

void CGL3D::createBox() {

	int size = 1;

	glNewList( 1, GL_COMPILE);
	    glBegin(GL_POLYGON); // right
			glNormal3d(  0.0,  0.0,  size);

	        glVertex3d( size,  size, size); 
	        glVertex3d(-size,  size, size);            
	        glVertex3d(-size, -size, size);           
	        glVertex3d( size, -size, size);            
	    glEnd();

	    glBegin(GL_POLYGON);	//left
			glNormal3d( 0.0,  0.0, -size);

	        glVertex3d( size,  size, -size);
	        glVertex3d( size, -size, -size);           
	        glVertex3d(-size, -size, -size);          
	        glVertex3d(-size,  size, -size);           
	    glEnd();

	    glBegin(GL_POLYGON); //Font
			glNormal3d(-size,  0.0,  0.0);

	        glVertex3d(-size,  size,  size);
	        glVertex3d(-size,  size, -size);           
	        glVertex3d(-size, -size, -size);          
	        glVertex3d(-size, -size,  size);           
	    glEnd();

	    glBegin(GL_POLYGON);  //Back
			glNormal3d(size,  0.0,  0.0);

	        glVertex3d(size,  size,  size);
	        glVertex3d(size, -size,  size);            
	        glVertex3d(size, -size, -size);           
	        glVertex3d(size,  size, -size);            
	    glEnd();

	    glBegin(GL_POLYGON);  //Top
			glNormal3d( 0.0, size,  0.0);

	        glVertex3d(-size, size, -size);
	        glVertex3d(-size, size,  size);            
	        glVertex3d( size, size,  size);             
	        glVertex3d( size, size, -size);            
	    glEnd();

	    glBegin(GL_POLYGON);	//Bottom
			glNormal3d( 0.0, -size,  0.0);

	        glVertex3d(-size, -size, -size);
	        glVertex3d( size, -size, -size);           
	        glVertex3d( size, -size,  size);            
	        glVertex3d(-size, -size,  size);           
	    glEnd();
	glEndList();
}

void CGL3D::presentBox() {
	glCallList( 1);
}