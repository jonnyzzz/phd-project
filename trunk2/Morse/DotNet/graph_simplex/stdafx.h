// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#ifdef WIN32
	#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers
	#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS	// some CString constructors will be explicit

	#ifndef VC_EXTRALEAN
	#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers
	#endif

	#include <afx.h>
	#include <afxwin.h>         // MFC core and standard components
#else
	#include "../gcc/gcc.h"
#endif

#include <iostream>

#include "../graph/typedefs.h"
#include "../graph/Graph.h"
#include "../graph/FileStream.h"

using namespace std;

// TODO: reference additional headers your program requires here
