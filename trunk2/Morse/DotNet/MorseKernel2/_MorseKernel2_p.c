

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Tue Mar 15 00:45:26 2005
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

#define TYPE_FORMAT_STRING_SIZE   1255                              
#define PROC_FORMAT_STRING_SIZE   1333                              
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


extern const MIDL_SERVER_INFO IFunction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IFunction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IComputationParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComputationParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IBoxMethodAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IBoxMethodAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IBoxMethodParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IBoxMethodParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResultMerger_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResultMerger_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResult_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResult_ProxyInfo;


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


extern const MIDL_SERVER_INFO IComponentRegistrar_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IComponentRegistrar_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IDummy_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IDummy_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableFunction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableFunction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernell_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernell_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableKernell_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableKernell_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ITarjanAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ITarjanAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ITarjanParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ITarjanParameters_ProxyInfo;


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

	/* Procedure GetEquations */

/* 318 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 320 */	NdrFcLong( 0x0 ),	/* 0 */
/* 324 */	NdrFcShort( 0x9 ),	/* 9 */
/* 326 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 328 */	NdrFcShort( 0x0 ),	/* 0 */
/* 330 */	NdrFcShort( 0x8 ),	/* 8 */
/* 332 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 334 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 336 */	NdrFcShort( 0x1 ),	/* 1 */
/* 338 */	NdrFcShort( 0x0 ),	/* 0 */
/* 340 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter equations */

/* 342 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 344 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 346 */	NdrFcShort( 0x62 ),	/* Type Offset=98 */

	/* Return value */

/* 348 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 350 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 352 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetDimension */

/* 354 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 356 */	NdrFcLong( 0x0 ),	/* 0 */
/* 360 */	NdrFcShort( 0xa ),	/* 10 */
/* 362 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 364 */	NdrFcShort( 0x0 ),	/* 0 */
/* 366 */	NdrFcShort( 0x24 ),	/* 36 */
/* 368 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 370 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 372 */	NdrFcShort( 0x0 ),	/* 0 */
/* 374 */	NdrFcShort( 0x0 ),	/* 0 */
/* 376 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter dimenstion */

/* 378 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 380 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 382 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 384 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 386 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 388 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetIterations */

/* 390 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 392 */	NdrFcLong( 0x0 ),	/* 0 */
/* 396 */	NdrFcShort( 0xb ),	/* 11 */
/* 398 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 400 */	NdrFcShort( 0x0 ),	/* 0 */
/* 402 */	NdrFcShort( 0x24 ),	/* 36 */
/* 404 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 406 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 408 */	NdrFcShort( 0x0 ),	/* 0 */
/* 410 */	NdrFcShort( 0x0 ),	/* 0 */
/* 412 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter iterations */

/* 414 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 416 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 418 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 420 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 422 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 424 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetFunction */


	/* Procedure GetFunction */

/* 426 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 428 */	NdrFcLong( 0x0 ),	/* 0 */
/* 432 */	NdrFcShort( 0x7 ),	/* 7 */
/* 434 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 436 */	NdrFcShort( 0x0 ),	/* 0 */
/* 438 */	NdrFcShort( 0x8 ),	/* 8 */
/* 440 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 442 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 444 */	NdrFcShort( 0x0 ),	/* 0 */
/* 446 */	NdrFcShort( 0x0 ),	/* 0 */
/* 448 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter function */


	/* Parameter function */

/* 450 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 452 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 454 */	NdrFcShort( 0x6c ),	/* Type Offset=108 */

	/* Return value */


	/* Return value */

/* 456 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 458 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 460 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetFactor */

/* 462 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 464 */	NdrFcLong( 0x0 ),	/* 0 */
/* 468 */	NdrFcShort( 0x8 ),	/* 8 */
/* 470 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 472 */	NdrFcShort( 0x8 ),	/* 8 */
/* 474 */	NdrFcShort( 0x24 ),	/* 36 */
/* 476 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 478 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 480 */	NdrFcShort( 0x0 ),	/* 0 */
/* 482 */	NdrFcShort( 0x0 ),	/* 0 */
/* 484 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 486 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 488 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 490 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter factor */

/* 492 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 494 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 496 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 498 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 500 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 502 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AddResult */

/* 504 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 506 */	NdrFcLong( 0x0 ),	/* 0 */
/* 510 */	NdrFcShort( 0x7 ),	/* 7 */
/* 512 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 514 */	NdrFcShort( 0x0 ),	/* 0 */
/* 516 */	NdrFcShort( 0x8 ),	/* 8 */
/* 518 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 520 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 522 */	NdrFcShort( 0x0 ),	/* 0 */
/* 524 */	NdrFcShort( 0x0 ),	/* 0 */
/* 526 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 528 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 530 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 532 */	NdrFcShort( 0x1c ),	/* Type Offset=28 */

	/* Return value */

/* 534 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 536 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 538 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CanAddResult */

/* 540 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 542 */	NdrFcLong( 0x0 ),	/* 0 */
/* 546 */	NdrFcShort( 0x8 ),	/* 8 */
/* 548 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 550 */	NdrFcShort( 0x0 ),	/* 0 */
/* 552 */	NdrFcShort( 0x22 ),	/* 34 */
/* 554 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 556 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 558 */	NdrFcShort( 0x0 ),	/* 0 */
/* 560 */	NdrFcShort( 0x0 ),	/* 0 */
/* 562 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 564 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 566 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 568 */	NdrFcShort( 0x1c ),	/* Type Offset=28 */

	/* Parameter value */

/* 570 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 572 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 574 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 576 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 578 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 580 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateResult */

/* 582 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 584 */	NdrFcLong( 0x0 ),	/* 0 */
/* 588 */	NdrFcShort( 0x9 ),	/* 9 */
/* 590 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 592 */	NdrFcShort( 0x0 ),	/* 0 */
/* 594 */	NdrFcShort( 0x8 ),	/* 8 */
/* 596 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 598 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 600 */	NdrFcShort( 0x0 ),	/* 0 */
/* 602 */	NdrFcShort( 0x0 ),	/* 0 */
/* 604 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 606 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 608 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 610 */	NdrFcShort( 0x2e ),	/* Type Offset=46 */

	/* Return value */

/* 612 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 614 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 616 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetResultMerger */

/* 618 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 620 */	NdrFcLong( 0x0 ),	/* 0 */
/* 624 */	NdrFcShort( 0x7 ),	/* 7 */
/* 626 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 628 */	NdrFcShort( 0x0 ),	/* 0 */
/* 630 */	NdrFcShort( 0x8 ),	/* 8 */
/* 632 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 634 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 636 */	NdrFcShort( 0x0 ),	/* 0 */
/* 638 */	NdrFcShort( 0x0 ),	/* 0 */
/* 640 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter merger */

/* 642 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 644 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 646 */	NdrFcShort( 0x82 ),	/* Type Offset=130 */

	/* Return value */

/* 648 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 650 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 652 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetEdges */

/* 654 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 656 */	NdrFcLong( 0x0 ),	/* 0 */
/* 660 */	NdrFcShort( 0x8 ),	/* 8 */
/* 662 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 664 */	NdrFcShort( 0x0 ),	/* 0 */
/* 666 */	NdrFcShort( 0x24 ),	/* 36 */
/* 668 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 670 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 672 */	NdrFcShort( 0x0 ),	/* 0 */
/* 674 */	NdrFcShort( 0x0 ),	/* 0 */
/* 676 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 678 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 680 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 682 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 684 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 686 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 688 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetCount */


	/* Procedure GetDimension */

/* 690 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 692 */	NdrFcLong( 0x0 ),	/* 0 */
/* 696 */	NdrFcShort( 0x9 ),	/* 9 */
/* 698 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 700 */	NdrFcShort( 0x0 ),	/* 0 */
/* 702 */	NdrFcShort( 0x24 ),	/* 36 */
/* 704 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 706 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 708 */	NdrFcShort( 0x0 ),	/* 0 */
/* 710 */	NdrFcShort( 0x0 ),	/* 0 */
/* 712 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter count */


	/* Parameter value */

/* 714 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 716 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 718 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 720 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 722 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 724 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMinimum */

/* 726 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 728 */	NdrFcLong( 0x0 ),	/* 0 */
/* 732 */	NdrFcShort( 0xa ),	/* 10 */
/* 734 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 736 */	NdrFcShort( 0x8 ),	/* 8 */
/* 738 */	NdrFcShort( 0x2c ),	/* 44 */
/* 740 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 742 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 744 */	NdrFcShort( 0x0 ),	/* 0 */
/* 746 */	NdrFcShort( 0x0 ),	/* 0 */
/* 748 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 750 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 752 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 754 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 756 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 758 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 760 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 762 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 764 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 766 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMaximum */

/* 768 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 770 */	NdrFcLong( 0x0 ),	/* 0 */
/* 774 */	NdrFcShort( 0xb ),	/* 11 */
/* 776 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 778 */	NdrFcShort( 0x8 ),	/* 8 */
/* 780 */	NdrFcShort( 0x2c ),	/* 44 */
/* 782 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 784 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 786 */	NdrFcShort( 0x0 ),	/* 0 */
/* 788 */	NdrFcShort( 0x0 ),	/* 0 */
/* 790 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 792 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 794 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 796 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 798 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 800 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 802 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 804 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 806 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 808 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGridNumber */

/* 810 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 812 */	NdrFcLong( 0x0 ),	/* 0 */
/* 816 */	NdrFcShort( 0xc ),	/* 12 */
/* 818 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 820 */	NdrFcShort( 0x8 ),	/* 8 */
/* 822 */	NdrFcShort( 0x24 ),	/* 36 */
/* 824 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 826 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 828 */	NdrFcShort( 0x0 ),	/* 0 */
/* 830 */	NdrFcShort( 0x0 ),	/* 0 */
/* 832 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 834 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 836 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 838 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 840 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 842 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 844 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 846 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 848 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 850 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGridSize */

/* 852 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 854 */	NdrFcLong( 0x0 ),	/* 0 */
/* 858 */	NdrFcShort( 0xd ),	/* 13 */
/* 860 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 862 */	NdrFcShort( 0x8 ),	/* 8 */
/* 864 */	NdrFcShort( 0x2c ),	/* 44 */
/* 866 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 868 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 870 */	NdrFcShort( 0x0 ),	/* 0 */
/* 872 */	NdrFcShort( 0x0 ),	/* 0 */
/* 874 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 876 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 878 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 880 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 882 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 884 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 886 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 888 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 890 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 892 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGraphInfo */

/* 894 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 896 */	NdrFcLong( 0x0 ),	/* 0 */
/* 900 */	NdrFcShort( 0xa ),	/* 10 */
/* 902 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 904 */	NdrFcShort( 0x0 ),	/* 0 */
/* 906 */	NdrFcShort( 0x8 ),	/* 8 */
/* 908 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 910 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 912 */	NdrFcShort( 0x0 ),	/* 0 */
/* 914 */	NdrFcShort( 0x0 ),	/* 0 */
/* 916 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter info */

/* 918 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 920 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 922 */	NdrFcShort( 0x9c ),	/* Type Offset=156 */

	/* Return value */

/* 924 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 926 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 928 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGraphInfoAt */

/* 930 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 932 */	NdrFcLong( 0x0 ),	/* 0 */
/* 936 */	NdrFcShort( 0xb ),	/* 11 */
/* 938 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 940 */	NdrFcShort( 0x8 ),	/* 8 */
/* 942 */	NdrFcShort( 0x8 ),	/* 8 */
/* 944 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 946 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 948 */	NdrFcShort( 0x0 ),	/* 0 */
/* 950 */	NdrFcShort( 0x0 ),	/* 0 */
/* 952 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 954 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 956 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 958 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter info */

/* 960 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 962 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 964 */	NdrFcShort( 0x9c ),	/* Type Offset=156 */

	/* Return value */

/* 966 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 968 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 970 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure IsStrongComponent */

/* 972 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 974 */	NdrFcLong( 0x0 ),	/* 0 */
/* 978 */	NdrFcShort( 0xc ),	/* 12 */
/* 980 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 982 */	NdrFcShort( 0x0 ),	/* 0 */
/* 984 */	NdrFcShort( 0x22 ),	/* 34 */
/* 986 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 988 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 990 */	NdrFcShort( 0x0 ),	/* 0 */
/* 992 */	NdrFcShort( 0x0 ),	/* 0 */
/* 994 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 996 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 998 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1000 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 1002 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1004 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1006 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetEquations */


	/* Procedure Attach */

/* 1008 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1010 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1014 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1016 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1018 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1020 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1022 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1024 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1026 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1028 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1030 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter equations */


	/* Parameter bstrPath */

/* 1032 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1034 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1036 */	NdrFcShort( 0xb6 ),	/* Type Offset=182 */

	/* Return value */


	/* Return value */

/* 1038 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1040 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1042 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterAll */

/* 1044 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1046 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1050 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1052 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1054 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1056 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1058 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 1060 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1062 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1064 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1066 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 1068 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1070 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1072 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetComponents */

/* 1074 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1076 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1080 */	NdrFcShort( 0xa ),	/* 10 */
/* 1082 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1084 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1086 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1088 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 1090 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 1092 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1094 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1096 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pbstrCLSIDs */

/* 1098 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1100 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1102 */	NdrFcShort( 0x4dc ),	/* Type Offset=1244 */

	/* Parameter pbstrDescriptions */

/* 1104 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1106 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1108 */	NdrFcShort( 0x4dc ),	/* Type Offset=1244 */

	/* Return value */

/* 1110 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1112 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1114 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterComponent */

/* 1116 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1118 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1122 */	NdrFcShort( 0xb ),	/* 11 */
/* 1124 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1126 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1128 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1130 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1132 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1134 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1136 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1138 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 1140 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1142 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1144 */	NdrFcShort( 0xb6 ),	/* Type Offset=182 */

	/* Return value */

/* 1146 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1148 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1150 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterComponent */

/* 1152 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1154 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1158 */	NdrFcShort( 0xc ),	/* 12 */
/* 1160 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1162 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1164 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1166 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1168 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1170 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1172 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1174 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */

/* 1176 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1178 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1180 */	NdrFcShort( 0xb6 ),	/* Type Offset=182 */

	/* Return value */

/* 1182 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1184 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1186 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetLastError */

/* 1188 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1190 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1194 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1196 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1198 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1200 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1202 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1204 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 1206 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1208 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1210 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter message */

/* 1212 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1214 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1216 */	NdrFcShort( 0x62 ),	/* Type Offset=98 */

	/* Return value */

/* 1218 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1220 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1222 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateInitialResult */

/* 1224 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1226 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1230 */	NdrFcShort( 0x8 ),	/* 8 */
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

	/* Parameter result */

/* 1248 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1250 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1252 */	NdrFcShort( 0x2e ),	/* Type Offset=46 */

	/* Return value */

/* 1254 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1256 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1258 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetFunction */

/* 1260 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1262 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1266 */	NdrFcShort( 0x7 ),	/* 7 */
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

	/* Parameter function */

/* 1284 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1286 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1288 */	NdrFcShort( 0x70 ),	/* Type Offset=112 */

	/* Return value */

/* 1290 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1292 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1294 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure NeedEdgeResolve */

/* 1296 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1298 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1302 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1304 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1306 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1308 */	NdrFcShort( 0x22 ),	/* 34 */
/* 1310 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1312 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1314 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1316 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1318 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 1320 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1322 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1324 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 1326 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1328 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1330 */	0x8,		/* FC_LONG */
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
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 70 */	NdrFcShort( 0x1c ),	/* Offset= 28 (98) */
/* 72 */	
			0x13, 0x0,	/* FC_OP */
/* 74 */	NdrFcShort( 0xe ),	/* Offset= 14 (88) */
/* 76 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 78 */	NdrFcShort( 0x2 ),	/* 2 */
/* 80 */	0x9,		/* Corr desc: FC_ULONG */
			0x0,		/*  */
/* 82 */	NdrFcShort( 0xfffc ),	/* -4 */
/* 84 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 86 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 88 */	
			0x17,		/* FC_CSTRUCT */
			0x3,		/* 3 */
/* 90 */	NdrFcShort( 0x8 ),	/* 8 */
/* 92 */	NdrFcShort( 0xfff0 ),	/* Offset= -16 (76) */
/* 94 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 96 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 98 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 100 */	NdrFcShort( 0x0 ),	/* 0 */
/* 102 */	NdrFcShort( 0x4 ),	/* 4 */
/* 104 */	NdrFcShort( 0x0 ),	/* 0 */
/* 106 */	NdrFcShort( 0xffde ),	/* Offset= -34 (72) */
/* 108 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 110 */	NdrFcShort( 0x2 ),	/* Offset= 2 (112) */
/* 112 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 114 */	NdrFcLong( 0x63b946e2 ),	/* 1673086690 */
/* 118 */	NdrFcShort( 0x2aee ),	/* 10990 */
/* 120 */	NdrFcShort( 0x4034 ),	/* 16436 */
/* 122 */	0xba,		/* 186 */
			0x1c,		/* 28 */
/* 124 */	0x1b,		/* 27 */
			0x4c,		/* 76 */
/* 126 */	0xfd,		/* 253 */
			0x68,		/* 104 */
/* 128 */	0xce,		/* 206 */
			0xc0,		/* 192 */
/* 130 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 132 */	NdrFcShort( 0x2 ),	/* Offset= 2 (134) */
/* 134 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 136 */	NdrFcLong( 0x4d5b2a01 ),	/* 1297820161 */
/* 140 */	NdrFcShort( 0x1cc2 ),	/* 7362 */
/* 142 */	NdrFcShort( 0x4d56 ),	/* 19798 */
/* 144 */	0xa8,		/* 168 */
			0xd7,		/* 215 */
/* 146 */	0x67,		/* 103 */
			0xc7,		/* 199 */
/* 148 */	0x30,		/* 48 */
			0xa0,		/* 160 */
/* 150 */	0x57,		/* 87 */
			0xed,		/* 237 */
/* 152 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 154 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 156 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 158 */	NdrFcShort( 0x2 ),	/* Offset= 2 (160) */
/* 160 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 162 */	NdrFcLong( 0x641c669 ),	/* 104973929 */
/* 166 */	NdrFcShort( 0xb362 ),	/* -19614 */
/* 168 */	NdrFcShort( 0x48c9 ),	/* 18633 */
/* 170 */	0x8b,		/* 139 */
			0x73,		/* 115 */
/* 172 */	0xd0,		/* 208 */
			0x2b,		/* 43 */
/* 174 */	0x6e,		/* 110 */
			0x25,		/* 37 */
/* 176 */	0x2a,		/* 42 */
			0x9d,		/* 157 */
/* 178 */	
			0x12, 0x0,	/* FC_UP */
/* 180 */	NdrFcShort( 0xffa4 ),	/* Offset= -92 (88) */
/* 182 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 184 */	NdrFcShort( 0x0 ),	/* 0 */
/* 186 */	NdrFcShort( 0x4 ),	/* 4 */
/* 188 */	NdrFcShort( 0x0 ),	/* 0 */
/* 190 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (178) */
/* 192 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 194 */	NdrFcShort( 0x41a ),	/* Offset= 1050 (1244) */
/* 196 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 198 */	NdrFcShort( 0x2 ),	/* Offset= 2 (200) */
/* 200 */	
			0x13, 0x0,	/* FC_OP */
/* 202 */	NdrFcShort( 0x400 ),	/* Offset= 1024 (1226) */
/* 204 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x49,		/* 73 */
/* 206 */	NdrFcShort( 0x18 ),	/* 24 */
/* 208 */	NdrFcShort( 0xa ),	/* 10 */
/* 210 */	NdrFcLong( 0x8 ),	/* 8 */
/* 214 */	NdrFcShort( 0x5a ),	/* Offset= 90 (304) */
/* 216 */	NdrFcLong( 0xd ),	/* 13 */
/* 220 */	NdrFcShort( 0x90 ),	/* Offset= 144 (364) */
/* 222 */	NdrFcLong( 0x9 ),	/* 9 */
/* 226 */	NdrFcShort( 0xc2 ),	/* Offset= 194 (420) */
/* 228 */	NdrFcLong( 0xc ),	/* 12 */
/* 232 */	NdrFcShort( 0x2ce ),	/* Offset= 718 (950) */
/* 234 */	NdrFcLong( 0x24 ),	/* 36 */
/* 238 */	NdrFcShort( 0x2f8 ),	/* Offset= 760 (998) */
/* 240 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 244 */	NdrFcShort( 0x32a ),	/* Offset= 810 (1054) */
/* 246 */	NdrFcLong( 0x10 ),	/* 16 */
/* 250 */	NdrFcShort( 0x344 ),	/* Offset= 836 (1086) */
/* 252 */	NdrFcLong( 0x2 ),	/* 2 */
/* 256 */	NdrFcShort( 0x35e ),	/* Offset= 862 (1118) */
/* 258 */	NdrFcLong( 0x3 ),	/* 3 */
/* 262 */	NdrFcShort( 0x378 ),	/* Offset= 888 (1150) */
/* 264 */	NdrFcLong( 0x14 ),	/* 20 */
/* 268 */	NdrFcShort( 0x392 ),	/* Offset= 914 (1182) */
/* 270 */	NdrFcShort( 0xffff ),	/* Offset= -1 (269) */
/* 272 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 274 */	NdrFcShort( 0x4 ),	/* 4 */
/* 276 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 278 */	NdrFcShort( 0x0 ),	/* 0 */
/* 280 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 282 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 284 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 286 */	NdrFcShort( 0x4 ),	/* 4 */
/* 288 */	NdrFcShort( 0x0 ),	/* 0 */
/* 290 */	NdrFcShort( 0x1 ),	/* 1 */
/* 292 */	NdrFcShort( 0x0 ),	/* 0 */
/* 294 */	NdrFcShort( 0x0 ),	/* 0 */
/* 296 */	0x13, 0x0,	/* FC_OP */
/* 298 */	NdrFcShort( 0xff2e ),	/* Offset= -210 (88) */
/* 300 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 302 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 304 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 306 */	NdrFcShort( 0x8 ),	/* 8 */
/* 308 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 310 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 312 */	NdrFcShort( 0x4 ),	/* 4 */
/* 314 */	NdrFcShort( 0x4 ),	/* 4 */
/* 316 */	0x11, 0x0,	/* FC_RP */
/* 318 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (272) */
/* 320 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 322 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 324 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 326 */	NdrFcLong( 0x0 ),	/* 0 */
/* 330 */	NdrFcShort( 0x0 ),	/* 0 */
/* 332 */	NdrFcShort( 0x0 ),	/* 0 */
/* 334 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 336 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 338 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 340 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 342 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 344 */	NdrFcShort( 0x0 ),	/* 0 */
/* 346 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 348 */	NdrFcShort( 0x0 ),	/* 0 */
/* 350 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 352 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 356 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 358 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 360 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (324) */
/* 362 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 364 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 366 */	NdrFcShort( 0x8 ),	/* 8 */
/* 368 */	NdrFcShort( 0x0 ),	/* 0 */
/* 370 */	NdrFcShort( 0x6 ),	/* Offset= 6 (376) */
/* 372 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 374 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 376 */	
			0x11, 0x0,	/* FC_RP */
/* 378 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (342) */
/* 380 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 382 */	NdrFcLong( 0x20400 ),	/* 132096 */
/* 386 */	NdrFcShort( 0x0 ),	/* 0 */
/* 388 */	NdrFcShort( 0x0 ),	/* 0 */
/* 390 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 392 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 394 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 396 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 398 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 400 */	NdrFcShort( 0x0 ),	/* 0 */
/* 402 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 404 */	NdrFcShort( 0x0 ),	/* 0 */
/* 406 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 408 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 412 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 414 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 416 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (380) */
/* 418 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 420 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 422 */	NdrFcShort( 0x8 ),	/* 8 */
/* 424 */	NdrFcShort( 0x0 ),	/* 0 */
/* 426 */	NdrFcShort( 0x6 ),	/* Offset= 6 (432) */
/* 428 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 430 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 432 */	
			0x11, 0x0,	/* FC_RP */
/* 434 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (398) */
/* 436 */	
			0x2b,		/* FC_NON_ENCAPSULATED_UNION */
			0x9,		/* FC_ULONG */
/* 438 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 440 */	NdrFcShort( 0xfff8 ),	/* -8 */
/* 442 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 444 */	NdrFcShort( 0x2 ),	/* Offset= 2 (446) */
/* 446 */	NdrFcShort( 0x10 ),	/* 16 */
/* 448 */	NdrFcShort( 0x2f ),	/* 47 */
/* 450 */	NdrFcLong( 0x14 ),	/* 20 */
/* 454 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 456 */	NdrFcLong( 0x3 ),	/* 3 */
/* 460 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 462 */	NdrFcLong( 0x11 ),	/* 17 */
/* 466 */	NdrFcShort( 0x8001 ),	/* Simple arm type: FC_BYTE */
/* 468 */	NdrFcLong( 0x2 ),	/* 2 */
/* 472 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 474 */	NdrFcLong( 0x4 ),	/* 4 */
/* 478 */	NdrFcShort( 0x800a ),	/* Simple arm type: FC_FLOAT */
/* 480 */	NdrFcLong( 0x5 ),	/* 5 */
/* 484 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 486 */	NdrFcLong( 0xb ),	/* 11 */
/* 490 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 492 */	NdrFcLong( 0xa ),	/* 10 */
/* 496 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 498 */	NdrFcLong( 0x6 ),	/* 6 */
/* 502 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (734) */
/* 504 */	NdrFcLong( 0x7 ),	/* 7 */
/* 508 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 510 */	NdrFcLong( 0x8 ),	/* 8 */
/* 514 */	NdrFcShort( 0xfe46 ),	/* Offset= -442 (72) */
/* 516 */	NdrFcLong( 0xd ),	/* 13 */
/* 520 */	NdrFcShort( 0xdc ),	/* Offset= 220 (740) */
/* 522 */	NdrFcLong( 0x9 ),	/* 9 */
/* 526 */	NdrFcShort( 0xff6e ),	/* Offset= -146 (380) */
/* 528 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 532 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (758) */
/* 534 */	NdrFcLong( 0x24 ),	/* 36 */
/* 538 */	NdrFcShort( 0xe4 ),	/* Offset= 228 (766) */
/* 540 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 544 */	NdrFcShort( 0xde ),	/* Offset= 222 (766) */
/* 546 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 550 */	NdrFcShort( 0x10e ),	/* Offset= 270 (820) */
/* 552 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 556 */	NdrFcShort( 0x10c ),	/* Offset= 268 (824) */
/* 558 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 562 */	NdrFcShort( 0x10a ),	/* Offset= 266 (828) */
/* 564 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 568 */	NdrFcShort( 0x108 ),	/* Offset= 264 (832) */
/* 570 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 574 */	NdrFcShort( 0x106 ),	/* Offset= 262 (836) */
/* 576 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 580 */	NdrFcShort( 0x104 ),	/* Offset= 260 (840) */
/* 582 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 586 */	NdrFcShort( 0xee ),	/* Offset= 238 (824) */
/* 588 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 592 */	NdrFcShort( 0xec ),	/* Offset= 236 (828) */
/* 594 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 598 */	NdrFcShort( 0xf6 ),	/* Offset= 246 (844) */
/* 600 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 604 */	NdrFcShort( 0xec ),	/* Offset= 236 (840) */
/* 606 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 610 */	NdrFcShort( 0xee ),	/* Offset= 238 (848) */
/* 612 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 616 */	NdrFcShort( 0xec ),	/* Offset= 236 (852) */
/* 618 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 622 */	NdrFcShort( 0xea ),	/* Offset= 234 (856) */
/* 624 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 628 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (860) */
/* 630 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 634 */	NdrFcShort( 0xee ),	/* Offset= 238 (872) */
/* 636 */	NdrFcLong( 0x10 ),	/* 16 */
/* 640 */	NdrFcShort( 0x8002 ),	/* Simple arm type: FC_CHAR */
/* 642 */	NdrFcLong( 0x12 ),	/* 18 */
/* 646 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 648 */	NdrFcLong( 0x13 ),	/* 19 */
/* 652 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 654 */	NdrFcLong( 0x15 ),	/* 21 */
/* 658 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 660 */	NdrFcLong( 0x16 ),	/* 22 */
/* 664 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 666 */	NdrFcLong( 0x17 ),	/* 23 */
/* 670 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 672 */	NdrFcLong( 0xe ),	/* 14 */
/* 676 */	NdrFcShort( 0xcc ),	/* Offset= 204 (880) */
/* 678 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 682 */	NdrFcShort( 0xd0 ),	/* Offset= 208 (890) */
/* 684 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 688 */	NdrFcShort( 0xce ),	/* Offset= 206 (894) */
/* 690 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 694 */	NdrFcShort( 0x82 ),	/* Offset= 130 (824) */
/* 696 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 700 */	NdrFcShort( 0x80 ),	/* Offset= 128 (828) */
/* 702 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 706 */	NdrFcShort( 0x7e ),	/* Offset= 126 (832) */
/* 708 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 712 */	NdrFcShort( 0x74 ),	/* Offset= 116 (828) */
/* 714 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 718 */	NdrFcShort( 0x6e ),	/* Offset= 110 (828) */
/* 720 */	NdrFcLong( 0x0 ),	/* 0 */
/* 724 */	NdrFcShort( 0x0 ),	/* Offset= 0 (724) */
/* 726 */	NdrFcLong( 0x1 ),	/* 1 */
/* 730 */	NdrFcShort( 0x0 ),	/* Offset= 0 (730) */
/* 732 */	NdrFcShort( 0xffff ),	/* Offset= -1 (731) */
/* 734 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 736 */	NdrFcShort( 0x8 ),	/* 8 */
/* 738 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 740 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 742 */	NdrFcLong( 0x0 ),	/* 0 */
/* 746 */	NdrFcShort( 0x0 ),	/* 0 */
/* 748 */	NdrFcShort( 0x0 ),	/* 0 */
/* 750 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 752 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 754 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 756 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 758 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 760 */	NdrFcShort( 0x2 ),	/* Offset= 2 (762) */
/* 762 */	
			0x13, 0x0,	/* FC_OP */
/* 764 */	NdrFcShort( 0x1ce ),	/* Offset= 462 (1226) */
/* 766 */	
			0x13, 0x0,	/* FC_OP */
/* 768 */	NdrFcShort( 0x20 ),	/* Offset= 32 (800) */
/* 770 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 772 */	NdrFcLong( 0x2f ),	/* 47 */
/* 776 */	NdrFcShort( 0x0 ),	/* 0 */
/* 778 */	NdrFcShort( 0x0 ),	/* 0 */
/* 780 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 782 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 784 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 786 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 788 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 790 */	NdrFcShort( 0x1 ),	/* 1 */
/* 792 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 794 */	NdrFcShort( 0x4 ),	/* 4 */
/* 796 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 798 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 800 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 802 */	NdrFcShort( 0x10 ),	/* 16 */
/* 804 */	NdrFcShort( 0x0 ),	/* 0 */
/* 806 */	NdrFcShort( 0xa ),	/* Offset= 10 (816) */
/* 808 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 810 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 812 */	NdrFcShort( 0xffd6 ),	/* Offset= -42 (770) */
/* 814 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 816 */	
			0x13, 0x0,	/* FC_OP */
/* 818 */	NdrFcShort( 0xffe2 ),	/* Offset= -30 (788) */
/* 820 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 822 */	0x1,		/* FC_BYTE */
			0x5c,		/* FC_PAD */
/* 824 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 826 */	0x6,		/* FC_SHORT */
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
/* 846 */	NdrFcShort( 0xff90 ),	/* Offset= -112 (734) */
/* 848 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 850 */	NdrFcShort( 0xfcf6 ),	/* Offset= -778 (72) */
/* 852 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 854 */	NdrFcShort( 0xff8e ),	/* Offset= -114 (740) */
/* 856 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 858 */	NdrFcShort( 0xfe22 ),	/* Offset= -478 (380) */
/* 860 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 862 */	NdrFcShort( 0x2 ),	/* Offset= 2 (864) */
/* 864 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 866 */	NdrFcShort( 0x2 ),	/* Offset= 2 (868) */
/* 868 */	
			0x13, 0x0,	/* FC_OP */
/* 870 */	NdrFcShort( 0x164 ),	/* Offset= 356 (1226) */
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
/* 914 */	NdrFcShort( 0xfe22 ),	/* Offset= -478 (436) */
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
/* 992 */	NdrFcShort( 0xff40 ),	/* Offset= -192 (800) */
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
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 1034 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1036 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1038 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1040 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1042 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 1046 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 1048 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1050 */	NdrFcShort( 0xfeca ),	/* Offset= -310 (740) */
/* 1052 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1054 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1056 */	NdrFcShort( 0x18 ),	/* 24 */
/* 1058 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1060 */	NdrFcShort( 0xa ),	/* Offset= 10 (1070) */
/* 1062 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1064 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1066 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (1020) */
/* 1068 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1070 */	
			0x11, 0x0,	/* FC_RP */
/* 1072 */	NdrFcShort( 0xffd8 ),	/* Offset= -40 (1032) */
/* 1074 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 1076 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1078 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1080 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1082 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1084 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1086 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1088 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1090 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1092 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1094 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1096 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1098 */	0x13, 0x0,	/* FC_OP */
/* 1100 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1074) */
/* 1102 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1104 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1106 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 1108 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1110 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1112 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1114 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1116 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 1118 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1120 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1122 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1124 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1126 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1128 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1130 */	0x13, 0x0,	/* FC_OP */
/* 1132 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1106) */
/* 1134 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1136 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1138 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1140 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1142 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1144 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1146 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1148 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1150 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1152 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1154 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1156 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1158 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1160 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1162 */	0x13, 0x0,	/* FC_OP */
/* 1164 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1138) */
/* 1166 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1168 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1170 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 1172 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1174 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1176 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1178 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1180 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 1182 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1184 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1186 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1188 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1190 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1192 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1194 */	0x13, 0x0,	/* FC_OP */
/* 1196 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1170) */
/* 1198 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1200 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1202 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1204 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1206 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1208 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1210 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1212 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1214 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 1216 */	NdrFcShort( 0xffd8 ),	/* -40 */
/* 1218 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1220 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1222 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1202) */
/* 1224 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1226 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1228 */	NdrFcShort( 0x28 ),	/* 40 */
/* 1230 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1210) */
/* 1232 */	NdrFcShort( 0x0 ),	/* Offset= 0 (1232) */
/* 1234 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1236 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1238 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1240 */	NdrFcShort( 0xfbf4 ),	/* Offset= -1036 (204) */
/* 1242 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1244 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1246 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1248 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1250 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1252 */	NdrFcShort( 0xfbe0 ),	/* Offset= -1056 (196) */

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
    318,
    354,
    390,
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


/* Object interface: IComputationParameters, ver. 0.0,
   GUID={0xAB57FCFD,0x2759,0x4E43,{0x80,0x95,0x34,0xFD,0x20,0xEA,0xAA,0x8B}} */

#pragma code_seg(".orpc")
static const unsigned short IComputationParameters_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    426
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


/* Object interface: IBoxMethodAction, ver. 0.0,
   GUID={0x586FAD2F,0xD9E4,0x4A30,{0xA9,0x25,0x34,0x5C,0x7E,0x1B,0xDC,0x56}} */

#pragma code_seg(".orpc")
static const unsigned short IBoxMethodAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    162,
    198,
    240,
    276,
    0
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
CINTERFACE_PROXY_VTABLE(11) _IBoxMethodActionProxyVtbl = 
{
    0,
    &IID_IBoxMethodAction,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    0 /* forced delegation IAction::SetActionParameters */ ,
    0 /* forced delegation IAction::Do */ ,
    0 /* forced delegation IAction::SetProgressBarInfo */ ,
    0 /* forced delegation IAction::CanDo */
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
    NdrStubCall2
};

CInterfaceStubVtbl _IBoxMethodActionStubVtbl =
{
    &IID_IBoxMethodAction,
    &IBoxMethodAction_ServerInfo,
    11,
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
    426,
    462,
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


/* Object interface: IResultMerger, ver. 0.0,
   GUID={0x4D5B2A01,0x1CC2,0x4D56,{0xA8,0xD7,0x67,0xC7,0x30,0xA0,0x57,0xED}} */

#pragma code_seg(".orpc")
static const unsigned short IResultMerger_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    504,
    540,
    582
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
    618
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
    654,
    690,
    726,
    768,
    810,
    852
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
    618,
    (unsigned short) -1,
    690,
    894,
    930,
    972
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


/* Object interface: IComponentRegistrar, ver. 0.0,
   GUID={0xa817e7a2,0x43fa,0x11d0,{0x9e,0x44,0x00,0xaa,0x00,0xb6,0x77,0x0a}} */

#pragma code_seg(".orpc")
static const unsigned short IComponentRegistrar_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1008,
    36,
    1044,
    1074,
    1116,
    1152
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


/* Object interface: IWritableFunction, ver. 0.0,
   GUID={0x9B3DA2D8,0xE279,0x4552,{0x99,0xF4,0x13,0xAA,0x06,0x66,0x42,0xD5}} */

#pragma code_seg(".orpc")
static const unsigned short IWritableFunction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1008,
    1188
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


/* Object interface: IKernell, ver. 0.0,
   GUID={0xF2D78B39,0xD782,0x49DE,{0x91,0xB7,0x77,0x1C,0xDA,0x2E,0xD0,0xE0}} */

#pragma code_seg(".orpc")
static const unsigned short IKernell_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    426,
    1224
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
    1260
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


/* Object interface: ITarjanAction, ver. 0.0,
   GUID={0xFAFD82A9,0x346E,0x4BD7,{0x83,0x16,0xF1,0x6B,0x10,0x5A,0x46,0x53}} */

#pragma code_seg(".orpc")
static const unsigned short ITarjanAction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    162,
    198,
    240,
    276,
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
    0 /* forced delegation IAction::Do */ ,
    0 /* forced delegation IAction::SetProgressBarInfo */ ,
    0 /* forced delegation IAction::CanDo */
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
    1296
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
    ( CInterfaceProxyVtbl *) &_IBoxMethodActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernellProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ITarjanParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IDummyProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComponentRegistrarProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ITarjanActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableKernellProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableFunctionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionBaseProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProgressBarInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IFunctionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IBoxMethodParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultBaseProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationParametersProxyVtbl,
    0
};

const CInterfaceStubVtbl * __MorseKernel2_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_IResultMergerStubVtbl,
    ( CInterfaceStubVtbl *) &_IBoxMethodActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernellStubVtbl,
    ( CInterfaceStubVtbl *) &_ITarjanParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IDummyStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IComponentRegistrarStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultStubVtbl,
    ( CInterfaceStubVtbl *) &_ITarjanActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableKernellStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableFunctionStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionBaseStubVtbl,
    ( CInterfaceStubVtbl *) &_IProgressBarInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IFunctionStubVtbl,
    ( CInterfaceStubVtbl *) &_IBoxMethodParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultBaseStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationParametersStubVtbl,
    0
};

PCInterfaceName const __MorseKernel2_InterfaceNamesList[] = 
{
    "IResultMerger",
    "IBoxMethodAction",
    "IKernell",
    "ITarjanParameters",
    "IDummy",
    "IGraphInfo",
    "IGraphResult",
    "IParameters",
    "IComponentRegistrar",
    "IResult",
    "ITarjanAction",
    "IWritableKernell",
    "IAction",
    "IWritableFunction",
    "IActionBase",
    "IProgressBarInfo",
    "IFunction",
    "IBoxMethodParameters",
    "IWritableGraphResult",
    "IResultBase",
    "IComputationParameters",
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
    0
};


#define __MorseKernel2_CHECK_IID(n)	IID_GENERIC_CHECK_IID( __MorseKernel2, pIID, n)

int __stdcall __MorseKernel2_IID_Lookup( const IID * pIID, int * pIndex )
{
    IID_BS_LOOKUP_SETUP

    IID_BS_LOOKUP_INITIAL_TEST( __MorseKernel2, 21, 16 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 8 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 4 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 2 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( __MorseKernel2, 21, *pIndex )
    
}

const ExtendedProxyFileInfo _MorseKernel2_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & __MorseKernel2_ProxyVtblList,
    (PCInterfaceStubVtblList *) & __MorseKernel2_StubVtblList,
    (const PCInterfaceName * ) & __MorseKernel2_InterfaceNamesList,
    (const IID ** ) & __MorseKernel2_BaseIIDList,
    & __MorseKernel2_IID_Lookup, 
    21,
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

