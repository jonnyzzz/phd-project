

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Tue Mar 15 00:45:26 2005
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


MIDL_DEFINE_GUID(IID, IID_IResultBase,0x92F4EEEF,0x602A,0x496D,0x80,0x67,0x51,0x84,0xF4,0xF1,0xD3,0x7B);


MIDL_DEFINE_GUID(IID, IID_IParameters,0x16C62C7B,0x6775,0x4D2B,0x9B,0xD2,0x43,0x62,0x4E,0x01,0x73,0x8B);


MIDL_DEFINE_GUID(IID, IID_IProgressBarInfo,0x54E003E2,0xEAA0,0x4321,0x9A,0x14,0x31,0xCF,0x8E,0x5B,0xCB,0x84);


MIDL_DEFINE_GUID(IID, IID_IAction,0xB94E10D8,0x08BD,0x405C,0xA4,0x35,0x08,0x68,0xDD,0x86,0xCD,0x3C);


MIDL_DEFINE_GUID(IID, IID_IFunction,0x63B946E2,0x2AEE,0x4034,0xBA,0x1C,0x1B,0x4C,0xFD,0x68,0xCE,0xC0);


MIDL_DEFINE_GUID(IID, IID_IComputationParameters,0xAB57FCFD,0x2759,0x4E43,0x80,0x95,0x34,0xFD,0x20,0xEA,0xAA,0x8B);


MIDL_DEFINE_GUID(IID, IID_IBoxMethodAction,0x586FAD2F,0xD9E4,0x4A30,0xA9,0x25,0x34,0x5C,0x7E,0x1B,0xDC,0x56);


MIDL_DEFINE_GUID(IID, IID_IBoxMethodParameters,0xEF3F28E7,0xDA5A,0x4294,0x9C,0x12,0x65,0x6D,0x0B,0x7C,0xB7,0x4A);


MIDL_DEFINE_GUID(IID, IID_IResultMerger,0x4D5B2A01,0x1CC2,0x4D56,0xA8,0xD7,0x67,0xC7,0x30,0xA0,0x57,0xED);


MIDL_DEFINE_GUID(IID, IID_IResult,0x9B7D45A5,0x77FD,0x4E97,0x8C,0x4A,0x76,0xD3,0x61,0x0C,0xC8,0x75);


MIDL_DEFINE_GUID(IID, IID_IGraphInfo,0x0641C669,0xB362,0x48C9,0x8B,0x73,0xD0,0x2B,0x6E,0x25,0x2A,0x9D);


MIDL_DEFINE_GUID(IID, IID_IGraphResult,0x6E606370,0x04E2,0x4BCB,0x85,0x2C,0x31,0x3A,0x7D,0x4B,0xAD,0x15);


MIDL_DEFINE_GUID(IID, IID_IWritableGraphResult,0x6ED8D0EA,0x3E9C,0x441A,0x96,0xC6,0xEE,0xB2,0xAF,0xCB,0xE2,0x7D);


MIDL_DEFINE_GUID(IID, IID_IComponentRegistrar,0xa817e7a2,0x43fa,0x11d0,0x9e,0x44,0x00,0xaa,0x00,0xb6,0x77,0x0a);


MIDL_DEFINE_GUID(IID, IID_IDummy,0x0A8C775B,0x8E19,0x4642,0xB2,0xD7,0x5B,0xBB,0x43,0x7B,0x7B,0x97);


MIDL_DEFINE_GUID(IID, IID_IWritableFunction,0x9B3DA2D8,0xE279,0x4552,0x99,0xF4,0x13,0xAA,0x06,0x66,0x42,0xD5);


MIDL_DEFINE_GUID(IID, IID_IWritableGraphInfo,0x5F89F9F3,0xAB8D,0x4129,0xA7,0x52,0x8A,0x42,0x58,0xA8,0xEC,0xE9);


MIDL_DEFINE_GUID(IID, IID_IKernell,0xF2D78B39,0xD782,0x49DE,0x91,0xB7,0x77,0x1C,0xDA,0x2E,0xD0,0xE0);


MIDL_DEFINE_GUID(IID, IID_IWritableKernell,0xDB255DC6,0x645A,0x4D60,0xA7,0xC6,0x5D,0x30,0x19,0xC2,0xDB,0xB7);


MIDL_DEFINE_GUID(IID, IID_ITarjanAction,0xFAFD82A9,0x346E,0x4BD7,0x83,0x16,0xF1,0x6B,0x10,0x5A,0x46,0x53);


MIDL_DEFINE_GUID(IID, IID_ITarjanParameters,0x8DB63B4A,0x7E18,0x4328,0x93,0x35,0x41,0x9C,0x4C,0xE5,0xA4,0xE5);


MIDL_DEFINE_GUID(IID, LIBID_MorseKernel2,0x922445B5,0xC296,0x49D0,0xB6,0x9D,0x45,0xFF,0x70,0xF8,0xCE,0x56);


MIDL_DEFINE_GUID(CLSID, CLSID_CBoxMethodAction,0xFDA0C930,0xC1F5,0x40C0,0xA0,0xB6,0xA9,0x78,0xCD,0xA9,0x3F,0x50);


MIDL_DEFINE_GUID(CLSID, CLSID_CGraphResultImpl,0x43037E6F,0x9884,0x4D5C,0xBB,0x41,0x44,0xD5,0x82,0x88,0x8F,0x9E);


MIDL_DEFINE_GUID(CLSID, CLSID_CCompReg,0x84035475,0x16DE,0x4504,0xAB,0xF2,0x5C,0x73,0x4E,0x46,0xA9,0x6A);


MIDL_DEFINE_GUID(CLSID, CLSID_CDummy,0x8C3F6AAB,0xF725,0x4C70,0xA9,0x2A,0x7E,0x4B,0xD2,0xA3,0x0C,0x23);


MIDL_DEFINE_GUID(CLSID, CLSID_CFunctionImpl,0xFDFB8D0E,0x74FF,0x439C,0xA1,0x3B,0x4A,0x39,0x38,0x7B,0x70,0x37);


MIDL_DEFINE_GUID(CLSID, CLSID_CGraphInfoImpl,0x1FCB1E52,0xC321,0x4E44,0x8B,0xA6,0x83,0xDA,0x8C,0x53,0x23,0x65);


MIDL_DEFINE_GUID(CLSID, CLSID_CKernellImpl,0x96E908D0,0x29BD,0x423D,0x8C,0xA8,0x9F,0x43,0x43,0xC7,0x96,0xA0);


MIDL_DEFINE_GUID(CLSID, CLSID_CTarjanAction,0x76C75A0A,0xAC4C,0x4CA9,0x8A,0x4E,0xD8,0x28,0x33,0x88,0xC3,0x61);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



#endif /* !defined(_M_IA64) && !defined(_M_AMD64)*/

