

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Sun Mar 13 23:11:53 2005
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

#define TYPE_FORMAT_STRING_SIZE   1277                              
#define PROC_FORMAT_STRING_SIZE   1255                              
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


extern const MIDL_SERVER_INFO IParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IProgressBarInfo_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IProgressBarInfo_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComponentRegistrar_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComponentRegistrar_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IFunction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IFunction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableFunction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableFunction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraphInfo_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphInfo_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResultMerger_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResultMerger_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraphResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableGraphResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableGraphResult_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernell_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernell_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableKernell_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableKernell_ProxyInfo;


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


	/* Parameter length */

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

	/* Parameter stop */

/* 90 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 92 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 94 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

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

	/* Procedure SetActionParameters */

/* 162 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 164 */	NdrFcLong( 0x0 ),	/* 0 */
/* 168 */	NdrFcShort( 0x7 ),	/* 7 */
/* 170 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 172 */	NdrFcShort( 0x0 ),	/* 0 */
/* 174 */	NdrFcShort( 0x8 ),	/* 8 */
/* 176 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 178 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 180 */	NdrFcShort( 0x0 ),	/* 0 */
/* 182 */	NdrFcShort( 0x0 ),	/* 0 */
/* 184 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter parameters */

/* 186 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 188 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 190 */	NdrFcShort( 0xa ),	/* Type Offset=10 */

	/* Return value */

/* 192 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 194 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 196 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Do */

/* 198 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 200 */	NdrFcLong( 0x0 ),	/* 0 */
/* 204 */	NdrFcShort( 0x8 ),	/* 8 */
/* 206 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 208 */	NdrFcShort( 0x0 ),	/* 0 */
/* 210 */	NdrFcShort( 0x8 ),	/* 8 */
/* 212 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 214 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 216 */	NdrFcShort( 0x0 ),	/* 0 */
/* 218 */	NdrFcShort( 0x0 ),	/* 0 */
/* 220 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter input */

/* 222 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 224 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 226 */	NdrFcShort( 0x1c ),	/* Type Offset=28 */

	/* Parameter output */

/* 228 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 230 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 232 */	NdrFcShort( 0x2e ),	/* Type Offset=46 */

	/* Return value */

/* 234 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 236 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 238 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetProgressBarInfo */

/* 240 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 242 */	NdrFcLong( 0x0 ),	/* 0 */
/* 246 */	NdrFcShort( 0x9 ),	/* 9 */
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
/* 282 */	NdrFcShort( 0xa ),	/* 10 */
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
/* 304 */	NdrFcShort( 0x1c ),	/* Type Offset=28 */

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

	/* Procedure SetEquations */


	/* Procedure Attach */

/* 318 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 320 */	NdrFcLong( 0x0 ),	/* 0 */
/* 324 */	NdrFcShort( 0x7 ),	/* 7 */
/* 326 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 328 */	NdrFcShort( 0x0 ),	/* 0 */
/* 330 */	NdrFcShort( 0x8 ),	/* 8 */
/* 332 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 334 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 336 */	NdrFcShort( 0x0 ),	/* 0 */
/* 338 */	NdrFcShort( 0x1 ),	/* 1 */
/* 340 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter equations */


	/* Parameter bstrPath */

/* 342 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 344 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 346 */	NdrFcShort( 0x5e ),	/* Type Offset=94 */

	/* Return value */


	/* Return value */

/* 348 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 350 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 352 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterAll */

/* 354 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 356 */	NdrFcLong( 0x0 ),	/* 0 */
/* 360 */	NdrFcShort( 0x9 ),	/* 9 */
/* 362 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 364 */	NdrFcShort( 0x0 ),	/* 0 */
/* 366 */	NdrFcShort( 0x8 ),	/* 8 */
/* 368 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 370 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 372 */	NdrFcShort( 0x0 ),	/* 0 */
/* 374 */	NdrFcShort( 0x0 ),	/* 0 */
/* 376 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 378 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 380 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 382 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetComponents */

/* 384 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 386 */	NdrFcLong( 0x0 ),	/* 0 */
/* 390 */	NdrFcShort( 0xa ),	/* 10 */
/* 392 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 394 */	NdrFcShort( 0x0 ),	/* 0 */
/* 396 */	NdrFcShort( 0x8 ),	/* 8 */
/* 398 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 400 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 402 */	NdrFcShort( 0x24 ),	/* 36 */
/* 404 */	NdrFcShort( 0x0 ),	/* 0 */
/* 406 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pbstrCLSIDs */

/* 408 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 410 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 412 */	NdrFcShort( 0x488 ),	/* Type Offset=1160 */

	/* Parameter pbstrDescriptions */

/* 414 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 416 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 418 */	NdrFcShort( 0x488 ),	/* Type Offset=1160 */

	/* Return value */

/* 420 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 422 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 424 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterComponent */

/* 426 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 428 */	NdrFcLong( 0x0 ),	/* 0 */
/* 432 */	NdrFcShort( 0xb ),	/* 11 */
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

	/* Parameter bstrCLSID */

/* 450 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 452 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 454 */	NdrFcShort( 0x5e ),	/* Type Offset=94 */

	/* Return value */

/* 456 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 458 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 460 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterComponent */

/* 462 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 464 */	NdrFcLong( 0x0 ),	/* 0 */
/* 468 */	NdrFcShort( 0xc ),	/* 12 */
/* 470 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 472 */	NdrFcShort( 0x0 ),	/* 0 */
/* 474 */	NdrFcShort( 0x8 ),	/* 8 */
/* 476 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 478 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 480 */	NdrFcShort( 0x0 ),	/* 0 */
/* 482 */	NdrFcShort( 0x1 ),	/* 1 */
/* 484 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 486 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 488 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 490 */	NdrFcShort( 0x5e ),	/* Type Offset=94 */

	/* Return value */

/* 492 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 494 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 496 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetEquations */

/* 498 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 500 */	NdrFcLong( 0x0 ),	/* 0 */
/* 504 */	NdrFcShort( 0x9 ),	/* 9 */
/* 506 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 508 */	NdrFcShort( 0x0 ),	/* 0 */
/* 510 */	NdrFcShort( 0x8 ),	/* 8 */
/* 512 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 514 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 516 */	NdrFcShort( 0x1 ),	/* 1 */
/* 518 */	NdrFcShort( 0x0 ),	/* 0 */
/* 520 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter equations */

/* 522 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 524 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 526 */	NdrFcShort( 0x496 ),	/* Type Offset=1174 */

	/* Return value */

/* 528 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 530 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 532 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetDimension */

/* 534 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 536 */	NdrFcLong( 0x0 ),	/* 0 */
/* 540 */	NdrFcShort( 0xa ),	/* 10 */
/* 542 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 544 */	NdrFcShort( 0x0 ),	/* 0 */
/* 546 */	NdrFcShort( 0x24 ),	/* 36 */
/* 548 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 550 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 552 */	NdrFcShort( 0x0 ),	/* 0 */
/* 554 */	NdrFcShort( 0x0 ),	/* 0 */
/* 556 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter dimenstion */

/* 558 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 560 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 562 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 564 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 566 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 568 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetIterations */

/* 570 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 572 */	NdrFcLong( 0x0 ),	/* 0 */
/* 576 */	NdrFcShort( 0xb ),	/* 11 */
/* 578 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 580 */	NdrFcShort( 0x0 ),	/* 0 */
/* 582 */	NdrFcShort( 0x24 ),	/* 36 */
/* 584 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 586 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 588 */	NdrFcShort( 0x0 ),	/* 0 */
/* 590 */	NdrFcShort( 0x0 ),	/* 0 */
/* 592 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter iterations */

/* 594 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 596 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 598 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 600 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 602 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 604 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetLastError */

/* 606 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 608 */	NdrFcLong( 0x0 ),	/* 0 */
/* 612 */	NdrFcShort( 0x8 ),	/* 8 */
/* 614 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 616 */	NdrFcShort( 0x0 ),	/* 0 */
/* 618 */	NdrFcShort( 0x8 ),	/* 8 */
/* 620 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 622 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 624 */	NdrFcShort( 0x1 ),	/* 1 */
/* 626 */	NdrFcShort( 0x0 ),	/* 0 */
/* 628 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter message */

/* 630 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 632 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 634 */	NdrFcShort( 0x496 ),	/* Type Offset=1174 */

	/* Return value */

/* 636 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 638 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 640 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetEdges */

/* 642 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 644 */	NdrFcLong( 0x0 ),	/* 0 */
/* 648 */	NdrFcShort( 0x8 ),	/* 8 */
/* 650 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 652 */	NdrFcShort( 0x0 ),	/* 0 */
/* 654 */	NdrFcShort( 0x24 ),	/* 36 */
/* 656 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 658 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 660 */	NdrFcShort( 0x0 ),	/* 0 */
/* 662 */	NdrFcShort( 0x0 ),	/* 0 */
/* 664 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 666 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 668 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 670 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 672 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 674 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 676 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetCount */


	/* Procedure GetDimension */

/* 678 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 680 */	NdrFcLong( 0x0 ),	/* 0 */
/* 684 */	NdrFcShort( 0x9 ),	/* 9 */
/* 686 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 688 */	NdrFcShort( 0x0 ),	/* 0 */
/* 690 */	NdrFcShort( 0x24 ),	/* 36 */
/* 692 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 694 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 696 */	NdrFcShort( 0x0 ),	/* 0 */
/* 698 */	NdrFcShort( 0x0 ),	/* 0 */
/* 700 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter count */


	/* Parameter value */

/* 702 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 704 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 706 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 708 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 710 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 712 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMinimum */

/* 714 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 716 */	NdrFcLong( 0x0 ),	/* 0 */
/* 720 */	NdrFcShort( 0xa ),	/* 10 */
/* 722 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 724 */	NdrFcShort( 0x8 ),	/* 8 */
/* 726 */	NdrFcShort( 0x2c ),	/* 44 */
/* 728 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 730 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 732 */	NdrFcShort( 0x0 ),	/* 0 */
/* 734 */	NdrFcShort( 0x0 ),	/* 0 */
/* 736 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 738 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 740 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 742 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 744 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 746 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 748 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 750 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 752 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 754 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMaximum */

/* 756 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 758 */	NdrFcLong( 0x0 ),	/* 0 */
/* 762 */	NdrFcShort( 0xb ),	/* 11 */
/* 764 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 766 */	NdrFcShort( 0x8 ),	/* 8 */
/* 768 */	NdrFcShort( 0x2c ),	/* 44 */
/* 770 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 772 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 774 */	NdrFcShort( 0x0 ),	/* 0 */
/* 776 */	NdrFcShort( 0x0 ),	/* 0 */
/* 778 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 780 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 782 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 784 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 786 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 788 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 790 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 792 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 794 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 796 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGridNumber */

/* 798 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 800 */	NdrFcLong( 0x0 ),	/* 0 */
/* 804 */	NdrFcShort( 0xc ),	/* 12 */
/* 806 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 808 */	NdrFcShort( 0x8 ),	/* 8 */
/* 810 */	NdrFcShort( 0x24 ),	/* 36 */
/* 812 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 814 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 816 */	NdrFcShort( 0x0 ),	/* 0 */
/* 818 */	NdrFcShort( 0x0 ),	/* 0 */
/* 820 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 822 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 824 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 826 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 828 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 830 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 832 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 834 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 836 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 838 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGridSize */

/* 840 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 842 */	NdrFcLong( 0x0 ),	/* 0 */
/* 846 */	NdrFcShort( 0xd ),	/* 13 */
/* 848 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 850 */	NdrFcShort( 0x8 ),	/* 8 */
/* 852 */	NdrFcShort( 0x2c ),	/* 44 */
/* 854 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 856 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 858 */	NdrFcShort( 0x0 ),	/* 0 */
/* 860 */	NdrFcShort( 0x0 ),	/* 0 */
/* 862 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 864 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 866 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 868 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 870 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 872 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 874 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 876 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 878 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 880 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AddResult */

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

	/* Parameter result */

/* 906 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 908 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 910 */	NdrFcShort( 0x4a4 ),	/* Type Offset=1188 */

	/* Return value */

/* 912 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 914 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 916 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CanAddResult */

/* 918 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 920 */	NdrFcLong( 0x0 ),	/* 0 */
/* 924 */	NdrFcShort( 0x8 ),	/* 8 */
/* 926 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 928 */	NdrFcShort( 0x0 ),	/* 0 */
/* 930 */	NdrFcShort( 0x22 ),	/* 34 */
/* 932 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 934 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 936 */	NdrFcShort( 0x0 ),	/* 0 */
/* 938 */	NdrFcShort( 0x0 ),	/* 0 */
/* 940 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 942 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 944 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 946 */	NdrFcShort( 0x4a4 ),	/* Type Offset=1188 */

	/* Parameter value */

/* 948 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 950 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 952 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 954 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 956 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 958 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateResult */

/* 960 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 962 */	NdrFcLong( 0x0 ),	/* 0 */
/* 966 */	NdrFcShort( 0x9 ),	/* 9 */
/* 968 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 970 */	NdrFcShort( 0x0 ),	/* 0 */
/* 972 */	NdrFcShort( 0x8 ),	/* 8 */
/* 974 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 976 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 978 */	NdrFcShort( 0x0 ),	/* 0 */
/* 980 */	NdrFcShort( 0x0 ),	/* 0 */
/* 982 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 984 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 986 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 988 */	NdrFcShort( 0x4b6 ),	/* Type Offset=1206 */

	/* Return value */

/* 990 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 992 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 994 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetResultMerger */

/* 996 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 998 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1002 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1004 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1006 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1008 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1010 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1012 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1014 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1016 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1018 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter merger */

/* 1020 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1022 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1024 */	NdrFcShort( 0x4ba ),	/* Type Offset=1210 */

	/* Return value */

/* 1026 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1028 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1030 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGraphInfo */

/* 1032 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1034 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1038 */	NdrFcShort( 0xa ),	/* 10 */
/* 1040 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1042 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1044 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1046 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1048 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1050 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1052 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1054 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter info */

/* 1056 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1058 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1060 */	NdrFcShort( 0x4d0 ),	/* Type Offset=1232 */

	/* Return value */

/* 1062 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1064 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1066 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGraphInfoAt */

/* 1068 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1070 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1074 */	NdrFcShort( 0xb ),	/* 11 */
/* 1076 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1078 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1080 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1082 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
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

	/* Parameter info */

/* 1098 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1100 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1102 */	NdrFcShort( 0x4d0 ),	/* Type Offset=1232 */

	/* Return value */

/* 1104 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1106 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1108 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure IsStrongComponent */

/* 1110 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1112 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1116 */	NdrFcShort( 0xc ),	/* 12 */
/* 1118 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1120 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1122 */	NdrFcShort( 0x22 ),	/* 34 */
/* 1124 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1126 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1128 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1130 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1132 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 1134 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1136 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1138 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 1140 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1142 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1144 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetFunction */

/* 1146 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1148 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1152 */	NdrFcShort( 0x7 ),	/* 7 */
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

	/* Parameter function */

/* 1170 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1172 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1174 */	NdrFcShort( 0x4e6 ),	/* Type Offset=1254 */

	/* Return value */

/* 1176 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1178 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1180 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateInitialResult */

/* 1182 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1184 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1188 */	NdrFcShort( 0x8 ),	/* 8 */
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

	/* Parameter result */

/* 1206 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1208 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1210 */	NdrFcShort( 0x4b6 ),	/* Type Offset=1206 */

	/* Return value */

/* 1212 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1214 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1216 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetFunction */

/* 1218 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1220 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1224 */	NdrFcShort( 0x7 ),	/* 7 */
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

	/* Parameter function */

/* 1242 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1244 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1246 */	NdrFcShort( 0x4ea ),	/* Type Offset=1258 */

	/* Return value */

/* 1248 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1250 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1252 */	0x8,		/* FC_LONG */
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
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 12 */	NdrFcLong( 0x16c62c7b ),	/* 382086267 */
/* 16 */	NdrFcShort( 0x6775 ),	/* 26485 */
/* 18 */	NdrFcShort( 0x4d2b ),	/* 19755 */
/* 20 */	0x9b,		/* 155 */
			0xd2,		/* 210 */
/* 22 */	0x43,		/* 67 */
			0x62,		/* 98 */
/* 24 */	0x4e,		/* 78 */
			0x1,		/* 1 */
/* 26 */	0x73,		/* 115 */
			0x8b,		/* 139 */
/* 28 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 30 */	NdrFcLong( 0x92f4eeef ),	/* -1829441809 */
/* 34 */	NdrFcShort( 0x602a ),	/* 24618 */
/* 36 */	NdrFcShort( 0x496d ),	/* 18797 */
/* 38 */	0x80,		/* 128 */
			0x67,		/* 103 */
/* 40 */	0x51,		/* 81 */
			0x84,		/* 132 */
/* 42 */	0xf4,		/* 244 */
			0xf1,		/* 241 */
/* 44 */	0xd3,		/* 211 */
			0x7b,		/* 123 */
/* 46 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 48 */	NdrFcShort( 0xffec ),	/* Offset= -20 (28) */
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
			0x12, 0x0,	/* FC_UP */
/* 70 */	NdrFcShort( 0xe ),	/* Offset= 14 (84) */
/* 72 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 74 */	NdrFcShort( 0x2 ),	/* 2 */
/* 76 */	0x9,		/* Corr desc: FC_ULONG */
			0x0,		/*  */
/* 78 */	NdrFcShort( 0xfffc ),	/* -4 */
/* 80 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 82 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 84 */	
			0x17,		/* FC_CSTRUCT */
			0x3,		/* 3 */
/* 86 */	NdrFcShort( 0x8 ),	/* 8 */
/* 88 */	NdrFcShort( 0xfff0 ),	/* Offset= -16 (72) */
/* 90 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 92 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 94 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 96 */	NdrFcShort( 0x0 ),	/* 0 */
/* 98 */	NdrFcShort( 0x4 ),	/* 4 */
/* 100 */	NdrFcShort( 0x0 ),	/* 0 */
/* 102 */	NdrFcShort( 0xffde ),	/* Offset= -34 (68) */
/* 104 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 106 */	NdrFcShort( 0x41e ),	/* Offset= 1054 (1160) */
/* 108 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 110 */	NdrFcShort( 0x2 ),	/* Offset= 2 (112) */
/* 112 */	
			0x13, 0x0,	/* FC_OP */
/* 114 */	NdrFcShort( 0x404 ),	/* Offset= 1028 (1142) */
/* 116 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x49,		/* 73 */
/* 118 */	NdrFcShort( 0x18 ),	/* 24 */
/* 120 */	NdrFcShort( 0xa ),	/* 10 */
/* 122 */	NdrFcLong( 0x8 ),	/* 8 */
/* 126 */	NdrFcShort( 0x5a ),	/* Offset= 90 (216) */
/* 128 */	NdrFcLong( 0xd ),	/* 13 */
/* 132 */	NdrFcShort( 0x90 ),	/* Offset= 144 (276) */
/* 134 */	NdrFcLong( 0x9 ),	/* 9 */
/* 138 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (332) */
/* 140 */	NdrFcLong( 0xc ),	/* 12 */
/* 144 */	NdrFcShort( 0x2d2 ),	/* Offset= 722 (866) */
/* 146 */	NdrFcLong( 0x24 ),	/* 36 */
/* 150 */	NdrFcShort( 0x2fc ),	/* Offset= 764 (914) */
/* 152 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 156 */	NdrFcShort( 0x32e ),	/* Offset= 814 (970) */
/* 158 */	NdrFcLong( 0x10 ),	/* 16 */
/* 162 */	NdrFcShort( 0x348 ),	/* Offset= 840 (1002) */
/* 164 */	NdrFcLong( 0x2 ),	/* 2 */
/* 168 */	NdrFcShort( 0x362 ),	/* Offset= 866 (1034) */
/* 170 */	NdrFcLong( 0x3 ),	/* 3 */
/* 174 */	NdrFcShort( 0x37c ),	/* Offset= 892 (1066) */
/* 176 */	NdrFcLong( 0x14 ),	/* 20 */
/* 180 */	NdrFcShort( 0x396 ),	/* Offset= 918 (1098) */
/* 182 */	NdrFcShort( 0xffff ),	/* Offset= -1 (181) */
/* 184 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 186 */	NdrFcShort( 0x4 ),	/* 4 */
/* 188 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 190 */	NdrFcShort( 0x0 ),	/* 0 */
/* 192 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 194 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 196 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 198 */	NdrFcShort( 0x4 ),	/* 4 */
/* 200 */	NdrFcShort( 0x0 ),	/* 0 */
/* 202 */	NdrFcShort( 0x1 ),	/* 1 */
/* 204 */	NdrFcShort( 0x0 ),	/* 0 */
/* 206 */	NdrFcShort( 0x0 ),	/* 0 */
/* 208 */	0x13, 0x0,	/* FC_OP */
/* 210 */	NdrFcShort( 0xff82 ),	/* Offset= -126 (84) */
/* 212 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 214 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 216 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 218 */	NdrFcShort( 0x8 ),	/* 8 */
/* 220 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 222 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 224 */	NdrFcShort( 0x4 ),	/* 4 */
/* 226 */	NdrFcShort( 0x4 ),	/* 4 */
/* 228 */	0x11, 0x0,	/* FC_RP */
/* 230 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (184) */
/* 232 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 234 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 236 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 238 */	NdrFcLong( 0x0 ),	/* 0 */
/* 242 */	NdrFcShort( 0x0 ),	/* 0 */
/* 244 */	NdrFcShort( 0x0 ),	/* 0 */
/* 246 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 248 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 250 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 252 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 254 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 256 */	NdrFcShort( 0x0 ),	/* 0 */
/* 258 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 260 */	NdrFcShort( 0x0 ),	/* 0 */
/* 262 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 264 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 268 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 270 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 272 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (236) */
/* 274 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 276 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 278 */	NdrFcShort( 0x8 ),	/* 8 */
/* 280 */	NdrFcShort( 0x0 ),	/* 0 */
/* 282 */	NdrFcShort( 0x6 ),	/* Offset= 6 (288) */
/* 284 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 286 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 288 */	
			0x11, 0x0,	/* FC_RP */
/* 290 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (254) */
/* 292 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 294 */	NdrFcLong( 0x20400 ),	/* 132096 */
/* 298 */	NdrFcShort( 0x0 ),	/* 0 */
/* 300 */	NdrFcShort( 0x0 ),	/* 0 */
/* 302 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 304 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 306 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 308 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 310 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 312 */	NdrFcShort( 0x0 ),	/* 0 */
/* 314 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 316 */	NdrFcShort( 0x0 ),	/* 0 */
/* 318 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 320 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 324 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 326 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 328 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (292) */
/* 330 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 332 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 334 */	NdrFcShort( 0x8 ),	/* 8 */
/* 336 */	NdrFcShort( 0x0 ),	/* 0 */
/* 338 */	NdrFcShort( 0x6 ),	/* Offset= 6 (344) */
/* 340 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 342 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 344 */	
			0x11, 0x0,	/* FC_RP */
/* 346 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (310) */
/* 348 */	
			0x2b,		/* FC_NON_ENCAPSULATED_UNION */
			0x9,		/* FC_ULONG */
/* 350 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 352 */	NdrFcShort( 0xfff8 ),	/* -8 */
/* 354 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 356 */	NdrFcShort( 0x2 ),	/* Offset= 2 (358) */
/* 358 */	NdrFcShort( 0x10 ),	/* 16 */
/* 360 */	NdrFcShort( 0x2f ),	/* 47 */
/* 362 */	NdrFcLong( 0x14 ),	/* 20 */
/* 366 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 368 */	NdrFcLong( 0x3 ),	/* 3 */
/* 372 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 374 */	NdrFcLong( 0x11 ),	/* 17 */
/* 378 */	NdrFcShort( 0x8001 ),	/* Simple arm type: FC_BYTE */
/* 380 */	NdrFcLong( 0x2 ),	/* 2 */
/* 384 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 386 */	NdrFcLong( 0x4 ),	/* 4 */
/* 390 */	NdrFcShort( 0x800a ),	/* Simple arm type: FC_FLOAT */
/* 392 */	NdrFcLong( 0x5 ),	/* 5 */
/* 396 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 398 */	NdrFcLong( 0xb ),	/* 11 */
/* 402 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 404 */	NdrFcLong( 0xa ),	/* 10 */
/* 408 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 410 */	NdrFcLong( 0x6 ),	/* 6 */
/* 414 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (646) */
/* 416 */	NdrFcLong( 0x7 ),	/* 7 */
/* 420 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 422 */	NdrFcLong( 0x8 ),	/* 8 */
/* 426 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (652) */
/* 428 */	NdrFcLong( 0xd ),	/* 13 */
/* 432 */	NdrFcShort( 0xe0 ),	/* Offset= 224 (656) */
/* 434 */	NdrFcLong( 0x9 ),	/* 9 */
/* 438 */	NdrFcShort( 0xff6e ),	/* Offset= -146 (292) */
/* 440 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 444 */	NdrFcShort( 0xe6 ),	/* Offset= 230 (674) */
/* 446 */	NdrFcLong( 0x24 ),	/* 36 */
/* 450 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (682) */
/* 452 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 456 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (682) */
/* 458 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 462 */	NdrFcShort( 0x112 ),	/* Offset= 274 (736) */
/* 464 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 468 */	NdrFcShort( 0x110 ),	/* Offset= 272 (740) */
/* 470 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 474 */	NdrFcShort( 0x10e ),	/* Offset= 270 (744) */
/* 476 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 480 */	NdrFcShort( 0x10c ),	/* Offset= 268 (748) */
/* 482 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 486 */	NdrFcShort( 0x10a ),	/* Offset= 266 (752) */
/* 488 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 492 */	NdrFcShort( 0x108 ),	/* Offset= 264 (756) */
/* 494 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 498 */	NdrFcShort( 0xf2 ),	/* Offset= 242 (740) */
/* 500 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 504 */	NdrFcShort( 0xf0 ),	/* Offset= 240 (744) */
/* 506 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 510 */	NdrFcShort( 0xfa ),	/* Offset= 250 (760) */
/* 512 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 516 */	NdrFcShort( 0xf0 ),	/* Offset= 240 (756) */
/* 518 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 522 */	NdrFcShort( 0xf2 ),	/* Offset= 242 (764) */
/* 524 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 528 */	NdrFcShort( 0xf0 ),	/* Offset= 240 (768) */
/* 530 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 534 */	NdrFcShort( 0xee ),	/* Offset= 238 (772) */
/* 536 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 540 */	NdrFcShort( 0xec ),	/* Offset= 236 (776) */
/* 542 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 546 */	NdrFcShort( 0xf2 ),	/* Offset= 242 (788) */
/* 548 */	NdrFcLong( 0x10 ),	/* 16 */
/* 552 */	NdrFcShort( 0x8002 ),	/* Simple arm type: FC_CHAR */
/* 554 */	NdrFcLong( 0x12 ),	/* 18 */
/* 558 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 560 */	NdrFcLong( 0x13 ),	/* 19 */
/* 564 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 566 */	NdrFcLong( 0x15 ),	/* 21 */
/* 570 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 572 */	NdrFcLong( 0x16 ),	/* 22 */
/* 576 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 578 */	NdrFcLong( 0x17 ),	/* 23 */
/* 582 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 584 */	NdrFcLong( 0xe ),	/* 14 */
/* 588 */	NdrFcShort( 0xd0 ),	/* Offset= 208 (796) */
/* 590 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 594 */	NdrFcShort( 0xd4 ),	/* Offset= 212 (806) */
/* 596 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 600 */	NdrFcShort( 0xd2 ),	/* Offset= 210 (810) */
/* 602 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 606 */	NdrFcShort( 0x86 ),	/* Offset= 134 (740) */
/* 608 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 612 */	NdrFcShort( 0x84 ),	/* Offset= 132 (744) */
/* 614 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 618 */	NdrFcShort( 0x82 ),	/* Offset= 130 (748) */
/* 620 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 624 */	NdrFcShort( 0x78 ),	/* Offset= 120 (744) */
/* 626 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 630 */	NdrFcShort( 0x72 ),	/* Offset= 114 (744) */
/* 632 */	NdrFcLong( 0x0 ),	/* 0 */
/* 636 */	NdrFcShort( 0x0 ),	/* Offset= 0 (636) */
/* 638 */	NdrFcLong( 0x1 ),	/* 1 */
/* 642 */	NdrFcShort( 0x0 ),	/* Offset= 0 (642) */
/* 644 */	NdrFcShort( 0xffff ),	/* Offset= -1 (643) */
/* 646 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 648 */	NdrFcShort( 0x8 ),	/* 8 */
/* 650 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 652 */	
			0x13, 0x0,	/* FC_OP */
/* 654 */	NdrFcShort( 0xfdc6 ),	/* Offset= -570 (84) */
/* 656 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 658 */	NdrFcLong( 0x0 ),	/* 0 */
/* 662 */	NdrFcShort( 0x0 ),	/* 0 */
/* 664 */	NdrFcShort( 0x0 ),	/* 0 */
/* 666 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 668 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 670 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 672 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 674 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 676 */	NdrFcShort( 0x2 ),	/* Offset= 2 (678) */
/* 678 */	
			0x13, 0x0,	/* FC_OP */
/* 680 */	NdrFcShort( 0x1ce ),	/* Offset= 462 (1142) */
/* 682 */	
			0x13, 0x0,	/* FC_OP */
/* 684 */	NdrFcShort( 0x20 ),	/* Offset= 32 (716) */
/* 686 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 688 */	NdrFcLong( 0x2f ),	/* 47 */
/* 692 */	NdrFcShort( 0x0 ),	/* 0 */
/* 694 */	NdrFcShort( 0x0 ),	/* 0 */
/* 696 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 698 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 700 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 702 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 704 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 706 */	NdrFcShort( 0x1 ),	/* 1 */
/* 708 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 710 */	NdrFcShort( 0x4 ),	/* 4 */
/* 712 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 714 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 716 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 718 */	NdrFcShort( 0x10 ),	/* 16 */
/* 720 */	NdrFcShort( 0x0 ),	/* 0 */
/* 722 */	NdrFcShort( 0xa ),	/* Offset= 10 (732) */
/* 724 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 726 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 728 */	NdrFcShort( 0xffd6 ),	/* Offset= -42 (686) */
/* 730 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 732 */	
			0x13, 0x0,	/* FC_OP */
/* 734 */	NdrFcShort( 0xffe2 ),	/* Offset= -30 (704) */
/* 736 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 738 */	0x1,		/* FC_BYTE */
			0x5c,		/* FC_PAD */
/* 740 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 742 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 744 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 746 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 748 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 750 */	0xb,		/* FC_HYPER */
			0x5c,		/* FC_PAD */
/* 752 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 754 */	0xa,		/* FC_FLOAT */
			0x5c,		/* FC_PAD */
/* 756 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 758 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 760 */	
			0x13, 0x0,	/* FC_OP */
/* 762 */	NdrFcShort( 0xff8c ),	/* Offset= -116 (646) */
/* 764 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 766 */	NdrFcShort( 0xff8e ),	/* Offset= -114 (652) */
/* 768 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 770 */	NdrFcShort( 0xff8e ),	/* Offset= -114 (656) */
/* 772 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 774 */	NdrFcShort( 0xfe1e ),	/* Offset= -482 (292) */
/* 776 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 778 */	NdrFcShort( 0x2 ),	/* Offset= 2 (780) */
/* 780 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 782 */	NdrFcShort( 0x2 ),	/* Offset= 2 (784) */
/* 784 */	
			0x13, 0x0,	/* FC_OP */
/* 786 */	NdrFcShort( 0x164 ),	/* Offset= 356 (1142) */
/* 788 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 790 */	NdrFcShort( 0x2 ),	/* Offset= 2 (792) */
/* 792 */	
			0x13, 0x0,	/* FC_OP */
/* 794 */	NdrFcShort( 0x14 ),	/* Offset= 20 (814) */
/* 796 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 798 */	NdrFcShort( 0x10 ),	/* 16 */
/* 800 */	0x6,		/* FC_SHORT */
			0x1,		/* FC_BYTE */
/* 802 */	0x1,		/* FC_BYTE */
			0x8,		/* FC_LONG */
/* 804 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 806 */	
			0x13, 0x0,	/* FC_OP */
/* 808 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (796) */
/* 810 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 812 */	0x2,		/* FC_CHAR */
			0x5c,		/* FC_PAD */
/* 814 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x7,		/* 7 */
/* 816 */	NdrFcShort( 0x20 ),	/* 32 */
/* 818 */	NdrFcShort( 0x0 ),	/* 0 */
/* 820 */	NdrFcShort( 0x0 ),	/* Offset= 0 (820) */
/* 822 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 824 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 826 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 828 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 830 */	NdrFcShort( 0xfe1e ),	/* Offset= -482 (348) */
/* 832 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 834 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 836 */	NdrFcShort( 0x4 ),	/* 4 */
/* 838 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 840 */	NdrFcShort( 0x0 ),	/* 0 */
/* 842 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 844 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 846 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 848 */	NdrFcShort( 0x4 ),	/* 4 */
/* 850 */	NdrFcShort( 0x0 ),	/* 0 */
/* 852 */	NdrFcShort( 0x1 ),	/* 1 */
/* 854 */	NdrFcShort( 0x0 ),	/* 0 */
/* 856 */	NdrFcShort( 0x0 ),	/* 0 */
/* 858 */	0x13, 0x0,	/* FC_OP */
/* 860 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (814) */
/* 862 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 864 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 866 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 868 */	NdrFcShort( 0x8 ),	/* 8 */
/* 870 */	NdrFcShort( 0x0 ),	/* 0 */
/* 872 */	NdrFcShort( 0x6 ),	/* Offset= 6 (878) */
/* 874 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 876 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 878 */	
			0x11, 0x0,	/* FC_RP */
/* 880 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (834) */
/* 882 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 884 */	NdrFcShort( 0x4 ),	/* 4 */
/* 886 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 888 */	NdrFcShort( 0x0 ),	/* 0 */
/* 890 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 892 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 894 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 896 */	NdrFcShort( 0x4 ),	/* 4 */
/* 898 */	NdrFcShort( 0x0 ),	/* 0 */
/* 900 */	NdrFcShort( 0x1 ),	/* 1 */
/* 902 */	NdrFcShort( 0x0 ),	/* 0 */
/* 904 */	NdrFcShort( 0x0 ),	/* 0 */
/* 906 */	0x13, 0x0,	/* FC_OP */
/* 908 */	NdrFcShort( 0xff40 ),	/* Offset= -192 (716) */
/* 910 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 912 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 914 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 916 */	NdrFcShort( 0x8 ),	/* 8 */
/* 918 */	NdrFcShort( 0x0 ),	/* 0 */
/* 920 */	NdrFcShort( 0x6 ),	/* Offset= 6 (926) */
/* 922 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 924 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 926 */	
			0x11, 0x0,	/* FC_RP */
/* 928 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (882) */
/* 930 */	
			0x1d,		/* FC_SMFARRAY */
			0x0,		/* 0 */
/* 932 */	NdrFcShort( 0x8 ),	/* 8 */
/* 934 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 936 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 938 */	NdrFcShort( 0x10 ),	/* 16 */
/* 940 */	0x8,		/* FC_LONG */
			0x6,		/* FC_SHORT */
/* 942 */	0x6,		/* FC_SHORT */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 944 */	0x0,		/* 0 */
			NdrFcShort( 0xfff1 ),	/* Offset= -15 (930) */
			0x5b,		/* FC_END */
/* 948 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 950 */	NdrFcShort( 0x0 ),	/* 0 */
/* 952 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 954 */	NdrFcShort( 0x0 ),	/* 0 */
/* 956 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 958 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 962 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 964 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 966 */	NdrFcShort( 0xfeca ),	/* Offset= -310 (656) */
/* 968 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 970 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 972 */	NdrFcShort( 0x18 ),	/* 24 */
/* 974 */	NdrFcShort( 0x0 ),	/* 0 */
/* 976 */	NdrFcShort( 0xa ),	/* Offset= 10 (986) */
/* 978 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 980 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 982 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (936) */
/* 984 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 986 */	
			0x11, 0x0,	/* FC_RP */
/* 988 */	NdrFcShort( 0xffd8 ),	/* Offset= -40 (948) */
/* 990 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 992 */	NdrFcShort( 0x1 ),	/* 1 */
/* 994 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 996 */	NdrFcShort( 0x0 ),	/* 0 */
/* 998 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1000 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1002 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1004 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1006 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1008 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1010 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1012 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1014 */	0x13, 0x0,	/* FC_OP */
/* 1016 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (990) */
/* 1018 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1020 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1022 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 1024 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1026 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1028 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1030 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1032 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 1034 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1036 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1038 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1040 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1042 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1044 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1046 */	0x13, 0x0,	/* FC_OP */
/* 1048 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1022) */
/* 1050 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1052 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1054 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1056 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1058 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1060 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1062 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1064 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1066 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1068 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1070 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1072 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1074 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1076 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1078 */	0x13, 0x0,	/* FC_OP */
/* 1080 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1054) */
/* 1082 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1084 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1086 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 1088 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1090 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1092 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1094 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1096 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 1098 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1100 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1102 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1104 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1106 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1108 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1110 */	0x13, 0x0,	/* FC_OP */
/* 1112 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1086) */
/* 1114 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1116 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1118 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1120 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1122 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1124 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1126 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1128 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1130 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 1132 */	NdrFcShort( 0xffd8 ),	/* -40 */
/* 1134 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1136 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1138 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1118) */
/* 1140 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1142 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1144 */	NdrFcShort( 0x28 ),	/* 40 */
/* 1146 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1126) */
/* 1148 */	NdrFcShort( 0x0 ),	/* Offset= 0 (1148) */
/* 1150 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1152 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1154 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1156 */	NdrFcShort( 0xfbf0 ),	/* Offset= -1040 (116) */
/* 1158 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1160 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1162 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1164 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1166 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1168 */	NdrFcShort( 0xfbdc ),	/* Offset= -1060 (108) */
/* 1170 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 1172 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1174) */
/* 1174 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1176 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1178 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1180 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1182 */	NdrFcShort( 0xfdee ),	/* Offset= -530 (652) */
/* 1184 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 1186 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 1188 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1190 */	NdrFcLong( 0x92f4eeef ),	/* -1829441809 */
/* 1194 */	NdrFcShort( 0x602a ),	/* 24618 */
/* 1196 */	NdrFcShort( 0x496d ),	/* 18797 */
/* 1198 */	0x80,		/* 128 */
			0x67,		/* 103 */
/* 1200 */	0x51,		/* 81 */
			0x84,		/* 132 */
/* 1202 */	0xf4,		/* 244 */
			0xf1,		/* 241 */
/* 1204 */	0xd3,		/* 211 */
			0x7b,		/* 123 */
/* 1206 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1208 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1188) */
/* 1210 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1212 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1214) */
/* 1214 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1216 */	NdrFcLong( 0x4d5b2a01 ),	/* 1297820161 */
/* 1220 */	NdrFcShort( 0x1cc2 ),	/* 7362 */
/* 1222 */	NdrFcShort( 0x4d56 ),	/* 19798 */
/* 1224 */	0xa8,		/* 168 */
			0xd7,		/* 215 */
/* 1226 */	0x67,		/* 103 */
			0xc7,		/* 199 */
/* 1228 */	0x30,		/* 48 */
			0xa0,		/* 160 */
/* 1230 */	0x57,		/* 87 */
			0xed,		/* 237 */
/* 1232 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1234 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1236) */
/* 1236 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1238 */	NdrFcLong( 0x641c669 ),	/* 104973929 */
/* 1242 */	NdrFcShort( 0xb362 ),	/* -19614 */
/* 1244 */	NdrFcShort( 0x48c9 ),	/* 18633 */
/* 1246 */	0x8b,		/* 139 */
			0x73,		/* 115 */
/* 1248 */	0xd0,		/* 208 */
			0x2b,		/* 43 */
/* 1250 */	0x6e,		/* 110 */
			0x25,		/* 37 */
/* 1252 */	0x2a,		/* 42 */
			0x9d,		/* 157 */
/* 1254 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1256 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1258) */
/* 1258 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1260 */	NdrFcLong( 0x63b946e2 ),	/* 1673086690 */
/* 1264 */	NdrFcShort( 0x2aee ),	/* 10990 */
/* 1266 */	NdrFcShort( 0x4034 ),	/* 16436 */
/* 1268 */	0xba,		/* 186 */
			0x1c,		/* 28 */
/* 1270 */	0x1b,		/* 27 */
			0x4c,		/* 76 */
/* 1272 */	0xfd,		/* 253 */
			0x68,		/* 104 */
/* 1274 */	0xce,		/* 206 */
			0xc0,		/* 192 */

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


/* Object interface: IAction, ver. 0.0,
   GUID={0xB94E10D8,0x08BD,0x405C,{0xA4,0x35,0x08,0x68,0xDD,0x86,0xCD,0x3C}} */

#pragma code_seg(".orpc")
static const unsigned short IAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    162,
    198,
    240,
    276
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
    (void *) (INT_PTR) -1 /* IAction::Do */ ,
    (void *) (INT_PTR) -1 /* IAction::SetProgressBarInfo */ ,
    (void *) (INT_PTR) -1 /* IAction::CanDo */
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


/* Object interface: IComponentRegistrar, ver. 0.0,
   GUID={0xa817e7a2,0x43fa,0x11d0,{0x9e,0x44,0x00,0xaa,0x00,0xb6,0x77,0x0a}} */

#pragma code_seg(".orpc")
static const unsigned short IComponentRegistrar_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    318,
    36,
    354,
    384,
    426,
    462
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
    498,
    534,
    570,
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
    0 /* (void *) (INT_PTR) -1 /* IFunction::GetSystemFunction */ ,
    0 /* (void *) (INT_PTR) -1 /* IFunction::GetSystemFunctionDerivate */ ,
    (void *) (INT_PTR) -1 /* IFunction::GetEquations */ ,
    (void *) (INT_PTR) -1 /* IFunction::GetDimension */ ,
    (void *) (INT_PTR) -1 /* IFunction::GetIterations */ ,
    0 /* (void *) (INT_PTR) -1 /* IFunction::CreateGraph */
};


static const PRPC_STUB_FUNCTION IFunction_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
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


/* Object interface: IWritableFunction, ver. 0.0,
   GUID={0x9B3DA2D8,0xE279,0x4552,{0x99,0xF4,0x13,0xAA,0x06,0x66,0x42,0xD5}} */

#pragma code_seg(".orpc")
static const unsigned short IWritableFunction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    318,
    606
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
    642,
    678,
    714,
    756,
    798,
    840
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


/* Object interface: IResultMerger, ver. 0.0,
   GUID={0x4D5B2A01,0x1CC2,0x4D56,{0xA8,0xD7,0x67,0xC7,0x30,0xA0,0x57,0xED}} */

#pragma code_seg(".orpc")
static const unsigned short IResultMerger_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    882,
    918,
    960
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
    996
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


/* Object interface: IGraphResult, ver. 0.0,
   GUID={0x6E606370,0x04E2,0x4BCB,{0x85,0x2C,0x31,0x3A,0x7D,0x4B,0xAD,0x15}} */

#pragma code_seg(".orpc")
static const unsigned short IGraphResult_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    996,
    (unsigned short) -1,
    678,
    1032,
    1068,
    1110
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


/* Object interface: IKernell, ver. 0.0,
   GUID={0xF2D78B39,0xD782,0x49DE,{0x91,0xB7,0x77,0x1C,0xDA,0x2E,0xD0,0xE0}} */

#pragma code_seg(".orpc")
static const unsigned short IKernell_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1146,
    1182
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
    (void *) (INT_PTR) -1 /* IKernell::CreateInitialResult */
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
    1218
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
    ( CInterfaceProxyVtbl *) &_IKernellProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComponentRegistrarProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableKernellProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableFunctionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionBaseProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProgressBarInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IFunctionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultBaseProxyVtbl,
    0
};

const CInterfaceStubVtbl * __MorseKernel2_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_IResultMergerStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernellStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IComponentRegistrarStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableKernellStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableFunctionStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionBaseStubVtbl,
    ( CInterfaceStubVtbl *) &_IProgressBarInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IFunctionStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultBaseStubVtbl,
    0
};

PCInterfaceName const __MorseKernel2_InterfaceNamesList[] = 
{
    "IResultMerger",
    "IKernell",
    "IGraphInfo",
    "IGraphResult",
    "IParameters",
    "IComponentRegistrar",
    "IResult",
    "IWritableKernell",
    "IAction",
    "IWritableFunction",
    "IActionBase",
    "IProgressBarInfo",
    "IFunction",
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

