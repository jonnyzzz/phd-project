

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Sun Jan 23 03:33:46 2005
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

#define TYPE_FORMAT_STRING_SIZE   1305                              
#define PROC_FORMAT_STRING_SIZE   1915                              
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


extern const MIDL_SERVER_INFO IDummy_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IDummy_ProxyInfo;


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


	/* Parameter dimension */

/* 24 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 26 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 28 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

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

	/* Parameter id */

/* 144 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 146 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 148 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter size */

/* 150 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 152 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 154 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 156 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 158 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 160 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

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

	/* Parameter id */

/* 186 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 188 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 190 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter size */

/* 192 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 194 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 196 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

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

	/* Procedure updateProgressBar */

/* 276 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 278 */	NdrFcLong( 0x0 ),	/* 0 */
/* 282 */	NdrFcShort( 0x7 ),	/* 7 */
/* 284 */	NdrFcShort( 0x14 ),	/* x86 Stack size/offset = 20 */
/* 286 */	NdrFcShort( 0x18 ),	/* 24 */
/* 288 */	NdrFcShort( 0x8 ),	/* 8 */
/* 290 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x4,		/* 4 */
/* 292 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 294 */	NdrFcShort( 0x0 ),	/* 0 */
/* 296 */	NdrFcShort( 0x0 ),	/* 0 */
/* 298 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter minValue */

/* 300 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 302 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 304 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter maxValue */

/* 306 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 308 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 310 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter currentValue */

/* 312 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 314 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 316 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 318 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 320 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 322 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure getCellPoints */

/* 324 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 326 */	NdrFcLong( 0x0 ),	/* 0 */
/* 330 */	NdrFcShort( 0x9 ),	/* 9 */
/* 332 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 334 */	NdrFcShort( 0x8 ),	/* 8 */
/* 336 */	NdrFcShort( 0x24 ),	/* 36 */
/* 338 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 340 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 342 */	NdrFcShort( 0x0 ),	/* 0 */
/* 344 */	NdrFcShort( 0x0 ),	/* 0 */
/* 346 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter axis */

/* 348 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 350 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 352 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 354 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 356 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 358 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 360 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 362 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 364 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure getCoordinateAt */

/* 366 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 368 */	NdrFcLong( 0x0 ),	/* 0 */
/* 372 */	NdrFcShort( 0x7 ),	/* 7 */
/* 374 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 376 */	NdrFcShort( 0x8 ),	/* 8 */
/* 378 */	NdrFcShort( 0x2c ),	/* 44 */
/* 380 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 382 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 384 */	NdrFcShort( 0x0 ),	/* 0 */
/* 386 */	NdrFcShort( 0x0 ),	/* 0 */
/* 388 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter axis */

/* 390 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 392 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 394 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 396 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 398 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 400 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 402 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 404 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 406 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure notifyNodeNotFound */

/* 408 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 410 */	NdrFcLong( 0x0 ),	/* 0 */
/* 414 */	NdrFcShort( 0x8 ),	/* 8 */
/* 416 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 418 */	NdrFcShort( 0x0 ),	/* 0 */
/* 420 */	NdrFcShort( 0x22 ),	/* 34 */
/* 422 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 424 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 426 */	NdrFcShort( 0x0 ),	/* 0 */
/* 428 */	NdrFcShort( 0x0 ),	/* 0 */
/* 430 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter tryAgain */

/* 432 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 434 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 436 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 438 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 440 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 442 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_kernel */

/* 444 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 446 */	NdrFcLong( 0x0 ),	/* 0 */
/* 450 */	NdrFcShort( 0x7 ),	/* 7 */
/* 452 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 454 */	NdrFcShort( 0x0 ),	/* 0 */
/* 456 */	NdrFcShort( 0x8 ),	/* 8 */
/* 458 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 460 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 462 */	NdrFcShort( 0x0 ),	/* 0 */
/* 464 */	NdrFcShort( 0x0 ),	/* 0 */
/* 466 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 468 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 470 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 472 */	NdrFcShort( 0xe ),	/* Type Offset=14 */

	/* Return value */

/* 474 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 476 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 478 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure putref_kernel */

/* 480 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 482 */	NdrFcLong( 0x0 ),	/* 0 */
/* 486 */	NdrFcShort( 0x8 ),	/* 8 */
/* 488 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 490 */	NdrFcShort( 0x0 ),	/* 0 */
/* 492 */	NdrFcShort( 0x8 ),	/* 8 */
/* 494 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 496 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 498 */	NdrFcShort( 0x0 ),	/* 0 */
/* 500 */	NdrFcShort( 0x0 ),	/* 0 */
/* 502 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 504 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 506 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 508 */	NdrFcShort( 0x12 ),	/* Type Offset=18 */

	/* Return value */

/* 510 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 512 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 514 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure graphDimension */

/* 516 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 518 */	NdrFcLong( 0x0 ),	/* 0 */
/* 522 */	NdrFcShort( 0x9 ),	/* 9 */
/* 524 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 526 */	NdrFcShort( 0x0 ),	/* 0 */
/* 528 */	NdrFcShort( 0x24 ),	/* 36 */
/* 530 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 532 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 534 */	NdrFcShort( 0x0 ),	/* 0 */
/* 536 */	NdrFcShort( 0x0 ),	/* 0 */
/* 538 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 540 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 542 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 544 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 546 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 548 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 550 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure graphInfo */

/* 552 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 554 */	NdrFcLong( 0x0 ),	/* 0 */
/* 558 */	NdrFcShort( 0xa ),	/* 10 */
/* 560 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 562 */	NdrFcShort( 0x0 ),	/* 0 */
/* 564 */	NdrFcShort( 0x8 ),	/* 8 */
/* 566 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 568 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 570 */	NdrFcShort( 0x0 ),	/* 0 */
/* 572 */	NdrFcShort( 0x0 ),	/* 0 */
/* 574 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter info */

/* 576 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 578 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 580 */	NdrFcShort( 0x24 ),	/* Type Offset=36 */

	/* Return value */

/* 582 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 584 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 586 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Subdevide */

/* 588 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 590 */	NdrFcLong( 0x0 ),	/* 0 */
/* 594 */	NdrFcShort( 0x7 ),	/* 7 */
/* 596 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 598 */	NdrFcShort( 0x0 ),	/* 0 */
/* 600 */	NdrFcShort( 0x8 ),	/* 8 */
/* 602 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 604 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 606 */	NdrFcShort( 0x0 ),	/* 0 */
/* 608 */	NdrFcShort( 0x0 ),	/* 0 */
/* 610 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter params */

/* 612 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 614 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 616 */	NdrFcShort( 0x3a ),	/* Type Offset=58 */

	/* Return value */

/* 618 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 620 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 622 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SubdevidePoint */

/* 624 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 626 */	NdrFcLong( 0x0 ),	/* 0 */
/* 630 */	NdrFcShort( 0x7 ),	/* 7 */
/* 632 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 634 */	NdrFcShort( 0x0 ),	/* 0 */
/* 636 */	NdrFcShort( 0x8 ),	/* 8 */
/* 638 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 640 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 642 */	NdrFcShort( 0x0 ),	/* 0 */
/* 644 */	NdrFcShort( 0x0 ),	/* 0 */
/* 646 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter params */

/* 648 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 650 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 652 */	NdrFcShort( 0x4c ),	/* Type Offset=76 */

	/* Return value */

/* 654 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 656 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 658 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure toResult */


	/* Procedure StrongComponents */


	/* Procedure Extend */

/* 660 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 662 */	NdrFcLong( 0x0 ),	/* 0 */
/* 666 */	NdrFcShort( 0x7 ),	/* 7 */
/* 668 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 670 */	NdrFcShort( 0x0 ),	/* 0 */
/* 672 */	NdrFcShort( 0x8 ),	/* 8 */
/* 674 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 676 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 678 */	NdrFcShort( 0x0 ),	/* 0 */
/* 680 */	NdrFcShort( 0x0 ),	/* 0 */
/* 682 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 684 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 686 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 688 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Morse */

/* 690 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 692 */	NdrFcLong( 0x0 ),	/* 0 */
/* 696 */	NdrFcShort( 0x3 ),	/* 3 */
/* 698 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 700 */	NdrFcShort( 0x0 ),	/* 0 */
/* 702 */	NdrFcShort( 0x8 ),	/* 8 */
/* 704 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 706 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 708 */	NdrFcShort( 0x0 ),	/* 0 */
/* 710 */	NdrFcShort( 0x0 ),	/* 0 */
/* 712 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 714 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 716 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 718 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure FunctionWrongInput */


	/* Procedure Attach */


	/* Procedure ExportData */

/* 720 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 722 */	NdrFcLong( 0x0 ),	/* 0 */
/* 726 */	NdrFcShort( 0x7 ),	/* 7 */
/* 728 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 730 */	NdrFcShort( 0x0 ),	/* 0 */
/* 732 */	NdrFcShort( 0x8 ),	/* 8 */
/* 734 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 736 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 738 */	NdrFcShort( 0x0 ),	/* 0 */
/* 740 */	NdrFcShort( 0x1 ),	/* 1 */
/* 742 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter description */


	/* Parameter bstrPath */


	/* Parameter file */

/* 744 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 746 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 748 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 750 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 752 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 754 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Homotop */

/* 756 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 758 */	NdrFcLong( 0x0 ),	/* 0 */
/* 762 */	NdrFcShort( 0x7 ),	/* 7 */
/* 764 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 766 */	NdrFcShort( 0x0 ),	/* 0 */
/* 768 */	NdrFcShort( 0x8 ),	/* 8 */
/* 770 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 772 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 774 */	NdrFcShort( 0x0 ),	/* 0 */
/* 776 */	NdrFcShort( 0x0 ),	/* 0 */
/* 778 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter params */

/* 780 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 782 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 784 */	NdrFcShort( 0x82 ),	/* Type Offset=130 */

	/* Return value */

/* 786 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 788 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 790 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterAll */


	/* Procedure StrongComponentsEdges */

/* 792 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 794 */	NdrFcLong( 0x0 ),	/* 0 */
/* 798 */	NdrFcShort( 0x8 ),	/* 8 */
/* 800 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 802 */	NdrFcShort( 0x0 ),	/* 0 */
/* 804 */	NdrFcShort( 0x8 ),	/* 8 */
/* 806 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 808 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 810 */	NdrFcShort( 0x0 ),	/* 0 */
/* 812 */	NdrFcShort( 0x0 ),	/* 0 */
/* 814 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */


	/* Return value */

/* 816 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 818 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 820 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure FunctionAccepted */


	/* Procedure UnregisterAll */


	/* Procedure Loops */

/* 822 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 824 */	NdrFcLong( 0x0 ),	/* 0 */
/* 828 */	NdrFcShort( 0x9 ),	/* 9 */
/* 830 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 832 */	NdrFcShort( 0x0 ),	/* 0 */
/* 834 */	NdrFcShort( 0x8 ),	/* 8 */
/* 836 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 838 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 840 */	NdrFcShort( 0x0 ),	/* 0 */
/* 842 */	NdrFcShort( 0x0 ),	/* 0 */
/* 844 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 846 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 848 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 850 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure DoNothing */

/* 852 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 854 */	NdrFcLong( 0x0 ),	/* 0 */
/* 858 */	NdrFcShort( 0xa ),	/* 10 */
/* 860 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 862 */	NdrFcShort( 0x0 ),	/* 0 */
/* 864 */	NdrFcShort( 0x8 ),	/* 8 */
/* 866 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 868 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 870 */	NdrFcShort( 0x0 ),	/* 0 */
/* 872 */	NdrFcShort( 0x0 ),	/* 0 */
/* 874 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 876 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 878 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 880 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure PointMethodProjectiveExtension */

/* 882 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 884 */	NdrFcLong( 0x0 ),	/* 0 */
/* 888 */	NdrFcShort( 0x7 ),	/* 7 */
/* 890 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 892 */	NdrFcShort( 0x0 ),	/* 0 */
/* 894 */	NdrFcShort( 0x8 ),	/* 8 */
/* 896 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 898 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 900 */	NdrFcShort( 0x0 ),	/* 0 */
/* 902 */	NdrFcShort( 0x0 ),	/* 0 */
/* 904 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter params */

/* 906 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 908 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 910 */	NdrFcShort( 0x94 ),	/* Type Offset=148 */

	/* Return value */

/* 912 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 914 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 916 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure PointMethodProjectiveExtensionDimension */

/* 918 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 920 */	NdrFcLong( 0x0 ),	/* 0 */
/* 924 */	NdrFcShort( 0x8 ),	/* 8 */
/* 926 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 928 */	NdrFcShort( 0x0 ),	/* 0 */
/* 930 */	NdrFcShort( 0x24 ),	/* 36 */
/* 932 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 934 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 936 */	NdrFcShort( 0x0 ),	/* 0 */
/* 938 */	NdrFcShort( 0x0 ),	/* 0 */
/* 940 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter dim */

/* 942 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 944 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 946 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 948 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 950 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 952 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetComponents */

/* 954 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 956 */	NdrFcLong( 0x0 ),	/* 0 */
/* 960 */	NdrFcShort( 0xa ),	/* 10 */
/* 962 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 964 */	NdrFcShort( 0x0 ),	/* 0 */
/* 966 */	NdrFcShort( 0x8 ),	/* 8 */
/* 968 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 970 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 972 */	NdrFcShort( 0x24 ),	/* 36 */
/* 974 */	NdrFcShort( 0x0 ),	/* 0 */
/* 976 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pbstrCLSIDs */

/* 978 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 980 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 982 */	NdrFcShort( 0x49e ),	/* Type Offset=1182 */

	/* Parameter pbstrDescriptions */

/* 984 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 986 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 988 */	NdrFcShort( 0x49e ),	/* Type Offset=1182 */

	/* Return value */

/* 990 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 992 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 994 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterComponent */

/* 996 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 998 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1002 */	NdrFcShort( 0xb ),	/* 11 */
/* 1004 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1006 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1008 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1010 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1012 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1014 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1016 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1018 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 1020 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1022 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1024 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */

/* 1026 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1028 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1030 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterComponent */

/* 1032 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1034 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1038 */	NdrFcShort( 0xc ),	/* 12 */
/* 1040 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1042 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1044 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1046 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1048 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1050 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1052 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1054 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 1056 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1058 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1060 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */

/* 1062 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1064 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1066 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure FunctionChanged */

/* 1068 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1070 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1074 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1076 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1078 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1080 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1082 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1084 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1086 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1088 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1090 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter oldFunction */

/* 1092 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1094 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1096 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Parameter newFunction */

/* 1098 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1100 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1102 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */

/* 1104 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1106 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1108 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_SystemSource */

/* 1110 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1112 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1116 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1118 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1120 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1122 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1124 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1126 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 1128 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1130 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1132 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1134 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1136 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1138 */	NdrFcShort( 0x4ac ),	/* Type Offset=1196 */

	/* Return value */

/* 1140 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1142 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1144 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_SystemSource */

/* 1146 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1148 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1152 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1154 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1156 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1158 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1160 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1162 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1164 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1166 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1168 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1170 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1172 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1174 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */

/* 1176 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1178 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1180 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_Function */

/* 1182 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1184 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1188 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1190 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1192 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1194 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1196 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1198 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1200 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1202 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1204 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1206 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1208 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1210 */	NdrFcShort( 0x4b6 ),	/* Type Offset=1206 */

	/* Return value */

/* 1212 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1214 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1216 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure putref_Function */

/* 1218 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1220 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1224 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1226 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1228 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1230 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1232 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1234 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1236 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1238 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1240 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1242 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1244 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1246 */	NdrFcShort( 0x4ba ),	/* Type Offset=1210 */

	/* Return value */

/* 1248 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1250 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1252 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateRootSymbolicImage */

/* 1254 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1256 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1260 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1262 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1264 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1266 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1268 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1270 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1272 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1274 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1276 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1278 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1280 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1282 */	NdrFcShort( 0x4cc ),	/* Type Offset=1228 */

	/* Return value */

/* 1284 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1286 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1288 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateSymbolicImageGroup */

/* 1290 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1292 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1296 */	NdrFcShort( 0xa ),	/* 10 */
/* 1298 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1300 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1302 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1304 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1306 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1308 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1310 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1312 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 1314 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1316 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1318 */	NdrFcShort( 0x4cc ),	/* Type Offset=1228 */

	/* Return value */

/* 1320 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1322 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1324 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateProjectiveBundleGroup */

/* 1326 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1328 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1332 */	NdrFcShort( 0xb ),	/* 11 */
/* 1334 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1336 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1338 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1340 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1342 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1344 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1346 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1348 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 1350 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1352 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1354 */	NdrFcShort( 0x4cc ),	/* Type Offset=1228 */

	/* Return value */

/* 1356 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1358 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1360 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNewNode */

/* 1362 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1364 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1368 */	NdrFcShort( 0xc ),	/* 12 */
/* 1370 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1372 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1374 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1376 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1378 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1380 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1382 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1384 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nodeParent */

/* 1386 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1388 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1390 */	NdrFcShort( 0x4d0 ),	/* Type Offset=1232 */

	/* Parameter nodeChild */

/* 1392 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1394 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1396 */	NdrFcShort( 0x4d0 ),	/* Type Offset=1232 */

	/* Return value */

/* 1398 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1400 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1402 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNewComputationResult */

/* 1404 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1406 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1410 */	NdrFcShort( 0xd ),	/* 13 */
/* 1412 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1414 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1416 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1418 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1420 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1422 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1424 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1426 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nodeParent */

/* 1428 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1430 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1432 */	NdrFcShort( 0x4d0 ),	/* Type Offset=1232 */

	/* Parameter nodeCResult */

/* 1434 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1436 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1438 */	NdrFcShort( 0x4e2 ),	/* Type Offset=1250 */

	/* Return value */

/* 1440 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1442 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1444 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNoChilds */

/* 1446 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1448 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1452 */	NdrFcShort( 0xe ),	/* 14 */
/* 1454 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1456 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1458 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1460 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1462 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1464 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1466 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1468 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nodeParent */

/* 1470 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1472 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1474 */	NdrFcShort( 0x4d0 ),	/* Type Offset=1232 */

	/* Return value */

/* 1476 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1478 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1480 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNoImplementation */

/* 1482 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1484 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1488 */	NdrFcShort( 0xf ),	/* 15 */
/* 1490 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1492 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1494 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1496 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1498 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1500 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1502 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1504 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nodeParent */

/* 1506 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1508 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1510 */	NdrFcShort( 0x4d0 ),	/* Type Offset=1232 */

	/* Return value */

/* 1512 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1514 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1516 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_lowerBound */

/* 1518 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1520 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1524 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1526 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1528 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1530 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1532 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1534 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1536 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1538 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1540 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1542 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1544 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1546 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1548 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1550 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1552 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_lowerBound */

/* 1554 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1556 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1560 */	NdrFcShort( 0xa ),	/* 10 */
/* 1562 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1564 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1566 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1568 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1570 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1572 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1574 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1576 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1578 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1580 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1582 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1584 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1586 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1588 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_upperBound */

/* 1590 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1592 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1596 */	NdrFcShort( 0xb ),	/* 11 */
/* 1598 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1600 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1602 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1604 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1606 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1608 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1610 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1612 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1614 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1616 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1618 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1620 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1622 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1624 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_upperBound */

/* 1626 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1628 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1632 */	NdrFcShort( 0xc ),	/* 12 */
/* 1634 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1636 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1638 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1640 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1642 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1644 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1646 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1648 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1650 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1652 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1654 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1656 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1658 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1660 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_lowerLength */

/* 1662 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1664 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1668 */	NdrFcShort( 0xe ),	/* 14 */
/* 1670 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1672 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1674 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1676 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1678 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1680 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1682 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1684 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1686 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1688 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1690 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1692 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1694 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1696 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_upperLength */

/* 1698 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1700 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1704 */	NdrFcShort( 0xf ),	/* 15 */
/* 1706 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1708 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1710 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1712 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1714 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1716 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1718 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1720 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1722 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1724 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1726 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1728 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1730 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1732 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_upperLength */

/* 1734 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1736 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1740 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1742 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1744 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1746 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1748 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1750 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1752 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1754 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1756 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1758 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1760 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1762 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1764 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1766 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1768 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure addNode */

/* 1770 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1772 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1776 */	NdrFcShort( 0xc ),	/* 12 */
/* 1778 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1780 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1782 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1784 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1786 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1788 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1790 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1792 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter img */

/* 1794 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1796 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1798 */	NdrFcShort( 0x4f4 ),	/* Type Offset=1268 */

	/* Return value */

/* 1800 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1802 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1804 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure removeNode */

/* 1806 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1808 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1812 */	NdrFcShort( 0xd ),	/* 13 */
/* 1814 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1816 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1818 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1820 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1822 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1824 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1826 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1828 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter img */

/* 1830 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1832 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1834 */	NdrFcShort( 0x4f4 ),	/* Type Offset=1268 */

	/* Return value */

/* 1836 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1838 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1840 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure addNode */

/* 1842 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1844 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1848 */	NdrFcShort( 0xc ),	/* 12 */
/* 1850 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1852 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1854 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1856 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1858 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1860 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1862 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1864 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bn */

/* 1866 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1868 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1870 */	NdrFcShort( 0x506 ),	/* Type Offset=1286 */

	/* Return value */

/* 1872 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1874 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1876 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure removeNode */

/* 1878 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1880 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1884 */	NdrFcShort( 0xd ),	/* 13 */
/* 1886 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1888 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1890 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1892 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1894 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1896 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1898 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1900 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter img */

/* 1902 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1904 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1906 */	NdrFcShort( 0x506 ),	/* Type Offset=1286 */

	/* Return value */

/* 1908 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1910 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1912 */	0x8,		/* FC_LONG */
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
/* 20 */	NdrFcLong( 0x18c498c5 ),	/* 415537349 */
/* 24 */	NdrFcShort( 0x231c ),	/* 8988 */
/* 26 */	NdrFcShort( 0x4f6a ),	/* 20330 */
/* 28 */	0xa4,		/* 164 */
			0x1,		/* 1 */
/* 30 */	0x3c,		/* 60 */
			0x76,		/* 118 */
/* 32 */	0xf5,		/* 245 */
			0xd9,		/* 217 */
/* 34 */	0xd7,		/* 215 */
			0xa8,		/* 168 */
/* 36 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 38 */	NdrFcShort( 0x2 ),	/* Offset= 2 (40) */
/* 40 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 42 */	NdrFcLong( 0xce2b6190 ),	/* -836017776 */
/* 46 */	NdrFcShort( 0xcbc5 ),	/* -13371 */
/* 48 */	NdrFcShort( 0x4104 ),	/* 16644 */
/* 50 */	0xa0,		/* 160 */
			0xe0,		/* 224 */
/* 52 */	0xd7,		/* 215 */
			0xb3,		/* 179 */
/* 54 */	0xfe,		/* 254 */
			0x56,		/* 86 */
/* 56 */	0x78,		/* 120 */
			0x67,		/* 103 */
/* 58 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 60 */	NdrFcLong( 0xf8ed2fd5 ),	/* -118673451 */
/* 64 */	NdrFcShort( 0xc65c ),	/* -14756 */
/* 66 */	NdrFcShort( 0x4c11 ),	/* 19473 */
/* 68 */	0xab,		/* 171 */
			0xd0,		/* 208 */
/* 70 */	0x6d,		/* 109 */
			0xc5,		/* 197 */
/* 72 */	0x3a,		/* 58 */
			0x7f,		/* 127 */
/* 74 */	0x5,		/* 5 */
			0xcd,		/* 205 */
/* 76 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 78 */	NdrFcLong( 0xe6f9519f ),	/* -419868257 */
/* 82 */	NdrFcShort( 0x6bf8 ),	/* 27640 */
/* 84 */	NdrFcShort( 0x45e0 ),	/* 17888 */
/* 86 */	0xac,		/* 172 */
			0xa2,		/* 162 */
/* 88 */	0x4e,		/* 78 */
			0x71,		/* 113 */
/* 90 */	0xf,		/* 15 */
			0x23,		/* 35 */
/* 92 */	0xf8,		/* 248 */
			0xc,		/* 12 */
/* 94 */	
			0x12, 0x0,	/* FC_UP */
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
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 132 */	NdrFcLong( 0x3c17c825 ),	/* 1008191525 */
/* 136 */	NdrFcShort( 0x1c25 ),	/* 7205 */
/* 138 */	NdrFcShort( 0x4f2d ),	/* 20269 */
/* 140 */	0x8e,		/* 142 */
			0xb,		/* 11 */
/* 142 */	0x63,		/* 99 */
			0x9,		/* 9 */
/* 144 */	0x53,		/* 83 */
			0xad,		/* 173 */
/* 146 */	0x95,		/* 149 */
			0x96,		/* 150 */
/* 148 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 150 */	NdrFcLong( 0xe389b4b7 ),	/* -477514569 */
/* 154 */	NdrFcShort( 0xe438 ),	/* -7112 */
/* 156 */	NdrFcShort( 0x4701 ),	/* 18177 */
/* 158 */	0x87,		/* 135 */
			0x19,		/* 25 */
/* 160 */	0x5c,		/* 92 */
			0xd3,		/* 211 */
/* 162 */	0x7f,		/* 127 */
			0x56,		/* 86 */
/* 164 */	0xd0,		/* 208 */
			0xcd,		/* 205 */
/* 166 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 168 */	NdrFcShort( 0x3f6 ),	/* Offset= 1014 (1182) */
/* 170 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 172 */	NdrFcShort( 0x2 ),	/* Offset= 2 (174) */
/* 174 */	
			0x13, 0x0,	/* FC_OP */
/* 176 */	NdrFcShort( 0x3dc ),	/* Offset= 988 (1164) */
/* 178 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x49,		/* 73 */
/* 180 */	NdrFcShort( 0x18 ),	/* 24 */
/* 182 */	NdrFcShort( 0xa ),	/* 10 */
/* 184 */	NdrFcLong( 0x8 ),	/* 8 */
/* 188 */	NdrFcShort( 0x5a ),	/* Offset= 90 (278) */
/* 190 */	NdrFcLong( 0xd ),	/* 13 */
/* 194 */	NdrFcShort( 0x90 ),	/* Offset= 144 (338) */
/* 196 */	NdrFcLong( 0x9 ),	/* 9 */
/* 200 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (394) */
/* 202 */	NdrFcLong( 0xc ),	/* 12 */
/* 206 */	NdrFcShort( 0x2c0 ),	/* Offset= 704 (910) */
/* 208 */	NdrFcLong( 0x24 ),	/* 36 */
/* 212 */	NdrFcShort( 0x2ea ),	/* Offset= 746 (958) */
/* 214 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 218 */	NdrFcShort( 0x306 ),	/* Offset= 774 (992) */
/* 220 */	NdrFcLong( 0x10 ),	/* 16 */
/* 224 */	NdrFcShort( 0x320 ),	/* Offset= 800 (1024) */
/* 226 */	NdrFcLong( 0x2 ),	/* 2 */
/* 230 */	NdrFcShort( 0x33a ),	/* Offset= 826 (1056) */
/* 232 */	NdrFcLong( 0x3 ),	/* 3 */
/* 236 */	NdrFcShort( 0x354 ),	/* Offset= 852 (1088) */
/* 238 */	NdrFcLong( 0x14 ),	/* 20 */
/* 242 */	NdrFcShort( 0x36e ),	/* Offset= 878 (1120) */
/* 244 */	NdrFcShort( 0xffff ),	/* Offset= -1 (243) */
/* 246 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 248 */	NdrFcShort( 0x4 ),	/* 4 */
/* 250 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 252 */	NdrFcShort( 0x0 ),	/* 0 */
/* 254 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 256 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 258 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 260 */	NdrFcShort( 0x4 ),	/* 4 */
/* 262 */	NdrFcShort( 0x0 ),	/* 0 */
/* 264 */	NdrFcShort( 0x1 ),	/* 1 */
/* 266 */	NdrFcShort( 0x0 ),	/* 0 */
/* 268 */	NdrFcShort( 0x0 ),	/* 0 */
/* 270 */	0x13, 0x0,	/* FC_OP */
/* 272 */	NdrFcShort( 0xff5e ),	/* Offset= -162 (110) */
/* 274 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 276 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 278 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 280 */	NdrFcShort( 0x8 ),	/* 8 */
/* 282 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 284 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 286 */	NdrFcShort( 0x4 ),	/* 4 */
/* 288 */	NdrFcShort( 0x4 ),	/* 4 */
/* 290 */	0x11, 0x0,	/* FC_RP */
/* 292 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (246) */
/* 294 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 296 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 298 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 300 */	NdrFcLong( 0x0 ),	/* 0 */
/* 304 */	NdrFcShort( 0x0 ),	/* 0 */
/* 306 */	NdrFcShort( 0x0 ),	/* 0 */
/* 308 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 310 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 312 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 314 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 316 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 318 */	NdrFcShort( 0x0 ),	/* 0 */
/* 320 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 322 */	NdrFcShort( 0x0 ),	/* 0 */
/* 324 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 326 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 330 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 332 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 334 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (298) */
/* 336 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 338 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 340 */	NdrFcShort( 0x8 ),	/* 8 */
/* 342 */	NdrFcShort( 0x0 ),	/* 0 */
/* 344 */	NdrFcShort( 0x6 ),	/* Offset= 6 (350) */
/* 346 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 348 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 350 */	
			0x11, 0x0,	/* FC_RP */
/* 352 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (316) */
/* 354 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 356 */	NdrFcLong( 0x20400 ),	/* 132096 */
/* 360 */	NdrFcShort( 0x0 ),	/* 0 */
/* 362 */	NdrFcShort( 0x0 ),	/* 0 */
/* 364 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 366 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 368 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 370 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 372 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 374 */	NdrFcShort( 0x0 ),	/* 0 */
/* 376 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 378 */	NdrFcShort( 0x0 ),	/* 0 */
/* 380 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 382 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 386 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 388 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 390 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (354) */
/* 392 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 394 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 396 */	NdrFcShort( 0x8 ),	/* 8 */
/* 398 */	NdrFcShort( 0x0 ),	/* 0 */
/* 400 */	NdrFcShort( 0x6 ),	/* Offset= 6 (406) */
/* 402 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 404 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 406 */	
			0x11, 0x0,	/* FC_RP */
/* 408 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (372) */
/* 410 */	
			0x2b,		/* FC_NON_ENCAPSULATED_UNION */
			0x9,		/* FC_ULONG */
/* 412 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 414 */	NdrFcShort( 0xfff8 ),	/* -8 */
/* 416 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 418 */	NdrFcShort( 0x2 ),	/* Offset= 2 (420) */
/* 420 */	NdrFcShort( 0x10 ),	/* 16 */
/* 422 */	NdrFcShort( 0x2f ),	/* 47 */
/* 424 */	NdrFcLong( 0x14 ),	/* 20 */
/* 428 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 430 */	NdrFcLong( 0x3 ),	/* 3 */
/* 434 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 436 */	NdrFcLong( 0x11 ),	/* 17 */
/* 440 */	NdrFcShort( 0x8001 ),	/* Simple arm type: FC_BYTE */
/* 442 */	NdrFcLong( 0x2 ),	/* 2 */
/* 446 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 448 */	NdrFcLong( 0x4 ),	/* 4 */
/* 452 */	NdrFcShort( 0x800a ),	/* Simple arm type: FC_FLOAT */
/* 454 */	NdrFcLong( 0x5 ),	/* 5 */
/* 458 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 460 */	NdrFcLong( 0xb ),	/* 11 */
/* 464 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 466 */	NdrFcLong( 0xa ),	/* 10 */
/* 470 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 472 */	NdrFcLong( 0x6 ),	/* 6 */
/* 476 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (708) */
/* 478 */	NdrFcLong( 0x7 ),	/* 7 */
/* 482 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 484 */	NdrFcLong( 0x8 ),	/* 8 */
/* 488 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (714) */
/* 490 */	NdrFcLong( 0xd ),	/* 13 */
/* 494 */	NdrFcShort( 0xff3c ),	/* Offset= -196 (298) */
/* 496 */	NdrFcLong( 0x9 ),	/* 9 */
/* 500 */	NdrFcShort( 0xff6e ),	/* Offset= -146 (354) */
/* 502 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 506 */	NdrFcShort( 0xd4 ),	/* Offset= 212 (718) */
/* 508 */	NdrFcLong( 0x24 ),	/* 36 */
/* 512 */	NdrFcShort( 0xd6 ),	/* Offset= 214 (726) */
/* 514 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 518 */	NdrFcShort( 0xd0 ),	/* Offset= 208 (726) */
/* 520 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 524 */	NdrFcShort( 0x100 ),	/* Offset= 256 (780) */
/* 526 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 530 */	NdrFcShort( 0xfe ),	/* Offset= 254 (784) */
/* 532 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 536 */	NdrFcShort( 0xfc ),	/* Offset= 252 (788) */
/* 538 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 542 */	NdrFcShort( 0xfa ),	/* Offset= 250 (792) */
/* 544 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 548 */	NdrFcShort( 0xf8 ),	/* Offset= 248 (796) */
/* 550 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 554 */	NdrFcShort( 0xf6 ),	/* Offset= 246 (800) */
/* 556 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 560 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (784) */
/* 562 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 566 */	NdrFcShort( 0xde ),	/* Offset= 222 (788) */
/* 568 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 572 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (804) */
/* 574 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 578 */	NdrFcShort( 0xde ),	/* Offset= 222 (800) */
/* 580 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 584 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (808) */
/* 586 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 590 */	NdrFcShort( 0xde ),	/* Offset= 222 (812) */
/* 592 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 596 */	NdrFcShort( 0xdc ),	/* Offset= 220 (816) */
/* 598 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 602 */	NdrFcShort( 0xda ),	/* Offset= 218 (820) */
/* 604 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 608 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (832) */
/* 610 */	NdrFcLong( 0x10 ),	/* 16 */
/* 614 */	NdrFcShort( 0x8002 ),	/* Simple arm type: FC_CHAR */
/* 616 */	NdrFcLong( 0x12 ),	/* 18 */
/* 620 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 622 */	NdrFcLong( 0x13 ),	/* 19 */
/* 626 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 628 */	NdrFcLong( 0x15 ),	/* 21 */
/* 632 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 634 */	NdrFcLong( 0x16 ),	/* 22 */
/* 638 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 640 */	NdrFcLong( 0x17 ),	/* 23 */
/* 644 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 646 */	NdrFcLong( 0xe ),	/* 14 */
/* 650 */	NdrFcShort( 0xbe ),	/* Offset= 190 (840) */
/* 652 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 656 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (850) */
/* 658 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 662 */	NdrFcShort( 0xc0 ),	/* Offset= 192 (854) */
/* 664 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 668 */	NdrFcShort( 0x74 ),	/* Offset= 116 (784) */
/* 670 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 674 */	NdrFcShort( 0x72 ),	/* Offset= 114 (788) */
/* 676 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 680 */	NdrFcShort( 0x70 ),	/* Offset= 112 (792) */
/* 682 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 686 */	NdrFcShort( 0x66 ),	/* Offset= 102 (788) */
/* 688 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 692 */	NdrFcShort( 0x60 ),	/* Offset= 96 (788) */
/* 694 */	NdrFcLong( 0x0 ),	/* 0 */
/* 698 */	NdrFcShort( 0x0 ),	/* Offset= 0 (698) */
/* 700 */	NdrFcLong( 0x1 ),	/* 1 */
/* 704 */	NdrFcShort( 0x0 ),	/* Offset= 0 (704) */
/* 706 */	NdrFcShort( 0xffff ),	/* Offset= -1 (705) */
/* 708 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 710 */	NdrFcShort( 0x8 ),	/* 8 */
/* 712 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 714 */	
			0x13, 0x0,	/* FC_OP */
/* 716 */	NdrFcShort( 0xfda2 ),	/* Offset= -606 (110) */
/* 718 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 720 */	NdrFcShort( 0x2 ),	/* Offset= 2 (722) */
/* 722 */	
			0x13, 0x0,	/* FC_OP */
/* 724 */	NdrFcShort( 0x1b8 ),	/* Offset= 440 (1164) */
/* 726 */	
			0x13, 0x0,	/* FC_OP */
/* 728 */	NdrFcShort( 0x20 ),	/* Offset= 32 (760) */
/* 730 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 732 */	NdrFcLong( 0x2f ),	/* 47 */
/* 736 */	NdrFcShort( 0x0 ),	/* 0 */
/* 738 */	NdrFcShort( 0x0 ),	/* 0 */
/* 740 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 742 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 744 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 746 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 748 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 750 */	NdrFcShort( 0x1 ),	/* 1 */
/* 752 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 754 */	NdrFcShort( 0x4 ),	/* 4 */
/* 756 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 758 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 760 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 762 */	NdrFcShort( 0x10 ),	/* 16 */
/* 764 */	NdrFcShort( 0x0 ),	/* 0 */
/* 766 */	NdrFcShort( 0xa ),	/* Offset= 10 (776) */
/* 768 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 770 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 772 */	NdrFcShort( 0xffd6 ),	/* Offset= -42 (730) */
/* 774 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 776 */	
			0x13, 0x0,	/* FC_OP */
/* 778 */	NdrFcShort( 0xffe2 ),	/* Offset= -30 (748) */
/* 780 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 782 */	0x1,		/* FC_BYTE */
			0x5c,		/* FC_PAD */
/* 784 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 786 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 788 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 790 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 792 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 794 */	0xb,		/* FC_HYPER */
			0x5c,		/* FC_PAD */
/* 796 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 798 */	0xa,		/* FC_FLOAT */
			0x5c,		/* FC_PAD */
/* 800 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 802 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 804 */	
			0x13, 0x0,	/* FC_OP */
/* 806 */	NdrFcShort( 0xff9e ),	/* Offset= -98 (708) */
/* 808 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 810 */	NdrFcShort( 0xffa0 ),	/* Offset= -96 (714) */
/* 812 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 814 */	NdrFcShort( 0xfdfc ),	/* Offset= -516 (298) */
/* 816 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 818 */	NdrFcShort( 0xfe30 ),	/* Offset= -464 (354) */
/* 820 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 822 */	NdrFcShort( 0x2 ),	/* Offset= 2 (824) */
/* 824 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 826 */	NdrFcShort( 0x2 ),	/* Offset= 2 (828) */
/* 828 */	
			0x13, 0x0,	/* FC_OP */
/* 830 */	NdrFcShort( 0x14e ),	/* Offset= 334 (1164) */
/* 832 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 834 */	NdrFcShort( 0x2 ),	/* Offset= 2 (836) */
/* 836 */	
			0x13, 0x0,	/* FC_OP */
/* 838 */	NdrFcShort( 0x14 ),	/* Offset= 20 (858) */
/* 840 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 842 */	NdrFcShort( 0x10 ),	/* 16 */
/* 844 */	0x6,		/* FC_SHORT */
			0x1,		/* FC_BYTE */
/* 846 */	0x1,		/* FC_BYTE */
			0x8,		/* FC_LONG */
/* 848 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 850 */	
			0x13, 0x0,	/* FC_OP */
/* 852 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (840) */
/* 854 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 856 */	0x2,		/* FC_CHAR */
			0x5c,		/* FC_PAD */
/* 858 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x7,		/* 7 */
/* 860 */	NdrFcShort( 0x20 ),	/* 32 */
/* 862 */	NdrFcShort( 0x0 ),	/* 0 */
/* 864 */	NdrFcShort( 0x0 ),	/* Offset= 0 (864) */
/* 866 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 868 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 870 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 872 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 874 */	NdrFcShort( 0xfe30 ),	/* Offset= -464 (410) */
/* 876 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 878 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 880 */	NdrFcShort( 0x4 ),	/* 4 */
/* 882 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 884 */	NdrFcShort( 0x0 ),	/* 0 */
/* 886 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 888 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 890 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 892 */	NdrFcShort( 0x4 ),	/* 4 */
/* 894 */	NdrFcShort( 0x0 ),	/* 0 */
/* 896 */	NdrFcShort( 0x1 ),	/* 1 */
/* 898 */	NdrFcShort( 0x0 ),	/* 0 */
/* 900 */	NdrFcShort( 0x0 ),	/* 0 */
/* 902 */	0x13, 0x0,	/* FC_OP */
/* 904 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (858) */
/* 906 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 908 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 910 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 912 */	NdrFcShort( 0x8 ),	/* 8 */
/* 914 */	NdrFcShort( 0x0 ),	/* 0 */
/* 916 */	NdrFcShort( 0x6 ),	/* Offset= 6 (922) */
/* 918 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 920 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 922 */	
			0x11, 0x0,	/* FC_RP */
/* 924 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (878) */
/* 926 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 928 */	NdrFcShort( 0x4 ),	/* 4 */
/* 930 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 932 */	NdrFcShort( 0x0 ),	/* 0 */
/* 934 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 936 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 938 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 940 */	NdrFcShort( 0x4 ),	/* 4 */
/* 942 */	NdrFcShort( 0x0 ),	/* 0 */
/* 944 */	NdrFcShort( 0x1 ),	/* 1 */
/* 946 */	NdrFcShort( 0x0 ),	/* 0 */
/* 948 */	NdrFcShort( 0x0 ),	/* 0 */
/* 950 */	0x13, 0x0,	/* FC_OP */
/* 952 */	NdrFcShort( 0xff40 ),	/* Offset= -192 (760) */
/* 954 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 956 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 958 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 960 */	NdrFcShort( 0x8 ),	/* 8 */
/* 962 */	NdrFcShort( 0x0 ),	/* 0 */
/* 964 */	NdrFcShort( 0x6 ),	/* Offset= 6 (970) */
/* 966 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 968 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 970 */	
			0x11, 0x0,	/* FC_RP */
/* 972 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (926) */
/* 974 */	
			0x1d,		/* FC_SMFARRAY */
			0x0,		/* 0 */
/* 976 */	NdrFcShort( 0x8 ),	/* 8 */
/* 978 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 980 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 982 */	NdrFcShort( 0x10 ),	/* 16 */
/* 984 */	0x8,		/* FC_LONG */
			0x6,		/* FC_SHORT */
/* 986 */	0x6,		/* FC_SHORT */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 988 */	0x0,		/* 0 */
			NdrFcShort( 0xfff1 ),	/* Offset= -15 (974) */
			0x5b,		/* FC_END */
/* 992 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 994 */	NdrFcShort( 0x18 ),	/* 24 */
/* 996 */	NdrFcShort( 0x0 ),	/* 0 */
/* 998 */	NdrFcShort( 0xa ),	/* Offset= 10 (1008) */
/* 1000 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1002 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1004 */	NdrFcShort( 0xffe8 ),	/* Offset= -24 (980) */
/* 1006 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1008 */	
			0x11, 0x0,	/* FC_RP */
/* 1010 */	NdrFcShort( 0xfd4a ),	/* Offset= -694 (316) */
/* 1012 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 1014 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1016 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1018 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1020 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1022 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1024 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1026 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1028 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1030 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1032 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1034 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1036 */	0x13, 0x0,	/* FC_OP */
/* 1038 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1012) */
/* 1040 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1042 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1044 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 1046 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1048 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1050 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1052 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1054 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 1056 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1058 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1060 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1062 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1064 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1066 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1068 */	0x13, 0x0,	/* FC_OP */
/* 1070 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1044) */
/* 1072 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1074 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1076 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1078 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1080 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1082 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1084 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1086 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1088 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1090 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1092 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1094 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1096 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1098 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1100 */	0x13, 0x0,	/* FC_OP */
/* 1102 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1076) */
/* 1104 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1106 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1108 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 1110 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1112 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1114 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1116 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1118 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 1120 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1122 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1124 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1126 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1128 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1130 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1132 */	0x13, 0x0,	/* FC_OP */
/* 1134 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1108) */
/* 1136 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1138 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1140 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1142 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1144 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1146 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1148 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1150 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1152 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 1154 */	NdrFcShort( 0xffd8 ),	/* -40 */
/* 1156 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1158 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1160 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1140) */
/* 1162 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1164 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1166 */	NdrFcShort( 0x28 ),	/* 40 */
/* 1168 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1148) */
/* 1170 */	NdrFcShort( 0x0 ),	/* Offset= 0 (1170) */
/* 1172 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1174 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1176 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1178 */	NdrFcShort( 0xfc18 ),	/* Offset= -1000 (178) */
/* 1180 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1182 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1184 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1186 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1188 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1190 */	NdrFcShort( 0xfc04 ),	/* Offset= -1020 (170) */
/* 1192 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 1194 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1196) */
/* 1196 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1198 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1200 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1202 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1204 */	NdrFcShort( 0xfe16 ),	/* Offset= -490 (714) */
/* 1206 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1208 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1210) */
/* 1210 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1212 */	NdrFcLong( 0x83229bf2 ),	/* -2094883854 */
/* 1216 */	NdrFcShort( 0x7eb9 ),	/* 32441 */
/* 1218 */	NdrFcShort( 0x428d ),	/* 17037 */
/* 1220 */	0xb8,		/* 184 */
			0x32,		/* 50 */
/* 1222 */	0x83,		/* 131 */
			0x1c,		/* 28 */
/* 1224 */	0xac,		/* 172 */
			0xfa,		/* 250 */
/* 1226 */	0xe7,		/* 231 */
			0x8c,		/* 140 */
/* 1228 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1230 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1232) */
/* 1232 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1234 */	NdrFcLong( 0xe7a4dbc7 ),	/* -408626233 */
/* 1238 */	NdrFcShort( 0x26f3 ),	/* 9971 */
/* 1240 */	NdrFcShort( 0x487b ),	/* 18555 */
/* 1242 */	0x9e,		/* 158 */
			0xad,		/* 173 */
/* 1244 */	0xe2,		/* 226 */
			0xa7,		/* 167 */
/* 1246 */	0xf6,		/* 246 */
			0xaf,		/* 175 */
/* 1248 */	0x82,		/* 130 */
			0xe1,		/* 225 */
/* 1250 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1252 */	NdrFcLong( 0xea038030 ),	/* -368869328 */
/* 1256 */	NdrFcShort( 0x124f ),	/* 4687 */
/* 1258 */	NdrFcShort( 0x4f15 ),	/* 20245 */
/* 1260 */	0xac,		/* 172 */
			0xd4,		/* 212 */
/* 1262 */	0xe0,		/* 224 */
			0x50,		/* 80 */
/* 1264 */	0xc,		/* 12 */
			0x51,		/* 81 */
/* 1266 */	0x10,		/* 16 */
			0xa3,		/* 163 */
/* 1268 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1270 */	NdrFcLong( 0x9acf69a8 ),	/* -1697683032 */
/* 1274 */	NdrFcShort( 0xe19e ),	/* -7778 */
/* 1276 */	NdrFcShort( 0x424a ),	/* 16970 */
/* 1278 */	0xae,		/* 174 */
			0xab,		/* 171 */
/* 1280 */	0xa1,		/* 161 */
			0x57,		/* 87 */
/* 1282 */	0x34,		/* 52 */
			0x8,		/* 8 */
/* 1284 */	0xf0,		/* 240 */
			0xae,		/* 174 */
/* 1286 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1288 */	NdrFcLong( 0x9a232764 ),	/* -1708972188 */
/* 1292 */	NdrFcShort( 0x6785 ),	/* 26501 */
/* 1294 */	NdrFcShort( 0x421f ),	/* 16927 */
/* 1296 */	0x81,		/* 129 */
			0x1a,		/* 26 */
/* 1298 */	0xd4,		/* 212 */
			0x7b,		/* 123 */
/* 1300 */	0x6f,		/* 111 */
			0x3b,		/* 59 */
/* 1302 */	0xc9,		/* 201 */
			0xbe,		/* 190 */

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


/* Object interface: IParams, ver. 0.0,
   GUID={0xE478D112,0x3D56,0x478E,{0x86,0xC0,0xD5,0x19,0x86,0x51,0x95,0x02}} */

#pragma code_seg(".orpc")
static const unsigned short IParams_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    276
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
    (void *) (INT_PTR) -1 /* IParams::updateProgressBar */
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
    276,
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
    (void *) (INT_PTR) -1 /* IParams::updateProgressBar */ ,
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
    276,
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
    0 /* forced delegation IParams::updateProgressBar */ ,
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
    276,
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
    0 /* forced delegation IParams::updateProgressBar */ ,
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
    276,
    36,
    324
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
CINTERFACE_PROXY_VTABLE(10) _ISubdevidePointParamsProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IParams::updateProgressBar */ ,
    (void *) (INT_PTR) -1 /* ISubdevideParams::getCellDevider */ ,
    (void *) (INT_PTR) -1 /* ISubdevidePointParams::getCellPoints */
};


static const PRPC_STUB_FUNCTION ISubdevidePointParams_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISubdevidePointParamsStubVtbl =
{
    &IID_ISubdevidePointParams,
    &ISubdevidePointParams_ServerInfo,
    10,
    &ISubdevidePointParams_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IHomotopParams, ver. 0.0,
   GUID={0x3C17C825,0x1C25,0x4F2D,{0x8E,0x0B,0x63,0x09,0x53,0xAD,0x95,0x96}} */

#pragma code_seg(".orpc")
static const unsigned short IHomotopParams_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    366,
    408
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
CINTERFACE_PROXY_VTABLE(9) _IHomotopParamsProxyVtbl = 
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
    NdrStubCall2
};

CInterfaceStubVtbl _IHomotopParamsStubVtbl =
{
    &IID_IHomotopParams,
    &IHomotopParams_ServerInfo,
    9,
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
    444,
    480
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
    444,
    480,
    516,
    552,
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
    588
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
    624
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
    660
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
    690
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
    720
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
    756
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
    660,
    792,
    822,
    852
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
    882,
    918
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
    660
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
    0
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
CINTERFACE_PROXY_VTABLE(8) _IGroupNodeProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IGroupNode::nodeCount */
};


static const PRPC_STUB_FUNCTION IGroupNode_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IGroupNodeStubVtbl =
{
    &IID_IGroupNode,
    &IGroupNode_ServerInfo,
    8,
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
    720,
    792,
    822,
    954,
    996,
    1032
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
    720,
    1068,
    822
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
    1110,
    1146,
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
    1182,
    1218,
    1254,
    1290,
    1326,
    1362,
    1404,
    1446,
    1482
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
CINTERFACE_PROXY_VTABLE(16) _IKernelProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IKernel::EventNoImplementation */
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
    NdrStubCall2
};

CInterfaceStubVtbl _IKernelStubVtbl =
{
    &IID_IKernel,
    &IKernel_ServerInfo,
    16,
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
    660,
    792,
    822,
    852,
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


/* Object interface: IDummy, ver. 0.0,
   GUID={0xECACE910,0x6692,0x4ACC,{0x85,0xC2,0x3E,0xF4,0x48,0xBF,0x26,0x38}} */

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


/* Object interface: IMorseSpectrum, ver. 0.0,
   GUID={0xE9A021D4,0x77A7,0x458E,{0xBB,0x1F,0x2F,0x84,0xDF,0x48,0xB9,0x82}} */

#pragma code_seg(".orpc")
static const unsigned short IMorseSpectrum_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    444,
    480,
    1518,
    1554,
    1590,
    1626,
    240,
    1662,
    1698,
    1734
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
    444,
    480,
    516,
    552,
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
    444,
    480,
    516,
    552,
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
    444,
    480,
    516,
    552,
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
    444,
    480,
    516,
    552,
    (unsigned short) -1,
    1770,
    1806
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
    444,
    480,
    516,
    552,
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
    444,
    480,
    516,
    552,
    (unsigned short) -1,
    1842,
    1878
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
    ( CInterfaceProxyVtbl *) &_IDummyProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProjectiveBundleProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IHomotopParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IExportDataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISubdevidableProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMorsableProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IExtendableProxyVtbl,
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
    ( CInterfaceProxyVtbl *) &_IComputationGraphResultExtProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IFunctionEventsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernelPointerProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernelNodeProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMorseSpectrumProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISubdevideParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationMorseResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IFunctionProxyVtbl,
    0
};

const CInterfaceStubVtbl * __MorseKernelATL_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_ISubdevidablePointStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphStubVtbl,
    ( CInterfaceStubVtbl *) &_IHomotopFindStubVtbl,
    ( CInterfaceStubVtbl *) &_IDummyStubVtbl,
    ( CInterfaceStubVtbl *) &_IParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_IProjectiveBundleStubVtbl,
    ( CInterfaceStubVtbl *) &_IHomotopParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_IExportDataStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationResultStubVtbl,
    ( CInterfaceStubVtbl *) &_ISubdevidableStubVtbl,
    ( CInterfaceStubVtbl *) &_IMorsableStubVtbl,
    ( CInterfaceStubVtbl *) &_IExtendableStubVtbl,
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
    ( CInterfaceStubVtbl *) &_IComputationGraphResultExtStubVtbl,
    ( CInterfaceStubVtbl *) &_IFunctionEventsStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernelPointerStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernelNodeStubVtbl,
    ( CInterfaceStubVtbl *) &_IMorseSpectrumStubVtbl,
    ( CInterfaceStubVtbl *) &_ISubdevideParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationMorseResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IFunctionStubVtbl,
    0
};

PCInterfaceName const __MorseKernelATL_InterfaceNamesList[] = 
{
    "ISubdevidablePoint",
    "IGraph",
    "IHomotopFind",
    "IDummy",
    "IParams",
    "IProjectiveBundle",
    "IHomotopParams",
    "IExportData",
    "IComputationResult",
    "ISubdevidable",
    "IMorsable",
    "IExtendable",
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
    "IComputationGraphResultExt",
    "IFunctionEvents",
    "IKernelPointer",
    "IKernelNode",
    "IMorseSpectrum",
    "ISubdevideParams",
    "IComputationMorseResult",
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
    0
};


#define __MorseKernelATL_CHECK_IID(n)	IID_GENERIC_CHECK_IID( __MorseKernelATL, pIID, n)

int __stdcall __MorseKernelATL_IID_Lookup( const IID * pIID, int * pIndex )
{
    IID_BS_LOOKUP_SETUP

    IID_BS_LOOKUP_INITIAL_TEST( __MorseKernelATL, 34, 32 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 16 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 8 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 4 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 2 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( __MorseKernelATL, 34, *pIndex )
    
}

const ExtendedProxyFileInfo _MorseKernelATL_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & __MorseKernelATL_ProxyVtblList,
    (PCInterfaceStubVtblList *) & __MorseKernelATL_StubVtblList,
    (const PCInterfaceName * ) & __MorseKernelATL_InterfaceNamesList,
    (const IID ** ) & __MorseKernelATL_BaseIIDList,
    & __MorseKernelATL_IID_Lookup, 
    34,
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

