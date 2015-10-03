// MorseKernel2.cpp : Implementation of DLL Exports.
//
// Note: COM+ 1.0 Information:
//      Please remember to run Microsoft Transaction Explorer to install the component(s).
//      Registration is not done by default. 

#include "stdafx.h"
#include "resource.h"
#include "compreg.h"

// The module attribute causes DllMain, DllRegisterServer and DllUnregisterServer to be automatically implemented for you
[ module(dll, uuid = "{922445B5-C296-49D0-B69D-45FF70F8CE56}", 
		 name = "MorseKernel2", 
		 helpstring = "MorseKernel2 1.0 Type Library",
		 resource_name = "IDR_MORSEKERNEL2", 
		 custom = { "a817e7a1-43fa-11d0-9e44-00aa00b6770a", "{84035475-16DE-4504-ABF2-5C734E46A96A}"}) ]
class CMorseKernel2Module
{
public:
// Override CAtlDllModuleT members
};
		 
