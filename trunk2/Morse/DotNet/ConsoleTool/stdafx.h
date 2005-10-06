// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once


#ifdef WIN32

	#ifndef VC_EXTRALEAN
	#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers
	#endif

	#include <afx.h>
	#include <afxwin.h>         // MFC core and standard components
	#include <afxext.h>         // MFC extensions
	#include <afxdtctl.h>		// MFC support for Internet Explorer 4 Common Controls
	#ifndef _AFX_NO_AFXCMN_SUPPORT
	#include <afxcmn.h>			// MFC support for Windows Common Controls
	#endif // _AFX_NO_AFXCMN_SUPPORT
#else 
	#include "../gcc/gcc.h"
#endif

#include <iostream>
using namespace std;
// TODO: reference additional headers your program requires here
