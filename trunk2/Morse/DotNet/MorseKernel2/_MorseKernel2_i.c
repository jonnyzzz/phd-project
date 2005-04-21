

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Thu Apr 21 22:48:58 2005
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


MIDL_DEFINE_GUID(IID, IID_IParameters,0x16C62C7B,0x6775,0x4D2B,0x9B,0xD2,0x43,0x62,0x4E,0x01,0x73,0x8B);


MIDL_DEFINE_GUID(IID, IID_IProgressBarInfo,0x54E003E2,0xEAA0,0x4321,0x9A,0x14,0x31,0xCF,0x8E,0x5B,0xCB,0x84);


MIDL_DEFINE_GUID(IID, IID_IResultBase,0x92F4EEEF,0x602A,0x496D,0x80,0x67,0x51,0x84,0xF4,0xF1,0xD3,0x7B);


MIDL_DEFINE_GUID(IID, IID_IResultSet,0x5498E339,0x8014,0x4366,0x90,0x92,0x13,0xEB,0x8A,0xD3,0x5E,0x1D);


MIDL_DEFINE_GUID(IID, IID_IAction,0xB94E10D8,0x08BD,0x405C,0xA4,0x35,0x08,0x68,0xDD,0x86,0xCD,0x3C);


MIDL_DEFINE_GUID(IID, IID_IFunction,0x63B946E2,0x2AEE,0x4034,0xBA,0x1C,0x1B,0x4C,0xFD,0x68,0xCE,0xC0);


MIDL_DEFINE_GUID(IID, IID_IComputationParameters,0xAB57FCFD,0x2759,0x4E43,0x80,0x95,0x34,0xFD,0x20,0xEA,0xAA,0x8B);


MIDL_DEFINE_GUID(IID, IID_IBoxMethodAction,0x586FAD2F,0xD9E4,0x4A30,0xA9,0x25,0x34,0x5C,0x7E,0x1B,0xDC,0x56);


MIDL_DEFINE_GUID(IID, IID_IBoxMethodParameters,0xEF3F28E7,0xDA5A,0x4294,0x9C,0x12,0x65,0x6D,0x0B,0x7C,0xB7,0x4A);


MIDL_DEFINE_GUID(IID, IID_IResultMetadata,0xA8E4F6FF,0x93DA,0x489A,0xA6,0xC3,0x22,0xA5,0x88,0x49,0x32,0xC9);


MIDL_DEFINE_GUID(IID, IID_IResult,0x9B7D45A5,0x77FD,0x4E97,0x8C,0x4A,0x76,0xD3,0x61,0x0C,0xC8,0x75);


MIDL_DEFINE_GUID(IID, IID_IGraphInfo,0x0641C669,0xB362,0x48C9,0x8B,0x73,0xD0,0x2B,0x6E,0x25,0x2A,0x9D);


MIDL_DEFINE_GUID(IID, IID_IGraphResult,0x6E606370,0x04E2,0x4BCB,0x85,0x2C,0x31,0x3A,0x7D,0x4B,0xAD,0x15);


MIDL_DEFINE_GUID(IID, IID_IWritableGraphResult,0x6ED8D0EA,0x3E9C,0x441A,0x96,0xC6,0xEE,0xB2,0xAF,0xCB,0xE2,0x7D);


MIDL_DEFINE_GUID(IID, IID_IWritableResultSet,0xA56A15AC,0xEAC4,0x4D8B,0x92,0xFC,0x84,0xCF,0x84,0xFC,0x4F,0x16);


MIDL_DEFINE_GUID(IID, IID_IGraphResultImpl,0x150237B9,0x7739,0x4882,0x87,0xE1,0x8F,0xE9,0x26,0xA9,0x6A,0xFF);


MIDL_DEFINE_GUID(IID, IID_ISymbolicImageMetadata,0x24EEB65B,0x81FF,0x42EA,0x85,0x21,0x6B,0x3F,0x62,0x66,0x5F,0x84);


MIDL_DEFINE_GUID(IID, IID_IComponentRegistrar,0xa817e7a2,0x43fa,0x11d0,0x9e,0x44,0x00,0xaa,0x00,0xb6,0x77,0x0a);


MIDL_DEFINE_GUID(IID, IID_ITarjanAction,0xFAFD82A9,0x346E,0x4BD7,0x83,0x16,0xF1,0x6B,0x10,0x5A,0x46,0x53);


MIDL_DEFINE_GUID(IID, IID_ITarjanParameters,0x8DB63B4A,0x7E18,0x4328,0x93,0x35,0x41,0x9C,0x4C,0xE5,0xA4,0xE5);


MIDL_DEFINE_GUID(IID, IID_IPointMethodAction,0x1B1FF1EE,0x4EB6,0x4F0A,0xB6,0xAB,0xCC,0xBF,0xFA,0x28,0xB9,0xF0);


MIDL_DEFINE_GUID(IID, IID_IPointMethodParameters,0xADCEDDBC,0x441A,0x479D,0x8E,0x7A,0x70,0x69,0x21,0xDA,0x82,0xAC);


MIDL_DEFINE_GUID(IID, IID_IDummy,0x0A8C775B,0x8E19,0x4642,0xB2,0xD7,0x5B,0xBB,0x43,0x7B,0x7B,0x97);


MIDL_DEFINE_GUID(IID, IID_IIsolatedSetAction,0x787DC58F,0xCD39,0x4BE2,0x9B,0x58,0xD5,0xB9,0x9A,0xDC,0xFC,0x4D);


MIDL_DEFINE_GUID(IID, IID_IIsolatedSetParameters,0x01C806AD,0x6003,0x4F5B,0x84,0x05,0xAE,0x3D,0xD6,0x37,0xD8,0x54);


MIDL_DEFINE_GUID(IID, IID_IMinimalLoopLocalizationAction,0x9FFB9554,0x2D64,0x45EE,0x9F,0x79,0xB3,0x10,0x98,0xFF,0x85,0x12);


MIDL_DEFINE_GUID(IID, IID_IMinimalLoopLocalizationParameters,0xB90D3C01,0xF6F8,0x4D06,0x8E,0x01,0xC1,0x2C,0x6D,0x51,0xF7,0x0A);


MIDL_DEFINE_GUID(IID, IID_ISIRomActionParameters,0x9CF385EA,0x26DB,0x4A19,0xAB,0x20,0x5E,0x73,0x56,0x54,0xD4,0x69);


MIDL_DEFINE_GUID(IID, IID_ISIRomAction,0x44DAD8BF,0x971F,0x485D,0x86,0xC5,0x45,0xFD,0x1F,0x67,0xAC,0xFE);


MIDL_DEFINE_GUID(IID, IID_ISpectrumMetadata,0x139E4822,0x4DF9,0x44B1,0x88,0x25,0xFA,0xD0,0x74,0x49,0x25,0x05);


MIDL_DEFINE_GUID(IID, IID_ISpectrumResult,0x2003DF4C,0x5367,0x4F11,0xA2,0x9C,0x44,0x7E,0x7E,0x45,0xE5,0xAA);


MIDL_DEFINE_GUID(IID, IID_IDummy1,0x5896F6EB,0xCFBF,0x406C,0xA0,0xFD,0xEA,0x25,0x36,0x76,0x73,0xD0);


MIDL_DEFINE_GUID(IID, IID_IDummy2,0x880BF42F,0xA1E3,0x4FA8,0x87,0xAD,0xFB,0x8D,0x96,0xF2,0x75,0xA0);


MIDL_DEFINE_GUID(IID, IID_IWritableFunction,0x9B3DA2D8,0xE279,0x4552,0x99,0xF4,0x13,0xAA,0x06,0x66,0x42,0xD5);


MIDL_DEFINE_GUID(IID, IID_IFunctionImpl,0x38C4B884,0x7772,0x4AA3,0xB1,0xC0,0x4B,0xC1,0x12,0xFE,0x48,0x5F);


MIDL_DEFINE_GUID(IID, IID_IWritableGraphInfo,0x5F89F9F3,0xAB8D,0x4129,0xA7,0x52,0x8A,0x42,0x58,0xA8,0xEC,0xE9);


MIDL_DEFINE_GUID(IID, IID_IGraphInfoImpl,0xE8AC201A,0x48EE,0x4CC4,0xA7,0xD3,0xD0,0x75,0xC3,0x01,0x61,0x04);


MIDL_DEFINE_GUID(IID, IID_IResultSetImpl,0x3EB38E81,0xF41E,0x44BD,0x85,0xE3,0x48,0x6C,0xF0,0x5F,0xD1,0xB2);


MIDL_DEFINE_GUID(IID, IID_IKernell,0xF2D78B39,0xD782,0x49DE,0x91,0xB7,0x77,0x1C,0xDA,0x2E,0xD0,0xE0);


MIDL_DEFINE_GUID(IID, IID_IWritableKernell,0xDB255DC6,0x645A,0x4D60,0xA7,0xC6,0x5D,0x30,0x19,0xC2,0xDB,0xB7);


MIDL_DEFINE_GUID(IID, IID_IKernellImpl,0x0667C597,0x8C23,0x4B74,0xA2,0x98,0x82,0x1D,0xB5,0x94,0xED,0x01);


MIDL_DEFINE_GUID(IID, IID_IWritableSpectrumResult,0x80B6D423,0x1E6D,0x4236,0xB1,0x87,0xFF,0xDE,0xC3,0xA2,0xA1,0x39);


MIDL_DEFINE_GUID(IID, LIBID_MorseKernel2,0x922445B5,0xC296,0x49D0,0xB6,0x9D,0x45,0xFF,0x70,0xF8,0xCE,0x56);


MIDL_DEFINE_GUID(CLSID, CLSID_CBoxMethodAction,0xFDA0C930,0xC1F5,0x40C0,0xA0,0xB6,0xA9,0x78,0xCD,0xA9,0x3F,0x50);


MIDL_DEFINE_GUID(CLSID, CLSID_CGraphResultImpl,0x43037E6F,0x9884,0x4D5C,0xBB,0x41,0x44,0xD5,0x82,0x88,0x8F,0x9E);


MIDL_DEFINE_GUID(CLSID, CLSID_CSymbolicImageMetadata,0xA5D5EA06,0x663E,0x4755,0xA3,0xE7,0xA5,0x36,0xE8,0x3B,0x5A,0xC2);


MIDL_DEFINE_GUID(CLSID, CLSID_CCompReg,0x84035475,0x16DE,0x4504,0xAB,0xF2,0x5C,0x73,0x4E,0x46,0xA9,0x6A);


MIDL_DEFINE_GUID(CLSID, CLSID_CTarjanAction,0x76C75A0A,0xAC4C,0x4CA9,0x8A,0x4E,0xD8,0x28,0x33,0x88,0xC3,0x61);


MIDL_DEFINE_GUID(CLSID, CLSID_CPointMethodAction,0xA1A0ABCD,0x1591,0x4846,0x88,0xA0,0x10,0xAF,0x62,0x56,0x0C,0x37);


MIDL_DEFINE_GUID(CLSID, CLSID_CDummy,0x8C3F6AAB,0xF725,0x4C70,0xA9,0x2A,0x7E,0x4B,0xD2,0xA3,0x0C,0x23);


MIDL_DEFINE_GUID(CLSID, CLSID_CIsolatedSetAction,0x5345FB53,0x5138,0x4D28,0xA6,0xFC,0x29,0x4D,0xF9,0xD0,0xA1,0xE9);


MIDL_DEFINE_GUID(CLSID, CLSID_CMinimalLoopLocalizationAction,0x7D81B505,0xC5D6,0x4AEF,0x83,0xEF,0xCF,0xAF,0x07,0x76,0x78,0x98);


MIDL_DEFINE_GUID(CLSID, CLSID_CSIRomAction,0x8C4D17D1,0x3A75,0x4E95,0x8D,0x6F,0xCF,0x58,0x74,0x3A,0x12,0xBD);


MIDL_DEFINE_GUID(CLSID, CLSID_CSpectrumMetadata,0x3855504A,0xAE6E,0x4601,0xB6,0xE5,0x02,0x6F,0x7E,0x07,0x3D,0x9B);


MIDL_DEFINE_GUID(CLSID, CLSID_CDummy1,0x62172280,0xD7A2,0x46C1,0xAF,0x3D,0xE8,0x76,0x20,0x35,0x04,0x8E);


MIDL_DEFINE_GUID(CLSID, CLSID_CDummy2,0xF47CA110,0x2F50,0x43F2,0xBB,0x91,0x45,0x5C,0x9F,0xCE,0x6B,0x96);


MIDL_DEFINE_GUID(CLSID, CLSID_CFunctionImpl,0xFDFB8D0E,0x74FF,0x439C,0xA1,0x3B,0x4A,0x39,0x38,0x7B,0x70,0x37);


MIDL_DEFINE_GUID(CLSID, CLSID_CGraphInfoImpl,0x1FCB1E52,0xC321,0x4E44,0x8B,0xA6,0x83,0xDA,0x8C,0x53,0x23,0x65);


MIDL_DEFINE_GUID(CLSID, CLSID_CResultSetImpl,0x5FAAF083,0x60CC,0x4A9B,0xAA,0xC0,0x4F,0xDB,0x29,0x04,0x7B,0x08);


MIDL_DEFINE_GUID(CLSID, CLSID_CKernellImpl,0x96E908D0,0x29BD,0x423D,0x8C,0xA8,0x9F,0x43,0x43,0xC7,0x96,0xA0);


MIDL_DEFINE_GUID(CLSID, CLSID_CSpectrumResultImpl,0x45FBC041,0xD2C1,0x495D,0x8C,0xC9,0x58,0x01,0x96,0x91,0xE9,0xCC);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



#endif /* !defined(_M_IA64) && !defined(_M_AMD64)*/

