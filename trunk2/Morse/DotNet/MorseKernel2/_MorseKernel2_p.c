

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Thu Mar 24 22:50:29 2005
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
#define PROC_FORMAT_STRING_SIZE   1579                              
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


extern const MIDL_SERVER_INFO IBoxMethodAction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IBoxMethodAction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IBoxMethodParameters_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IBoxMethodParameters_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResultMetadata_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResultMetadata_ProxyInfo;


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


extern const MIDL_SERVER_INFO IWritableResultSet_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableResultSet_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraphResultImpl_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphResultImpl_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ISymbolicImageMetadata_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ISymbolicImageMetadata_ProxyInfo;


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


extern const MIDL_SERVER_INFO IDummy_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IDummy_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IDummy1_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IDummy1_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableFunction_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableFunction_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IFunctionImpl_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IFunctionImpl_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IGraphInfoImpl_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IGraphInfoImpl_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IResultSetImpl_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IResultSetImpl_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernell_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernell_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IWritableKernell_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IWritableKernell_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IKernellImpl_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IKernellImpl_ProxyInfo;


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
/* 366 */	NdrFcShort( 0x9 ),	/* 9 */
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

	/* Procedure GetDimension */

/* 396 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 398 */	NdrFcLong( 0x0 ),	/* 0 */
/* 402 */	NdrFcShort( 0xa ),	/* 10 */
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

	/* Parameter dimenstion */

/* 420 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 422 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 424 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 426 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 428 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 430 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetIterations */

/* 432 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 434 */	NdrFcLong( 0x0 ),	/* 0 */
/* 438 */	NdrFcShort( 0xb ),	/* 11 */
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

	/* Procedure GetFunction */

/* 468 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 470 */	NdrFcLong( 0x0 ),	/* 0 */
/* 474 */	NdrFcShort( 0x7 ),	/* 7 */
/* 476 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 478 */	NdrFcShort( 0x0 ),	/* 0 */
/* 480 */	NdrFcShort( 0x8 ),	/* 8 */
/* 482 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 484 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 486 */	NdrFcShort( 0x0 ),	/* 0 */
/* 488 */	NdrFcShort( 0x0 ),	/* 0 */
/* 490 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter function */

/* 492 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 494 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 496 */	NdrFcShort( 0x82 ),	/* Type Offset=130 */

	/* Return value */

/* 498 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 500 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 502 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetDimensionForParameters */

/* 504 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 506 */	NdrFcLong( 0x0 ),	/* 0 */
/* 510 */	NdrFcShort( 0xb ),	/* 11 */
/* 512 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 514 */	NdrFcShort( 0x0 ),	/* 0 */
/* 516 */	NdrFcShort( 0x24 ),	/* 36 */
/* 518 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 520 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 522 */	NdrFcShort( 0x0 ),	/* 0 */
/* 524 */	NdrFcShort( 0x0 ),	/* 0 */
/* 526 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter resultSet */

/* 528 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 530 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 532 */	NdrFcShort( 0x44 ),	/* Type Offset=68 */

	/* Parameter dimension */

/* 534 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 536 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 538 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 540 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 542 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 544 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetFactor */


	/* Procedure GetFactor */

/* 546 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 548 */	NdrFcLong( 0x0 ),	/* 0 */
/* 552 */	NdrFcShort( 0x8 ),	/* 8 */
/* 554 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 556 */	NdrFcShort( 0x8 ),	/* 8 */
/* 558 */	NdrFcShort( 0x24 ),	/* 36 */
/* 560 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 562 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 564 */	NdrFcShort( 0x0 ),	/* 0 */
/* 566 */	NdrFcShort( 0x0 ),	/* 0 */
/* 568 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */


	/* Parameter index */

/* 570 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 572 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 574 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter factor */


	/* Parameter factor */

/* 576 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 578 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 580 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 582 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 584 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 586 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EqualType */

/* 588 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 590 */	NdrFcLong( 0x0 ),	/* 0 */
/* 594 */	NdrFcShort( 0x7 ),	/* 7 */
/* 596 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 598 */	NdrFcShort( 0x0 ),	/* 0 */
/* 600 */	NdrFcShort( 0x22 ),	/* 34 */
/* 602 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 604 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 606 */	NdrFcShort( 0x0 ),	/* 0 */
/* 608 */	NdrFcShort( 0x0 ),	/* 0 */
/* 610 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter metadata */

/* 612 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 614 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 616 */	NdrFcShort( 0x98 ),	/* Type Offset=152 */

	/* Parameter out */

/* 618 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 620 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 622 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 624 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 626 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 628 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure Clone */

/* 630 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 632 */	NdrFcLong( 0x0 ),	/* 0 */
/* 636 */	NdrFcShort( 0x8 ),	/* 8 */
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

	/* Parameter metadata */

/* 654 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 656 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 658 */	NdrFcShort( 0xaa ),	/* Type Offset=170 */

	/* Return value */

/* 660 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 662 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 664 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMetadata */

/* 666 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 668 */	NdrFcLong( 0x0 ),	/* 0 */
/* 672 */	NdrFcShort( 0x7 ),	/* 7 */
/* 674 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 676 */	NdrFcShort( 0x0 ),	/* 0 */
/* 678 */	NdrFcShort( 0x8 ),	/* 8 */
/* 680 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 682 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 684 */	NdrFcShort( 0x0 ),	/* 0 */
/* 686 */	NdrFcShort( 0x0 ),	/* 0 */
/* 688 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter out */

/* 690 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 692 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 694 */	NdrFcShort( 0xaa ),	/* Type Offset=170 */

	/* Return value */

/* 696 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 698 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 700 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetEdges */

/* 702 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 704 */	NdrFcLong( 0x0 ),	/* 0 */
/* 708 */	NdrFcShort( 0x8 ),	/* 8 */
/* 710 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 712 */	NdrFcShort( 0x0 ),	/* 0 */
/* 714 */	NdrFcShort( 0x24 ),	/* 36 */
/* 716 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 718 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 720 */	NdrFcShort( 0x0 ),	/* 0 */
/* 722 */	NdrFcShort( 0x0 ),	/* 0 */
/* 724 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 726 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 728 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 730 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 732 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 734 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 736 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetDimension */

/* 738 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 740 */	NdrFcLong( 0x0 ),	/* 0 */
/* 744 */	NdrFcShort( 0x9 ),	/* 9 */
/* 746 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 748 */	NdrFcShort( 0x0 ),	/* 0 */
/* 750 */	NdrFcShort( 0x24 ),	/* 36 */
/* 752 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 754 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 756 */	NdrFcShort( 0x0 ),	/* 0 */
/* 758 */	NdrFcShort( 0x0 ),	/* 0 */
/* 760 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter value */

/* 762 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 764 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 766 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 768 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 770 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 772 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMinimum */

/* 774 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 776 */	NdrFcLong( 0x0 ),	/* 0 */
/* 780 */	NdrFcShort( 0xa ),	/* 10 */
/* 782 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 784 */	NdrFcShort( 0x8 ),	/* 8 */
/* 786 */	NdrFcShort( 0x2c ),	/* 44 */
/* 788 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 790 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 792 */	NdrFcShort( 0x0 ),	/* 0 */
/* 794 */	NdrFcShort( 0x0 ),	/* 0 */
/* 796 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 798 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 800 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 802 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter value */

/* 804 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 806 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 808 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 810 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 812 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 814 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetMaximum */

/* 816 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 818 */	NdrFcLong( 0x0 ),	/* 0 */
/* 822 */	NdrFcShort( 0xb ),	/* 11 */
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

	/* Procedure GetGridNumber */

/* 858 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 860 */	NdrFcLong( 0x0 ),	/* 0 */
/* 864 */	NdrFcShort( 0xc ),	/* 12 */
/* 866 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 868 */	NdrFcShort( 0x8 ),	/* 8 */
/* 870 */	NdrFcShort( 0x24 ),	/* 36 */
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
/* 892 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 894 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 896 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 898 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGridSize */

/* 900 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 902 */	NdrFcLong( 0x0 ),	/* 0 */
/* 906 */	NdrFcShort( 0xd ),	/* 13 */
/* 908 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 910 */	NdrFcShort( 0x8 ),	/* 8 */
/* 912 */	NdrFcShort( 0x2c ),	/* 44 */
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
/* 934 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 936 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 938 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 940 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetGraphInfo */

/* 942 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 944 */	NdrFcLong( 0x0 ),	/* 0 */
/* 948 */	NdrFcShort( 0x9 ),	/* 9 */
/* 950 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 952 */	NdrFcShort( 0x0 ),	/* 0 */
/* 954 */	NdrFcShort( 0x8 ),	/* 8 */
/* 956 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 958 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 960 */	NdrFcShort( 0x0 ),	/* 0 */
/* 962 */	NdrFcShort( 0x0 ),	/* 0 */
/* 964 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter info */

/* 966 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 968 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 970 */	NdrFcShort( 0xb2 ),	/* Type Offset=178 */

	/* Return value */

/* 972 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 974 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 976 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UseOffsets */


	/* Procedure IsStrongComponent */

/* 978 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 980 */	NdrFcLong( 0x0 ),	/* 0 */
/* 984 */	NdrFcShort( 0xa ),	/* 10 */
/* 986 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 988 */	NdrFcShort( 0x0 ),	/* 0 */
/* 990 */	NdrFcShort( 0x22 ),	/* 34 */
/* 992 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 994 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 996 */	NdrFcShort( 0x0 ),	/* 0 */
/* 998 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1000 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter data */


	/* Parameter value */

/* 1002 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1004 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1006 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 1008 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1010 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1012 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure RegisterComponent */


	/* Procedure SaveText */

/* 1014 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1016 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1020 */	NdrFcShort( 0xb ),	/* 11 */
/* 1022 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1024 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1026 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1028 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1030 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1032 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1034 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1036 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */


	/* Parameter file */

/* 1038 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1040 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1042 */	NdrFcShort( 0xcc ),	/* Type Offset=204 */

	/* Return value */


	/* Return value */

/* 1044 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1046 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1048 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterComponent */


	/* Procedure SaveGraph */

/* 1050 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1052 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1056 */	NdrFcShort( 0xc ),	/* 12 */
/* 1058 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1060 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1062 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1064 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1066 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1068 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1070 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1072 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter bstrCLSID */


	/* Parameter file */

/* 1074 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1076 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1078 */	NdrFcShort( 0xcc ),	/* Type Offset=204 */

	/* Return value */


	/* Return value */

/* 1080 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1082 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1084 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetMetadata */

/* 1086 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1088 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1092 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1094 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1096 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1098 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1100 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1102 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1104 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1106 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1108 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter metadata */

/* 1110 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1112 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1114 */	NdrFcShort( 0x98 ),	/* Type Offset=152 */

	/* Return value */

/* 1116 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1118 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1120 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AddResult */

/* 1122 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1124 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1128 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1130 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1132 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1134 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1136 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1138 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1140 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1142 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1144 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 1146 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1148 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1150 */	NdrFcShort( 0xe ),	/* Type Offset=14 */

	/* Return value */

/* 1152 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1154 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1156 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetEquations */


	/* Procedure Attach */

/* 1158 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1160 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1164 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1166 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1168 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1170 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1172 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 1174 */	0x8,		/* 8 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 1176 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1178 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1180 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter equations */


	/* Parameter bstrPath */

/* 1182 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 1184 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1186 */	NdrFcShort( 0xcc ),	/* Type Offset=204 */

	/* Return value */


	/* Return value */

/* 1188 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1190 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1192 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure UnregisterAll */

/* 1194 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1196 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1200 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1202 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1204 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1206 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1208 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 1210 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1212 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1214 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1216 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 1218 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1220 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1222 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetComponents */

/* 1224 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1226 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1230 */	NdrFcShort( 0xa ),	/* 10 */
/* 1232 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1234 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1236 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1238 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x3,		/* 3 */
/* 1240 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 1242 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1244 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1246 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pbstrCLSIDs */

/* 1248 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1250 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1252 */	NdrFcShort( 0x4f2 ),	/* Type Offset=1266 */

	/* Parameter pbstrDescriptions */

/* 1254 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1256 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1258 */	NdrFcShort( 0x4f2 ),	/* Type Offset=1266 */

	/* Return value */

/* 1260 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1262 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1264 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure NeedEdgeResolve */

/* 1266 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1268 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1272 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1274 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1276 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1278 */	NdrFcShort( 0x22 ),	/* 34 */
/* 1280 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 1282 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1284 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1286 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1288 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter result */

/* 1290 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1292 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1294 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 1296 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1298 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1300 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetDimensionForParameters */

/* 1302 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1304 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1308 */	NdrFcShort( 0xb ),	/* 11 */
/* 1310 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1312 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1314 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1316 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 1318 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1320 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1322 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1324 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter resultSet */

/* 1326 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1328 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1330 */	NdrFcShort( 0x4fc ),	/* Type Offset=1276 */

	/* Parameter dimension */

/* 1332 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1334 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1336 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1338 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1340 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1342 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetPoints */

/* 1344 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1346 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1350 */	NdrFcShort( 0x9 ),	/* 9 */
/* 1352 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1354 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1356 */	NdrFcShort( 0x24 ),	/* 36 */
/* 1358 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 1360 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1362 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1364 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1366 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1368 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1370 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1372 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter ks */

/* 1374 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1376 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1378 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 1380 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1382 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1384 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetOffset */

/* 1386 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1388 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1392 */	NdrFcShort( 0xb ),	/* 11 */
/* 1394 */	NdrFcShort( 0x14 ),	/* x86 Stack size/offset = 20 */
/* 1396 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1398 */	NdrFcShort( 0x50 ),	/* 80 */
/* 1400 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x4,		/* 4 */
/* 1402 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1404 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1406 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1408 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter index */

/* 1410 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 1412 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1414 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter offset1 */

/* 1416 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1418 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1420 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Parameter offset2 */

/* 1422 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 1424 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1426 */	0xc,		/* FC_DOUBLE */
			0x0,		/* 0 */

	/* Return value */

/* 1428 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1430 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 1432 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetLastError */

/* 1434 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1436 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1440 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1442 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1444 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1446 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1448 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1450 */	0x8,		/* 8 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 1452 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1454 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1456 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter message */

/* 1458 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 1460 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1462 */	NdrFcShort( 0x78 ),	/* Type Offset=120 */

	/* Return value */

/* 1464 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1466 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1468 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetFunction */

/* 1470 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1472 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1476 */	NdrFcShort( 0x7 ),	/* 7 */
/* 1478 */	NdrFcShort( 0xc ),	/* x86 Stack size/offset = 12 */
/* 1480 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1482 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1484 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 1486 */	0x8,		/* 8 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 1488 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1490 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1492 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter function */

/* 1494 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1496 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1498 */	NdrFcShort( 0x50e ),	/* Type Offset=1294 */

	/* Return value */

/* 1500 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1502 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1504 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CreateInitialResultSet */

/* 1506 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1508 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1512 */	NdrFcShort( 0x8 ),	/* 8 */
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

	/* Parameter result */

/* 1530 */	NdrFcShort( 0x13 ),	/* Flags:  must size, must free, out, */
/* 1532 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1534 */	NdrFcShort( 0x524 ),	/* Type Offset=1316 */

	/* Return value */

/* 1536 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1538 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1540 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetFunction */

/* 1542 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 1544 */	NdrFcLong( 0x0 ),	/* 0 */
/* 1548 */	NdrFcShort( 0x7 ),	/* 7 */
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

	/* Parameter function */

/* 1566 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 1568 */	NdrFcShort( 0x4 ),	/* x86 Stack size/offset = 4 */
/* 1570 */	NdrFcShort( 0x512 ),	/* Type Offset=1298 */

	/* Return value */

/* 1572 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 1574 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 1576 */	0x8,		/* FC_LONG */
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
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 132 */	NdrFcShort( 0x2 ),	/* Offset= 2 (134) */
/* 134 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 136 */	NdrFcLong( 0x63b946e2 ),	/* 1673086690 */
/* 140 */	NdrFcShort( 0x2aee ),	/* 10990 */
/* 142 */	NdrFcShort( 0x4034 ),	/* 16436 */
/* 144 */	0xba,		/* 186 */
			0x1c,		/* 28 */
/* 146 */	0x1b,		/* 27 */
			0x4c,		/* 76 */
/* 148 */	0xfd,		/* 253 */
			0x68,		/* 104 */
/* 150 */	0xce,		/* 206 */
			0xc0,		/* 192 */
/* 152 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 154 */	NdrFcLong( 0xa8e4f6ff ),	/* -1461389569 */
/* 158 */	NdrFcShort( 0x93da ),	/* -27686 */
/* 160 */	NdrFcShort( 0x489a ),	/* 18586 */
/* 162 */	0xa6,		/* 166 */
			0xc3,		/* 195 */
/* 164 */	0x22,		/* 34 */
			0xa5,		/* 165 */
/* 166 */	0x88,		/* 136 */
			0x49,		/* 73 */
/* 168 */	0x32,		/* 50 */
			0xc9,		/* 201 */
/* 170 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 172 */	NdrFcShort( 0xffec ),	/* Offset= -20 (152) */
/* 174 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 176 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
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
/* 216 */	NdrFcShort( 0x41a ),	/* Offset= 1050 (1266) */
/* 218 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 220 */	NdrFcShort( 0x2 ),	/* Offset= 2 (222) */
/* 222 */	
			0x13, 0x0,	/* FC_OP */
/* 224 */	NdrFcShort( 0x400 ),	/* Offset= 1024 (1248) */
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
/* 254 */	NdrFcShort( 0x2ce ),	/* Offset= 718 (972) */
/* 256 */	NdrFcLong( 0x24 ),	/* 36 */
/* 260 */	NdrFcShort( 0x2f8 ),	/* Offset= 760 (1020) */
/* 262 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 266 */	NdrFcShort( 0x32a ),	/* Offset= 810 (1076) */
/* 268 */	NdrFcLong( 0x10 ),	/* 16 */
/* 272 */	NdrFcShort( 0x344 ),	/* Offset= 836 (1108) */
/* 274 */	NdrFcLong( 0x2 ),	/* 2 */
/* 278 */	NdrFcShort( 0x35e ),	/* Offset= 862 (1140) */
/* 280 */	NdrFcLong( 0x3 ),	/* 3 */
/* 284 */	NdrFcShort( 0x378 ),	/* Offset= 888 (1172) */
/* 286 */	NdrFcLong( 0x14 ),	/* 20 */
/* 290 */	NdrFcShort( 0x392 ),	/* Offset= 914 (1204) */
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
/* 542 */	NdrFcShort( 0xdc ),	/* Offset= 220 (762) */
/* 544 */	NdrFcLong( 0x9 ),	/* 9 */
/* 548 */	NdrFcShort( 0xff6e ),	/* Offset= -146 (402) */
/* 550 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 554 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (780) */
/* 556 */	NdrFcLong( 0x24 ),	/* 36 */
/* 560 */	NdrFcShort( 0xe4 ),	/* Offset= 228 (788) */
/* 562 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 566 */	NdrFcShort( 0xde ),	/* Offset= 222 (788) */
/* 568 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 572 */	NdrFcShort( 0x10e ),	/* Offset= 270 (842) */
/* 574 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 578 */	NdrFcShort( 0x10c ),	/* Offset= 268 (846) */
/* 580 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 584 */	NdrFcShort( 0x10a ),	/* Offset= 266 (850) */
/* 586 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 590 */	NdrFcShort( 0x108 ),	/* Offset= 264 (854) */
/* 592 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 596 */	NdrFcShort( 0x106 ),	/* Offset= 262 (858) */
/* 598 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 602 */	NdrFcShort( 0x104 ),	/* Offset= 260 (862) */
/* 604 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 608 */	NdrFcShort( 0xee ),	/* Offset= 238 (846) */
/* 610 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 614 */	NdrFcShort( 0xec ),	/* Offset= 236 (850) */
/* 616 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 620 */	NdrFcShort( 0xf6 ),	/* Offset= 246 (866) */
/* 622 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 626 */	NdrFcShort( 0xec ),	/* Offset= 236 (862) */
/* 628 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 632 */	NdrFcShort( 0xee ),	/* Offset= 238 (870) */
/* 634 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 638 */	NdrFcShort( 0xec ),	/* Offset= 236 (874) */
/* 640 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 644 */	NdrFcShort( 0xea ),	/* Offset= 234 (878) */
/* 646 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 650 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (882) */
/* 652 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 656 */	NdrFcShort( 0xee ),	/* Offset= 238 (894) */
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
/* 698 */	NdrFcShort( 0xcc ),	/* Offset= 204 (902) */
/* 700 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 704 */	NdrFcShort( 0xd0 ),	/* Offset= 208 (912) */
/* 706 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 710 */	NdrFcShort( 0xce ),	/* Offset= 206 (916) */
/* 712 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 716 */	NdrFcShort( 0x82 ),	/* Offset= 130 (846) */
/* 718 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 722 */	NdrFcShort( 0x80 ),	/* Offset= 128 (850) */
/* 724 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 728 */	NdrFcShort( 0x7e ),	/* Offset= 126 (854) */
/* 730 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 734 */	NdrFcShort( 0x74 ),	/* Offset= 116 (850) */
/* 736 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 740 */	NdrFcShort( 0x6e ),	/* Offset= 110 (850) */
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
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 764 */	NdrFcLong( 0x0 ),	/* 0 */
/* 768 */	NdrFcShort( 0x0 ),	/* 0 */
/* 770 */	NdrFcShort( 0x0 ),	/* 0 */
/* 772 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 774 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 776 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 778 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 780 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 782 */	NdrFcShort( 0x2 ),	/* Offset= 2 (784) */
/* 784 */	
			0x13, 0x0,	/* FC_OP */
/* 786 */	NdrFcShort( 0x1ce ),	/* Offset= 462 (1248) */
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
/* 848 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 850 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 852 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 854 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 856 */	0xb,		/* FC_HYPER */
			0x5c,		/* FC_PAD */
/* 858 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 860 */	0xa,		/* FC_FLOAT */
			0x5c,		/* FC_PAD */
/* 862 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 864 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 866 */	
			0x13, 0x0,	/* FC_OP */
/* 868 */	NdrFcShort( 0xff90 ),	/* Offset= -112 (756) */
/* 870 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 872 */	NdrFcShort( 0xfcf6 ),	/* Offset= -778 (94) */
/* 874 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 876 */	NdrFcShort( 0xff8e ),	/* Offset= -114 (762) */
/* 878 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 880 */	NdrFcShort( 0xfe22 ),	/* Offset= -478 (402) */
/* 882 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 884 */	NdrFcShort( 0x2 ),	/* Offset= 2 (886) */
/* 886 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 888 */	NdrFcShort( 0x2 ),	/* Offset= 2 (890) */
/* 890 */	
			0x13, 0x0,	/* FC_OP */
/* 892 */	NdrFcShort( 0x164 ),	/* Offset= 356 (1248) */
/* 894 */	
			0x13, 0x10,	/* FC_OP [pointer_deref] */
/* 896 */	NdrFcShort( 0x2 ),	/* Offset= 2 (898) */
/* 898 */	
			0x13, 0x0,	/* FC_OP */
/* 900 */	NdrFcShort( 0x14 ),	/* Offset= 20 (920) */
/* 902 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 904 */	NdrFcShort( 0x10 ),	/* 16 */
/* 906 */	0x6,		/* FC_SHORT */
			0x1,		/* FC_BYTE */
/* 908 */	0x1,		/* FC_BYTE */
			0x8,		/* FC_LONG */
/* 910 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 912 */	
			0x13, 0x0,	/* FC_OP */
/* 914 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (902) */
/* 916 */	
			0x13, 0x8,	/* FC_OP [simple_pointer] */
/* 918 */	0x2,		/* FC_CHAR */
			0x5c,		/* FC_PAD */
/* 920 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x7,		/* 7 */
/* 922 */	NdrFcShort( 0x20 ),	/* 32 */
/* 924 */	NdrFcShort( 0x0 ),	/* 0 */
/* 926 */	NdrFcShort( 0x0 ),	/* Offset= 0 (926) */
/* 928 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 930 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 932 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 934 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 936 */	NdrFcShort( 0xfe22 ),	/* Offset= -478 (458) */
/* 938 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 940 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 942 */	NdrFcShort( 0x4 ),	/* 4 */
/* 944 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 946 */	NdrFcShort( 0x0 ),	/* 0 */
/* 948 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 950 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 952 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 954 */	NdrFcShort( 0x4 ),	/* 4 */
/* 956 */	NdrFcShort( 0x0 ),	/* 0 */
/* 958 */	NdrFcShort( 0x1 ),	/* 1 */
/* 960 */	NdrFcShort( 0x0 ),	/* 0 */
/* 962 */	NdrFcShort( 0x0 ),	/* 0 */
/* 964 */	0x13, 0x0,	/* FC_OP */
/* 966 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (920) */
/* 968 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 970 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 972 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 974 */	NdrFcShort( 0x8 ),	/* 8 */
/* 976 */	NdrFcShort( 0x0 ),	/* 0 */
/* 978 */	NdrFcShort( 0x6 ),	/* Offset= 6 (984) */
/* 980 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 982 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 984 */	
			0x11, 0x0,	/* FC_RP */
/* 986 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (940) */
/* 988 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 990 */	NdrFcShort( 0x4 ),	/* 4 */
/* 992 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 994 */	NdrFcShort( 0x0 ),	/* 0 */
/* 996 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 998 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1000 */	
			0x48,		/* FC_VARIABLE_REPEAT */
			0x49,		/* FC_FIXED_OFFSET */
/* 1002 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1004 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1006 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1008 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1010 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1012 */	0x13, 0x0,	/* FC_OP */
/* 1014 */	NdrFcShort( 0xff40 ),	/* Offset= -192 (822) */
/* 1016 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1018 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1020 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1022 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1024 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1026 */	NdrFcShort( 0x6 ),	/* Offset= 6 (1032) */
/* 1028 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1030 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1032 */	
			0x11, 0x0,	/* FC_RP */
/* 1034 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (988) */
/* 1036 */	
			0x1d,		/* FC_SMFARRAY */
			0x0,		/* 0 */
/* 1038 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1040 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1042 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1044 */	NdrFcShort( 0x10 ),	/* 16 */
/* 1046 */	0x8,		/* FC_LONG */
			0x6,		/* FC_SHORT */
/* 1048 */	0x6,		/* FC_SHORT */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 1050 */	0x0,		/* 0 */
			NdrFcShort( 0xfff1 ),	/* Offset= -15 (1036) */
			0x5b,		/* FC_END */
/* 1054 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 1056 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1058 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1060 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1062 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1064 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 1068 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 1070 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1072 */	NdrFcShort( 0xfeca ),	/* Offset= -310 (762) */
/* 1074 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1076 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1078 */	NdrFcShort( 0x18 ),	/* 24 */
/* 1080 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1082 */	NdrFcShort( 0xa ),	/* Offset= 10 (1092) */
/* 1084 */	0x8,		/* FC_LONG */
			0x36,		/* FC_POINTER */
/* 1086 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1088 */	NdrFcShort( 0xffd2 ),	/* Offset= -46 (1042) */
/* 1090 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1092 */	
			0x11, 0x0,	/* FC_RP */
/* 1094 */	NdrFcShort( 0xffd8 ),	/* Offset= -40 (1054) */
/* 1096 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 1098 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1100 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1102 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1104 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1106 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 1108 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1110 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1112 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1114 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1116 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1118 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1120 */	0x13, 0x0,	/* FC_OP */
/* 1122 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1096) */
/* 1124 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1126 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1128 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 1130 */	NdrFcShort( 0x2 ),	/* 2 */
/* 1132 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1134 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1136 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1138 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 1140 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1142 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1144 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1146 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1148 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1150 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1152 */	0x13, 0x0,	/* FC_OP */
/* 1154 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1128) */
/* 1156 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1158 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1160 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1162 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1164 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1166 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1168 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1170 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1172 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1174 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1176 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1178 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1180 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1182 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1184 */	0x13, 0x0,	/* FC_OP */
/* 1186 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1160) */
/* 1188 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1190 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1192 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 1194 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1196 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 1198 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1200 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1202 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 1204 */	
			0x16,		/* FC_PSTRUCT */
			0x3,		/* 3 */
/* 1206 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1208 */	
			0x4b,		/* FC_PP */
			0x5c,		/* FC_PAD */
/* 1210 */	
			0x46,		/* FC_NO_REPEAT */
			0x5c,		/* FC_PAD */
/* 1212 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1214 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1216 */	0x13, 0x0,	/* FC_OP */
/* 1218 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (1192) */
/* 1220 */	
			0x5b,		/* FC_END */

			0x8,		/* FC_LONG */
/* 1222 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 1224 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 1226 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1228 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1230 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1232 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 1234 */	NdrFcShort( 0x8 ),	/* 8 */
/* 1236 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 1238 */	NdrFcShort( 0xffd8 ),	/* -40 */
/* 1240 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 1242 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1244 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1224) */
/* 1246 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1248 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 1250 */	NdrFcShort( 0x28 ),	/* 40 */
/* 1252 */	NdrFcShort( 0xffec ),	/* Offset= -20 (1232) */
/* 1254 */	NdrFcShort( 0x0 ),	/* Offset= 0 (1254) */
/* 1256 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1258 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1260 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1262 */	NdrFcShort( 0xfbf4 ),	/* Offset= -1036 (226) */
/* 1264 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1266 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1268 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1270 */	NdrFcShort( 0x4 ),	/* 4 */
/* 1272 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1274 */	NdrFcShort( 0xfbe0 ),	/* Offset= -1056 (218) */
/* 1276 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1278 */	NdrFcLong( 0x5498e339 ),	/* 1419305785 */
/* 1282 */	NdrFcShort( 0x8014 ),	/* -32748 */
/* 1284 */	NdrFcShort( 0x4366 ),	/* 17254 */
/* 1286 */	0x90,		/* 144 */
			0x92,		/* 146 */
/* 1288 */	0x13,		/* 19 */
			0xeb,		/* 235 */
/* 1290 */	0x8a,		/* 138 */
			0xd3,		/* 211 */
/* 1292 */	0x5e,		/* 94 */
			0x1d,		/* 29 */
/* 1294 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1296 */	NdrFcShort( 0x2 ),	/* Offset= 2 (1298) */
/* 1298 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 1300 */	NdrFcLong( 0x63b946e2 ),	/* 1673086690 */
/* 1304 */	NdrFcShort( 0x2aee ),	/* 10990 */
/* 1306 */	NdrFcShort( 0x4034 ),	/* 16436 */
/* 1308 */	0xba,		/* 186 */
			0x1c,		/* 28 */
/* 1310 */	0x1b,		/* 27 */
			0x4c,		/* 76 */
/* 1312 */	0xfd,		/* 253 */
			0x68,		/* 104 */
/* 1314 */	0xce,		/* 206 */
			0xc0,		/* 192 */
/* 1316 */	
			0x11, 0x10,	/* FC_RP [pointer_deref] */
/* 1318 */	NdrFcShort( 0xffd6 ),	/* Offset= -42 (1276) */

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
    360,
    396,
    432,
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
    468
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
    204,
    240,
    276,
    318,
    504
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
    468,
    546,
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


/* Object interface: IResultMetadata, ver. 0.0,
   GUID={0xA8E4F6FF,0x93DA,0x489A,{0xA6,0xC3,0x22,0xA5,0x88,0x49,0x32,0xC9}} */

#pragma code_seg(".orpc")
static const unsigned short IResultMetadata_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    588,
    630
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
    666
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
    702,
    738,
    774,
    816,
    858,
    900
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
    666,
    (unsigned short) -1,
    942,
    978,
    1014,
    1050
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
    1086
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
CINTERFACE_PROXY_VTABLE(9) _IWritableGraphResultProxyVtbl = 
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
    (void *) (INT_PTR) -1 /* IWritableGraphResult::SetMetadata */
};


static const PRPC_STUB_FUNCTION IWritableGraphResult_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2
};

CInterfaceStubVtbl _IWritableGraphResultStubVtbl =
{
    &IID_IWritableGraphResult,
    &IWritableGraphResult_ServerInfo,
    9,
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
    1122
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
    588,
    630,
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


/* Object interface: IComponentRegistrar, ver. 0.0,
   GUID={0xa817e7a2,0x43fa,0x11d0,{0x9e,0x44,0x00,0xaa,0x00,0xb6,0x77,0x0a}} */

#pragma code_seg(".orpc")
static const unsigned short IComponentRegistrar_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1158,
    36,
    1194,
    1224,
    1014,
    1050
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
    1266
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
    1302
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
    468,
    546,
    1344,
    978,
    1386
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


/* Object interface: IWritableFunction, ver. 0.0,
   GUID={0x9B3DA2D8,0xE279,0x4552,{0x99,0xF4,0x13,0xAA,0x06,0x66,0x42,0xD5}} */

#pragma code_seg(".orpc")
static const unsigned short IWritableFunction_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1158,
    1434
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


/* Object interface: IFunctionImpl, ver. 0.0,
   GUID={0x38C4B884,0x7772,0x4AA3,{0xB1,0xC0,0x4B,0xC1,0x12,0xFE,0x48,0x5F}} */

#pragma code_seg(".orpc")
static const unsigned short IFunctionImpl_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0
    };

static const MIDL_STUBLESS_PROXY_INFO IFunctionImpl_ProxyInfo =
    {
    &Object_StubDesc,
    __MIDL_ProcFormatString.Format,
    &IFunctionImpl_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IFunctionImpl_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    __MIDL_ProcFormatString.Format,
    &IFunctionImpl_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(7) _IFunctionImplProxyVtbl = 
{
    0,
    &IID_IFunctionImpl,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfoCount */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetTypeInfo */ ,
    0 /* (void *) (INT_PTR) -1 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */
};


static const PRPC_STUB_FUNCTION IFunctionImpl_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION
};

CInterfaceStubVtbl _IFunctionImplStubVtbl =
{
    &IID_IFunctionImpl,
    &IFunctionImpl_ServerInfo,
    7,
    &IFunctionImpl_table[-3],
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


/* Object interface: IKernell, ver. 0.0,
   GUID={0xF2D78B39,0xD782,0x49DE,{0x91,0xB7,0x77,0x1C,0xDA,0x2E,0xD0,0xE0}} */

#pragma code_seg(".orpc")
static const unsigned short IKernell_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    1470,
    1506
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
    1542
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
    1542,
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
    ( CInterfaceProxyVtbl *) &_IGraphInfoImplProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IBoxMethodActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernellProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultSetProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ITarjanParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IDummyProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ISymbolicImageMetadataProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultSetImplProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IFunctionImplProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IKernellImplProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComponentRegistrarProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ITarjanActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableResultSetProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IGraphResultImplProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IPointMethodParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableKernellProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableFunctionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IActionBaseProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IProgressBarInfoProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IFunctionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IBoxMethodParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IWritableGraphResultProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IDummy1ProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IPointMethodActionProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultBaseProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IComputationParametersProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IResultMetadataProxyVtbl,
    0
};

const CInterfaceStubVtbl * __MorseKernel2_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_IGraphInfoImplStubVtbl,
    ( CInterfaceStubVtbl *) &_IBoxMethodActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernellStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultSetStubVtbl,
    ( CInterfaceStubVtbl *) &_ITarjanParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IDummyStubVtbl,
    ( CInterfaceStubVtbl *) &_ISymbolicImageMetadataStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultSetImplStubVtbl,
    ( CInterfaceStubVtbl *) &_IFunctionImplStubVtbl,
    ( CInterfaceStubVtbl *) &_IKernellImplStubVtbl,
    ( CInterfaceStubVtbl *) &_IComponentRegistrarStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultStubVtbl,
    ( CInterfaceStubVtbl *) &_ITarjanActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableResultSetStubVtbl,
    ( CInterfaceStubVtbl *) &_IGraphResultImplStubVtbl,
    ( CInterfaceStubVtbl *) &_IPointMethodParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableKernellStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableFunctionStubVtbl,
    ( CInterfaceStubVtbl *) &_IActionBaseStubVtbl,
    ( CInterfaceStubVtbl *) &_IProgressBarInfoStubVtbl,
    ( CInterfaceStubVtbl *) &_IFunctionStubVtbl,
    ( CInterfaceStubVtbl *) &_IBoxMethodParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IWritableGraphResultStubVtbl,
    ( CInterfaceStubVtbl *) &_IDummy1StubVtbl,
    ( CInterfaceStubVtbl *) &_IPointMethodActionStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultBaseStubVtbl,
    ( CInterfaceStubVtbl *) &_IComputationParametersStubVtbl,
    ( CInterfaceStubVtbl *) &_IResultMetadataStubVtbl,
    0
};

PCInterfaceName const __MorseKernel2_InterfaceNamesList[] = 
{
    "IGraphInfoImpl",
    "IBoxMethodAction",
    "IKernell",
    "IResultSet",
    "ITarjanParameters",
    "IDummy",
    "ISymbolicImageMetadata",
    "IGraphInfo",
    "IGraphResult",
    "IParameters",
    "IResultSetImpl",
    "IFunctionImpl",
    "IKernellImpl",
    "IComponentRegistrar",
    "IResult",
    "ITarjanAction",
    "IWritableResultSet",
    "IGraphResultImpl",
    "IPointMethodParameters",
    "IWritableKernell",
    "IAction",
    "IWritableFunction",
    "IActionBase",
    "IProgressBarInfo",
    "IFunction",
    "IBoxMethodParameters",
    "IWritableGraphResult",
    "IDummy1",
    "IPointMethodAction",
    "IResultBase",
    "IComputationParameters",
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
    0
};


#define __MorseKernel2_CHECK_IID(n)	IID_GENERIC_CHECK_IID( __MorseKernel2, pIID, n)

int __stdcall __MorseKernel2_IID_Lookup( const IID * pIID, int * pIndex )
{
    IID_BS_LOOKUP_SETUP

    IID_BS_LOOKUP_INITIAL_TEST( __MorseKernel2, 32, 16 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 8 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 4 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 2 )
    IID_BS_LOOKUP_NEXT_TEST( __MorseKernel2, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( __MorseKernel2, 32, *pIndex )
    
}

const ExtendedProxyFileInfo _MorseKernel2_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & __MorseKernel2_ProxyVtblList,
    (PCInterfaceStubVtblList *) & __MorseKernel2_StubVtblList,
    (const PCInterfaceName * ) & __MorseKernel2_InterfaceNamesList,
    (const IID ** ) & __MorseKernel2_BaseIIDList,
    & __MorseKernel2_IID_Lookup, 
    32,
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

