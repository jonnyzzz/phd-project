

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Fri Dec 02 01:15:12 2005
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
#if _MSC_VER >= 1200
#pragma warning(push)
#endif
#pragma warning( disable: 4100 ) /* unreferenced arguments in x86 call */
#pragma warning( disable: 4211 )  /* redefine extent to static */
#pragma warning( disable: 4232 )  /* dllimport identity*/
#define USE_STUBLESS_PROXY


/* verify that the <rpcproxy.h> version is high enough to compile this file*/
#ifndef __REDQ_RPCPROXY_H_VERSION__
#define __REQUIRED_RPCPROXY_H_VERSION__ 475
#endif


#include "rpcproxy.h"
#ifndef __RPCPROXY_H_VERSION__
#error this stub requires an updated version of <rpcproxy.h>
#endif // __RPCPROXY_H_VERSION__


#include "_MorseKernel2.h"

#define TYPE_FORMAT_STRING_SIZE   1321                              
#define PROC_FORMAT_STRING_SIZE   2479                              
#define TRANSMIT_AS_TABLE_SIZE    0            
#define WIRE_MARSHAL_TABLE_SIZE   2            

typedef struct _MIDL_TYPE_FORMAT_STRING
    {
    short          Pad;
    unsigned char  Format[ TYPE_FORMAT_STRING_SIZE ];
    } MIDL_TYPE_FORMAT_STRING;

typedef struct _MIDL_PROC_FORMAT_STRING
    {
    short          Pad;
    unsigned char  Format[ PROC_FORMAT_STRING_SIZE ];
    } MIDL_PROC_FORMAT_STRING;


static RPC_SYNTAX_IDENTIFIER  _RpcTransferSyntax = 
{{0x8A885D04,0x1CEB,0x11C9,{0x9F,0xE8,0x08,0x00,0x2B,0x10,0x48,0x60}},{2,0}};


extern const MIDL_TYPE_FORMAT_STRING __MIDL_TypeFormatString;
extern const MIDL_PROC_FORMAT_STRING __MIDL_ProcFormatString;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IActionBase_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IActionBase_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IProgressBarInfo_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IProgressBarInfo_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResultBase_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResultBase_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResultSet_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResultSet_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IFunction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IFunction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComputationParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComputationParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IAdaptiveBoxMethod_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IAdaptiveBoxMethod_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IAdaptiveBoxParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IAdaptiveBoxParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResultMetadata_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResultMetadata_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResultInfo_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResultInfo_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraphInfo_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphInfo_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraphResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableGraphResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableGraphResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableResultSet_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableResultSet_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraphResultImpl_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphResultImpl_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISymbolicImageMetadata_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISymbolicImageMetadata_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResultSetImpl_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResultSetImpl_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IAdaptiveMethodAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IAdaptiveMethodAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IAdaptiveMethodParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IAdaptiveMethodParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IBoxMethodAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IBoxMethodAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IBoxMethodParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IBoxMethodParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComponentRegistrar_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComponentRegistrar_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ITarjanAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ITarjanAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ITarjanParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ITarjanParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IPointMethodAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IPointMethodAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IPointMethodParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IPointMethodParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IProjectAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IProjectAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IProjectActionParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IProjectActionParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IDummy_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IDummy_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IIsolatedSetAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IIsolatedSetAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IIsolatedSetParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IIsolatedSetParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMinimalLoopLocalizationAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMinimalLoopLocalizationAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMinimalLoopLocalizationParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMinimalLoopLocalizationParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISIRomActionParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISIRomActionParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISIRomAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISIRomAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISpectrumMetadata_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISpectrumMetadata_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISpectrumResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISpectrumResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IDummy1_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IDummy1_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IDummy2_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IDummy2_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMS2DCreationAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMS2DCreationAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMS2DCreationParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMS2DCreationParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IDummy3_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IDummy3_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMS2DProcessAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMS2DProcessAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMS2DProcessParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMS2DProcessParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMSCreationProcess_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMSCreationProcess_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMSCreationParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMSCreationParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IDummy4_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IDummy4_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableFunction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableFunction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraphInfoImpl_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphInfoImpl_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernell_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernell_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableKernell_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableKernell_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernellImpl_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernellImpl_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ILoopsLocalizationAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ILoopsLocalizationAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMSMetadata_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMSMetadata_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMS2Metadata_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMS2Metadata_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMS2DRomAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMS2DRomAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableSpectrumResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableSpectrumResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMSSegmentMetadata_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMSSegmentMetadata_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMSMethodAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMSMethodAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMSSegmentRom_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMSSegmentRom_ProxyInfo;


extern const USER_MARSHAL_ROUTINE_QUADRUPLE UserMarshalRoutines[ WIRE_MARSHAL_TABLE_SIZE ];

#if !defined(__RPC_WIN32__)
#error  Invalid build platform for this stub.
#endif

#if !(TARGET_IS_NT50_OR_LATER)
#error You need a Windows 2000 or later to run this stub because it uses these features:
#error   /robust command line switch.
#error However, your C/C++ compilation flags indicate you intend to run this app on earlier systems.
#error This app will die there with the RPC_X_WRONG_STUB_VERSION error.
#endif


static const MIDL_PROC_FORMAT_STRING __MIDL_ProcFormatString =
    {
        0,
        {

	/* Procedure GetNodes */


	/* Procedure GetCount */


	/* Procedure Length */

			0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/*  2 */	NdrFcLong( 0x0 ),	/* 0 */
/*  6 */	NdrFcShort( 0x7 ),	/* 7 */
/*  8 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 10 */	NdrFcShort( 0x0 ),	/* 0 */
/* 12 */	NdrFcShort( 0x24 ),	/* 36 */
/* 14 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 16 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 18 */	NdrFcShort( 0x0 ),	/* 0 */
/* 20 */	NdrFcShort( 0x0 ),	/* 0 */
/* 22 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */


	/* Parameter count */


	/* Parameter length */

/* 24 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 26 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 28 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 30 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 32 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 34 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterAll */


	/* Procedure Next */

/* 36 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 38 */	NdrFcLong( 0x0 ),	/* 0 */
/* 42 */	NdrFcShort( 0x8 ),	/* 8 */
/* 44 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 46 */	NdrFcShort( 0x0 ),	/* 0 */
/* 48 */	NdrFcShort( 0x8 ),	/* 8 */
/* 50 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 52 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 54 */	NdrFcShort( 0x0 ),	/* 0 */
/* 56 */	NdrFcShort( 0x0 ),	/* 0 */
/* 58 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */


	/* Return value */

/* 60 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 62 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 64 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UseDerivate */


	/* Procedure NeedStop */

/* 66 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 68 */	NdrFcLong( 0x0 ),	/* 0 */
/* 72 */	NdrFcShort( 0x9 ),	/* 9 */
/* 74 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 76 */	NdrFcShort( 0x0 ),	/* 0 */
/* 78 */	NdrFcShort( 0x22 ),	/* 34 */
/* 80 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 82 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 84 */	NdrFcShort( 0x0 ),	/* 0 */
/* 86 */	NdrFcShort( 0x0 ),	/* 0 */
/* 88 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter out */


	/* Parameter stop */

/* 90 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 92 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 94 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 96 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 98 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 100 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Start */

/* 102 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 104 */	NdrFcLong( 0x0 ),	/* 0 */
/* 108 */	NdrFcShort( 0xa ),	/* 10 */
/* 110 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 112 */	NdrFcShort( 0x0 ),	/* 0 */
/* 114 */	NdrFcShort( 0x8 ),	/* 8 */
/* 116 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 118 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 120 */	NdrFcShort( 0x0 ),	/* 0 */
/* 122 */	NdrFcShort( 0x0 ),	/* 0 */
/* 124 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 126 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 128 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 130 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Finish */

/* 132 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 134 */	NdrFcLong( 0x0 ),	/* 0 */
/* 138 */	NdrFcShort( 0xb ),	/* 11 */
/* 140 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 142 */	NdrFcShort( 0x0 ),	/* 0 */
/* 144 */	NdrFcShort( 0x8 ),	/* 8 */
/* 146 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 148 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 150 */	NdrFcShort( 0x0 ),	/* 0 */
/* 152 */	NdrFcShort( 0x0 ),	/* 0 */
/* 154 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 156 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 158 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 160 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetResult */

/* 162 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 164 */	NdrFcLong( 0x0 ),	/* 0 */
/* 168 */	NdrFcShort( 0x8 ),	/* 8 */
/* 170 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 172 */	NdrFcShort( 0x8 ),	/* 8 */
/* 174 */	NdrFcShort( 0x8 ),	/* 8 */
/* 176 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 178 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 180 */	NdrFcShort( 0x0 ),	/* 0 */
/* 182 */	NdrFcShort( 0x0 ),	/* 0 */
/* 184 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 186 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 188 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 190 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter result */

/* 192 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 194 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 196 */	NdrFcShort( 0xa ),	/* Type Offset=10 */

	/* Return value */

/* 198 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 200 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 202 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetActionParameters */

/* 204 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 206 */	NdrFcLong( 0x0 ),	/* 0 */
/* 210 */	NdrFcShort( 0x7 ),	/* 7 */
/* 212 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 214 */	NdrFcShort( 0x0 ),	/* 0 */
/* 216 */	NdrFcShort( 0x8 ),	/* 8 */
/* 218 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 220 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 222 */	NdrFcShort( 0x0 ),	/* 0 */
/* 224 */	NdrFcShort( 0x0 ),	/* 0 */
/* 226 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter parameters */

/* 228 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 230 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 232 */	NdrFcShort( 0x20 ),	/* Type Offset=32 */

	/* Return value */

/* 234 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 236 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 238 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetProgressBarInfo */

/* 240 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 242 */	NdrFcLong( 0x0 ),	/* 0 */
/* 246 */	NdrFcShort( 0x8 ),	/* 8 */
/* 248 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 250 */	NdrFcShort( 0x0 ),	/* 0 */
/* 252 */	NdrFcShort( 0x8 ),	/* 8 */
/* 254 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 256 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 258 */	NdrFcShort( 0x0 ),	/* 0 */
/* 260 */	NdrFcShort( 0x0 ),	/* 0 */
/* 262 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pinfo */

/* 264 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 266 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 268 */	NdrFcShort( 0x32 ),	/* Type Offset=50 */

	/* Return value */

/* 270 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 272 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 274 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CanDo */

/* 276 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 278 */	NdrFcLong( 0x0 ),	/* 0 */
/* 282 */	NdrFcShort( 0x9 ),	/* 9 */
/* 284 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 286 */	NdrFcShort( 0x0 ),	/* 0 */
/* 288 */	NdrFcShort( 0x22 ),	/* 34 */
/* 290 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 292 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 294 */	NdrFcShort( 0x0 ),	/* 0 */
/* 296 */	NdrFcShort( 0x0 ),	/* 0 */
/* 298 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 300 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 302 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 304 */	NdrFcShort( 0x44 ),	/* Type Offset=68 */

	/* Parameter can */

/* 306 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 308 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 310 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 312 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 314 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 316 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Do */

/* 318 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 320 */	NdrFcLong( 0x0 ),	/* 0 */
/* 324 */	NdrFcShort( 0xa ),	/* 10 */
/* 326 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 328 */	NdrFcShort( 0x0 ),	/* 0 */
/* 330 */	NdrFcShort( 0x8 ),	/* 8 */
/* 332 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 334 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 336 */	NdrFcShort( 0x0 ),	/* 0 */
/* 338 */	NdrFcShort( 0x0 ),	/* 0 */
/* 340 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter input */

/* 342 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 344 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 346 */	NdrFcShort( 0x44 ),	/* Type Offset=68 */

	/* Parameter output */

/* 348 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 350 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 352 */	NdrFcShort( 0x56 ),	/* Type Offset=86 */

	/* Return value */

/* 354 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 356 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 358 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetEquations */

/* 360 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 362 */	NdrFcLong( 0x0 ),	/* 0 */
/* 366 */	NdrFcShort( 0xa ),	/* 10 */
/* 368 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 370 */	NdrFcShort( 0x0 ),	/* 0 */
/* 372 */	NdrFcShort( 0x8 ),	/* 8 */
/* 374 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 376 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 378 */	NdrFcShort( 0x1 ),	/* 1 */
/* 380 */	NdrFcShort( 0x0 ),	/* 0 */
/* 382 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter equations */

/* 384 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 386 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 388 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */

/* 390 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 392 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 394 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetUpperLength */


	/* Procedure GetDimension */

/* 396 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 398 */	NdrFcLong( 0x0 ),	/* 0 */
/* 402 */	NdrFcShort( 0xb ),	/* 11 */
/* 404 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 406 */	NdrFcShort( 0x0 ),	/* 0 */
/* 408 */	NdrFcShort( 0x24 ),	/* 36 */
/* 410 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 412 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 414 */	NdrFcShort( 0x0 ),	/* 0 */
/* 416 */	NdrFcShort( 0x0 ),	/* 0 */
/* 418 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */


	/* Parameter dimenstion */

/* 420 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 422 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 424 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 426 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 428 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 430 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetIterations */

/* 432 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 434 */	NdrFcLong( 0x0 ),	/* 0 */
/* 438 */	NdrFcShort( 0xc ),	/* 12 */
/* 440 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 442 */	NdrFcShort( 0x0 ),	/* 0 */
/* 444 */	NdrFcShort( 0x24 ),	/* 36 */
/* 446 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 448 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 450 */	NdrFcShort( 0x0 ),	/* 0 */
/* 452 */	NdrFcShort( 0x0 ),	/* 0 */
/* 454 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter iterations */

/* 456 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 458 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 460 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 462 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 464 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 466 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetIterations */

/* 468 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 470 */	NdrFcLong( 0x0 ),	/* 0 */
/* 474 */	NdrFcShort( 0xd ),	/* 13 */
/* 476 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 478 */	NdrFcShort( 0x8 ),	/* 8 */
/* 480 */	NdrFcShort( 0x8 ),	/* 8 */
/* 482 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 484 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 486 */	NdrFcShort( 0x0 ),	/* 0 */
/* 488 */	NdrFcShort( 0x0 ),	/* 0 */
/* 490 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter iterations */

/* 492 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 494 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 496 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 498 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 500 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 502 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMinimum */

/* 504 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 506 */	NdrFcLong( 0x0 ),	/* 0 */
/* 510 */	NdrFcShort( 0xe ),	/* 14 */
/* 512 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 514 */	NdrFcShort( 0x8 ),	/* 8 */
/* 516 */	NdrFcShort( 0x2c ),	/* 44 */
/* 518 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 520 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 522 */	NdrFcShort( 0x0 ),	/* 0 */
/* 524 */	NdrFcShort( 0x0 ),	/* 0 */
/* 526 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter id */

/* 528 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 530 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 532 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 534 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 536 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 538 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 540 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 542 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 544 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMaximum */

/* 546 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 548 */	NdrFcLong( 0x0 ),	/* 0 */
/* 552 */	NdrFcShort( 0xf ),	/* 15 */
/* 554 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 556 */	NdrFcShort( 0x8 ),	/* 8 */
/* 558 */	NdrFcShort( 0x2c ),	/* 44 */
/* 560 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 562 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 564 */	NdrFcShort( 0x0 ),	/* 0 */
/* 566 */	NdrFcShort( 0x0 ),	/* 0 */
/* 568 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter id */

/* 570 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 572 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 574 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 576 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 578 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 580 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 582 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 584 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 586 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetLipshitz */

/* 588 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 590 */	NdrFcLong( 0x0 ),	/* 0 */
/* 594 */	NdrFcShort( 0x10 ),	/* 16 */
/* 596 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 598 */	NdrFcShort( 0x8 ),	/* 8 */
/* 600 */	NdrFcShort( 0x2c ),	/* 44 */
/* 602 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 604 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 606 */	NdrFcShort( 0x0 ),	/* 0 */
/* 608 */	NdrFcShort( 0x0 ),	/* 0 */
/* 610 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter id */

/* 612 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 614 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 616 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 618 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 620 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 622 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 624 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 626 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 628 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetFunction */

/* 630 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 632 */	NdrFcLong( 0x0 ),	/* 0 */
/* 636 */	NdrFcShort( 0x7 ),	/* 7 */
/* 638 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 640 */	NdrFcShort( 0x0 ),	/* 0 */
/* 642 */	NdrFcShort( 0x8 ),	/* 8 */
/* 644 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 646 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 648 */	NdrFcShort( 0x0 ),	/* 0 */
/* 650 */	NdrFcShort( 0x0 ),	/* 0 */
/* 652 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter function */

/* 654 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 656 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 658 */	NdrFcShort( 0x86 ),	/* Type Offset=134 */

	/* Return value */

/* 660 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 662 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 664 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetDimensionForParameters */


	/* Procedure GetDimensionFromParameters */

/* 666 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 668 */	NdrFcLong( 0x0 ),	/* 0 */
/* 672 */	NdrFcShort( 0xb ),	/* 11 */
/* 674 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 676 */	NdrFcShort( 0x0 ),	/* 0 */
/* 678 */	NdrFcShort( 0x24 ),	/* 36 */
/* 680 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 682 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 684 */	NdrFcShort( 0x0 ),	/* 0 */
/* 686 */	NdrFcShort( 0x0 ),	/* 0 */
/* 688 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter resultSet */


	/* Parameter in */

/* 690 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 692 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 694 */	NdrFcShort( 0x44 ),	/* Type Offset=68 */

	/* Parameter dimension */


	/* Parameter demention */

/* 696 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 698 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 700 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 702 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 704 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 706 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetRecomendedPrecision */

/* 708 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 710 */	NdrFcLong( 0x0 ),	/* 0 */
/* 714 */	NdrFcShort( 0xc ),	/* 12 */
/* 716 */	NdrFcShort( 0x14 ),	/* x86 Stack size/offset = 20 */
/* 718 */	NdrFcShort( 0x8 ),	/* 8 */
/* 720 */	NdrFcShort( 0x2c ),	/* 44 */
/* 722 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 724 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 726 */	NdrFcShort( 0x0 ),	/* 0 */
/* 728 */	NdrFcShort( 0x0 ),	/* 0 */
/* 730 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter in */

/* 732 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 734 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 736 */	NdrFcShort( 0x44 ),	/* Type Offset=68 */

	/* Parameter id */

/* 738 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 740 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 742 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter prec */

/* 744 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 746 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 748 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 750 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 752 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 754 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetFactor */


	/* Procedure GetFactor */


	/* Procedure GetFactor */


	/* Procedure GetFactor */


	/* Procedure GetFactor */

/* 756 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 758 */	NdrFcLong( 0x0 ),	/* 0 */
/* 762 */	NdrFcShort( 0x8 ),	/* 8 */
/* 764 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 766 */	NdrFcShort( 0x8 ),	/* 8 */
/* 768 */	NdrFcShort( 0x24 ),	/* 36 */
/* 770 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 772 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 774 */	NdrFcShort( 0x0 ),	/* 0 */
/* 776 */	NdrFcShort( 0x0 ),	/* 0 */
/* 778 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */


	/* Parameter index */


	/* Parameter index */


	/* Parameter index */


	/* Parameter id */

/* 780 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 782 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 784 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter factor */


	/* Parameter factor */


	/* Parameter factor */


	/* Parameter factor */


	/* Parameter factor */

/* 786 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 788 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 790 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */


	/* Return value */


	/* Return value */

/* 792 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 794 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 796 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetPrecision */


	/* Procedure GetPrecision */

/* 798 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 800 */	NdrFcLong( 0x0 ),	/* 0 */
/* 804 */	NdrFcShort( 0x9 ),	/* 9 */
/* 806 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 808 */	NdrFcShort( 0x8 ),	/* 8 */
/* 810 */	NdrFcShort( 0x2c ),	/* 44 */
/* 812 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 814 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 816 */	NdrFcShort( 0x0 ),	/* 0 */
/* 818 */	NdrFcShort( 0x0 ),	/* 0 */
/* 820 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */


	/* Parameter id */

/* 822 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 824 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 826 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter prec */


	/* Parameter prec */

/* 828 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 830 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 832 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 834 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 836 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 838 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EqualType */

/* 840 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 842 */	NdrFcLong( 0x0 ),	/* 0 */
/* 846 */	NdrFcShort( 0x7 ),	/* 7 */
/* 848 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 850 */	NdrFcShort( 0x0 ),	/* 0 */
/* 852 */	NdrFcShort( 0x22 ),	/* 34 */
/* 854 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 856 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 858 */	NdrFcShort( 0x0 ),	/* 0 */
/* 860 */	NdrFcShort( 0x0 ),	/* 0 */
/* 862 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter metadata */

/* 864 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 866 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 868 */	NdrFcShort( 0x9c ),	/* Type Offset=156 */

	/* Parameter out */

/* 870 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 872 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 874 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 876 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 878 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 880 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Clone */

/* 882 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 884 */	NdrFcLong( 0x0 ),	/* 0 */
/* 888 */	NdrFcShort( 0x8 ),	/* 8 */
/* 890 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 892 */	NdrFcShort( 0x0 ),	/* 0 */
/* 894 */	NdrFcShort( 0x8 ),	/* 8 */
/* 896 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 898 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 900 */	NdrFcShort( 0x0 ),	/* 0 */
/* 902 */	NdrFcShort( 0x0 ),	/* 0 */
/* 904 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter metadata */

/* 906 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 908 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 910 */	NdrFcShort( 0xae ),	/* Type Offset=174 */

	/* Return value */

/* 912 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 914 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 916 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMetadata */

/* 918 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 920 */	NdrFcLong( 0x0 ),	/* 0 */
/* 924 */	NdrFcShort( 0x7 ),	/* 7 */
/* 926 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 928 */	NdrFcShort( 0x0 ),	/* 0 */
/* 930 */	NdrFcShort( 0x8 ),	/* 8 */
/* 932 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 934 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 936 */	NdrFcShort( 0x0 ),	/* 0 */
/* 938 */	NdrFcShort( 0x0 ),	/* 0 */
/* 940 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter out */

/* 942 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 944 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 946 */	NdrFcShort( 0xae ),	/* Type Offset=174 */

	/* Return value */

/* 948 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 950 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 952 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetEdges */

/* 954 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 956 */	NdrFcLong( 0x0 ),	/* 0 */
/* 960 */	NdrFcShort( 0x8 ),	/* 8 */
/* 962 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 964 */	NdrFcShort( 0x0 ),	/* 0 */
/* 966 */	NdrFcShort( 0x24 ),	/* 36 */
/* 968 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 970 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 972 */	NdrFcShort( 0x0 ),	/* 0 */
/* 974 */	NdrFcShort( 0x0 ),	/* 0 */
/* 976 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 978 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 980 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 982 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 984 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 986 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 988 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetDimension */

/* 990 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 992 */	NdrFcLong( 0x0 ),	/* 0 */
/* 996 */	NdrFcShort( 0x9 ),	/* 9 */
/* 998 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1000 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1002 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1004 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1006 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1008 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1010 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1012 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 1014 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1016 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1018 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1020 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1022 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1024 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMinimum */

/* 1026 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1028 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1032 */	NdrFcShort( 0xa ),	/* 10 */
/* 1034 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1036 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1038 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1040 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1042 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1044 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1046 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1048 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1050 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1052 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1054 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 1056 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1058 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1060 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1062 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1064 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1066 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMaximum */

/* 1068 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1070 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1074 */	NdrFcShort( 0xb ),	/* 11 */
/* 1076 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1078 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1080 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1082 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1084 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1086 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1088 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1090 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1092 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1094 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1096 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 1098 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1100 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1102 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1104 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1106 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1108 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGridNumber */

/* 1110 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1112 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1116 */	NdrFcShort( 0xc ),	/* 12 */
/* 1118 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1120 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1122 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1124 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1126 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1128 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1130 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1132 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1134 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1136 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1138 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 1140 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1142 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1144 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1146 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1148 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1150 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGridSize */

/* 1152 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1154 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1158 */	NdrFcShort( 0xd ),	/* 13 */
/* 1160 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1162 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1164 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1166 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1168 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1170 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1172 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1174 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1176 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1178 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1180 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 1182 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1184 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1186 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1188 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1190 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1192 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGraphInfo */

/* 1194 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1196 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1200 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1202 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1204 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1206 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1208 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1210 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1212 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1214 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1216 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter info */

/* 1218 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1220 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1222 */	NdrFcShort( 0xb2 ),	/* Type Offset=178 */

	/* Return value */

/* 1224 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1226 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1228 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UseOffsets */


	/* Procedure IsStrongComponent */

/* 1230 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1232 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1236 */	NdrFcShort( 0xa ),	/* 10 */
/* 1238 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1240 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1242 */	NdrFcShort( 0x22 ),	/* 34 */
/* 1244 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1246 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1248 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1250 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1252 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */


	/* Parameter value */

/* 1254 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1256 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1258 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 1260 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1262 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1264 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterComponent */


	/* Procedure SaveText */

/* 1266 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1268 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1272 */	NdrFcShort( 0xb ),	/* 11 */
/* 1274 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1276 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1278 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1280 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1282 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1284 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1286 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1288 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */


	/* Parameter file */

/* 1290 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1292 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1294 */	NdrFcShort( 0xcc ),	/* Type Offset=204 */

	/* Return value */


	/* Return value */

/* 1296 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1298 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1300 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterComponent */


	/* Procedure SaveGraph */

/* 1302 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1304 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1308 */	NdrFcShort( 0xc ),	/* 12 */
/* 1310 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1312 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1314 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1316 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1318 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1320 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1322 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1324 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */


	/* Parameter file */

/* 1326 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1328 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1330 */	NdrFcShort( 0xcc ),	/* Type Offset=204 */

	/* Return value */


	/* Return value */

/* 1332 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1334 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1336 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetMetadata */

/* 1338 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1340 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1344 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1346 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1348 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1350 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1352 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1354 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1356 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1358 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1360 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter metadata */

/* 1362 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1364 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1366 */	NdrFcShort( 0x9c ),	/* Type Offset=156 */

	/* Return value */

/* 1368 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1370 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1372 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetGraphFromFile */

/* 1374 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1376 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1380 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1382 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1384 */	NdrFcShort( 0x6 ),	/* 6 */
/* 1386 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1388 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1390 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1392 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1394 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1396 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter file */

/* 1398 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1400 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1402 */	NdrFcShort( 0xcc ),	/* Type Offset=204 */

	/* Parameter isStrongComponent */

/* 1404 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1406 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1408 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 1410 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1412 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1414 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AddResult */

/* 1416 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1418 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1422 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1424 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1426 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1428 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1430 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1432 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1434 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1436 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1438 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 1440 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1442 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1444 */	NdrFcShort( 0xe ),	/* Type Offset=14 */

	/* Return value */

/* 1446 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1448 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1450 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetRecomendedPrecision */

/* 1452 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1454 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1458 */	NdrFcShort( 0xb ),	/* 11 */
/* 1460 */	NdrFcShort( 0x14 ),	/* x86 Stack size/offset = 20 */
/* 1462 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1464 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1466 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 1468 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1470 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1472 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1474 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter in */

/* 1476 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1478 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1480 */	NdrFcShort( 0x44 ),	/* Type Offset=68 */

	/* Parameter index */

/* 1482 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1484 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1486 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter prec */

/* 1488 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1490 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1492 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1494 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1496 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1498 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetDimension */

/* 1500 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1502 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1506 */	NdrFcShort( 0xc ),	/* 12 */
/* 1508 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1510 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1512 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1514 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1516 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1518 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1520 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1522 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter in */

/* 1524 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1526 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1528 */	NdrFcShort( 0x44 ),	/* Type Offset=68 */

	/* Parameter dim */

/* 1530 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1532 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1534 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1536 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1538 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1540 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetLowerLength */


	/* Procedure GetUpperLimit */

/* 1542 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1544 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1548 */	NdrFcShort( 0xa ),	/* 10 */
/* 1550 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1552 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1554 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1556 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1558 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1560 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1562 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1564 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */


	/* Parameter out */

/* 1566 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1568 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1570 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 1572 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1574 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1576 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetEquations */


	/* Procedure Attach */

/* 1578 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1580 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1584 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1586 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1588 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1590 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1592 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1594 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1596 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1598 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1600 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter equations */


	/* Parameter bstrPath */

/* 1602 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1604 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1606 */	NdrFcShort( 0xcc ),	/* Type Offset=204 */

	/* Return value */


	/* Return value */

/* 1608 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1610 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1612 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterAll */

/* 1614 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1616 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1620 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1622 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1624 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1626 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1628 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 1630 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1632 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1634 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1636 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 1638 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1640 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1642 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetComponents */

/* 1644 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1646 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1650 */	NdrFcShort( 0xa ),	/* 10 */
/* 1652 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1654 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1656 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1658 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 1660 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 1662 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1664 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1666 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pbstrCLSIDs */

/* 1668 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1670 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1672 */	NdrFcShort( 0x4ca ),	/* Type Offset=1226 */

	/* Parameter pbstrDescriptions */

/* 1674 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1676 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1678 */	NdrFcShort( 0x4ca ),	/* Type Offset=1226 */

	/* Return value */

/* 1680 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1682 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1684 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure NeedEdgeResolve */

/* 1686 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1688 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1692 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1694 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1696 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1698 */	NdrFcShort( 0x22 ),	/* 34 */
/* 1700 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1702 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1704 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1706 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1708 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 1710 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1712 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1714 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 1716 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1718 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1720 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetDimension */


	/* Procedure GetDimension */


	/* Procedure GetDimention */


	/* Procedure GetDimensionForParameters */

/* 1722 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1724 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1728 */	NdrFcShort( 0xb ),	/* 11 */
/* 1730 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1732 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1734 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1736 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1738 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1740 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1742 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1744 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter set */


	/* Parameter resultSet */


	/* Parameter set */


	/* Parameter resultSet */

/* 1746 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1748 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1750 */	NdrFcShort( 0x4d4 ),	/* Type Offset=1236 */

	/* Parameter dim */


	/* Parameter dimension */


	/* Parameter dim */


	/* Parameter dimension */

/* 1752 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1754 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1756 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */


	/* Return value */

/* 1758 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1760 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1762 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetPoints */

/* 1764 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1766 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1770 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1772 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1774 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1776 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1778 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1780 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1782 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1784 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1786 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1788 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1790 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1792 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter ks */

/* 1794 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1796 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1798 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1800 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1802 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1804 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetOffset */

/* 1806 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1808 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1812 */	NdrFcShort( 0xb ),	/* 11 */
/* 1814 */	NdrFcShort( 0x14 ),	/* x86 Stack size/offset = 20 */
/* 1816 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1818 */	NdrFcShort( 0x50 ),	/* 80 */
/* 1820 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x4,		/* 4 */
/* 1822 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1824 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1826 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1828 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1830 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1832 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1834 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter offset1 */

/* 1836 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1838 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1840 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Parameter offset2 */

/* 1842 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1844 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1846 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1848 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1850 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1852 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetFactor */


	/* Procedure GetFactor */


	/* Procedure GetDevisor */

/* 1854 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1856 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1860 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1862 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1864 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1866 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1868 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1870 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1872 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1874 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1876 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */


	/* Parameter index */


	/* Parameter index */

/* 1878 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1880 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1882 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter factor */


	/* Parameter factor */


	/* Parameter value */

/* 1884 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1886 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1888 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 1890 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1892 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1894 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetStartSet */

/* 1896 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1898 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1902 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1904 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1906 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1908 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1910 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1912 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1914 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1916 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1918 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 1920 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1922 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1924 */	NdrFcShort( 0x4e6 ),	/* Type Offset=1254 */

	/* Return value */

/* 1926 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1928 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1930 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetCoordinate */

/* 1932 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1934 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1938 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1940 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1942 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1944 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1946 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1948 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1950 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1952 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1954 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter id */

/* 1956 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1958 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1960 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter data */

/* 1962 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1964 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1966 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1968 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1970 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1972 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetLowerBound */

/* 1974 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1976 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1980 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1982 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1984 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1986 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1988 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1990 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1992 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1994 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1996 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */

/* 1998 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 2000 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2002 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 2004 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2006 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2008 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetUpperBound */

/* 2010 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2012 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2016 */	NdrFcShort( 0x9 ),	/* 9 */
/* 2018 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2020 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2022 */	NdrFcShort( 0x2c ),	/* 44 */
/* 2024 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 2026 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2028 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2030 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2032 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */

/* 2034 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 2036 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2038 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 2040 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2042 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2044 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetLastError */

/* 2046 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2048 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2052 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2054 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2056 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2058 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2060 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 2062 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 2064 */	NdrFcShort( 0x1 ),	/* 1 */
/* 2066 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2068 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter message */

/* 2070 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 2072 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2074 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */

/* 2076 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2078 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2080 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetFunction */

/* 2082 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2084 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2088 */	NdrFcShort( 0x7 ),	/* 7 */
/* 2090 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2092 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2094 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2096 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 2098 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2100 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2102 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2104 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter function */

/* 2106 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 2108 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2110 */	NdrFcShort( 0x4fc ),	/* Type Offset=1276 */

	/* Return value */

/* 2112 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2114 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2116 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateInitialResultSet */

/* 2118 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2120 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2124 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2126 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2128 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2130 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2132 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 2134 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2136 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2138 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2140 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 2142 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 2144 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2146 */	NdrFcShort( 0x512 ),	/* Type Offset=1298 */

	/* Return value */

/* 2148 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2150 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2152 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetFunction */

/* 2154 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2156 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2160 */	NdrFcShort( 0x7 ),	/* 7 */
/* 2162 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2164 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2166 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2168 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 2170 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2172 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2174 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2176 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter function */

/* 2178 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2180 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2182 */	NdrFcShort( 0x500 ),	/* Type Offset=1280 */

	/* Return value */

/* 2184 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2186 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2188 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetSIGraphResult */

/* 2190 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2192 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2196 */	NdrFcShort( 0x9 ),	/* 9 */
/* 2198 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2200 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2202 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2204 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 2206 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2208 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2210 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2212 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter out */

/* 2214 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 2216 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2218 */	NdrFcShort( 0x512 ),	/* Type Offset=1298 */

	/* Return value */

/* 2220 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2222 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2224 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetSIGraphResult */

/* 2226 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2228 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2232 */	NdrFcShort( 0xa ),	/* 10 */
/* 2234 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2236 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2238 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2240 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 2242 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2244 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2246 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2248 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter in */

/* 2250 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2252 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2254 */	NdrFcShort( 0x4d4 ),	/* Type Offset=1236 */

	/* Return value */

/* 2256 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2258 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2260 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure HasSIGraphResult */

/* 2262 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2264 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2268 */	NdrFcShort( 0xb ),	/* 11 */
/* 2270 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2272 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2274 */	NdrFcShort( 0x22 ),	/* 34 */
/* 2276 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 2278 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2280 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2282 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2284 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter out */

/* 2286 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 2288 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2290 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 2292 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2294 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2296 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetLowerBound */

/* 2298 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2300 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2304 */	NdrFcShort( 0x7 ),	/* 7 */
/* 2306 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 2308 */	NdrFcShort( 0x10 ),	/* 16 */
/* 2310 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2312 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 2314 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2316 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2318 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2320 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */

/* 2322 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 2324 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2326 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 2328 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2330 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2332 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetUpperBound */

/* 2334 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2336 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2340 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2342 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 2344 */	NdrFcShort( 0x10 ),	/* 16 */
/* 2346 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2348 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 2350 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2352 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2354 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2356 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */

/* 2358 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 2360 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2362 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 2364 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2366 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2368 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetLowerLength */

/* 2370 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2372 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2376 */	NdrFcShort( 0x9 ),	/* 9 */
/* 2378 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2380 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2382 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2384 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 2386 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2388 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2390 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2392 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */

/* 2394 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 2396 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2398 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 2400 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2402 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2404 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetUpperLength */

/* 2406 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2408 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2412 */	NdrFcShort( 0xa ),	/* 10 */
/* 2414 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2416 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2418 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2420 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 2422 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2424 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2426 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2428 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */

/* 2430 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 2432 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2434 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 2436 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2438 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2440 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetMetadata */

/* 2442 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2444 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2448 */	NdrFcShort( 0xb ),	/* 11 */
/* 2450 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2452 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2454 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2456 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 2458 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2460 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2462 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2464 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */

/* 2466 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2468 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2470 */	NdrFcShort( 0x516 ),	/* Type Offset=1302 */

	/* Return value */

/* 2472 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2474 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2476 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

			0x0
        }
    };

static const MIDL_TYPE_FORMAT_STRING __MIDL_TypeFormatString =
    {
        0,
        {
			NdrFcShort( 0x0 ),	/* 0 */
/*  2 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/*  4 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/*  6 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/*  8 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 10 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 12 */	NdrFcShort( 0x2 ),	/* Offset= 2 (14) */
/* 14 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 16 */	NdrFcLong( 0x92f4eeef ),	/* -1829441809 */
/* 20 */	NdrFcShort( 0x602a ),	/* 24618 */
/* 22 */	NdrFcShort( 0x496d ),	/* 18797 */
/* 24 */	0x80,		/* 128 */
			0x67,		/* 103 */
/* 26 */	0x51,		/* 81 */
			0x84,		/* 132 */
/* 28 */	0xf4,		/* 244 */
			0xf1,		/* 241 */
/* 30 */	0xd3,		/* 211 */
			0x7b,		/* 123 */
/* 32 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 34 */	NdrFcLong( 0x16c62c7b ),	/* 382086267 */
/* 38 */	NdrFcShort( 0x6775 ),	/* 26485 */
/* 40 */	NdrFcShort( 0x4d2b ),	/* 19755 */
/* 42 */	0x9b,		/* 155 */
			0xd2,		/* 210 */
/* 44 */	0x43,		/* 67 */
			0x62,		/* 98 */
/* 46 */	0x4e,		/* 78 */
			0x1,		/* 1 */
/* 48 */	0x73,		/* 115 */
			0x8b,		/* 139 */
/* 50 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 52 */	NdrFcLong( 0x54e003e2 ),	/* 1423967202 */
/* 56 */	NdrFcShort( 0xeaa0 ),	/* -5472 */
/* 58 */	NdrFcShort( 0x4321 ),	/* 17185 */
/* 60 */	0x9a,		/* 154 */
			0x14,		/* 20 */
/* 62 */	0x31,		/* 49 */
			0xcf,		/* 207 */
/* 64 */	0x8e,		/* 142 */
			0x5b,		/* 91 */
/* 66 */	0xcb,		/* 203 */
			0x84,		/* 132 */
/* 68 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 70 */	NdrFcLong( 0x5498e339 ),	/* 1419305785 */
/* 74 */	NdrFcShort( 0x8014 ),	/* -32748 */
/* 76 */	NdrFcShort( 0x4366 ),	/* 17254 */
/* 78 */	0x90,		/* 144 */
			0x92,		/* 146 */
/* 80 */	0x13,		/* 19 */
			0xeb,		/* 235 */
/* 82 */	0x8a,		/* 138 */
			0xd3,		/* 211 */
/* 84 */	0x5e,		/* 94 */
			0x1d,		/* 29 */
/* 86 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 88 */	NdrFcShort( 0xffec ),	/* Offset= -20 (68) */
/* 90 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 92 */	NdrFcShort( 0x1c ),	/* Offset= 28 (120) */
/* 94 */	
			0x13, 0x0,	/* FC_OP */
/* 96 */	NdrFcShort( 0xe ),	/* Offset= 14 (110) */
/* 98 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 100 */	NdrFcShort( 0x2 ),	/* 2 */
/* 102 */	0x9,		/* Corr desc: FC_ULONG */
			0x0,		/*  */
/* 104 */	NdrFcShort( 0xfffc ),	/* -4 */
/* 106 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 108 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 110 */	
			0x17,		/* FC_CSTRUCT */
			0x3,		/* 3 */
/* 112 */	NdrFcShort( 0x8 ),	/* 8 */
/* 114 */	NdrFcShort( 0xfff0 ),	/* Offset= -16 (98) */
/* 116 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 118 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 120 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 122 */	NdrFcShort( 0x0 ),	/* 0 */
/* 124 */	NdrFcShort( 0x4 ),	/* 4 */
/* 126 */	NdrFcShort( 0x0 ),	/* 0 */
/* 128 */	NdrFcShort( 0xffde ),	/* Offset= -34 (94) */
/* 130 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 132 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 134 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 136 */	NdrFcShort( 0x2 ),	/* Offset= 2 (138) */
/* 138 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 140 */	NdrFcLong( 0x63b946e2 ),	/* 1673086690 */
/* 144 */	NdrFcShort( 0x2aee ),	/* 10990 */
/* 146 */	NdrFcShort( 0x4034 ),	/* 16436 */
/* 148 */	0xba,		/* 186 */
			0x1c,		/* 28 */
/* 150 */	0x1b,		/* 27 */
			0x4c,		/* 76 */
/* 152 */	0xfd,		/* 253 */
			0x68,		/* 104 */
/* 154 */	0xce,		/* 206 */
			0xc0,		/* 192 */
/* 156 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 158 */	NdrFcLong( 0xa8e4f6ff ),	/* -1461389569 */
/* 162 */	NdrFcShort( 0x93da ),	/* -27686 */
/* 164 */	NdrFcShort( 0x489a ),	/* 18586 */
/* 166 */	0xa6,		/* 166 */
			0xc3,		/* 195 */
/* 168 */	0x22,		/* 34 */
			0xa5,		/* 165 */
/* 170 */	0x88,		/* 136 */
			0x49,		/* 73 */
/* 172 */	0x32,		/* 50 */
			0xc9,		/* 201 */
/* 174 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 176 */	NdrFcShort( 0xffec ),	/* Offset= -20 (156) */
/* 178 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 180 */	NdrFcShort( 0x2 ),	/* Offset= 2 (182) */
/* 182 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 184 */	NdrFcLong( 0x641c669 ),	/* 104973929 */
/* 188 */	NdrFcShort( 0xb362 ),	/* -19614 */
/* 190 */	NdrFcShort( 0x48c9 ),	/* 18633 */
/* 192 */	0x8b,		/* 139 */
			0x73,		/* 115 */
/* 194 */	0xd0,		/* 208 */
			0x2b,		/* 43 */
/* 196 */	0x6e,		/* 110 */
			0x25,		/* 37 */
/* 198 */	0x2a,		/* 42 */
			0x9d,		/* 157 */
/* 200 */	
			0x12, 0x0,	/* FC_UP */
/* 202 */	NdrFcShort( 0xffa4 ),	/* Offset= -92 (110) */
/* 204 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 206 */	NdrFcShort( 0x0 ),	/* 0 */
/* 208 */	NdrFcShort( 0x4 ),	/* 4 */
/* 210 */	NdrFcShort( 0x0 ),	/* 0 */
/* 212 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (200) */
/* 214 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 216 */	NdrFcShort( 0x3f2 ),	/* Offset= 1010 (1226) */
/* 218 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 220 */	NdrFcShort( 0x2 ),	/* Offset= 2 (222) */
/* 222 */	
			0x13, 0x0,	/* FC_OP */
/* 224 */	NdrFcShort( 0x3d8 ),	/* Offset= 984 (1208) */
/* 226 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x49,		/* 73 */
/* 228 */	NdrFcShort( 0x18 ),	/* 24 */
/* 230 */	NdrFcShort( 0xa ),	/* 10 */
/* 232 */	NdrFcLong( 0x8 ),	/* 8 */
/* 236 */	NdrFcShort( 0x5a ),	/* Offset= 90 (326) */
/* 238 */	NdrFcLong( 0xd ),	/* 13 */
/* 242 */	NdrFcShort( 0x90 ),	/* Offset= 144 (386) */
/* 244 */	NdrFcLong( 0x9 ),	/* 9 */
/* 248 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (442) */
/* 250 */	NdrFcLong( 0xc ),	/* 12 */
/* 254 */	NdrFcShort( 0x2bc ),	/* Offset= 700 (954) */
/* 256 */	NdrFcLong( 0x24 ),	/* 36 */
/* 260 */	NdrFcShort( 0x2e6 ),	/* Offset= 742 (1002) */
/* 262 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 266 */	NdrFcShort( 0x302 ),	/* Offset= 770 (1036) */
/* 268 */	NdrFcLong( 0x10 ),	/* 16 */
/* 272 */	NdrFcShort( 0x31c ),	/* Offset= 796 (1068) */
/* 274 */	NdrFcLong( 0x2 ),	/* 2 */
/* 278 */	NdrFcShort( 0x336 ),	/* Offset= 822 (1100) */
/* 280 */	NdrFcLong( 0x3 ),	/* 3 */
/* 284 */	NdrFcShort( 0x350 ),	/* Offset= 848 (1132) */
/* 286 */	NdrFcLong( 0x14 ),	/* 20 */
/* 290 */	NdrFcShort( 0x36a ),	/* Offset= 874 (1164) */
/* 292 */	NdrFcShort( 0xffff ),	/* Offset= -1 (291) */
/* 294 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 296 */	NdrFcShort( 0x4 ),	/* 4 */
/* 298 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 300 */	NdrFcShort( 0x0 ),	/* 0 */
/* 302 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 304 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 306 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 308 */	NdrFcShort( 0x4 ),	/* 4 */
/* 310 */	NdrFcShort( 0x0 ),	/* 0 */
/* 312 */	NdrFcShort( 0x1 ),	/* 1 */
/* 314 */	NdrFcShort( 0x0 ),	/* 0 */
/* 316 */	NdrFcShort( 0x0 ),	/* 0 */
/* 318 */	0x13, 0x0,	/* FC_OP */
/* 320 */	NdrFcShort( 0xff2e ),	/* Offset= -210 (110) */
/* 322 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 324 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 326 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 328 */	NdrFcShort( 0x8 ),	/* 8 */
/* 330 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 332 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 334 */	NdrFcShort( 0x4 ),	/* 4 */
/* 336 */	NdrFcShort( 0x4 ),	/* 4 */
/* 338 */	0x11, 0x0,	/* FC_RP */
/* 340 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (294) */
/* 342 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 344 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 346 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 348 */	NdrFcLong( 0x0 ),	/* 0 */
/* 352 */	NdrFcShort( 0x0 ),	/* 0 */
/* 354 */	NdrFcShort( 0x0 ),	/* 0 */
/* 356 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 358 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 360 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 362 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 364 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 366 */	NdrFcShort( 0x0 ),	/* 0 */
/* 368 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 370 */	NdrFcShort( 0x0 ),	/* 0 */
/* 372 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 374 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 378 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 380 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 382 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (346) */
/* 384 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 386 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 388 */	NdrFcShort( 0x8 ),	/* 8 */
/* 390 */	NdrFcShort( 0x0 ),	/* 0 */
/* 392 */	NdrFcShort( 0x6 ),	/* Offset= 6 (398) */
/* 394 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 396 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 398 */	
			0x11, 0x0,	/* FC_RP */
/* 400 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (364) */
/* 402 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 404 */	NdrFcLong( 0x20400 ),	/* 132096 */
/* 408 */	NdrFcShort( 0x0 ),	/* 0 */
/* 410 */	NdrFcShort( 0x0 ),	/* 0 */
/* 412 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 414 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 416 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 418 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 420 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 422 */	NdrFcShort( 0x0 ),	/* 0 */
/* 424 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 426 */	NdrFcShort( 0x0 ),	/* 0 */
/* 428 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 430 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 434 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 436 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 438 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (402) */
/* 440 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 442 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 444 */	NdrFcShort( 0x8 ),	/* 8 */
/* 446 */	NdrFcShort( 0x0 ),	/* 0 */
/* 448 */	NdrFcShort( 0x6 ),	/* Offset= 6 (454) */
/* 450 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 452 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 454 */	
			0x11, 0x0,	/* FC_RP */
/* 456 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (420) */
/* 458 */	
			0x2b,		/* FC_NON_ENCAPSULATED_UNION */
			0x9,		/* FC_ULONG */
/* 460 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 462 */	NdrFcShort( 0xfff8 ),	/* -8 */
/* 464 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 466 */	NdrFcShort( 0x2 ),	/* Offset= 2 (468) */
/* 468 */	NdrFcShort( 0x10 ),	/* 16 */
/* 470 */	NdrFcShort( 0x2f ),	/* 47 */
/* 472 */	NdrFcLong( 0x14 ),	/* 20 */
/* 476 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 478 */	NdrFcLong( 0x3 ),	/* 3 */
/* 482 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 484 */	NdrFcLong( 0x11 ),	/* 17 */
/* 488 */	NdrFcShort( 0x8001 ),	/* Simple arm type: FC_BYTE */
/* 490 */	NdrFcLong( 0x2 ),	/* 2 */
/* 494 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 496 */	NdrFcLong( 0x4 ),	/* 4 */
/* 500 */	NdrFcShort( 0x800a ),	/* Simple arm type: FC_FLOAT */
/* 502 */	NdrFcLong( 0x5 ),	/* 5 */
/* 506 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 508 */	NdrFcLong( 0xb ),	/* 11 */
/* 512 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 514 */	NdrFcLong( 0xa ),	/* 10 */
/* 518 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 520 */	NdrFcLong( 0x6 ),	/* 6 */
/* 524 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (756) */
/* 526 */	NdrFcLong( 0x7 ),	/* 7 */
/* 530 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 532 */	NdrFcLong( 0x8 ),	/* 8 */
/* 536 */	NdrFcShort( 0xfe46 ),	/* Offset= -442 (94) */
/* 538 */	NdrFcLong( 0xd ),	/* 13 */
/* 542 */	NdrFcShort( 0xff3c ),	/* Offset= -196 (346) */
/* 544 */	NdrFcLong( 0x9 ),	/* 9 */
/* 548 */	NdrFcShort( 0xff6e ),	/* Offset= -146 (402) */
/* 550 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 554 */	NdrFcShort( 0xd0 ),	/* Offset= 208 (762) */
/* 556 */	NdrFcLong( 0x24 ),	/* 36 */
/* 560 */	NdrFcShort( 0xd2 ),	/* Offset= 210 (770) */
/* 562 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 566 */	NdrFcShort( 0xcc ),	/* Offset= 204 (770) */
/* 568 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 572 */	NdrFcShort( 0xfc ),	/* Offset= 252 (824) */
/* 574 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 578 */	NdrFcShort( 0xfa ),	/* Offset= 250 (828) */
/* 580 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 584 */	NdrFcShort( 0xf8 ),	/* Offset= 248 (832) */
/* 586 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 590 */	NdrFcShort( 0xf6 ),	/* Offset= 246 (836) */
/* 592 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 596 */	NdrFcShort( 0xf4 ),	/* Offset= 244 (840) */
/* 598 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 602 */	NdrFcShort( 0xf2 ),	/* Offset= 242 (844) */
/* 604 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 608 */	NdrFcShort( 0xdc ),	/* Offset= 220 (828) */
/* 610 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 614 */	NdrFcShort( 0xda ),	/* Offset= 218 (832) */
/* 616 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 620 */	NdrFcShort( 0xe4 ),	/* Offset= 228 (848) */
/* 622 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 626 */	NdrFcShort( 0xda ),	/* Offset= 218 (844) */
/* 628 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 632 */	NdrFcShort( 0xdc ),	/* Offset= 220 (852) */
/* 634 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 638 */	NdrFcShort( 0xda ),	/* Offset= 218 (856) */
/* 640 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 644 */	NdrFcShort( 0xd8 ),	/* Offset= 216 (860) */
/* 646 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 650 */	NdrFcShort( 0xd6 ),	/* Offset= 214 (864) */
/* 652 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 656 */	NdrFcShort( 0xdc ),	/* Offset= 220 (876) */
/* 658 */	NdrFcLong( 0x10 ),	/* 16 */
/* 662 */	NdrFcShort( 0x8002 ),	/* Simple arm type: FC_CHAR */
/* 664 */	NdrFcLong( 0x12 ),	/* 18 */
/* 668 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 670 */	NdrFcLong( 0x13 ),	/* 19 */
/* 674 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 676 */	NdrFcLong( 0x15 ),	/* 21 */
/* 680 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 682 */	NdrFcLong( 0x16 ),	/* 22 */
/* 686 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 688 */	NdrFcLong( 0x17 ),	/* 23 */
/* 692 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 694 */	NdrFcLong( 0xe ),	/* 14 */
/* 698 */	NdrFcShort( 0xba ),	/* Offset= 186 (884) */
/* 700 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 704 */	NdrFcShort( 0xbe ),	/* Offset= 190 (894) */
/* 706 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 710 */	NdrFcShort( 0xbc ),	/* Offset= 188 (898) */
/* 712 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 716 */	NdrFcShort( 0x70 ),	/* Offset= 112 (828) */
/* 718 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 722 */	NdrFcShort( 0x6e ),	/* Offset= 110 (832) */
/* 724 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 728 */	NdrFcShort( 0x6c ),	/* Offset= 108 (836) */
/* 730 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 734 */	NdrFcShort( 0x62 ),	/* Offset= 98 (832) */
/* 736 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 740 */	NdrFcShort( 0x5c ),	/* Offset= 92 (832) */
/* 742 */	NdrFcLong( 0x0 ),	/* 0 */
/* 746 */	NdrFcShort( 0x0 ),	/* Offset= 0 (746) */
/* 748 */	NdrFcLong( 0x1 ),	/* 1 */
/* 752 */	NdrFcShort( 0x0 ),	/* Offset= 0 (752) */
/* 754 */	NdrFcShort( 0xffff ),	/* Offset= -1 (753) */
/* 756 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 758 */	NdrFcShort( 0x8 ),	/* 8 */
/* 760 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 762 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 764 */	NdrFcShort( 0x2 ),	/* Offset= 2 (766) */
/* 766 */	
			0x13, 0x0,	/* FC_OP */
/* 768 */	NdrFcShort( 0x1b8 ),	/* Offset= 440 (1208) */
/* 770 */	
			0x13, 0x0,	/* FC_OP */
/* 772 */	NdrFcShort( 0x20 ),	/* Offset= 32 (804) */
/* 774 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 776 */	NdrFcLong( 0x2f ),	/* 47 */
/* 780 */	NdrFcShort( 0x0 ),	/* 0 */
/* 782 */	NdrFcShort( 0x0 ),	/* 0 */
/* 784 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 786 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 788 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 790 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 792 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 794 */	NdrFcShort( 0x1 ),	/* 1 */
/* 796 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 798 */	NdrFcShort( 0x4 ),	/* 4 */
/* 800 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 802 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 804 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 806 */	NdrFcShort( 0x10 ),	/* 16 */
/* 808 */	NdrFcShort( 0x0 ),	/* 0 */
/* 810 */	NdrFcShort( 0xa ),	/* Offset= 10 (820) */
/* 812 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 814 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 816 */	NdrFcShort( 0xffd6 ),	/* Offset= -42 (774) */
/* 818 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 820 */	
			0x13, 0x0,	/* FC_OP */
/* 822 */	NdrFcShort( 0xffe2 ),	/* Offset= -30 (792) */
/* 824 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 826 */	0x1,		/* FC_BYTE */
			0x5c,		/* FC_PAD */
/* 828 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 830 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 832 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 834 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 836 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 838 */	0xb,		/* FC_HYPER */
			0x5c,		/* FC_PAD */
/* 840 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 842 */	0xa,		/* FC_FLOAT */
			0x5c,		/* FC_PAD */
/* 844 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 846 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 848 */	
			0x13, 0x0,	/* FC_OP */
/* 850 */	NdrFcShort( 0xffa2 ),	/* Offset= -94 (756) */
/* 852 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 854 */	NdrFcShort( 0xfd08 ),	/* Offset= -760 (94) */
/* 856 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 858 */	NdrFcShort( 0xfe00 ),	/* Offset= -512 (346) */
/* 860 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 862 */	NdrFcShort( 0xfe34 ),	/* Offset= -460 (402) */
/* 864 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 866 */	NdrFcShort( 0x2 ),	/* Offset= 2 (868) */
/* 868 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 870 */	NdrFcShort( 0x2 ),	/* Offset= 2 (872) */
/* 872 */	
			0x13, 0x0,	/* FC_OP */
/* 874 */	NdrFcShort( 0x14e ),	/* Offset= 334 (1208) */
/* 876 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 878 */	NdrFcShort( 0x2 ),	/* Offset= 2 (880) */
/* 880 */	
			0x13, 0x0,	/* FC_OP */
/* 882 */	NdrFcShort( 0x14 ),	/* Offset= 20 (902) */
/* 884 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 886 */	NdrFcShort( 0x10 ),	/* 16 */
/* 888 */	0x6,		/* FC_SHORT */
			0x1,		/* FC_BYTE */
/* 890 */	0x1,		/* FC_BYTE */
			0x8,		/* FC_LONG */
/* 892 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 894 */	
			0x13, 0x0,	/* FC_OP */
/* 896 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (884) */
/* 898 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 900 */	0x2,		/* FC_CHAR */
			0x5c,		/* FC_PAD */
/* 902 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x7,		/* 7 */
/* 904 */	NdrFcShort( 0x20 ),	/* 32 */
/* 906 */	NdrFcShort( 0x0 ),	/* 0 */
/* 908 */	NdrFcShort( 0x0 ),	/* Offset= 0 (908) */
/* 910 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 912 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 914 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 916 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 918 */	NdrFcShort( 0xfe34 ),	/* Offset= -460 (458) */
/* 920 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 922 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 924 */	NdrFcShort( 0x4 ),	/* 4 */
/* 926 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 928 */	NdrFcShort( 0x0 ),	/* 0 */
/* 930 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 932 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 934 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 936 */	NdrFcShort( 0x4 ),	/* 4 */
/* 938 */	NdrFcShort( 0x0 ),	/* 0 */
/* 940 */	NdrFcShort( 0x1 ),	/* 1 */
/* 942 */	NdrFcShort( 0x0 ),	/* 0 */
/* 944 */	NdrFcShort( 0x0 ),	/* 0 */
/* 946 */	0x13, 0x0,	/* FC_OP */
/* 948 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (902) */
/* 950 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 952 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 954 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 956 */	NdrFcShort( 0x8 ),	/* 8 */
/* 958 */	NdrFcShort( 0x0 ),	/* 0 */
/* 960 */	NdrFcShort( 0x6 ),	/* Offset= 6 (966) */
/* 962 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 964 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 966 */	
			0x11, 0x0,	/* FC_RP */
/* 968 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (922) */
/* 970 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 972 */	NdrFcShort( 0x4 ),	/* 4 */
/* 974 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 976 */	NdrFcShort( 0x0 ),	/* 0 */
/* 978 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 980 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 982 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 984 */	NdrFcShort( 0x4 ),	/* 4 */
/* 986 */	NdrFcShort( 0x0 ),	/* 0 */
/* 988 */	NdrFcShort( 0x1 ),	/* 1 */
/* 990 */	NdrFcShort( 0x0 ),	/* 0 */
/* 992 */	NdrFcShort( 0x0 ),	/* 0 */
/* 994 */	0x13, 0x0,	/* FC_OP */
/* 996 */	NdrFcShort( 0xff40 ),	/* Offset= -192 (804) */
/* 998 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1000 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1002 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1004 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1006 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1008 */	NdrFcShort( 0x6 ),	/* Offset= 6 (1014) */
/* 1010 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1012 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1014 */	
			0x11, 0x0,	/* FC_RP */
/* 1016 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (970) */
/* 1018 */	
			0x1d,		/* FC_SMFARRAY */
			0x0,		/* 0 */
/* 1020 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1022 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1024 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1026 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1028 */	0x8,		/* FC_LONG */
			0x6,		/* FC_SHORT */
/* 1030 */	0x6,		/* FC_SHORT */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 1032 */	0x0,		/* 0 */
			NdrFcShort( 0xfff1 ),	/* Offset= -15 (1018) */
			0x5b,		/* FC_END */
/* 1036 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1038 */	NdrFcShort( 0x18 ),	/* 24 */
/* 1040 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1042 */	NdrFcShort( 0xa ),	/* Offset= 10 (1052) */
/* 1044 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1046 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1048 */	NdrFcShort( 0xffe8 ),	/* Offset= -24 (1024) */
/* 1050 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1052 */	
			0x11, 0x0,	/* FC_RP */
/* 1054 */	NdrFcShort( 0xfd4e ),	/* Offset= -690 (364) */
/* 1056 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 1058 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1060 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1062 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1064 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1066 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1068 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1070 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1072 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1074 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1076 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1078 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1080 */	0x13, 0x0,	/* FC_OP */
/* 1082 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1056) */
/* 1084 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1086 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1088 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 1090 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1092 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1094 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1096 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1098 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 1100 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1102 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1104 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1106 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1108 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1110 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1112 */	0x13, 0x0,	/* FC_OP */
/* 1114 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1088) */
/* 1116 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1118 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1120 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1122 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1124 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1126 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1128 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1130 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1132 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1134 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1136 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1138 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1140 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1142 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1144 */	0x13, 0x0,	/* FC_OP */
/* 1146 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1120) */
/* 1148 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1150 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1152 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 1154 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1156 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1158 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1160 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1162 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 1164 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1166 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1168 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1170 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1172 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1174 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1176 */	0x13, 0x0,	/* FC_OP */
/* 1178 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1152) */
/* 1180 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1182 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1184 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1186 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1188 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1190 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1192 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1194 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1196 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 1198 */	NdrFcShort( 0xffd8 ),	/* -40 */
/* 1200 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1202 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1204 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1184) */
/* 1206 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1208 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1210 */	NdrFcShort( 0x28 ),	/* 40 */
/* 1212 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1192) */
/* 1214 */	NdrFcShort( 0x0 ),	/* Offset= 0 (1214) */
/* 1216 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1218 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1220 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1222 */	NdrFcShort( 0xfc1c ),	/* Offset= -996 (226) */
/* 1224 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1226 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1228 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1230 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1232 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1234 */	NdrFcShort( 0xfc08 ),	/* Offset= -1016 (218) */
/* 1236 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1238 */	NdrFcLong( 0x5498e339 ),	/* 1419305785 */
/* 1242 */	NdrFcShort( 0x8014 ),	/* -32748 */
/* 1244 */	NdrFcShort( 0x4366 ),	/* 17254 */
/* 1246 */	0x90,		/* 144 */
			0x92,		/* 146 */
/* 1248 */	0x13,		/* 19 */
			0xeb,		/* 235 */
/* 1250 */	0x8a,		/* 138 */
			0xd3,		/* 211 */
/* 1252 */	0x5e,		/* 94 */
			0x1d,		/* 29 */
/* 1254 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1256 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1258) */
/* 1258 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1260 */	NdrFcLong( 0x6e606370 ),	/* 1851810672 */
/* 1264 */	NdrFcShort( 0x4e2 ),	/* 1250 */
/* 1266 */	NdrFcShort( 0x4bcb ),	/* 19403 */
/* 1268 */	0x85,		/* 133 */
			0x2c,		/* 44 */
/* 1270 */	0x31,		/* 49 */
			0x3a,		/* 58 */
/* 1272 */	0x7d,		/* 125 */
			0x4b,		/* 75 */
/* 1274 */	0xad,		/* 173 */
			0x15,		/* 21 */
/* 1276 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1278 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1280) */
/* 1280 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1282 */	NdrFcLong( 0x63b946e2 ),	/* 1673086690 */
/* 1286 */	NdrFcShort( 0x2aee ),	/* 10990 */
/* 1288 */	NdrFcShort( 0x4034 ),	/* 16436 */
/* 1290 */	0xba,		/* 186 */
			0x1c,		/* 28 */
/* 1292 */	0x1b,		/* 27 */
			0x4c,		/* 76 */
/* 1294 */	0xfd,		/* 253 */
			0x68,		/* 104 */
/* 1296 */	0xce,		/* 206 */
			0xc0,		/* 192 */
/* 1298 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1300 */	NdrFcShort( 0xffc0 ),	/* Offset= -64 (1236) */
/* 1302 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1304 */	NdrFcLong( 0xa8e4f6ff ),	/* -1461389569 */
/* 1308 */	NdrFcShort( 0x93da ),	/* -27686 */
/* 1310 */	NdrFcShort( 0x489a ),	/* 18586 */
/* 1312 */	0xa6,		/* 166 */
			0xc3,		/* 195 */
/* 1314 */	0x22,		/* 34 */
			0xa5,		/* 165 */
/* 1316 */	0x88,		/* 136 */
			0x49,		/* 73 */
/* 1318 */	0x32,		/* 50 */
			0xc9,		/* 201 */

			0x0
        }
    };

static const USER_MARSHAL_ROUTINE_QUADRUPLE UserMarshalRoutines[ WIRE_MARSHAL_TABLE_SIZE ] = 
        {
            
            {
            BSTR_UserSize
            ,BSTR_UserMarshal
            ,BSTR_UserUnmarshal
            ,BSTR_UserFree
            },
            {
            LPSAFEARRAY_UserSize
            ,LPSAFEARRAY_UserMarshal
            ,LPSAFEARRAY_UserUnmarshal
            ,LPSAFEARRAY_UserFree
            }

        };



/* Object interface: IUnknown, ver. 0.0,
   GUID={0x00000000,0x0000,0x0000,{0xC0,0x00,0x00,0x00,0x00,0x00,0x00,0x46}} */


/* Object interface: IDispatch, ver. 0.0,
   GUID={0x00020400,0x0000,0x0000,{0xC0,0x00,0x00,0x00,0x00,0x00,0x00,0x46}} */


/* Object interface: IActionBase, ver. 0.0,
   GUID={0x285691E1,0xBFC9,0x4E8B,{0xBE,0x17,0x5B,0x1C,0xC2,0x30,0x2E,0xD9}} */

#pragma code_seg(".orpc")
static const unsigned short IActionBase_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IActionBase_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IActionBase_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IActionBase_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IActionBase_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IActionBaseProxyVtbl = 
{
    0,
    &IID_IActionBase,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IActionBase_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IActionBaseStubVtbl =
{
    &IID_IActionBase,
    &IActionBase_ServerInfo,
    7,
    &IActionBase_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IParameters, ver. 0.0,
   GUID={0x16C62C7B,0x6775,0x4D2B,{0x9B,0xD2,0x43,0x62,0x4E,0x01,0x73,0x8B}} */

#pragma code_seg(".orpc")
static const unsigned short IParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IParametersProxyVtbl = 
{
    0,
    &IID_IParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IParametersStubVtbl =
{
    &IID_IParameters,
    &IParameters_ServerInfo,
    7,
    &IParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IProgressBarInfo, ver. 0.0,
   GUID={0x54E003E2,0xEAA0,0x4321,{0x9A,0x14,0x31,0xCF,0x8E,0x5B,0xCB,0x84}} */

#pragma code_seg(".orpc")
static const unsigned short IProgressBarInfo_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0,
    36,
    66,
    102,
    132
    };

static const MIDL_STUBLESS_PROXY_INFO IProgressBarInfo_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IProgressBarInfo_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IProgressBarInfo_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IProgressBarInfo_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IProgressBarInfoProxyVtbl = 
{
    &IProgressBarInfo_ProxyInfo,
    &IID_IProgressBarInfo,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IProgressBarInfo::Length */ ,
    (void *) (INT_PTR) -1 /* IProgressBarInfo::Next */ ,
    (void *) (INT_PTR) -1 /* IProgressBarInfo::NeedStop */ ,
    (void *) (INT_PTR) -1 /* IProgressBarInfo::Start */ ,
    (void *) (INT_PTR) -1 /* IProgressBarInfo::Finish */
};


static const PRPC_STUB_FUNCTION IProgressBarInfo_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IProgressBarInfoStubVtbl =
{
    &IID_IProgressBarInfo,
    &IProgressBarInfo_ServerInfo,
    12,
    &IProgressBarInfo_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IResultBase, ver. 0.0,
   GUID={0x92F4EEEF,0x602A,0x496D,{0x80,0x67,0x51,0x84,0xF4,0xF1,0xD3,0x7B}} */

#pragma code_seg(".orpc")
static const unsigned short IResultBase_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IResultBase_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IResultBase_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IResultBase_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IResultBase_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IResultBaseProxyVtbl = 
{
    0,
    &IID_IResultBase,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IResultBase_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IResultBaseStubVtbl =
{
    &IID_IResultBase,
    &IResultBase_ServerInfo,
    7,
    &IResultBase_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IResultSet, ver. 0.0,
   GUID={0x5498E339,0x8014,0x4366,{0x90,0x92,0x13,0xEB,0x8A,0xD3,0x5E,0x1D}} */

#pragma code_seg(".orpc")
static const unsigned short IResultSet_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0,
    162
    };

static const MIDL_STUBLESS_PROXY_INFO IResultSet_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IResultSet_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IResultSet_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IResultSet_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IResultSetProxyVtbl = 
{
    &IResultSet_ProxyInfo,
    &IID_IResultSet,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IResultSet::GetCount */ ,
    (void *) (INT_PTR) -1 /* IResultSet::GetResult */
};


static const PRPC_STUB_FUNCTION IResultSet_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IResultSetStubVtbl =
{
    &IID_IResultSet,
    &IResultSet_ServerInfo,
    9,
    &IResultSet_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IAction, ver. 0.0,
   GUID={0xB94E10D8,0x08BD,0x405C,{0xA4,0x35,0x08,0x68,0xDD,0x86,0xCD,0x3C}} */

#pragma code_seg(".orpc")
static const unsigned short IAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318
    };

static const MIDL_STUBLESS_PROXY_INFO IAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _IActionProxyVtbl = 
{
    &IAction_ProxyInfo,
    &IID_IAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IAction::SetActionParameters */ ,
    (void *) (INT_PTR) -1 /* IAction::SetProgressBarInfo */ ,
    (void *) (INT_PTR) -1 /* IAction::CanDo */ ,
    (void *) (INT_PTR) -1 /* IAction::Do */
};


static const PRPC_STUB_FUNCTION IAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IActionStubVtbl =
{
    &IID_IAction,
    &IAction_ServerInfo,
    11,
    &IAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IFunction, ver. 0.0,
   GUID={0x63B946E2,0x2AEE,0x4034,{0xBA,0x1C,0x1B,0x4C,0xFD,0x68,0xCE,0xC0}} */

#pragma code_seg(".orpc")
static const unsigned short IFunction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    360,
    396,
    432,
    468,
    504,
    546,
    588
    };

static const MIDL_STUBLESS_PROXY_INFO IFunction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IFunction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IFunction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IFunction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(17) _IFunctionProxyVtbl = 
{
    &IFunction_ProxyInfo,
    &IID_IFunction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* (void *) (INT_PTR) -1 /* IFunction::GetSystemFunction */ ,
    0 /* (void *) (INT_PTR) -1 /* IFunction::GetSystemFunctionDerivate */ ,
    0 /* (void *) (INT_PTR) -1 /* IFunction::CreateGraph */ ,
    (void *) (INT_PTR) -1 /* IFunction::GetEquations */ ,
    (void *) (INT_PTR) -1 /* IFunction::GetDimension */ ,
    (void *) (INT_PTR) -1 /* IFunction::GetIterations */ ,
    (void *) (INT_PTR) -1 /* IFunction::SetIterations */ ,
    (void *) (INT_PTR) -1 /* IFunction::GetMinimum */ ,
    (void *) (INT_PTR) -1 /* IFunction::GetMaximum */ ,
    (void *) (INT_PTR) -1 /* IFunction::GetLipshitz */
};


static const PRPC_STUB_FUNCTION IFunction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IFunctionStubVtbl =
{
    &IID_IFunction,
    &IFunction_ServerInfo,
    17,
    &IFunction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IComputationParameters, ver. 0.0,
   GUID={0xAB57FCFD,0x2759,0x4E43,{0x80,0x95,0x34,0xFD,0x20,0xEA,0xAA,0x8B}} */

#pragma code_seg(".orpc")
static const unsigned short IComputationParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    630
    };

static const MIDL_STUBLESS_PROXY_INFO IComputationParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IComputationParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IComputationParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IComputationParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IComputationParametersProxyVtbl = 
{
    &IComputationParameters_ProxyInfo,
    &IID_IComputationParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IComputationParameters::GetFunction */
};


static const PRPC_STUB_FUNCTION IComputationParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IComputationParametersStubVtbl =
{
    &IID_IComputationParameters,
    &IComputationParameters_ServerInfo,
    8,
    &IComputationParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IAdaptiveBoxMethod, ver. 0.0,
   GUID={0x20B6A0EB,0x2F40,0x4AA7,{0xA0,0x66,0x0C,0xC6,0x72,0xBF,0x15,0x31}} */

#pragma code_seg(".orpc")
static const unsigned short IAdaptiveBoxMethod_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    666,
    708
    };

static const MIDL_STUBLESS_PROXY_INFO IAdaptiveBoxMethod_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IAdaptiveBoxMethod_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IAdaptiveBoxMethod_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IAdaptiveBoxMethod_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(13) _IAdaptiveBoxMethodProxyVtbl = 
{
    &IAdaptiveBoxMethod_ProxyInfo,
    &IID_IAdaptiveBoxMethod,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IAction::SetActionParameters */ ,
    (void *) (INT_PTR) -1 /* IAction::SetProgressBarInfo */ ,
    (void *) (INT_PTR) -1 /* IAction::CanDo */ ,
    (void *) (INT_PTR) -1 /* IAction::Do */ ,
    (void *) (INT_PTR) -1 /* IAdaptiveBoxMethod::GetDimensionFromParameters */ ,
    (void *) (INT_PTR) -1 /* IAdaptiveBoxMethod::GetRecomendedPrecision */
};


static const PRPC_STUB_FUNCTION IAdaptiveBoxMethod_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IAdaptiveBoxMethodStubVtbl =
{
    &IID_IAdaptiveBoxMethod,
    &IAdaptiveBoxMethod_ServerInfo,
    13,
    &IAdaptiveBoxMethod_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IAdaptiveBoxParameters, ver. 0.0,
   GUID={0xAF4C5C56,0xDFE3,0x4DCE,{0x9A,0x4E,0xE4,0x89,0x43,0xF4,0x9F,0x51}} */

#pragma code_seg(".orpc")
static const unsigned short IAdaptiveBoxParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    630,
    756,
    798
    };

static const MIDL_STUBLESS_PROXY_INFO IAdaptiveBoxParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IAdaptiveBoxParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IAdaptiveBoxParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IAdaptiveBoxParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(10) _IAdaptiveBoxParametersProxyVtbl = 
{
    &IAdaptiveBoxParameters_ProxyInfo,
    &IID_IAdaptiveBoxParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IComputationParameters::GetFunction */ ,
    (void *) (INT_PTR) -1 /* IAdaptiveBoxParameters::GetFactor */ ,
    (void *) (INT_PTR) -1 /* IAdaptiveBoxParameters::GetPrecision */
};


static const PRPC_STUB_FUNCTION IAdaptiveBoxParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IAdaptiveBoxParametersStubVtbl =
{
    &IID_IAdaptiveBoxParameters,
    &IAdaptiveBoxParameters_ServerInfo,
    10,
    &IAdaptiveBoxParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IResultMetadata, ver. 0.0,
   GUID={0xA8E4F6FF,0x93DA,0x489A,{0xA6,0xC3,0x22,0xA5,0x88,0x49,0x32,0xC9}} */

#pragma code_seg(".orpc")
static const unsigned short IResultMetadata_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    840,
    882
    };

static const MIDL_STUBLESS_PROXY_INFO IResultMetadata_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IResultMetadata_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IResultMetadata_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IResultMetadata_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IResultMetadataProxyVtbl = 
{
    &IResultMetadata_ProxyInfo,
    &IID_IResultMetadata,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IResultMetadata::EqualType */ ,
    (void *) (INT_PTR) -1 /* IResultMetadata::Clone */
};


static const PRPC_STUB_FUNCTION IResultMetadata_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IResultMetadataStubVtbl =
{
    &IID_IResultMetadata,
    &IResultMetadata_ServerInfo,
    9,
    &IResultMetadata_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IResult, ver. 0.0,
   GUID={0x9B7D45A5,0x77FD,0x4E97,{0x8C,0x4A,0x76,0xD3,0x61,0x0C,0xC8,0x75}} */

#pragma code_seg(".orpc")
static const unsigned short IResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    918
    };

static const MIDL_STUBLESS_PROXY_INFO IResult_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IResult_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IResult_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IResult_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IResultProxyVtbl = 
{
    &IResult_ProxyInfo,
    &IID_IResult,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IResult::GetMetadata */
};


static const PRPC_STUB_FUNCTION IResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IResultStubVtbl =
{
    &IID_IResult,
    &IResult_ServerInfo,
    8,
    &IResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IResultInfo, ver. 0.0,
   GUID={0xEDD6B3E5,0x2F48,0x4232,{0xBC,0xF6,0x00,0x5F,0xC8,0x75,0x76,0xBF}} */

#pragma code_seg(".orpc")
static const unsigned short IResultInfo_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IResultInfo_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IResultInfo_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IResultInfo_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IResultInfo_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IResultInfoProxyVtbl = 
{
    0,
    &IID_IResultInfo,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IResultInfo_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IResultInfoStubVtbl =
{
    &IID_IResultInfo,
    &IResultInfo_ServerInfo,
    7,
    &IResultInfo_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IGraphInfo, ver. 0.0,
   GUID={0x0641C669,0xB362,0x48C9,{0x8B,0x73,0xD0,0x2B,0x6E,0x25,0x2A,0x9D}} */

#pragma code_seg(".orpc")
static const unsigned short IGraphInfo_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0,
    954,
    990,
    1026,
    1068,
    1110,
    1152
    };

static const MIDL_STUBLESS_PROXY_INFO IGraphInfo_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IGraphInfo_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IGraphInfo_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IGraphInfo_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(14) _IGraphInfoProxyVtbl = 
{
    &IGraphInfo_ProxyInfo,
    &IID_IGraphInfo,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::GetNodes */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::GetEdges */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::GetDimension */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::GetMinimum */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::GetMaximum */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::GetGridNumber */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::GetGridSize */
};


static const PRPC_STUB_FUNCTION IGraphInfo_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IGraphInfoStubVtbl =
{
    &IID_IGraphInfo,
    &IGraphInfo_ServerInfo,
    14,
    &IGraphInfo_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IGraphResult, ver. 0.0,
   GUID={0x6E606370,0x04E2,0x4BCB,{0x85,0x2C,0x31,0x3A,0x7D,0x4B,0xAD,0x15}} */

#pragma code_seg(".orpc")
static const unsigned short IGraphResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    918,
    (unsigned short) -1,
    1194,
    1230,
    1266,
    1302
    };

static const MIDL_STUBLESS_PROXY_INFO IGraphResult_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IGraphResult_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IGraphResult_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IGraphResult_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(13) _IGraphResultProxyVtbl = 
{
    &IGraphResult_ProxyInfo,
    &IID_IGraphResult,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IResult::GetMetadata */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraphResult::GetGraph */ ,
    (void *) (INT_PTR) -1 /* IGraphResult::GetGraphInfo */ ,
    (void *) (INT_PTR) -1 /* IGraphResult::IsStrongComponent */ ,
    (void *) (INT_PTR) -1 /* IGraphResult::SaveText */ ,
    (void *) (INT_PTR) -1 /* IGraphResult::SaveGraph */
};


static const PRPC_STUB_FUNCTION IGraphResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IGraphResultStubVtbl =
{
    &IID_IGraphResult,
    &IGraphResult_ServerInfo,
    13,
    &IGraphResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IWritableGraphResult, ver. 0.0,
   GUID={0x6ED8D0EA,0x3E9C,0x441A,{0x96,0xC6,0xEE,0xB2,0xAF,0xCB,0xE2,0x7D}} */

#pragma code_seg(".orpc")
static const unsigned short IWritableGraphResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1338,
    1374
    };

static const MIDL_STUBLESS_PROXY_INFO IWritableGraphResult_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IWritableGraphResult_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IWritableGraphResult_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IWritableGraphResult_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(10) _IWritableGraphResultProxyVtbl = 
{
    &IWritableGraphResult_ProxyInfo,
    &IID_IWritableGraphResult,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* (void *) (INT_PTR) -1 /* IWritableGraphResult::SetGraph */ ,
    (void *) (INT_PTR) -1 /* IWritableGraphResult::SetMetadata */ ,
    (void *) (INT_PTR) -1 /* IWritableGraphResult::SetGraphFromFile */
};


static const PRPC_STUB_FUNCTION IWritableGraphResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IWritableGraphResultStubVtbl =
{
    &IID_IWritableGraphResult,
    &IWritableGraphResult_ServerInfo,
    10,
    &IWritableGraphResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IWritableResultSet, ver. 0.0,
   GUID={0xA56A15AC,0xEAC4,0x4D8B,{0x92,0xFC,0x84,0xCF,0x84,0xFC,0x4F,0x16}} */

#pragma code_seg(".orpc")
static const unsigned short IWritableResultSet_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1416
    };

static const MIDL_STUBLESS_PROXY_INFO IWritableResultSet_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IWritableResultSet_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IWritableResultSet_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IWritableResultSet_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IWritableResultSetProxyVtbl = 
{
    &IWritableResultSet_ProxyInfo,
    &IID_IWritableResultSet,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IWritableResultSet::AddResult */
};


static const PRPC_STUB_FUNCTION IWritableResultSet_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IWritableResultSetStubVtbl =
{
    &IID_IWritableResultSet,
    &IWritableResultSet_ServerInfo,
    8,
    &IWritableResultSet_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IGraphResultImpl, ver. 0.0,
   GUID={0x150237B9,0x7739,0x4882,{0x87,0xE1,0x8F,0xE9,0x26,0xA9,0x6A,0xFF}} */

#pragma code_seg(".orpc")
static const unsigned short IGraphResultImpl_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IGraphResultImpl_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IGraphResultImpl_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IGraphResultImpl_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IGraphResultImpl_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IGraphResultImplProxyVtbl = 
{
    0,
    &IID_IGraphResultImpl,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IGraphResultImpl_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IGraphResultImplStubVtbl =
{
    &IID_IGraphResultImpl,
    &IGraphResultImpl_ServerInfo,
    7,
    &IGraphResultImpl_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISymbolicImageMetadata, ver. 0.0,
   GUID={0x24EEB65B,0x81FF,0x42EA,{0x85,0x21,0x6B,0x3F,0x62,0x66,0x5F,0x84}} */

#pragma code_seg(".orpc")
static const unsigned short ISymbolicImageMetadata_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    840,
    882,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO ISymbolicImageMetadata_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISymbolicImageMetadata_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISymbolicImageMetadata_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISymbolicImageMetadata_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _ISymbolicImageMetadataProxyVtbl = 
{
    0,
    &IID_ISymbolicImageMetadata,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IResultMetadata::EqualType */ ,
    0 /* forced delegation IResultMetadata::Clone */
};


static const PRPC_STUB_FUNCTION ISymbolicImageMetadata_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISymbolicImageMetadataStubVtbl =
{
    &IID_ISymbolicImageMetadata,
    &ISymbolicImageMetadata_ServerInfo,
    9,
    &ISymbolicImageMetadata_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IResultSetImpl, ver. 0.0,
   GUID={0x3EB38E81,0xF41E,0x44BD,{0x85,0xE3,0x48,0x6C,0xF0,0x5F,0xD1,0xB2}} */

#pragma code_seg(".orpc")
static const unsigned short IResultSetImpl_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IResultSetImpl_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IResultSetImpl_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IResultSetImpl_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IResultSetImpl_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IResultSetImplProxyVtbl = 
{
    0,
    &IID_IResultSetImpl,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IResultSetImpl_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IResultSetImplStubVtbl =
{
    &IID_IResultSetImpl,
    &IResultSetImpl_ServerInfo,
    7,
    &IResultSetImpl_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IAdaptiveMethodAction, ver. 0.0,
   GUID={0x6EBF68E3,0x4686,0x40C8,{0x9F,0x63,0x3A,0xBC,0x35,0x04,0x92,0x3A}} */

#pragma code_seg(".orpc")
static const unsigned short IAdaptiveMethodAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    1452,
    1500
    };

static const MIDL_STUBLESS_PROXY_INFO IAdaptiveMethodAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IAdaptiveMethodAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IAdaptiveMethodAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IAdaptiveMethodAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(13) _IAdaptiveMethodActionProxyVtbl = 
{
    &IAdaptiveMethodAction_ProxyInfo,
    &IID_IAdaptiveMethodAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IAction::SetActionParameters */ ,
    (void *) (INT_PTR) -1 /* IAction::SetProgressBarInfo */ ,
    (void *) (INT_PTR) -1 /* IAction::CanDo */ ,
    (void *) (INT_PTR) -1 /* IAction::Do */ ,
    (void *) (INT_PTR) -1 /* IAdaptiveMethodAction::GetRecomendedPrecision */ ,
    (void *) (INT_PTR) -1 /* IAdaptiveMethodAction::GetDimension */
};


static const PRPC_STUB_FUNCTION IAdaptiveMethodAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IAdaptiveMethodActionStubVtbl =
{
    &IID_IAdaptiveMethodAction,
    &IAdaptiveMethodAction_ServerInfo,
    13,
    &IAdaptiveMethodAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IAdaptiveMethodParameters, ver. 0.0,
   GUID={0x554362EE,0x42C4,0x48EB,{0xB5,0xC3,0x8C,0x10,0x27,0x3D,0x73,0xB5}} */

#pragma code_seg(".orpc")
static const unsigned short IAdaptiveMethodParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    630,
    756,
    798,
    1542
    };

static const MIDL_STUBLESS_PROXY_INFO IAdaptiveMethodParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IAdaptiveMethodParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IAdaptiveMethodParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IAdaptiveMethodParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _IAdaptiveMethodParametersProxyVtbl = 
{
    &IAdaptiveMethodParameters_ProxyInfo,
    &IID_IAdaptiveMethodParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IComputationParameters::GetFunction */ ,
    (void *) (INT_PTR) -1 /* IAdaptiveMethodParameters::GetFactor */ ,
    (void *) (INT_PTR) -1 /* IAdaptiveMethodParameters::GetPrecision */ ,
    (void *) (INT_PTR) -1 /* IAdaptiveMethodParameters::GetUpperLimit */
};


static const PRPC_STUB_FUNCTION IAdaptiveMethodParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IAdaptiveMethodParametersStubVtbl =
{
    &IID_IAdaptiveMethodParameters,
    &IAdaptiveMethodParameters_ServerInfo,
    11,
    &IAdaptiveMethodParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IBoxMethodAction, ver. 0.0,
   GUID={0x586FAD2F,0xD9E4,0x4A30,{0xA9,0x25,0x34,0x5C,0x7E,0x1B,0xDC,0x56}} */

#pragma code_seg(".orpc")
static const unsigned short IBoxMethodAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    666
    };

static const MIDL_STUBLESS_PROXY_INFO IBoxMethodAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IBoxMethodAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IBoxMethodAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IBoxMethodAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IBoxMethodActionProxyVtbl = 
{
    &IBoxMethodAction_ProxyInfo,
    &IID_IBoxMethodAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IAction::SetActionParameters */ ,
    (void *) (INT_PTR) -1 /* IAction::SetProgressBarInfo */ ,
    (void *) (INT_PTR) -1 /* IAction::CanDo */ ,
    (void *) (INT_PTR) -1 /* IAction::Do */ ,
    (void *) (INT_PTR) -1 /* IBoxMethodAction::GetDimensionForParameters */
};


static const PRPC_STUB_FUNCTION IBoxMethodAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IBoxMethodActionStubVtbl =
{
    &IID_IBoxMethodAction,
    &IBoxMethodAction_ServerInfo,
    12,
    &IBoxMethodAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IBoxMethodParameters, ver. 0.0,
   GUID={0xEF3F28E7,0xDA5A,0x4294,{0x9C,0x12,0x65,0x6D,0x0B,0x7C,0xB7,0x4A}} */

#pragma code_seg(".orpc")
static const unsigned short IBoxMethodParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    630,
    756,
    66
    };

static const MIDL_STUBLESS_PROXY_INFO IBoxMethodParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IBoxMethodParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IBoxMethodParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IBoxMethodParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(10) _IBoxMethodParametersProxyVtbl = 
{
    &IBoxMethodParameters_ProxyInfo,
    &IID_IBoxMethodParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IComputationParameters::GetFunction */ ,
    (void *) (INT_PTR) -1 /* IBoxMethodParameters::GetFactor */ ,
    (void *) (INT_PTR) -1 /* IBoxMethodParameters::UseDerivate */
};


static const PRPC_STUB_FUNCTION IBoxMethodParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IBoxMethodParametersStubVtbl =
{
    &IID_IBoxMethodParameters,
    &IBoxMethodParameters_ServerInfo,
    10,
    &IBoxMethodParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IComponentRegistrar, ver. 0.0,
   GUID={0xa817e7a2,0x43fa,0x11d0,{0x9e,0x44,0x00,0xaa,0x00,0xb6,0x77,0x0a}} */

#pragma code_seg(".orpc")
static const unsigned short IComponentRegistrar_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1578,
    36,
    1614,
    1644,
    1266,
    1302
    };

static const MIDL_STUBLESS_PROXY_INFO IComponentRegistrar_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IComponentRegistrar_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IComponentRegistrar_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IComponentRegistrar_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(13) _IComponentRegistrarProxyVtbl = 
{
    &IComponentRegistrar_ProxyInfo,
    &IID_IComponentRegistrar,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IComponentRegistrar::Attach */ ,
    (void *) (INT_PTR) -1 /* IComponentRegistrar::RegisterAll */ ,
    (void *) (INT_PTR) -1 /* IComponentRegistrar::UnregisterAll */ ,
    (void *) (INT_PTR) -1 /* IComponentRegistrar::GetComponents */ ,
    (void *) (INT_PTR) -1 /* IComponentRegistrar::RegisterComponent */ ,
    (void *) (INT_PTR) -1 /* IComponentRegistrar::UnregisterComponent */
};


static const PRPC_STUB_FUNCTION IComponentRegistrar_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IComponentRegistrarStubVtbl =
{
    &IID_IComponentRegistrar,
    &IComponentRegistrar_ServerInfo,
    13,
    &IComponentRegistrar_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ITarjanAction, ver. 0.0,
   GUID={0xFAFD82A9,0x346E,0x4BD7,{0x83,0x16,0xF1,0x6B,0x10,0x5A,0x46,0x53}} */

#pragma code_seg(".orpc")
static const unsigned short ITarjanAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO ITarjanAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ITarjanAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ITarjanAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ITarjanAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _ITarjanActionProxyVtbl = 
{
    0,
    &IID_ITarjanAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IAction::SetActionParameters */ ,
    0 /* forced delegation IAction::SetProgressBarInfo */ ,
    0 /* forced delegation IAction::CanDo */ ,
    0 /* forced delegation IAction::Do */
};


static const PRPC_STUB_FUNCTION ITarjanAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ITarjanActionStubVtbl =
{
    &IID_ITarjanAction,
    &ITarjanAction_ServerInfo,
    11,
    &ITarjanAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ITarjanParameters, ver. 0.0,
   GUID={0x8DB63B4A,0x7E18,0x4328,{0x93,0x35,0x41,0x9C,0x4C,0xE5,0xA4,0xE5}} */

#pragma code_seg(".orpc")
static const unsigned short ITarjanParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1686
    };

static const MIDL_STUBLESS_PROXY_INFO ITarjanParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ITarjanParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ITarjanParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ITarjanParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _ITarjanParametersProxyVtbl = 
{
    &ITarjanParameters_ProxyInfo,
    &IID_ITarjanParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* ITarjanParameters::NeedEdgeResolve */
};


static const PRPC_STUB_FUNCTION ITarjanParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _ITarjanParametersStubVtbl =
{
    &IID_ITarjanParameters,
    &ITarjanParameters_ServerInfo,
    8,
    &ITarjanParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IPointMethodAction, ver. 0.0,
   GUID={0x1B1FF1EE,0x4EB6,0x4F0A,{0xB6,0xAB,0xCC,0xBF,0xFA,0x28,0xB9,0xF0}} */

#pragma code_seg(".orpc")
static const unsigned short IPointMethodAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    1722
    };

static const MIDL_STUBLESS_PROXY_INFO IPointMethodAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IPointMethodAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IPointMethodAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IPointMethodAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IPointMethodActionProxyVtbl = 
{
    &IPointMethodAction_ProxyInfo,
    &IID_IPointMethodAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IAction::SetActionParameters */ ,
    (void *) (INT_PTR) -1 /* IAction::SetProgressBarInfo */ ,
    (void *) (INT_PTR) -1 /* IAction::CanDo */ ,
    (void *) (INT_PTR) -1 /* IAction::Do */ ,
    (void *) (INT_PTR) -1 /* IPointMethodAction::GetDimensionForParameters */
};


static const PRPC_STUB_FUNCTION IPointMethodAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IPointMethodActionStubVtbl =
{
    &IID_IPointMethodAction,
    &IPointMethodAction_ServerInfo,
    12,
    &IPointMethodAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IPointMethodParameters, ver. 0.0,
   GUID={0xADCEDDBC,0x441A,0x479D,{0x8E,0x7A,0x70,0x69,0x21,0xDA,0x82,0xAC}} */

#pragma code_seg(".orpc")
static const unsigned short IPointMethodParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    630,
    756,
    1764,
    1230,
    1806
    };

static const MIDL_STUBLESS_PROXY_INFO IPointMethodParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IPointMethodParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IPointMethodParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IPointMethodParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IPointMethodParametersProxyVtbl = 
{
    &IPointMethodParameters_ProxyInfo,
    &IID_IPointMethodParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IComputationParameters::GetFunction */ ,
    (void *) (INT_PTR) -1 /* IPointMethodParameters::GetFactor */ ,
    (void *) (INT_PTR) -1 /* IPointMethodParameters::GetPoints */ ,
    (void *) (INT_PTR) -1 /* IPointMethodParameters::UseOffsets */ ,
    (void *) (INT_PTR) -1 /* IPointMethodParameters::GetOffset */
};


static const PRPC_STUB_FUNCTION IPointMethodParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IPointMethodParametersStubVtbl =
{
    &IID_IPointMethodParameters,
    &IPointMethodParameters_ServerInfo,
    12,
    &IPointMethodParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IProjectAction, ver. 0.0,
   GUID={0xDD6571DF,0x3579,0x4F30,{0xBB,0x16,0x48,0x2C,0xA0,0xA1,0x04,0xA4}} */

#pragma code_seg(".orpc")
static const unsigned short IProjectAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    1722
    };

static const MIDL_STUBLESS_PROXY_INFO IProjectAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IProjectAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IProjectAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IProjectAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IProjectActionProxyVtbl = 
{
    &IProjectAction_ProxyInfo,
    &IID_IProjectAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IAction::SetActionParameters */ ,
    (void *) (INT_PTR) -1 /* IAction::SetProgressBarInfo */ ,
    (void *) (INT_PTR) -1 /* IAction::CanDo */ ,
    (void *) (INT_PTR) -1 /* IAction::Do */ ,
    (void *) (INT_PTR) -1 /* IProjectAction::GetDimention */
};


static const PRPC_STUB_FUNCTION IProjectAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IProjectActionStubVtbl =
{
    &IID_IProjectAction,
    &IProjectAction_ServerInfo,
    12,
    &IProjectAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IProjectActionParameters, ver. 0.0,
   GUID={0x840AFB9E,0xF0B8,0x4601,{0x83,0x26,0xC1,0x01,0xF1,0x92,0x13,0x7D}} */

#pragma code_seg(".orpc")
static const unsigned short IProjectActionParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1854
    };

static const MIDL_STUBLESS_PROXY_INFO IProjectActionParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IProjectActionParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IProjectActionParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IProjectActionParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IProjectActionParametersProxyVtbl = 
{
    &IProjectActionParameters_ProxyInfo,
    &IID_IProjectActionParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IProjectActionParameters::GetDevisor */
};


static const PRPC_STUB_FUNCTION IProjectActionParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IProjectActionParametersStubVtbl =
{
    &IID_IProjectActionParameters,
    &IProjectActionParameters_ServerInfo,
    8,
    &IProjectActionParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IDummy, ver. 0.0,
   GUID={0x0A8C775B,0x8E19,0x4642,{0xB2,0xD7,0x5B,0xBB,0x43,0x7B,0x7B,0x97}} */

#pragma code_seg(".orpc")
static const unsigned short IDummy_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IDummy_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IDummy_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IDummy_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IDummy_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IDummyProxyVtbl = 
{
    0,
    &IID_IDummy,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IDummy_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IDummyStubVtbl =
{
    &IID_IDummy,
    &IDummy_ServerInfo,
    7,
    &IDummy_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IIsolatedSetAction, ver. 0.0,
   GUID={0x787DC58F,0xCD39,0x4BE2,{0x9B,0x58,0xD5,0xB9,0x9A,0xDC,0xFC,0x4D}} */

#pragma code_seg(".orpc")
static const unsigned short IIsolatedSetAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IIsolatedSetAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IIsolatedSetAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IIsolatedSetAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IIsolatedSetAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _IIsolatedSetActionProxyVtbl = 
{
    0,
    &IID_IIsolatedSetAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IAction::SetActionParameters */ ,
    0 /* forced delegation IAction::SetProgressBarInfo */ ,
    0 /* forced delegation IAction::CanDo */ ,
    0 /* forced delegation IAction::Do */
};


static const PRPC_STUB_FUNCTION IIsolatedSetAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IIsolatedSetActionStubVtbl =
{
    &IID_IIsolatedSetAction,
    &IIsolatedSetAction_ServerInfo,
    11,
    &IIsolatedSetAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IIsolatedSetParameters, ver. 0.0,
   GUID={0x01C806AD,0x6003,0x4F5B,{0x84,0x05,0xAE,0x3D,0xD6,0x37,0xD8,0x54}} */

#pragma code_seg(".orpc")
static const unsigned short IIsolatedSetParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1896
    };

static const MIDL_STUBLESS_PROXY_INFO IIsolatedSetParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IIsolatedSetParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IIsolatedSetParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IIsolatedSetParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IIsolatedSetParametersProxyVtbl = 
{
    &IIsolatedSetParameters_ProxyInfo,
    &IID_IIsolatedSetParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IIsolatedSetParameters::GetStartSet */
};


static const PRPC_STUB_FUNCTION IIsolatedSetParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IIsolatedSetParametersStubVtbl =
{
    &IID_IIsolatedSetParameters,
    &IIsolatedSetParameters_ServerInfo,
    8,
    &IIsolatedSetParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMinimalLoopLocalizationAction, ver. 0.0,
   GUID={0x9FFB9554,0x2D64,0x45EE,{0x9F,0x79,0xB3,0x10,0x98,0xFF,0x85,0x12}} */

#pragma code_seg(".orpc")
static const unsigned short IMinimalLoopLocalizationAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    1722
    };

static const MIDL_STUBLESS_PROXY_INFO IMinimalLoopLocalizationAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMinimalLoopLocalizationAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMinimalLoopLocalizationAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMinimalLoopLocalizationAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IMinimalLoopLocalizationActionProxyVtbl = 
{
    &IMinimalLoopLocalizationAction_ProxyInfo,
    &IID_IMinimalLoopLocalizationAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IAction::SetActionParameters */ ,
    (void *) (INT_PTR) -1 /* IAction::SetProgressBarInfo */ ,
    (void *) (INT_PTR) -1 /* IAction::CanDo */ ,
    (void *) (INT_PTR) -1 /* IAction::Do */ ,
    (void *) (INT_PTR) -1 /* IMinimalLoopLocalizationAction::GetDimension */
};


static const PRPC_STUB_FUNCTION IMinimalLoopLocalizationAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMinimalLoopLocalizationActionStubVtbl =
{
    &IID_IMinimalLoopLocalizationAction,
    &IMinimalLoopLocalizationAction_ServerInfo,
    12,
    &IMinimalLoopLocalizationAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMinimalLoopLocalizationParameters, ver. 0.0,
   GUID={0xB90D3C01,0xF6F8,0x4D06,{0x8E,0x01,0xC1,0x2C,0x6D,0x51,0xF7,0x0A}} */

#pragma code_seg(".orpc")
static const unsigned short IMinimalLoopLocalizationParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1932
    };

static const MIDL_STUBLESS_PROXY_INFO IMinimalLoopLocalizationParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMinimalLoopLocalizationParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMinimalLoopLocalizationParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMinimalLoopLocalizationParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IMinimalLoopLocalizationParametersProxyVtbl = 
{
    &IMinimalLoopLocalizationParameters_ProxyInfo,
    &IID_IMinimalLoopLocalizationParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IMinimalLoopLocalizationParameters::GetCoordinate */
};


static const PRPC_STUB_FUNCTION IMinimalLoopLocalizationParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IMinimalLoopLocalizationParametersStubVtbl =
{
    &IID_IMinimalLoopLocalizationParameters,
    &IMinimalLoopLocalizationParameters_ServerInfo,
    8,
    &IMinimalLoopLocalizationParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISIRomActionParameters, ver. 0.0,
   GUID={0x9CF385EA,0x26DB,0x4A19,{0xAB,0x20,0x5E,0x73,0x56,0x54,0xD4,0x69}} */

#pragma code_seg(".orpc")
static const unsigned short ISIRomActionParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    630,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO ISIRomActionParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISIRomActionParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISIRomActionParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISIRomActionParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _ISIRomActionParametersProxyVtbl = 
{
    0,
    &IID_ISIRomActionParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IComputationParameters::GetFunction */
};


static const PRPC_STUB_FUNCTION ISIRomActionParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _ISIRomActionParametersStubVtbl =
{
    &IID_ISIRomActionParameters,
    &ISIRomActionParameters_ServerInfo,
    8,
    &ISIRomActionParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISIRomAction, ver. 0.0,
   GUID={0x44DAD8BF,0x971F,0x485D,{0x86,0xC5,0x45,0xFD,0x1F,0x67,0xAC,0xFE}} */

#pragma code_seg(".orpc")
static const unsigned short ISIRomAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO ISIRomAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISIRomAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISIRomAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISIRomAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _ISIRomActionProxyVtbl = 
{
    0,
    &IID_ISIRomAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IAction::SetActionParameters */ ,
    0 /* forced delegation IAction::SetProgressBarInfo */ ,
    0 /* forced delegation IAction::CanDo */ ,
    0 /* forced delegation IAction::Do */
};


static const PRPC_STUB_FUNCTION ISIRomAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISIRomActionStubVtbl =
{
    &IID_ISIRomAction,
    &ISIRomAction_ServerInfo,
    11,
    &ISIRomAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISpectrumMetadata, ver. 0.0,
   GUID={0x139E4822,0x4DF9,0x44B1,{0x88,0x25,0xFA,0xD0,0x74,0x49,0x25,0x05}} */

#pragma code_seg(".orpc")
static const unsigned short ISpectrumMetadata_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    840,
    882,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO ISpectrumMetadata_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISpectrumMetadata_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISpectrumMetadata_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISpectrumMetadata_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _ISpectrumMetadataProxyVtbl = 
{
    0,
    &IID_ISpectrumMetadata,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IResultMetadata::EqualType */ ,
    0 /* forced delegation IResultMetadata::Clone */
};


static const PRPC_STUB_FUNCTION ISpectrumMetadata_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISpectrumMetadataStubVtbl =
{
    &IID_ISpectrumMetadata,
    &ISpectrumMetadata_ServerInfo,
    9,
    &ISpectrumMetadata_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISpectrumResult, ver. 0.0,
   GUID={0x2003DF4C,0x5367,0x4F11,{0xA2,0x9C,0x44,0x7E,0x7E,0x45,0xE5,0xAA}} */

#pragma code_seg(".orpc")
static const unsigned short ISpectrumResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    918,
    1974,
    2010,
    1542,
    396
    };

static const MIDL_STUBLESS_PROXY_INFO ISpectrumResult_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISpectrumResult_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISpectrumResult_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISpectrumResult_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _ISpectrumResultProxyVtbl = 
{
    &ISpectrumResult_ProxyInfo,
    &IID_ISpectrumResult,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IResult::GetMetadata */ ,
    (void *) (INT_PTR) -1 /* ISpectrumResult::GetLowerBound */ ,
    (void *) (INT_PTR) -1 /* ISpectrumResult::GetUpperBound */ ,
    (void *) (INT_PTR) -1 /* ISpectrumResult::GetLowerLength */ ,
    (void *) (INT_PTR) -1 /* ISpectrumResult::GetUpperLength */
};


static const PRPC_STUB_FUNCTION ISpectrumResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISpectrumResultStubVtbl =
{
    &IID_ISpectrumResult,
    &ISpectrumResult_ServerInfo,
    12,
    &ISpectrumResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IDummy1, ver. 0.0,
   GUID={0x5896F6EB,0xCFBF,0x406C,{0xA0,0xFD,0xEA,0x25,0x36,0x76,0x73,0xD0}} */

#pragma code_seg(".orpc")
static const unsigned short IDummy1_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IDummy1_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IDummy1_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IDummy1_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IDummy1_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IDummy1ProxyVtbl = 
{
    0,
    &IID_IDummy1,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IDummy1_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IDummy1StubVtbl =
{
    &IID_IDummy1,
    &IDummy1_ServerInfo,
    7,
    &IDummy1_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IDummy2, ver. 0.0,
   GUID={0x880BF42F,0xA1E3,0x4FA8,{0x87,0xAD,0xFB,0x8D,0x96,0xF2,0x75,0xA0}} */

#pragma code_seg(".orpc")
static const unsigned short IDummy2_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IDummy2_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IDummy2_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IDummy2_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IDummy2_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IDummy2ProxyVtbl = 
{
    0,
    &IID_IDummy2,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IDummy2_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IDummy2StubVtbl =
{
    &IID_IDummy2,
    &IDummy2_ServerInfo,
    7,
    &IDummy2_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMS2DCreationAction, ver. 0.0,
   GUID={0xB56578FA,0x7E2F,0x4EDC,{0xA2,0xF0,0x1B,0x3F,0x91,0x28,0xF2,0x27}} */

#pragma code_seg(".orpc")
static const unsigned short IMS2DCreationAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IMS2DCreationAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMS2DCreationAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMS2DCreationAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMS2DCreationAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _IMS2DCreationActionProxyVtbl = 
{
    0,
    &IID_IMS2DCreationAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IAction::SetActionParameters */ ,
    0 /* forced delegation IAction::SetProgressBarInfo */ ,
    0 /* forced delegation IAction::CanDo */ ,
    0 /* forced delegation IAction::Do */
};


static const PRPC_STUB_FUNCTION IMS2DCreationAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMS2DCreationActionStubVtbl =
{
    &IID_IMS2DCreationAction,
    &IMS2DCreationAction_ServerInfo,
    11,
    &IMS2DCreationAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMS2DCreationParameters, ver. 0.0,
   GUID={0x52E2BF5B,0x0E91,0x4588,{0x8B,0x56,0xD7,0xB4,0x9E,0xF8,0xDE,0x0B}} */

#pragma code_seg(".orpc")
static const unsigned short IMS2DCreationParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1854
    };

static const MIDL_STUBLESS_PROXY_INFO IMS2DCreationParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMS2DCreationParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMS2DCreationParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMS2DCreationParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IMS2DCreationParametersProxyVtbl = 
{
    &IMS2DCreationParameters_ProxyInfo,
    &IID_IMS2DCreationParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IMS2DCreationParameters::GetFactor */
};


static const PRPC_STUB_FUNCTION IMS2DCreationParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IMS2DCreationParametersStubVtbl =
{
    &IID_IMS2DCreationParameters,
    &IMS2DCreationParameters_ServerInfo,
    8,
    &IMS2DCreationParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IDummy3, ver. 0.0,
   GUID={0x506F850B,0x7CBA,0x4A7F,{0xA1,0x6D,0x25,0xB3,0xD1,0x04,0xF7,0xBE}} */

#pragma code_seg(".orpc")
static const unsigned short IDummy3_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IDummy3_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IDummy3_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IDummy3_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IDummy3_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IDummy3ProxyVtbl = 
{
    0,
    &IID_IDummy3,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IDummy3_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IDummy3StubVtbl =
{
    &IID_IDummy3,
    &IDummy3_ServerInfo,
    7,
    &IDummy3_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMS2DProcessAction, ver. 0.0,
   GUID={0xF8F384DC,0xFF2E,0x48B5,{0x9F,0xB3,0x95,0x8A,0x82,0x85,0x54,0xC5}} */

#pragma code_seg(".orpc")
static const unsigned short IMS2DProcessAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IMS2DProcessAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMS2DProcessAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMS2DProcessAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMS2DProcessAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _IMS2DProcessActionProxyVtbl = 
{
    0,
    &IID_IMS2DProcessAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IAction::SetActionParameters */ ,
    0 /* forced delegation IAction::SetProgressBarInfo */ ,
    0 /* forced delegation IAction::CanDo */ ,
    0 /* forced delegation IAction::Do */
};


static const PRPC_STUB_FUNCTION IMS2DProcessAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMS2DProcessActionStubVtbl =
{
    &IID_IMS2DProcessAction,
    &IMS2DProcessAction_ServerInfo,
    11,
    &IMS2DProcessAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMS2DProcessParameters, ver. 0.0,
   GUID={0x9FAD2A0A,0x2208,0x4F26,{0xAB,0xF7,0x01,0xCE,0xFE,0x67,0xB7,0x38}} */

#pragma code_seg(".orpc")
static const unsigned short IMS2DProcessParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    630,
    756
    };

static const MIDL_STUBLESS_PROXY_INFO IMS2DProcessParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMS2DProcessParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMS2DProcessParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMS2DProcessParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IMS2DProcessParametersProxyVtbl = 
{
    &IMS2DProcessParameters_ProxyInfo,
    &IID_IMS2DProcessParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IComputationParameters::GetFunction */ ,
    (void *) (INT_PTR) -1 /* IMS2DProcessParameters::GetFactor */
};


static const PRPC_STUB_FUNCTION IMS2DProcessParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMS2DProcessParametersStubVtbl =
{
    &IID_IMS2DProcessParameters,
    &IMS2DProcessParameters_ServerInfo,
    9,
    &IMS2DProcessParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMSCreationProcess, ver. 0.0,
   GUID={0x03982D3C,0xF495,0x4B48,{0xAD,0x40,0x9E,0x14,0xC6,0xB3,0x43,0x87}} */

#pragma code_seg(".orpc")
static const unsigned short IMSCreationProcess_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    1722
    };

static const MIDL_STUBLESS_PROXY_INFO IMSCreationProcess_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMSCreationProcess_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMSCreationProcess_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMSCreationProcess_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IMSCreationProcessProxyVtbl = 
{
    &IMSCreationProcess_ProxyInfo,
    &IID_IMSCreationProcess,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IAction::SetActionParameters */ ,
    (void *) (INT_PTR) -1 /* IAction::SetProgressBarInfo */ ,
    (void *) (INT_PTR) -1 /* IAction::CanDo */ ,
    (void *) (INT_PTR) -1 /* IAction::Do */ ,
    (void *) (INT_PTR) -1 /* IMSCreationProcess::GetDimension */
};


static const PRPC_STUB_FUNCTION IMSCreationProcess_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMSCreationProcessStubVtbl =
{
    &IID_IMSCreationProcess,
    &IMSCreationProcess_ServerInfo,
    12,
    &IMSCreationProcess_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMSCreationParameters, ver. 0.0,
   GUID={0xFF53DE10,0x042E,0x4444,{0x9D,0x72,0x81,0xFB,0x51,0x20,0xDF,0x2B}} */

#pragma code_seg(".orpc")
static const unsigned short IMSCreationParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1854
    };

static const MIDL_STUBLESS_PROXY_INFO IMSCreationParameters_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMSCreationParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMSCreationParameters_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMSCreationParameters_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IMSCreationParametersProxyVtbl = 
{
    &IMSCreationParameters_ProxyInfo,
    &IID_IMSCreationParameters,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IMSCreationParameters::GetFactor */
};


static const PRPC_STUB_FUNCTION IMSCreationParameters_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IMSCreationParametersStubVtbl =
{
    &IID_IMSCreationParameters,
    &IMSCreationParameters_ServerInfo,
    8,
    &IMSCreationParameters_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IDummy4, ver. 0.0,
   GUID={0x4D810CEE,0x9913,0x438E,{0x98,0x83,0xBC,0x05,0x53,0x71,0xB1,0x74}} */

#pragma code_seg(".orpc")
static const unsigned short IDummy4_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IDummy4_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IDummy4_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IDummy4_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IDummy4_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IDummy4ProxyVtbl = 
{
    0,
    &IID_IDummy4,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IDummy4_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IDummy4StubVtbl =
{
    &IID_IDummy4,
    &IDummy4_ServerInfo,
    7,
    &IDummy4_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IWritableFunction, ver. 0.0,
   GUID={0x9B3DA2D8,0xE279,0x4552,{0x99,0xF4,0x13,0xAA,0x06,0x66,0x42,0xD5}} */

#pragma code_seg(".orpc")
static const unsigned short IWritableFunction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1578,
    2046
    };

static const MIDL_STUBLESS_PROXY_INFO IWritableFunction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IWritableFunction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IWritableFunction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IWritableFunction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IWritableFunctionProxyVtbl = 
{
    &IWritableFunction_ProxyInfo,
    &IID_IWritableFunction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IWritableFunction::SetEquations */ ,
    (void *) (INT_PTR) -1 /* IWritableFunction::GetLastError */
};


static const PRPC_STUB_FUNCTION IWritableFunction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IWritableFunctionStubVtbl =
{
    &IID_IWritableFunction,
    &IWritableFunction_ServerInfo,
    9,
    &IWritableFunction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IWritableGraphInfo, ver. 0.0,
   GUID={0x5F89F9F3,0xAB8D,0x4129,{0xA7,0x52,0x8A,0x42,0x58,0xA8,0xEC,0xE9}} */


/* Object interface: IGraphInfoImpl, ver. 0.0,
   GUID={0xE8AC201A,0x48EE,0x4CC4,{0xA7,0xD3,0xD0,0x75,0xC3,0x01,0x61,0x04}} */

#pragma code_seg(".orpc")
static const unsigned short IGraphInfoImpl_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IGraphInfoImpl_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IGraphInfoImpl_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IGraphInfoImpl_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IGraphInfoImpl_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IGraphInfoImplProxyVtbl = 
{
    0,
    &IID_IGraphInfoImpl,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IGraphInfoImpl_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IGraphInfoImplStubVtbl =
{
    &IID_IGraphInfoImpl,
    &IGraphInfoImpl_ServerInfo,
    7,
    &IGraphInfoImpl_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IKernell, ver. 0.0,
   GUID={0xF2D78B39,0xD782,0x49DE,{0x91,0xB7,0x77,0x1C,0xDA,0x2E,0xD0,0xE0}} */

#pragma code_seg(".orpc")
static const unsigned short IKernell_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    2082,
    2118
    };

static const MIDL_STUBLESS_PROXY_INFO IKernell_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IKernell_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IKernell_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IKernell_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IKernellProxyVtbl = 
{
    &IKernell_ProxyInfo,
    &IID_IKernell,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IKernell::GetFunction */ ,
    (void *) (INT_PTR) -1 /* IKernell::CreateInitialResultSet */
};


static const PRPC_STUB_FUNCTION IKernell_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IKernellStubVtbl =
{
    &IID_IKernell,
    &IKernell_ServerInfo,
    9,
    &IKernell_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IWritableKernell, ver. 0.0,
   GUID={0xDB255DC6,0x645A,0x4D60,{0xA7,0xC6,0x5D,0x30,0x19,0xC2,0xDB,0xB7}} */

#pragma code_seg(".orpc")
static const unsigned short IWritableKernell_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    2154
    };

static const MIDL_STUBLESS_PROXY_INFO IWritableKernell_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IWritableKernell_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IWritableKernell_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IWritableKernell_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IWritableKernellProxyVtbl = 
{
    &IWritableKernell_ProxyInfo,
    &IID_IWritableKernell,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IWritableKernell::SetFunction */
};


static const PRPC_STUB_FUNCTION IWritableKernell_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IWritableKernellStubVtbl =
{
    &IID_IWritableKernell,
    &IWritableKernell_ServerInfo,
    8,
    &IWritableKernell_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IKernellImpl, ver. 0.0,
   GUID={0x0667C597,0x8C23,0x4B74,{0xA2,0x98,0x82,0x1D,0xB5,0x94,0xED,0x01}} */

#pragma code_seg(".orpc")
static const unsigned short IKernellImpl_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    2154,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IKernellImpl_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IKernellImpl_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IKernellImpl_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IKernellImpl_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IKernellImplProxyVtbl = 
{
    0,
    &IID_IKernellImpl,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IWritableKernell::SetFunction */
};


static const PRPC_STUB_FUNCTION IKernellImpl_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IKernellImplStubVtbl =
{
    &IID_IKernellImpl,
    &IKernellImpl_ServerInfo,
    8,
    &IKernellImpl_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ILoopsLocalizationAction, ver. 0.0,
   GUID={0x7EC2A3FE,0xE845,0x4FAC,{0x9E,0x24,0x8A,0x51,0x01,0xC2,0xE9,0x22}} */

#pragma code_seg(".orpc")
static const unsigned short ILoopsLocalizationAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO ILoopsLocalizationAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ILoopsLocalizationAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ILoopsLocalizationAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ILoopsLocalizationAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _ILoopsLocalizationActionProxyVtbl = 
{
    0,
    &IID_ILoopsLocalizationAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IAction::SetActionParameters */ ,
    0 /* forced delegation IAction::SetProgressBarInfo */ ,
    0 /* forced delegation IAction::CanDo */ ,
    0 /* forced delegation IAction::Do */
};


static const PRPC_STUB_FUNCTION ILoopsLocalizationAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ILoopsLocalizationActionStubVtbl =
{
    &IID_ILoopsLocalizationAction,
    &ILoopsLocalizationAction_ServerInfo,
    11,
    &ILoopsLocalizationAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMSMetadata, ver. 0.0,
   GUID={0x9FC179BA,0x4641,0x46FF,{0x8F,0x8B,0xD2,0x77,0xC1,0x03,0x59,0x64}} */

#pragma code_seg(".orpc")
static const unsigned short IMSMetadata_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    840,
    882,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IMSMetadata_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMSMetadata_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMSMetadata_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMSMetadata_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IMSMetadataProxyVtbl = 
{
    0,
    &IID_IMSMetadata,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IResultMetadata::EqualType */ ,
    0 /* forced delegation IResultMetadata::Clone */
};


static const PRPC_STUB_FUNCTION IMSMetadata_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMSMetadataStubVtbl =
{
    &IID_IMSMetadata,
    &IMSMetadata_ServerInfo,
    9,
    &IMSMetadata_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMS2Metadata, ver. 0.0,
   GUID={0x5E5AEEE1,0xA73F,0x43C7,{0x91,0xA6,0x35,0x24,0x91,0x71,0xD3,0xC4}} */

#pragma code_seg(".orpc")
static const unsigned short IMS2Metadata_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    840,
    882,
    2190,
    2226,
    2262
    };

static const MIDL_STUBLESS_PROXY_INFO IMS2Metadata_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMS2Metadata_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMS2Metadata_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMS2Metadata_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IMS2MetadataProxyVtbl = 
{
    &IMS2Metadata_ProxyInfo,
    &IID_IMS2Metadata,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IResultMetadata::EqualType */ ,
    (void *) (INT_PTR) -1 /* IResultMetadata::Clone */ ,
    (void *) (INT_PTR) -1 /* IMS2Metadata::GetSIGraphResult */ ,
    (void *) (INT_PTR) -1 /* IMS2Metadata::SetSIGraphResult */ ,
    (void *) (INT_PTR) -1 /* IMS2Metadata::HasSIGraphResult */
};


static const PRPC_STUB_FUNCTION IMS2Metadata_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMS2MetadataStubVtbl =
{
    &IID_IMS2Metadata,
    &IMS2Metadata_ServerInfo,
    12,
    &IMS2Metadata_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMS2DRomAction, ver. 0.0,
   GUID={0x27633F37,0x3573,0x46D6,{0xB4,0x5D,0x78,0xAE,0x25,0x61,0x6D,0xAD}} */

#pragma code_seg(".orpc")
static const unsigned short IMS2DRomAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IMS2DRomAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMS2DRomAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMS2DRomAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMS2DRomAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _IMS2DRomActionProxyVtbl = 
{
    0,
    &IID_IMS2DRomAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IAction::SetActionParameters */ ,
    0 /* forced delegation IAction::SetProgressBarInfo */ ,
    0 /* forced delegation IAction::CanDo */ ,
    0 /* forced delegation IAction::Do */
};


static const PRPC_STUB_FUNCTION IMS2DRomAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMS2DRomActionStubVtbl =
{
    &IID_IMS2DRomAction,
    &IMS2DRomAction_ServerInfo,
    11,
    &IMS2DRomAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IWritableSpectrumResult, ver. 0.0,
   GUID={0x80B6D423,0x1E6D,0x4236,{0xB1,0x87,0xFF,0xDE,0xC3,0xA2,0xA1,0x39}} */

#pragma code_seg(".orpc")
static const unsigned short IWritableSpectrumResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    2298,
    2334,
    2370,
    2406,
    2442
    };

static const MIDL_STUBLESS_PROXY_INFO IWritableSpectrumResult_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IWritableSpectrumResult_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IWritableSpectrumResult_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IWritableSpectrumResult_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IWritableSpectrumResultProxyVtbl = 
{
    &IWritableSpectrumResult_ProxyInfo,
    &IID_IWritableSpectrumResult,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IWritableSpectrumResult::SetLowerBound */ ,
    (void *) (INT_PTR) -1 /* IWritableSpectrumResult::SetUpperBound */ ,
    (void *) (INT_PTR) -1 /* IWritableSpectrumResult::SetLowerLength */ ,
    (void *) (INT_PTR) -1 /* IWritableSpectrumResult::SetUpperLength */ ,
    (void *) (INT_PTR) -1 /* IWritableSpectrumResult::SetMetadata */
};


static const PRPC_STUB_FUNCTION IWritableSpectrumResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IWritableSpectrumResultStubVtbl =
{
    &IID_IWritableSpectrumResult,
    &IWritableSpectrumResult_ServerInfo,
    12,
    &IWritableSpectrumResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMSSegmentMetadata, ver. 0.0,
   GUID={0xEC1007B0,0xEB8F,0x4234,{0x85,0xD1,0x31,0x51,0x8B,0xBB,0xEE,0x58}} */

#pragma code_seg(".orpc")
static const unsigned short IMSSegmentMetadata_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    840,
    882,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IMSSegmentMetadata_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMSSegmentMetadata_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMSSegmentMetadata_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMSSegmentMetadata_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IMSSegmentMetadataProxyVtbl = 
{
    0,
    &IID_IMSSegmentMetadata,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IResultMetadata::EqualType */ ,
    0 /* forced delegation IResultMetadata::Clone */
};


static const PRPC_STUB_FUNCTION IMSSegmentMetadata_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMSSegmentMetadataStubVtbl =
{
    &IID_IMSSegmentMetadata,
    &IMSSegmentMetadata_ServerInfo,
    9,
    &IMSSegmentMetadata_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMSMethodAction, ver. 0.0,
   GUID={0x729D2ADA,0x2C8A,0x453F,{0x97,0xFB,0x2A,0x3F,0x64,0x09,0xB1,0x17}} */

#pragma code_seg(".orpc")
static const unsigned short IMSMethodAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    1722,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IMSMethodAction_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMSMethodAction_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMSMethodAction_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMSMethodAction_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IMSMethodActionProxyVtbl = 
{
    0,
    &IID_IMSMethodAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IAction::SetActionParameters */ ,
    0 /* forced delegation IAction::SetProgressBarInfo */ ,
    0 /* forced delegation IAction::CanDo */ ,
    0 /* forced delegation IAction::Do */ ,
    0 /* forced delegation IPointMethodAction::GetDimensionForParameters */
};


static const PRPC_STUB_FUNCTION IMSMethodAction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMSMethodActionStubVtbl =
{
    &IID_IMSMethodAction,
    &IMSMethodAction_ServerInfo,
    12,
    &IMSMethodAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMSSegmentRom, ver. 0.0,
   GUID={0xA5FEE589,0x2AE6,0x4F6F,{0x83,0x27,0xE5,0x31,0xD2,0x26,0x9F,0x50}} */

#pragma code_seg(".orpc")
static const unsigned short IMSSegmentRom_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    204,
    240,
    276,
    318,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IMSSegmentRom_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMSSegmentRom_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMSSegmentRom_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMSSegmentRom_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _IMSSegmentRomProxyVtbl = 
{
    0,
    &IID_IMSSegmentRom,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IAction::SetActionParameters */ ,
    0 /* forced delegation IAction::SetProgressBarInfo */ ,
    0 /* forced delegation IAction::CanDo */ ,
    0 /* forced delegation IAction::Do */
};


static const PRPC_STUB_FUNCTION IMSSegmentRom_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMSSegmentRomStubVtbl =
{
    &IID_IMSSegmentRom,
    &IMSSegmentRom_ServerInfo,
    11,
    &IMSSegmentRom_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};

static const MIDL_STUB_DESC Object_StubDesc = 
    {
    0,
    NdrOleAllocate,
    NdrOleFree,
    0,
    0,
    0,
    0,
    0,
    __MIDL_TypeFormatString.Format,
    1, /* -error bounds_check flag */
    0x50002, /* Ndr library version */
    0,
    0x6000169, /* MIDL Version 6.0.361 */
    0,
    UserMarshalRoutines,
    0,  /* notify & notify_flag routine table */
    0x1, /* MIDL flag */
    0, /* cs routines */
    0,   /* proxy/server info */
    0   /* Reserved5 */
    };

const CInterfaceProxyVtbl * __MorseKernel2_ProxyVtblList[] = 
{
    ( CInterfaceProxyVtbl *) &_IMinimalLoopLocalizationParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMS2DProcessParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IDummy3ProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMSCreationParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphInfoImplProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISpectrumMetadataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableSpectrumResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IBoxMethodActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IDummy2ProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMS2DRomActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernellProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultSetProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMSCreationProcessProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ITarjanParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISpectrumResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMinimalLoopLocalizationActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IAdaptiveBoxParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IDummyProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISymbolicImageMetadataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMS2DCreationParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultSetImplProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMSSegmentRomProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IIsolatedSetActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernellImplProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProjectActionParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComponentRegistrarProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ITarjanActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableResultSetProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IIsolatedSetParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMSSegmentMetadataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphResultImplProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMSMetadataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IPointMethodParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISIRomActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableKernellProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableFunctionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMSMethodActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMS2DProcessActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProjectActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionBaseProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMS2MetadataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProgressBarInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IFunctionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IAdaptiveMethodActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IBoxMethodParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISIRomActionParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IAdaptiveBoxMethodProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IDummy1ProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IDummy4ProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IAdaptiveMethodParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IPointMethodActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultBaseProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMS2DCreationActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ILoopsLocalizationActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultMetadataProxyVtbl,
    0
};

const CInterfaceStubVtbl * __MorseKernel2_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_IMinimalLoopLocalizationParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IMS2DProcessParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IDummy3StubVtbl,
    ( CInterfaceStubVtbl *) &_IMSCreationParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphInfoImplStubVtbl,
    ( CInterfaceStubVtbl *) &_ISpectrumMetadataStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableSpectrumResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IBoxMethodActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IDummy2StubVtbl,
    ( CInterfaceStubVtbl *) &_IMS2DRomActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernellStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultSetStubVtbl,
    ( CInterfaceStubVtbl *) &_IMSCreationProcessStubVtbl,
    ( CInterfaceStubVtbl *) &_ITarjanParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_ISpectrumResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IMinimalLoopLocalizationActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IAdaptiveBoxParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IDummyStubVtbl,
    ( CInterfaceStubVtbl *) &_ISymbolicImageMetadataStubVtbl,
    ( CInterfaceStubVtbl *) &_IMS2DCreationParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultSetImplStubVtbl,
    ( CInterfaceStubVtbl *) &_IMSSegmentRomStubVtbl,
    ( CInterfaceStubVtbl *) &_IIsolatedSetActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernellImplStubVtbl,
    ( CInterfaceStubVtbl *) &_IProjectActionParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IComponentRegistrarStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultStubVtbl,
    ( CInterfaceStubVtbl *) &_ITarjanActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableResultSetStubVtbl,
    ( CInterfaceStubVtbl *) &_IIsolatedSetParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IMSSegmentMetadataStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphResultImplStubVtbl,
    ( CInterfaceStubVtbl *) &_IMSMetadataStubVtbl,
    ( CInterfaceStubVtbl *) &_IPointMethodParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_ISIRomActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableKernellStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableFunctionStubVtbl,
    ( CInterfaceStubVtbl *) &_IMSMethodActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IMS2DProcessActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IProjectActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionBaseStubVtbl,
    ( CInterfaceStubVtbl *) &_IMS2MetadataStubVtbl,
    ( CInterfaceStubVtbl *) &_IProgressBarInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IFunctionStubVtbl,
    ( CInterfaceStubVtbl *) &_IAdaptiveMethodActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IBoxMethodParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_ISIRomActionParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IAdaptiveBoxMethodStubVtbl,
    ( CInterfaceStubVtbl *) &_IDummy1StubVtbl,
    ( CInterfaceStubVtbl *) &_IDummy4StubVtbl,
    ( CInterfaceStubVtbl *) &_IAdaptiveMethodParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IPointMethodActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultBaseStubVtbl,
    ( CInterfaceStubVtbl *) &_IMS2DCreationActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_ILoopsLocalizationActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultMetadataStubVtbl,
    0
};

PCInterfaceName const __MorseKernel2_InterfaceNamesList[] = 
{
    "IMinimalLoopLocalizationParameters",
    "IMS2DProcessParameters",
    "IDummy3",
    "IMSCreationParameters",
    "IGraphInfoImpl",
    "ISpectrumMetadata",
    "IWritableSpectrumResult",
    "IBoxMethodAction",
    "IDummy2",
    "IMS2DRomAction",
    "IKernell",
    "IResultSet",
    "IMSCreationProcess",
    "ITarjanParameters",
    "ISpectrumResult",
    "IMinimalLoopLocalizationAction",
    "IAdaptiveBoxParameters",
    "IDummy",
    "ISymbolicImageMetadata",
    "IMS2DCreationParameters",
    "IGraphInfo",
    "IGraphResult",
    "IParameters",
    "IResultSetImpl",
    "IMSSegmentRom",
    "IIsolatedSetAction",
    "IKernellImpl",
    "IProjectActionParameters",
    "IComponentRegistrar",
    "IResult",
    "ITarjanAction",
    "IWritableResultSet",
    "IIsolatedSetParameters",
    "IMSSegmentMetadata",
    "IGraphResultImpl",
    "IMSMetadata",
    "IPointMethodParameters",
    "ISIRomAction",
    "IWritableKernell",
    "IAction",
    "IWritableFunction",
    "IMSMethodAction",
    "IMS2DProcessAction",
    "IProjectAction",
    "IActionBase",
    "IMS2Metadata",
    "IProgressBarInfo",
    "IFunction",
    "IAdaptiveMethodAction",
    "IResultInfo",
    "IBoxMethodParameters",
    "ISIRomActionParameters",
    "IWritableGraphResult",
    "IAdaptiveBoxMethod",
    "IDummy1",
    "IDummy4",
    "IAdaptiveMethodParameters",
    "IPointMethodAction",
    "IResultBase",
    "IMS2DCreationAction",
    "IComputationParameters",
    "ILoopsLocalizationAction",
    "IResultMetadata",
    0
};

const IID *  __MorseKernel2_BaseIIDList[] = 
{
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    0
};


#define __MorseKernel2_CHECK_IID(n)	IID_GENERIC_CHECK_IID( __MorseKernel2, pIID, n)

int __stdcall __MorseKernel2_IID_Lookup( const IID * pIID, int * pIndex )
{
    IID_BS_LOOKUP_SETUP

    IID_BS_LOOKUP_INITIAL_TEST( __MorseKernel2, 63, 32 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 16 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 8 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 4 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 2 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( __MorseKernel2, 63, *pIndex )
    
}

const ExtendedProxyFileInfo _MorseKernel2_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & __MorseKernel2_ProxyVtblList,
    (PCInterfaceStubVtblList *) & __MorseKernel2_StubVtblList,
    (const PCInterfaceName * ) & __MorseKernel2_InterfaceNamesList,
    (const IID ** ) & __MorseKernel2_BaseIIDList,
    & __MorseKernel2_IID_Lookup, 
    63,
    2,
    0, /* table of [async_uuid] interfaces */
    0, /* Filler1 */
    0, /* Filler2 */
    0  /* Filler3 */
};
#if _MSC_VER >= 1200
#pragma warning(pop)
#endif


#endif /* !defined(_M_IA64) && !defined(_M_AMD64)*/

