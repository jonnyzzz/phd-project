

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Sat Mar 12 00:20:39 2005
 */
/* Compiler settings for _GLVisualization.idl:
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


MIDL_DEFINE_GUID(IID, IID_IGL3D,0xB1D47447,0xE686,0x41A7,0x9A,0x02,0x6B,0xC3,0xCC,0xFF,0x02,0x69);


MIDL_DEFINE_GUID(IID, LIBID_GLVisualization,0x7C814E07,0x7943,0x4389,0x96,0xD9,0xA9,0xF7,0x4F,0x88,0xEB,0x22);


MIDL_DEFINE_GUID(CLSID, CLSID_CCompReg,0x587BC862,0x099F,0x4C1C,0xB0,0x51,0xA1,0x93,0xB0,0xD2,0x8D,0xFD);


MIDL_DEFINE_GUID(IID, DIID__IGL3DEvents,0xF37FCEE2,0xA358,0x41D1,0xBF,0x3F,0xD1,0x9C,0xAA,0x7F,0x7D,0x01);


MIDL_DEFINE_GUID(CLSID, CLSID_CGL3D,0xF0160158,0x6F4D,0x4AD0,0xAC,0x2B,0xC5,0x77,0x3E,0x2A,0x17,0x54);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



#endif /* !defined(_M_IA64) && !defined(_M_AMD64)*/

