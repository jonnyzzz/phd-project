

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Tue Mar 08 22:05:43 2005
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

#define TYPE_FORMAT_STRING_SIZE   1285                              
#define PROC_FORMAT_STRING_SIZE   1099                              
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


extern const MIDL_SERVER_INFO IWritableGraphInfo_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableGraphInfo_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraphResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphResult_ProxyInfo;


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

	/* Procedure GetLength */

			0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/*  2 */	NdrFcLong( 0x0 ),	/* 0 */
/*  6 */	NdrFcShort( 0x7 ),	/* 7 */
/*  8 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 10 */	NdrFcShort( 0x1c ),	/* 28 */
/* 12 */	NdrFcShort( 0x8 ),	/* 8 */
/* 14 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 16 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 18 */	NdrFcShort( 0x0 ),	/* 0 */
/* 20 */	NdrFcShort( 0x0 ),	/* 0 */
/* 22 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter count */

/* 24 */	NdrFcShort( 0x148 ),	/* Flags:  in, base type, simple ref, */
/* 26 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 28 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 30 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 32 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 34 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetAction */

/* 36 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 38 */	NdrFcLong( 0x0 ),	/* 0 */
/* 42 */	NdrFcShort( 0x8 ),	/* 8 */
/* 44 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 46 */	NdrFcShort( 0x8 ),	/* 8 */
/* 48 */	NdrFcShort( 0x8 ),	/* 8 */
/* 50 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 52 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 54 */	NdrFcShort( 0x0 ),	/* 0 */
/* 56 */	NdrFcShort( 0x0 ),	/* 0 */
/* 58 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 60 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 62 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 64 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter action */

/* 66 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 68 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 70 */	NdrFcShort( 0x6 ),	/* Type Offset=6 */

	/* Return value */

/* 72 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 74 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 76 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetNextActionManager */

/* 78 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 80 */	NdrFcLong( 0x0 ),	/* 0 */
/* 84 */	NdrFcShort( 0x7 ),	/* 7 */
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

	/* Parameter manager */

/* 102 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 104 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 106 */	NdrFcShort( 0x1c ),	/* Type Offset=28 */

	/* Return value */

/* 108 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 110 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 112 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetActionParameters */

/* 114 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 116 */	NdrFcLong( 0x0 ),	/* 0 */
/* 120 */	NdrFcShort( 0x8 ),	/* 8 */
/* 122 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 124 */	NdrFcShort( 0x0 ),	/* 0 */
/* 126 */	NdrFcShort( 0x8 ),	/* 8 */
/* 128 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 130 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 132 */	NdrFcShort( 0x0 ),	/* 0 */
/* 134 */	NdrFcShort( 0x0 ),	/* 0 */
/* 136 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter parameters */

/* 138 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 140 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 142 */	NdrFcShort( 0x32 ),	/* Type Offset=50 */

	/* Return value */

/* 144 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 146 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 148 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Do */

/* 150 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 152 */	NdrFcLong( 0x0 ),	/* 0 */
/* 156 */	NdrFcShort( 0x9 ),	/* 9 */
/* 158 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 160 */	NdrFcShort( 0x0 ),	/* 0 */
/* 162 */	NdrFcShort( 0x8 ),	/* 8 */
/* 164 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 166 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 168 */	NdrFcShort( 0x0 ),	/* 0 */
/* 170 */	NdrFcShort( 0x0 ),	/* 0 */
/* 172 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter input */

/* 174 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 176 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 178 */	NdrFcShort( 0x44 ),	/* Type Offset=68 */

	/* Parameter output */

/* 180 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 182 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 184 */	NdrFcShort( 0x56 ),	/* Type Offset=86 */

	/* Return value */

/* 186 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 188 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 190 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetProgressBarInfo */

/* 192 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 194 */	NdrFcLong( 0x0 ),	/* 0 */
/* 198 */	NdrFcShort( 0xa ),	/* 10 */
/* 200 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 202 */	NdrFcShort( 0x0 ),	/* 0 */
/* 204 */	NdrFcShort( 0x8 ),	/* 8 */
/* 206 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 208 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 210 */	NdrFcShort( 0x0 ),	/* 0 */
/* 212 */	NdrFcShort( 0x0 ),	/* 0 */
/* 214 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pinfo */

/* 216 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 218 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 220 */	NdrFcShort( 0x5a ),	/* Type Offset=90 */

	/* Return value */

/* 222 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 224 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 226 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetActionManager */

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
/* 256 */	NdrFcShort( 0x6c ),	/* Type Offset=108 */

	/* Return value */

/* 258 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 260 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 262 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetResult */

/* 264 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 266 */	NdrFcLong( 0x0 ),	/* 0 */
/* 270 */	NdrFcShort( 0x8 ),	/* 8 */
/* 272 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 274 */	NdrFcShort( 0x0 ),	/* 0 */
/* 276 */	NdrFcShort( 0x8 ),	/* 8 */
/* 278 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 280 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 282 */	NdrFcShort( 0x0 ),	/* 0 */
/* 284 */	NdrFcShort( 0x0 ),	/* 0 */
/* 286 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 288 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 290 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 292 */	NdrFcShort( 0x56 ),	/* Type Offset=86 */

	/* Return value */

/* 294 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 296 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 298 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CanCreateAction */

/* 300 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 302 */	NdrFcLong( 0x0 ),	/* 0 */
/* 306 */	NdrFcShort( 0x7 ),	/* 7 */
/* 308 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 310 */	NdrFcShort( 0x0 ),	/* 0 */
/* 312 */	NdrFcShort( 0x36 ),	/* 54 */
/* 314 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 316 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 318 */	NdrFcShort( 0x0 ),	/* 0 */
/* 320 */	NdrFcShort( 0x0 ),	/* 0 */
/* 322 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 324 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 326 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 328 */	NdrFcShort( 0x82 ),	/* Type Offset=130 */

	/* Parameter result */

/* 330 */	NdrFcShort( 0x2012 ),	/* Flags:  must free, out, srv alloc size=8 */
/* 332 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 334 */	NdrFcShort( 0x94 ),	/* Type Offset=148 */

	/* Return value */

/* 336 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 338 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 340 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateAction */

/* 342 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 344 */	NdrFcLong( 0x0 ),	/* 0 */
/* 348 */	NdrFcShort( 0x8 ),	/* 8 */
/* 350 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 352 */	NdrFcShort( 0x0 ),	/* 0 */
/* 354 */	NdrFcShort( 0x8 ),	/* 8 */
/* 356 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 358 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 360 */	NdrFcShort( 0x0 ),	/* 0 */
/* 362 */	NdrFcShort( 0x0 ),	/* 0 */
/* 364 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 366 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 368 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 370 */	NdrFcShort( 0x82 ),	/* Type Offset=130 */

	/* Parameter action */

/* 372 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 374 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 376 */	NdrFcShort( 0x6 ),	/* Type Offset=6 */

	/* Return value */

/* 378 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 380 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 382 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AllocateActionManager */

/* 384 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 386 */	NdrFcLong( 0x0 ),	/* 0 */
/* 390 */	NdrFcShort( 0x7 ),	/* 7 */
/* 392 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 394 */	NdrFcShort( 0x0 ),	/* 0 */
/* 396 */	NdrFcShort( 0x8 ),	/* 8 */
/* 398 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 400 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 402 */	NdrFcShort( 0x0 ),	/* 0 */
/* 404 */	NdrFcShort( 0x0 ),	/* 0 */
/* 406 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 408 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 410 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 412 */	NdrFcShort( 0x82 ),	/* Type Offset=130 */

	/* Parameter manager */

/* 414 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 416 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 418 */	NdrFcShort( 0x6c ),	/* Type Offset=108 */

	/* Return value */

/* 420 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 422 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 424 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterActionFactory */

/* 426 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 428 */	NdrFcLong( 0x0 ),	/* 0 */
/* 432 */	NdrFcShort( 0x7 ),	/* 7 */
/* 434 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 436 */	NdrFcShort( 0x0 ),	/* 0 */
/* 438 */	NdrFcShort( 0x8 ),	/* 8 */
/* 440 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 442 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 444 */	NdrFcShort( 0x0 ),	/* 0 */
/* 446 */	NdrFcShort( 0x0 ),	/* 0 */
/* 448 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter action */

/* 450 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 452 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 454 */	NdrFcShort( 0x9c ),	/* Type Offset=156 */

	/* Return value */

/* 456 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 458 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 460 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AddAction */

/* 462 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 464 */	NdrFcLong( 0x0 ),	/* 0 */
/* 468 */	NdrFcShort( 0x7 ),	/* 7 */
/* 470 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 472 */	NdrFcShort( 0x0 ),	/* 0 */
/* 474 */	NdrFcShort( 0x8 ),	/* 8 */
/* 476 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 478 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 480 */	NdrFcShort( 0x0 ),	/* 0 */
/* 482 */	NdrFcShort( 0x0 ),	/* 0 */
/* 484 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter action */

/* 486 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 488 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 490 */	NdrFcShort( 0xae ),	/* Type Offset=174 */

	/* Return value */

/* 492 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 494 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 496 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Attach */

/* 498 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 500 */	NdrFcLong( 0x0 ),	/* 0 */
/* 504 */	NdrFcShort( 0x7 ),	/* 7 */
/* 506 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 508 */	NdrFcShort( 0x0 ),	/* 0 */
/* 510 */	NdrFcShort( 0x8 ),	/* 8 */
/* 512 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 514 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 516 */	NdrFcShort( 0x0 ),	/* 0 */
/* 518 */	NdrFcShort( 0x1 ),	/* 1 */
/* 520 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrPath */

/* 522 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 524 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 526 */	NdrFcShort( 0xda ),	/* Type Offset=218 */

	/* Return value */

/* 528 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 530 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 532 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterAll */

/* 534 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 536 */	NdrFcLong( 0x0 ),	/* 0 */
/* 540 */	NdrFcShort( 0x8 ),	/* 8 */
/* 542 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 544 */	NdrFcShort( 0x0 ),	/* 0 */
/* 546 */	NdrFcShort( 0x8 ),	/* 8 */
/* 548 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 550 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 552 */	NdrFcShort( 0x0 ),	/* 0 */
/* 554 */	NdrFcShort( 0x0 ),	/* 0 */
/* 556 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 558 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 560 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 562 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterAll */

/* 564 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 566 */	NdrFcLong( 0x0 ),	/* 0 */
/* 570 */	NdrFcShort( 0x9 ),	/* 9 */
/* 572 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 574 */	NdrFcShort( 0x0 ),	/* 0 */
/* 576 */	NdrFcShort( 0x8 ),	/* 8 */
/* 578 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 580 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 582 */	NdrFcShort( 0x0 ),	/* 0 */
/* 584 */	NdrFcShort( 0x0 ),	/* 0 */
/* 586 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 588 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 590 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 592 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetComponents */

/* 594 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 596 */	NdrFcLong( 0x0 ),	/* 0 */
/* 600 */	NdrFcShort( 0xa ),	/* 10 */
/* 602 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 604 */	NdrFcShort( 0x0 ),	/* 0 */
/* 606 */	NdrFcShort( 0x8 ),	/* 8 */
/* 608 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 610 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 612 */	NdrFcShort( 0x24 ),	/* 36 */
/* 614 */	NdrFcShort( 0x0 ),	/* 0 */
/* 616 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pbstrCLSIDs */

/* 618 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 620 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 622 */	NdrFcShort( 0x4d8 ),	/* Type Offset=1240 */

	/* Parameter pbstrDescriptions */

/* 624 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 626 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 628 */	NdrFcShort( 0x4d8 ),	/* Type Offset=1240 */

	/* Return value */

/* 630 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 632 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 634 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterComponent */

/* 636 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 638 */	NdrFcLong( 0x0 ),	/* 0 */
/* 642 */	NdrFcShort( 0xb ),	/* 11 */
/* 644 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 646 */	NdrFcShort( 0x0 ),	/* 0 */
/* 648 */	NdrFcShort( 0x8 ),	/* 8 */
/* 650 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 652 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 654 */	NdrFcShort( 0x0 ),	/* 0 */
/* 656 */	NdrFcShort( 0x1 ),	/* 1 */
/* 658 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 660 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 662 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 664 */	NdrFcShort( 0xda ),	/* Type Offset=218 */

	/* Return value */

/* 666 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 668 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 670 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterComponent */

/* 672 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 674 */	NdrFcLong( 0x0 ),	/* 0 */
/* 678 */	NdrFcShort( 0xc ),	/* 12 */
/* 680 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 682 */	NdrFcShort( 0x0 ),	/* 0 */
/* 684 */	NdrFcShort( 0x8 ),	/* 8 */
/* 686 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 688 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 690 */	NdrFcShort( 0x0 ),	/* 0 */
/* 692 */	NdrFcShort( 0x1 ),	/* 1 */
/* 694 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 696 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 698 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 700 */	NdrFcShort( 0xda ),	/* Type Offset=218 */

	/* Return value */

/* 702 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 704 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 706 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetNodes */

/* 708 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 710 */	NdrFcLong( 0x0 ),	/* 0 */
/* 714 */	NdrFcShort( 0x7 ),	/* 7 */
/* 716 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 718 */	NdrFcShort( 0x0 ),	/* 0 */
/* 720 */	NdrFcShort( 0x24 ),	/* 36 */
/* 722 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 724 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 726 */	NdrFcShort( 0x0 ),	/* 0 */
/* 728 */	NdrFcShort( 0x0 ),	/* 0 */
/* 730 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 732 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 734 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 736 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 738 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 740 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 742 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetEdges */

/* 744 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 746 */	NdrFcLong( 0x0 ),	/* 0 */
/* 750 */	NdrFcShort( 0x8 ),	/* 8 */
/* 752 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 754 */	NdrFcShort( 0x0 ),	/* 0 */
/* 756 */	NdrFcShort( 0x24 ),	/* 36 */
/* 758 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 760 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 762 */	NdrFcShort( 0x0 ),	/* 0 */
/* 764 */	NdrFcShort( 0x0 ),	/* 0 */
/* 766 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 768 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 770 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 772 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 774 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 776 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 778 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetDimension */

/* 780 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 782 */	NdrFcLong( 0x0 ),	/* 0 */
/* 786 */	NdrFcShort( 0x9 ),	/* 9 */
/* 788 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 790 */	NdrFcShort( 0x0 ),	/* 0 */
/* 792 */	NdrFcShort( 0x24 ),	/* 36 */
/* 794 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 796 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 798 */	NdrFcShort( 0x0 ),	/* 0 */
/* 800 */	NdrFcShort( 0x0 ),	/* 0 */
/* 802 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 804 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 806 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 808 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 810 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 812 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 814 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMinimum */

/* 816 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 818 */	NdrFcLong( 0x0 ),	/* 0 */
/* 822 */	NdrFcShort( 0xa ),	/* 10 */
/* 824 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 826 */	NdrFcShort( 0x8 ),	/* 8 */
/* 828 */	NdrFcShort( 0x2c ),	/* 44 */
/* 830 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 832 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 834 */	NdrFcShort( 0x0 ),	/* 0 */
/* 836 */	NdrFcShort( 0x0 ),	/* 0 */
/* 838 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 840 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 842 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 844 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 846 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 848 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 850 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 852 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 854 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 856 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMaximum */

/* 858 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 860 */	NdrFcLong( 0x0 ),	/* 0 */
/* 864 */	NdrFcShort( 0xb ),	/* 11 */
/* 866 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 868 */	NdrFcShort( 0x8 ),	/* 8 */
/* 870 */	NdrFcShort( 0x2c ),	/* 44 */
/* 872 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 874 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 876 */	NdrFcShort( 0x0 ),	/* 0 */
/* 878 */	NdrFcShort( 0x0 ),	/* 0 */
/* 880 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 882 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 884 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 886 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 888 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 890 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 892 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 894 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 896 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 898 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGridNumber */

/* 900 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 902 */	NdrFcLong( 0x0 ),	/* 0 */
/* 906 */	NdrFcShort( 0xc ),	/* 12 */
/* 908 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 910 */	NdrFcShort( 0x8 ),	/* 8 */
/* 912 */	NdrFcShort( 0x24 ),	/* 36 */
/* 914 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 916 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 918 */	NdrFcShort( 0x0 ),	/* 0 */
/* 920 */	NdrFcShort( 0x0 ),	/* 0 */
/* 922 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 924 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 926 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 928 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 930 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 932 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 934 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 936 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 938 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 940 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGridSize */

/* 942 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 944 */	NdrFcLong( 0x0 ),	/* 0 */
/* 948 */	NdrFcShort( 0xd ),	/* 13 */
/* 950 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 952 */	NdrFcShort( 0x8 ),	/* 8 */
/* 954 */	NdrFcShort( 0x2c ),	/* 44 */
/* 956 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 958 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 960 */	NdrFcShort( 0x0 ),	/* 0 */
/* 962 */	NdrFcShort( 0x0 ),	/* 0 */
/* 964 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 966 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 968 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 970 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 972 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 974 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 976 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 978 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 980 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 982 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGraphInfo */

/* 984 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 986 */	NdrFcLong( 0x0 ),	/* 0 */
/* 990 */	NdrFcShort( 0x9 ),	/* 9 */
/* 992 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 994 */	NdrFcShort( 0x0 ),	/* 0 */
/* 996 */	NdrFcShort( 0x8 ),	/* 8 */
/* 998 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1000 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1002 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1004 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1006 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter info */

/* 1008 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1010 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1012 */	NdrFcShort( 0x4ea ),	/* Type Offset=1258 */

	/* Return value */

/* 1014 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1016 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1018 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGraphInfoAt */

/* 1020 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1022 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1026 */	NdrFcShort( 0xa ),	/* 10 */
/* 1028 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1030 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1032 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1034 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 1036 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1038 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1040 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1042 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1044 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1046 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1048 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter info */

/* 1050 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1052 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1054 */	NdrFcShort( 0x4ea ),	/* Type Offset=1258 */

	/* Return value */

/* 1056 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1058 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1060 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure IsStrongComponent */

/* 1062 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1064 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1068 */	NdrFcShort( 0xb ),	/* 11 */
/* 1070 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1072 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1074 */	NdrFcShort( 0x22 ),	/* 34 */
/* 1076 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1078 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1080 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1082 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1084 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 1086 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1088 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1090 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 1092 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1094 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1096 */	0x8,		/* FC_LONG */
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
			0x11, 0x8,	/* FC_RP [simple_pointer] */
/*  4 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/*  6 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/*  8 */	NdrFcShort( 0x2 ),	/* Offset= 2 (10) */
/* 10 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 12 */	NdrFcLong( 0x285691e1 ),	/* 676762081 */
/* 16 */	NdrFcShort( 0xbfc9 ),	/* -16439 */
/* 18 */	NdrFcShort( 0x4e8b ),	/* 20107 */
/* 20 */	0xbe,		/* 190 */
			0x17,		/* 23 */
/* 22 */	0x5b,		/* 91 */
			0x1c,		/* 28 */
/* 24 */	0xc2,		/* 194 */
			0x30,		/* 48 */
/* 26 */	0x2e,		/* 46 */
			0xd9,		/* 217 */
/* 28 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 30 */	NdrFcShort( 0x2 ),	/* Offset= 2 (32) */
/* 32 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 34 */	NdrFcLong( 0x5eb44493 ),	/* 1588872339 */
/* 38 */	NdrFcShort( 0x8ff9 ),	/* -28679 */
/* 40 */	NdrFcShort( 0x486a ),	/* 18538 */
/* 42 */	0x8a,		/* 138 */
			0xbd,		/* 189 */
/* 44 */	0x9,		/* 9 */
			0xb9,		/* 185 */
/* 46 */	0xf2,		/* 242 */
			0x32,		/* 50 */
/* 48 */	0x62,		/* 98 */
			0x8a,		/* 138 */
/* 50 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 52 */	NdrFcLong( 0x16c62c7b ),	/* 382086267 */
/* 56 */	NdrFcShort( 0x6775 ),	/* 26485 */
/* 58 */	NdrFcShort( 0x4d2b ),	/* 19755 */
/* 60 */	0x9b,		/* 155 */
			0xd2,		/* 210 */
/* 62 */	0x43,		/* 67 */
			0x62,		/* 98 */
/* 64 */	0x4e,		/* 78 */
			0x1,		/* 1 */
/* 66 */	0x73,		/* 115 */
			0x8b,		/* 139 */
/* 68 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 70 */	NdrFcLong( 0x9b7d45a5 ),	/* -1686288987 */
/* 74 */	NdrFcShort( 0x77fd ),	/* 30717 */
/* 76 */	NdrFcShort( 0x4e97 ),	/* 20119 */
/* 78 */	0x8c,		/* 140 */
			0x4a,		/* 74 */
/* 80 */	0x76,		/* 118 */
			0xd3,		/* 211 */
/* 82 */	0x61,		/* 97 */
			0xc,		/* 12 */
/* 84 */	0xc8,		/* 200 */
			0x75,		/* 117 */
/* 86 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 88 */	NdrFcShort( 0xffec ),	/* Offset= -20 (68) */
/* 90 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 92 */	NdrFcLong( 0x54e003e2 ),	/* 1423967202 */
/* 96 */	NdrFcShort( 0xeaa0 ),	/* -5472 */
/* 98 */	NdrFcShort( 0x4321 ),	/* 17185 */
/* 100 */	0x9a,		/* 154 */
			0x14,		/* 20 */
/* 102 */	0x31,		/* 49 */
			0xcf,		/* 207 */
/* 104 */	0x8e,		/* 142 */
			0x5b,		/* 91 */
/* 106 */	0xcb,		/* 203 */
			0x84,		/* 132 */
/* 108 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 110 */	NdrFcShort( 0x2 ),	/* Offset= 2 (112) */
/* 112 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 114 */	NdrFcLong( 0x5eb44493 ),	/* 1588872339 */
/* 118 */	NdrFcShort( 0x8ff9 ),	/* -28679 */
/* 120 */	NdrFcShort( 0x486a ),	/* 18538 */
/* 122 */	0x8a,		/* 138 */
			0xbd,		/* 189 */
/* 124 */	0x9,		/* 9 */
			0xb9,		/* 185 */
/* 126 */	0xf2,		/* 242 */
			0x32,		/* 50 */
/* 128 */	0x62,		/* 98 */
			0x8a,		/* 138 */
/* 130 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 132 */	NdrFcLong( 0xd3beda0d ),	/* -742467059 */
/* 136 */	NdrFcShort( 0x1771 ),	/* 6001 */
/* 138 */	NdrFcShort( 0x4493 ),	/* 17555 */
/* 140 */	0xbb,		/* 187 */
			0x5c,		/* 92 */
/* 142 */	0xe9,		/* 233 */
			0x33,		/* 51 */
/* 144 */	0x84,		/* 132 */
			0x79,		/* 121 */
/* 146 */	0x2b,		/* 43 */
			0x2a,		/* 42 */
/* 148 */	
			0x11, 0x14,	/* FC_RP [alloced_on_stack] [pointer_deref] */
/* 150 */	NdrFcShort( 0x2 ),	/* Offset= 2 (152) */
/* 152 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 154 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 156 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 158 */	NdrFcLong( 0x35f624d3 ),	/* 905323731 */
/* 162 */	NdrFcShort( 0xeb6c ),	/* -5268 */
/* 164 */	NdrFcShort( 0x4f79 ),	/* 20345 */
/* 166 */	0xab,		/* 171 */
			0x1e,		/* 30 */
/* 168 */	0xc0,		/* 192 */
			0x17,		/* 23 */
/* 170 */	0x95,		/* 149 */
			0xa0,		/* 160 */
/* 172 */	0x8c,		/* 140 */
			0x5a,		/* 90 */
/* 174 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 176 */	NdrFcLong( 0x285691e1 ),	/* 676762081 */
/* 180 */	NdrFcShort( 0xbfc9 ),	/* -16439 */
/* 182 */	NdrFcShort( 0x4e8b ),	/* 20107 */
/* 184 */	0xbe,		/* 190 */
			0x17,		/* 23 */
/* 186 */	0x5b,		/* 91 */
			0x1c,		/* 28 */
/* 188 */	0xc2,		/* 194 */
			0x30,		/* 48 */
/* 190 */	0x2e,		/* 46 */
			0xd9,		/* 217 */
/* 192 */	
			0x12, 0x0,	/* FC_UP */
/* 194 */	NdrFcShort( 0xe ),	/* Offset= 14 (208) */
/* 196 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 198 */	NdrFcShort( 0x2 ),	/* 2 */
/* 200 */	0x9,		/* Corr desc: FC_ULONG */
			0x0,		/*  */
/* 202 */	NdrFcShort( 0xfffc ),	/* -4 */
/* 204 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 206 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 208 */	
			0x17,		/* FC_CSTRUCT */
			0x3,		/* 3 */
/* 210 */	NdrFcShort( 0x8 ),	/* 8 */
/* 212 */	NdrFcShort( 0xfff0 ),	/* Offset= -16 (196) */
/* 214 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 216 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 218 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 220 */	NdrFcShort( 0x0 ),	/* 0 */
/* 222 */	NdrFcShort( 0x4 ),	/* 4 */
/* 224 */	NdrFcShort( 0x0 ),	/* 0 */
/* 226 */	NdrFcShort( 0xffde ),	/* Offset= -34 (192) */
/* 228 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 230 */	NdrFcShort( 0x3f2 ),	/* Offset= 1010 (1240) */
/* 232 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 234 */	NdrFcShort( 0x2 ),	/* Offset= 2 (236) */
/* 236 */	
			0x13, 0x0,	/* FC_OP */
/* 238 */	NdrFcShort( 0x3d8 ),	/* Offset= 984 (1222) */
/* 240 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x49,		/* 73 */
/* 242 */	NdrFcShort( 0x18 ),	/* 24 */
/* 244 */	NdrFcShort( 0xa ),	/* 10 */
/* 246 */	NdrFcLong( 0x8 ),	/* 8 */
/* 250 */	NdrFcShort( 0x5a ),	/* Offset= 90 (340) */
/* 252 */	NdrFcLong( 0xd ),	/* 13 */
/* 256 */	NdrFcShort( 0x90 ),	/* Offset= 144 (400) */
/* 258 */	NdrFcLong( 0x9 ),	/* 9 */
/* 262 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (456) */
/* 264 */	NdrFcLong( 0xc ),	/* 12 */
/* 268 */	NdrFcShort( 0x2bc ),	/* Offset= 700 (968) */
/* 270 */	NdrFcLong( 0x24 ),	/* 36 */
/* 274 */	NdrFcShort( 0x2e6 ),	/* Offset= 742 (1016) */
/* 276 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 280 */	NdrFcShort( 0x302 ),	/* Offset= 770 (1050) */
/* 282 */	NdrFcLong( 0x10 ),	/* 16 */
/* 286 */	NdrFcShort( 0x31c ),	/* Offset= 796 (1082) */
/* 288 */	NdrFcLong( 0x2 ),	/* 2 */
/* 292 */	NdrFcShort( 0x336 ),	/* Offset= 822 (1114) */
/* 294 */	NdrFcLong( 0x3 ),	/* 3 */
/* 298 */	NdrFcShort( 0x350 ),	/* Offset= 848 (1146) */
/* 300 */	NdrFcLong( 0x14 ),	/* 20 */
/* 304 */	NdrFcShort( 0x36a ),	/* Offset= 874 (1178) */
/* 306 */	NdrFcShort( 0xffff ),	/* Offset= -1 (305) */
/* 308 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 310 */	NdrFcShort( 0x4 ),	/* 4 */
/* 312 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 314 */	NdrFcShort( 0x0 ),	/* 0 */
/* 316 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 318 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 320 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 322 */	NdrFcShort( 0x4 ),	/* 4 */
/* 324 */	NdrFcShort( 0x0 ),	/* 0 */
/* 326 */	NdrFcShort( 0x1 ),	/* 1 */
/* 328 */	NdrFcShort( 0x0 ),	/* 0 */
/* 330 */	NdrFcShort( 0x0 ),	/* 0 */
/* 332 */	0x13, 0x0,	/* FC_OP */
/* 334 */	NdrFcShort( 0xff82 ),	/* Offset= -126 (208) */
/* 336 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 338 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 340 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 342 */	NdrFcShort( 0x8 ),	/* 8 */
/* 344 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 346 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 348 */	NdrFcShort( 0x4 ),	/* 4 */
/* 350 */	NdrFcShort( 0x4 ),	/* 4 */
/* 352 */	0x11, 0x0,	/* FC_RP */
/* 354 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (308) */
/* 356 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 358 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 360 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 362 */	NdrFcLong( 0x0 ),	/* 0 */
/* 366 */	NdrFcShort( 0x0 ),	/* 0 */
/* 368 */	NdrFcShort( 0x0 ),	/* 0 */
/* 370 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 372 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 374 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 376 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 378 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 380 */	NdrFcShort( 0x0 ),	/* 0 */
/* 382 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 384 */	NdrFcShort( 0x0 ),	/* 0 */
/* 386 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 388 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 392 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 394 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 396 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (360) */
/* 398 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 400 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 402 */	NdrFcShort( 0x8 ),	/* 8 */
/* 404 */	NdrFcShort( 0x0 ),	/* 0 */
/* 406 */	NdrFcShort( 0x6 ),	/* Offset= 6 (412) */
/* 408 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 410 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 412 */	
			0x11, 0x0,	/* FC_RP */
/* 414 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (378) */
/* 416 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 418 */	NdrFcLong( 0x20400 ),	/* 132096 */
/* 422 */	NdrFcShort( 0x0 ),	/* 0 */
/* 424 */	NdrFcShort( 0x0 ),	/* 0 */
/* 426 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 428 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 430 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 432 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 434 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 436 */	NdrFcShort( 0x0 ),	/* 0 */
/* 438 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 440 */	NdrFcShort( 0x0 ),	/* 0 */
/* 442 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 444 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 448 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 450 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 452 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (416) */
/* 454 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 456 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 458 */	NdrFcShort( 0x8 ),	/* 8 */
/* 460 */	NdrFcShort( 0x0 ),	/* 0 */
/* 462 */	NdrFcShort( 0x6 ),	/* Offset= 6 (468) */
/* 464 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 466 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 468 */	
			0x11, 0x0,	/* FC_RP */
/* 470 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (434) */
/* 472 */	
			0x2b,		/* FC_NON_ENCAPSULATED_UNION */
			0x9,		/* FC_ULONG */
/* 474 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 476 */	NdrFcShort( 0xfff8 ),	/* -8 */
/* 478 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 480 */	NdrFcShort( 0x2 ),	/* Offset= 2 (482) */
/* 482 */	NdrFcShort( 0x10 ),	/* 16 */
/* 484 */	NdrFcShort( 0x2f ),	/* 47 */
/* 486 */	NdrFcLong( 0x14 ),	/* 20 */
/* 490 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 492 */	NdrFcLong( 0x3 ),	/* 3 */
/* 496 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 498 */	NdrFcLong( 0x11 ),	/* 17 */
/* 502 */	NdrFcShort( 0x8001 ),	/* Simple arm type: FC_BYTE */
/* 504 */	NdrFcLong( 0x2 ),	/* 2 */
/* 508 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 510 */	NdrFcLong( 0x4 ),	/* 4 */
/* 514 */	NdrFcShort( 0x800a ),	/* Simple arm type: FC_FLOAT */
/* 516 */	NdrFcLong( 0x5 ),	/* 5 */
/* 520 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 522 */	NdrFcLong( 0xb ),	/* 11 */
/* 526 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 528 */	NdrFcLong( 0xa ),	/* 10 */
/* 532 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 534 */	NdrFcLong( 0x6 ),	/* 6 */
/* 538 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (770) */
/* 540 */	NdrFcLong( 0x7 ),	/* 7 */
/* 544 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 546 */	NdrFcLong( 0x8 ),	/* 8 */
/* 550 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (776) */
/* 552 */	NdrFcLong( 0xd ),	/* 13 */
/* 556 */	NdrFcShort( 0xff3c ),	/* Offset= -196 (360) */
/* 558 */	NdrFcLong( 0x9 ),	/* 9 */
/* 562 */	NdrFcShort( 0xff6e ),	/* Offset= -146 (416) */
/* 564 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 568 */	NdrFcShort( 0xd4 ),	/* Offset= 212 (780) */
/* 570 */	NdrFcLong( 0x24 ),	/* 36 */
/* 574 */	NdrFcShort( 0xd6 ),	/* Offset= 214 (788) */
/* 576 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 580 */	NdrFcShort( 0xd0 ),	/* Offset= 208 (788) */
/* 582 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 586 */	NdrFcShort( 0x100 ),	/* Offset= 256 (842) */
/* 588 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 592 */	NdrFcShort( 0xfe48 ),	/* Offset= -440 (152) */
/* 594 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 598 */	NdrFcShort( 0xf8 ),	/* Offset= 248 (846) */
/* 600 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 604 */	NdrFcShort( 0xf6 ),	/* Offset= 246 (850) */
/* 606 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 610 */	NdrFcShort( 0xf4 ),	/* Offset= 244 (854) */
/* 612 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 616 */	NdrFcShort( 0xf2 ),	/* Offset= 242 (858) */
/* 618 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 622 */	NdrFcShort( 0xfe2a ),	/* Offset= -470 (152) */
/* 624 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 628 */	NdrFcShort( 0xda ),	/* Offset= 218 (846) */
/* 630 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 634 */	NdrFcShort( 0xe4 ),	/* Offset= 228 (862) */
/* 636 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 640 */	NdrFcShort( 0xda ),	/* Offset= 218 (858) */
/* 642 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 646 */	NdrFcShort( 0xdc ),	/* Offset= 220 (866) */
/* 648 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 652 */	NdrFcShort( 0xda ),	/* Offset= 218 (870) */
/* 654 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 658 */	NdrFcShort( 0xd8 ),	/* Offset= 216 (874) */
/* 660 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 664 */	NdrFcShort( 0xd6 ),	/* Offset= 214 (878) */
/* 666 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 670 */	NdrFcShort( 0xdc ),	/* Offset= 220 (890) */
/* 672 */	NdrFcLong( 0x10 ),	/* 16 */
/* 676 */	NdrFcShort( 0x8002 ),	/* Simple arm type: FC_CHAR */
/* 678 */	NdrFcLong( 0x12 ),	/* 18 */
/* 682 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 684 */	NdrFcLong( 0x13 ),	/* 19 */
/* 688 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 690 */	NdrFcLong( 0x15 ),	/* 21 */
/* 694 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 696 */	NdrFcLong( 0x16 ),	/* 22 */
/* 700 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 702 */	NdrFcLong( 0x17 ),	/* 23 */
/* 706 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 708 */	NdrFcLong( 0xe ),	/* 14 */
/* 712 */	NdrFcShort( 0xba ),	/* Offset= 186 (898) */
/* 714 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 718 */	NdrFcShort( 0xbe ),	/* Offset= 190 (908) */
/* 720 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 724 */	NdrFcShort( 0xbc ),	/* Offset= 188 (912) */
/* 726 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 730 */	NdrFcShort( 0xfdbe ),	/* Offset= -578 (152) */
/* 732 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 736 */	NdrFcShort( 0x6e ),	/* Offset= 110 (846) */
/* 738 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 742 */	NdrFcShort( 0x6c ),	/* Offset= 108 (850) */
/* 744 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 748 */	NdrFcShort( 0x62 ),	/* Offset= 98 (846) */
/* 750 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 754 */	NdrFcShort( 0x5c ),	/* Offset= 92 (846) */
/* 756 */	NdrFcLong( 0x0 ),	/* 0 */
/* 760 */	NdrFcShort( 0x0 ),	/* Offset= 0 (760) */
/* 762 */	NdrFcLong( 0x1 ),	/* 1 */
/* 766 */	NdrFcShort( 0x0 ),	/* Offset= 0 (766) */
/* 768 */	NdrFcShort( 0xffff ),	/* Offset= -1 (767) */
/* 770 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 772 */	NdrFcShort( 0x8 ),	/* 8 */
/* 774 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 776 */	
			0x13, 0x0,	/* FC_OP */
/* 778 */	NdrFcShort( 0xfdc6 ),	/* Offset= -570 (208) */
/* 780 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 782 */	NdrFcShort( 0x2 ),	/* Offset= 2 (784) */
/* 784 */	
			0x13, 0x0,	/* FC_OP */
/* 786 */	NdrFcShort( 0x1b4 ),	/* Offset= 436 (1222) */
/* 788 */	
			0x13, 0x0,	/* FC_OP */
/* 790 */	NdrFcShort( 0x20 ),	/* Offset= 32 (822) */
/* 792 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 794 */	NdrFcLong( 0x2f ),	/* 47 */
/* 798 */	NdrFcShort( 0x0 ),	/* 0 */
/* 800 */	NdrFcShort( 0x0 ),	/* 0 */
/* 802 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 804 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 806 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 808 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 810 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 812 */	NdrFcShort( 0x1 ),	/* 1 */
/* 814 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 816 */	NdrFcShort( 0x4 ),	/* 4 */
/* 818 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 820 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 822 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 824 */	NdrFcShort( 0x10 ),	/* 16 */
/* 826 */	NdrFcShort( 0x0 ),	/* 0 */
/* 828 */	NdrFcShort( 0xa ),	/* Offset= 10 (838) */
/* 830 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 832 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 834 */	NdrFcShort( 0xffd6 ),	/* Offset= -42 (792) */
/* 836 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 838 */	
			0x13, 0x0,	/* FC_OP */
/* 840 */	NdrFcShort( 0xffe2 ),	/* Offset= -30 (810) */
/* 842 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 844 */	0x1,		/* FC_BYTE */
			0x5c,		/* FC_PAD */
/* 846 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 848 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 850 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 852 */	0xb,		/* FC_HYPER */
			0x5c,		/* FC_PAD */
/* 854 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 856 */	0xa,		/* FC_FLOAT */
			0x5c,		/* FC_PAD */
/* 858 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 860 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 862 */	
			0x13, 0x0,	/* FC_OP */
/* 864 */	NdrFcShort( 0xffa2 ),	/* Offset= -94 (770) */
/* 866 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 868 */	NdrFcShort( 0xffa4 ),	/* Offset= -92 (776) */
/* 870 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 872 */	NdrFcShort( 0xfe00 ),	/* Offset= -512 (360) */
/* 874 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 876 */	NdrFcShort( 0xfe34 ),	/* Offset= -460 (416) */
/* 878 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 880 */	NdrFcShort( 0x2 ),	/* Offset= 2 (882) */
/* 882 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 884 */	NdrFcShort( 0x2 ),	/* Offset= 2 (886) */
/* 886 */	
			0x13, 0x0,	/* FC_OP */
/* 888 */	NdrFcShort( 0x14e ),	/* Offset= 334 (1222) */
/* 890 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 892 */	NdrFcShort( 0x2 ),	/* Offset= 2 (894) */
/* 894 */	
			0x13, 0x0,	/* FC_OP */
/* 896 */	NdrFcShort( 0x14 ),	/* Offset= 20 (916) */
/* 898 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 900 */	NdrFcShort( 0x10 ),	/* 16 */
/* 902 */	0x6,		/* FC_SHORT */
			0x1,		/* FC_BYTE */
/* 904 */	0x1,		/* FC_BYTE */
			0x8,		/* FC_LONG */
/* 906 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 908 */	
			0x13, 0x0,	/* FC_OP */
/* 910 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (898) */
/* 912 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 914 */	0x2,		/* FC_CHAR */
			0x5c,		/* FC_PAD */
/* 916 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x7,		/* 7 */
/* 918 */	NdrFcShort( 0x20 ),	/* 32 */
/* 920 */	NdrFcShort( 0x0 ),	/* 0 */
/* 922 */	NdrFcShort( 0x0 ),	/* Offset= 0 (922) */
/* 924 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 926 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 928 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 930 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 932 */	NdrFcShort( 0xfe34 ),	/* Offset= -460 (472) */
/* 934 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 936 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 938 */	NdrFcShort( 0x4 ),	/* 4 */
/* 940 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 942 */	NdrFcShort( 0x0 ),	/* 0 */
/* 944 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 946 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 948 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 950 */	NdrFcShort( 0x4 ),	/* 4 */
/* 952 */	NdrFcShort( 0x0 ),	/* 0 */
/* 954 */	NdrFcShort( 0x1 ),	/* 1 */
/* 956 */	NdrFcShort( 0x0 ),	/* 0 */
/* 958 */	NdrFcShort( 0x0 ),	/* 0 */
/* 960 */	0x13, 0x0,	/* FC_OP */
/* 962 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (916) */
/* 964 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 966 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 968 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 970 */	NdrFcShort( 0x8 ),	/* 8 */
/* 972 */	NdrFcShort( 0x0 ),	/* 0 */
/* 974 */	NdrFcShort( 0x6 ),	/* Offset= 6 (980) */
/* 976 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 978 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 980 */	
			0x11, 0x0,	/* FC_RP */
/* 982 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (936) */
/* 984 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 986 */	NdrFcShort( 0x4 ),	/* 4 */
/* 988 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 990 */	NdrFcShort( 0x0 ),	/* 0 */
/* 992 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 994 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 996 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 998 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1000 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1002 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1004 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1006 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1008 */	0x13, 0x0,	/* FC_OP */
/* 1010 */	NdrFcShort( 0xff44 ),	/* Offset= -188 (822) */
/* 1012 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1014 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1016 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1018 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1020 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1022 */	NdrFcShort( 0x6 ),	/* Offset= 6 (1028) */
/* 1024 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1026 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1028 */	
			0x11, 0x0,	/* FC_RP */
/* 1030 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (984) */
/* 1032 */	
			0x1d,		/* FC_SMFARRAY */
			0x0,		/* 0 */
/* 1034 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1036 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1038 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1040 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1042 */	0x8,		/* FC_LONG */
			0x6,		/* FC_SHORT */
/* 1044 */	0x6,		/* FC_SHORT */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 1046 */	0x0,		/* 0 */
			NdrFcShort( 0xfff1 ),	/* Offset= -15 (1032) */
			0x5b,		/* FC_END */
/* 1050 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1052 */	NdrFcShort( 0x18 ),	/* 24 */
/* 1054 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1056 */	NdrFcShort( 0xa ),	/* Offset= 10 (1066) */
/* 1058 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1060 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1062 */	NdrFcShort( 0xffe8 ),	/* Offset= -24 (1038) */
/* 1064 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1066 */	
			0x11, 0x0,	/* FC_RP */
/* 1068 */	NdrFcShort( 0xfd4e ),	/* Offset= -690 (378) */
/* 1070 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 1072 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1074 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1076 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1078 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1080 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1082 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1084 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1086 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1088 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1090 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1092 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1094 */	0x13, 0x0,	/* FC_OP */
/* 1096 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1070) */
/* 1098 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1100 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1102 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 1104 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1106 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1108 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1110 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1112 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 1114 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1116 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1118 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1120 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1122 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1124 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1126 */	0x13, 0x0,	/* FC_OP */
/* 1128 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1102) */
/* 1130 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1132 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1134 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1136 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1138 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1140 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1142 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1144 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1146 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1148 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1150 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1152 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1154 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1156 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1158 */	0x13, 0x0,	/* FC_OP */
/* 1160 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1134) */
/* 1162 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1164 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1166 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 1168 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1170 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1172 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1174 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1176 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 1178 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1180 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1182 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1184 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1186 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1188 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1190 */	0x13, 0x0,	/* FC_OP */
/* 1192 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1166) */
/* 1194 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1196 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1198 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1200 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1202 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1204 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1206 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1208 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1210 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 1212 */	NdrFcShort( 0xffd8 ),	/* -40 */
/* 1214 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1216 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1218 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1198) */
/* 1220 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1222 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1224 */	NdrFcShort( 0x28 ),	/* 40 */
/* 1226 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1206) */
/* 1228 */	NdrFcShort( 0x0 ),	/* Offset= 0 (1228) */
/* 1230 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1232 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1234 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1236 */	NdrFcShort( 0xfc1c ),	/* Offset= -996 (240) */
/* 1238 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1240 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1242 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1244 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1246 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1248 */	NdrFcShort( 0xfc08 ),	/* Offset= -1016 (232) */
/* 1250 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 1252 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 1254 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 1256 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 1258 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1260 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1262) */
/* 1262 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1264 */	NdrFcLong( 0x641c669 ),	/* 104973929 */
/* 1268 */	NdrFcShort( 0xb362 ),	/* -19614 */
/* 1270 */	NdrFcShort( 0x48c9 ),	/* 18633 */
/* 1272 */	0x8b,		/* 139 */
			0x73,		/* 115 */
/* 1274 */	0xd0,		/* 208 */
			0x2b,		/* 43 */
/* 1276 */	0x6e,		/* 110 */
			0x25,		/* 37 */
/* 1278 */	0x2a,		/* 42 */
			0x9d,		/* 157 */
/* 1280 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 1282 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */

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


/* Object interface: IResult, ver. 0.0,
   GUID={0x9B7D45A5,0x77FD,0x4E97,{0x8C,0x4A,0x76,0xD3,0x61,0x0C,0xC8,0x75}} */

#pragma code_seg(".orpc")
static const unsigned short IResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
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
CINTERFACE_PROXY_VTABLE(7) _IResultProxyVtbl = 
{
    0,
    &IID_IResult,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IResultStubVtbl =
{
    &IID_IResult,
    &IResult_ServerInfo,
    7,
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
    0,
    36
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
    78,
    114,
    150,
    192
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
    (void *) (INT_PTR) -1 /* IAction::GetNextActionManager */ ,
    (void *) (INT_PTR) -1 /* IAction::SetActionParameters */ ,
    (void *) (INT_PTR) -1 /* IAction::Do */ ,
    (void *) (INT_PTR) -1 /* IAction::SetProgressBarInfo */
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


/* Object interface: INode, ver. 0.0,
   GUID={0xD3BEDA0D,0x1771,0x4493,{0xBB,0x5C,0xE9,0x33,0x84,0x79,0x2B,0x2A}} */

#pragma code_seg(".orpc")
static const unsigned short INode_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    228,
    264
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
    300,
    342
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
CINTERFACE_PROXY_VTABLE(9) _IActionFactoryProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IActionFactory::CanCreateAction */ ,
    (void *) (INT_PTR) -1 /* IActionFactory::CreateAction */
};


static const PRPC_STUB_FUNCTION IActionFactory_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IActionFactoryStubVtbl =
{
    &IID_IActionFactory,
    &IActionFactory_ServerInfo,
    9,
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
    384
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
CINTERFACE_PROXY_VTABLE(8) _IActionAllocatorProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IActionAllocator::AllocateActionManager */
};


static const PRPC_STUB_FUNCTION IActionAllocator_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IActionAllocatorStubVtbl =
{
    &IID_IActionAllocator,
    &IActionAllocator_ServerInfo,
    8,
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
    426
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
    462
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
    498,
    534,
    564,
    594,
    636,
    672
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
    708,
    744,
    780,
    816,
    858,
    900,
    942
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

#pragma code_seg(".orpc")
static const unsigned short IWritableGraphInfo_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1
    };

static const MIDL_STUBLESS_PROXY_INFO IWritableGraphInfo_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IWritableGraphInfo_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IWritableGraphInfo_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IWritableGraphInfo_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(8) _IWritableGraphInfoProxyVtbl = 
{
    &IWritableGraphInfo_ProxyInfo,
    &IID_IWritableGraphInfo,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* (void *) (INT_PTR) -1 /* IWritableGraphInfo::AddGraph */
};


static const PRPC_STUB_FUNCTION IWritableGraphInfo_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IWritableGraphInfoStubVtbl =
{
    &IID_IWritableGraphInfo,
    &IWritableGraphInfo_ServerInfo,
    8,
    &IWritableGraphInfo_table[-3],
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
    (unsigned short) -1,
    (unsigned short) -1,
    984,
    1020,
    1062
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
CINTERFACE_PROXY_VTABLE(12) _IGraphResultProxyVtbl = 
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
    0 /* (void *) (INT_PTR) -1 /* IGraphResult::GetGraph */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraphResult::GetCount */ ,
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
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IGraphResultStubVtbl =
{
    &IID_IGraphResult,
    &IGraphResult_ServerInfo,
    12,
    &IGraphResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IWritableGraphResult, ver. 0.0,
   GUID={0x6ED8D0EA,0x3E9C,0x441A,{0x96,0xC6,0xEE,0xB2,0xAF,0xCB,0xE2,0x7D}} */

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
    ( CInterfaceProxyVtbl *) &_IActionAllocatorProxyVtbl,
    ( CInterfaceProxyVtbl *) &_INodeProxyVtbl,
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
    ( CInterfaceProxyVtbl *) &_IWritableGraphInfoProxyVtbl,
    0
};

const CInterfaceStubVtbl * __MorseKernel2_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_IActionAllocatorStubVtbl,
    ( CInterfaceStubVtbl *) &_INodeStubVtbl,
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
    ( CInterfaceStubVtbl *) &_IWritableGraphInfoStubVtbl,
    0
};

PCInterfaceName const __MorseKernel2_InterfaceNamesList[] = 
{
    "IActionAllocator",
    "INode",
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
    "IWritableGraphInfo",
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
    0
};


#define __MorseKernel2_CHECK_IID(n)	IID_GENERIC_CHECK_IID( __MorseKernel2, pIID, n)

int __stdcall __MorseKernel2_IID_Lookup( const IID * pIID, int * pIndex )
{
    IID_BS_LOOKUP_SETUP

    IID_BS_LOOKUP_INITIAL_TEST( __MorseKernel2, 15, 8 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 4 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 2 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( __MorseKernel2, 15, *pIndex )
    
}

const ExtendedProxyFileInfo _MorseKernel2_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & __MorseKernel2_ProxyVtblList,
    (PCInterfaceStubVtblList *) & __MorseKernel2_StubVtblList,
    (const PCInterfaceName * ) & __MorseKernel2_InterfaceNamesList,
    (const IID ** ) & __MorseKernel2_BaseIIDList,
    & __MorseKernel2_IID_Lookup, 
    15,
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

