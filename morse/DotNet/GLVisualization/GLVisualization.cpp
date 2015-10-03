// GLVisualization.cpp : Implementation of DLL Exports.
//
// Note: COM+ 1.0 Information:
//      Please remember to run Microsoft Transaction Explorer to install the component(s).
//      Registration is not done by default. 

#include "stdafx.h"
#include "resource.h"
#include "compreg.h"

// The module attribute causes DllMain, DllRegisterServer and DllUnregisterServer to be automatically implemented for you
[ module(dll, uuid = "{7C814E07-7943-4389-96D9-A9F74F88EB22}", 
		 name = "GLVisualization", 
		 helpstring = "GLVisualization 1.0 Type Library",
		 resource_name = "IDR_GLVISUALIZATION", 
		 custom = { "a817e7a1-43fa-11d0-9e44-00aa00b6770a", "{587BC862-099F-4C1C-B051-A193B0D28DFD}"}) ]
class CGLVisualizationModule
{
public:
// Override CAtlDllModuleT members
};
		 
