========================================================================
    ACTIVE TEMPLATE LIBRARY : MorseKernel2 Project Overview
========================================================================

AppWizard has created this MorseKernel2 project for you to use as the starting point for
writing your Dynamic Link Library (DLL).
This project is implemented with Visual C++ attributes.

This file contains a summary of what you will find in each of the files that
make up your project.

MorseKernel2.vcproj
    This is the main project file for VC++ projects generated using an Application Wizard. 
    It contains information about the version of Visual C++ that generated the file, and 
    information about the platforms, configurations, and project features selected with the
    Application Wizard.

_MorseKernel2.idl
    This file will be generated by the compiler when the project is built. It will contain the IDL 
    definitions of the type library, the interfaces and co-classes defined in your project.
    This file will be processed by the MIDL compiler to generate:
        C++ interface definitions and GUID declarations (_MorseKernel2.h)
        GUID definitions                                (_MorseKernel2_i.c)
        A type library                                  (_MorseKernel2.tlb)
        Marshaling code                                 (_MorseKernel2_p.c and dlldata.c)
MorseKernel2.cpp
    This file contains the object map and the implementation of your DLL's exports.
MorseKernel2.rc
    This is a listing of all of the Microsoft Windows resources that the
    program uses.

MorseKernel2.def
    This module-definition file provides the linker with information about the exports
    required by your DLL. It contains exports for:
        DllGetClassObject  
        DllCanUnloadNow    
        GetProxyDllInfo    
        DllRegisterServer	
        DllUnregisterServer

/////////////////////////////////////////////////////////////////////////////
Other standard files:

StdAfx.h, StdAfx.cpp
    These files are used to build a precompiled header (PCH) file
    named MorseKernel2.pch and a precompiled types file named StdAfx.obj.

Resource.h
    This is the standard header file that defines resource IDs.

/////////////////////////////////////////////////////////////////////////////
Proxy/stub DLL project and module definition file:

MorseKernel2ps.vcproj
    This file is the project file for building a proxy/stub DLL if necessary.
	The IDL file in the main project must contain at least one interface and you must 
	first compile the IDL file before building the proxy/stub DLL.	This process generates
	dlldata.c, MorseKernel2_i.c and MorseKernel2_p.c which are required
	to build the proxy/stub DLL.

MorseKernel2ps.def
    This module definition file provides the linker with information about the exports
    required by the proxy/stub.
/////////////////////////////////////////////////////////////////////////////
Other notes:

	The COM+ 1.0 Support option builds the COM+ 1.0 library into your skeleton application,
	making COM+ 1.0 classes, objects, and functions available to you.
/////////////////////////////////////////////////////////////////////////////
