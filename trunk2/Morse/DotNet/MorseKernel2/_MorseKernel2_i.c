

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Thu Feb 24 21:35:30 2005
 */
/* Compiler settings for _MorseKernel2.idl:
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

MIDL_DEFINE_GUID(IID, IID_IActionBase,0x285691E1,0xBFC9,0x4E8B,0xBE,0x17,0x5B,0x1C,0xC2,0x30,0x2E,0xD9);


MIDL_DEFINE_GUID(IID, IID_IResult,0x9B7D45A5,0x77FD,0x4E97,0x8C,0x4A,0x76,0xD3,0x61,0x0C,0xC8,0x75);


MIDL_DEFINE_GUID(IID, IID_IActionManager,0x5EB44493,0x8FF9,0x486A,0x8A,0xBD,0x09,0xB9,0xF2,0x32,0x62,0x8A);


MIDL_DEFINE_GUID(IID, IID_IParameters,0x16C62C7B,0x6775,0x4D2B,0x9B,0xD2,0x43,0x62,0x4E,0x01,0x73,0x8B);


MIDL_DEFINE_GUID(IID, IID_IProgressBarInfo,0x54E003E2,0xEAA0,0x4321,0x9A,0x14,0x31,0xCF,0x8E,0x5B,0xCB,0x84);


MIDL_DEFINE_GUID(IID, IID_IAction,0xB94E10D8,0x08BD,0x405C,0xA4,0x35,0x08,0x68,0xDD,0x86,0xCD,0x3C);


MIDL_DEFINE_GUID(IID, IID_INode,0xD3BEDA0D,0x1771,0x4493,0xBB,0x5C,0xE9,0x33,0x84,0x79,0x2B,0x2A);


MIDL_DEFINE_GUID(IID, IID_IActionFactory,0x35F624D3,0xEB6C,0x4F79,0xAB,0x1E,0xC0,0x17,0x95,0xA0,0x8C,0x5A);


MIDL_DEFINE_GUID(IID, IID_IActionAllocator,0x9D90D301,0xE998,0x4229,0x98,0xC0,0x27,0xC5,0x96,0x90,0x30,0x8D);


MIDL_DEFINE_GUID(IID, IID_IWritableActionAllocator,0xBC2B7099,0xB5A6,0x4D0B,0xBD,0xE0,0xDA,0x02,0x7E,0x87,0xFF,0x93);


MIDL_DEFINE_GUID(IID, IID_IComponentRegistrar,0xa817e7a2,0x43fa,0x11d0,0x9e,0x44,0x00,0xaa,0x00,0xb6,0x77,0x0a);


MIDL_DEFINE_GUID(IID, IID_IGroupNode,0x28EBA211,0xE2B0,0x4717,0x87,0xAA,0x63,0xA0,0xA5,0xC7,0x6C,0xDC);


MIDL_DEFINE_GUID(IID, IID_IGraphResult,0x6E606370,0x04E2,0x4BCB,0x85,0x2C,0x31,0x3A,0x7D,0x4B,0xAD,0x15);


MIDL_DEFINE_GUID(IID, IID_IGraphNode,0x5CBE5D72,0x2BA0,0x4321,0xBB,0x64,0x07,0x72,0xD2,0x00,0x4C,0x9A);


MIDL_DEFINE_GUID(IID, LIBID_MorseKernel2,0x922445B5,0xC296,0x49D0,0xB6,0x9D,0x45,0xFF,0x70,0xF8,0xCE,0x56);


MIDL_DEFINE_GUID(CLSID, CLSID_CActionAllocator,0x43EAE42D,0xD986,0x4DAB,0x9D,0x7D,0xD4,0xB7,0x25,0xE7,0x7A,0xB0);


MIDL_DEFINE_GUID(CLSID, CLSID_CCompReg,0x84035475,0x16DE,0x4504,0xAB,0xF2,0x5C,0x73,0x4E,0x46,0xA9,0x6A);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



#endif /* !defined(_M_IA64) && !defined(_M_AMD64)*/

