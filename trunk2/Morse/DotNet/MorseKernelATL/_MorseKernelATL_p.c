

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Thu Feb 24 21:35:19 2005
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


#include "_MorseKernelATL.h"

#define TYPE_FORMAT_STRING_SIZE   1425                              
#define PROC_FORMAT_STRING_SIZE   2227                              
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


extern const MIDL_SERVER_INFO IGraphInfo_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphInfo_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IProgressBarNotification_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IProgressBarNotification_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IParams_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IParams_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISubdevideParams_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISubdevideParams_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IExtendableParams_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IExtendableParams_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IExtendablePointParams_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IExtendablePointParams_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISubdevidePointParams_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISubdevidePointParams_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISubdevidableOverlapedPointParams_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISubdevidableOverlapedPointParams_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IHomotopParams_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IHomotopParams_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernelPointer_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernelPointer_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernelNode_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernelNode_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraph_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraph_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISubdevidable_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISubdevidable_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISubdevidablePoint_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISubdevidablePoint_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IExtendable_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IExtendable_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMorsable_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMorsable_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IExportData_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IExportData_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IHomotopFind_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IHomotopFind_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComputationResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComputationResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComputationGraphResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComputationGraphResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComputationExtendingResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComputationExtendingResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComputationMorseResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComputationMorseResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGroupNode_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGroupNode_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComponentRegistrar_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComponentRegistrar_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IFunctionEvents_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IFunctionEvents_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IFunction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IFunction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernel_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernel_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComputationGraphResultExt_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComputationGraphResultExt_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMorseSpectrum_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMorseSpectrum_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IProjectiveBundle_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IProjectiveBundle_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISymbolicImage_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISymbolicImage_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISymbolicImageGraph_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISymbolicImageGraph_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISymbolicImageGroup_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISymbolicImageGroup_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IProjectiveBundleGraph_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IProjectiveBundleGraph_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IProjectiveBundleGroup_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IProjectiveBundleGroup_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISerializerOutputData_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISerializerOutputData_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISerializerInputData_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISerializerInputData_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISerializer_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISerializer_ProxyInfo;


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

	/* Procedure nodeCount */


	/* Procedure Length */


	/* Procedure dimension */

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

	/* Parameter val */


	/* Parameter length */


	/* Parameter dimension */

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

	/* Procedure getCellDevider */


	/* Procedure gridNumber */

/* 36 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 38 */	NdrFcLong( 0x0 ),	/* 0 */
/* 42 */	NdrFcShort( 0x8 ),	/* 8 */
/* 44 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 46 */	NdrFcShort( 0x8 ),	/* 8 */
/* 48 */	NdrFcShort( 0x24 ),	/* 36 */
/* 50 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 52 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 54 */	NdrFcShort( 0x0 ),	/* 0 */
/* 56 */	NdrFcShort( 0x0 ),	/* 0 */
/* 58 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter axis */


	/* Parameter id */

/* 60 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 62 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 64 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */


	/* Parameter grid */

/* 66 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 68 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 70 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 72 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 74 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 76 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure gridSize */

/* 78 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 80 */	NdrFcLong( 0x0 ),	/* 0 */
/* 84 */	NdrFcShort( 0x9 ),	/* 9 */
/* 86 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 88 */	NdrFcShort( 0x8 ),	/* 8 */
/* 90 */	NdrFcShort( 0x2c ),	/* 44 */
/* 92 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 94 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 96 */	NdrFcShort( 0x0 ),	/* 0 */
/* 98 */	NdrFcShort( 0x0 ),	/* 0 */
/* 100 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter id */

/* 102 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 104 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 106 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter size */

/* 108 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 110 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 112 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 114 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 116 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 118 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure getOverlaping1 */


	/* Procedure spaceMin */

/* 120 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 122 */	NdrFcLong( 0x0 ),	/* 0 */
/* 126 */	NdrFcShort( 0xa ),	/* 10 */
/* 128 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 130 */	NdrFcShort( 0x8 ),	/* 8 */
/* 132 */	NdrFcShort( 0x2c ),	/* 44 */
/* 134 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 136 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 138 */	NdrFcShort( 0x0 ),	/* 0 */
/* 140 */	NdrFcShort( 0x0 ),	/* 0 */
/* 142 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter axis */


	/* Parameter id */

/* 144 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 146 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 148 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter percent */


	/* Parameter size */

/* 150 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 152 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 154 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 156 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 158 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 160 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure getOverlaping2 */


	/* Procedure spaceMax */

/* 162 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 164 */	NdrFcLong( 0x0 ),	/* 0 */
/* 168 */	NdrFcShort( 0xb ),	/* 11 */
/* 170 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 172 */	NdrFcShort( 0x8 ),	/* 8 */
/* 174 */	NdrFcShort( 0x2c ),	/* 44 */
/* 176 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 178 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 180 */	NdrFcShort( 0x0 ),	/* 0 */
/* 182 */	NdrFcShort( 0x0 ),	/* 0 */
/* 184 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter axis */


	/* Parameter id */

/* 186 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 188 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 190 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter percent */


	/* Parameter size */

/* 192 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 194 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 196 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 198 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 200 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 202 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure edges */

/* 204 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 206 */	NdrFcLong( 0x0 ),	/* 0 */
/* 210 */	NdrFcShort( 0xc ),	/* 12 */
/* 212 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 214 */	NdrFcShort( 0x0 ),	/* 0 */
/* 216 */	NdrFcShort( 0x24 ),	/* 36 */
/* 218 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 220 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 222 */	NdrFcShort( 0x0 ),	/* 0 */
/* 224 */	NdrFcShort( 0x0 ),	/* 0 */
/* 226 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter num */

/* 228 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 230 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 232 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 234 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 236 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 238 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_lowerLength */


	/* Procedure nodes */

/* 240 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 242 */	NdrFcLong( 0x0 ),	/* 0 */
/* 246 */	NdrFcShort( 0xd ),	/* 13 */
/* 248 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 250 */	NdrFcShort( 0x0 ),	/* 0 */
/* 252 */	NdrFcShort( 0x24 ),	/* 36 */
/* 254 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 256 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 258 */	NdrFcShort( 0x0 ),	/* 0 */
/* 260 */	NdrFcShort( 0x0 ),	/* 0 */
/* 262 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */


	/* Parameter num */

/* 264 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 266 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 268 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 270 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 272 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 274 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Next */

/* 276 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 278 */	NdrFcLong( 0x0 ),	/* 0 */
/* 282 */	NdrFcShort( 0x8 ),	/* 8 */
/* 284 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 286 */	NdrFcShort( 0x8 ),	/* 8 */
/* 288 */	NdrFcShort( 0x8 ),	/* 8 */
/* 290 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 292 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 294 */	NdrFcShort( 0x0 ),	/* 0 */
/* 296 */	NdrFcShort( 0x0 ),	/* 0 */
/* 298 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nSteps */

/* 300 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 302 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 304 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 306 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 308 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 310 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure notifyNodeNotFound */


	/* Procedure NeedStop */

/* 312 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 314 */	NdrFcLong( 0x0 ),	/* 0 */
/* 318 */	NdrFcShort( 0x9 ),	/* 9 */
/* 320 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 322 */	NdrFcShort( 0x0 ),	/* 0 */
/* 324 */	NdrFcShort( 0x22 ),	/* 34 */
/* 326 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 328 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 330 */	NdrFcShort( 0x0 ),	/* 0 */
/* 332 */	NdrFcShort( 0x0 ),	/* 0 */
/* 334 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter tryAgain */


	/* Parameter stop */

/* 336 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 338 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 340 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 342 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 344 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 346 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure DoNothing */


	/* Procedure Start */

/* 348 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 350 */	NdrFcLong( 0x0 ),	/* 0 */
/* 354 */	NdrFcShort( 0xa ),	/* 10 */
/* 356 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 358 */	NdrFcShort( 0x0 ),	/* 0 */
/* 360 */	NdrFcShort( 0x8 ),	/* 8 */
/* 362 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 364 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 366 */	NdrFcShort( 0x0 ),	/* 0 */
/* 368 */	NdrFcShort( 0x0 ),	/* 0 */
/* 370 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */


	/* Return value */

/* 372 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 374 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 376 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Finish */

/* 378 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 380 */	NdrFcLong( 0x0 ),	/* 0 */
/* 384 */	NdrFcShort( 0xb ),	/* 11 */
/* 386 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 388 */	NdrFcShort( 0x0 ),	/* 0 */
/* 390 */	NdrFcShort( 0x8 ),	/* 8 */
/* 392 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 394 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 396 */	NdrFcShort( 0x0 ),	/* 0 */
/* 398 */	NdrFcShort( 0x0 ),	/* 0 */
/* 400 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 402 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 404 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 406 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetProgressBarNotification */

/* 408 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 410 */	NdrFcLong( 0x0 ),	/* 0 */
/* 414 */	NdrFcShort( 0x7 ),	/* 7 */
/* 416 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 418 */	NdrFcShort( 0x0 ),	/* 0 */
/* 420 */	NdrFcShort( 0x8 ),	/* 8 */
/* 422 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 424 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 426 */	NdrFcShort( 0x0 ),	/* 0 */
/* 428 */	NdrFcShort( 0x0 ),	/* 0 */
/* 430 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter notify */

/* 432 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 434 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 436 */	NdrFcShort( 0xe ),	/* Type Offset=14 */

	/* Return value */

/* 438 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 440 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 442 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure getCellPoints */

/* 444 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 446 */	NdrFcLong( 0x0 ),	/* 0 */
/* 450 */	NdrFcShort( 0x9 ),	/* 9 */
/* 452 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 454 */	NdrFcShort( 0x8 ),	/* 8 */
/* 456 */	NdrFcShort( 0x24 ),	/* 36 */
/* 458 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 460 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 462 */	NdrFcShort( 0x0 ),	/* 0 */
/* 464 */	NdrFcShort( 0x0 ),	/* 0 */
/* 466 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter axis */

/* 468 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 470 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 472 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 474 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 476 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 478 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 480 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 482 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 484 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure getCoordinateAt */

/* 486 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 488 */	NdrFcLong( 0x0 ),	/* 0 */
/* 492 */	NdrFcShort( 0x8 ),	/* 8 */
/* 494 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 496 */	NdrFcShort( 0x8 ),	/* 8 */
/* 498 */	NdrFcShort( 0x2c ),	/* 44 */
/* 500 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 502 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 504 */	NdrFcShort( 0x0 ),	/* 0 */
/* 506 */	NdrFcShort( 0x0 ),	/* 0 */
/* 508 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter axis */

/* 510 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 512 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 514 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 516 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 518 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 520 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 522 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 524 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 526 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_kernel */

/* 528 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 530 */	NdrFcLong( 0x0 ),	/* 0 */
/* 534 */	NdrFcShort( 0x7 ),	/* 7 */
/* 536 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 538 */	NdrFcShort( 0x0 ),	/* 0 */
/* 540 */	NdrFcShort( 0x8 ),	/* 8 */
/* 542 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 544 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 546 */	NdrFcShort( 0x0 ),	/* 0 */
/* 548 */	NdrFcShort( 0x0 ),	/* 0 */
/* 550 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 552 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 554 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 556 */	NdrFcShort( 0x24 ),	/* Type Offset=36 */

	/* Return value */

/* 558 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 560 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 562 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure putref_kernel */

/* 564 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 566 */	NdrFcLong( 0x0 ),	/* 0 */
/* 570 */	NdrFcShort( 0x8 ),	/* 8 */
/* 572 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 574 */	NdrFcShort( 0x0 ),	/* 0 */
/* 576 */	NdrFcShort( 0x8 ),	/* 8 */
/* 578 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 580 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 582 */	NdrFcShort( 0x0 ),	/* 0 */
/* 584 */	NdrFcShort( 0x0 ),	/* 0 */
/* 586 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 588 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 590 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 592 */	NdrFcShort( 0x28 ),	/* Type Offset=40 */

	/* Return value */

/* 594 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 596 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 598 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure graphDimension */

/* 600 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 602 */	NdrFcLong( 0x0 ),	/* 0 */
/* 606 */	NdrFcShort( 0x9 ),	/* 9 */
/* 608 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 610 */	NdrFcShort( 0x0 ),	/* 0 */
/* 612 */	NdrFcShort( 0x24 ),	/* 36 */
/* 614 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 616 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 618 */	NdrFcShort( 0x0 ),	/* 0 */
/* 620 */	NdrFcShort( 0x0 ),	/* 0 */
/* 622 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 624 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 626 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 628 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 630 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 632 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 634 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure graphInfo */

/* 636 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 638 */	NdrFcLong( 0x0 ),	/* 0 */
/* 642 */	NdrFcShort( 0xa ),	/* 10 */
/* 644 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 646 */	NdrFcShort( 0x0 ),	/* 0 */
/* 648 */	NdrFcShort( 0x8 ),	/* 8 */
/* 650 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 652 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 654 */	NdrFcShort( 0x0 ),	/* 0 */
/* 656 */	NdrFcShort( 0x0 ),	/* 0 */
/* 658 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter info */

/* 660 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 662 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 664 */	NdrFcShort( 0x3a ),	/* Type Offset=58 */

	/* Return value */

/* 666 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 668 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 670 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Subdevide */

/* 672 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 674 */	NdrFcLong( 0x0 ),	/* 0 */
/* 678 */	NdrFcShort( 0x7 ),	/* 7 */
/* 680 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 682 */	NdrFcShort( 0x0 ),	/* 0 */
/* 684 */	NdrFcShort( 0x8 ),	/* 8 */
/* 686 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 688 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 690 */	NdrFcShort( 0x0 ),	/* 0 */
/* 692 */	NdrFcShort( 0x0 ),	/* 0 */
/* 694 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter params */

/* 696 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 698 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 700 */	NdrFcShort( 0x50 ),	/* Type Offset=80 */

	/* Return value */

/* 702 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 704 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 706 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SubdevidePoint */

/* 708 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 710 */	NdrFcLong( 0x0 ),	/* 0 */
/* 714 */	NdrFcShort( 0x7 ),	/* 7 */
/* 716 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 718 */	NdrFcShort( 0x0 ),	/* 0 */
/* 720 */	NdrFcShort( 0x8 ),	/* 8 */
/* 722 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 724 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 726 */	NdrFcShort( 0x0 ),	/* 0 */
/* 728 */	NdrFcShort( 0x0 ),	/* 0 */
/* 730 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter params */

/* 732 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 734 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 736 */	NdrFcShort( 0x62 ),	/* Type Offset=98 */

	/* Return value */

/* 738 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 740 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 742 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure toResult */


	/* Procedure StrongComponents */


	/* Procedure Extend */

/* 744 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 746 */	NdrFcLong( 0x0 ),	/* 0 */
/* 750 */	NdrFcShort( 0x7 ),	/* 7 */
/* 752 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 754 */	NdrFcShort( 0x0 ),	/* 0 */
/* 756 */	NdrFcShort( 0x8 ),	/* 8 */
/* 758 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 760 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 762 */	NdrFcShort( 0x0 ),	/* 0 */
/* 764 */	NdrFcShort( 0x0 ),	/* 0 */
/* 766 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 768 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 770 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 772 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Morse */

/* 774 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 776 */	NdrFcLong( 0x0 ),	/* 0 */
/* 780 */	NdrFcShort( 0x3 ),	/* 3 */
/* 782 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 784 */	NdrFcShort( 0x0 ),	/* 0 */
/* 786 */	NdrFcShort( 0x8 ),	/* 8 */
/* 788 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 790 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 792 */	NdrFcShort( 0x0 ),	/* 0 */
/* 794 */	NdrFcShort( 0x0 ),	/* 0 */
/* 796 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 798 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 800 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 802 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure FunctionWrongInput */


	/* Procedure Attach */


	/* Procedure ExportData */

/* 804 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 806 */	NdrFcLong( 0x0 ),	/* 0 */
/* 810 */	NdrFcShort( 0x7 ),	/* 7 */
/* 812 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 814 */	NdrFcShort( 0x0 ),	/* 0 */
/* 816 */	NdrFcShort( 0x8 ),	/* 8 */
/* 818 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 820 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 822 */	NdrFcShort( 0x0 ),	/* 0 */
/* 824 */	NdrFcShort( 0x1 ),	/* 1 */
/* 826 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter description */


	/* Parameter bstrPath */


	/* Parameter file */

/* 828 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 830 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 832 */	NdrFcShort( 0x8e ),	/* Type Offset=142 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 834 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 836 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 838 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Homotop */

/* 840 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 842 */	NdrFcLong( 0x0 ),	/* 0 */
/* 846 */	NdrFcShort( 0x7 ),	/* 7 */
/* 848 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 850 */	NdrFcShort( 0x0 ),	/* 0 */
/* 852 */	NdrFcShort( 0x8 ),	/* 8 */
/* 854 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 856 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 858 */	NdrFcShort( 0x0 ),	/* 0 */
/* 860 */	NdrFcShort( 0x0 ),	/* 0 */
/* 862 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter params */

/* 864 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 866 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 868 */	NdrFcShort( 0x98 ),	/* Type Offset=152 */

	/* Return value */

/* 870 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 872 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 874 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterAll */


	/* Procedure StrongComponentsEdges */

/* 876 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 878 */	NdrFcLong( 0x0 ),	/* 0 */
/* 882 */	NdrFcShort( 0x8 ),	/* 8 */
/* 884 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 886 */	NdrFcShort( 0x0 ),	/* 0 */
/* 888 */	NdrFcShort( 0x8 ),	/* 8 */
/* 890 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 892 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 894 */	NdrFcShort( 0x0 ),	/* 0 */
/* 896 */	NdrFcShort( 0x0 ),	/* 0 */
/* 898 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */


	/* Return value */

/* 900 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 902 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 904 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure FunctionAccepted */


	/* Procedure UnregisterAll */


	/* Procedure Loops */

/* 906 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 908 */	NdrFcLong( 0x0 ),	/* 0 */
/* 912 */	NdrFcShort( 0x9 ),	/* 9 */
/* 914 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 916 */	NdrFcShort( 0x0 ),	/* 0 */
/* 918 */	NdrFcShort( 0x8 ),	/* 8 */
/* 920 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 922 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 924 */	NdrFcShort( 0x0 ),	/* 0 */
/* 926 */	NdrFcShort( 0x0 ),	/* 0 */
/* 928 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 930 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 932 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 934 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure PointMethodProjectiveExtension */

/* 936 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 938 */	NdrFcLong( 0x0 ),	/* 0 */
/* 942 */	NdrFcShort( 0x7 ),	/* 7 */
/* 944 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 946 */	NdrFcShort( 0x0 ),	/* 0 */
/* 948 */	NdrFcShort( 0x8 ),	/* 8 */
/* 950 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 952 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 954 */	NdrFcShort( 0x0 ),	/* 0 */
/* 956 */	NdrFcShort( 0x0 ),	/* 0 */
/* 958 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter params */

/* 960 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 962 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 964 */	NdrFcShort( 0xaa ),	/* Type Offset=170 */

	/* Return value */

/* 966 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 968 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 970 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure PointMethodProjectiveExtensionDimension */

/* 972 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 974 */	NdrFcLong( 0x0 ),	/* 0 */
/* 978 */	NdrFcShort( 0x8 ),	/* 8 */
/* 980 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 982 */	NdrFcShort( 0x0 ),	/* 0 */
/* 984 */	NdrFcShort( 0x24 ),	/* 36 */
/* 986 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 988 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 990 */	NdrFcShort( 0x0 ),	/* 0 */
/* 992 */	NdrFcShort( 0x0 ),	/* 0 */
/* 994 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter dim */

/* 996 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 998 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1000 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1002 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1004 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1006 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure getNode */

/* 1008 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1010 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1014 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1016 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1018 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1020 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1022 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 1024 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1026 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1028 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1030 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1032 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1034 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1036 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter node */

/* 1038 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1040 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1042 */	NdrFcShort( 0xbc ),	/* Type Offset=188 */

	/* Return value */

/* 1044 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1046 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1048 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetComponents */

/* 1050 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1052 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1056 */	NdrFcShort( 0xa ),	/* 10 */
/* 1058 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1060 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1062 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1064 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 1066 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 1068 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1070 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1072 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pbstrCLSIDs */

/* 1074 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1076 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1078 */	NdrFcShort( 0x4ca ),	/* Type Offset=1226 */

	/* Parameter pbstrDescriptions */

/* 1080 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1082 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1084 */	NdrFcShort( 0x4ca ),	/* Type Offset=1226 */

	/* Return value */

/* 1086 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1088 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1090 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterComponent */

/* 1092 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1094 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1098 */	NdrFcShort( 0xb ),	/* 11 */
/* 1100 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1102 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1104 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1106 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1108 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1110 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1112 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1114 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 1116 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1118 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1120 */	NdrFcShort( 0x8e ),	/* Type Offset=142 */

	/* Return value */

/* 1122 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1124 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1126 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterComponent */

/* 1128 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1130 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1134 */	NdrFcShort( 0xc ),	/* 12 */
/* 1136 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1138 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1140 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1142 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1144 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1146 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1148 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1150 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 1152 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1154 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1156 */	NdrFcShort( 0x8e ),	/* Type Offset=142 */

	/* Return value */

/* 1158 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1160 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1162 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure FunctionChanged */

/* 1164 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1166 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1170 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1172 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1174 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1176 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1178 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1180 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1182 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1184 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1186 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter oldFunction */

/* 1188 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1190 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1192 */	NdrFcShort( 0x8e ),	/* Type Offset=142 */

	/* Parameter newFunction */

/* 1194 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1196 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1198 */	NdrFcShort( 0x8e ),	/* Type Offset=142 */

	/* Return value */

/* 1200 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1202 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1204 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure FileName */


	/* Procedure FileName */


	/* Procedure get_SystemSource */

/* 1206 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1208 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1212 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1214 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1216 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1218 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1220 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1222 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 1224 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1226 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1228 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter fileName */


	/* Parameter fileName */


	/* Parameter pVal */

/* 1230 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1232 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1234 */	NdrFcShort( 0x4d8 ),	/* Type Offset=1240 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 1236 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1238 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1240 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_SystemSource */

/* 1242 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1244 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1248 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1250 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1252 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1254 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1256 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1258 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1260 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1262 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1264 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1266 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1268 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1270 */	NdrFcShort( 0x8e ),	/* Type Offset=142 */

	/* Return value */

/* 1272 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1274 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1276 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_Function */

/* 1278 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1280 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1284 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1286 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1288 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1290 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1292 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1294 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1296 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1298 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1300 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1302 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1304 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1306 */	NdrFcShort( 0x4e2 ),	/* Type Offset=1250 */

	/* Return value */

/* 1308 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1310 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1312 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure putref_Function */

/* 1314 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1316 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1320 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1322 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1324 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1326 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1328 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1330 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1332 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1334 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1336 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1338 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1340 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1342 */	NdrFcShort( 0x4e6 ),	/* Type Offset=1254 */

	/* Return value */

/* 1344 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1346 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1348 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateRootSymbolicImage */

/* 1350 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1352 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1356 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1358 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1360 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1362 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1364 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1366 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1368 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1370 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1372 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1374 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1376 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1378 */	NdrFcShort( 0x4f8 ),	/* Type Offset=1272 */

	/* Return value */

/* 1380 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1382 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1384 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateSymbolicImageGroup */

/* 1386 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1388 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1392 */	NdrFcShort( 0xa ),	/* 10 */
/* 1394 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1396 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1398 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1400 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1402 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1404 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1406 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1408 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 1410 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1412 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1414 */	NdrFcShort( 0x4f8 ),	/* Type Offset=1272 */

	/* Return value */

/* 1416 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1418 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1420 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateProjectiveBundleGroup */

/* 1422 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1424 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1428 */	NdrFcShort( 0xb ),	/* 11 */
/* 1430 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1432 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1434 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1436 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1438 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1440 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1442 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1444 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 1446 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1448 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1450 */	NdrFcShort( 0x4f8 ),	/* Type Offset=1272 */

	/* Return value */

/* 1452 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1454 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1456 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNewNode */

/* 1458 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1460 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1464 */	NdrFcShort( 0xc ),	/* 12 */
/* 1466 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1468 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1470 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1472 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1474 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1476 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1478 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1480 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nodeParent */

/* 1482 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1484 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1486 */	NdrFcShort( 0x4fc ),	/* Type Offset=1276 */

	/* Parameter nodeChild */

/* 1488 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1490 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1492 */	NdrFcShort( 0x4fc ),	/* Type Offset=1276 */

	/* Return value */

/* 1494 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1496 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1498 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNewComputationResult */

/* 1500 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1502 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1506 */	NdrFcShort( 0xd ),	/* 13 */
/* 1508 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1510 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1512 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1514 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1516 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1518 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1520 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1522 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nodeParent */

/* 1524 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1526 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1528 */	NdrFcShort( 0x4fc ),	/* Type Offset=1276 */

	/* Parameter nodeCResult */

/* 1530 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1532 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1534 */	NdrFcShort( 0x50e ),	/* Type Offset=1294 */

	/* Return value */

/* 1536 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1538 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1540 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNoChilds */

/* 1542 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1544 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1548 */	NdrFcShort( 0xe ),	/* 14 */
/* 1550 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1552 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1554 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1556 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1558 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1560 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1562 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1564 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nodeParent */

/* 1566 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1568 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1570 */	NdrFcShort( 0x4fc ),	/* Type Offset=1276 */

	/* Return value */

/* 1572 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1574 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1576 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNoImplementation */

/* 1578 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1580 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1584 */	NdrFcShort( 0xf ),	/* 15 */
/* 1586 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1588 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1590 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1592 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1594 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1596 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1598 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1600 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nodeParent */

/* 1602 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1604 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1606 */	NdrFcShort( 0x4fc ),	/* Type Offset=1276 */

	/* Return value */

/* 1608 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1610 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1612 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_upperLength */


	/* Procedure AllocateGarbage */

/* 1614 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1616 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1620 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1622 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1624 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1626 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1628 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1630 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1632 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1634 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1636 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */


	/* Parameter len */

/* 1638 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1640 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1642 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 1644 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1646 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1648 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_lowerBound */

/* 1650 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1652 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1656 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1658 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1660 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1662 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1664 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1666 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1668 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1670 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1672 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1674 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1676 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1678 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1680 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1682 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1684 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_lowerBound */

/* 1686 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1688 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1692 */	NdrFcShort( 0xa ),	/* 10 */
/* 1694 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1696 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1698 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1700 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1702 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1704 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1706 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1708 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1710 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1712 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1714 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1716 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1718 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1720 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_upperBound */

/* 1722 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1724 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1728 */	NdrFcShort( 0xb ),	/* 11 */
/* 1730 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1732 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1734 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1736 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1738 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1740 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1742 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1744 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1746 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1748 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1750 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1752 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1754 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1756 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_upperBound */

/* 1758 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1760 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1764 */	NdrFcShort( 0xc ),	/* 12 */
/* 1766 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1768 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1770 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1772 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1774 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1776 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1778 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1780 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1782 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1784 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1786 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1788 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1790 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1792 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_lowerLength */

/* 1794 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1796 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1800 */	NdrFcShort( 0xe ),	/* 14 */
/* 1802 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1804 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1806 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1808 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1810 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1812 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1814 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1816 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1818 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1820 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1822 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1824 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1826 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1828 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_upperLength */

/* 1830 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1832 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1836 */	NdrFcShort( 0xf ),	/* 15 */
/* 1838 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1840 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1842 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1844 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1846 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1848 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1850 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1852 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1854 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1856 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1858 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1860 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1862 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1864 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure addNode */

/* 1866 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1868 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1872 */	NdrFcShort( 0xc ),	/* 12 */
/* 1874 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1876 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1878 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1880 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1882 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1884 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1886 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1888 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter img */

/* 1890 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1892 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1894 */	NdrFcShort( 0x520 ),	/* Type Offset=1312 */

	/* Return value */

/* 1896 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1898 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1900 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure removeNode */

/* 1902 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1904 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1908 */	NdrFcShort( 0xd ),	/* 13 */
/* 1910 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1912 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1914 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1916 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1918 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1920 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1922 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1924 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter img */

/* 1926 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1928 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1930 */	NdrFcShort( 0x520 ),	/* Type Offset=1312 */

	/* Return value */

/* 1932 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1934 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1936 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure addNode */

/* 1938 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1940 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1944 */	NdrFcShort( 0xc ),	/* 12 */
/* 1946 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1948 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1950 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1952 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1954 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1956 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1958 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1960 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bn */

/* 1962 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1964 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1966 */	NdrFcShort( 0x532 ),	/* Type Offset=1330 */

	/* Return value */

/* 1968 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1970 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1972 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure removeNode */

/* 1974 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1976 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1980 */	NdrFcShort( 0xd ),	/* 13 */
/* 1982 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1984 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1986 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1988 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1990 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1992 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1994 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1996 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter img */

/* 1998 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2000 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2002 */	NdrFcShort( 0x532 ),	/* Type Offset=1330 */

	/* Return value */

/* 2004 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2006 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2008 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SaveWithID */

/* 2010 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2012 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2016 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2018 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 2020 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2022 */	NdrFcShort( 0x24 ),	/* 36 */
/* 2024 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 2026 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2028 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2030 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2032 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 2034 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2036 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2038 */	NdrFcShort( 0x4fc ),	/* Type Offset=1276 */

	/* Parameter ID */

/* 2040 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 2042 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2044 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 2046 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2048 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2050 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure LoadByID */

/* 2052 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2054 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2058 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2060 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 2062 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2064 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2066 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 2068 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2070 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2072 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2074 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter ID */

/* 2076 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 2078 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2080 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter node */

/* 2082 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 2084 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2086 */	NdrFcShort( 0x4f8 ),	/* Type Offset=1272 */

	/* Return value */

/* 2088 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2090 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2092 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure LoadKernelNode */

/* 2094 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2096 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2100 */	NdrFcShort( 0x7 ),	/* 7 */
/* 2102 */	NdrFcShort( 0x14 ),	/* x86 Stack size/offset = 20 */
/* 2104 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2106 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2108 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 2110 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2112 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2114 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2116 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */

/* 2118 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2120 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2122 */	NdrFcShort( 0x544 ),	/* Type Offset=1348 */

	/* Parameter kernel */

/* 2124 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2126 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2128 */	NdrFcShort( 0x556 ),	/* Type Offset=1366 */

	/* Parameter node */

/* 2130 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 2132 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2134 */	NdrFcShort( 0x568 ),	/* Type Offset=1384 */

	/* Return value */

/* 2136 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2138 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 2140 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SaveKernelNode */

/* 2142 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2144 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2148 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2150 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 2152 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2154 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2156 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 2158 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2160 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2162 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2164 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter output */

/* 2166 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2168 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2170 */	NdrFcShort( 0x57e ),	/* Type Offset=1406 */

	/* Parameter node */

/* 2172 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2174 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2176 */	NdrFcShort( 0x56c ),	/* Type Offset=1388 */

	/* Return value */

/* 2178 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2180 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2182 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SupportSerialization */

/* 2184 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2186 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2190 */	NdrFcShort( 0x9 ),	/* 9 */
/* 2192 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 2194 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2196 */	NdrFcShort( 0x22 ),	/* 34 */
/* 2198 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 2200 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2202 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2204 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2206 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 2208 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2210 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2212 */	NdrFcShort( 0x56c ),	/* Type Offset=1388 */

	/* Parameter result */

/* 2214 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 2216 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2218 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 2220 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2222 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2224 */	0x8,		/* FC_LONG */
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
/*  8 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 10 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 12 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 14 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 16 */	NdrFcShort( 0x2 ),	/* Offset= 2 (18) */
/* 18 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 20 */	NdrFcLong( 0x845738bd ),	/* -2074658627 */
/* 24 */	NdrFcShort( 0x1d8b ),	/* 7563 */
/* 26 */	NdrFcShort( 0x42bc ),	/* 17084 */
/* 28 */	0xa1,		/* 161 */
			0xeb,		/* 235 */
/* 30 */	0xff,		/* 255 */
			0x11,		/* 17 */
/* 32 */	0xf1,		/* 241 */
			0xf2,		/* 242 */
/* 34 */	0x2e,		/* 46 */
			0x67,		/* 103 */
/* 36 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 38 */	NdrFcShort( 0x2 ),	/* Offset= 2 (40) */
/* 40 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 42 */	NdrFcLong( 0x18c498c5 ),	/* 415537349 */
/* 46 */	NdrFcShort( 0x231c ),	/* 8988 */
/* 48 */	NdrFcShort( 0x4f6a ),	/* 20330 */
/* 50 */	0xa4,		/* 164 */
			0x1,		/* 1 */
/* 52 */	0x3c,		/* 60 */
			0x76,		/* 118 */
/* 54 */	0xf5,		/* 245 */
			0xd9,		/* 217 */
/* 56 */	0xd7,		/* 215 */
			0xa8,		/* 168 */
/* 58 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 60 */	NdrFcShort( 0x2 ),	/* Offset= 2 (62) */
/* 62 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 64 */	NdrFcLong( 0xce2b6190 ),	/* -836017776 */
/* 68 */	NdrFcShort( 0xcbc5 ),	/* -13371 */
/* 70 */	NdrFcShort( 0x4104 ),	/* 16644 */
/* 72 */	0xa0,		/* 160 */
			0xe0,		/* 224 */
/* 74 */	0xd7,		/* 215 */
			0xb3,		/* 179 */
/* 76 */	0xfe,		/* 254 */
			0x56,		/* 86 */
/* 78 */	0x78,		/* 120 */
			0x67,		/* 103 */
/* 80 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 82 */	NdrFcLong( 0xf8ed2fd5 ),	/* -118673451 */
/* 86 */	NdrFcShort( 0xc65c ),	/* -14756 */
/* 88 */	NdrFcShort( 0x4c11 ),	/* 19473 */
/* 90 */	0xab,		/* 171 */
			0xd0,		/* 208 */
/* 92 */	0x6d,		/* 109 */
			0xc5,		/* 197 */
/* 94 */	0x3a,		/* 58 */
			0x7f,		/* 127 */
/* 96 */	0x5,		/* 5 */
			0xcd,		/* 205 */
/* 98 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 100 */	NdrFcLong( 0xe6f9519f ),	/* -419868257 */
/* 104 */	NdrFcShort( 0x6bf8 ),	/* 27640 */
/* 106 */	NdrFcShort( 0x45e0 ),	/* 17888 */
/* 108 */	0xac,		/* 172 */
			0xa2,		/* 162 */
/* 110 */	0x4e,		/* 78 */
			0x71,		/* 113 */
/* 112 */	0xf,		/* 15 */
			0x23,		/* 35 */
/* 114 */	0xf8,		/* 248 */
			0xc,		/* 12 */
/* 116 */	
			0x12, 0x0,	/* FC_UP */
/* 118 */	NdrFcShort( 0xe ),	/* Offset= 14 (132) */
/* 120 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 122 */	NdrFcShort( 0x2 ),	/* 2 */
/* 124 */	0x9,		/* Corr desc: FC_ULONG */
			0x0,		/*  */
/* 126 */	NdrFcShort( 0xfffc ),	/* -4 */
/* 128 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 130 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 132 */	
			0x17,		/* FC_CSTRUCT */
			0x3,		/* 3 */
/* 134 */	NdrFcShort( 0x8 ),	/* 8 */
/* 136 */	NdrFcShort( 0xfff0 ),	/* Offset= -16 (120) */
/* 138 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 140 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 142 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 144 */	NdrFcShort( 0x0 ),	/* 0 */
/* 146 */	NdrFcShort( 0x4 ),	/* 4 */
/* 148 */	NdrFcShort( 0x0 ),	/* 0 */
/* 150 */	NdrFcShort( 0xffde ),	/* Offset= -34 (116) */
/* 152 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 154 */	NdrFcLong( 0xc15cf4df ),	/* -1050872609 */
/* 158 */	NdrFcShort( 0xc579 ),	/* -14983 */
/* 160 */	NdrFcShort( 0x4a02 ),	/* 18946 */
/* 162 */	0xa3,		/* 163 */
			0x3e,		/* 62 */
/* 164 */	0xaf,		/* 175 */
			0xb2,		/* 178 */
/* 166 */	0x6a,		/* 106 */
			0xab,		/* 171 */
/* 168 */	0x2c,		/* 44 */
			0x49,		/* 73 */
/* 170 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 172 */	NdrFcLong( 0xe389b4b7 ),	/* -477514569 */
/* 176 */	NdrFcShort( 0xe438 ),	/* -7112 */
/* 178 */	NdrFcShort( 0x4701 ),	/* 18177 */
/* 180 */	0x87,		/* 135 */
			0x19,		/* 25 */
/* 182 */	0x5c,		/* 92 */
			0xd3,		/* 211 */
/* 184 */	0x7f,		/* 127 */
			0x56,		/* 86 */
/* 186 */	0xd0,		/* 208 */
			0xcd,		/* 205 */
/* 188 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 190 */	NdrFcShort( 0x2 ),	/* Offset= 2 (192) */
/* 192 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 194 */	NdrFcLong( 0xe7a4dbc7 ),	/* -408626233 */
/* 198 */	NdrFcShort( 0x26f3 ),	/* 9971 */
/* 200 */	NdrFcShort( 0x487b ),	/* 18555 */
/* 202 */	0x9e,		/* 158 */
			0xad,		/* 173 */
/* 204 */	0xe2,		/* 226 */
			0xa7,		/* 167 */
/* 206 */	0xf6,		/* 246 */
			0xaf,		/* 175 */
/* 208 */	0x82,		/* 130 */
			0xe1,		/* 225 */
/* 210 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 212 */	NdrFcShort( 0x3f6 ),	/* Offset= 1014 (1226) */
/* 214 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 216 */	NdrFcShort( 0x2 ),	/* Offset= 2 (218) */
/* 218 */	
			0x13, 0x0,	/* FC_OP */
/* 220 */	NdrFcShort( 0x3dc ),	/* Offset= 988 (1208) */
/* 222 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x49,		/* 73 */
/* 224 */	NdrFcShort( 0x18 ),	/* 24 */
/* 226 */	NdrFcShort( 0xa ),	/* 10 */
/* 228 */	NdrFcLong( 0x8 ),	/* 8 */
/* 232 */	NdrFcShort( 0x5a ),	/* Offset= 90 (322) */
/* 234 */	NdrFcLong( 0xd ),	/* 13 */
/* 238 */	NdrFcShort( 0x90 ),	/* Offset= 144 (382) */
/* 240 */	NdrFcLong( 0x9 ),	/* 9 */
/* 244 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (438) */
/* 246 */	NdrFcLong( 0xc ),	/* 12 */
/* 250 */	NdrFcShort( 0x2c0 ),	/* Offset= 704 (954) */
/* 252 */	NdrFcLong( 0x24 ),	/* 36 */
/* 256 */	NdrFcShort( 0x2ea ),	/* Offset= 746 (1002) */
/* 258 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 262 */	NdrFcShort( 0x306 ),	/* Offset= 774 (1036) */
/* 264 */	NdrFcLong( 0x10 ),	/* 16 */
/* 268 */	NdrFcShort( 0x320 ),	/* Offset= 800 (1068) */
/* 270 */	NdrFcLong( 0x2 ),	/* 2 */
/* 274 */	NdrFcShort( 0x33a ),	/* Offset= 826 (1100) */
/* 276 */	NdrFcLong( 0x3 ),	/* 3 */
/* 280 */	NdrFcShort( 0x354 ),	/* Offset= 852 (1132) */
/* 282 */	NdrFcLong( 0x14 ),	/* 20 */
/* 286 */	NdrFcShort( 0x36e ),	/* Offset= 878 (1164) */
/* 288 */	NdrFcShort( 0xffff ),	/* Offset= -1 (287) */
/* 290 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 292 */	NdrFcShort( 0x4 ),	/* 4 */
/* 294 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 296 */	NdrFcShort( 0x0 ),	/* 0 */
/* 298 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 300 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 302 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 304 */	NdrFcShort( 0x4 ),	/* 4 */
/* 306 */	NdrFcShort( 0x0 ),	/* 0 */
/* 308 */	NdrFcShort( 0x1 ),	/* 1 */
/* 310 */	NdrFcShort( 0x0 ),	/* 0 */
/* 312 */	NdrFcShort( 0x0 ),	/* 0 */
/* 314 */	0x13, 0x0,	/* FC_OP */
/* 316 */	NdrFcShort( 0xff48 ),	/* Offset= -184 (132) */
/* 318 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 320 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 322 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 324 */	NdrFcShort( 0x8 ),	/* 8 */
/* 326 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 328 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 330 */	NdrFcShort( 0x4 ),	/* 4 */
/* 332 */	NdrFcShort( 0x4 ),	/* 4 */
/* 334 */	0x11, 0x0,	/* FC_RP */
/* 336 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (290) */
/* 338 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 340 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 342 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 344 */	NdrFcLong( 0x0 ),	/* 0 */
/* 348 */	NdrFcShort( 0x0 ),	/* 0 */
/* 350 */	NdrFcShort( 0x0 ),	/* 0 */
/* 352 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 354 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 356 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 358 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 360 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 362 */	NdrFcShort( 0x0 ),	/* 0 */
/* 364 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 366 */	NdrFcShort( 0x0 ),	/* 0 */
/* 368 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 370 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 374 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 376 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 378 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (342) */
/* 380 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 382 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 384 */	NdrFcShort( 0x8 ),	/* 8 */
/* 386 */	NdrFcShort( 0x0 ),	/* 0 */
/* 388 */	NdrFcShort( 0x6 ),	/* Offset= 6 (394) */
/* 390 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 392 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 394 */	
			0x11, 0x0,	/* FC_RP */
/* 396 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (360) */
/* 398 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 400 */	NdrFcLong( 0x20400 ),	/* 132096 */
/* 404 */	NdrFcShort( 0x0 ),	/* 0 */
/* 406 */	NdrFcShort( 0x0 ),	/* 0 */
/* 408 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 410 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 412 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 414 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 416 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 418 */	NdrFcShort( 0x0 ),	/* 0 */
/* 420 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 422 */	NdrFcShort( 0x0 ),	/* 0 */
/* 424 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 426 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 430 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 432 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 434 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (398) */
/* 436 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 438 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 440 */	NdrFcShort( 0x8 ),	/* 8 */
/* 442 */	NdrFcShort( 0x0 ),	/* 0 */
/* 444 */	NdrFcShort( 0x6 ),	/* Offset= 6 (450) */
/* 446 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 448 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 450 */	
			0x11, 0x0,	/* FC_RP */
/* 452 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (416) */
/* 454 */	
			0x2b,		/* FC_NON_ENCAPSULATED_UNION */
			0x9,		/* FC_ULONG */
/* 456 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 458 */	NdrFcShort( 0xfff8 ),	/* -8 */
/* 460 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 462 */	NdrFcShort( 0x2 ),	/* Offset= 2 (464) */
/* 464 */	NdrFcShort( 0x10 ),	/* 16 */
/* 466 */	NdrFcShort( 0x2f ),	/* 47 */
/* 468 */	NdrFcLong( 0x14 ),	/* 20 */
/* 472 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 474 */	NdrFcLong( 0x3 ),	/* 3 */
/* 478 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 480 */	NdrFcLong( 0x11 ),	/* 17 */
/* 484 */	NdrFcShort( 0x8001 ),	/* Simple arm type: FC_BYTE */
/* 486 */	NdrFcLong( 0x2 ),	/* 2 */
/* 490 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 492 */	NdrFcLong( 0x4 ),	/* 4 */
/* 496 */	NdrFcShort( 0x800a ),	/* Simple arm type: FC_FLOAT */
/* 498 */	NdrFcLong( 0x5 ),	/* 5 */
/* 502 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 504 */	NdrFcLong( 0xb ),	/* 11 */
/* 508 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 510 */	NdrFcLong( 0xa ),	/* 10 */
/* 514 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 516 */	NdrFcLong( 0x6 ),	/* 6 */
/* 520 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (752) */
/* 522 */	NdrFcLong( 0x7 ),	/* 7 */
/* 526 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 528 */	NdrFcLong( 0x8 ),	/* 8 */
/* 532 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (758) */
/* 534 */	NdrFcLong( 0xd ),	/* 13 */
/* 538 */	NdrFcShort( 0xff3c ),	/* Offset= -196 (342) */
/* 540 */	NdrFcLong( 0x9 ),	/* 9 */
/* 544 */	NdrFcShort( 0xff6e ),	/* Offset= -146 (398) */
/* 546 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 550 */	NdrFcShort( 0xd4 ),	/* Offset= 212 (762) */
/* 552 */	NdrFcLong( 0x24 ),	/* 36 */
/* 556 */	NdrFcShort( 0xd6 ),	/* Offset= 214 (770) */
/* 558 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 562 */	NdrFcShort( 0xd0 ),	/* Offset= 208 (770) */
/* 564 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 568 */	NdrFcShort( 0x100 ),	/* Offset= 256 (824) */
/* 570 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 574 */	NdrFcShort( 0xfe ),	/* Offset= 254 (828) */
/* 576 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 580 */	NdrFcShort( 0xfc ),	/* Offset= 252 (832) */
/* 582 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 586 */	NdrFcShort( 0xfa ),	/* Offset= 250 (836) */
/* 588 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 592 */	NdrFcShort( 0xf8 ),	/* Offset= 248 (840) */
/* 594 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 598 */	NdrFcShort( 0xf6 ),	/* Offset= 246 (844) */
/* 600 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 604 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (828) */
/* 606 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 610 */	NdrFcShort( 0xde ),	/* Offset= 222 (832) */
/* 612 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 616 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (848) */
/* 618 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 622 */	NdrFcShort( 0xde ),	/* Offset= 222 (844) */
/* 624 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 628 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (852) */
/* 630 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 634 */	NdrFcShort( 0xde ),	/* Offset= 222 (856) */
/* 636 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 640 */	NdrFcShort( 0xdc ),	/* Offset= 220 (860) */
/* 642 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 646 */	NdrFcShort( 0xda ),	/* Offset= 218 (864) */
/* 648 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 652 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (876) */
/* 654 */	NdrFcLong( 0x10 ),	/* 16 */
/* 658 */	NdrFcShort( 0x8002 ),	/* Simple arm type: FC_CHAR */
/* 660 */	NdrFcLong( 0x12 ),	/* 18 */
/* 664 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 666 */	NdrFcLong( 0x13 ),	/* 19 */
/* 670 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 672 */	NdrFcLong( 0x15 ),	/* 21 */
/* 676 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 678 */	NdrFcLong( 0x16 ),	/* 22 */
/* 682 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 684 */	NdrFcLong( 0x17 ),	/* 23 */
/* 688 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 690 */	NdrFcLong( 0xe ),	/* 14 */
/* 694 */	NdrFcShort( 0xbe ),	/* Offset= 190 (884) */
/* 696 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 700 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (894) */
/* 702 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 706 */	NdrFcShort( 0xc0 ),	/* Offset= 192 (898) */
/* 708 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 712 */	NdrFcShort( 0x74 ),	/* Offset= 116 (828) */
/* 714 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 718 */	NdrFcShort( 0x72 ),	/* Offset= 114 (832) */
/* 720 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 724 */	NdrFcShort( 0x70 ),	/* Offset= 112 (836) */
/* 726 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 730 */	NdrFcShort( 0x66 ),	/* Offset= 102 (832) */
/* 732 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 736 */	NdrFcShort( 0x60 ),	/* Offset= 96 (832) */
/* 738 */	NdrFcLong( 0x0 ),	/* 0 */
/* 742 */	NdrFcShort( 0x0 ),	/* Offset= 0 (742) */
/* 744 */	NdrFcLong( 0x1 ),	/* 1 */
/* 748 */	NdrFcShort( 0x0 ),	/* Offset= 0 (748) */
/* 750 */	NdrFcShort( 0xffff ),	/* Offset= -1 (749) */
/* 752 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 754 */	NdrFcShort( 0x8 ),	/* 8 */
/* 756 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 758 */	
			0x13, 0x0,	/* FC_OP */
/* 760 */	NdrFcShort( 0xfd8c ),	/* Offset= -628 (132) */
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
/* 850 */	NdrFcShort( 0xff9e ),	/* Offset= -98 (752) */
/* 852 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 854 */	NdrFcShort( 0xffa0 ),	/* Offset= -96 (758) */
/* 856 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 858 */	NdrFcShort( 0xfdfc ),	/* Offset= -516 (342) */
/* 860 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 862 */	NdrFcShort( 0xfe30 ),	/* Offset= -464 (398) */
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
/* 918 */	NdrFcShort( 0xfe30 ),	/* Offset= -464 (454) */
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
/* 1054 */	NdrFcShort( 0xfd4a ),	/* Offset= -694 (360) */
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
/* 1222 */	NdrFcShort( 0xfc18 ),	/* Offset= -1000 (222) */
/* 1224 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1226 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1228 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1230 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1232 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1234 */	NdrFcShort( 0xfc04 ),	/* Offset= -1020 (214) */
/* 1236 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 1238 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1240) */
/* 1240 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1242 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1244 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1246 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1248 */	NdrFcShort( 0xfe16 ),	/* Offset= -490 (758) */
/* 1250 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1252 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1254) */
/* 1254 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1256 */	NdrFcLong( 0x83229bf2 ),	/* -2094883854 */
/* 1260 */	NdrFcShort( 0x7eb9 ),	/* 32441 */
/* 1262 */	NdrFcShort( 0x428d ),	/* 17037 */
/* 1264 */	0xb8,		/* 184 */
			0x32,		/* 50 */
/* 1266 */	0x83,		/* 131 */
			0x1c,		/* 28 */
/* 1268 */	0xac,		/* 172 */
			0xfa,		/* 250 */
/* 1270 */	0xe7,		/* 231 */
			0x8c,		/* 140 */
/* 1272 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1274 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1276) */
/* 1276 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1278 */	NdrFcLong( 0xe7a4dbc7 ),	/* -408626233 */
/* 1282 */	NdrFcShort( 0x26f3 ),	/* 9971 */
/* 1284 */	NdrFcShort( 0x487b ),	/* 18555 */
/* 1286 */	0x9e,		/* 158 */
			0xad,		/* 173 */
/* 1288 */	0xe2,		/* 226 */
			0xa7,		/* 167 */
/* 1290 */	0xf6,		/* 246 */
			0xaf,		/* 175 */
/* 1292 */	0x82,		/* 130 */
			0xe1,		/* 225 */
/* 1294 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1296 */	NdrFcLong( 0xea038030 ),	/* -368869328 */
/* 1300 */	NdrFcShort( 0x124f ),	/* 4687 */
/* 1302 */	NdrFcShort( 0x4f15 ),	/* 20245 */
/* 1304 */	0xac,		/* 172 */
			0xd4,		/* 212 */
/* 1306 */	0xe0,		/* 224 */
			0x50,		/* 80 */
/* 1308 */	0xc,		/* 12 */
			0x51,		/* 81 */
/* 1310 */	0x10,		/* 16 */
			0xa3,		/* 163 */
/* 1312 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1314 */	NdrFcLong( 0x9acf69a8 ),	/* -1697683032 */
/* 1318 */	NdrFcShort( 0xe19e ),	/* -7778 */
/* 1320 */	NdrFcShort( 0x424a ),	/* 16970 */
/* 1322 */	0xae,		/* 174 */
			0xab,		/* 171 */
/* 1324 */	0xa1,		/* 161 */
			0x57,		/* 87 */
/* 1326 */	0x34,		/* 52 */
			0x8,		/* 8 */
/* 1328 */	0xf0,		/* 240 */
			0xae,		/* 174 */
/* 1330 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1332 */	NdrFcLong( 0x9a232764 ),	/* -1708972188 */
/* 1336 */	NdrFcShort( 0x6785 ),	/* 26501 */
/* 1338 */	NdrFcShort( 0x421f ),	/* 16927 */
/* 1340 */	0x81,		/* 129 */
			0x1a,		/* 26 */
/* 1342 */	0xd4,		/* 212 */
			0x7b,		/* 123 */
/* 1344 */	0x6f,		/* 111 */
			0x3b,		/* 59 */
/* 1346 */	0xc9,		/* 201 */
			0xbe,		/* 190 */
/* 1348 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1350 */	NdrFcLong( 0x5f688d62 ),	/* 1600687458 */
/* 1354 */	NdrFcShort( 0xbce3 ),	/* -17181 */
/* 1356 */	NdrFcShort( 0x4787 ),	/* 18311 */
/* 1358 */	0x95,		/* 149 */
			0xc5,		/* 197 */
/* 1360 */	0x36,		/* 54 */
			0x11,		/* 17 */
/* 1362 */	0x86,		/* 134 */
			0x86,		/* 134 */
/* 1364 */	0xc2,		/* 194 */
			0xd1,		/* 209 */
/* 1366 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1368 */	NdrFcLong( 0x8d366f71 ),	/* -1925812367 */
/* 1372 */	NdrFcShort( 0xea60 ),	/* -5536 */
/* 1374 */	NdrFcShort( 0x4812 ),	/* 18450 */
/* 1376 */	0xaf,		/* 175 */
			0xcd,		/* 205 */
/* 1378 */	0xbc,		/* 188 */
			0x5a,		/* 90 */
/* 1380 */	0x20,		/* 32 */
			0x29,		/* 41 */
/* 1382 */	0x7f,		/* 127 */
			0xdd,		/* 221 */
/* 1384 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1386 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1388) */
/* 1388 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1390 */	NdrFcLong( 0xe7a4dbc7 ),	/* -408626233 */
/* 1394 */	NdrFcShort( 0x26f3 ),	/* 9971 */
/* 1396 */	NdrFcShort( 0x487b ),	/* 18555 */
/* 1398 */	0x9e,		/* 158 */
			0xad,		/* 173 */
/* 1400 */	0xe2,		/* 226 */
			0xa7,		/* 167 */
/* 1402 */	0xf6,		/* 246 */
			0xaf,		/* 175 */
/* 1404 */	0x82,		/* 130 */
			0xe1,		/* 225 */
/* 1406 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1408 */	NdrFcLong( 0xf42fa761 ),	/* -198203551 */
/* 1412 */	NdrFcShort( 0x5767 ),	/* 22375 */
/* 1414 */	NdrFcShort( 0x4c66 ),	/* 19558 */
/* 1416 */	0x8e,		/* 142 */
			0x91,		/* 145 */
/* 1418 */	0x4a,		/* 74 */
			0xc5,		/* 197 */
/* 1420 */	0xec,		/* 236 */
			0x15,		/* 21 */
/* 1422 */	0xae,		/* 174 */
			0x2e,		/* 46 */

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


/* Object interface: IGraphInfo, ver. 0.0,
   GUID={0xCE2B6190,0xCBC5,0x4104,{0xA0,0xE0,0xD7,0xB3,0xFE,0x56,0x78,0x67}} */

#pragma code_seg(".orpc")
static const unsigned short IGraphInfo_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0,
    36,
    78,
    120,
    162,
    204,
    240,
    (unsigned short) -1,
    (unsigned short) -1
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
CINTERFACE_PROXY_VTABLE(16) _IGraphInfoProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IGraphInfo::dimension */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::gridNumber */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::gridSize */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::spaceMin */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::spaceMax */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::edges */ ,
    (void *) (INT_PTR) -1 /* IGraphInfo::nodes */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraphInfo::setGraph */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraphInfo::setGraphComponents */
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
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IGraphInfoStubVtbl =
{
    &IID_IGraphInfo,
    &IGraphInfo_ServerInfo,
    16,
    &IGraphInfo_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IProgressBarNotification, ver. 0.0,
   GUID={0x845738BD,0x1D8B,0x42BC,{0xA1,0xEB,0xFF,0x11,0xF1,0xF2,0x2E,0x67}} */

#pragma code_seg(".orpc")
static const unsigned short IProgressBarNotification_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0,
    276,
    312,
    348,
    378
    };

static const MIDL_STUBLESS_PROXY_INFO IProgressBarNotification_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IProgressBarNotification_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IProgressBarNotification_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IProgressBarNotification_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IProgressBarNotificationProxyVtbl = 
{
    &IProgressBarNotification_ProxyInfo,
    &IID_IProgressBarNotification,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IProgressBarNotification::Length */ ,
    (void *) (INT_PTR) -1 /* IProgressBarNotification::Next */ ,
    (void *) (INT_PTR) -1 /* IProgressBarNotification::NeedStop */ ,
    (void *) (INT_PTR) -1 /* IProgressBarNotification::Start */ ,
    (void *) (INT_PTR) -1 /* IProgressBarNotification::Finish */
};


static const PRPC_STUB_FUNCTION IProgressBarNotification_table[] =
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

CInterfaceStubVtbl _IProgressBarNotificationStubVtbl =
{
    &IID_IProgressBarNotification,
    &IProgressBarNotification_ServerInfo,
    12,
    &IProgressBarNotification_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IParams, ver. 0.0,
   GUID={0xE478D112,0x3D56,0x478E,{0x86,0xC0,0xD5,0x19,0x86,0x51,0x95,0x02}} */

#pragma code_seg(".orpc")
static const unsigned short IParams_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    408
    };

static const MIDL_STUBLESS_PROXY_INFO IParams_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IParams_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IParams_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IParams_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IParamsProxyVtbl = 
{
    &IParams_ProxyInfo,
    &IID_IParams,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IParams::GetProgressBarNotification */
};


static const PRPC_STUB_FUNCTION IParams_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IParamsStubVtbl =
{
    &IID_IParams,
    &IParams_ServerInfo,
    8,
    &IParams_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISubdevideParams, ver. 0.0,
   GUID={0xF8ED2FD5,0xC65C,0x4C11,{0xAB,0xD0,0x6D,0xC5,0x3A,0x7F,0x05,0xCD}} */

#pragma code_seg(".orpc")
static const unsigned short ISubdevideParams_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    408,
    36
    };

static const MIDL_STUBLESS_PROXY_INFO ISubdevideParams_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISubdevideParams_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISubdevideParams_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISubdevideParams_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _ISubdevideParamsProxyVtbl = 
{
    &ISubdevideParams_ProxyInfo,
    &IID_ISubdevideParams,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IParams::GetProgressBarNotification */ ,
    (void *) (INT_PTR) -1 /* ISubdevideParams::getCellDevider */
};


static const PRPC_STUB_FUNCTION ISubdevideParams_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISubdevideParamsStubVtbl =
{
    &IID_ISubdevideParams,
    &ISubdevideParams_ServerInfo,
    9,
    &ISubdevideParams_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IExtendableParams, ver. 0.0,
   GUID={0xCC76B166,0x5482,0x4EA8,{0x97,0x7D,0xD4,0x70,0x05,0xF2,0xBB,0x17}} */

#pragma code_seg(".orpc")
static const unsigned short IExtendableParams_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    408,
    36,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IExtendableParams_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IExtendableParams_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IExtendableParams_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IExtendableParams_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IExtendableParamsProxyVtbl = 
{
    0,
    &IID_IExtendableParams,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IParams::GetProgressBarNotification */ ,
    0 /* forced delegation ISubdevideParams::getCellDevider */
};


static const PRPC_STUB_FUNCTION IExtendableParams_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IExtendableParamsStubVtbl =
{
    &IID_IExtendableParams,
    &IExtendableParams_ServerInfo,
    9,
    &IExtendableParams_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IExtendablePointParams, ver. 0.0,
   GUID={0xE389B4B7,0xE438,0x4701,{0x87,0x19,0x5C,0xD3,0x7F,0x56,0xD0,0xCD}} */

#pragma code_seg(".orpc")
static const unsigned short IExtendablePointParams_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    408,
    36,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IExtendablePointParams_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IExtendablePointParams_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IExtendablePointParams_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IExtendablePointParams_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IExtendablePointParamsProxyVtbl = 
{
    0,
    &IID_IExtendablePointParams,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IParams::GetProgressBarNotification */ ,
    0 /* forced delegation ISubdevideParams::getCellDevider */
};


static const PRPC_STUB_FUNCTION IExtendablePointParams_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IExtendablePointParamsStubVtbl =
{
    &IID_IExtendablePointParams,
    &IExtendablePointParams_ServerInfo,
    9,
    &IExtendablePointParams_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISubdevidePointParams, ver. 0.0,
   GUID={0xE6F9519F,0x6BF8,0x45E0,{0xAC,0xA2,0x4E,0x71,0x0F,0x23,0xF8,0x0C}} */

#pragma code_seg(".orpc")
static const unsigned short ISubdevidePointParams_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    408,
    36,
    444,
    120,
    162
    };

static const MIDL_STUBLESS_PROXY_INFO ISubdevidePointParams_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISubdevidePointParams_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISubdevidePointParams_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISubdevidePointParams_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _ISubdevidePointParamsProxyVtbl = 
{
    &ISubdevidePointParams_ProxyInfo,
    &IID_ISubdevidePointParams,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IParams::GetProgressBarNotification */ ,
    (void *) (INT_PTR) -1 /* ISubdevideParams::getCellDevider */ ,
    (void *) (INT_PTR) -1 /* ISubdevidePointParams::getCellPoints */ ,
    (void *) (INT_PTR) -1 /* ISubdevidePointParams::getOverlaping1 */ ,
    (void *) (INT_PTR) -1 /* ISubdevidePointParams::getOverlaping2 */
};


static const PRPC_STUB_FUNCTION ISubdevidePointParams_table[] =
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

CInterfaceStubVtbl _ISubdevidePointParamsStubVtbl =
{
    &IID_ISubdevidePointParams,
    &ISubdevidePointParams_ServerInfo,
    12,
    &ISubdevidePointParams_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISubdevidableOverlapedPointParams, ver. 0.0,
   GUID={0x5240A861,0x6177,0x4AD5,{0xBC,0x6F,0x44,0x9A,0x6E,0x77,0x1F,0xAC}} */

#pragma code_seg(".orpc")
static const unsigned short ISubdevidableOverlapedPointParams_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    408,
    36,
    444,
    120,
    162,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO ISubdevidableOverlapedPointParams_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISubdevidableOverlapedPointParams_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISubdevidableOverlapedPointParams_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISubdevidableOverlapedPointParams_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _ISubdevidableOverlapedPointParamsProxyVtbl = 
{
    0,
    &IID_ISubdevidableOverlapedPointParams,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IParams::GetProgressBarNotification */ ,
    0 /* forced delegation ISubdevideParams::getCellDevider */ ,
    0 /* forced delegation ISubdevidePointParams::getCellPoints */ ,
    0 /* forced delegation ISubdevidePointParams::getOverlaping1 */ ,
    0 /* forced delegation ISubdevidePointParams::getOverlaping2 */
};


static const PRPC_STUB_FUNCTION ISubdevidableOverlapedPointParams_table[] =
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

CInterfaceStubVtbl _ISubdevidableOverlapedPointParamsStubVtbl =
{
    &IID_ISubdevidableOverlapedPointParams,
    &ISubdevidableOverlapedPointParams_ServerInfo,
    12,
    &ISubdevidableOverlapedPointParams_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IHomotopParams, ver. 0.0,
   GUID={0xC15CF4DF,0xC579,0x4A02,{0xA3,0x3E,0xAF,0xB2,0x6A,0xAB,0x2C,0x49}} */

#pragma code_seg(".orpc")
static const unsigned short IHomotopParams_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    408,
    486,
    312
    };

static const MIDL_STUBLESS_PROXY_INFO IHomotopParams_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IHomotopParams_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IHomotopParams_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IHomotopParams_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(10) _IHomotopParamsProxyVtbl = 
{
    &IHomotopParams_ProxyInfo,
    &IID_IHomotopParams,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IParams::GetProgressBarNotification */ ,
    (void *) (INT_PTR) -1 /* IHomotopParams::getCoordinateAt */ ,
    (void *) (INT_PTR) -1 /* IHomotopParams::notifyNodeNotFound */
};


static const PRPC_STUB_FUNCTION IHomotopParams_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IHomotopParamsStubVtbl =
{
    &IID_IHomotopParams,
    &IHomotopParams_ServerInfo,
    10,
    &IHomotopParams_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IKernelPointer, ver. 0.0,
   GUID={0x18C498C5,0x231C,0x4F6A,{0xA4,0x01,0x3C,0x76,0xF5,0xD9,0xD7,0xA8}} */

#pragma code_seg(".orpc")
static const unsigned short IKernelPointer_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IKernelPointer_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IKernelPointer_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IKernelPointer_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IKernelPointer_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IKernelPointerProxyVtbl = 
{
    0,
    &IID_IKernelPointer,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IKernelPointer_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IKernelPointerStubVtbl =
{
    &IID_IKernelPointer,
    &IKernelPointer_ServerInfo,
    7,
    &IKernelPointer_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IKernelNode, ver. 0.0,
   GUID={0xE7A4DBC7,0x26F3,0x487B,{0x9E,0xAD,0xE2,0xA7,0xF6,0xAF,0x82,0xE1}} */

#pragma code_seg(".orpc")
static const unsigned short IKernelNode_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    528,
    564
    };

static const MIDL_STUBLESS_PROXY_INFO IKernelNode_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IKernelNode_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IKernelNode_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IKernelNode_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IKernelNodeProxyVtbl = 
{
    &IKernelNode_ProxyInfo,
    &IID_IKernelNode,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::get_kernel */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::putref_kernel */
};


static const PRPC_STUB_FUNCTION IKernelNode_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IKernelNodeStubVtbl =
{
    &IID_IKernelNode,
    &IKernelNode_ServerInfo,
    9,
    &IKernelNode_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IGraph, ver. 0.0,
   GUID={0x3A59CE0B,0xD214,0x4BD9,{0xBB,0x1A,0x57,0x78,0x22,0xA5,0x82,0xEE}} */

#pragma code_seg(".orpc")
static const unsigned short IGraph_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    528,
    564,
    600,
    636,
    (unsigned short) -1
    };

static const MIDL_STUBLESS_PROXY_INFO IGraph_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IGraph_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IGraph_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IGraph_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IGraphProxyVtbl = 
{
    &IGraph_ProxyInfo,
    &IID_IGraph,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::get_kernel */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::putref_kernel */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphDimension */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */
};


static const PRPC_STUB_FUNCTION IGraph_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IGraphStubVtbl =
{
    &IID_IGraph,
    &IGraph_ServerInfo,
    12,
    &IGraph_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISubdevidable, ver. 0.0,
   GUID={0x02431842,0x302A,0x4760,{0x80,0xA0,0x1F,0xD2,0xC1,0x61,0xD6,0xAC}} */

#pragma code_seg(".orpc")
static const unsigned short ISubdevidable_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    672
    };

static const MIDL_STUBLESS_PROXY_INFO ISubdevidable_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISubdevidable_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISubdevidable_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISubdevidable_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _ISubdevidableProxyVtbl = 
{
    &ISubdevidable_ProxyInfo,
    &IID_ISubdevidable,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* ISubdevidable::Subdevide */
};


static const PRPC_STUB_FUNCTION ISubdevidable_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _ISubdevidableStubVtbl =
{
    &IID_ISubdevidable,
    &ISubdevidable_ServerInfo,
    8,
    &ISubdevidable_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISubdevidablePoint, ver. 0.0,
   GUID={0x2EBA1301,0xAB35,0x4CC6,{0xBA,0x28,0xD2,0xFC,0xB0,0xCE,0xD0,0x2B}} */

#pragma code_seg(".orpc")
static const unsigned short ISubdevidablePoint_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    708
    };

static const MIDL_STUBLESS_PROXY_INFO ISubdevidablePoint_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISubdevidablePoint_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISubdevidablePoint_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISubdevidablePoint_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _ISubdevidablePointProxyVtbl = 
{
    &ISubdevidablePoint_ProxyInfo,
    &IID_ISubdevidablePoint,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* ISubdevidablePoint::SubdevidePoint */
};


static const PRPC_STUB_FUNCTION ISubdevidablePoint_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _ISubdevidablePointStubVtbl =
{
    &IID_ISubdevidablePoint,
    &ISubdevidablePoint_ServerInfo,
    8,
    &ISubdevidablePoint_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IExtendable, ver. 0.0,
   GUID={0x26DF2357,0x91F9,0x4C63,{0x94,0x17,0x27,0x62,0xB0,0xF8,0x34,0x01}} */

#pragma code_seg(".orpc")
static const unsigned short IExtendable_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    744
    };

static const MIDL_STUBLESS_PROXY_INFO IExtendable_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IExtendable_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IExtendable_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IExtendable_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IExtendableProxyVtbl = 
{
    &IExtendable_ProxyInfo,
    &IID_IExtendable,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IExtendable::Extend */
};


static const PRPC_STUB_FUNCTION IExtendable_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IExtendableStubVtbl =
{
    &IID_IExtendable,
    &IExtendable_ServerInfo,
    8,
    &IExtendable_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMorsable, ver. 0.0,
   GUID={0xAF4F6B4B,0xC82F,0x49B9,{0x9B,0x01,0x16,0x7D,0x5E,0x38,0xAD,0x69}} */

#pragma code_seg(".orpc")
static const unsigned short IMorsable_FormatStringOffsetTable[] =
    {
    774
    };

static const MIDL_STUBLESS_PROXY_INFO IMorsable_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMorsable_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMorsable_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMorsable_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(4) _IMorsableProxyVtbl = 
{
    &IMorsable_ProxyInfo,
    &IID_IMorsable,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    (void *) (INT_PTR) -1 /* IMorsable::Morse */
};

const CInterfaceStubVtbl _IMorsableStubVtbl =
{
    &IID_IMorsable,
    &IMorsable_ServerInfo,
    4,
    0, /* pure interpreted */
    CStdStubBuffer_METHODS
};


/* Object interface: IExportData, ver. 0.0,
   GUID={0x424DB12A,0x2DE1,0x4A38,{0x9C,0xA0,0x2F,0x52,0xDF,0x62,0x94,0x4D}} */

#pragma code_seg(".orpc")
static const unsigned short IExportData_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    804
    };

static const MIDL_STUBLESS_PROXY_INFO IExportData_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IExportData_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IExportData_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IExportData_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IExportDataProxyVtbl = 
{
    &IExportData_ProxyInfo,
    &IID_IExportData,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IExportData::ExportData */
};


static const PRPC_STUB_FUNCTION IExportData_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IExportDataStubVtbl =
{
    &IID_IExportData,
    &IExportData_ServerInfo,
    8,
    &IExportData_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IHomotopFind, ver. 0.0,
   GUID={0xA395C00D,0x8306,0x4AA8,{0x9A,0x9F,0xEA,0x9E,0x79,0xE7,0x4C,0x92}} */

#pragma code_seg(".orpc")
static const unsigned short IHomotopFind_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    840
    };

static const MIDL_STUBLESS_PROXY_INFO IHomotopFind_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IHomotopFind_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IHomotopFind_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IHomotopFind_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IHomotopFindProxyVtbl = 
{
    &IHomotopFind_ProxyInfo,
    &IID_IHomotopFind,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IHomotopFind::Homotop */
};


static const PRPC_STUB_FUNCTION IHomotopFind_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IHomotopFindStubVtbl =
{
    &IID_IHomotopFind,
    &IHomotopFind_ServerInfo,
    8,
    &IHomotopFind_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IComputationResult, ver. 0.0,
   GUID={0xEA038030,0x124F,0x4F15,{0xAC,0xD4,0xE0,0x50,0x0C,0x51,0x10,0xA3}} */

#pragma code_seg(".orpc")
static const unsigned short IComputationResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IComputationResult_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IComputationResult_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IComputationResult_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IComputationResult_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IComputationResultProxyVtbl = 
{
    0,
    &IID_IComputationResult,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IComputationResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IComputationResultStubVtbl =
{
    &IID_IComputationResult,
    &IComputationResult_ServerInfo,
    7,
    &IComputationResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IComputationGraphResult, ver. 0.0,
   GUID={0x5195A2BC,0x243D,0x4DA4,{0xB6,0x8F,0x90,0x15,0xD3,0x38,0x2D,0xB9}} */

#pragma code_seg(".orpc")
static const unsigned short IComputationGraphResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    744,
    876,
    906,
    348
    };

static const MIDL_STUBLESS_PROXY_INFO IComputationGraphResult_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IComputationGraphResult_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IComputationGraphResult_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IComputationGraphResult_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _IComputationGraphResultProxyVtbl = 
{
    &IComputationGraphResult_ProxyInfo,
    &IID_IComputationGraphResult,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IComputationGraphResult::StrongComponents */ ,
    (void *) (INT_PTR) -1 /* IComputationGraphResult::StrongComponentsEdges */ ,
    (void *) (INT_PTR) -1 /* IComputationGraphResult::Loops */ ,
    (void *) (INT_PTR) -1 /* IComputationGraphResult::DoNothing */
};


static const PRPC_STUB_FUNCTION IComputationGraphResult_table[] =
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

CInterfaceStubVtbl _IComputationGraphResultStubVtbl =
{
    &IID_IComputationGraphResult,
    &IComputationGraphResult_ServerInfo,
    11,
    &IComputationGraphResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IComputationExtendingResult, ver. 0.0,
   GUID={0x76314083,0x5CCF,0x4EB5,{0x91,0xF4,0x0D,0xE7,0x9E,0x54,0x93,0x40}} */

#pragma code_seg(".orpc")
static const unsigned short IComputationExtendingResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    936,
    972
    };

static const MIDL_STUBLESS_PROXY_INFO IComputationExtendingResult_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IComputationExtendingResult_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IComputationExtendingResult_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IComputationExtendingResult_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IComputationExtendingResultProxyVtbl = 
{
    &IComputationExtendingResult_ProxyInfo,
    &IID_IComputationExtendingResult,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IComputationExtendingResult::PointMethodProjectiveExtension */ ,
    (void *) (INT_PTR) -1 /* IComputationExtendingResult::PointMethodProjectiveExtensionDimension */
};


static const PRPC_STUB_FUNCTION IComputationExtendingResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IComputationExtendingResultStubVtbl =
{
    &IID_IComputationExtendingResult,
    &IComputationExtendingResult_ServerInfo,
    9,
    &IComputationExtendingResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IComputationMorseResult, ver. 0.0,
   GUID={0x6C613BDB,0xC2CE,0x47EA,{0x9B,0xA0,0x9F,0x2B,0x2D,0x25,0x90,0x16}} */

#pragma code_seg(".orpc")
static const unsigned short IComputationMorseResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    744
    };

static const MIDL_STUBLESS_PROXY_INFO IComputationMorseResult_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IComputationMorseResult_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IComputationMorseResult_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IComputationMorseResult_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IComputationMorseResultProxyVtbl = 
{
    &IComputationMorseResult_ProxyInfo,
    &IID_IComputationMorseResult,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IComputationMorseResult::toResult */
};


static const PRPC_STUB_FUNCTION IComputationMorseResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IComputationMorseResultStubVtbl =
{
    &IID_IComputationMorseResult,
    &IComputationMorseResult_ServerInfo,
    8,
    &IComputationMorseResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IGroupNode, ver. 0.0,
   GUID={0x243208B9,0xC9C1,0x429C,{0x92,0xE5,0xA1,0x58,0x9F,0x15,0x63,0x76}} */

#pragma code_seg(".orpc")
static const unsigned short IGroupNode_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0,
    1008
    };

static const MIDL_STUBLESS_PROXY_INFO IGroupNode_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IGroupNode_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IGroupNode_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IGroupNode_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IGroupNodeProxyVtbl = 
{
    &IGroupNode_ProxyInfo,
    &IID_IGroupNode,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IGroupNode::nodeCount */ ,
    (void *) (INT_PTR) -1 /* IGroupNode::getNode */
};


static const PRPC_STUB_FUNCTION IGroupNode_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IGroupNodeStubVtbl =
{
    &IID_IGroupNode,
    &IGroupNode_ServerInfo,
    9,
    &IGroupNode_table[-3],
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
    804,
    876,
    906,
    1050,
    1092,
    1128
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


/* Object interface: IFunctionEvents, ver. 0.0,
   GUID={0x47A8D8C4,0x8744,0x4150,{0xA8,0xF9,0x27,0x8A,0xE0,0x8C,0x4D,0xA4}} */

#pragma code_seg(".orpc")
static const unsigned short IFunctionEvents_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    804,
    1164,
    906
    };

static const MIDL_STUBLESS_PROXY_INFO IFunctionEvents_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IFunctionEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IFunctionEvents_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IFunctionEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(10) _IFunctionEventsProxyVtbl = 
{
    &IFunctionEvents_ProxyInfo,
    &IID_IFunctionEvents,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IFunctionEvents::FunctionWrongInput */ ,
    (void *) (INT_PTR) -1 /* IFunctionEvents::FunctionChanged */ ,
    (void *) (INT_PTR) -1 /* IFunctionEvents::FunctionAccepted */
};


static const PRPC_STUB_FUNCTION IFunctionEvents_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IFunctionEventsStubVtbl =
{
    &IID_IFunctionEvents,
    &IFunctionEvents_ServerInfo,
    10,
    &IFunctionEvents_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IFunction, ver. 0.0,
   GUID={0x83229BF2,0x7EB9,0x428D,{0xB8,0x32,0x83,0x1C,0xAC,0xFA,0xE7,0x8C}} */

#pragma code_seg(".orpc")
static const unsigned short IFunction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1206,
    1242,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1
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
CINTERFACE_PROXY_VTABLE(13) _IFunctionProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IFunction::get_SystemSource */ ,
    (void *) (INT_PTR) -1 /* IFunction::put_SystemSource */ ,
    0 /* (void *) (INT_PTR) -1 /* IFunction::getFunction */ ,
    0 /* (void *) (INT_PTR) -1 /* IFunction::createGraph */ ,
    0 /* (void *) (INT_PTR) -1 /* IFunction::getSystemFunction */ ,
    0 /* (void *) (INT_PTR) -1 /* IFunction::getSystemFunctionDerivate */
};


static const PRPC_STUB_FUNCTION IFunction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IFunctionStubVtbl =
{
    &IID_IFunction,
    &IFunction_ServerInfo,
    13,
    &IFunction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IKernel, ver. 0.0,
   GUID={0x8D366F71,0xEA60,0x4812,{0xAF,0xCD,0xBC,0x5A,0x20,0x29,0x7F,0xDD}} */

#pragma code_seg(".orpc")
static const unsigned short IKernel_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1278,
    1314,
    1350,
    1386,
    1422,
    1458,
    1500,
    1542,
    1578,
    1614
    };

static const MIDL_STUBLESS_PROXY_INFO IKernel_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IKernel_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IKernel_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IKernel_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(17) _IKernelProxyVtbl = 
{
    &IKernel_ProxyInfo,
    &IID_IKernel,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IKernel::get_Function */ ,
    (void *) (INT_PTR) -1 /* IKernel::putref_Function */ ,
    (void *) (INT_PTR) -1 /* IKernel::CreateRootSymbolicImage */ ,
    (void *) (INT_PTR) -1 /* IKernel::CreateSymbolicImageGroup */ ,
    (void *) (INT_PTR) -1 /* IKernel::CreateProjectiveBundleGroup */ ,
    (void *) (INT_PTR) -1 /* IKernel::EventNewNode */ ,
    (void *) (INT_PTR) -1 /* IKernel::EventNewComputationResult */ ,
    (void *) (INT_PTR) -1 /* IKernel::EventNoChilds */ ,
    (void *) (INT_PTR) -1 /* IKernel::EventNoImplementation */ ,
    (void *) (INT_PTR) -1 /* IKernel::AllocateGarbage */
};


static const PRPC_STUB_FUNCTION IKernel_table[] =
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
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IKernelStubVtbl =
{
    &IID_IKernel,
    &IKernel_ServerInfo,
    17,
    &IKernel_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IComputationGraphResultExt, ver. 0.0,
   GUID={0xA16233C4,0x8412,0x43B1,{0xB8,0xFB,0xC3,0x39,0xF8,0x6E,0xFB,0x55}} */

#pragma code_seg(".orpc")
static const unsigned short IComputationGraphResultExt_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    744,
    876,
    906,
    348,
    (unsigned short) -1,
    (unsigned short) -1
    };

static const MIDL_STUBLESS_PROXY_INFO IComputationGraphResultExt_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IComputationGraphResultExt_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IComputationGraphResultExt_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IComputationGraphResultExt_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(13) _IComputationGraphResultExtProxyVtbl = 
{
    &IComputationGraphResultExt_ProxyInfo,
    &IID_IComputationGraphResultExt,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IComputationGraphResult::StrongComponents */ ,
    (void *) (INT_PTR) -1 /* IComputationGraphResult::StrongComponentsEdges */ ,
    (void *) (INT_PTR) -1 /* IComputationGraphResult::Loops */ ,
    (void *) (INT_PTR) -1 /* IComputationGraphResult::DoNothing */ ,
    0 /* (void *) (INT_PTR) -1 /* IComputationGraphResultExt::setRootGraph */ ,
    0 /* (void *) (INT_PTR) -1 /* IComputationGraphResultExt::setGraphNode */
};


static const PRPC_STUB_FUNCTION IComputationGraphResultExt_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IComputationGraphResultExtStubVtbl =
{
    &IID_IComputationGraphResultExt,
    &IComputationGraphResultExt_ServerInfo,
    13,
    &IComputationGraphResultExt_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMorseSpectrum, ver. 0.0,
   GUID={0xE9A021D4,0x77A7,0x458E,{0xBB,0x1F,0x2F,0x84,0xDF,0x48,0xB9,0x82}} */

#pragma code_seg(".orpc")
static const unsigned short IMorseSpectrum_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    528,
    564,
    1650,
    1686,
    1722,
    1758,
    240,
    1794,
    1830,
    1614
    };

static const MIDL_STUBLESS_PROXY_INFO IMorseSpectrum_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IMorseSpectrum_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IMorseSpectrum_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IMorseSpectrum_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(17) _IMorseSpectrumProxyVtbl = 
{
    &IMorseSpectrum_ProxyInfo,
    &IID_IMorseSpectrum,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::get_kernel */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::putref_kernel */ ,
    (void *) (INT_PTR) -1 /* IMorseSpectrum::get_lowerBound */ ,
    (void *) (INT_PTR) -1 /* IMorseSpectrum::put_lowerBound */ ,
    (void *) (INT_PTR) -1 /* IMorseSpectrum::get_upperBound */ ,
    (void *) (INT_PTR) -1 /* IMorseSpectrum::put_upperBound */ ,
    (void *) (INT_PTR) -1 /* IMorseSpectrum::get_lowerLength */ ,
    (void *) (INT_PTR) -1 /* IMorseSpectrum::put_lowerLength */ ,
    (void *) (INT_PTR) -1 /* IMorseSpectrum::get_upperLength */ ,
    (void *) (INT_PTR) -1 /* IMorseSpectrum::put_upperLength */
};


static const PRPC_STUB_FUNCTION IMorseSpectrum_table[] =
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
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IMorseSpectrumStubVtbl =
{
    &IID_IMorseSpectrum,
    &IMorseSpectrum_ServerInfo,
    17,
    &IMorseSpectrum_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IProjectiveBundle, ver. 0.0,
   GUID={0x1C62FD1D,0xF7D8,0x417E,{0x9D,0xAA,0x5A,0xEC,0xF0,0x7C,0xF7,0xD3}} */

#pragma code_seg(".orpc")
static const unsigned short IProjectiveBundle_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    528,
    564,
    600,
    636,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IProjectiveBundle_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IProjectiveBundle_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IProjectiveBundle_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IProjectiveBundle_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _IProjectiveBundleProxyVtbl = 
{
    0,
    &IID_IProjectiveBundle,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IKernelNode::get_kernel */ ,
    0 /* forced delegation IKernelNode::putref_kernel */ ,
    0 /* forced delegation IGraph::graphDimension */ ,
    0 /* forced delegation IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */
};


static const PRPC_STUB_FUNCTION IProjectiveBundle_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IProjectiveBundleStubVtbl =
{
    &IID_IProjectiveBundle,
    &IProjectiveBundle_ServerInfo,
    12,
    &IProjectiveBundle_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISymbolicImage, ver. 0.0,
   GUID={0xFA9817A1,0x3666,0x41E7,{0x8F,0xCF,0x09,0x85,0xA4,0x3D,0x5F,0xA6}} */

#pragma code_seg(".orpc")
static const unsigned short ISymbolicImage_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    528,
    564,
    600,
    636,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO ISymbolicImage_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISymbolicImage_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISymbolicImage_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISymbolicImage_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(12) _ISymbolicImageProxyVtbl = 
{
    0,
    &IID_ISymbolicImage,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IKernelNode::get_kernel */ ,
    0 /* forced delegation IKernelNode::putref_kernel */ ,
    0 /* forced delegation IGraph::graphDimension */ ,
    0 /* forced delegation IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */
};


static const PRPC_STUB_FUNCTION ISymbolicImage_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _ISymbolicImageStubVtbl =
{
    &IID_ISymbolicImage,
    &ISymbolicImage_ServerInfo,
    12,
    &ISymbolicImage_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISymbolicImageGraph, ver. 0.0,
   GUID={0x9ACF69A8,0xE19E,0x424A,{0xAE,0xAB,0xA1,0x57,0x34,0x08,0xF0,0xAE}} */

#pragma code_seg(".orpc")
static const unsigned short ISymbolicImageGraph_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    528,
    564,
    600,
    636,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1
    };

static const MIDL_STUBLESS_PROXY_INFO ISymbolicImageGraph_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISymbolicImageGraph_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISymbolicImageGraph_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISymbolicImageGraph_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(14) _ISymbolicImageGraphProxyVtbl = 
{
    &ISymbolicImageGraph_ProxyInfo,
    &IID_ISymbolicImageGraph,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::get_kernel */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::putref_kernel */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphDimension */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */ ,
    0 /* (void *) (INT_PTR) -1 /* ISymbolicImageGraph::setGraph */ ,
    0 /* (void *) (INT_PTR) -1 /* ISymbolicImageGraph::getGraph */
};


static const PRPC_STUB_FUNCTION ISymbolicImageGraph_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _ISymbolicImageGraphStubVtbl =
{
    &IID_ISymbolicImageGraph,
    &ISymbolicImageGraph_ServerInfo,
    14,
    &ISymbolicImageGraph_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISymbolicImageGroup, ver. 0.0,
   GUID={0x148EBD9B,0x8DB6,0x44DF,{0x81,0x48,0x0F,0x71,0xF2,0xB0,0x78,0x90}} */

#pragma code_seg(".orpc")
static const unsigned short ISymbolicImageGroup_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    528,
    564,
    600,
    636,
    (unsigned short) -1,
    1866,
    1902
    };

static const MIDL_STUBLESS_PROXY_INFO ISymbolicImageGroup_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISymbolicImageGroup_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISymbolicImageGroup_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISymbolicImageGroup_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(14) _ISymbolicImageGroupProxyVtbl = 
{
    &ISymbolicImageGroup_ProxyInfo,
    &IID_ISymbolicImageGroup,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::get_kernel */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::putref_kernel */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphDimension */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */ ,
    (void *) (INT_PTR) -1 /* ISymbolicImageGroup::addNode */ ,
    (void *) (INT_PTR) -1 /* ISymbolicImageGroup::removeNode */
};


static const PRPC_STUB_FUNCTION ISymbolicImageGroup_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISymbolicImageGroupStubVtbl =
{
    &IID_ISymbolicImageGroup,
    &ISymbolicImageGroup_ServerInfo,
    14,
    &ISymbolicImageGroup_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IProjectiveBundleGraph, ver. 0.0,
   GUID={0x9A232764,0x6785,0x421F,{0x81,0x1A,0xD4,0x7B,0x6F,0x3B,0xC9,0xBE}} */

#pragma code_seg(".orpc")
static const unsigned short IProjectiveBundleGraph_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    528,
    564,
    600,
    636,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1
    };

static const MIDL_STUBLESS_PROXY_INFO IProjectiveBundleGraph_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IProjectiveBundleGraph_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IProjectiveBundleGraph_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IProjectiveBundleGraph_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(14) _IProjectiveBundleGraphProxyVtbl = 
{
    &IProjectiveBundleGraph_ProxyInfo,
    &IID_IProjectiveBundleGraph,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::get_kernel */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::putref_kernel */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphDimension */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */ ,
    0 /* (void *) (INT_PTR) -1 /* IProjectiveBundleGraph::setGraph */ ,
    0 /* (void *) (INT_PTR) -1 /* IProjectiveBundleGraph::getGraph */
};


static const PRPC_STUB_FUNCTION IProjectiveBundleGraph_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IProjectiveBundleGraphStubVtbl =
{
    &IID_IProjectiveBundleGraph,
    &IProjectiveBundleGraph_ServerInfo,
    14,
    &IProjectiveBundleGraph_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IProjectiveBundleGroup, ver. 0.0,
   GUID={0x979E3895,0x84BD,0x489D,{0xA0,0xA9,0xC6,0xC7,0x3D,0x62,0x3C,0xE2}} */

#pragma code_seg(".orpc")
static const unsigned short IProjectiveBundleGroup_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    528,
    564,
    600,
    636,
    (unsigned short) -1,
    1938,
    1974
    };

static const MIDL_STUBLESS_PROXY_INFO IProjectiveBundleGroup_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IProjectiveBundleGroup_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IProjectiveBundleGroup_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IProjectiveBundleGroup_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(14) _IProjectiveBundleGroupProxyVtbl = 
{
    &IProjectiveBundleGroup_ProxyInfo,
    &IID_IProjectiveBundleGroup,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::get_kernel */ ,
    (void *) (INT_PTR) -1 /* IKernelNode::putref_kernel */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphDimension */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */ ,
    (void *) (INT_PTR) -1 /* IProjectiveBundleGroup::addNode */ ,
    (void *) (INT_PTR) -1 /* IProjectiveBundleGroup::removeNode */
};


static const PRPC_STUB_FUNCTION IProjectiveBundleGroup_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IProjectiveBundleGroupStubVtbl =
{
    &IID_IProjectiveBundleGroup,
    &IProjectiveBundleGroup_ServerInfo,
    14,
    &IProjectiveBundleGroup_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISerializerOutputData, ver. 0.0,
   GUID={0xF42FA761,0x5767,0x4C66,{0x8E,0x91,0x4A,0xC5,0xEC,0x15,0xAE,0x2E}} */

#pragma code_seg(".orpc")
static const unsigned short ISerializerOutputData_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1206,
    2010
    };

static const MIDL_STUBLESS_PROXY_INFO ISerializerOutputData_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISerializerOutputData_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISerializerOutputData_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISerializerOutputData_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _ISerializerOutputDataProxyVtbl = 
{
    &ISerializerOutputData_ProxyInfo,
    &IID_ISerializerOutputData,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* ISerializerOutputData::FileName */ ,
    (void *) (INT_PTR) -1 /* ISerializerOutputData::SaveWithID */
};


static const PRPC_STUB_FUNCTION ISerializerOutputData_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISerializerOutputDataStubVtbl =
{
    &IID_ISerializerOutputData,
    &ISerializerOutputData_ServerInfo,
    9,
    &ISerializerOutputData_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISerializerInputData, ver. 0.0,
   GUID={0x5F688D62,0xBCE3,0x4787,{0x95,0xC5,0x36,0x11,0x86,0x86,0xC2,0xD1}} */

#pragma code_seg(".orpc")
static const unsigned short ISerializerInputData_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1206,
    2052
    };

static const MIDL_STUBLESS_PROXY_INFO ISerializerInputData_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISerializerInputData_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISerializerInputData_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISerializerInputData_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _ISerializerInputDataProxyVtbl = 
{
    &ISerializerInputData_ProxyInfo,
    &IID_ISerializerInputData,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* ISerializerInputData::FileName */ ,
    (void *) (INT_PTR) -1 /* ISerializerInputData::LoadByID */
};


static const PRPC_STUB_FUNCTION ISerializerInputData_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISerializerInputDataStubVtbl =
{
    &IID_ISerializerInputData,
    &ISerializerInputData_ServerInfo,
    9,
    &ISerializerInputData_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISerializer, ver. 0.0,
   GUID={0xEEDA2826,0x2706,0x49B4,{0x98,0x96,0xD3,0x45,0x4C,0x40,0x07,0x54}} */

#pragma code_seg(".orpc")
static const unsigned short ISerializer_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    2094,
    2142,
    2184
    };

static const MIDL_STUBLESS_PROXY_INFO ISerializer_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISerializer_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISerializer_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISerializer_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(10) _ISerializerProxyVtbl = 
{
    &ISerializer_ProxyInfo,
    &IID_ISerializer,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* ISerializer::LoadKernelNode */ ,
    (void *) (INT_PTR) -1 /* ISerializer::SaveKernelNode */ ,
    (void *) (INT_PTR) -1 /* ISerializer::SupportSerialization */
};


static const PRPC_STUB_FUNCTION ISerializer_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISerializerStubVtbl =
{
    &IID_ISerializer,
    &ISerializer_ServerInfo,
    10,
    &ISerializer_table[-3],
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

const CInterfaceProxyVtbl * __MorseKernelATL_ProxyVtblList[] = 
{
    ( CInterfaceProxyVtbl *) &_ISubdevidablePointProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IHomotopFindProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProjectiveBundleProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISerializerProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IExportDataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISubdevidableProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMorsableProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IExtendableProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISerializerOutputDataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISubdevidableOverlapedPointParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISerializerInputDataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProjectiveBundleGraphProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IExtendableParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernelProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationExtendingResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProjectiveBundleGroupProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISymbolicImageGroupProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISubdevidePointParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISymbolicImageProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComponentRegistrarProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISymbolicImageGraphProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IExtendablePointParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGroupNodeProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProgressBarNotificationProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationGraphResultExtProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IFunctionEventsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernelPointerProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernelNodeProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMorseSpectrumProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISubdevideParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationMorseResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IHomotopParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IFunctionProxyVtbl,
    0
};

const CInterfaceStubVtbl * __MorseKernelATL_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_ISubdevidablePointStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphStubVtbl,
    ( CInterfaceStubVtbl *) &_IHomotopFindStubVtbl,
    ( CInterfaceStubVtbl *) &_IParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_IProjectiveBundleStubVtbl,
    ( CInterfaceStubVtbl *) &_ISerializerStubVtbl,
    ( CInterfaceStubVtbl *) &_IExportDataStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationResultStubVtbl,
    ( CInterfaceStubVtbl *) &_ISubdevidableStubVtbl,
    ( CInterfaceStubVtbl *) &_IMorsableStubVtbl,
    ( CInterfaceStubVtbl *) &_IExtendableStubVtbl,
    ( CInterfaceStubVtbl *) &_ISerializerOutputDataStubVtbl,
    ( CInterfaceStubVtbl *) &_ISubdevidableOverlapedPointParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_ISerializerInputDataStubVtbl,
    ( CInterfaceStubVtbl *) &_IProjectiveBundleGraphStubVtbl,
    ( CInterfaceStubVtbl *) &_IExtendableParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernelStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationExtendingResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IProjectiveBundleGroupStubVtbl,
    ( CInterfaceStubVtbl *) &_ISymbolicImageGroupStubVtbl,
    ( CInterfaceStubVtbl *) &_ISubdevidePointParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_ISymbolicImageStubVtbl,
    ( CInterfaceStubVtbl *) &_IComponentRegistrarStubVtbl,
    ( CInterfaceStubVtbl *) &_ISymbolicImageGraphStubVtbl,
    ( CInterfaceStubVtbl *) &_IExtendablePointParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_IGroupNodeStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IProgressBarNotificationStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationGraphResultExtStubVtbl,
    ( CInterfaceStubVtbl *) &_IFunctionEventsStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernelPointerStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernelNodeStubVtbl,
    ( CInterfaceStubVtbl *) &_IMorseSpectrumStubVtbl,
    ( CInterfaceStubVtbl *) &_ISubdevideParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationMorseResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IHomotopParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_IFunctionStubVtbl,
    0
};

PCInterfaceName const __MorseKernelATL_InterfaceNamesList[] = 
{
    "ISubdevidablePoint",
    "IGraph",
    "IHomotopFind",
    "IParams",
    "IProjectiveBundle",
    "ISerializer",
    "IExportData",
    "IComputationResult",
    "ISubdevidable",
    "IMorsable",
    "IExtendable",
    "ISerializerOutputData",
    "ISubdevidableOverlapedPointParams",
    "ISerializerInputData",
    "IProjectiveBundleGraph",
    "IExtendableParams",
    "IKernel",
    "IComputationExtendingResult",
    "IGraphInfo",
    "IProjectiveBundleGroup",
    "ISymbolicImageGroup",
    "ISubdevidePointParams",
    "ISymbolicImage",
    "IComponentRegistrar",
    "ISymbolicImageGraph",
    "IExtendablePointParams",
    "IGroupNode",
    "IComputationGraphResult",
    "IProgressBarNotification",
    "IComputationGraphResultExt",
    "IFunctionEvents",
    "IKernelPointer",
    "IKernelNode",
    "IMorseSpectrum",
    "ISubdevideParams",
    "IComputationMorseResult",
    "IHomotopParams",
    "IFunction",
    0
};

const IID *  __MorseKernelATL_BaseIIDList[] = 
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
    0,
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


#define __MorseKernelATL_CHECK_IID(n)	IID_GENERIC_CHECK_IID( __MorseKernelATL, pIID, n)

int __stdcall __MorseKernelATL_IID_Lookup( const IID * pIID, int * pIndex )
{
    IID_BS_LOOKUP_SETUP

    IID_BS_LOOKUP_INITIAL_TEST( __MorseKernelATL, 38, 32 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 16 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 8 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 4 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 2 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( __MorseKernelATL, 38, *pIndex )
    
}

const ExtendedProxyFileInfo _MorseKernelATL_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & __MorseKernelATL_ProxyVtblList,
    (PCInterfaceStubVtblList *) & __MorseKernelATL_StubVtblList,
    (const PCInterfaceName * ) & __MorseKernelATL_InterfaceNamesList,
    (const IID ** ) & __MorseKernelATL_BaseIIDList,
    & __MorseKernelATL_IID_Lookup, 
    38,
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

