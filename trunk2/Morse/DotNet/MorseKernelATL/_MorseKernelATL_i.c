

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Fri Jan 07 05:15:39 2005
 */
/* Compiler settings for _MorseKernelATL.idl:
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

MIDL_DEFINE_GUID(IID, IID_IGraphInfo,0xCE2B6190,0xCBC5,0x4104,0xA0,0xE0,0xD7,0xB3,0xFE,0x56,0x78,0x67);


MIDL_DEFINE_GUID(IID, IID_IParams,0xE478D112,0x3D56,0x478E,0x86,0xC0,0xD5,0x19,0x86,0x51,0x95,0x02);


MIDL_DEFINE_GUID(IID, IID_ISubdevideParams,0xF8ED2FD5,0xC65C,0x4C11,0xAB,0xD0,0x6D,0xC5,0x3A,0x7F,0x05,0xCD);


MIDL_DEFINE_GUID(IID, IID_IExtendableParams,0xCC76B166,0x5482,0x4EA8,0x97,0x7D,0xD4,0x70,0x05,0xF2,0xBB,0x17);


MIDL_DEFINE_GUID(IID, IID_ISubdevidePointParams,0xE6F9519F,0x6BF8,0x45E0,0xAC,0xA2,0x4E,0x71,0x0F,0x23,0xF8,0x0C);


MIDL_DEFINE_GUID(IID, IID_IKernelPointer,0x18C498C5,0x231C,0x4F6A,0xA4,0x01,0x3C,0x76,0xF5,0xD9,0xD7,0xA8);


MIDL_DEFINE_GUID(IID, IID_IKernelNode,0xE7A4DBC7,0x26F3,0x487B,0x9E,0xAD,0xE2,0xA7,0xF6,0xAF,0x82,0xE1);


MIDL_DEFINE_GUID(IID, IID_IGraph,0x3A59CE0B,0xD214,0x4BD9,0xBB,0x1A,0x57,0x78,0x22,0xA5,0x82,0xEE);


MIDL_DEFINE_GUID(IID, IID_ISubdevidable,0x02431842,0x302A,0x4760,0x80,0xA0,0x1F,0xD2,0xC1,0x61,0xD6,0xAC);


MIDL_DEFINE_GUID(IID, IID_ISubdevidablePoint,0x2EBA1301,0xAB35,0x4CC6,0xBA,0x28,0xD2,0xFC,0xB0,0xCE,0xD0,0x2B);


MIDL_DEFINE_GUID(IID, IID_IExtendable,0x26DF2357,0x91F9,0x4C63,0x94,0x17,0x27,0x62,0xB0,0xF8,0x34,0x01);


MIDL_DEFINE_GUID(IID, IID_IMorsable,0xAF4F6B4B,0xC82F,0x49B9,0x9B,0x01,0x16,0x7D,0x5E,0x38,0xAD,0x69);


MIDL_DEFINE_GUID(IID, IID_IExportData,0x424DB12A,0x2DE1,0x4A38,0x9C,0xA0,0x2F,0x52,0xDF,0x62,0x94,0x4D);


MIDL_DEFINE_GUID(IID, IID_IComputationResult,0xEA038030,0x124F,0x4F15,0xAC,0xD4,0xE0,0x50,0x0C,0x51,0x10,0xA3);


MIDL_DEFINE_GUID(IID, IID_IComputationGraphResult,0x5195A2BC,0x243D,0x4DA4,0xB6,0x8F,0x90,0x15,0xD3,0x38,0x2D,0xB9);


MIDL_DEFINE_GUID(IID, IID_IComputationMorseResult,0x6C613BDB,0xC2CE,0x47EA,0x9B,0xA0,0x9F,0x2B,0x2D,0x25,0x90,0x16);


MIDL_DEFINE_GUID(IID, IID_IGroupNode,0x243208B9,0xC9C1,0x429C,0x92,0xE5,0xA1,0x58,0x9F,0x15,0x63,0x76);


MIDL_DEFINE_GUID(IID, IID_IComponentRegistrar,0xa817e7a2,0x43fa,0x11d0,0x9e,0x44,0x00,0xaa,0x00,0xb6,0x77,0x0a);


MIDL_DEFINE_GUID(IID, IID_IFunctionEvents,0x47A8D8C4,0x8744,0x4150,0xA8,0xF9,0x27,0x8A,0xE0,0x8C,0x4D,0xA4);


MIDL_DEFINE_GUID(IID, IID_IFunction,0x83229BF2,0x7EB9,0x428D,0xB8,0x32,0x83,0x1C,0xAC,0xFA,0xE7,0x8C);


MIDL_DEFINE_GUID(IID, IID_IKernelEvents,0x7B44B0BB,0x0C63,0x4216,0x80,0xB1,0xE2,0x28,0x56,0x5D,0xF7,0x3D);


MIDL_DEFINE_GUID(IID, IID_IKernel,0x8D366F71,0xEA60,0x4812,0xAF,0xCD,0xBC,0x5A,0x20,0x29,0x7F,0xDD);


MIDL_DEFINE_GUID(IID, IID_IComputationGraphResultExt,0xA16233C4,0x8412,0x43B1,0xB8,0xFB,0xC3,0x39,0xF8,0x6E,0xFB,0x55);


MIDL_DEFINE_GUID(IID, IID_IMorseSpectrum,0xE9A021D4,0x77A7,0x458E,0xBB,0x1F,0x2F,0x84,0xDF,0x48,0xB9,0x82);


MIDL_DEFINE_GUID(IID, IID_IProjectiveBundle,0x1C62FD1D,0xF7D8,0x417E,0x9D,0xAA,0x5A,0xEC,0xF0,0x7C,0xF7,0xD3);


MIDL_DEFINE_GUID(IID, IID_ISymbolicImage,0xFA9817A1,0x3666,0x41E7,0x8F,0xCF,0x09,0x85,0xA4,0x3D,0x5F,0xA6);


MIDL_DEFINE_GUID(IID, IID_ISymbolicImageGraph,0x9ACF69A8,0xE19E,0x424A,0xAE,0xAB,0xA1,0x57,0x34,0x08,0xF0,0xAE);


MIDL_DEFINE_GUID(IID, IID_ISymbolicImageGroup,0x148EBD9B,0x8DB6,0x44DF,0x81,0x48,0x0F,0x71,0xF2,0xB0,0x78,0x90);


MIDL_DEFINE_GUID(IID, IID_IProjectiveBundleGraph,0x9A232764,0x6785,0x421F,0x81,0x1A,0xD4,0x7B,0x6F,0x3B,0xC9,0xBE);


MIDL_DEFINE_GUID(IID, IID_IProjectiveBundleGroup,0x979E3895,0x84BD,0x489D,0xA0,0xA9,0xC6,0xC7,0x3D,0x62,0x3C,0xE2);


MIDL_DEFINE_GUID(IID, LIBID_MorseKernelATL,0x13645F55,0xEF1A,0x4222,0xA2,0x09,0x70,0x9D,0xC3,0xA6,0xE7,0x82);


MIDL_DEFINE_GUID(CLSID, CLSID_CGraphInfo,0xA7C5C80A,0xDA2F,0x4900,0x80,0x42,0x9E,0xBA,0x1C,0x1B,0x0F,0x4B);


MIDL_DEFINE_GUID(CLSID, CLSID_CCompReg,0x58BF9B64,0xD15E,0x4C43,0x9B,0xA5,0xD5,0x79,0xCF,0x30,0x09,0x9C);


MIDL_DEFINE_GUID(CLSID, CLSID_CFunction,0x95B0D0F5,0xD7BD,0x48D8,0xB1,0x3A,0x5E,0x55,0x38,0xF3,0x34,0xE9);


MIDL_DEFINE_GUID(CLSID, CLSID_CKernel,0x4C18DA89,0xC2C3,0x480B,0x80,0x99,0x14,0x99,0x18,0xE4,0xAE,0x43);


MIDL_DEFINE_GUID(CLSID, CLSID_CComputationGraphResult,0x83FCA237,0x5E87,0x49D4,0x81,0xEE,0x95,0xBC,0x81,0x24,0x22,0xFE);


MIDL_DEFINE_GUID(CLSID, CLSID_CMorseSpectrum,0xBF5438F7,0xB6B4,0x457C,0x84,0x3E,0xC4,0x65,0x39,0xC7,0xA2,0xF7);


MIDL_DEFINE_GUID(CLSID, CLSID_CSymbolicImageGraph,0xA3AE65EC,0x004B,0x4CA9,0x93,0x7B,0x12,0x56,0x54,0x00,0x66,0x2C);


MIDL_DEFINE_GUID(CLSID, CLSID_CSymbolicImageGroup,0x00414483,0x2F27,0x43B5,0xB7,0xA6,0x68,0xA9,0xE9,0x67,0x4C,0xC9);


MIDL_DEFINE_GUID(CLSID, CLSID_CProjectiveBundleGraph,0x0FF20A2F,0x2518,0x4146,0x83,0x8A,0xEB,0x5C,0x0B,0x42,0xDD,0x7B);


MIDL_DEFINE_GUID(CLSID, CLSID_CProjectiveBundleGroup,0x520018A2,0x475A,0x4FB5,0xA7,0x80,0xE1,0x29,0x10,0x49,0xBA,0xB5);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



#endif /* !defined(_M_IA64) && !defined(_M_AMD64)*/

