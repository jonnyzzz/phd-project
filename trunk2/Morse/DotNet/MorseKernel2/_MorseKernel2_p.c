

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Fri Feb 25 00:08:10 2005
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

#define TYPE_FORMAT_STRING_SIZE   1281                              
#define PROC_FORMAT_STRING_SIZE   829                               
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


extern const MIDL_SERVER_INFO IComponentRegistrar_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComponentRegistrar_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGroupNode_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGroupNode_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraphResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraphNode_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphNode_ProxyInfo;


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

	/* Procedure ProgressBarInfo */

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

	/* Procedure CanCreateAction */

/* 264 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 266 */	NdrFcLong( 0x0 ),	/* 0 */
/* 270 */	NdrFcShort( 0x7 ),	/* 7 */
/* 272 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 274 */	NdrFcShort( 0x0 ),	/* 0 */
/* 276 */	NdrFcShort( 0x36 ),	/* 54 */
/* 278 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 280 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 282 */	NdrFcShort( 0x0 ),	/* 0 */
/* 284 */	NdrFcShort( 0x0 ),	/* 0 */
/* 286 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 288 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 290 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 292 */	NdrFcShort( 0x82 ),	/* Type Offset=130 */

	/* Parameter result */

/* 294 */	NdrFcShort( 0x2012 ),	/* Flags:  must free, out, srv alloc size=8 */
/* 296 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 298 */	NdrFcShort( 0x94 ),	/* Type Offset=148 */

	/* Return value */

/* 300 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 302 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 304 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateAction */

/* 306 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 308 */	NdrFcLong( 0x0 ),	/* 0 */
/* 312 */	NdrFcShort( 0x8 ),	/* 8 */
/* 314 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 316 */	NdrFcShort( 0x0 ),	/* 0 */
/* 318 */	NdrFcShort( 0x8 ),	/* 8 */
/* 320 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 322 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 324 */	NdrFcShort( 0x0 ),	/* 0 */
/* 326 */	NdrFcShort( 0x0 ),	/* 0 */
/* 328 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 330 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 332 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 334 */	NdrFcShort( 0x82 ),	/* Type Offset=130 */

	/* Parameter action */

/* 336 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 338 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 340 */	NdrFcShort( 0x6 ),	/* Type Offset=6 */

	/* Return value */

/* 342 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 344 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 346 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AllocateActionManager */

/* 348 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 350 */	NdrFcLong( 0x0 ),	/* 0 */
/* 354 */	NdrFcShort( 0x7 ),	/* 7 */
/* 356 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 358 */	NdrFcShort( 0x0 ),	/* 0 */
/* 360 */	NdrFcShort( 0x8 ),	/* 8 */
/* 362 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 364 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 366 */	NdrFcShort( 0x0 ),	/* 0 */
/* 368 */	NdrFcShort( 0x0 ),	/* 0 */
/* 370 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 372 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 374 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 376 */	NdrFcShort( 0x82 ),	/* Type Offset=130 */

	/* Parameter manager */

/* 378 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 380 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 382 */	NdrFcShort( 0x6c ),	/* Type Offset=108 */

	/* Return value */

/* 384 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 386 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 388 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterActionFactory */

/* 390 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 392 */	NdrFcLong( 0x0 ),	/* 0 */
/* 396 */	NdrFcShort( 0x7 ),	/* 7 */
/* 398 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 400 */	NdrFcShort( 0x0 ),	/* 0 */
/* 402 */	NdrFcShort( 0x8 ),	/* 8 */
/* 404 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 406 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 408 */	NdrFcShort( 0x0 ),	/* 0 */
/* 410 */	NdrFcShort( 0x0 ),	/* 0 */
/* 412 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter action */

/* 414 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 416 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 418 */	NdrFcShort( 0x9c ),	/* Type Offset=156 */

	/* Return value */

/* 420 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 422 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 424 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Attach */

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
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 444 */	NdrFcShort( 0x0 ),	/* 0 */
/* 446 */	NdrFcShort( 0x1 ),	/* 1 */
/* 448 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrPath */

/* 450 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 452 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 454 */	NdrFcShort( 0xc8 ),	/* Type Offset=200 */

	/* Return value */

/* 456 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 458 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 460 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterAll */

/* 462 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 464 */	NdrFcLong( 0x0 ),	/* 0 */
/* 468 */	NdrFcShort( 0x8 ),	/* 8 */
/* 470 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 472 */	NdrFcShort( 0x0 ),	/* 0 */
/* 474 */	NdrFcShort( 0x8 ),	/* 8 */
/* 476 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 478 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 480 */	NdrFcShort( 0x0 ),	/* 0 */
/* 482 */	NdrFcShort( 0x0 ),	/* 0 */
/* 484 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 486 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 488 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 490 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterAll */

/* 492 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 494 */	NdrFcLong( 0x0 ),	/* 0 */
/* 498 */	NdrFcShort( 0x9 ),	/* 9 */
/* 500 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 502 */	NdrFcShort( 0x0 ),	/* 0 */
/* 504 */	NdrFcShort( 0x8 ),	/* 8 */
/* 506 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 508 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 510 */	NdrFcShort( 0x0 ),	/* 0 */
/* 512 */	NdrFcShort( 0x0 ),	/* 0 */
/* 514 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 516 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 518 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 520 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetComponents */

/* 522 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 524 */	NdrFcLong( 0x0 ),	/* 0 */
/* 528 */	NdrFcShort( 0xa ),	/* 10 */
/* 530 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 532 */	NdrFcShort( 0x0 ),	/* 0 */
/* 534 */	NdrFcShort( 0x8 ),	/* 8 */
/* 536 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 538 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 540 */	NdrFcShort( 0x24 ),	/* 36 */
/* 542 */	NdrFcShort( 0x0 ),	/* 0 */
/* 544 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pbstrCLSIDs */

/* 546 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 548 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 550 */	NdrFcShort( 0x4c6 ),	/* Type Offset=1222 */

	/* Parameter pbstrDescriptions */

/* 552 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 554 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 556 */	NdrFcShort( 0x4c6 ),	/* Type Offset=1222 */

	/* Return value */

/* 558 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 560 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 562 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterComponent */

/* 564 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 566 */	NdrFcLong( 0x0 ),	/* 0 */
/* 570 */	NdrFcShort( 0xb ),	/* 11 */
/* 572 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 574 */	NdrFcShort( 0x0 ),	/* 0 */
/* 576 */	NdrFcShort( 0x8 ),	/* 8 */
/* 578 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 580 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 582 */	NdrFcShort( 0x0 ),	/* 0 */
/* 584 */	NdrFcShort( 0x1 ),	/* 1 */
/* 586 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 588 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 590 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 592 */	NdrFcShort( 0xc8 ),	/* Type Offset=200 */

	/* Return value */

/* 594 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 596 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 598 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterComponent */

/* 600 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 602 */	NdrFcLong( 0x0 ),	/* 0 */
/* 606 */	NdrFcShort( 0xc ),	/* 12 */
/* 608 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 610 */	NdrFcShort( 0x0 ),	/* 0 */
/* 612 */	NdrFcShort( 0x8 ),	/* 8 */
/* 614 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 616 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 618 */	NdrFcShort( 0x0 ),	/* 0 */
/* 620 */	NdrFcShort( 0x1 ),	/* 1 */
/* 622 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 624 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 626 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 628 */	NdrFcShort( 0xc8 ),	/* Type Offset=200 */

	/* Return value */

/* 630 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 632 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 634 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetLength */

/* 636 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 638 */	NdrFcLong( 0x0 ),	/* 0 */
/* 642 */	NdrFcShort( 0x7 ),	/* 7 */
/* 644 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 646 */	NdrFcShort( 0x0 ),	/* 0 */
/* 648 */	NdrFcShort( 0x24 ),	/* 36 */
/* 650 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 652 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 654 */	NdrFcShort( 0x0 ),	/* 0 */
/* 656 */	NdrFcShort( 0x0 ),	/* 0 */
/* 658 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter count */

/* 660 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 662 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 664 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 666 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 668 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 670 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetNode */

/* 672 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 674 */	NdrFcLong( 0x0 ),	/* 0 */
/* 678 */	NdrFcShort( 0x8 ),	/* 8 */
/* 680 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 682 */	NdrFcShort( 0x8 ),	/* 8 */
/* 684 */	NdrFcShort( 0x8 ),	/* 8 */
/* 686 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 688 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 690 */	NdrFcShort( 0x0 ),	/* 0 */
/* 692 */	NdrFcShort( 0x0 ),	/* 0 */
/* 694 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 696 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 698 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 700 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter node */

/* 702 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 704 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 706 */	NdrFcShort( 0x4d4 ),	/* Type Offset=1236 */

	/* Return value */

/* 708 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 710 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 712 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AddNode */

/* 714 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 716 */	NdrFcLong( 0x0 ),	/* 0 */
/* 720 */	NdrFcShort( 0x9 ),	/* 9 */
/* 722 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 724 */	NdrFcShort( 0x0 ),	/* 0 */
/* 726 */	NdrFcShort( 0x8 ),	/* 8 */
/* 728 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 730 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 732 */	NdrFcShort( 0x0 ),	/* 0 */
/* 734 */	NdrFcShort( 0x0 ),	/* 0 */
/* 736 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 738 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 740 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 742 */	NdrFcShort( 0x4d8 ),	/* Type Offset=1240 */

	/* Return value */

/* 744 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 746 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 748 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateNode */

/* 750 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 752 */	NdrFcLong( 0x0 ),	/* 0 */
/* 756 */	NdrFcShort( 0xa ),	/* 10 */
/* 758 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 760 */	NdrFcShort( 0x0 ),	/* 0 */
/* 762 */	NdrFcShort( 0x8 ),	/* 8 */
/* 764 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 766 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 768 */	NdrFcShort( 0x0 ),	/* 0 */
/* 770 */	NdrFcShort( 0x0 ),	/* 0 */
/* 772 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter node */

/* 774 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 776 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 778 */	NdrFcShort( 0x4d4 ),	/* Type Offset=1236 */

	/* Return value */

/* 780 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 782 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 784 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetAsGraphResult */

/* 786 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 788 */	NdrFcLong( 0x0 ),	/* 0 */
/* 792 */	NdrFcShort( 0xa ),	/* 10 */
/* 794 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 796 */	NdrFcShort( 0x8 ),	/* 8 */
/* 798 */	NdrFcShort( 0x8 ),	/* 8 */
/* 800 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 802 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 804 */	NdrFcShort( 0x0 ),	/* 0 */
/* 806 */	NdrFcShort( 0x0 ),	/* 0 */
/* 808 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 810 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 812 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 814 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter result */

/* 816 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 818 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 820 */	NdrFcShort( 0x4ea ),	/* Type Offset=1258 */

	/* Return value */

/* 822 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 824 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 826 */	0x8,		/* FC_LONG */
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
			0x12, 0x0,	/* FC_UP */
/* 176 */	NdrFcShort( 0xe ),	/* Offset= 14 (190) */
/* 178 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 180 */	NdrFcShort( 0x2 ),	/* 2 */
/* 182 */	0x9,		/* Corr desc: FC_ULONG */
			0x0,		/*  */
/* 184 */	NdrFcShort( 0xfffc ),	/* -4 */
/* 186 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 188 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 190 */	
			0x17,		/* FC_CSTRUCT */
			0x3,		/* 3 */
/* 192 */	NdrFcShort( 0x8 ),	/* 8 */
/* 194 */	NdrFcShort( 0xfff0 ),	/* Offset= -16 (178) */
/* 196 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 198 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 200 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 202 */	NdrFcShort( 0x0 ),	/* 0 */
/* 204 */	NdrFcShort( 0x4 ),	/* 4 */
/* 206 */	NdrFcShort( 0x0 ),	/* 0 */
/* 208 */	NdrFcShort( 0xffde ),	/* Offset= -34 (174) */
/* 210 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 212 */	NdrFcShort( 0x3f2 ),	/* Offset= 1010 (1222) */
/* 214 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 216 */	NdrFcShort( 0x2 ),	/* Offset= 2 (218) */
/* 218 */	
			0x13, 0x0,	/* FC_OP */
/* 220 */	NdrFcShort( 0x3d8 ),	/* Offset= 984 (1204) */
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
/* 250 */	NdrFcShort( 0x2bc ),	/* Offset= 700 (950) */
/* 252 */	NdrFcLong( 0x24 ),	/* 36 */
/* 256 */	NdrFcShort( 0x2e6 ),	/* Offset= 742 (998) */
/* 258 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 262 */	NdrFcShort( 0x302 ),	/* Offset= 770 (1032) */
/* 264 */	NdrFcLong( 0x10 ),	/* 16 */
/* 268 */	NdrFcShort( 0x31c ),	/* Offset= 796 (1064) */
/* 270 */	NdrFcLong( 0x2 ),	/* 2 */
/* 274 */	NdrFcShort( 0x336 ),	/* Offset= 822 (1096) */
/* 276 */	NdrFcLong( 0x3 ),	/* 3 */
/* 280 */	NdrFcShort( 0x350 ),	/* Offset= 848 (1128) */
/* 282 */	NdrFcLong( 0x14 ),	/* 20 */
/* 286 */	NdrFcShort( 0x36a ),	/* Offset= 874 (1160) */
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
/* 316 */	NdrFcShort( 0xff82 ),	/* Offset= -126 (190) */
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
/* 574 */	NdrFcShort( 0xfe5a ),	/* Offset= -422 (152) */
/* 576 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 580 */	NdrFcShort( 0xf8 ),	/* Offset= 248 (828) */
/* 582 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 586 */	NdrFcShort( 0xf6 ),	/* Offset= 246 (832) */
/* 588 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 592 */	NdrFcShort( 0xf4 ),	/* Offset= 244 (836) */
/* 594 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 598 */	NdrFcShort( 0xf2 ),	/* Offset= 242 (840) */
/* 600 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 604 */	NdrFcShort( 0xfe3c ),	/* Offset= -452 (152) */
/* 606 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 610 */	NdrFcShort( 0xda ),	/* Offset= 218 (828) */
/* 612 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 616 */	NdrFcShort( 0xe4 ),	/* Offset= 228 (844) */
/* 618 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 622 */	NdrFcShort( 0xda ),	/* Offset= 218 (840) */
/* 624 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 628 */	NdrFcShort( 0xdc ),	/* Offset= 220 (848) */
/* 630 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 634 */	NdrFcShort( 0xda ),	/* Offset= 218 (852) */
/* 636 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 640 */	NdrFcShort( 0xd8 ),	/* Offset= 216 (856) */
/* 642 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 646 */	NdrFcShort( 0xd6 ),	/* Offset= 214 (860) */
/* 648 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 652 */	NdrFcShort( 0xdc ),	/* Offset= 220 (872) */
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
/* 694 */	NdrFcShort( 0xba ),	/* Offset= 186 (880) */
/* 696 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 700 */	NdrFcShort( 0xbe ),	/* Offset= 190 (890) */
/* 702 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 706 */	NdrFcShort( 0xbc ),	/* Offset= 188 (894) */
/* 708 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 712 */	NdrFcShort( 0xfdd0 ),	/* Offset= -560 (152) */
/* 714 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 718 */	NdrFcShort( 0x6e ),	/* Offset= 110 (828) */
/* 720 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 724 */	NdrFcShort( 0x6c ),	/* Offset= 108 (832) */
/* 726 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 730 */	NdrFcShort( 0x62 ),	/* Offset= 98 (828) */
/* 732 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 736 */	NdrFcShort( 0x5c ),	/* Offset= 92 (828) */
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
/* 760 */	NdrFcShort( 0xfdc6 ),	/* Offset= -570 (190) */
/* 762 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 764 */	NdrFcShort( 0x2 ),	/* Offset= 2 (766) */
/* 766 */	
			0x13, 0x0,	/* FC_OP */
/* 768 */	NdrFcShort( 0x1b4 ),	/* Offset= 436 (1204) */
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
/* 830 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 832 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 834 */	0xb,		/* FC_HYPER */
			0x5c,		/* FC_PAD */
/* 836 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 838 */	0xa,		/* FC_FLOAT */
			0x5c,		/* FC_PAD */
/* 840 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 842 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 844 */	
			0x13, 0x0,	/* FC_OP */
/* 846 */	NdrFcShort( 0xffa2 ),	/* Offset= -94 (752) */
/* 848 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 850 */	NdrFcShort( 0xffa4 ),	/* Offset= -92 (758) */
/* 852 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 854 */	NdrFcShort( 0xfe00 ),	/* Offset= -512 (342) */
/* 856 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 858 */	NdrFcShort( 0xfe34 ),	/* Offset= -460 (398) */
/* 860 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 862 */	NdrFcShort( 0x2 ),	/* Offset= 2 (864) */
/* 864 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 866 */	NdrFcShort( 0x2 ),	/* Offset= 2 (868) */
/* 868 */	
			0x13, 0x0,	/* FC_OP */
/* 870 */	NdrFcShort( 0x14e ),	/* Offset= 334 (1204) */
/* 872 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 874 */	NdrFcShort( 0x2 ),	/* Offset= 2 (876) */
/* 876 */	
			0x13, 0x0,	/* FC_OP */
/* 878 */	NdrFcShort( 0x14 ),	/* Offset= 20 (898) */
/* 880 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 882 */	NdrFcShort( 0x10 ),	/* 16 */
/* 884 */	0x6,		/* FC_SHORT */
			0x1,		/* FC_BYTE */
/* 886 */	0x1,		/* FC_BYTE */
			0x8,		/* FC_LONG */
/* 888 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 890 */	
			0x13, 0x0,	/* FC_OP */
/* 892 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (880) */
/* 894 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 896 */	0x2,		/* FC_CHAR */
			0x5c,		/* FC_PAD */
/* 898 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x7,		/* 7 */
/* 900 */	NdrFcShort( 0x20 ),	/* 32 */
/* 902 */	NdrFcShort( 0x0 ),	/* 0 */
/* 904 */	NdrFcShort( 0x0 ),	/* Offset= 0 (904) */
/* 906 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 908 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 910 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 912 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 914 */	NdrFcShort( 0xfe34 ),	/* Offset= -460 (454) */
/* 916 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
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
/* 944 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (898) */
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
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 968 */	NdrFcShort( 0x4 ),	/* 4 */
/* 970 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 972 */	NdrFcShort( 0x0 ),	/* 0 */
/* 974 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 976 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 978 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 980 */	NdrFcShort( 0x4 ),	/* 4 */
/* 982 */	NdrFcShort( 0x0 ),	/* 0 */
/* 984 */	NdrFcShort( 0x1 ),	/* 1 */
/* 986 */	NdrFcShort( 0x0 ),	/* 0 */
/* 988 */	NdrFcShort( 0x0 ),	/* 0 */
/* 990 */	0x13, 0x0,	/* FC_OP */
/* 992 */	NdrFcShort( 0xff44 ),	/* Offset= -188 (804) */
/* 994 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 996 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 998 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1000 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1002 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1004 */	NdrFcShort( 0x6 ),	/* Offset= 6 (1010) */
/* 1006 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1008 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1010 */	
			0x11, 0x0,	/* FC_RP */
/* 1012 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (966) */
/* 1014 */	
			0x1d,		/* FC_SMFARRAY */
			0x0,		/* 0 */
/* 1016 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1018 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1020 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1022 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1024 */	0x8,		/* FC_LONG */
			0x6,		/* FC_SHORT */
/* 1026 */	0x6,		/* FC_SHORT */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 1028 */	0x0,		/* 0 */
			NdrFcShort( 0xfff1 ),	/* Offset= -15 (1014) */
			0x5b,		/* FC_END */
/* 1032 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1034 */	NdrFcShort( 0x18 ),	/* 24 */
/* 1036 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1038 */	NdrFcShort( 0xa ),	/* Offset= 10 (1048) */
/* 1040 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1042 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1044 */	NdrFcShort( 0xffe8 ),	/* Offset= -24 (1020) */
/* 1046 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1048 */	
			0x11, 0x0,	/* FC_RP */
/* 1050 */	NdrFcShort( 0xfd4e ),	/* Offset= -690 (360) */
/* 1052 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 1054 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1056 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1058 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1060 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1062 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1064 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1066 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1068 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1070 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1072 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1074 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1076 */	0x13, 0x0,	/* FC_OP */
/* 1078 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1052) */
/* 1080 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1082 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1084 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 1086 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1088 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1090 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1092 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1094 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 1096 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1098 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1100 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1102 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1104 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1106 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1108 */	0x13, 0x0,	/* FC_OP */
/* 1110 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1084) */
/* 1112 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1114 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1116 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1118 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1120 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1122 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1124 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1126 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1128 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1130 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1132 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1134 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1136 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1138 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1140 */	0x13, 0x0,	/* FC_OP */
/* 1142 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1116) */
/* 1144 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1146 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1148 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 1150 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1152 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1154 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1156 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1158 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 1160 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1162 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1164 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1166 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1168 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1170 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1172 */	0x13, 0x0,	/* FC_OP */
/* 1174 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1148) */
/* 1176 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1178 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1180 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1182 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1184 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1186 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1188 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1190 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1192 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 1194 */	NdrFcShort( 0xffd8 ),	/* -40 */
/* 1196 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1198 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1200 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1180) */
/* 1202 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1204 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1206 */	NdrFcShort( 0x28 ),	/* 40 */
/* 1208 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1188) */
/* 1210 */	NdrFcShort( 0x0 ),	/* Offset= 0 (1210) */
/* 1212 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1214 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1216 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1218 */	NdrFcShort( 0xfc1c ),	/* Offset= -996 (222) */
/* 1220 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1222 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1224 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1226 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1228 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1230 */	NdrFcShort( 0xfc08 ),	/* Offset= -1016 (214) */
/* 1232 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 1234 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 1236 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1238 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1240) */
/* 1240 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1242 */	NdrFcLong( 0xd3beda0d ),	/* -742467059 */
/* 1246 */	NdrFcShort( 0x1771 ),	/* 6001 */
/* 1248 */	NdrFcShort( 0x4493 ),	/* 17555 */
/* 1250 */	0xbb,		/* 187 */
			0x5c,		/* 92 */
/* 1252 */	0xe9,		/* 233 */
			0x33,		/* 51 */
/* 1254 */	0x84,		/* 132 */
			0x79,		/* 121 */
/* 1256 */	0x2b,		/* 43 */
			0x2a,		/* 42 */
/* 1258 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1260 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1262) */
/* 1262 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1264 */	NdrFcLong( 0x6e606370 ),	/* 1851810672 */
/* 1268 */	NdrFcShort( 0x4e2 ),	/* 1250 */
/* 1270 */	NdrFcShort( 0x4bcb ),	/* 19403 */
/* 1272 */	0x85,		/* 133 */
			0x2c,		/* 44 */
/* 1274 */	0x31,		/* 49 */
			0x3a,		/* 58 */
/* 1276 */	0x7d,		/* 125 */
			0x4b,		/* 75 */
/* 1278 */	0xad,		/* 173 */
			0x15,		/* 21 */

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
    (void *) (INT_PTR) -1 /* IAction::ProgressBarInfo */
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
    228
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
CINTERFACE_PROXY_VTABLE(8) _INodeProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* INode::GetActionManager */
};


static const PRPC_STUB_FUNCTION INode_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _INodeStubVtbl =
{
    &IID_INode,
    &INode_ServerInfo,
    8,
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
    264,
    306
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
    348
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
    390
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


/* Object interface: IComponentRegistrar, ver. 0.0,
   GUID={0xa817e7a2,0x43fa,0x11d0,{0x9e,0x44,0x00,0xaa,0x00,0xb6,0x77,0x0a}} */

#pragma code_seg(".orpc")
static const unsigned short IComponentRegistrar_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    426,
    462,
    492,
    522,
    564,
    600
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


/* Object interface: IGroupNode, ver. 0.0,
   GUID={0x28EBA211,0xE2B0,0x4717,{0x87,0xAA,0x63,0xA0,0xA5,0xC7,0x6C,0xDC}} */

#pragma code_seg(".orpc")
static const unsigned short IGroupNode_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    636,
    672,
    714,
    750
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
CINTERFACE_PROXY_VTABLE(11) _IGroupNodeProxyVtbl = 
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
    NdrStubCall2
};

CInterfaceStubVtbl _IGroupNodeStubVtbl =
{
    &IID_IGroupNode,
    &IGroupNode_ServerInfo,
    11,
    &IGroupNode_table[-3],
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
    0
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
CINTERFACE_PROXY_VTABLE(7) _IGraphResultProxyVtbl = 
{
    0,
    &IID_IGraphResult,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IGraphResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IGraphResultStubVtbl =
{
    &IID_IGraphResult,
    &IGraphResult_ServerInfo,
    7,
    &IGraphResult_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IGraphNode, ver. 0.0,
   GUID={0x5CBE5D72,0x2BA0,0x4321,{0xBB,0x64,0x07,0x72,0xD2,0x00,0x4C,0x9A}} */

#pragma code_seg(".orpc")
static const unsigned short IGraphNode_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    228,
    (unsigned short) -1,
    (unsigned short) -1,
    786
    };

static const MIDL_STUBLESS_PROXY_INFO IGraphNode_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IGraphNode_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IGraphNode_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IGraphNode_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(11) _IGraphNodeProxyVtbl = 
{
    &IGraphNode_ProxyInfo,
    &IID_IGraphNode,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* INode::GetActionManager */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraphNode::GetGraphCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IGraphNode::GetGraph */ ,
    (void *) (INT_PTR) -1 /* IGraphNode::GetAsGraphResult */
};


static const PRPC_STUB_FUNCTION IGraphNode_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IGraphNodeStubVtbl =
{
    &IID_IGraphNode,
    &IGraphNode_ServerInfo,
    11,
    &IGraphNode_table[-3],
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
    ( CInterfaceProxyVtbl *) &_IActionAllocatorProxyVtbl,
    ( CInterfaceProxyVtbl *) &_INodeProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGroupNodeProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphNodeProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionManagerProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableActionAllocatorProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComponentRegistrarProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionFactoryProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionBaseProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProgressBarInfoProxyVtbl,
    0
};

const CInterfaceStubVtbl * __MorseKernel2_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_IActionAllocatorStubVtbl,
    ( CInterfaceStubVtbl *) &_INodeStubVtbl,
    ( CInterfaceStubVtbl *) &_IGroupNodeStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphNodeStubVtbl,
    ( CInterfaceStubVtbl *) &_IParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionManagerStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableActionAllocatorStubVtbl,
    ( CInterfaceStubVtbl *) &_IComponentRegistrarStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionFactoryStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionBaseStubVtbl,
    ( CInterfaceStubVtbl *) &_IProgressBarInfoStubVtbl,
    0
};

PCInterfaceName const __MorseKernel2_InterfaceNamesList[] = 
{
    "IActionAllocator",
    "INode",
    "IGroupNode",
    "IGraphResult",
    "IGraphNode",
    "IParameters",
    "IActionManager",
    "IWritableActionAllocator",
    "IComponentRegistrar",
    "IResult",
    "IActionFactory",
    "IAction",
    "IActionBase",
    "IProgressBarInfo",
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
    0
};


#define __MorseKernel2_CHECK_IID(n)	IID_GENERIC_CHECK_IID( __MorseKernel2, pIID, n)

int __stdcall __MorseKernel2_IID_Lookup( const IID * pIID, int * pIndex )
{
    IID_BS_LOOKUP_SETUP

    IID_BS_LOOKUP_INITIAL_TEST( __MorseKernel2, 14, 8 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 4 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 2 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( __MorseKernel2, 14, *pIndex )
    
}

const ExtendedProxyFileInfo _MorseKernel2_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & __MorseKernel2_ProxyVtblList,
    (PCInterfaceStubVtblList *) & __MorseKernel2_StubVtblList,
    (const PCInterfaceName * ) & __MorseKernel2_InterfaceNamesList,
    (const IID ** ) & __MorseKernel2_BaseIIDList,
    & __MorseKernel2_IID_Lookup, 
    14,
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

