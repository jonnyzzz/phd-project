

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Thu Feb 10 01:29:34 2005
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

#define TYPE_FORMAT_STRING_SIZE   1381                              
#define PROC_FORMAT_STRING_SIZE   2131                              
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

	/* Procedure LoadByID */


	/* Procedure getNode */

/* 954 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 956 */	NdrFcLong( 0x0 ),	/* 0 */
/* 960 */	NdrFcShort( 0x8 ),	/* 8 */
/* 962 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 964 */	NdrFcShort( 0x8 ),	/* 8 */
/* 966 */	NdrFcShort( 0x8 ),	/* 8 */
/* 968 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 970 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 972 */	NdrFcShort( 0x0 ),	/* 0 */
/* 974 */	NdrFcShort( 0x0 ),	/* 0 */
/* 976 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter ID */


	/* Parameter index */

/* 978 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 980 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 982 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter node */


	/* Parameter node */

/* 984 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 986 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 988 */	NdrFcShort( 0xa6 ),	/* Type Offset=166 */

	/* Return value */


	/* Return value */

/* 990 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 992 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 994 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetComponents */

/* 996 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 998 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1002 */	NdrFcShort( 0xa ),	/* 10 */
/* 1004 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1006 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1008 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1010 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 1012 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 1014 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1016 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1018 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pbstrCLSIDs */

/* 1020 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1022 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1024 */	NdrFcShort( 0x4b4 ),	/* Type Offset=1204 */

	/* Parameter pbstrDescriptions */

/* 1026 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1028 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1030 */	NdrFcShort( 0x4b4 ),	/* Type Offset=1204 */

	/* Return value */

/* 1032 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1034 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1036 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterComponent */

/* 1038 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1040 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1044 */	NdrFcShort( 0xb ),	/* 11 */
/* 1046 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1048 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1050 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1052 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1054 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1056 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1058 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1060 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 1062 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1064 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1066 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */

/* 1068 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1070 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1072 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterComponent */

/* 1074 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1076 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1080 */	NdrFcShort( 0xc ),	/* 12 */
/* 1082 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1084 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1086 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1088 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1090 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1092 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1094 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1096 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 1098 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1100 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1102 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */

/* 1104 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1106 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1108 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure FunctionChanged */

/* 1110 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1112 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1116 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1118 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1120 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1122 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1124 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1126 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1128 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1130 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1132 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter oldFunction */

/* 1134 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1136 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1138 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Parameter newFunction */

/* 1140 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1142 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1144 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */

/* 1146 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1148 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1150 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure FileName */


	/* Procedure FileName */


	/* Procedure get_SystemSource */

/* 1152 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1154 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1158 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1160 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1162 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1164 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1166 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1168 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 1170 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1172 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1174 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter fileName */


	/* Parameter fileName */


	/* Parameter pVal */

/* 1176 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1178 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1180 */	NdrFcShort( 0x4c2 ),	/* Type Offset=1218 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 1182 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1184 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1186 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_SystemSource */

/* 1188 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1190 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1194 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1196 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1198 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1200 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1202 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1204 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1206 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1208 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1210 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1212 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1214 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1216 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */

/* 1218 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1220 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1222 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_Function */

/* 1224 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1226 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1230 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1232 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1234 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1236 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1238 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1240 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1242 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1244 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1246 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1248 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1250 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1252 */	NdrFcShort( 0x4cc ),	/* Type Offset=1228 */

	/* Return value */

/* 1254 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1256 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1258 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure putref_Function */

/* 1260 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1262 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1266 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1268 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1270 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1272 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1274 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1276 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1278 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1280 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1282 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1284 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1286 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1288 */	NdrFcShort( 0x4d0 ),	/* Type Offset=1232 */

	/* Return value */

/* 1290 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1292 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1294 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateRootSymbolicImage */

/* 1296 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1298 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1302 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1304 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1306 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1308 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1310 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1312 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1314 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1316 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1318 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1320 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1322 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1324 */	NdrFcShort( 0xa6 ),	/* Type Offset=166 */

	/* Return value */

/* 1326 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1328 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1330 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateSymbolicImageGroup */

/* 1332 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1334 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1338 */	NdrFcShort( 0xa ),	/* 10 */
/* 1340 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1342 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1344 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1346 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1348 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1350 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1352 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1354 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 1356 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1358 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1360 */	NdrFcShort( 0xa6 ),	/* Type Offset=166 */

	/* Return value */

/* 1362 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1364 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1366 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateProjectiveBundleGroup */

/* 1368 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1370 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1374 */	NdrFcShort( 0xb ),	/* 11 */
/* 1376 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1378 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1380 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1382 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1384 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1386 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1388 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1390 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 1392 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1394 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1396 */	NdrFcShort( 0xa6 ),	/* Type Offset=166 */

	/* Return value */

/* 1398 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1400 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1402 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNewNode */

/* 1404 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1406 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1410 */	NdrFcShort( 0xc ),	/* 12 */
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
/* 1432 */	NdrFcShort( 0xaa ),	/* Type Offset=170 */

	/* Parameter nodeChild */

/* 1434 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1436 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1438 */	NdrFcShort( 0xaa ),	/* Type Offset=170 */

	/* Return value */

/* 1440 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1442 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1444 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNewComputationResult */

/* 1446 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1448 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1452 */	NdrFcShort( 0xd ),	/* 13 */
/* 1454 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1456 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1458 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1460 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1462 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1464 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1466 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1468 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nodeParent */

/* 1470 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1472 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1474 */	NdrFcShort( 0xaa ),	/* Type Offset=170 */

	/* Parameter nodeCResult */

/* 1476 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1478 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1480 */	NdrFcShort( 0x4e2 ),	/* Type Offset=1250 */

	/* Return value */

/* 1482 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1484 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1486 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNoChilds */

/* 1488 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1490 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1494 */	NdrFcShort( 0xe ),	/* 14 */
/* 1496 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1498 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1500 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1502 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1504 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1506 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1508 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1510 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nodeParent */

/* 1512 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1514 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1516 */	NdrFcShort( 0xaa ),	/* Type Offset=170 */

	/* Return value */

/* 1518 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1520 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1522 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EventNoImplementation */

/* 1524 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1526 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1530 */	NdrFcShort( 0xf ),	/* 15 */
/* 1532 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1534 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1536 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1538 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1540 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1542 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1544 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1546 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter nodeParent */

/* 1548 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1550 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1552 */	NdrFcShort( 0xaa ),	/* Type Offset=170 */

	/* Return value */

/* 1554 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1556 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1558 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_lowerBound */

/* 1560 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1562 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1566 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1568 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1570 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1572 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1574 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1576 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1578 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1580 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1582 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1584 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1586 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1588 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1590 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1592 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1594 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_lowerBound */

/* 1596 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1598 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1602 */	NdrFcShort( 0xa ),	/* 10 */
/* 1604 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1606 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1608 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1610 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1612 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1614 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1616 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1618 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1620 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1622 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1624 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1626 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1628 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1630 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_upperBound */

/* 1632 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1634 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1638 */	NdrFcShort( 0xb ),	/* 11 */
/* 1640 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1642 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1644 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1646 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1648 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1650 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1652 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1654 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1656 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1658 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1660 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1662 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1664 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1666 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_upperBound */

/* 1668 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1670 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1674 */	NdrFcShort( 0xc ),	/* 12 */
/* 1676 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1678 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1680 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1682 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1684 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1686 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1688 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1690 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1692 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1694 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1696 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1698 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1700 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1702 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_lowerLength */

/* 1704 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1706 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1710 */	NdrFcShort( 0xe ),	/* 14 */
/* 1712 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1714 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1716 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1718 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1720 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1722 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1724 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1726 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1728 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1730 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1732 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1734 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1736 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1738 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_upperLength */

/* 1740 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1742 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1746 */	NdrFcShort( 0xf ),	/* 15 */
/* 1748 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1750 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1752 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1754 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1756 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1758 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1760 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1762 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 1764 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1766 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1768 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1770 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1772 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1774 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_upperLength */

/* 1776 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1778 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1782 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1784 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1786 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1788 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1790 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1792 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1794 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1796 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1798 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 1800 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1802 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1804 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1806 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1808 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1810 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure addNode */

/* 1812 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1814 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1818 */	NdrFcShort( 0xc ),	/* 12 */
/* 1820 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1822 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1824 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1826 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1828 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1830 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1832 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1834 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter img */

/* 1836 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1838 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1840 */	NdrFcShort( 0x4f4 ),	/* Type Offset=1268 */

	/* Return value */

/* 1842 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1844 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1846 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure removeNode */

/* 1848 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1850 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1854 */	NdrFcShort( 0xd ),	/* 13 */
/* 1856 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1858 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1860 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1862 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1864 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1866 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1868 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1870 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter img */

/* 1872 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1874 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1876 */	NdrFcShort( 0x4f4 ),	/* Type Offset=1268 */

	/* Return value */

/* 1878 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1880 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1882 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure addNode */

/* 1884 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1886 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1890 */	NdrFcShort( 0xc ),	/* 12 */
/* 1892 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1894 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1896 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1898 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1900 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1902 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1904 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1906 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bn */

/* 1908 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1910 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1912 */	NdrFcShort( 0x506 ),	/* Type Offset=1286 */

	/* Return value */

/* 1914 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1916 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1918 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure removeNode */

/* 1920 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1922 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1926 */	NdrFcShort( 0xd ),	/* 13 */
/* 1928 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1930 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1932 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1934 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1936 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1938 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1940 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1942 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter img */

/* 1944 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1946 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1948 */	NdrFcShort( 0x506 ),	/* Type Offset=1286 */

	/* Return value */

/* 1950 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1952 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1954 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SaveWithID */

/* 1956 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1958 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1962 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1964 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1966 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1968 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1970 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1972 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1974 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1976 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1978 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 1980 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1982 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1984 */	NdrFcShort( 0xaa ),	/* Type Offset=170 */

	/* Parameter ID */

/* 1986 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1988 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1990 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1992 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1994 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1996 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure LoadKernelNode */

/* 1998 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2000 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2004 */	NdrFcShort( 0x7 ),	/* 7 */
/* 2006 */	NdrFcShort( 0x14 ),	/* x86 Stack size/offset = 20 */
/* 2008 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2010 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2012 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 2014 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2016 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2018 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2020 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */

/* 2022 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2024 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2026 */	NdrFcShort( 0x518 ),	/* Type Offset=1304 */

	/* Parameter kernel */

/* 2028 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2030 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2032 */	NdrFcShort( 0x52a ),	/* Type Offset=1322 */

	/* Parameter node */

/* 2034 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 2036 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2038 */	NdrFcShort( 0x53c ),	/* Type Offset=1340 */

	/* Return value */

/* 2040 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2042 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 2044 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SaveKernelNode */

/* 2046 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2048 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2052 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2054 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 2056 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2058 */	NdrFcShort( 0x8 ),	/* 8 */
/* 2060 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 2062 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2064 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2066 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2068 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter output */

/* 2070 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2072 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2074 */	NdrFcShort( 0x552 ),	/* Type Offset=1362 */

	/* Parameter node */

/* 2076 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2078 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2080 */	NdrFcShort( 0x540 ),	/* Type Offset=1344 */

	/* Return value */

/* 2082 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2084 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2086 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SupportSerialization */

/* 2088 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 2090 */	NdrFcLong( 0x0 ),	/* 0 */
/* 2094 */	NdrFcShort( 0x9 ),	/* 9 */
/* 2096 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 2098 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2100 */	NdrFcShort( 0x22 ),	/* 34 */
/* 2102 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 2104 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 2106 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2108 */	NdrFcShort( 0x0 ),	/* 0 */
/* 2110 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 2112 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 2114 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 2116 */	NdrFcShort( 0x540 ),	/* Type Offset=1344 */

	/* Parameter result */

/* 2118 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 2120 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 2122 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 2124 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 2126 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 2128 */	0x8,		/* FC_LONG */
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
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 168 */	NdrFcShort( 0x2 ),	/* Offset= 2 (170) */
/* 170 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 172 */	NdrFcLong( 0xe7a4dbc7 ),	/* -408626233 */
/* 176 */	NdrFcShort( 0x26f3 ),	/* 9971 */
/* 178 */	NdrFcShort( 0x487b ),	/* 18555 */
/* 180 */	0x9e,		/* 158 */
			0xad,		/* 173 */
/* 182 */	0xe2,		/* 226 */
			0xa7,		/* 167 */
/* 184 */	0xf6,		/* 246 */
			0xaf,		/* 175 */
/* 186 */	0x82,		/* 130 */
			0xe1,		/* 225 */
/* 188 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 190 */	NdrFcShort( 0x3f6 ),	/* Offset= 1014 (1204) */
/* 192 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 194 */	NdrFcShort( 0x2 ),	/* Offset= 2 (196) */
/* 196 */	
			0x13, 0x0,	/* FC_OP */
/* 198 */	NdrFcShort( 0x3dc ),	/* Offset= 988 (1186) */
/* 200 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x49,		/* 73 */
/* 202 */	NdrFcShort( 0x18 ),	/* 24 */
/* 204 */	NdrFcShort( 0xa ),	/* 10 */
/* 206 */	NdrFcLong( 0x8 ),	/* 8 */
/* 210 */	NdrFcShort( 0x5a ),	/* Offset= 90 (300) */
/* 212 */	NdrFcLong( 0xd ),	/* 13 */
/* 216 */	NdrFcShort( 0x90 ),	/* Offset= 144 (360) */
/* 218 */	NdrFcLong( 0x9 ),	/* 9 */
/* 222 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (416) */
/* 224 */	NdrFcLong( 0xc ),	/* 12 */
/* 228 */	NdrFcShort( 0x2c0 ),	/* Offset= 704 (932) */
/* 230 */	NdrFcLong( 0x24 ),	/* 36 */
/* 234 */	NdrFcShort( 0x2ea ),	/* Offset= 746 (980) */
/* 236 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 240 */	NdrFcShort( 0x306 ),	/* Offset= 774 (1014) */
/* 242 */	NdrFcLong( 0x10 ),	/* 16 */
/* 246 */	NdrFcShort( 0x320 ),	/* Offset= 800 (1046) */
/* 248 */	NdrFcLong( 0x2 ),	/* 2 */
/* 252 */	NdrFcShort( 0x33a ),	/* Offset= 826 (1078) */
/* 254 */	NdrFcLong( 0x3 ),	/* 3 */
/* 258 */	NdrFcShort( 0x354 ),	/* Offset= 852 (1110) */
/* 260 */	NdrFcLong( 0x14 ),	/* 20 */
/* 264 */	NdrFcShort( 0x36e ),	/* Offset= 878 (1142) */
/* 266 */	NdrFcShort( 0xffff ),	/* Offset= -1 (265) */
/* 268 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 270 */	NdrFcShort( 0x4 ),	/* 4 */
/* 272 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 274 */	NdrFcShort( 0x0 ),	/* 0 */
/* 276 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 278 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 280 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 282 */	NdrFcShort( 0x4 ),	/* 4 */
/* 284 */	NdrFcShort( 0x0 ),	/* 0 */
/* 286 */	NdrFcShort( 0x1 ),	/* 1 */
/* 288 */	NdrFcShort( 0x0 ),	/* 0 */
/* 290 */	NdrFcShort( 0x0 ),	/* 0 */
/* 292 */	0x13, 0x0,	/* FC_OP */
/* 294 */	NdrFcShort( 0xff48 ),	/* Offset= -184 (110) */
/* 296 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 298 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 300 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 302 */	NdrFcShort( 0x8 ),	/* 8 */
/* 304 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 306 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 308 */	NdrFcShort( 0x4 ),	/* 4 */
/* 310 */	NdrFcShort( 0x4 ),	/* 4 */
/* 312 */	0x11, 0x0,	/* FC_RP */
/* 314 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (268) */
/* 316 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 318 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 320 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 322 */	NdrFcLong( 0x0 ),	/* 0 */
/* 326 */	NdrFcShort( 0x0 ),	/* 0 */
/* 328 */	NdrFcShort( 0x0 ),	/* 0 */
/* 330 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 332 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 334 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 336 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 338 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 340 */	NdrFcShort( 0x0 ),	/* 0 */
/* 342 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 344 */	NdrFcShort( 0x0 ),	/* 0 */
/* 346 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 348 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 352 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 354 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 356 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (320) */
/* 358 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 360 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 362 */	NdrFcShort( 0x8 ),	/* 8 */
/* 364 */	NdrFcShort( 0x0 ),	/* 0 */
/* 366 */	NdrFcShort( 0x6 ),	/* Offset= 6 (372) */
/* 368 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 370 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 372 */	
			0x11, 0x0,	/* FC_RP */
/* 374 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (338) */
/* 376 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 378 */	NdrFcLong( 0x20400 ),	/* 132096 */
/* 382 */	NdrFcShort( 0x0 ),	/* 0 */
/* 384 */	NdrFcShort( 0x0 ),	/* 0 */
/* 386 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 388 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 390 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 392 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 394 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 396 */	NdrFcShort( 0x0 ),	/* 0 */
/* 398 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 400 */	NdrFcShort( 0x0 ),	/* 0 */
/* 402 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 404 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 408 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 410 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 412 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (376) */
/* 414 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 416 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 418 */	NdrFcShort( 0x8 ),	/* 8 */
/* 420 */	NdrFcShort( 0x0 ),	/* 0 */
/* 422 */	NdrFcShort( 0x6 ),	/* Offset= 6 (428) */
/* 424 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 426 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 428 */	
			0x11, 0x0,	/* FC_RP */
/* 430 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (394) */
/* 432 */	
			0x2b,		/* FC_NON_ENCAPSULATED_UNION */
			0x9,		/* FC_ULONG */
/* 434 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 436 */	NdrFcShort( 0xfff8 ),	/* -8 */
/* 438 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 440 */	NdrFcShort( 0x2 ),	/* Offset= 2 (442) */
/* 442 */	NdrFcShort( 0x10 ),	/* 16 */
/* 444 */	NdrFcShort( 0x2f ),	/* 47 */
/* 446 */	NdrFcLong( 0x14 ),	/* 20 */
/* 450 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 452 */	NdrFcLong( 0x3 ),	/* 3 */
/* 456 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 458 */	NdrFcLong( 0x11 ),	/* 17 */
/* 462 */	NdrFcShort( 0x8001 ),	/* Simple arm type: FC_BYTE */
/* 464 */	NdrFcLong( 0x2 ),	/* 2 */
/* 468 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 470 */	NdrFcLong( 0x4 ),	/* 4 */
/* 474 */	NdrFcShort( 0x800a ),	/* Simple arm type: FC_FLOAT */
/* 476 */	NdrFcLong( 0x5 ),	/* 5 */
/* 480 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 482 */	NdrFcLong( 0xb ),	/* 11 */
/* 486 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 488 */	NdrFcLong( 0xa ),	/* 10 */
/* 492 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 494 */	NdrFcLong( 0x6 ),	/* 6 */
/* 498 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (730) */
/* 500 */	NdrFcLong( 0x7 ),	/* 7 */
/* 504 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 506 */	NdrFcLong( 0x8 ),	/* 8 */
/* 510 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (736) */
/* 512 */	NdrFcLong( 0xd ),	/* 13 */
/* 516 */	NdrFcShort( 0xff3c ),	/* Offset= -196 (320) */
/* 518 */	NdrFcLong( 0x9 ),	/* 9 */
/* 522 */	NdrFcShort( 0xff6e ),	/* Offset= -146 (376) */
/* 524 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 528 */	NdrFcShort( 0xd4 ),	/* Offset= 212 (740) */
/* 530 */	NdrFcLong( 0x24 ),	/* 36 */
/* 534 */	NdrFcShort( 0xd6 ),	/* Offset= 214 (748) */
/* 536 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 540 */	NdrFcShort( 0xd0 ),	/* Offset= 208 (748) */
/* 542 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 546 */	NdrFcShort( 0x100 ),	/* Offset= 256 (802) */
/* 548 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 552 */	NdrFcShort( 0xfe ),	/* Offset= 254 (806) */
/* 554 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 558 */	NdrFcShort( 0xfc ),	/* Offset= 252 (810) */
/* 560 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 564 */	NdrFcShort( 0xfa ),	/* Offset= 250 (814) */
/* 566 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 570 */	NdrFcShort( 0xf8 ),	/* Offset= 248 (818) */
/* 572 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 576 */	NdrFcShort( 0xf6 ),	/* Offset= 246 (822) */
/* 578 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 582 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (806) */
/* 584 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 588 */	NdrFcShort( 0xde ),	/* Offset= 222 (810) */
/* 590 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 594 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (826) */
/* 596 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 600 */	NdrFcShort( 0xde ),	/* Offset= 222 (822) */
/* 602 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 606 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (830) */
/* 608 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 612 */	NdrFcShort( 0xde ),	/* Offset= 222 (834) */
/* 614 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 618 */	NdrFcShort( 0xdc ),	/* Offset= 220 (838) */
/* 620 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 624 */	NdrFcShort( 0xda ),	/* Offset= 218 (842) */
/* 626 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 630 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (854) */
/* 632 */	NdrFcLong( 0x10 ),	/* 16 */
/* 636 */	NdrFcShort( 0x8002 ),	/* Simple arm type: FC_CHAR */
/* 638 */	NdrFcLong( 0x12 ),	/* 18 */
/* 642 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 644 */	NdrFcLong( 0x13 ),	/* 19 */
/* 648 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 650 */	NdrFcLong( 0x15 ),	/* 21 */
/* 654 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 656 */	NdrFcLong( 0x16 ),	/* 22 */
/* 660 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 662 */	NdrFcLong( 0x17 ),	/* 23 */
/* 666 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 668 */	NdrFcLong( 0xe ),	/* 14 */
/* 672 */	NdrFcShort( 0xbe ),	/* Offset= 190 (862) */
/* 674 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 678 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (872) */
/* 680 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 684 */	NdrFcShort( 0xc0 ),	/* Offset= 192 (876) */
/* 686 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 690 */	NdrFcShort( 0x74 ),	/* Offset= 116 (806) */
/* 692 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 696 */	NdrFcShort( 0x72 ),	/* Offset= 114 (810) */
/* 698 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 702 */	NdrFcShort( 0x70 ),	/* Offset= 112 (814) */
/* 704 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 708 */	NdrFcShort( 0x66 ),	/* Offset= 102 (810) */
/* 710 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 714 */	NdrFcShort( 0x60 ),	/* Offset= 96 (810) */
/* 716 */	NdrFcLong( 0x0 ),	/* 0 */
/* 720 */	NdrFcShort( 0x0 ),	/* Offset= 0 (720) */
/* 722 */	NdrFcLong( 0x1 ),	/* 1 */
/* 726 */	NdrFcShort( 0x0 ),	/* Offset= 0 (726) */
/* 728 */	NdrFcShort( 0xffff ),	/* Offset= -1 (727) */
/* 730 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 732 */	NdrFcShort( 0x8 ),	/* 8 */
/* 734 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 736 */	
			0x13, 0x0,	/* FC_OP */
/* 738 */	NdrFcShort( 0xfd8c ),	/* Offset= -628 (110) */
/* 740 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 742 */	NdrFcShort( 0x2 ),	/* Offset= 2 (744) */
/* 744 */	
			0x13, 0x0,	/* FC_OP */
/* 746 */	NdrFcShort( 0x1b8 ),	/* Offset= 440 (1186) */
/* 748 */	
			0x13, 0x0,	/* FC_OP */
/* 750 */	NdrFcShort( 0x20 ),	/* Offset= 32 (782) */
/* 752 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 754 */	NdrFcLong( 0x2f ),	/* 47 */
/* 758 */	NdrFcShort( 0x0 ),	/* 0 */
/* 760 */	NdrFcShort( 0x0 ),	/* 0 */
/* 762 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 764 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 766 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 768 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 770 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 772 */	NdrFcShort( 0x1 ),	/* 1 */
/* 774 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 776 */	NdrFcShort( 0x4 ),	/* 4 */
/* 778 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 780 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 782 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 784 */	NdrFcShort( 0x10 ),	/* 16 */
/* 786 */	NdrFcShort( 0x0 ),	/* 0 */
/* 788 */	NdrFcShort( 0xa ),	/* Offset= 10 (798) */
/* 790 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 792 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 794 */	NdrFcShort( 0xffd6 ),	/* Offset= -42 (752) */
/* 796 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 798 */	
			0x13, 0x0,	/* FC_OP */
/* 800 */	NdrFcShort( 0xffe2 ),	/* Offset= -30 (770) */
/* 802 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 804 */	0x1,		/* FC_BYTE */
			0x5c,		/* FC_PAD */
/* 806 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 808 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 810 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 812 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 814 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 816 */	0xb,		/* FC_HYPER */
			0x5c,		/* FC_PAD */
/* 818 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 820 */	0xa,		/* FC_FLOAT */
			0x5c,		/* FC_PAD */
/* 822 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 824 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 826 */	
			0x13, 0x0,	/* FC_OP */
/* 828 */	NdrFcShort( 0xff9e ),	/* Offset= -98 (730) */
/* 830 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 832 */	NdrFcShort( 0xffa0 ),	/* Offset= -96 (736) */
/* 834 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 836 */	NdrFcShort( 0xfdfc ),	/* Offset= -516 (320) */
/* 838 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 840 */	NdrFcShort( 0xfe30 ),	/* Offset= -464 (376) */
/* 842 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 844 */	NdrFcShort( 0x2 ),	/* Offset= 2 (846) */
/* 846 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 848 */	NdrFcShort( 0x2 ),	/* Offset= 2 (850) */
/* 850 */	
			0x13, 0x0,	/* FC_OP */
/* 852 */	NdrFcShort( 0x14e ),	/* Offset= 334 (1186) */
/* 854 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 856 */	NdrFcShort( 0x2 ),	/* Offset= 2 (858) */
/* 858 */	
			0x13, 0x0,	/* FC_OP */
/* 860 */	NdrFcShort( 0x14 ),	/* Offset= 20 (880) */
/* 862 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 864 */	NdrFcShort( 0x10 ),	/* 16 */
/* 866 */	0x6,		/* FC_SHORT */
			0x1,		/* FC_BYTE */
/* 868 */	0x1,		/* FC_BYTE */
			0x8,		/* FC_LONG */
/* 870 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 872 */	
			0x13, 0x0,	/* FC_OP */
/* 874 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (862) */
/* 876 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 878 */	0x2,		/* FC_CHAR */
			0x5c,		/* FC_PAD */
/* 880 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x7,		/* 7 */
/* 882 */	NdrFcShort( 0x20 ),	/* 32 */
/* 884 */	NdrFcShort( 0x0 ),	/* 0 */
/* 886 */	NdrFcShort( 0x0 ),	/* Offset= 0 (886) */
/* 888 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 890 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 892 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 894 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 896 */	NdrFcShort( 0xfe30 ),	/* Offset= -464 (432) */
/* 898 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 900 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 902 */	NdrFcShort( 0x4 ),	/* 4 */
/* 904 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 906 */	NdrFcShort( 0x0 ),	/* 0 */
/* 908 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 910 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 912 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 914 */	NdrFcShort( 0x4 ),	/* 4 */
/* 916 */	NdrFcShort( 0x0 ),	/* 0 */
/* 918 */	NdrFcShort( 0x1 ),	/* 1 */
/* 920 */	NdrFcShort( 0x0 ),	/* 0 */
/* 922 */	NdrFcShort( 0x0 ),	/* 0 */
/* 924 */	0x13, 0x0,	/* FC_OP */
/* 926 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (880) */
/* 928 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 930 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 932 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 934 */	NdrFcShort( 0x8 ),	/* 8 */
/* 936 */	NdrFcShort( 0x0 ),	/* 0 */
/* 938 */	NdrFcShort( 0x6 ),	/* Offset= 6 (944) */
/* 940 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 942 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 944 */	
			0x11, 0x0,	/* FC_RP */
/* 946 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (900) */
/* 948 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 950 */	NdrFcShort( 0x4 ),	/* 4 */
/* 952 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 954 */	NdrFcShort( 0x0 ),	/* 0 */
/* 956 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 958 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 960 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 962 */	NdrFcShort( 0x4 ),	/* 4 */
/* 964 */	NdrFcShort( 0x0 ),	/* 0 */
/* 966 */	NdrFcShort( 0x1 ),	/* 1 */
/* 968 */	NdrFcShort( 0x0 ),	/* 0 */
/* 970 */	NdrFcShort( 0x0 ),	/* 0 */
/* 972 */	0x13, 0x0,	/* FC_OP */
/* 974 */	NdrFcShort( 0xff40 ),	/* Offset= -192 (782) */
/* 976 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 978 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 980 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 982 */	NdrFcShort( 0x8 ),	/* 8 */
/* 984 */	NdrFcShort( 0x0 ),	/* 0 */
/* 986 */	NdrFcShort( 0x6 ),	/* Offset= 6 (992) */
/* 988 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 990 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 992 */	
			0x11, 0x0,	/* FC_RP */
/* 994 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (948) */
/* 996 */	
			0x1d,		/* FC_SMFARRAY */
			0x0,		/* 0 */
/* 998 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1000 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1002 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1004 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1006 */	0x8,		/* FC_LONG */
			0x6,		/* FC_SHORT */
/* 1008 */	0x6,		/* FC_SHORT */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 1010 */	0x0,		/* 0 */
			NdrFcShort( 0xfff1 ),	/* Offset= -15 (996) */
			0x5b,		/* FC_END */
/* 1014 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1016 */	NdrFcShort( 0x18 ),	/* 24 */
/* 1018 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1020 */	NdrFcShort( 0xa ),	/* Offset= 10 (1030) */
/* 1022 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1024 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1026 */	NdrFcShort( 0xffe8 ),	/* Offset= -24 (1002) */
/* 1028 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1030 */	
			0x11, 0x0,	/* FC_RP */
/* 1032 */	NdrFcShort( 0xfd4a ),	/* Offset= -694 (338) */
/* 1034 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 1036 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1038 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1040 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1042 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1044 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1046 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1048 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1050 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1052 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1054 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1056 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1058 */	0x13, 0x0,	/* FC_OP */
/* 1060 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1034) */
/* 1062 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1064 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1066 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 1068 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1070 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1072 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1074 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1076 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 1078 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1080 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1082 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1084 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1086 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1088 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1090 */	0x13, 0x0,	/* FC_OP */
/* 1092 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1066) */
/* 1094 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1096 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1098 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1100 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1102 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1104 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1106 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1108 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1110 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1112 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1114 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1116 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1118 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1120 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1122 */	0x13, 0x0,	/* FC_OP */
/* 1124 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1098) */
/* 1126 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1128 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1130 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 1132 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1134 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1136 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1138 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1140 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 1142 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1144 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1146 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1148 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1150 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1152 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1154 */	0x13, 0x0,	/* FC_OP */
/* 1156 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1130) */
/* 1158 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1160 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1162 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1164 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1166 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1168 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1170 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1172 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1174 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 1176 */	NdrFcShort( 0xffd8 ),	/* -40 */
/* 1178 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1180 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1182 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1162) */
/* 1184 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1186 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1188 */	NdrFcShort( 0x28 ),	/* 40 */
/* 1190 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1170) */
/* 1192 */	NdrFcShort( 0x0 ),	/* Offset= 0 (1192) */
/* 1194 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1196 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1198 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1200 */	NdrFcShort( 0xfc18 ),	/* Offset= -1000 (200) */
/* 1202 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1204 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1206 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1208 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1210 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1212 */	NdrFcShort( 0xfc04 ),	/* Offset= -1020 (192) */
/* 1214 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 1216 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1218) */
/* 1218 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1220 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1222 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1224 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1226 */	NdrFcShort( 0xfe16 ),	/* Offset= -490 (736) */
/* 1228 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1230 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1232) */
/* 1232 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1234 */	NdrFcLong( 0x83229bf2 ),	/* -2094883854 */
/* 1238 */	NdrFcShort( 0x7eb9 ),	/* 32441 */
/* 1240 */	NdrFcShort( 0x428d ),	/* 17037 */
/* 1242 */	0xb8,		/* 184 */
			0x32,		/* 50 */
/* 1244 */	0x83,		/* 131 */
			0x1c,		/* 28 */
/* 1246 */	0xac,		/* 172 */
			0xfa,		/* 250 */
/* 1248 */	0xe7,		/* 231 */
			0x8c,		/* 140 */
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
/* 1304 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1306 */	NdrFcLong( 0x5f688d62 ),	/* 1600687458 */
/* 1310 */	NdrFcShort( 0xbce3 ),	/* -17181 */
/* 1312 */	NdrFcShort( 0x4787 ),	/* 18311 */
/* 1314 */	0x95,		/* 149 */
			0xc5,		/* 197 */
/* 1316 */	0x36,		/* 54 */
			0x11,		/* 17 */
/* 1318 */	0x86,		/* 134 */
			0x86,		/* 134 */
/* 1320 */	0xc2,		/* 194 */
			0xd1,		/* 209 */
/* 1322 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1324 */	NdrFcLong( 0x8d366f71 ),	/* -1925812367 */
/* 1328 */	NdrFcShort( 0xea60 ),	/* -5536 */
/* 1330 */	NdrFcShort( 0x4812 ),	/* 18450 */
/* 1332 */	0xaf,		/* 175 */
			0xcd,		/* 205 */
/* 1334 */	0xbc,		/* 188 */
			0x5a,		/* 90 */
/* 1336 */	0x20,		/* 32 */
			0x29,		/* 41 */
/* 1338 */	0x7f,		/* 127 */
			0xdd,		/* 221 */
/* 1340 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1342 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1344) */
/* 1344 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1346 */	NdrFcLong( 0xe7a4dbc7 ),	/* -408626233 */
/* 1350 */	NdrFcShort( 0x26f3 ),	/* 9971 */
/* 1352 */	NdrFcShort( 0x487b ),	/* 18555 */
/* 1354 */	0x9e,		/* 158 */
			0xad,		/* 173 */
/* 1356 */	0xe2,		/* 226 */
			0xa7,		/* 167 */
/* 1358 */	0xf6,		/* 246 */
			0xaf,		/* 175 */
/* 1360 */	0x82,		/* 130 */
			0xe1,		/* 225 */
/* 1362 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1364 */	NdrFcLong( 0xf42fa761 ),	/* -198203551 */
/* 1368 */	NdrFcShort( 0x5767 ),	/* 22375 */
/* 1370 */	NdrFcShort( 0x4c66 ),	/* 19558 */
/* 1372 */	0x8e,		/* 142 */
			0x91,		/* 145 */
/* 1374 */	0x4a,		/* 74 */
			0xc5,		/* 197 */
/* 1376 */	0xec,		/* 236 */
			0x15,		/* 21 */
/* 1378 */	0xae,		/* 174 */
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
    0,
    954
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
    720,
    792,
    822,
    996,
    1038,
    1074
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
    1110,
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
    1152,
    1188,
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
    1224,
    1260,
    1296,
    1332,
    1368,
    1404,
    1446,
    1488,
    1524
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
    1560,
    1596,
    1632,
    1668,
    240,
    1704,
    1740,
    1776
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
    1812,
    1848
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
    1884,
    1920
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
    1152,
    1956
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
    1152,
    954
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
    1998,
    2046,
    2088
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
    ( CInterfaceProxyVtbl *) &_IDummyProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProjectiveBundleProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IHomotopParamsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISerializerProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IExportDataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISubdevidableProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IMorsableProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IExtendableProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISerializerOutputDataProxyVtbl,
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
    ( CInterfaceStubVtbl *) &_ISerializerStubVtbl,
    ( CInterfaceStubVtbl *) &_IExportDataStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationResultStubVtbl,
    ( CInterfaceStubVtbl *) &_ISubdevidableStubVtbl,
    ( CInterfaceStubVtbl *) &_IMorsableStubVtbl,
    ( CInterfaceStubVtbl *) &_IExtendableStubVtbl,
    ( CInterfaceStubVtbl *) &_ISerializerOutputDataStubVtbl,
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
    "ISerializer",
    "IExportData",
    "IComputationResult",
    "ISubdevidable",
    "IMorsable",
    "IExtendable",
    "ISerializerOutputData",
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
    0
};


#define __MorseKernelATL_CHECK_IID(n)	IID_GENERIC_CHECK_IID( __MorseKernelATL, pIID, n)

int __stdcall __MorseKernelATL_IID_Lookup( const IID * pIID, int * pIndex )
{
    IID_BS_LOOKUP_SETUP

    IID_BS_LOOKUP_INITIAL_TEST( __MorseKernelATL, 37, 32 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 16 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 8 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 4 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 2 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernelATL, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( __MorseKernelATL, 37, *pIndex )
    
}

const ExtendedProxyFileInfo _MorseKernelATL_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & __MorseKernelATL_ProxyVtblList,
    (PCInterfaceStubVtblList *) & __MorseKernelATL_StubVtblList,
    (const PCInterfaceName * ) & __MorseKernelATL_InterfaceNamesList,
    (const IID ** ) & __MorseKernelATL_BaseIIDList,
    & __MorseKernelATL_IID_Lookup, 
    37,
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

