// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

/*

#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers
#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS	// some CString constructors will be explicit

#ifndef VC_EXTRALEAN
#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers
#endif

#include <afx.h>
#include <afxwin.h>         // MFC core and standard components

*/

#include <iostream>

#include "../graph/stdafx.h"

#include "../graph/FunctionInclude.h"
#include "../graph/typedefs.h"
#include "../graph/Graph.h"
#include "../graph/GraphException.h"
#include "../graph/Function.h"
#include "../graph/SIComputationProcess.h"
#include "../graph/Computator.h"
#include "../graph/GraphComponents.h"
#include "..\graph\functionMS.h"
#include "..\graph\FileStream.h"
#include "..\graph_simplex\RomDebug.h"
#define _USE_MATH_DEFINES
#include <Math.h>
#include <map>
#include <list>

#include "../cellImageBuilders/SIPointBuilder.h"
#include "../cellImageBuilders/MS3PointBuilder.h"
#include "../cellImageBuilders/MS2PointBuilder.h"
using namespace std;


// TODO: reference additional headers your program requires here
