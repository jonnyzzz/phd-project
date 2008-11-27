#pragma once

class PWindow
{
public:
    PWindow(void);
    virtual ~PWindow(void);

public:
    bool Create(HWND parenthWnd);
    bool Create(HINSTANCE instance, HWND parenthWnd = NULL);
    void Dispose();


private:
    HINSTANCE instance;
    
    HWND parenthWnd;
    HWND hWnd;


    WNDCLASS wndClass;
};
