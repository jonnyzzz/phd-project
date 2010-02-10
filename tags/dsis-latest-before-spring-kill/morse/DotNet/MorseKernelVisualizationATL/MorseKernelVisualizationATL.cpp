// MorseKernelVisualizationATL.cpp : Implementation of DLL Exports.
//
// Note: COM+ 1.0 Information:
//      Please remember to run Microsoft Transaction Explorer to install the component(s).
//      Registration is not done by default. 

#include "stdafx.h"
#include "resource.h"
#include "compreg.h"

// The module attribute causes DllMain, DllRegisterServer and DllUnregisterServer to be automatically implemented for you
[ module(dll, uuid = "{EC4C473F-66E4-4129-BE42-48D9BEF71D34}", 
		 name = "MorseKernelVisualizationATL", 
		 helpstring = "MorseKernelVisualizationATL 1.0 Type Library",
		 resource_name = "IDR_MORSEKERNELVISUALIZATIONATL", 
		 custom = { "a817e7a1-43fa-11d0-9e44-00aa00b6770a", "{C5F4E1EE-5450-4DED-B0A0-97941189B524}"}) ]
class CMorseKernelVisualizationATLModule
{
public:
// Override CAtlDllModuleT members
};
		 
