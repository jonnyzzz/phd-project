

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Tue Dec 14 14:34:32 2004
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

#define TYPE_FORMAT_STRING_SIZE   1359                              
#define PROC_FORMAT_STRING_SIZE   1939                              
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


extern const MIDL_SERVER_INFO ISubdevidePointParams_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISubdevidePointParams_ProxyInfo;


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


extern const MIDL_SERVER_INFO IComputationResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComputationResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComputationGraphResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComputationGraphResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComputationMorseResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComputationMorseResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO AbstractComputationEvent_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO AbstractComputationEvent_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO AbstractEvent_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO AbstractEvent_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGroupNode_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGroupNode_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComponentRegistrar_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComponentRegistrar_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComputationGraphResultExt_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComputationGraphResultExt_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IFunctionEvents_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IFunctionEvents_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IFunction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IFunction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernelEvents_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernelEvents_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernel_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernel_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IMorseSpectrum_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IMorseSpectrum_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IProjectiveBundle_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IProjectiveBundle_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IProjectiveBundleEvents_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IProjectiveBundleEvents_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISymbolicImage_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISymbolicImage_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISymbolicImageEvents_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISymbolicImageEvents_ProxyInfo;


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


	/* Procedure graphDimension */


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


	/* Parameter value */


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

	/* Procedure get_upperLength */


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

	/* Procedure graphInfo */

/* 366 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 368 */	NdrFcLong( 0x0 ),	/* 0 */
/* 372 */	NdrFcShort( 0x8 ),	/* 8 */
/* 374 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 376 */	NdrFcShort( 0x0 ),	/* 0 */
/* 378 */	NdrFcShort( 0x8 ),	/* 8 */
/* 380 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 382 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 384 */	NdrFcShort( 0x0 ),	/* 0 */
/* 386 */	NdrFcShort( 0x0 ),	/* 0 */
/* 388 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter info */

/* 390 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 392 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 394 */	NdrFcShort( 0xa ),	/* Type Offset=10 */

	/* Return value */

/* 396 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 398 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 400 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Subdevide */

/* 402 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 404 */	NdrFcLong( 0x0 ),	/* 0 */
/* 408 */	NdrFcShort( 0x7 ),	/* 7 */
/* 410 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 412 */	NdrFcShort( 0x0 ),	/* 0 */
/* 414 */	NdrFcShort( 0x8 ),	/* 8 */
/* 416 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 418 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 420 */	NdrFcShort( 0x0 ),	/* 0 */
/* 422 */	NdrFcShort( 0x0 ),	/* 0 */
/* 424 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter params */

/* 426 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 428 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 430 */	NdrFcShort( 0x20 ),	/* Type Offset=32 */

	/* Return value */

/* 432 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 434 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 436 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SubdevidePoint */

/* 438 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 440 */	NdrFcLong( 0x0 ),	/* 0 */
/* 444 */	NdrFcShort( 0x7 ),	/* 7 */
/* 446 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 448 */	NdrFcShort( 0x0 ),	/* 0 */
/* 450 */	NdrFcShort( 0x8 ),	/* 8 */
/* 452 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 454 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 456 */	NdrFcShort( 0x0 ),	/* 0 */
/* 458 */	NdrFcShort( 0x0 ),	/* 0 */
/* 460 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter params */

/* 462 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 464 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 466 */	NdrFcShort( 0x32 ),	/* Type Offset=50 */

	/* Return value */

/* 468 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 470 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 472 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Extend */

/* 474 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 476 */	NdrFcLong( 0x0 ),	/* 0 */
/* 480 */	NdrFcShort( 0x7 ),	/* 7 */
/* 482 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 484 */	NdrFcShort( 0x0 ),	/* 0 */
/* 486 */	NdrFcShort( 0x8 ),	/* 8 */
/* 488 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 490 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 492 */	NdrFcShort( 0x0 ),	/* 0 */
/* 494 */	NdrFcShort( 0x0 ),	/* 0 */
/* 496 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter params */

/* 498 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 500 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 502 */	NdrFcShort( 0x44 ),	/* Type Offset=68 */

	/* Return value */

/* 504 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 506 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 508 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure NewDimension */

/* 510 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 512 */	NdrFcLong( 0x0 ),	/* 0 */
/* 516 */	NdrFcShort( 0x8 ),	/* 8 */
/* 518 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 520 */	NdrFcShort( 0x0 ),	/* 0 */
/* 522 */	NdrFcShort( 0x24 ),	/* 36 */
/* 524 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 526 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 528 */	NdrFcShort( 0x0 ),	/* 0 */
/* 530 */	NdrFcShort( 0x0 ),	/* 0 */
/* 532 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 534 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 536 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 538 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 540 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 542 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 544 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Morse */

/* 546 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 548 */	NdrFcLong( 0x0 ),	/* 0 */
/* 552 */	NdrFcShort( 0x3 ),	/* 3 */
/* 554 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 556 */	NdrFcShort( 0x0 ),	/* 0 */
/* 558 */	NdrFcShort( 0x8 ),	/* 8 */
/* 560 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 562 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 564 */	NdrFcShort( 0x0 ),	/* 0 */
/* 566 */	NdrFcShort( 0x0 ),	/* 0 */
/* 568 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 570 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 572 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 574 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure InternalException */


	/* Procedure FunctionWrongInput */


	/* Procedure Attach */


	/* Procedure ExportData */

/* 576 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 578 */	NdrFcLong( 0x0 ),	/* 0 */
/* 582 */	NdrFcShort( 0x7 ),	/* 7 */
/* 584 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 586 */	NdrFcShort( 0x0 ),	/* 0 */
/* 588 */	NdrFcShort( 0x8 ),	/* 8 */
/* 590 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 592 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 594 */	NdrFcShort( 0x0 ),	/* 0 */
/* 596 */	NdrFcShort( 0x1 ),	/* 1 */
/* 598 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter message */


	/* Parameter description */


	/* Parameter bstrPath */


	/* Parameter file */

/* 600 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 602 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 604 */	NdrFcShort( 0x70 ),	/* Type Offset=112 */

	/* Return value */


	/* Return value */


	/* Return value */


	/* Return value */

/* 606 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 608 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 610 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure noChilds */


	/* Procedure toResult */


	/* Procedure StrongComponents */

/* 612 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 614 */	NdrFcLong( 0x0 ),	/* 0 */
/* 618 */	NdrFcShort( 0x7 ),	/* 7 */
/* 620 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 622 */	NdrFcShort( 0x0 ),	/* 0 */
/* 624 */	NdrFcShort( 0x8 ),	/* 8 */
/* 626 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 628 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 630 */	NdrFcShort( 0x0 ),	/* 0 */
/* 632 */	NdrFcShort( 0x0 ),	/* 0 */
/* 634 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 636 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 638 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 640 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterAll */


	/* Procedure noImplementation */


	/* Procedure StrongComponentsEdges */

/* 642 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 644 */	NdrFcLong( 0x0 ),	/* 0 */
/* 648 */	NdrFcShort( 0x8 ),	/* 8 */
/* 650 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 652 */	NdrFcShort( 0x0 ),	/* 0 */
/* 654 */	NdrFcShort( 0x8 ),	/* 8 */
/* 656 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 658 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 660 */	NdrFcShort( 0x0 ),	/* 0 */
/* 662 */	NdrFcShort( 0x0 ),	/* 0 */
/* 664 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 666 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 668 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 670 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure FunctionAccepted */


	/* Procedure UnregisterAll */


	/* Procedure noImplementation */


	/* Procedure Loops */

/* 672 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 674 */	NdrFcLong( 0x0 ),	/* 0 */
/* 678 */	NdrFcShort( 0x9 ),	/* 9 */
/* 680 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 682 */	NdrFcShort( 0x0 ),	/* 0 */
/* 684 */	NdrFcShort( 0x8 ),	/* 8 */
/* 686 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 688 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 690 */	NdrFcShort( 0x0 ),	/* 0 */
/* 692 */	NdrFcShort( 0x0 ),	/* 0 */
/* 694 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */


	/* Return value */

/* 696 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 698 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 700 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure newComputationResult */

/* 702 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 704 */	NdrFcLong( 0x0 ),	/* 0 */
/* 708 */	NdrFcShort( 0x7 ),	/* 7 */
/* 710 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 712 */	NdrFcShort( 0x0 ),	/* 0 */
/* 714 */	NdrFcShort( 0x8 ),	/* 8 */
/* 716 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 718 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 720 */	NdrFcShort( 0x0 ),	/* 0 */
/* 722 */	NdrFcShort( 0x0 ),	/* 0 */
/* 724 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 726 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 728 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 730 */	NdrFcShort( 0x7a ),	/* Type Offset=122 */

	/* Return value */

/* 732 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 734 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 736 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure newKernelNode */

/* 738 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 740 */	NdrFcLong( 0x0 ),	/* 0 */
/* 744 */	NdrFcShort( 0x8 ),	/* 8 */
/* 746 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 748 */	NdrFcShort( 0x0 ),	/* 0 */
/* 750 */	NdrFcShort( 0x8 ),	/* 8 */
/* 752 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 754 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 756 */	NdrFcShort( 0x0 ),	/* 0 */
/* 758 */	NdrFcShort( 0x0 ),	/* 0 */
/* 760 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 762 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 764 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 766 */	NdrFcShort( 0x8c ),	/* Type Offset=140 */

	/* Return value */

/* 768 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 770 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 772 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure noChilds */

/* 774 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 776 */	NdrFcLong( 0x0 ),	/* 0 */
/* 780 */	NdrFcShort( 0xa ),	/* 10 */
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

	/* Procedure GetComponents */

/* 804 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 806 */	NdrFcLong( 0x0 ),	/* 0 */
/* 810 */	NdrFcShort( 0xa ),	/* 10 */
/* 812 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 814 */	NdrFcShort( 0x0 ),	/* 0 */
/* 816 */	NdrFcShort( 0x8 ),	/* 8 */
/* 818 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 820 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 822 */	NdrFcShort( 0x24 ),	/* 36 */
/* 824 */	NdrFcShort( 0x0 ),	/* 0 */
/* 826 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pbstrCLSIDs */

/* 828 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 830 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 832 */	NdrFcShort( 0x496 ),	/* Type Offset=1174 */

	/* Parameter pbstrDescriptions */

/* 834 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 836 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 838 */	NdrFcShort( 0x496 ),	/* Type Offset=1174 */

	/* Return value */

/* 840 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 842 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 844 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterComponent */

/* 846 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 848 */	NdrFcLong( 0x0 ),	/* 0 */
/* 852 */	NdrFcShort( 0xb ),	/* 11 */
/* 854 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 856 */	NdrFcShort( 0x0 ),	/* 0 */
/* 858 */	NdrFcShort( 0x8 ),	/* 8 */
/* 860 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 862 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 864 */	NdrFcShort( 0x0 ),	/* 0 */
/* 866 */	NdrFcShort( 0x1 ),	/* 1 */
/* 868 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 870 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 872 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 874 */	NdrFcShort( 0x70 ),	/* Type Offset=112 */

	/* Return value */

/* 876 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 878 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 880 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterComponent */

/* 882 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 884 */	NdrFcLong( 0x0 ),	/* 0 */
/* 888 */	NdrFcShort( 0xc ),	/* 12 */
/* 890 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 892 */	NdrFcShort( 0x0 ),	/* 0 */
/* 894 */	NdrFcShort( 0x8 ),	/* 8 */
/* 896 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 898 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 900 */	NdrFcShort( 0x0 ),	/* 0 */
/* 902 */	NdrFcShort( 0x1 ),	/* 1 */
/* 904 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 906 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 908 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 910 */	NdrFcShort( 0x70 ),	/* Type Offset=112 */

	/* Return value */

/* 912 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 914 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 916 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure FunctionChanged */

/* 918 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 920 */	NdrFcLong( 0x0 ),	/* 0 */
/* 924 */	NdrFcShort( 0x8 ),	/* 8 */
/* 926 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 928 */	NdrFcShort( 0x0 ),	/* 0 */
/* 930 */	NdrFcShort( 0x8 ),	/* 8 */
/* 932 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 934 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 936 */	NdrFcShort( 0x0 ),	/* 0 */
/* 938 */	NdrFcShort( 0x2 ),	/* 2 */
/* 940 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter oldFunction */

/* 942 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 944 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 946 */	NdrFcShort( 0x70 ),	/* Type Offset=112 */

	/* Parameter newFunction */

/* 948 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 950 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 952 */	NdrFcShort( 0x70 ),	/* Type Offset=112 */

	/* Return value */

/* 954 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 956 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 958 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_SystemSource */

/* 960 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 962 */	NdrFcLong( 0x0 ),	/* 0 */
/* 966 */	NdrFcShort( 0x7 ),	/* 7 */
/* 968 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 970 */	NdrFcShort( 0x0 ),	/* 0 */
/* 972 */	NdrFcShort( 0x8 ),	/* 8 */
/* 974 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 976 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 978 */	NdrFcShort( 0x1 ),	/* 1 */
/* 980 */	NdrFcShort( 0x0 ),	/* 0 */
/* 982 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 984 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 986 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 988 */	NdrFcShort( 0x4a4 ),	/* Type Offset=1188 */

	/* Return value */

/* 990 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 992 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 994 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_SystemSource */

/* 996 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 998 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1002 */	NdrFcShort( 0x8 ),	/* 8 */
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

	/* Parameter newVal */

/* 1020 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1022 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1024 */	NdrFcShort( 0x70 ),	/* Type Offset=112 */

	/* Return value */

/* 1026 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1028 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1030 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure KernelFunctionChanged */

/* 1032 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1034 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1038 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1040 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1042 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1044 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1046 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1048 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1050 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1052 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1054 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter oldFunction */

/* 1056 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1058 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1060 */	NdrFcShort( 0x4ae ),	/* Type Offset=1198 */

	/* Parameter newFunction */

/* 1062 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1064 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1066 */	NdrFcShort( 0x4ae ),	/* Type Offset=1198 */

	/* Return value */

/* 1068 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1070 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1072 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_Function */

/* 1074 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1076 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1080 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1082 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1084 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1086 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1088 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1090 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1092 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1094 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1096 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1098 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1100 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1102 */	NdrFcShort( 0x4c0 ),	/* Type Offset=1216 */

	/* Return value */

/* 1104 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1106 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1108 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure putref_Function */

/* 1110 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1112 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1116 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1118 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1120 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1122 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1124 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1126 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1128 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1130 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1132 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1134 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1136 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1138 */	NdrFcShort( 0x4ae ),	/* Type Offset=1198 */

	/* Return value */

/* 1140 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1142 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1144 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateRootSymbolicImage */

/* 1146 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1148 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1152 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1154 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1156 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1158 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1160 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1162 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1164 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1166 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1168 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1170 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1172 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1174 */	NdrFcShort( 0x4c4 ),	/* Type Offset=1220 */

	/* Return value */

/* 1176 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1178 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1180 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateSymbolicImageGroup */

/* 1182 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1184 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1188 */	NdrFcShort( 0xa ),	/* 10 */
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

	/* Parameter node */

/* 1206 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1208 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1210 */	NdrFcShort( 0x4c4 ),	/* Type Offset=1220 */

	/* Return value */

/* 1212 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1214 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1216 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateProjectiveBundleGroup */

/* 1218 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1220 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1224 */	NdrFcShort( 0xb ),	/* 11 */
/* 1226 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1228 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1230 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1232 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1234 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1236 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1238 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1240 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 1242 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1244 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1246 */	NdrFcShort( 0x4c4 ),	/* Type Offset=1220 */

	/* Return value */

/* 1248 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1250 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1252 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_lowerBound */

/* 1254 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1256 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1260 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1262 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1264 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1266 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1268 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1270 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1272 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1274 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1276 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1278 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1280 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1282 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1284 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1286 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1288 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_lowerBound */

/* 1290 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1292 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1296 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1298 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1300 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1302 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1304 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1306 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1308 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1310 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1312 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1314 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1316 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1318 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1320 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1322 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1324 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_upperBound */

/* 1326 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1328 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1332 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1334 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1336 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1338 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1340 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1342 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1344 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1346 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1348 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1350 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1352 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1354 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1356 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1358 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1360 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_upperBound */

/* 1362 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1364 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1368 */	NdrFcShort( 0xa ),	/* 10 */
/* 1370 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1372 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1374 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1376 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1378 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1380 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1382 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1384 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1386 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1388 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1390 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1392 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1394 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1396 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_lowerLength */

/* 1398 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1400 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1404 */	NdrFcShort( 0xb ),	/* 11 */
/* 1406 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1408 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1410 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1412 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1414 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1416 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1418 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1420 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1422 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1424 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1426 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1428 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1430 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1432 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_lowerLength */

/* 1434 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1436 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1440 */	NdrFcShort( 0xc ),	/* 12 */
/* 1442 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1444 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1446 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1448 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1450 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1452 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1454 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1456 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1458 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1460 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1462 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1464 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1466 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1468 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_upperLength */

/* 1470 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1472 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1476 */	NdrFcShort( 0xe ),	/* 14 */
/* 1478 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1480 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1482 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1484 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1486 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1488 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1490 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1492 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1494 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1496 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1498 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1500 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1502 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1504 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_kernel */

/* 1506 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1508 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1512 */	NdrFcShort( 0xa ),	/* 10 */
/* 1514 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1516 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1518 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1520 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1522 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1524 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1526 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1528 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1530 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1532 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1534 */	NdrFcShort( 0x4c8 ),	/* Type Offset=1224 */

	/* Return value */

/* 1536 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1538 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1540 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure putref_kernel */

/* 1542 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1544 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1548 */	NdrFcShort( 0xb ),	/* 11 */
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

	/* Parameter newVal */

/* 1566 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1568 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1570 */	NdrFcShort( 0x4cc ),	/* Type Offset=1228 */

	/* Return value */

/* 1572 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1574 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1576 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure newChildProjectiveBundle */

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
			0x1,		/* Ext Flags:  new corr desc, */
/* 1596 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1598 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1600 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pb */

/* 1602 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1604 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1606 */	NdrFcShort( 0x4de ),	/* Type Offset=1246 */

	/* Return value */

/* 1608 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1610 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1612 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure newChildMorseSpectrum */

/* 1614 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1616 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1620 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1622 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1624 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1626 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1628 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1630 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1632 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1634 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1636 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter ms */

/* 1638 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1640 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1642 */	NdrFcShort( 0x4f0 ),	/* Type Offset=1264 */

	/* Return value */

/* 1644 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1646 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1648 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_kernel */

/* 1650 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1652 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1656 */	NdrFcShort( 0xa ),	/* 10 */
/* 1658 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1660 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1662 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1664 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1666 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1668 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1670 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1672 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1674 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1676 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1678 */	NdrFcShort( 0x502 ),	/* Type Offset=1282 */

	/* Return value */

/* 1680 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1682 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1684 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure putref_kernel */

/* 1686 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1688 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1692 */	NdrFcShort( 0xb ),	/* 11 */
/* 1694 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1696 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1698 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1700 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1702 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1704 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1706 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1708 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1710 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1712 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1714 */	NdrFcShort( 0x506 ),	/* Type Offset=1286 */

	/* Return value */

/* 1716 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1718 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1720 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure newChildSymbolicImage */

/* 1722 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1724 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1728 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1730 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1732 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1734 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1736 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1738 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1740 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1742 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1744 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter image */

/* 1746 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1748 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1750 */	NdrFcShort( 0x518 ),	/* Type Offset=1304 */

	/* Return value */

/* 1752 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1754 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1756 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure newChildProjectiveBundle */

/* 1758 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1760 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1764 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1766 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1768 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1770 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1772 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1774 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1776 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1778 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1780 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bundle */

/* 1782 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1784 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1786 */	NdrFcShort( 0x4de ),	/* Type Offset=1246 */

	/* Return value */

/* 1788 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1790 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1792 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure addNode */

/* 1794 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1796 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1800 */	NdrFcShort( 0xc ),	/* 12 */
/* 1802 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1804 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1806 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1808 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1810 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1812 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1814 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1816 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter img */

/* 1818 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1820 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1822 */	NdrFcShort( 0x52a ),	/* Type Offset=1322 */

	/* Return value */

/* 1824 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1826 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1828 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure removeNode */

/* 1830 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1832 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1836 */	NdrFcShort( 0xd ),	/* 13 */
/* 1838 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1840 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1842 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1844 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1846 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1848 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1850 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1852 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter img */

/* 1854 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1856 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1858 */	NdrFcShort( 0x52a ),	/* Type Offset=1322 */

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

	/* Parameter bn */

/* 1890 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1892 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1894 */	NdrFcShort( 0x53c ),	/* Type Offset=1340 */

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
/* 1930 */	NdrFcShort( 0x53c ),	/* Type Offset=1340 */

	/* Return value */

/* 1932 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1934 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1936 */	0x8,		/* FC_LONG */
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
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 12 */	NdrFcShort( 0x2 ),	/* Offset= 2 (14) */
/* 14 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 16 */	NdrFcLong( 0xce2b6190 ),	/* -836017776 */
/* 20 */	NdrFcShort( 0xcbc5 ),	/* -13371 */
/* 22 */	NdrFcShort( 0x4104 ),	/* 16644 */
/* 24 */	0xa0,		/* 160 */
			0xe0,		/* 224 */
/* 26 */	0xd7,		/* 215 */
			0xb3,		/* 179 */
/* 28 */	0xfe,		/* 254 */
			0x56,		/* 86 */
/* 30 */	0x78,		/* 120 */
			0x67,		/* 103 */
/* 32 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 34 */	NdrFcLong( 0xf8ed2fd5 ),	/* -118673451 */
/* 38 */	NdrFcShort( 0xc65c ),	/* -14756 */
/* 40 */	NdrFcShort( 0x4c11 ),	/* 19473 */
/* 42 */	0xab,		/* 171 */
			0xd0,		/* 208 */
/* 44 */	0x6d,		/* 109 */
			0xc5,		/* 197 */
/* 46 */	0x3a,		/* 58 */
			0x7f,		/* 127 */
/* 48 */	0x5,		/* 5 */
			0xcd,		/* 205 */
/* 50 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 52 */	NdrFcLong( 0xe6f9519f ),	/* -419868257 */
/* 56 */	NdrFcShort( 0x6bf8 ),	/* 27640 */
/* 58 */	NdrFcShort( 0x45e0 ),	/* 17888 */
/* 60 */	0xac,		/* 172 */
			0xa2,		/* 162 */
/* 62 */	0x4e,		/* 78 */
			0x71,		/* 113 */
/* 64 */	0xf,		/* 15 */
			0x23,		/* 35 */
/* 66 */	0xf8,		/* 248 */
			0xc,		/* 12 */
/* 68 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 70 */	NdrFcLong( 0xcc76b166 ),	/* -864636570 */
/* 74 */	NdrFcShort( 0x5482 ),	/* 21634 */
/* 76 */	NdrFcShort( 0x4ea8 ),	/* 20136 */
/* 78 */	0x97,		/* 151 */
			0x7d,		/* 125 */
/* 80 */	0xd4,		/* 212 */
			0x70,		/* 112 */
/* 82 */	0x5,		/* 5 */
			0xf2,		/* 242 */
/* 84 */	0xbb,		/* 187 */
			0x17,		/* 23 */
/* 86 */	
			0x12, 0x0,	/* FC_UP */
/* 88 */	NdrFcShort( 0xe ),	/* Offset= 14 (102) */
/* 90 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 92 */	NdrFcShort( 0x2 ),	/* 2 */
/* 94 */	0x9,		/* Corr desc: FC_ULONG */
			0x0,		/*  */
/* 96 */	NdrFcShort( 0xfffc ),	/* -4 */
/* 98 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 100 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 102 */	
			0x17,		/* FC_CSTRUCT */
			0x3,		/* 3 */
/* 104 */	NdrFcShort( 0x8 ),	/* 8 */
/* 106 */	NdrFcShort( 0xfff0 ),	/* Offset= -16 (90) */
/* 108 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 110 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 112 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 114 */	NdrFcShort( 0x0 ),	/* 0 */
/* 116 */	NdrFcShort( 0x4 ),	/* 4 */
/* 118 */	NdrFcShort( 0x0 ),	/* 0 */
/* 120 */	NdrFcShort( 0xffde ),	/* Offset= -34 (86) */
/* 122 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 124 */	NdrFcLong( 0xea038030 ),	/* -368869328 */
/* 128 */	NdrFcShort( 0x124f ),	/* 4687 */
/* 130 */	NdrFcShort( 0x4f15 ),	/* 20245 */
/* 132 */	0xac,		/* 172 */
			0xd4,		/* 212 */
/* 134 */	0xe0,		/* 224 */
			0x50,		/* 80 */
/* 136 */	0xc,		/* 12 */
			0x51,		/* 81 */
/* 138 */	0x10,		/* 16 */
			0xa3,		/* 163 */
/* 140 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 142 */	NdrFcLong( 0xe7a4dbc7 ),	/* -408626233 */
/* 146 */	NdrFcShort( 0x26f3 ),	/* 9971 */
/* 148 */	NdrFcShort( 0x487b ),	/* 18555 */
/* 150 */	0x9e,		/* 158 */
			0xad,		/* 173 */
/* 152 */	0xe2,		/* 226 */
			0xa7,		/* 167 */
/* 154 */	0xf6,		/* 246 */
			0xaf,		/* 175 */
/* 156 */	0x82,		/* 130 */
			0xe1,		/* 225 */
/* 158 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 160 */	NdrFcShort( 0x3f6 ),	/* Offset= 1014 (1174) */
/* 162 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 164 */	NdrFcShort( 0x2 ),	/* Offset= 2 (166) */
/* 166 */	
			0x13, 0x0,	/* FC_OP */
/* 168 */	NdrFcShort( 0x3dc ),	/* Offset= 988 (1156) */
/* 170 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x49,		/* 73 */
/* 172 */	NdrFcShort( 0x18 ),	/* 24 */
/* 174 */	NdrFcShort( 0xa ),	/* 10 */
/* 176 */	NdrFcLong( 0x8 ),	/* 8 */
/* 180 */	NdrFcShort( 0x5a ),	/* Offset= 90 (270) */
/* 182 */	NdrFcLong( 0xd ),	/* 13 */
/* 186 */	NdrFcShort( 0x90 ),	/* Offset= 144 (330) */
/* 188 */	NdrFcLong( 0x9 ),	/* 9 */
/* 192 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (386) */
/* 194 */	NdrFcLong( 0xc ),	/* 12 */
/* 198 */	NdrFcShort( 0x2c0 ),	/* Offset= 704 (902) */
/* 200 */	NdrFcLong( 0x24 ),	/* 36 */
/* 204 */	NdrFcShort( 0x2ea ),	/* Offset= 746 (950) */
/* 206 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 210 */	NdrFcShort( 0x306 ),	/* Offset= 774 (984) */
/* 212 */	NdrFcLong( 0x10 ),	/* 16 */
/* 216 */	NdrFcShort( 0x320 ),	/* Offset= 800 (1016) */
/* 218 */	NdrFcLong( 0x2 ),	/* 2 */
/* 222 */	NdrFcShort( 0x33a ),	/* Offset= 826 (1048) */
/* 224 */	NdrFcLong( 0x3 ),	/* 3 */
/* 228 */	NdrFcShort( 0x354 ),	/* Offset= 852 (1080) */
/* 230 */	NdrFcLong( 0x14 ),	/* 20 */
/* 234 */	NdrFcShort( 0x36e ),	/* Offset= 878 (1112) */
/* 236 */	NdrFcShort( 0xffff ),	/* Offset= -1 (235) */
/* 238 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 240 */	NdrFcShort( 0x4 ),	/* 4 */
/* 242 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 244 */	NdrFcShort( 0x0 ),	/* 0 */
/* 246 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 248 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 250 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 252 */	NdrFcShort( 0x4 ),	/* 4 */
/* 254 */	NdrFcShort( 0x0 ),	/* 0 */
/* 256 */	NdrFcShort( 0x1 ),	/* 1 */
/* 258 */	NdrFcShort( 0x0 ),	/* 0 */
/* 260 */	NdrFcShort( 0x0 ),	/* 0 */
/* 262 */	0x13, 0x0,	/* FC_OP */
/* 264 */	NdrFcShort( 0xff5e ),	/* Offset= -162 (102) */
/* 266 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 268 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 270 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 272 */	NdrFcShort( 0x8 ),	/* 8 */
/* 274 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 276 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 278 */	NdrFcShort( 0x4 ),	/* 4 */
/* 280 */	NdrFcShort( 0x4 ),	/* 4 */
/* 282 */	0x11, 0x0,	/* FC_RP */
/* 284 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (238) */
/* 286 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 288 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 290 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 292 */	NdrFcLong( 0x0 ),	/* 0 */
/* 296 */	NdrFcShort( 0x0 ),	/* 0 */
/* 298 */	NdrFcShort( 0x0 ),	/* 0 */
/* 300 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 302 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 304 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 306 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 308 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 310 */	NdrFcShort( 0x0 ),	/* 0 */
/* 312 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 314 */	NdrFcShort( 0x0 ),	/* 0 */
/* 316 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 318 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 322 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 324 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 326 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (290) */
/* 328 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 330 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 332 */	NdrFcShort( 0x8 ),	/* 8 */
/* 334 */	NdrFcShort( 0x0 ),	/* 0 */
/* 336 */	NdrFcShort( 0x6 ),	/* Offset= 6 (342) */
/* 338 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 340 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 342 */	
			0x11, 0x0,	/* FC_RP */
/* 344 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (308) */
/* 346 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 348 */	NdrFcLong( 0x20400 ),	/* 132096 */
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
			0x2b,		/* FC_NON_ENCAPSULATED_UNION */
			0x9,		/* FC_ULONG */
/* 404 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 406 */	NdrFcShort( 0xfff8 ),	/* -8 */
/* 408 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 410 */	NdrFcShort( 0x2 ),	/* Offset= 2 (412) */
/* 412 */	NdrFcShort( 0x10 ),	/* 16 */
/* 414 */	NdrFcShort( 0x2f ),	/* 47 */
/* 416 */	NdrFcLong( 0x14 ),	/* 20 */
/* 420 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 422 */	NdrFcLong( 0x3 ),	/* 3 */
/* 426 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 428 */	NdrFcLong( 0x11 ),	/* 17 */
/* 432 */	NdrFcShort( 0x8001 ),	/* Simple arm type: FC_BYTE */
/* 434 */	NdrFcLong( 0x2 ),	/* 2 */
/* 438 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 440 */	NdrFcLong( 0x4 ),	/* 4 */
/* 444 */	NdrFcShort( 0x800a ),	/* Simple arm type: FC_FLOAT */
/* 446 */	NdrFcLong( 0x5 ),	/* 5 */
/* 450 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 452 */	NdrFcLong( 0xb ),	/* 11 */
/* 456 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 458 */	NdrFcLong( 0xa ),	/* 10 */
/* 462 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 464 */	NdrFcLong( 0x6 ),	/* 6 */
/* 468 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (700) */
/* 470 */	NdrFcLong( 0x7 ),	/* 7 */
/* 474 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 476 */	NdrFcLong( 0x8 ),	/* 8 */
/* 480 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (706) */
/* 482 */	NdrFcLong( 0xd ),	/* 13 */
/* 486 */	NdrFcShort( 0xff3c ),	/* Offset= -196 (290) */
/* 488 */	NdrFcLong( 0x9 ),	/* 9 */
/* 492 */	NdrFcShort( 0xff6e ),	/* Offset= -146 (346) */
/* 494 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 498 */	NdrFcShort( 0xd4 ),	/* Offset= 212 (710) */
/* 500 */	NdrFcLong( 0x24 ),	/* 36 */
/* 504 */	NdrFcShort( 0xd6 ),	/* Offset= 214 (718) */
/* 506 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 510 */	NdrFcShort( 0xd0 ),	/* Offset= 208 (718) */
/* 512 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 516 */	NdrFcShort( 0x100 ),	/* Offset= 256 (772) */
/* 518 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 522 */	NdrFcShort( 0xfe ),	/* Offset= 254 (776) */
/* 524 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 528 */	NdrFcShort( 0xfc ),	/* Offset= 252 (780) */
/* 530 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 534 */	NdrFcShort( 0xfa ),	/* Offset= 250 (784) */
/* 536 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 540 */	NdrFcShort( 0xf8 ),	/* Offset= 248 (788) */
/* 542 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 546 */	NdrFcShort( 0xf6 ),	/* Offset= 246 (792) */
/* 548 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 552 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (776) */
/* 554 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 558 */	NdrFcShort( 0xde ),	/* Offset= 222 (780) */
/* 560 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 564 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (796) */
/* 566 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 570 */	NdrFcShort( 0xde ),	/* Offset= 222 (792) */
/* 572 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 576 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (800) */
/* 578 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 582 */	NdrFcShort( 0xde ),	/* Offset= 222 (804) */
/* 584 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 588 */	NdrFcShort( 0xdc ),	/* Offset= 220 (808) */
/* 590 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 594 */	NdrFcShort( 0xda ),	/* Offset= 218 (812) */
/* 596 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 600 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (824) */
/* 602 */	NdrFcLong( 0x10 ),	/* 16 */
/* 606 */	NdrFcShort( 0x8002 ),	/* Simple arm type: FC_CHAR */
/* 608 */	NdrFcLong( 0x12 ),	/* 18 */
/* 612 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 614 */	NdrFcLong( 0x13 ),	/* 19 */
/* 618 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 620 */	NdrFcLong( 0x15 ),	/* 21 */
/* 624 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 626 */	NdrFcLong( 0x16 ),	/* 22 */
/* 630 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 632 */	NdrFcLong( 0x17 ),	/* 23 */
/* 636 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 638 */	NdrFcLong( 0xe ),	/* 14 */
/* 642 */	NdrFcShort( 0xbe ),	/* Offset= 190 (832) */
/* 644 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 648 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (842) */
/* 650 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 654 */	NdrFcShort( 0xc0 ),	/* Offset= 192 (846) */
/* 656 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 660 */	NdrFcShort( 0x74 ),	/* Offset= 116 (776) */
/* 662 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 666 */	NdrFcShort( 0x72 ),	/* Offset= 114 (780) */
/* 668 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 672 */	NdrFcShort( 0x70 ),	/* Offset= 112 (784) */
/* 674 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 678 */	NdrFcShort( 0x66 ),	/* Offset= 102 (780) */
/* 680 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 684 */	NdrFcShort( 0x60 ),	/* Offset= 96 (780) */
/* 686 */	NdrFcLong( 0x0 ),	/* 0 */
/* 690 */	NdrFcShort( 0x0 ),	/* Offset= 0 (690) */
/* 692 */	NdrFcLong( 0x1 ),	/* 1 */
/* 696 */	NdrFcShort( 0x0 ),	/* Offset= 0 (696) */
/* 698 */	NdrFcShort( 0xffff ),	/* Offset= -1 (697) */
/* 700 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 702 */	NdrFcShort( 0x8 ),	/* 8 */
/* 704 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 706 */	
			0x13, 0x0,	/* FC_OP */
/* 708 */	NdrFcShort( 0xfda2 ),	/* Offset= -606 (102) */
/* 710 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 712 */	NdrFcShort( 0x2 ),	/* Offset= 2 (714) */
/* 714 */	
			0x13, 0x0,	/* FC_OP */
/* 716 */	NdrFcShort( 0x1b8 ),	/* Offset= 440 (1156) */
/* 718 */	
			0x13, 0x0,	/* FC_OP */
/* 720 */	NdrFcShort( 0x20 ),	/* Offset= 32 (752) */
/* 722 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 724 */	NdrFcLong( 0x2f ),	/* 47 */
/* 728 */	NdrFcShort( 0x0 ),	/* 0 */
/* 730 */	NdrFcShort( 0x0 ),	/* 0 */
/* 732 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 734 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 736 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 738 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 740 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 742 */	NdrFcShort( 0x1 ),	/* 1 */
/* 744 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 746 */	NdrFcShort( 0x4 ),	/* 4 */
/* 748 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 750 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 752 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 754 */	NdrFcShort( 0x10 ),	/* 16 */
/* 756 */	NdrFcShort( 0x0 ),	/* 0 */
/* 758 */	NdrFcShort( 0xa ),	/* Offset= 10 (768) */
/* 760 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 762 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 764 */	NdrFcShort( 0xffd6 ),	/* Offset= -42 (722) */
/* 766 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 768 */	
			0x13, 0x0,	/* FC_OP */
/* 770 */	NdrFcShort( 0xffe2 ),	/* Offset= -30 (740) */
/* 772 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 774 */	0x1,		/* FC_BYTE */
			0x5c,		/* FC_PAD */
/* 776 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 778 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 780 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 782 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 784 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 786 */	0xb,		/* FC_HYPER */
			0x5c,		/* FC_PAD */
/* 788 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 790 */	0xa,		/* FC_FLOAT */
			0x5c,		/* FC_PAD */
/* 792 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 794 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 796 */	
			0x13, 0x0,	/* FC_OP */
/* 798 */	NdrFcShort( 0xff9e ),	/* Offset= -98 (700) */
/* 800 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 802 */	NdrFcShort( 0xffa0 ),	/* Offset= -96 (706) */
/* 804 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 806 */	NdrFcShort( 0xfdfc ),	/* Offset= -516 (290) */
/* 808 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 810 */	NdrFcShort( 0xfe30 ),	/* Offset= -464 (346) */
/* 812 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 814 */	NdrFcShort( 0x2 ),	/* Offset= 2 (816) */
/* 816 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 818 */	NdrFcShort( 0x2 ),	/* Offset= 2 (820) */
/* 820 */	
			0x13, 0x0,	/* FC_OP */
/* 822 */	NdrFcShort( 0x14e ),	/* Offset= 334 (1156) */
/* 824 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 826 */	NdrFcShort( 0x2 ),	/* Offset= 2 (828) */
/* 828 */	
			0x13, 0x0,	/* FC_OP */
/* 830 */	NdrFcShort( 0x14 ),	/* Offset= 20 (850) */
/* 832 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 834 */	NdrFcShort( 0x10 ),	/* 16 */
/* 836 */	0x6,		/* FC_SHORT */
			0x1,		/* FC_BYTE */
/* 838 */	0x1,		/* FC_BYTE */
			0x8,		/* FC_LONG */
/* 840 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 842 */	
			0x13, 0x0,	/* FC_OP */
/* 844 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (832) */
/* 846 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 848 */	0x2,		/* FC_CHAR */
			0x5c,		/* FC_PAD */
/* 850 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x7,		/* 7 */
/* 852 */	NdrFcShort( 0x20 ),	/* 32 */
/* 854 */	NdrFcShort( 0x0 ),	/* 0 */
/* 856 */	NdrFcShort( 0x0 ),	/* Offset= 0 (856) */
/* 858 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 860 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 862 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 864 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 866 */	NdrFcShort( 0xfe30 ),	/* Offset= -464 (402) */
/* 868 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 870 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 872 */	NdrFcShort( 0x4 ),	/* 4 */
/* 874 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 876 */	NdrFcShort( 0x0 ),	/* 0 */
/* 878 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 880 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 882 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 884 */	NdrFcShort( 0x4 ),	/* 4 */
/* 886 */	NdrFcShort( 0x0 ),	/* 0 */
/* 888 */	NdrFcShort( 0x1 ),	/* 1 */
/* 890 */	NdrFcShort( 0x0 ),	/* 0 */
/* 892 */	NdrFcShort( 0x0 ),	/* 0 */
/* 894 */	0x13, 0x0,	/* FC_OP */
/* 896 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (850) */
/* 898 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 900 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 902 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 904 */	NdrFcShort( 0x8 ),	/* 8 */
/* 906 */	NdrFcShort( 0x0 ),	/* 0 */
/* 908 */	NdrFcShort( 0x6 ),	/* Offset= 6 (914) */
/* 910 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 912 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 914 */	
			0x11, 0x0,	/* FC_RP */
/* 916 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (870) */
/* 918 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 920 */	NdrFcShort( 0x4 ),	/* 4 */
/* 922 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 924 */	NdrFcShort( 0x0 ),	/* 0 */
/* 926 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 928 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 930 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 932 */	NdrFcShort( 0x4 ),	/* 4 */
/* 934 */	NdrFcShort( 0x0 ),	/* 0 */
/* 936 */	NdrFcShort( 0x1 ),	/* 1 */
/* 938 */	NdrFcShort( 0x0 ),	/* 0 */
/* 940 */	NdrFcShort( 0x0 ),	/* 0 */
/* 942 */	0x13, 0x0,	/* FC_OP */
/* 944 */	NdrFcShort( 0xff40 ),	/* Offset= -192 (752) */
/* 946 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 948 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 950 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 952 */	NdrFcShort( 0x8 ),	/* 8 */
/* 954 */	NdrFcShort( 0x0 ),	/* 0 */
/* 956 */	NdrFcShort( 0x6 ),	/* Offset= 6 (962) */
/* 958 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 960 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 962 */	
			0x11, 0x0,	/* FC_RP */
/* 964 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (918) */
/* 966 */	
			0x1d,		/* FC_SMFARRAY */
			0x0,		/* 0 */
/* 968 */	NdrFcShort( 0x8 ),	/* 8 */
/* 970 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 972 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 974 */	NdrFcShort( 0x10 ),	/* 16 */
/* 976 */	0x8,		/* FC_LONG */
			0x6,		/* FC_SHORT */
/* 978 */	0x6,		/* FC_SHORT */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 980 */	0x0,		/* 0 */
			NdrFcShort( 0xfff1 ),	/* Offset= -15 (966) */
			0x5b,		/* FC_END */
/* 984 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 986 */	NdrFcShort( 0x18 ),	/* 24 */
/* 988 */	NdrFcShort( 0x0 ),	/* 0 */
/* 990 */	NdrFcShort( 0xa ),	/* Offset= 10 (1000) */
/* 992 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 994 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 996 */	NdrFcShort( 0xffe8 ),	/* Offset= -24 (972) */
/* 998 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1000 */	
			0x11, 0x0,	/* FC_RP */
/* 1002 */	NdrFcShort( 0xfd4a ),	/* Offset= -694 (308) */
/* 1004 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 1006 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1008 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1010 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1012 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1014 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1016 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1018 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1020 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1022 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1024 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1026 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1028 */	0x13, 0x0,	/* FC_OP */
/* 1030 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1004) */
/* 1032 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1034 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1036 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 1038 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1040 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1042 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1044 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1046 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 1048 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1050 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1052 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1054 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1056 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1058 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1060 */	0x13, 0x0,	/* FC_OP */
/* 1062 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1036) */
/* 1064 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1066 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1068 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1070 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1072 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1074 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1076 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1078 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1080 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1082 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1084 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1086 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1088 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1090 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1092 */	0x13, 0x0,	/* FC_OP */
/* 1094 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1068) */
/* 1096 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1098 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1100 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 1102 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1104 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1106 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1108 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1110 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 1112 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1114 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1116 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1118 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1120 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1122 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1124 */	0x13, 0x0,	/* FC_OP */
/* 1126 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1100) */
/* 1128 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1130 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1132 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1134 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1136 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1138 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1140 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1142 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1144 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 1146 */	NdrFcShort( 0xffd8 ),	/* -40 */
/* 1148 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1150 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1152 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1132) */
/* 1154 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1156 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1158 */	NdrFcShort( 0x28 ),	/* 40 */
/* 1160 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1140) */
/* 1162 */	NdrFcShort( 0x0 ),	/* Offset= 0 (1162) */
/* 1164 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1166 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1168 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1170 */	NdrFcShort( 0xfc18 ),	/* Offset= -1000 (170) */
/* 1172 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1174 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1176 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1178 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1180 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1182 */	NdrFcShort( 0xfc04 ),	/* Offset= -1020 (162) */
/* 1184 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 1186 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1188) */
/* 1188 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1190 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1192 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1194 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1196 */	NdrFcShort( 0xfe16 ),	/* Offset= -490 (706) */
/* 1198 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1200 */	NdrFcLong( 0x83229bf2 ),	/* -2094883854 */
/* 1204 */	NdrFcShort( 0x7eb9 ),	/* 32441 */
/* 1206 */	NdrFcShort( 0x428d ),	/* 17037 */
/* 1208 */	0xb8,		/* 184 */
			0x32,		/* 50 */
/* 1210 */	0x83,		/* 131 */
			0x1c,		/* 28 */
/* 1212 */	0xac,		/* 172 */
			0xfa,		/* 250 */
/* 1214 */	0xe7,		/* 231 */
			0x8c,		/* 140 */
/* 1216 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1218 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1198) */
/* 1220 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1222 */	NdrFcShort( 0xfbc6 ),	/* Offset= -1082 (140) */
/* 1224 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1226 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1228) */
/* 1228 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1230 */	NdrFcLong( 0x8d366f71 ),	/* -1925812367 */
/* 1234 */	NdrFcShort( 0xea60 ),	/* -5536 */
/* 1236 */	NdrFcShort( 0x4812 ),	/* 18450 */
/* 1238 */	0xaf,		/* 175 */
			0xcd,		/* 205 */
/* 1240 */	0xbc,		/* 188 */
			0x5a,		/* 90 */
/* 1242 */	0x20,		/* 32 */
			0x29,		/* 41 */
/* 1244 */	0x7f,		/* 127 */
			0xdd,		/* 221 */
/* 1246 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1248 */	NdrFcLong( 0x1c62fd1d ),	/* 476249373 */
/* 1252 */	NdrFcShort( 0xf7d8 ),	/* -2088 */
/* 1254 */	NdrFcShort( 0x417e ),	/* 16766 */
/* 1256 */	0x9d,		/* 157 */
			0xaa,		/* 170 */
/* 1258 */	0x5a,		/* 90 */
			0xec,		/* 236 */
/* 1260 */	0xf0,		/* 240 */
			0x7c,		/* 124 */
/* 1262 */	0xf7,		/* 247 */
			0xd3,		/* 211 */
/* 1264 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1266 */	NdrFcLong( 0xe9a021d4 ),	/* -375381548 */
/* 1270 */	NdrFcShort( 0x77a7 ),	/* 30631 */
/* 1272 */	NdrFcShort( 0x458e ),	/* 17806 */
/* 1274 */	0xbb,		/* 187 */
			0x1f,		/* 31 */
/* 1276 */	0x2f,		/* 47 */
			0x84,		/* 132 */
/* 1278 */	0xdf,		/* 223 */
			0x48,		/* 72 */
/* 1280 */	0xb9,		/* 185 */
			0x82,		/* 130 */
/* 1282 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1284 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1286) */
/* 1286 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1288 */	NdrFcLong( 0x8d366f71 ),	/* -1925812367 */
/* 1292 */	NdrFcShort( 0xea60 ),	/* -5536 */
/* 1294 */	NdrFcShort( 0x4812 ),	/* 18450 */
/* 1296 */	0xaf,		/* 175 */
			0xcd,		/* 205 */
/* 1298 */	0xbc,		/* 188 */
			0x5a,		/* 90 */
/* 1300 */	0x20,		/* 32 */
			0x29,		/* 41 */
/* 1302 */	0x7f,		/* 127 */
			0xdd,		/* 221 */
/* 1304 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1306 */	NdrFcLong( 0xfa9817a1 ),	/* -90695775 */
/* 1310 */	NdrFcShort( 0x3666 ),	/* 13926 */
/* 1312 */	NdrFcShort( 0x41e7 ),	/* 16871 */
/* 1314 */	0x8f,		/* 143 */
			0xcf,		/* 207 */
/* 1316 */	0x9,		/* 9 */
			0x85,		/* 133 */
/* 1318 */	0xa4,		/* 164 */
			0x3d,		/* 61 */
/* 1320 */	0x5f,		/* 95 */
			0xa6,		/* 166 */
/* 1322 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1324 */	NdrFcLong( 0x9acf69a8 ),	/* -1697683032 */
/* 1328 */	NdrFcShort( 0xe19e ),	/* -7778 */
/* 1330 */	NdrFcShort( 0x424a ),	/* 16970 */
/* 1332 */	0xae,		/* 174 */
			0xab,		/* 171 */
/* 1334 */	0xa1,		/* 161 */
			0x57,		/* 87 */
/* 1336 */	0x34,		/* 52 */
			0x8,		/* 8 */
/* 1338 */	0xf0,		/* 240 */
			0xae,		/* 174 */
/* 1340 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1342 */	NdrFcLong( 0x9a232764 ),	/* -1708972188 */
/* 1346 */	NdrFcShort( 0x6785 ),	/* 26501 */
/* 1348 */	NdrFcShort( 0x421f ),	/* 16927 */
/* 1350 */	0x81,		/* 129 */
			0x1a,		/* 26 */
/* 1352 */	0xd4,		/* 212 */
			0x7b,		/* 123 */
/* 1354 */	0x6f,		/* 111 */
			0x3b,		/* 59 */
/* 1356 */	0xc9,		/* 201 */
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


/* Object interface: IKernelNode, ver. 0.0,
   GUID={0xE7A4DBC7,0x26F3,0x487B,{0x9E,0xAD,0xE2,0xA7,0xF6,0xAF,0x82,0xE1}} */

#pragma code_seg(".orpc")
static const unsigned short IKernelNode_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
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
CINTERFACE_PROXY_VTABLE(7) _IKernelNodeProxyVtbl = 
{
    0,
    &IID_IKernelNode,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IKernelNode_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IKernelNodeStubVtbl =
{
    &IID_IKernelNode,
    &IKernelNode_ServerInfo,
    7,
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
    0,
    366,
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
CINTERFACE_PROXY_VTABLE(10) _IGraphProxyVtbl = 
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
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IGraphStubVtbl =
{
    &IID_IGraph,
    &IGraph_ServerInfo,
    10,
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
    402
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
    438
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
    474,
    510
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
CINTERFACE_PROXY_VTABLE(9) _IExtendableProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IExtendable::Extend */ ,
    (void *) (INT_PTR) -1 /* IExtendable::NewDimension */
};


static const PRPC_STUB_FUNCTION IExtendable_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IExtendableStubVtbl =
{
    &IID_IExtendable,
    &IExtendable_ServerInfo,
    9,
    &IExtendable_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IMorsable, ver. 0.0,
   GUID={0xAF4F6B4B,0xC82F,0x49B9,{0x9B,0x01,0x16,0x7D,0x5E,0x38,0xAD,0x69}} */

#pragma code_seg(".orpc")
static const unsigned short IMorsable_FormatStringOffsetTable[] =
    {
    546
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
    576
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
    612,
    642,
    672
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
CINTERFACE_PROXY_VTABLE(10) _IComputationGraphResultProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IComputationGraphResult::Loops */
};


static const PRPC_STUB_FUNCTION IComputationGraphResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IComputationGraphResultStubVtbl =
{
    &IID_IComputationGraphResult,
    &IComputationGraphResult_ServerInfo,
    10,
    &IComputationGraphResult_table[-3],
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
    612
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


/* Object interface: AbstractComputationEvent, ver. 0.0,
   GUID={0xA05EF93D,0x10B9,0x41ED,{0xAF,0x38,0xBC,0x01,0x93,0xFD,0xFF,0x96}} */

#pragma code_seg(".orpc")
static const unsigned short AbstractComputationEvent_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    612,
    642
    };

static const MIDL_STUBLESS_PROXY_INFO AbstractComputationEvent_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &AbstractComputationEvent_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO AbstractComputationEvent_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &AbstractComputationEvent_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _AbstractComputationEventProxyVtbl = 
{
    &AbstractComputationEvent_ProxyInfo,
    &IID_AbstractComputationEvent,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* AbstractComputationEvent::noChilds */ ,
    (void *) (INT_PTR) -1 /* AbstractComputationEvent::noImplementation */
};


static const PRPC_STUB_FUNCTION AbstractComputationEvent_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _AbstractComputationEventStubVtbl =
{
    &IID_AbstractComputationEvent,
    &AbstractComputationEvent_ServerInfo,
    9,
    &AbstractComputationEvent_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: AbstractEvent, ver. 0.0,
   GUID={0x169609CE,0x174B,0x42E4,{0x88,0x83,0xCB,0x72,0x16,0x08,0x89,0x69}} */

#pragma code_seg(".orpc")
static const unsigned short AbstractEvent_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    702,
    738,
    672,
    774
    };

static const MIDL_STUBLESS_PROXY_INFO AbstractEvent_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &AbstractEvent_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO AbstractEvent_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &AbstractEvent_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _AbstractEventProxyVtbl = 
{
    &AbstractEvent_ProxyInfo,
    &IID_AbstractEvent,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* AbstractEvent::newComputationResult */ ,
    (void *) (INT_PTR) -1 /* AbstractEvent::newKernelNode */ ,
    (void *) (INT_PTR) -1 /* AbstractEvent::noImplementation */ ,
    (void *) (INT_PTR) -1 /* AbstractEvent::noChilds */
};


static const PRPC_STUB_FUNCTION AbstractEvent_table[] =
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

CInterfaceStubVtbl _AbstractEventStubVtbl =
{
    &IID_AbstractEvent,
    &AbstractEvent_ServerInfo,
    11,
    &AbstractEvent_table[-3],
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
    576,
    642,
    672,
    804,
    846,
    882
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


/* Object interface: IComputationGraphResultExt, ver. 0.0,
   GUID={0xA16233C4,0x8412,0x43B1,{0xB8,0xFB,0xC3,0x39,0xF8,0x6E,0xFB,0x55}} */

#pragma code_seg(".orpc")
static const unsigned short IComputationGraphResultExt_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    612,
    642,
    672,
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
CINTERFACE_PROXY_VTABLE(12) _IComputationGraphResultExtProxyVtbl = 
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
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IComputationGraphResultExtStubVtbl =
{
    &IID_IComputationGraphResultExt,
    &IComputationGraphResultExt_ServerInfo,
    12,
    &IComputationGraphResultExt_table[-3],
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
    576,
    918,
    672
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
    960,
    996,
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
CINTERFACE_PROXY_VTABLE(11) _IFunctionProxyVtbl = 
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
    0 /* (void *) (INT_PTR) -1 /* IFunction::createGraph */
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
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IFunctionStubVtbl =
{
    &IID_IFunction,
    &IFunction_ServerInfo,
    11,
    &IFunction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IKernelEvents, ver. 0.0,
   GUID={0x7B44B0BB,0x0C63,0x4216,{0x80,0xB1,0xE2,0x28,0x56,0x5D,0xF7,0x3D}} */

#pragma code_seg(".orpc")
static const unsigned short IKernelEvents_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    576,
    1032
    };

static const MIDL_STUBLESS_PROXY_INFO IKernelEvents_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IKernelEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IKernelEvents_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IKernelEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IKernelEventsProxyVtbl = 
{
    &IKernelEvents_ProxyInfo,
    &IID_IKernelEvents,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IKernelEvents::InternalException */ ,
    (void *) (INT_PTR) -1 /* IKernelEvents::KernelFunctionChanged */
};


static const PRPC_STUB_FUNCTION IKernelEvents_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IKernelEventsStubVtbl =
{
    &IID_IKernelEvents,
    &IKernelEvents_ServerInfo,
    9,
    &IKernelEvents_table[-3],
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
    1074,
    1110,
    1146,
    1182,
    1218
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
CINTERFACE_PROXY_VTABLE(12) _IKernelProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IKernel::CreateProjectiveBundleGroup */
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
    NdrStubCall2
};

CInterfaceStubVtbl _IKernelStubVtbl =
{
    &IID_IKernel,
    &IKernel_ServerInfo,
    12,
    &IKernel_table[-3],
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
    1254,
    1290,
    1326,
    1362,
    1398,
    1434,
    240,
    1470
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
CINTERFACE_PROXY_VTABLE(15) _IMorseSpectrumProxyVtbl = 
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
    NdrStubCall2
};

CInterfaceStubVtbl _IMorseSpectrumStubVtbl =
{
    &IID_IMorseSpectrum,
    &IMorseSpectrum_ServerInfo,
    15,
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
    0,
    366,
    (unsigned short) -1,
    1506,
    1542
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
    &IProjectiveBundle_ProxyInfo,
    &IID_IProjectiveBundle,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphDimension */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */ ,
    (void *) (INT_PTR) -1 /* IProjectiveBundle::get_kernel */ ,
    (void *) (INT_PTR) -1 /* IProjectiveBundle::putref_kernel */
};


static const PRPC_STUB_FUNCTION IProjectiveBundle_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IProjectiveBundleStubVtbl =
{
    &IID_IProjectiveBundle,
    &IProjectiveBundle_ServerInfo,
    12,
    &IProjectiveBundle_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IProjectiveBundleEvents, ver. 0.0,
   GUID={0xA9EBC232,0xAB43,0x43EA,{0x89,0xE6,0x67,0x10,0xFD,0xD3,0x53,0x42}} */

#pragma code_seg(".orpc")
static const unsigned short IProjectiveBundleEvents_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1578,
    1614
    };

static const MIDL_STUBLESS_PROXY_INFO IProjectiveBundleEvents_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IProjectiveBundleEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IProjectiveBundleEvents_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IProjectiveBundleEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IProjectiveBundleEventsProxyVtbl = 
{
    &IProjectiveBundleEvents_ProxyInfo,
    &IID_IProjectiveBundleEvents,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IProjectiveBundleEvents::newChildProjectiveBundle */ ,
    (void *) (INT_PTR) -1 /* IProjectiveBundleEvents::newChildMorseSpectrum */
};


static const PRPC_STUB_FUNCTION IProjectiveBundleEvents_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IProjectiveBundleEventsStubVtbl =
{
    &IID_IProjectiveBundleEvents,
    &IProjectiveBundleEvents_ServerInfo,
    9,
    &IProjectiveBundleEvents_table[-3],
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
    0,
    366,
    (unsigned short) -1,
    1650,
    1686
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
    &ISymbolicImage_ProxyInfo,
    &IID_ISymbolicImage,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphDimension */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */ ,
    (void *) (INT_PTR) -1 /* ISymbolicImage::get_kernel */ ,
    (void *) (INT_PTR) -1 /* ISymbolicImage::putref_kernel */
};


static const PRPC_STUB_FUNCTION ISymbolicImage_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISymbolicImageStubVtbl =
{
    &IID_ISymbolicImage,
    &ISymbolicImage_ServerInfo,
    12,
    &ISymbolicImage_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ISymbolicImageEvents, ver. 0.0,
   GUID={0x4840FAA7,0x422A,0x4717,{0x83,0x18,0xE3,0xDC,0x82,0x59,0x9C,0xBC}} */

#pragma code_seg(".orpc")
static const unsigned short ISymbolicImageEvents_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1722,
    1758
    };

static const MIDL_STUBLESS_PROXY_INFO ISymbolicImageEvents_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &ISymbolicImageEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ISymbolicImageEvents_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &ISymbolicImageEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _ISymbolicImageEventsProxyVtbl = 
{
    &ISymbolicImageEvents_ProxyInfo,
    &IID_ISymbolicImageEvents,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* ISymbolicImageEvents::newChildSymbolicImage */ ,
    (void *) (INT_PTR) -1 /* ISymbolicImageEvents::newChildProjectiveBundle */
};


static const PRPC_STUB_FUNCTION ISymbolicImageEvents_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ISymbolicImageEventsStubVtbl =
{
    &IID_ISymbolicImageEvents,
    &ISymbolicImageEvents_ServerInfo,
    9,
    &ISymbolicImageEvents_table[-3],
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
    0,
    366,
    (unsigned short) -1,
    1650,
    1686,
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
    (void *) (INT_PTR) -1 /* IGraph::graphDimension */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */ ,
    (void *) (INT_PTR) -1 /* ISymbolicImage::get_kernel */ ,
    (void *) (INT_PTR) -1 /* ISymbolicImage::putref_kernel */ ,
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
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
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
    0,
    366,
    (unsigned short) -1,
    1650,
    1686,
    1794,
    1830
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
    (void *) (INT_PTR) -1 /* IGraph::graphDimension */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */ ,
    (void *) (INT_PTR) -1 /* ISymbolicImage::get_kernel */ ,
    (void *) (INT_PTR) -1 /* ISymbolicImage::putref_kernel */ ,
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
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
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
    0,
    366,
    (unsigned short) -1,
    1506,
    1542,
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
    (void *) (INT_PTR) -1 /* IGraph::graphDimension */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */ ,
    (void *) (INT_PTR) -1 /* IProjectiveBundle::get_kernel */ ,
    (void *) (INT_PTR) -1 /* IProjectiveBundle::putref_kernel */ ,
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
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
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
    0,
    366,
    (unsigned short) -1,
    1506,
    1542,
    1866,
    1902
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
    (void *) (INT_PTR) -1 /* IGraph::graphDimension */ ,
    (void *) (INT_PTR) -1 /* IGraph::graphInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraph::acceptChilds */ ,
    (void *) (INT_PTR) -1 /* IProjectiveBundle::get_kernel */ ,
    (void *) (INT_PTR) -1 /* IProjectiveBundle::putref_kernel */ ,
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
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
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
    ( CInterfaceProxyVtbl *) &_IParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProjectiveBundleProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IExportDataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProjectiveBundleEventsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_AbstractComputationEventProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISubdevidableProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMorsableProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IExtendableProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProjectiveBundleGraphProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IExtendableParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernelProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProjectiveBundleGroupProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISymbolicImageGroupProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISubdevidePointParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISymbolicImageProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComponentRegistrarProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISymbolicImageEventsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISymbolicImageGraphProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGroupNodeProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernelEventsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationGraphResultExtProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IFunctionEventsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernelNodeProxyVtbl,
    ( CInterfaceProxyVtbl *) &_AbstractEventProxyVtbl,
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
    ( CInterfaceStubVtbl *) &_IParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_IProjectiveBundleStubVtbl,
    ( CInterfaceStubVtbl *) &_IExportDataStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IProjectiveBundleEventsStubVtbl,
    ( CInterfaceStubVtbl *) &_AbstractComputationEventStubVtbl,
    ( CInterfaceStubVtbl *) &_ISubdevidableStubVtbl,
    ( CInterfaceStubVtbl *) &_IMorsableStubVtbl,
    ( CInterfaceStubVtbl *) &_IExtendableStubVtbl,
    ( CInterfaceStubVtbl *) &_IProjectiveBundleGraphStubVtbl,
    ( CInterfaceStubVtbl *) &_IExtendableParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernelStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IProjectiveBundleGroupStubVtbl,
    ( CInterfaceStubVtbl *) &_ISymbolicImageGroupStubVtbl,
    ( CInterfaceStubVtbl *) &_ISubdevidePointParamsStubVtbl,
    ( CInterfaceStubVtbl *) &_ISymbolicImageStubVtbl,
    ( CInterfaceStubVtbl *) &_IComponentRegistrarStubVtbl,
    ( CInterfaceStubVtbl *) &_ISymbolicImageEventsStubVtbl,
    ( CInterfaceStubVtbl *) &_ISymbolicImageGraphStubVtbl,
    ( CInterfaceStubVtbl *) &_IGroupNodeStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernelEventsStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationGraphResultExtStubVtbl,
    ( CInterfaceStubVtbl *) &_IFunctionEventsStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernelNodeStubVtbl,
    ( CInterfaceStubVtbl *) &_AbstractEventStubVtbl,
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
    "IParams",
    "IProjectiveBundle",
    "IExportData",
    "IComputationResult",
    "IProjectiveBundleEvents",
    "AbstractComputationEvent",
    "ISubdevidable",
    "IMorsable",
    "IExtendable",
    "IProjectiveBundleGraph",
    "IExtendableParams",
    "IKernel",
    "IGraphInfo",
    "IProjectiveBundleGroup",
    "ISymbolicImageGroup",
    "ISubdevidePointParams",
    "ISymbolicImage",
    "IComponentRegistrar",
    "ISymbolicImageEvents",
    "ISymbolicImageGraph",
    "IGroupNode",
    "IKernelEvents",
    "IComputationGraphResult",
    "IComputationGraphResultExt",
    "IFunctionEvents",
    "IKernelNode",
    "AbstractEvent",
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

    IID_BS_LOOKUP_INITIAL_TEST( __MorseKernelATL, 33, 32 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 16 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 8 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 4 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 2 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( __MorseKernelATL, 33, *pIndex )
    
}

const ExtendedProxyFileInfo _MorseKernelATL_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & __MorseKernelATL_ProxyVtblList,
    (PCInterfaceStubVtblList *) & __MorseKernelATL_StubVtblList,
    (const PCInterfaceName * ) & __MorseKernelATL_InterfaceNamesList,
    (const IID ** ) & __MorseKernelATL_BaseIIDList,
    & __MorseKernelATL_IID_Lookup, 
    33,
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

