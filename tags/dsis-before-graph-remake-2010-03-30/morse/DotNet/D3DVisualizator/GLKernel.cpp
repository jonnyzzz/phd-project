#include "stdafx.h"
#include ".\glkernel.h"

GLKernel::GLKernel(void)
{
    hwnd = NULL;
    isInitialized = false;
}

GLKernel::~GLKernel(void)
{
}



bool GLKernel::Create(HWND hwnd) {
    HDC hdc = GetDC(hwnd);

    if (SetPixelFormat(hdc) == false) return false;

    HGLRC hrc;

    // ������� �������� ���������������
    if((hrc = ::wglCreateContext(hdc)) == NULL) return false;

    // ������ �������� ��������������� �������
    if(::wglMakeCurrent(hdc, hrc) == FALSE) return FALSE;

    isInitialized = true;
    return true;
}




void GLKernel::Dispose() {

}

bool GLKernel::SetPixelFormat(HDC hdc)
{
 // ��������� ���� ���������
  static PIXELFORMATDESCRIPTOR pfd = 	{
    sizeof(PIXELFORMATDESCRIPTOR),  // ������ ���������
    1,                              // ����� ������
    PFD_DRAW_TO_WINDOW   |          // ��������� ������ � ����
    PFD_SUPPORT_OPENGL   |          // ��������� OpenGL
    PFD_DOUBLEBUFFER,               // ������� �����������
    PFD_TYPE_RGBA,         // ����� � ������ RGBA
    24,                    // 24-������� �� ����
    0, 0, 0, 0, 0, 0,      // ���� ����� ������������
    0,                     // �� ������������ ����� ��������
    0,                     // �������� ������ ������������
    0,                     // ����� ������������ �� ������������
    0, 0, 0, 0,            // ���� ������������ ������������
    32,                    // 32-��������� ����� �������
    0,                     // ����� ��������� �� ������������
    0,                     // ��������������� ����� �� ������������
    PFD_MAIN_PLANE,        // �������� ����
    0,                     // ��������������
    0, 0, 0                // ����� ���� ������������
  };
  
  int pixelFormat;
  
// ������������ �� ������� ����������� ������ ��������?
  if((pixelFormat = ::ChoosePixelFormat(hdc, &pfd)) == 0){
    MessageBox(NULL, "� �������� �������� �������� �������� ������", 0, 0);
    return false;
  }

  if (::SetPixelFormat(hdc, pixelFormat, &pfd) == FALSE)
    {
      MessageBox(NULL,"������ ��� ���������� SetPixelFormat", 0, 0);
      return false;
    }

  return true;
}