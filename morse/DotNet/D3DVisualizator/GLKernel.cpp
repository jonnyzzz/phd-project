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

    // Создаем контекст воспроизведения
    if((hrc = ::wglCreateContext(hdc)) == NULL) return false;

    // Делаем контекст воспроизведения текущим
    if(::wglMakeCurrent(hdc, hrc) == FALSE) return FALSE;

    isInitialized = true;
    return true;
}




void GLKernel::Dispose() {

}

bool GLKernel::SetPixelFormat(HDC hdc)
{
 // Заполняем поля структуры
  static PIXELFORMATDESCRIPTOR pfd = 	{
    sizeof(PIXELFORMATDESCRIPTOR),  // размер структуры
    1,                              // номер версии
    PFD_DRAW_TO_WINDOW   |          // поддержка вывода в окно
    PFD_SUPPORT_OPENGL   |          // поддержка OpenGL
    PFD_DOUBLEBUFFER,               // двойная буферизация
    PFD_TYPE_RGBA,         // цвета в режиме RGBA
    24,                    // 24-разряда на цвет
    0, 0, 0, 0, 0, 0,      // биты цвета игнорируются
    0,                     // не используется альфа параметр
    0,                     // смещение цветов игнорируются
    0,                     // буфер аккумулятора не используется
    0, 0, 0, 0,            // биты аккумулятора игнорируются
    32,                    // 32-разрядный буфер глубины
    0,                     // буфер трафарета не используется
    0,                     // вспомогательный буфер не используется
    PFD_MAIN_PLANE,        // основной слой
    0,                     // зарезервирован
    0, 0, 0                // маски слоя игнорируются
  };
  
  int pixelFormat;
  
// Поддерживает ли система необходимый формат пикселей?
  if((pixelFormat = ::ChoosePixelFormat(hdc, &pfd)) == 0){
    MessageBox(NULL, "С заданным форматом пикселей работать нельзя", 0, 0);
    return false;
  }

  if (::SetPixelFormat(hdc, pixelFormat, &pfd) == FALSE)
    {
      MessageBox(NULL,"Ошибка при выполнении SetPixelFormat", 0, 0);
      return false;
    }

  return true;
}