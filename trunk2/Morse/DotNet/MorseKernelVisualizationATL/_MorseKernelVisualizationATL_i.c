

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Thu Feb 10 01:29:49 2005
 */
/* Compiler settings for _MorseKernelVisualizationATL.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#if !defined(_M_IA64) && !defined(_M_AMD64)


#pragma warning( disable: 4049 )  /* more than 64k source lines */


#ifdef __cplusplus
extern "C"{
#endif 


#include <rpc.h>
#include <rpcndr.h>

#ifdef _MIDL_USE_GUIDDEF_

#ifndef INITGUID
#define INITGUID
#include <guiddef.h>
#undef INITGUID
#else
#include <guiddef.h>
#endif

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        DEFINE_GUID(name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8)

#else // !_MIDL_USE_GUIDDEF_

#ifndef __IID_DEFINED__
#define __IID_DEFINED__

typedef struct _IID
{
    unsigned long x;
    unsigned short s1;
    unsigned short s2;
    unsigned char  c[8];
} IID;

#endif // __IID_DEFINED__

#ifndef CLSID_DEFINED
#define CLSID_DEFINED
typedef IID CLSID;
#endif // CLSID_DEFINED

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        const type name = {l,w1,w2,{b1,b2,b3,b4,b5,b6,b7,b8}}

#endif !_MIDL_USE_GUIDDEF_

MIDL_DEFINE_GUID(IID, IID_IComponentRegistrar,0xa817e7a2,0x43fa,0x11d0,0x9e,0x44,0x00,0xaa,0x00,0xb6,0x77,0x0a);


MIDL_DEFINE_GUID(IID, IID_IMorseKernelVisualizationDirect3D,0x35435412,0x4462,0x4A3D,0xA9,0xC8,0xCE,0xB1,0x1A,0xC9,0x00,0xEE);


MIDL_DEFINE_GUID(IID, IID_IMorseKernelVisualizationDirectGraph3D,0xADE7B805,0x2B13,0x46CC,0x9F,0x90,0x7E,0x4E,0x6D,0x1B,0x93,0x84);


MIDL_DEFINE_GUID(IID, IID_IMorseKernelVisualizationDirectGraph2D,0x31146F99,0xAA89,0x4E63,0x94,0xB2,0xCF,0xF1,0x35,0x8E,0x46,0xED);


MIDL_DEFINE_GUID(IID, LIBID_MorseKernelVisualizationATL,0xEC4C473F,0x66E4,0x4129,0xBE,0x42,0x48,0xD9,0xBE,0xF7,0x1D,0x34);


MIDL_DEFINE_GUID(CLSID, CLSID_CCompReg,0xC5F4E1EE,0x5450,0x4DED,0xB0,0xA0,0x97,0x94,0x11,0x89,0xB5,0x24);


MIDL_DEFINE_GUID(IID, DIID__IMorseKernelVisualizationDirect3DEvents,0xFE6F9A99,0xFF69,0x44D9,0x89,0xAD,0x68,0x5E,0x6C,0x73,0x03,0xCA);


MIDL_DEFINE_GUID(CLSID, CLSID_CMorseKernelVisualizationDirectGraph3D,0x3CF9772B,0xCC75,0x4596,0xA5,0xEC,0x90,0x3D,0x6A,0xBD,0x49,0x83);


MIDL_DEFINE_GUID(CLSID, CLSID_CMorseKernelVisualizationDirectGraph2D,0x2BBDCC1B,0x8356,0x4536,0x9C,0x86,0x0C,0xBA,0xBD,0x91,0x58,0xB0);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



#endif /* !defined(_M_IA64) && !defined(_M_AMD64)*/

