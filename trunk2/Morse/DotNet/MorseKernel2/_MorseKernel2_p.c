

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Sat Mar 12 01:22:44 2005
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

#define TYPE_FORMAT_STRING_SIZE   1409                              
#define PROC_FORMAT_STRING_SIZE   1597                              
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


extern const MIDL_SERVER_INFO IResultBase_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResultBase_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResultMerger_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResultMerger_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IActionManager_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IActionManager_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IProgressBarInfo_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IProgressBarInfo_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO INode_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO INode_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IActionFactory_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IActionFactory_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IActionAllocator_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IActionAllocator_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableActionAllocator_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableActionAllocator_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableActionManager_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableActionManager_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComponentRegistrar_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComponentRegistrar_ProxyInfo;


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


extern const MIDL_SERVER_INFO IGroupNode_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGroupNode_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernell_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernell_ProxyInfo;


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

	/* Procedure AddResult */

			0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/*  2 */	NdrFcLong( 0x0 ),	/* 0 */
/*  6 */	NdrFcShort( 0x7 ),	/* 7 */
/*  8 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 10 */	NdrFcShort( 0x0 ),	/* 0 */
/* 12 */	NdrFcShort( 0x8 ),	/* 8 */
/* 14 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 16 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 18 */	NdrFcShort( 0x0 ),	/* 0 */
/* 20 */	NdrFcShort( 0x0 ),	/* 0 */
/* 22 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 24 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 26 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 28 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Return value */

/* 30 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 32 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 34 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CanAddResult */

/* 36 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 38 */	NdrFcLong( 0x0 ),	/* 0 */
/* 42 */	NdrFcShort( 0x8 ),	/* 8 */
/* 44 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 46 */	NdrFcShort( 0x0 ),	/* 0 */
/* 48 */	NdrFcShort( 0x22 ),	/* 34 */
/* 50 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 52 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 54 */	NdrFcShort( 0x0 ),	/* 0 */
/* 56 */	NdrFcShort( 0x0 ),	/* 0 */
/* 58 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 60 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 62 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 64 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Parameter value */

/* 66 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 68 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 70 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 72 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 74 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 76 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateResult */

/* 78 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 80 */	NdrFcLong( 0x0 ),	/* 0 */
/* 84 */	NdrFcShort( 0x9 ),	/* 9 */
/* 86 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 88 */	NdrFcShort( 0x0 ),	/* 0 */
/* 90 */	NdrFcShort( 0x8 ),	/* 8 */
/* 92 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 94 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 96 */	NdrFcShort( 0x0 ),	/* 0 */
/* 98 */	NdrFcShort( 0x0 ),	/* 0 */
/* 100 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 102 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 104 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 106 */	NdrFcShort( 0x18 ),	/* Type Offset=24 */

	/* Return value */

/* 108 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 110 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 112 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetResultMerger */

/* 114 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 116 */	NdrFcLong( 0x0 ),	/* 0 */
/* 120 */	NdrFcShort( 0x7 ),	/* 7 */
/* 122 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 124 */	NdrFcShort( 0x0 ),	/* 0 */
/* 126 */	NdrFcShort( 0x8 ),	/* 8 */
/* 128 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 130 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 132 */	NdrFcShort( 0x0 ),	/* 0 */
/* 134 */	NdrFcShort( 0x0 ),	/* 0 */
/* 136 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter merger */

/* 138 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 140 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 142 */	NdrFcShort( 0x1c ),	/* Type Offset=28 */

	/* Return value */

/* 144 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 146 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 148 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetLength */

/* 150 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 152 */	NdrFcLong( 0x0 ),	/* 0 */
/* 156 */	NdrFcShort( 0x7 ),	/* 7 */
/* 158 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 160 */	NdrFcShort( 0x1c ),	/* 28 */
/* 162 */	NdrFcShort( 0x8 ),	/* 8 */
/* 164 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 166 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 168 */	NdrFcShort( 0x0 ),	/* 0 */
/* 170 */	NdrFcShort( 0x0 ),	/* 0 */
/* 172 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter count */

/* 174 */	NdrFcShort( 0x148 ),	/* Flags:  in, base type, simple ref, */
/* 176 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 178 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 180 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 182 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 184 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetAction */

/* 186 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 188 */	NdrFcLong( 0x0 ),	/* 0 */
/* 192 */	NdrFcShort( 0x8 ),	/* 8 */
/* 194 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 196 */	NdrFcShort( 0x8 ),	/* 8 */
/* 198 */	NdrFcShort( 0x8 ),	/* 8 */
/* 200 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 202 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 204 */	NdrFcShort( 0x0 ),	/* 0 */
/* 206 */	NdrFcShort( 0x0 ),	/* 0 */
/* 208 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 210 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 212 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 214 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter action */

/* 216 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 218 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 220 */	NdrFcShort( 0x36 ),	/* Type Offset=54 */

	/* Return value */

/* 222 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 224 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 226 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetNextActionManager */

/* 228 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 230 */	NdrFcLong( 0x0 ),	/* 0 */
/* 234 */	NdrFcShort( 0x7 ),	/* 7 */
/* 236 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 238 */	NdrFcShort( 0x0 ),	/* 0 */
/* 240 */	NdrFcShort( 0x8 ),	/* 8 */
/* 242 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 244 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 246 */	NdrFcShort( 0x0 ),	/* 0 */
/* 248 */	NdrFcShort( 0x0 ),	/* 0 */
/* 250 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter manager */

/* 252 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 254 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 256 */	NdrFcShort( 0x4c ),	/* Type Offset=76 */

	/* Return value */

/* 258 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 260 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 262 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetActionParameters */

/* 264 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 266 */	NdrFcLong( 0x0 ),	/* 0 */
/* 270 */	NdrFcShort( 0x8 ),	/* 8 */
/* 272 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 274 */	NdrFcShort( 0x0 ),	/* 0 */
/* 276 */	NdrFcShort( 0x8 ),	/* 8 */
/* 278 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 280 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 282 */	NdrFcShort( 0x0 ),	/* 0 */
/* 284 */	NdrFcShort( 0x0 ),	/* 0 */
/* 286 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter parameters */

/* 288 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 290 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 292 */	NdrFcShort( 0x62 ),	/* Type Offset=98 */

	/* Return value */

/* 294 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 296 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 298 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Do */

/* 300 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 302 */	NdrFcLong( 0x0 ),	/* 0 */
/* 306 */	NdrFcShort( 0x9 ),	/* 9 */
/* 308 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 310 */	NdrFcShort( 0x0 ),	/* 0 */
/* 312 */	NdrFcShort( 0x8 ),	/* 8 */
/* 314 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 316 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 318 */	NdrFcShort( 0x0 ),	/* 0 */
/* 320 */	NdrFcShort( 0x0 ),	/* 0 */
/* 322 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter input */

/* 324 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 326 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 328 */	NdrFcShort( 0x74 ),	/* Type Offset=116 */

	/* Parameter output */

/* 330 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 332 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 334 */	NdrFcShort( 0x86 ),	/* Type Offset=134 */

	/* Return value */

/* 336 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 338 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 340 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetProgressBarInfo */

/* 342 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 344 */	NdrFcLong( 0x0 ),	/* 0 */
/* 348 */	NdrFcShort( 0xa ),	/* 10 */
/* 350 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 352 */	NdrFcShort( 0x0 ),	/* 0 */
/* 354 */	NdrFcShort( 0x8 ),	/* 8 */
/* 356 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 358 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 360 */	NdrFcShort( 0x0 ),	/* 0 */
/* 362 */	NdrFcShort( 0x0 ),	/* 0 */
/* 364 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pinfo */

/* 366 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 368 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 370 */	NdrFcShort( 0x8a ),	/* Type Offset=138 */

	/* Return value */

/* 372 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 374 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 376 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure IsChainLeaf */

/* 378 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 380 */	NdrFcLong( 0x0 ),	/* 0 */
/* 384 */	NdrFcShort( 0xb ),	/* 11 */
/* 386 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 388 */	NdrFcShort( 0x0 ),	/* 0 */
/* 390 */	NdrFcShort( 0x22 ),	/* 34 */
/* 392 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 394 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 396 */	NdrFcShort( 0x0 ),	/* 0 */
/* 398 */	NdrFcShort( 0x0 ),	/* 0 */
/* 400 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 402 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 404 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 406 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 408 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 410 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 412 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetActionManager */

/* 414 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 416 */	NdrFcLong( 0x0 ),	/* 0 */
/* 420 */	NdrFcShort( 0x7 ),	/* 7 */
/* 422 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 424 */	NdrFcShort( 0x0 ),	/* 0 */
/* 426 */	NdrFcShort( 0x8 ),	/* 8 */
/* 428 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 430 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 432 */	NdrFcShort( 0x0 ),	/* 0 */
/* 434 */	NdrFcShort( 0x0 ),	/* 0 */
/* 436 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter manager */

/* 438 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 440 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 442 */	NdrFcShort( 0x9c ),	/* Type Offset=156 */

	/* Return value */

/* 444 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 446 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 448 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetResult */

/* 450 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 452 */	NdrFcLong( 0x0 ),	/* 0 */
/* 456 */	NdrFcShort( 0x8 ),	/* 8 */
/* 458 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 460 */	NdrFcShort( 0x0 ),	/* 0 */
/* 462 */	NdrFcShort( 0x8 ),	/* 8 */
/* 464 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 466 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 468 */	NdrFcShort( 0x0 ),	/* 0 */
/* 470 */	NdrFcShort( 0x0 ),	/* 0 */
/* 472 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 474 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 476 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 478 */	NdrFcShort( 0x86 ),	/* Type Offset=134 */

	/* Return value */

/* 480 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 482 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 484 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CanCreateActionFromNode */

/* 486 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 488 */	NdrFcLong( 0x0 ),	/* 0 */
/* 492 */	NdrFcShort( 0x7 ),	/* 7 */
/* 494 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 496 */	NdrFcShort( 0x0 ),	/* 0 */
/* 498 */	NdrFcShort( 0x22 ),	/* 34 */
/* 500 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 502 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 504 */	NdrFcShort( 0x0 ),	/* 0 */
/* 506 */	NdrFcShort( 0x0 ),	/* 0 */
/* 508 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 510 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 512 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 514 */	NdrFcShort( 0xb2 ),	/* Type Offset=178 */

	/* Parameter result */

/* 516 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 518 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 520 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 522 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 524 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 526 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateActionFromNode */

/* 528 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 530 */	NdrFcLong( 0x0 ),	/* 0 */
/* 534 */	NdrFcShort( 0x8 ),	/* 8 */
/* 536 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 538 */	NdrFcShort( 0x0 ),	/* 0 */
/* 540 */	NdrFcShort( 0x8 ),	/* 8 */
/* 542 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 544 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 546 */	NdrFcShort( 0x0 ),	/* 0 */
/* 548 */	NdrFcShort( 0x0 ),	/* 0 */
/* 550 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 552 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 554 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 556 */	NdrFcShort( 0xb2 ),	/* Type Offset=178 */

	/* Parameter action */

/* 558 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 560 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 562 */	NdrFcShort( 0x36 ),	/* Type Offset=54 */

	/* Return value */

/* 564 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 566 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 568 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CanCreateActionFromAction */

/* 570 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 572 */	NdrFcLong( 0x0 ),	/* 0 */
/* 576 */	NdrFcShort( 0x9 ),	/* 9 */
/* 578 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 580 */	NdrFcShort( 0x0 ),	/* 0 */
/* 582 */	NdrFcShort( 0x22 ),	/* 34 */
/* 584 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 586 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 588 */	NdrFcShort( 0x0 ),	/* 0 */
/* 590 */	NdrFcShort( 0x0 ),	/* 0 */
/* 592 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter action */

/* 594 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 596 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 598 */	NdrFcShort( 0x3a ),	/* Type Offset=58 */

	/* Parameter result */

/* 600 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 602 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 604 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 606 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 608 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 610 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateActionFromAction */

/* 612 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 614 */	NdrFcLong( 0x0 ),	/* 0 */
/* 618 */	NdrFcShort( 0xa ),	/* 10 */
/* 620 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 622 */	NdrFcShort( 0x0 ),	/* 0 */
/* 624 */	NdrFcShort( 0x8 ),	/* 8 */
/* 626 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 628 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 630 */	NdrFcShort( 0x0 ),	/* 0 */
/* 632 */	NdrFcShort( 0x0 ),	/* 0 */
/* 634 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter action */

/* 636 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 638 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 640 */	NdrFcShort( 0x3a ),	/* Type Offset=58 */

	/* Parameter result */

/* 642 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 644 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 646 */	NdrFcShort( 0x36 ),	/* Type Offset=54 */

	/* Return value */

/* 648 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 650 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 652 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AllocateActionManagerForNode */

/* 654 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 656 */	NdrFcLong( 0x0 ),	/* 0 */
/* 660 */	NdrFcShort( 0x7 ),	/* 7 */
/* 662 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 664 */	NdrFcShort( 0x0 ),	/* 0 */
/* 666 */	NdrFcShort( 0x8 ),	/* 8 */
/* 668 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 670 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 672 */	NdrFcShort( 0x0 ),	/* 0 */
/* 674 */	NdrFcShort( 0x0 ),	/* 0 */
/* 676 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 678 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 680 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 682 */	NdrFcShort( 0xb2 ),	/* Type Offset=178 */

	/* Parameter manager */

/* 684 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 686 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 688 */	NdrFcShort( 0x9c ),	/* Type Offset=156 */

	/* Return value */

/* 690 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 692 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 694 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AllocateActionManagerForAction */

/* 696 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 698 */	NdrFcLong( 0x0 ),	/* 0 */
/* 702 */	NdrFcShort( 0x8 ),	/* 8 */
/* 704 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 706 */	NdrFcShort( 0x0 ),	/* 0 */
/* 708 */	NdrFcShort( 0x8 ),	/* 8 */
/* 710 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 712 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 714 */	NdrFcShort( 0x0 ),	/* 0 */
/* 716 */	NdrFcShort( 0x0 ),	/* 0 */
/* 718 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter action */

/* 720 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 722 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 724 */	NdrFcShort( 0xc4 ),	/* Type Offset=196 */

	/* Parameter manager */

/* 726 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 728 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 730 */	NdrFcShort( 0x9c ),	/* Type Offset=156 */

	/* Return value */

/* 732 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 734 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 736 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterActionFactory */

/* 738 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 740 */	NdrFcLong( 0x0 ),	/* 0 */
/* 744 */	NdrFcShort( 0x7 ),	/* 7 */
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

	/* Parameter action */

/* 762 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 764 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 766 */	NdrFcShort( 0xd6 ),	/* Type Offset=214 */

	/* Return value */

/* 768 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 770 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 772 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AddAction */

/* 774 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 776 */	NdrFcLong( 0x0 ),	/* 0 */
/* 780 */	NdrFcShort( 0x7 ),	/* 7 */
/* 782 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 784 */	NdrFcShort( 0x0 ),	/* 0 */
/* 786 */	NdrFcShort( 0x8 ),	/* 8 */
/* 788 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 790 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 792 */	NdrFcShort( 0x0 ),	/* 0 */
/* 794 */	NdrFcShort( 0x0 ),	/* 0 */
/* 796 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter action */

/* 798 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 800 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 802 */	NdrFcShort( 0xc4 ),	/* Type Offset=196 */

	/* Return value */

/* 804 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 806 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 808 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Attach */

/* 810 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 812 */	NdrFcLong( 0x0 ),	/* 0 */
/* 816 */	NdrFcShort( 0x7 ),	/* 7 */
/* 818 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 820 */	NdrFcShort( 0x0 ),	/* 0 */
/* 822 */	NdrFcShort( 0x8 ),	/* 8 */
/* 824 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 826 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 828 */	NdrFcShort( 0x0 ),	/* 0 */
/* 830 */	NdrFcShort( 0x1 ),	/* 1 */
/* 832 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrPath */

/* 834 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 836 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 838 */	NdrFcShort( 0x102 ),	/* Type Offset=258 */

	/* Return value */

/* 840 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 842 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 844 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterAll */

/* 846 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 848 */	NdrFcLong( 0x0 ),	/* 0 */
/* 852 */	NdrFcShort( 0x8 ),	/* 8 */
/* 854 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 856 */	NdrFcShort( 0x0 ),	/* 0 */
/* 858 */	NdrFcShort( 0x8 ),	/* 8 */
/* 860 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 862 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 864 */	NdrFcShort( 0x0 ),	/* 0 */
/* 866 */	NdrFcShort( 0x0 ),	/* 0 */
/* 868 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 870 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 872 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 874 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterAll */

/* 876 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 878 */	NdrFcLong( 0x0 ),	/* 0 */
/* 882 */	NdrFcShort( 0x9 ),	/* 9 */
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

/* 900 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 902 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 904 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetComponents */

/* 906 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 908 */	NdrFcLong( 0x0 ),	/* 0 */
/* 912 */	NdrFcShort( 0xa ),	/* 10 */
/* 914 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 916 */	NdrFcShort( 0x0 ),	/* 0 */
/* 918 */	NdrFcShort( 0x8 ),	/* 8 */
/* 920 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 922 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 924 */	NdrFcShort( 0x24 ),	/* 36 */
/* 926 */	NdrFcShort( 0x0 ),	/* 0 */
/* 928 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pbstrCLSIDs */

/* 930 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 932 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 934 */	NdrFcShort( 0x52c ),	/* Type Offset=1324 */

	/* Parameter pbstrDescriptions */

/* 936 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 938 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 940 */	NdrFcShort( 0x52c ),	/* Type Offset=1324 */

	/* Return value */

/* 942 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 944 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 946 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterComponent */

/* 948 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 950 */	NdrFcLong( 0x0 ),	/* 0 */
/* 954 */	NdrFcShort( 0xb ),	/* 11 */
/* 956 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 958 */	NdrFcShort( 0x0 ),	/* 0 */
/* 960 */	NdrFcShort( 0x8 ),	/* 8 */
/* 962 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 964 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 966 */	NdrFcShort( 0x0 ),	/* 0 */
/* 968 */	NdrFcShort( 0x1 ),	/* 1 */
/* 970 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 972 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 974 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 976 */	NdrFcShort( 0x102 ),	/* Type Offset=258 */

	/* Return value */

/* 978 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 980 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 982 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterComponent */

/* 984 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 986 */	NdrFcLong( 0x0 ),	/* 0 */
/* 990 */	NdrFcShort( 0xc ),	/* 12 */
/* 992 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 994 */	NdrFcShort( 0x0 ),	/* 0 */
/* 996 */	NdrFcShort( 0x8 ),	/* 8 */
/* 998 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1000 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1002 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1004 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1006 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 1008 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1010 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1012 */	NdrFcShort( 0x102 ),	/* Type Offset=258 */

	/* Return value */

/* 1014 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1016 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1018 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetLength */


	/* Procedure GetNodes */

/* 1020 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1022 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1026 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1028 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1030 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1032 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1034 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1036 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1038 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1040 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1042 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter count */


	/* Parameter value */

/* 1044 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1046 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1048 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 1050 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1052 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1054 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetEdges */

/* 1056 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1058 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1062 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1064 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1066 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1068 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1070 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1072 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1074 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1076 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1078 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 1080 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1082 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1084 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1086 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1088 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1090 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetCount */


	/* Procedure GetDimension */

/* 1092 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1094 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1098 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1100 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1102 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1104 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1106 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1108 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1110 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1112 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1114 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter count */


	/* Parameter value */

/* 1116 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1118 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1120 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 1122 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1124 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1126 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMinimum */

/* 1128 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1130 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1134 */	NdrFcShort( 0xa ),	/* 10 */
/* 1136 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1138 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1140 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1142 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1144 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1146 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1148 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1150 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1152 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1154 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1156 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 1158 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1160 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1162 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1164 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1166 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1168 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMaximum */

/* 1170 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1172 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1176 */	NdrFcShort( 0xb ),	/* 11 */
/* 1178 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1180 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1182 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1184 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1186 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1188 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1190 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1192 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1194 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1196 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1198 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 1200 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1202 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1204 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1206 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1208 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1210 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGridNumber */

/* 1212 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1214 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1218 */	NdrFcShort( 0xc ),	/* 12 */
/* 1220 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1222 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1224 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1226 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1228 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1230 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1232 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1234 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1236 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1238 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1240 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 1242 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1244 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1246 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1248 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1250 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1252 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGridSize */

/* 1254 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1256 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1260 */	NdrFcShort( 0xd ),	/* 13 */
/* 1262 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1264 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1266 */	NdrFcShort( 0x2c ),	/* 44 */
/* 1268 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1270 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1272 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1274 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1276 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1278 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1280 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1282 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 1284 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1286 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1288 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1290 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1292 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1294 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGraphInfo */

/* 1296 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1298 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1302 */	NdrFcShort( 0xa ),	/* 10 */
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

	/* Parameter info */

/* 1320 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1322 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1324 */	NdrFcShort( 0x53e ),	/* Type Offset=1342 */

	/* Return value */

/* 1326 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1328 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1330 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGraphInfoAt */

/* 1332 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1334 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1338 */	NdrFcShort( 0xb ),	/* 11 */
/* 1340 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1342 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1344 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1346 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 1348 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1350 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1352 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1354 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1356 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1358 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1360 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter info */

/* 1362 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1364 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1366 */	NdrFcShort( 0x53e ),	/* Type Offset=1342 */

	/* Return value */

/* 1368 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1370 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1372 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure IsStrongComponent */

/* 1374 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1376 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1380 */	NdrFcShort( 0xc ),	/* 12 */
/* 1382 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1384 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1386 */	NdrFcShort( 0x22 ),	/* 34 */
/* 1388 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1390 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1392 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1394 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1396 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 1398 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1400 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1402 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 1404 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1406 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1408 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetNode */

/* 1410 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1412 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1416 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1418 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1420 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1422 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1424 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 1426 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1428 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1430 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1432 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1434 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1436 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1438 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter node */

/* 1440 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1442 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1444 */	NdrFcShort( 0x554 ),	/* Type Offset=1364 */

	/* Return value */

/* 1446 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1448 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1450 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CanAddNode */

/* 1452 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1454 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1458 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1460 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1462 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1464 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1466 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1468 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1470 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1472 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1474 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 1476 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1478 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1480 */	NdrFcShort( 0x558 ),	/* Type Offset=1368 */

	/* Return value */

/* 1482 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1484 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1486 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AddNode */

/* 1488 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1490 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1494 */	NdrFcShort( 0xa ),	/* 10 */
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

	/* Parameter node */

/* 1512 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1514 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1516 */	NdrFcShort( 0x558 ),	/* Type Offset=1368 */

	/* Return value */

/* 1518 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1520 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1522 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateNode */

/* 1524 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1526 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1530 */	NdrFcShort( 0xb ),	/* 11 */
/* 1532 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1534 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1536 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1538 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1540 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1542 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1544 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1546 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 1548 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1550 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1552 */	NdrFcShort( 0x554 ),	/* Type Offset=1364 */

	/* Return value */

/* 1554 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1556 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1558 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetActionAllocator */

/* 1560 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1562 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1566 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1568 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1570 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1572 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1574 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1576 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1578 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1580 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1582 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter allocator */

/* 1584 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1586 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1588 */	NdrFcShort( 0x56a ),	/* Type Offset=1386 */

	/* Return value */

/* 1590 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1592 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1594 */	0x8,		/* FC_LONG */
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
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/*  4 */	NdrFcLong( 0x92f4eeef ),	/* -1829441809 */
/*  8 */	NdrFcShort( 0x602a ),	/* 24618 */
/* 10 */	NdrFcShort( 0x496d ),	/* 18797 */
/* 12 */	0x80,		/* 128 */
			0x67,		/* 103 */
/* 14 */	0x51,		/* 81 */
			0x84,		/* 132 */
/* 16 */	0xf4,		/* 244 */
			0xf1,		/* 241 */
/* 18 */	0xd3,		/* 211 */
			0x7b,		/* 123 */
/* 20 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 22 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 24 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 26 */	NdrFcShort( 0xffe8 ),	/* Offset= -24 (2) */
/* 28 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 30 */	NdrFcShort( 0x2 ),	/* Offset= 2 (32) */
/* 32 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 34 */	NdrFcLong( 0x4d5b2a01 ),	/* 1297820161 */
/* 38 */	NdrFcShort( 0x1cc2 ),	/* 7362 */
/* 40 */	NdrFcShort( 0x4d56 ),	/* 19798 */
/* 42 */	0xa8,		/* 168 */
			0xd7,		/* 215 */
/* 44 */	0x67,		/* 103 */
			0xc7,		/* 199 */
/* 46 */	0x30,		/* 48 */
			0xa0,		/* 160 */
/* 48 */	0x57,		/* 87 */
			0xed,		/* 237 */
/* 50 */	
			0x11, 0x8,	/* FC_RP [simple_pointer] */
/* 52 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 54 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 56 */	NdrFcShort( 0x2 ),	/* Offset= 2 (58) */
/* 58 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 60 */	NdrFcLong( 0x285691e1 ),	/* 676762081 */
/* 64 */	NdrFcShort( 0xbfc9 ),	/* -16439 */
/* 66 */	NdrFcShort( 0x4e8b ),	/* 20107 */
/* 68 */	0xbe,		/* 190 */
			0x17,		/* 23 */
/* 70 */	0x5b,		/* 91 */
			0x1c,		/* 28 */
/* 72 */	0xc2,		/* 194 */
			0x30,		/* 48 */
/* 74 */	0x2e,		/* 46 */
			0xd9,		/* 217 */
/* 76 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 78 */	NdrFcShort( 0x2 ),	/* Offset= 2 (80) */
/* 80 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 82 */	NdrFcLong( 0x5eb44493 ),	/* 1588872339 */
/* 86 */	NdrFcShort( 0x8ff9 ),	/* -28679 */
/* 88 */	NdrFcShort( 0x486a ),	/* 18538 */
/* 90 */	0x8a,		/* 138 */
			0xbd,		/* 189 */
/* 92 */	0x9,		/* 9 */
			0xb9,		/* 185 */
/* 94 */	0xf2,		/* 242 */
			0x32,		/* 50 */
/* 96 */	0x62,		/* 98 */
			0x8a,		/* 138 */
/* 98 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 100 */	NdrFcLong( 0x16c62c7b ),	/* 382086267 */
/* 104 */	NdrFcShort( 0x6775 ),	/* 26485 */
/* 106 */	NdrFcShort( 0x4d2b ),	/* 19755 */
/* 108 */	0x9b,		/* 155 */
			0xd2,		/* 210 */
/* 110 */	0x43,		/* 67 */
			0x62,		/* 98 */
/* 112 */	0x4e,		/* 78 */
			0x1,		/* 1 */
/* 114 */	0x73,		/* 115 */
			0x8b,		/* 139 */
/* 116 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 118 */	NdrFcLong( 0x9b7d45a5 ),	/* -1686288987 */
/* 122 */	NdrFcShort( 0x77fd ),	/* 30717 */
/* 124 */	NdrFcShort( 0x4e97 ),	/* 20119 */
/* 126 */	0x8c,		/* 140 */
			0x4a,		/* 74 */
/* 128 */	0x76,		/* 118 */
			0xd3,		/* 211 */
/* 130 */	0x61,		/* 97 */
			0xc,		/* 12 */
/* 132 */	0xc8,		/* 200 */
			0x75,		/* 117 */
/* 134 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 136 */	NdrFcShort( 0xffec ),	/* Offset= -20 (116) */
/* 138 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 140 */	NdrFcLong( 0x54e003e2 ),	/* 1423967202 */
/* 144 */	NdrFcShort( 0xeaa0 ),	/* -5472 */
/* 146 */	NdrFcShort( 0x4321 ),	/* 17185 */
/* 148 */	0x9a,		/* 154 */
			0x14,		/* 20 */
/* 150 */	0x31,		/* 49 */
			0xcf,		/* 207 */
/* 152 */	0x8e,		/* 142 */
			0x5b,		/* 91 */
/* 154 */	0xcb,		/* 203 */
			0x84,		/* 132 */
/* 156 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 158 */	NdrFcShort( 0x2 ),	/* Offset= 2 (160) */
/* 160 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 162 */	NdrFcLong( 0x5eb44493 ),	/* 1588872339 */
/* 166 */	NdrFcShort( 0x8ff9 ),	/* -28679 */
/* 168 */	NdrFcShort( 0x486a ),	/* 18538 */
/* 170 */	0x8a,		/* 138 */
			0xbd,		/* 189 */
/* 172 */	0x9,		/* 9 */
			0xb9,		/* 185 */
/* 174 */	0xf2,		/* 242 */
			0x32,		/* 50 */
/* 176 */	0x62,		/* 98 */
			0x8a,		/* 138 */
/* 178 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 180 */	NdrFcLong( 0xd3beda0d ),	/* -742467059 */
/* 184 */	NdrFcShort( 0x1771 ),	/* 6001 */
/* 186 */	NdrFcShort( 0x4493 ),	/* 17555 */
/* 188 */	0xbb,		/* 187 */
			0x5c,		/* 92 */
/* 190 */	0xe9,		/* 233 */
			0x33,		/* 51 */
/* 192 */	0x84,		/* 132 */
			0x79,		/* 121 */
/* 194 */	0x2b,		/* 43 */
			0x2a,		/* 42 */
/* 196 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 198 */	NdrFcLong( 0x285691e1 ),	/* 676762081 */
/* 202 */	NdrFcShort( 0xbfc9 ),	/* -16439 */
/* 204 */	NdrFcShort( 0x4e8b ),	/* 20107 */
/* 206 */	0xbe,		/* 190 */
			0x17,		/* 23 */
/* 208 */	0x5b,		/* 91 */
			0x1c,		/* 28 */
/* 210 */	0xc2,		/* 194 */
			0x30,		/* 48 */
/* 212 */	0x2e,		/* 46 */
			0xd9,		/* 217 */
/* 214 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 216 */	NdrFcLong( 0x35f624d3 ),	/* 905323731 */
/* 220 */	NdrFcShort( 0xeb6c ),	/* -5268 */
/* 222 */	NdrFcShort( 0x4f79 ),	/* 20345 */
/* 224 */	0xab,		/* 171 */
			0x1e,		/* 30 */
/* 226 */	0xc0,		/* 192 */
			0x17,		/* 23 */
/* 228 */	0x95,		/* 149 */
			0xa0,		/* 160 */
/* 230 */	0x8c,		/* 140 */
			0x5a,		/* 90 */
/* 232 */	
			0x12, 0x0,	/* FC_UP */
/* 234 */	NdrFcShort( 0xe ),	/* Offset= 14 (248) */
/* 236 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 238 */	NdrFcShort( 0x2 ),	/* 2 */
/* 240 */	0x9,		/* Corr desc: FC_ULONG */
			0x0,		/*  */
/* 242 */	NdrFcShort( 0xfffc ),	/* -4 */
/* 244 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 246 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 248 */	
			0x17,		/* FC_CSTRUCT */
			0x3,		/* 3 */
/* 250 */	NdrFcShort( 0x8 ),	/* 8 */
/* 252 */	NdrFcShort( 0xfff0 ),	/* Offset= -16 (236) */
/* 254 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 256 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 258 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 260 */	NdrFcShort( 0x0 ),	/* 0 */
/* 262 */	NdrFcShort( 0x4 ),	/* 4 */
/* 264 */	NdrFcShort( 0x0 ),	/* 0 */
/* 266 */	NdrFcShort( 0xffde ),	/* Offset= -34 (232) */
/* 268 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 270 */	NdrFcShort( 0x41e ),	/* Offset= 1054 (1324) */
/* 272 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 274 */	NdrFcShort( 0x2 ),	/* Offset= 2 (276) */
/* 276 */	
			0x13, 0x0,	/* FC_OP */
/* 278 */	NdrFcShort( 0x404 ),	/* Offset= 1028 (1306) */
/* 280 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x49,		/* 73 */
/* 282 */	NdrFcShort( 0x18 ),	/* 24 */
/* 284 */	NdrFcShort( 0xa ),	/* 10 */
/* 286 */	NdrFcLong( 0x8 ),	/* 8 */
/* 290 */	NdrFcShort( 0x5a ),	/* Offset= 90 (380) */
/* 292 */	NdrFcLong( 0xd ),	/* 13 */
/* 296 */	NdrFcShort( 0x90 ),	/* Offset= 144 (440) */
/* 298 */	NdrFcLong( 0x9 ),	/* 9 */
/* 302 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (496) */
/* 304 */	NdrFcLong( 0xc ),	/* 12 */
/* 308 */	NdrFcShort( 0x2d2 ),	/* Offset= 722 (1030) */
/* 310 */	NdrFcLong( 0x24 ),	/* 36 */
/* 314 */	NdrFcShort( 0x2fc ),	/* Offset= 764 (1078) */
/* 316 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 320 */	NdrFcShort( 0x32e ),	/* Offset= 814 (1134) */
/* 322 */	NdrFcLong( 0x10 ),	/* 16 */
/* 326 */	NdrFcShort( 0x348 ),	/* Offset= 840 (1166) */
/* 328 */	NdrFcLong( 0x2 ),	/* 2 */
/* 332 */	NdrFcShort( 0x362 ),	/* Offset= 866 (1198) */
/* 334 */	NdrFcLong( 0x3 ),	/* 3 */
/* 338 */	NdrFcShort( 0x37c ),	/* Offset= 892 (1230) */
/* 340 */	NdrFcLong( 0x14 ),	/* 20 */
/* 344 */	NdrFcShort( 0x396 ),	/* Offset= 918 (1262) */
/* 346 */	NdrFcShort( 0xffff ),	/* Offset= -1 (345) */
/* 348 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 350 */	NdrFcShort( 0x4 ),	/* 4 */
/* 352 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 354 */	NdrFcShort( 0x0 ),	/* 0 */
/* 356 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 358 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 360 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 362 */	NdrFcShort( 0x4 ),	/* 4 */
/* 364 */	NdrFcShort( 0x0 ),	/* 0 */
/* 366 */	NdrFcShort( 0x1 ),	/* 1 */
/* 368 */	NdrFcShort( 0x0 ),	/* 0 */
/* 370 */	NdrFcShort( 0x0 ),	/* 0 */
/* 372 */	0x13, 0x0,	/* FC_OP */
/* 374 */	NdrFcShort( 0xff82 ),	/* Offset= -126 (248) */
/* 376 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 378 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 380 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 382 */	NdrFcShort( 0x8 ),	/* 8 */
/* 384 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 386 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 388 */	NdrFcShort( 0x4 ),	/* 4 */
/* 390 */	NdrFcShort( 0x4 ),	/* 4 */
/* 392 */	0x11, 0x0,	/* FC_RP */
/* 394 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (348) */
/* 396 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 398 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 400 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 402 */	NdrFcLong( 0x0 ),	/* 0 */
/* 406 */	NdrFcShort( 0x0 ),	/* 0 */
/* 408 */	NdrFcShort( 0x0 ),	/* 0 */
/* 410 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 412 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 414 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 416 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 418 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 420 */	NdrFcShort( 0x0 ),	/* 0 */
/* 422 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 424 */	NdrFcShort( 0x0 ),	/* 0 */
/* 426 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 428 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 432 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 434 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 436 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (400) */
/* 438 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 440 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 442 */	NdrFcShort( 0x8 ),	/* 8 */
/* 444 */	NdrFcShort( 0x0 ),	/* 0 */
/* 446 */	NdrFcShort( 0x6 ),	/* Offset= 6 (452) */
/* 448 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 450 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 452 */	
			0x11, 0x0,	/* FC_RP */
/* 454 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (418) */
/* 456 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 458 */	NdrFcLong( 0x20400 ),	/* 132096 */
/* 462 */	NdrFcShort( 0x0 ),	/* 0 */
/* 464 */	NdrFcShort( 0x0 ),	/* 0 */
/* 466 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 468 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 470 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 472 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 474 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 476 */	NdrFcShort( 0x0 ),	/* 0 */
/* 478 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 480 */	NdrFcShort( 0x0 ),	/* 0 */
/* 482 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 484 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 488 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 490 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 492 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (456) */
/* 494 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 496 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 498 */	NdrFcShort( 0x8 ),	/* 8 */
/* 500 */	NdrFcShort( 0x0 ),	/* 0 */
/* 502 */	NdrFcShort( 0x6 ),	/* Offset= 6 (508) */
/* 504 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 506 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 508 */	
			0x11, 0x0,	/* FC_RP */
/* 510 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (474) */
/* 512 */	
			0x2b,		/* FC_NON_ENCAPSULATED_UNION */
			0x9,		/* FC_ULONG */
/* 514 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 516 */	NdrFcShort( 0xfff8 ),	/* -8 */
/* 518 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 520 */	NdrFcShort( 0x2 ),	/* Offset= 2 (522) */
/* 522 */	NdrFcShort( 0x10 ),	/* 16 */
/* 524 */	NdrFcShort( 0x2f ),	/* 47 */
/* 526 */	NdrFcLong( 0x14 ),	/* 20 */
/* 530 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 532 */	NdrFcLong( 0x3 ),	/* 3 */
/* 536 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 538 */	NdrFcLong( 0x11 ),	/* 17 */
/* 542 */	NdrFcShort( 0x8001 ),	/* Simple arm type: FC_BYTE */
/* 544 */	NdrFcLong( 0x2 ),	/* 2 */
/* 548 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 550 */	NdrFcLong( 0x4 ),	/* 4 */
/* 554 */	NdrFcShort( 0x800a ),	/* Simple arm type: FC_FLOAT */
/* 556 */	NdrFcLong( 0x5 ),	/* 5 */
/* 560 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 562 */	NdrFcLong( 0xb ),	/* 11 */
/* 566 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 568 */	NdrFcLong( 0xa ),	/* 10 */
/* 572 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 574 */	NdrFcLong( 0x6 ),	/* 6 */
/* 578 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (810) */
/* 580 */	NdrFcLong( 0x7 ),	/* 7 */
/* 584 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 586 */	NdrFcLong( 0x8 ),	/* 8 */
/* 590 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (816) */
/* 592 */	NdrFcLong( 0xd ),	/* 13 */
/* 596 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (820) */
/* 598 */	NdrFcLong( 0x9 ),	/* 9 */
/* 602 */	NdrFcShort( 0xff6e ),	/* Offset= -146 (456) */
/* 604 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 608 */	NdrFcShort( 0xe6 ),	/* Offset= 230 (838) */
/* 610 */	NdrFcLong( 0x24 ),	/* 36 */
/* 614 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (846) */
/* 616 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 620 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (846) */
/* 622 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 626 */	NdrFcShort( 0x112 ),	/* Offset= 274 (900) */
/* 628 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 632 */	NdrFcShort( 0x110 ),	/* Offset= 272 (904) */
/* 634 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 638 */	NdrFcShort( 0x10e ),	/* Offset= 270 (908) */
/* 640 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 644 */	NdrFcShort( 0x10c ),	/* Offset= 268 (912) */
/* 646 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 650 */	NdrFcShort( 0x10a ),	/* Offset= 266 (916) */
/* 652 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 656 */	NdrFcShort( 0x108 ),	/* Offset= 264 (920) */
/* 658 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 662 */	NdrFcShort( 0xf2 ),	/* Offset= 242 (904) */
/* 664 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 668 */	NdrFcShort( 0xf0 ),	/* Offset= 240 (908) */
/* 670 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 674 */	NdrFcShort( 0xfa ),	/* Offset= 250 (924) */
/* 676 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 680 */	NdrFcShort( 0xf0 ),	/* Offset= 240 (920) */
/* 682 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 686 */	NdrFcShort( 0xf2 ),	/* Offset= 242 (928) */
/* 688 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 692 */	NdrFcShort( 0xf0 ),	/* Offset= 240 (932) */
/* 694 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 698 */	NdrFcShort( 0xee ),	/* Offset= 238 (936) */
/* 700 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 704 */	NdrFcShort( 0xec ),	/* Offset= 236 (940) */
/* 706 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 710 */	NdrFcShort( 0xf2 ),	/* Offset= 242 (952) */
/* 712 */	NdrFcLong( 0x10 ),	/* 16 */
/* 716 */	NdrFcShort( 0x8002 ),	/* Simple arm type: FC_CHAR */
/* 718 */	NdrFcLong( 0x12 ),	/* 18 */
/* 722 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 724 */	NdrFcLong( 0x13 ),	/* 19 */
/* 728 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 730 */	NdrFcLong( 0x15 ),	/* 21 */
/* 734 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 736 */	NdrFcLong( 0x16 ),	/* 22 */
/* 740 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 742 */	NdrFcLong( 0x17 ),	/* 23 */
/* 746 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 748 */	NdrFcLong( 0xe ),	/* 14 */
/* 752 */	NdrFcShort( 0xd0 ),	/* Offset= 208 (960) */
/* 754 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 758 */	NdrFcShort( 0xd4 ),	/* Offset= 212 (970) */
/* 760 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 764 */	NdrFcShort( 0xd2 ),	/* Offset= 210 (974) */
/* 766 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 770 */	NdrFcShort( 0x86 ),	/* Offset= 134 (904) */
/* 772 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 776 */	NdrFcShort( 0x84 ),	/* Offset= 132 (908) */
/* 778 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 782 */	NdrFcShort( 0x82 ),	/* Offset= 130 (912) */
/* 784 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 788 */	NdrFcShort( 0x78 ),	/* Offset= 120 (908) */
/* 790 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 794 */	NdrFcShort( 0x72 ),	/* Offset= 114 (908) */
/* 796 */	NdrFcLong( 0x0 ),	/* 0 */
/* 800 */	NdrFcShort( 0x0 ),	/* Offset= 0 (800) */
/* 802 */	NdrFcLong( 0x1 ),	/* 1 */
/* 806 */	NdrFcShort( 0x0 ),	/* Offset= 0 (806) */
/* 808 */	NdrFcShort( 0xffff ),	/* Offset= -1 (807) */
/* 810 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 812 */	NdrFcShort( 0x8 ),	/* 8 */
/* 814 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 816 */	
			0x13, 0x0,	/* FC_OP */
/* 818 */	NdrFcShort( 0xfdc6 ),	/* Offset= -570 (248) */
/* 820 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 822 */	NdrFcLong( 0x0 ),	/* 0 */
/* 826 */	NdrFcShort( 0x0 ),	/* 0 */
/* 828 */	NdrFcShort( 0x0 ),	/* 0 */
/* 830 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 832 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 834 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 836 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 838 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 840 */	NdrFcShort( 0x2 ),	/* Offset= 2 (842) */
/* 842 */	
			0x13, 0x0,	/* FC_OP */
/* 844 */	NdrFcShort( 0x1ce ),	/* Offset= 462 (1306) */
/* 846 */	
			0x13, 0x0,	/* FC_OP */
/* 848 */	NdrFcShort( 0x20 ),	/* Offset= 32 (880) */
/* 850 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 852 */	NdrFcLong( 0x2f ),	/* 47 */
/* 856 */	NdrFcShort( 0x0 ),	/* 0 */
/* 858 */	NdrFcShort( 0x0 ),	/* 0 */
/* 860 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 862 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 864 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 866 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 868 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 870 */	NdrFcShort( 0x1 ),	/* 1 */
/* 872 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 874 */	NdrFcShort( 0x4 ),	/* 4 */
/* 876 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 878 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 880 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 882 */	NdrFcShort( 0x10 ),	/* 16 */
/* 884 */	NdrFcShort( 0x0 ),	/* 0 */
/* 886 */	NdrFcShort( 0xa ),	/* Offset= 10 (896) */
/* 888 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 890 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 892 */	NdrFcShort( 0xffd6 ),	/* Offset= -42 (850) */
/* 894 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 896 */	
			0x13, 0x0,	/* FC_OP */
/* 898 */	NdrFcShort( 0xffe2 ),	/* Offset= -30 (868) */
/* 900 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 902 */	0x1,		/* FC_BYTE */
			0x5c,		/* FC_PAD */
/* 904 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 906 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 908 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 910 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 912 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 914 */	0xb,		/* FC_HYPER */
			0x5c,		/* FC_PAD */
/* 916 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 918 */	0xa,		/* FC_FLOAT */
			0x5c,		/* FC_PAD */
/* 920 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 922 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 924 */	
			0x13, 0x0,	/* FC_OP */
/* 926 */	NdrFcShort( 0xff8c ),	/* Offset= -116 (810) */
/* 928 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 930 */	NdrFcShort( 0xff8e ),	/* Offset= -114 (816) */
/* 932 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 934 */	NdrFcShort( 0xff8e ),	/* Offset= -114 (820) */
/* 936 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 938 */	NdrFcShort( 0xfe1e ),	/* Offset= -482 (456) */
/* 940 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 942 */	NdrFcShort( 0x2 ),	/* Offset= 2 (944) */
/* 944 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 946 */	NdrFcShort( 0x2 ),	/* Offset= 2 (948) */
/* 948 */	
			0x13, 0x0,	/* FC_OP */
/* 950 */	NdrFcShort( 0x164 ),	/* Offset= 356 (1306) */
/* 952 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 954 */	NdrFcShort( 0x2 ),	/* Offset= 2 (956) */
/* 956 */	
			0x13, 0x0,	/* FC_OP */
/* 958 */	NdrFcShort( 0x14 ),	/* Offset= 20 (978) */
/* 960 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 962 */	NdrFcShort( 0x10 ),	/* 16 */
/* 964 */	0x6,		/* FC_SHORT */
			0x1,		/* FC_BYTE */
/* 966 */	0x1,		/* FC_BYTE */
			0x8,		/* FC_LONG */
/* 968 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 970 */	
			0x13, 0x0,	/* FC_OP */
/* 972 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (960) */
/* 974 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 976 */	0x2,		/* FC_CHAR */
			0x5c,		/* FC_PAD */
/* 978 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x7,		/* 7 */
/* 980 */	NdrFcShort( 0x20 ),	/* 32 */
/* 982 */	NdrFcShort( 0x0 ),	/* 0 */
/* 984 */	NdrFcShort( 0x0 ),	/* Offset= 0 (984) */
/* 986 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 988 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 990 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 992 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 994 */	NdrFcShort( 0xfe1e ),	/* Offset= -482 (512) */
/* 996 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 998 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1000 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1002 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1004 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1006 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1008 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1010 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 1012 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1014 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1016 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1018 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1020 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1022 */	0x13, 0x0,	/* FC_OP */
/* 1024 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (978) */
/* 1026 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1028 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1030 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1032 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1034 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1036 */	NdrFcShort( 0x6 ),	/* Offset= 6 (1042) */
/* 1038 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1040 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1042 */	
			0x11, 0x0,	/* FC_RP */
/* 1044 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (998) */
/* 1046 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1048 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1050 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1052 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1054 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1056 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1058 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 1060 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1062 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1064 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1066 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1068 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1070 */	0x13, 0x0,	/* FC_OP */
/* 1072 */	NdrFcShort( 0xff40 ),	/* Offset= -192 (880) */
/* 1074 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1076 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1078 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1080 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1082 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1084 */	NdrFcShort( 0x6 ),	/* Offset= 6 (1090) */
/* 1086 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1088 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1090 */	
			0x11, 0x0,	/* FC_RP */
/* 1092 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (1046) */
/* 1094 */	
			0x1d,		/* FC_SMFARRAY */
			0x0,		/* 0 */
/* 1096 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1098 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1100 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1102 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1104 */	0x8,		/* FC_LONG */
			0x6,		/* FC_SHORT */
/* 1106 */	0x6,		/* FC_SHORT */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 1108 */	0x0,		/* 0 */
			NdrFcShort( 0xfff1 ),	/* Offset= -15 (1094) */
			0x5b,		/* FC_END */
/* 1112 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 1114 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1116 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1118 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1120 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1122 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 1126 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 1128 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1130 */	NdrFcShort( 0xfeca ),	/* Offset= -310 (820) */
/* 1132 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1134 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1136 */	NdrFcShort( 0x18 ),	/* 24 */
/* 1138 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1140 */	NdrFcShort( 0xa ),	/* Offset= 10 (1150) */
/* 1142 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1144 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1146 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (1100) */
/* 1148 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1150 */	
			0x11, 0x0,	/* FC_RP */
/* 1152 */	NdrFcShort( 0xffd8 ),	/* Offset= -40 (1112) */
/* 1154 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 1156 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1158 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1160 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1162 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1164 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1166 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1168 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1170 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1172 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1174 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1176 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1178 */	0x13, 0x0,	/* FC_OP */
/* 1180 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1154) */
/* 1182 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1184 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1186 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 1188 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1190 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1192 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1194 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1196 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 1198 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1200 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1202 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1204 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1206 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1208 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1210 */	0x13, 0x0,	/* FC_OP */
/* 1212 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1186) */
/* 1214 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1216 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1218 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1220 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1222 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1224 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1226 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1228 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1230 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1232 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1234 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1236 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1238 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1240 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1242 */	0x13, 0x0,	/* FC_OP */
/* 1244 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1218) */
/* 1246 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1248 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1250 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 1252 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1254 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1256 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1258 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1260 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 1262 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1264 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1266 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1268 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1270 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1272 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1274 */	0x13, 0x0,	/* FC_OP */
/* 1276 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1250) */
/* 1278 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1280 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1282 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1284 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1286 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1288 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1290 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1292 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1294 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 1296 */	NdrFcShort( 0xffd8 ),	/* -40 */
/* 1298 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1300 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1302 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1282) */
/* 1304 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1306 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1308 */	NdrFcShort( 0x28 ),	/* 40 */
/* 1310 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1290) */
/* 1312 */	NdrFcShort( 0x0 ),	/* Offset= 0 (1312) */
/* 1314 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1316 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1318 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1320 */	NdrFcShort( 0xfbf0 ),	/* Offset= -1040 (280) */
/* 1322 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1324 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1326 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1328 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1330 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1332 */	NdrFcShort( 0xfbdc ),	/* Offset= -1060 (272) */
/* 1334 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 1336 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 1338 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 1340 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 1342 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1344 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1346) */
/* 1346 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1348 */	NdrFcLong( 0x641c669 ),	/* 104973929 */
/* 1352 */	NdrFcShort( 0xb362 ),	/* -19614 */
/* 1354 */	NdrFcShort( 0x48c9 ),	/* 18633 */
/* 1356 */	0x8b,		/* 139 */
			0x73,		/* 115 */
/* 1358 */	0xd0,		/* 208 */
			0x2b,		/* 43 */
/* 1360 */	0x6e,		/* 110 */
			0x25,		/* 37 */
/* 1362 */	0x2a,		/* 42 */
			0x9d,		/* 157 */
/* 1364 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1366 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1368) */
/* 1368 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1370 */	NdrFcLong( 0xd3beda0d ),	/* -742467059 */
/* 1374 */	NdrFcShort( 0x1771 ),	/* 6001 */
/* 1376 */	NdrFcShort( 0x4493 ),	/* 17555 */
/* 1378 */	0xbb,		/* 187 */
			0x5c,		/* 92 */
/* 1380 */	0xe9,		/* 233 */
			0x33,		/* 51 */
/* 1382 */	0x84,		/* 132 */
			0x79,		/* 121 */
/* 1384 */	0x2b,		/* 43 */
			0x2a,		/* 42 */
/* 1386 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1388 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1390) */
/* 1390 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1392 */	NdrFcLong( 0x9d90d301 ),	/* -1651453183 */
/* 1396 */	NdrFcShort( 0xe998 ),	/* -5736 */
/* 1398 */	NdrFcShort( 0x4229 ),	/* 16937 */
/* 1400 */	0x98,		/* 152 */
			0xc0,		/* 192 */
/* 1402 */	0x27,		/* 39 */
			0xc5,		/* 197 */
/* 1404 */	0x96,		/* 150 */
			0x90,		/* 144 */
/* 1406 */	0x30,		/* 48 */
			0x8d,		/* 141 */

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


/* Object interface: IResultMerger, ver. 0.0,
   GUID={0x4D5B2A01,0x1CC2,0x4D56,{0xA8,0xD7,0x67,0xC7,0x30,0xA0,0x57,0xED}} */

#pragma code_seg(".orpc")
static const unsigned short IResultMerger_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0,
    36,
    78
    };

static const MIDL_STUBLESS_PROXY_INFO IResultMerger_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IResultMerger_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IResultMerger_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IResultMerger_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(10) _IResultMergerProxyVtbl = 
{
    &IResultMerger_ProxyInfo,
    &IID_IResultMerger,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IResultMerger::AddResult */ ,
    (void *) (INT_PTR) -1 /* IResultMerger::CanAddResult */ ,
    (void *) (INT_PTR) -1 /* IResultMerger::CreateResult */
};


static const PRPC_STUB_FUNCTION IResultMerger_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IResultMergerStubVtbl =
{
    &IID_IResultMerger,
    &IResultMerger_ServerInfo,
    10,
    &IResultMerger_table[-3],
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
    114
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
    (void *) (INT_PTR) -1 /* IResult::GetResultMerger */
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


/* Object interface: IActionManager, ver. 0.0,
   GUID={0x5EB44493,0x8FF9,0x486A,{0x8A,0xBD,0x09,0xB9,0xF2,0x32,0x62,0x8A}} */

#pragma code_seg(".orpc")
static const unsigned short IActionManager_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    150,
    186
    };

static const MIDL_STUBLESS_PROXY_INFO IActionManager_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IActionManager_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IActionManager_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IActionManager_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IActionManagerProxyVtbl = 
{
    &IActionManager_ProxyInfo,
    &IID_IActionManager,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IActionManager::GetLength */ ,
    (void *) (INT_PTR) -1 /* IActionManager::GetAction */
};


static const PRPC_STUB_FUNCTION IActionManager_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IActionManagerStubVtbl =
{
    &IID_IActionManager,
    &IActionManager_ServerInfo,
    9,
    &IActionManager_table[-3],
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
    0
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
CINTERFACE_PROXY_VTABLE(7) _IProgressBarInfoProxyVtbl = 
{
    0,
    &IID_IProgressBarInfo,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IProgressBarInfo_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IProgressBarInfoStubVtbl =
{
    &IID_IProgressBarInfo,
    &IProgressBarInfo_ServerInfo,
    7,
    &IProgressBarInfo_table[-3],
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
    228,
    264,
    300,
    342,
    378
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
CINTERFACE_PROXY_VTABLE(12) _IActionProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IAction::GetNextActionManager */ ,
    (void *) (INT_PTR) -1 /* IAction::SetActionParameters */ ,
    (void *) (INT_PTR) -1 /* IAction::Do */ ,
    (void *) (INT_PTR) -1 /* IAction::SetProgressBarInfo */ ,
    (void *) (INT_PTR) -1 /* IAction::IsChainLeaf */
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
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IActionStubVtbl =
{
    &IID_IAction,
    &IAction_ServerInfo,
    12,
    &IAction_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: INode, ver. 0.0,
   GUID={0xD3BEDA0D,0x1771,0x4493,{0xBB,0x5C,0xE9,0x33,0x84,0x79,0x2B,0x2A}} */

#pragma code_seg(".orpc")
static const unsigned short INode_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    414,
    450
    };

static const MIDL_STUBLESS_PROXY_INFO INode_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &INode_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO INode_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &INode_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _INodeProxyVtbl = 
{
    &INode_ProxyInfo,
    &IID_INode,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* INode::GetActionManager */ ,
    (void *) (INT_PTR) -1 /* INode::GetResult */
};


static const PRPC_STUB_FUNCTION INode_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _INodeStubVtbl =
{
    &IID_INode,
    &INode_ServerInfo,
    9,
    &INode_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IActionFactory, ver. 0.0,
   GUID={0x35F624D3,0xEB6C,0x4F79,{0xAB,0x1E,0xC0,0x17,0x95,0xA0,0x8C,0x5A}} */

#pragma code_seg(".orpc")
static const unsigned short IActionFactory_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    486,
    528,
    570,
    612
    };

static const MIDL_STUBLESS_PROXY_INFO IActionFactory_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IActionFactory_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IActionFactory_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IActionFactory_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _IActionFactoryProxyVtbl = 
{
    &IActionFactory_ProxyInfo,
    &IID_IActionFactory,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IActionFactory::CanCreateActionFromNode */ ,
    (void *) (INT_PTR) -1 /* IActionFactory::CreateActionFromNode */ ,
    (void *) (INT_PTR) -1 /* IActionFactory::CanCreateActionFromAction */ ,
    (void *) (INT_PTR) -1 /* IActionFactory::CreateActionFromAction */
};


static const PRPC_STUB_FUNCTION IActionFactory_table[] =
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

CInterfaceStubVtbl _IActionFactoryStubVtbl =
{
    &IID_IActionFactory,
    &IActionFactory_ServerInfo,
    11,
    &IActionFactory_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IActionAllocator, ver. 0.0,
   GUID={0x9D90D301,0xE998,0x4229,{0x98,0xC0,0x27,0xC5,0x96,0x90,0x30,0x8D}} */

#pragma code_seg(".orpc")
static const unsigned short IActionAllocator_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    654,
    696
    };

static const MIDL_STUBLESS_PROXY_INFO IActionAllocator_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IActionAllocator_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IActionAllocator_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IActionAllocator_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _IActionAllocatorProxyVtbl = 
{
    &IActionAllocator_ProxyInfo,
    &IID_IActionAllocator,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IActionAllocator::AllocateActionManagerForNode */ ,
    (void *) (INT_PTR) -1 /* IActionAllocator::AllocateActionManagerForAction */
};


static const PRPC_STUB_FUNCTION IActionAllocator_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IActionAllocatorStubVtbl =
{
    &IID_IActionAllocator,
    &IActionAllocator_ServerInfo,
    9,
    &IActionAllocator_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IWritableActionAllocator, ver. 0.0,
   GUID={0xBC2B7099,0xB5A6,0x4D0B,{0xBD,0xE0,0xDA,0x02,0x7E,0x87,0xFF,0x93}} */

#pragma code_seg(".orpc")
static const unsigned short IWritableActionAllocator_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    738
    };

static const MIDL_STUBLESS_PROXY_INFO IWritableActionAllocator_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IWritableActionAllocator_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IWritableActionAllocator_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IWritableActionAllocator_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IWritableActionAllocatorProxyVtbl = 
{
    &IWritableActionAllocator_ProxyInfo,
    &IID_IWritableActionAllocator,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IWritableActionAllocator::RegisterActionFactory */
};


static const PRPC_STUB_FUNCTION IWritableActionAllocator_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IWritableActionAllocatorStubVtbl =
{
    &IID_IWritableActionAllocator,
    &IWritableActionAllocator_ServerInfo,
    8,
    &IWritableActionAllocator_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IWritableActionManager, ver. 0.0,
   GUID={0xE20C06D8,0x1C51,0x455C,{0xB3,0x06,0x33,0xD0,0x63,0x5F,0x1E,0x52}} */

#pragma code_seg(".orpc")
static const unsigned short IWritableActionManager_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    774
    };

static const MIDL_STUBLESS_PROXY_INFO IWritableActionManager_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IWritableActionManager_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IWritableActionManager_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IWritableActionManager_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IWritableActionManagerProxyVtbl = 
{
    &IWritableActionManager_ProxyInfo,
    &IID_IWritableActionManager,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IWritableActionManager::AddAction */
};


static const PRPC_STUB_FUNCTION IWritableActionManager_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IWritableActionManagerStubVtbl =
{
    &IID_IWritableActionManager,
    &IWritableActionManager_ServerInfo,
    8,
    &IWritableActionManager_table[-3],
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
    810,
    846,
    876,
    906,
    948,
    984
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


/* Object interface: IGraphInfo, ver. 0.0,
   GUID={0x0641C669,0xB362,0x48C9,{0x8B,0x73,0xD0,0x2B,0x6E,0x25,0x2A,0x9D}} */

#pragma code_seg(".orpc")
static const unsigned short IGraphInfo_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1020,
    1056,
    1092,
    1128,
    1170,
    1212,
    1254
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


/* Object interface: IWritableGraphInfo, ver. 0.0,
   GUID={0x5F89F9F3,0xAB8D,0x4129,{0xA7,0x52,0x8A,0x42,0x58,0xA8,0xEC,0xE9}} */


/* Object interface: IGraphResult, ver. 0.0,
   GUID={0x6E606370,0x04E2,0x4BCB,{0x85,0x2C,0x31,0x3A,0x7D,0x4B,0xAD,0x15}} */

#pragma code_seg(".orpc")
static const unsigned short IGraphResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    114,
    (unsigned short) -1,
    1092,
    1296,
    1332,
    1374
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
    (void *) (INT_PTR) -1 /* IResult::GetResultMerger */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraphResult::GetGraph */ ,
    (void *) (INT_PTR) -1 /* IGraphResult::GetCount */ ,
    (void *) (INT_PTR) -1 /* IGraphResult::GetGraphInfo */ ,
    (void *) (INT_PTR) -1 /* IGraphResult::GetGraphInfoAt */ ,
    (void *) (INT_PTR) -1 /* IGraphResult::IsStrongComponent */
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
    (unsigned short) -1
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
CINTERFACE_PROXY_VTABLE(8) _IWritableGraphResultProxyVtbl = 
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
    0 /* (void *) (INT_PTR) -1 /* IWritableGraphResult::AddGraph */
};


static const PRPC_STUB_FUNCTION IWritableGraphResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IWritableGraphResultStubVtbl =
{
    &IID_IWritableGraphResult,
    &IWritableGraphResult_ServerInfo,
    8,
    &IWritableGraphResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IGroupNode, ver. 0.0,
   GUID={0x28EBA211,0xE2B0,0x4717,{0x87,0xAA,0x63,0xA0,0xA5,0xC7,0x6C,0xDC}} */

#pragma code_seg(".orpc")
static const unsigned short IGroupNode_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1020,
    1410,
    1452,
    1488,
    1524
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
CINTERFACE_PROXY_VTABLE(12) _IGroupNodeProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IGroupNode::GetLength */ ,
    (void *) (INT_PTR) -1 /* IGroupNode::GetNode */ ,
    (void *) (INT_PTR) -1 /* IGroupNode::CanAddNode */ ,
    (void *) (INT_PTR) -1 /* IGroupNode::AddNode */ ,
    (void *) (INT_PTR) -1 /* IGroupNode::CreateNode */
};


static const PRPC_STUB_FUNCTION IGroupNode_table[] =
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

CInterfaceStubVtbl _IGroupNodeStubVtbl =
{
    &IID_IGroupNode,
    &IGroupNode_ServerInfo,
    12,
    &IGroupNode_table[-3],
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
    1560
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
CINTERFACE_PROXY_VTABLE(8) _IKernellProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IKernell::GetActionAllocator */
};


static const PRPC_STUB_FUNCTION IKernell_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IKernellStubVtbl =
{
    &IID_IKernell,
    &IKernell_ServerInfo,
    8,
    &IKernell_table[-3],
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
    ( CInterfaceProxyVtbl *) &_IResultMergerProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionAllocatorProxyVtbl,
    ( CInterfaceProxyVtbl *) &_INodeProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGroupNodeProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernellProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionManagerProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableActionAllocatorProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComponentRegistrarProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionFactoryProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableActionManagerProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionBaseProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProgressBarInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultBaseProxyVtbl,
    0
};

const CInterfaceStubVtbl * __MorseKernel2_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_IResultMergerStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionAllocatorStubVtbl,
    ( CInterfaceStubVtbl *) &_INodeStubVtbl,
    ( CInterfaceStubVtbl *) &_IGroupNodeStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernellStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionManagerStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableActionAllocatorStubVtbl,
    ( CInterfaceStubVtbl *) &_IComponentRegistrarStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionFactoryStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableActionManagerStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionBaseStubVtbl,
    ( CInterfaceStubVtbl *) &_IProgressBarInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultBaseStubVtbl,
    0
};

PCInterfaceName const __MorseKernel2_InterfaceNamesList[] = 
{
    "IResultMerger",
    "IActionAllocator",
    "INode",
    "IGroupNode",
    "IKernell",
    "IGraphInfo",
    "IGraphResult",
    "IParameters",
    "IActionManager",
    "IWritableActionAllocator",
    "IComponentRegistrar",
    "IResult",
    "IActionFactory",
    "IWritableActionManager",
    "IAction",
    "IActionBase",
    "IProgressBarInfo",
    "IWritableGraphResult",
    "IResultBase",
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
    0
};


#define __MorseKernel2_CHECK_IID(n)	IID_GENERIC_CHECK_IID( __MorseKernel2, pIID, n)

int __stdcall __MorseKernel2_IID_Lookup( const IID * pIID, int * pIndex )
{
    IID_BS_LOOKUP_SETUP

    IID_BS_LOOKUP_INITIAL_TEST( __MorseKernel2, 19, 16 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 8 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 4 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 2 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( __MorseKernel2, 19, *pIndex )
    
}

const ExtendedProxyFileInfo _MorseKernel2_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & __MorseKernel2_ProxyVtblList,
    (PCInterfaceStubVtblList *) & __MorseKernel2_StubVtblList,
    (const PCInterfaceName * ) & __MorseKernel2_InterfaceNamesList,
    (const IID ** ) & __MorseKernel2_BaseIIDList,
    & __MorseKernel2_IID_Lookup, 
    19,
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

