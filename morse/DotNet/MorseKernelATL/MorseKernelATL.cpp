// MorseKernelATL.cpp : Implementation of DLL Exports.
//
// Note: COM+ 1.0 Information:
//      Please remember to run Microsoft Transaction Explorer to install the component(s).
//      Registration is not done by default. 

#include "stdafx.h"
#include "resource.h"
#include "compreg.h"

// The module attribute causes DllMain, DllRegisterServer and DllUnregisterServer to be automatically implemented for you
[ module(dll, uuid = "{13645F55-EF1A-4222-A209-709DC3A6E782}", 
		 name = "MorseKernelATL", 
		 helpstring = "MorseKernelATL",
		 resource_name = "IDR_MORSEKERNELATL", 
         custom = { "a817e7a1-43fa-11d0-9e44-00aa00b6770a", "{58BF9B64-D15E-4C43-9BA5-D579CF30099C}"}, 
         version = "1.1") 
]
class CMorseKernelATLModule
{
public:
// Override CAtlDllModuleT members
};
		 
