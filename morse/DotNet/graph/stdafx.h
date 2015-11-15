// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#ifdef WIN32

#define _SILENCE_STDEXT_HASH_DEPRECATION_WARNINGS

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

#include "typedefs.h"
//#include "FunctionInclude.h"
//#include "../graph_simplex/Rom.h"

using namespace std;
