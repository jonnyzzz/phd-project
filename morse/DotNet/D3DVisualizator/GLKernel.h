

class GLKernel
{
public:
    GLKernel(void);
    virtual ~GLKernel(void);

public:
    bool Create(HWND hWnd);
    void Dispose();

public:


private:
    HWND hwnd;
    bool isInitialized;


private:
    bool SetPixelFormat(HDC hdc);
};
