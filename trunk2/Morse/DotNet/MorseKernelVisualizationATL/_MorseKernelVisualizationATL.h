

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Tue Feb 15 00:57:38 2005
 */
/* Compiler settings for _MorseKernelVisualizationATL.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef ___MorseKernelVisualizationATL_h__
#define ___MorseKernelVisualizationATL_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IComponentRegistrar_FWD_DEFINED__
#define __IComponentRegistrar_FWD_DEFINED__
typedef interface IComponentRegistrar IComponentRegistrar;
#endif 	/* __IComponentRegistrar_FWD_DEFINED__ */


#ifndef __IMorseKernelVisualizationDirect3D_FWD_DEFINED__
#define __IMorseKernelVisualizationDirect3D_FWD_DEFINED__
typedef interface IMorseKernelVisualizationDirect3D IMorseKernelVisualizationDirect3D;
#endif 	/* __IMorseKernelVisualizationDirect3D_FWD_DEFINED__ */


#ifndef __IMorseKernelVisualizationDirectGraph3D_FWD_DEFINED__
#define __IMorseKernelVisualizationDirectGraph3D_FWD_DEFINED__
typedef interface IMorseKernelVisualizationDirectGraph3D IMorseKernelVisualizationDirectGraph3D;
#endif 	/* __IMorseKernelVisualizationDirectGraph3D_FWD_DEFINED__ */


#ifndef __IMorseKernelVisualizationDirectGraph2D_FWD_DEFINED__
#define __IMorseKernelVisualizationDirectGraph2D_FWD_DEFINED__
typedef interface IMorseKernelVisualizationDirectGraph2D IMorseKernelVisualizationDirectGraph2D;
#endif 	/* __IMorseKernelVisualizationDirectGraph2D_FWD_DEFINED__ */


#ifndef __CCompReg_FWD_DEFINED__
#define __CCompReg_FWD_DEFINED__

#ifdef __cplusplus
typedef class CCompReg CCompReg;
#else
typedef struct CCompReg CCompReg;
#endif /* __cplusplus */

#endif 	/* __CCompReg_FWD_DEFINED__ */


#ifndef ___IMorseKernelVisualizationDirect3DEvents_FWD_DEFINED__
#define ___IMorseKernelVisualizationDirect3DEvents_FWD_DEFINED__
typedef interface _IMorseKernelVisualizationDirect3DEvents _IMorseKernelVisualizationDirect3DEvents;
#endif 	/* ___IMorseKernelVisualizationDirect3DEvents_FWD_DEFINED__ */


#ifndef __CMorseKernelVisualizationDirectGraph3D_FWD_DEFINED__
#define __CMorseKernelVisualizationDirectGraph3D_FWD_DEFINED__

#ifdef __cplusplus
typedef class CMorseKernelVisualizationDirectGraph3D CMorseKernelVisualizationDirectGraph3D;
#else
typedef struct CMorseKernelVisualizationDirectGraph3D CMorseKernelVisualizationDirectGraph3D;
#endif /* __cplusplus */

#endif 	/* __CMorseKernelVisualizationDirectGraph3D_FWD_DEFINED__ */


#ifndef __CMorseKernelVisualizationDirectGraph2D_FWD_DEFINED__
#define __CMorseKernelVisualizationDirectGraph2D_FWD_DEFINED__

#ifdef __cplusplus
typedef class CMorseKernelVisualizationDirectGraph2D CMorseKernelVisualizationDirectGraph2D;
#else
typedef struct CMorseKernelVisualizationDirectGraph2D CMorseKernelVisualizationDirectGraph2D;
#endif /* __cplusplus */

#endif 	/* __CMorseKernelVisualizationDirectGraph2D_FWD_DEFINED__ */


/* header files for imported files */
#include "prsht.h"
#include "mshtml.h"
#include "mshtmhst.h"
#include "exdisp.h"
#include "objsafe.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __IComponentRegistrar_INTERFACE_DEFINED__
#define __IComponentRegistrar_INTERFACE_DEFINED__

/* interface IComponentRegistrar */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IComponentRegistrar;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("a817e7a2-43fa-11d0-9e44-00aa00b6770a")
    IComponentRegistrar : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Attach( 
            /* [in] */ BSTR bstrPath) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE RegisterAll( void) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE UnregisterAll( void) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetComponents( 
            /* [out] */ SAFEARRAY * *pbstrCLSIDs,
            /* [out] */ SAFEARRAY * *pbstrDescriptions) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE RegisterComponent( 
            /* [in] */ BSTR bstrCLSID) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE UnregisterComponent( 
            /* [in] */ BSTR bstrCLSID) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IComponentRegistrarVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IComponentRegistrar * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IComponentRegistrar * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IComponentRegistrar * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IComponentRegistrar * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IComponentRegistrar * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IComponentRegistrar * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IComponentRegistrar * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Attach )( 
            IComponentRegistrar * This,
            /* [in] */ BSTR bstrPath);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *RegisterAll )( 
            IComponentRegistrar * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *UnregisterAll )( 
            IComponentRegistrar * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetComponents )( 
            IComponentRegistrar * This,
            /* [out] */ SAFEARRAY * *pbstrCLSIDs,
            /* [out] */ SAFEARRAY * *pbstrDescriptions);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *RegisterComponent )( 
            IComponentRegistrar * This,
            /* [in] */ BSTR bstrCLSID);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *UnregisterComponent )( 
            IComponentRegistrar * This,
            /* [in] */ BSTR bstrCLSID);
        
        END_INTERFACE
    } IComponentRegistrarVtbl;

    interface IComponentRegistrar
    {
        CONST_VTBL struct IComponentRegistrarVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IComponentRegistrar_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IComponentRegistrar_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IComponentRegistrar_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IComponentRegistrar_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IComponentRegistrar_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IComponentRegistrar_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IComponentRegistrar_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IComponentRegistrar_Attach(This,bstrPath)	\
    (This)->lpVtbl -> Attach(This,bstrPath)

#define IComponentRegistrar_RegisterAll(This)	\
    (This)->lpVtbl -> RegisterAll(This)

#define IComponentRegistrar_UnregisterAll(This)	\
    (This)->lpVtbl -> UnregisterAll(This)

#define IComponentRegistrar_GetComponents(This,pbstrCLSIDs,pbstrDescriptions)	\
    (This)->lpVtbl -> GetComponents(This,pbstrCLSIDs,pbstrDescriptions)

#define IComponentRegistrar_RegisterComponent(This,bstrCLSID)	\
    (This)->lpVtbl -> RegisterComponent(This,bstrCLSID)

#define IComponentRegistrar_UnregisterComponent(This,bstrCLSID)	\
    (This)->lpVtbl -> UnregisterComponent(This,bstrCLSID)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IComponentRegistrar_Attach_Proxy( 
    IComponentRegistrar * This,
    /* [in] */ BSTR bstrPath);


void __RPC_STUB IComponentRegistrar_Attach_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IComponentRegistrar_RegisterAll_Proxy( 
    IComponentRegistrar * This);


void __RPC_STUB IComponentRegistrar_RegisterAll_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IComponentRegistrar_UnregisterAll_Proxy( 
    IComponentRegistrar * This);


void __RPC_STUB IComponentRegistrar_UnregisterAll_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IComponentRegistrar_GetComponents_Proxy( 
    IComponentRegistrar * This,
    /* [out] */ SAFEARRAY * *pbstrCLSIDs,
    /* [out] */ SAFEARRAY * *pbstrDescriptions);


void __RPC_STUB IComponentRegistrar_GetComponents_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IComponentRegistrar_RegisterComponent_Proxy( 
    IComponentRegistrar * This,
    /* [in] */ BSTR bstrCLSID);


void __RPC_STUB IComponentRegistrar_RegisterComponent_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IComponentRegistrar_UnregisterComponent_Proxy( 
    IComponentRegistrar * This,
    /* [in] */ BSTR bstrCLSID);


void __RPC_STUB IComponentRegistrar_UnregisterComponent_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IComponentRegistrar_INTERFACE_DEFINED__ */


#ifndef __IMorseKernelVisualizationDirect3D_INTERFACE_DEFINED__
#define __IMorseKernelVisualizationDirect3D_INTERFACE_DEFINED__

/* interface IMorseKernelVisualizationDirect3D */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IMorseKernelVisualizationDirect3D;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("35435412-4462-4A3D-A9C8-CEB11AC900EE")
    IMorseKernelVisualizationDirect3D : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE MoveLeftAtom( void) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE MoveRightAtom( void) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE MoveUpAtom( void) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE MoveDownAtom( void) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE ZoomOutAtom( void) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE ZoomInAtom( void) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE CenterView( void) = 0;
        
        virtual /* [local][id] */ HRESULT STDMETHODCALLTYPE SetGraph( 
            /* [in] */ void **graph) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetTestGraph( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMorseKernelVisualizationDirect3DVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMorseKernelVisualizationDirect3D * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMorseKernelVisualizationDirect3D * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMorseKernelVisualizationDirect3D * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMorseKernelVisualizationDirect3D * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMorseKernelVisualizationDirect3D * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMorseKernelVisualizationDirect3D * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMorseKernelVisualizationDirect3D * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveLeftAtom )( 
            IMorseKernelVisualizationDirect3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveRightAtom )( 
            IMorseKernelVisualizationDirect3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveUpAtom )( 
            IMorseKernelVisualizationDirect3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveDownAtom )( 
            IMorseKernelVisualizationDirect3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *ZoomOutAtom )( 
            IMorseKernelVisualizationDirect3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *ZoomInAtom )( 
            IMorseKernelVisualizationDirect3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CenterView )( 
            IMorseKernelVisualizationDirect3D * This);
        
        /* [local][id] */ HRESULT ( STDMETHODCALLTYPE *SetGraph )( 
            IMorseKernelVisualizationDirect3D * This,
            /* [in] */ void **graph);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetTestGraph )( 
            IMorseKernelVisualizationDirect3D * This);
        
        END_INTERFACE
    } IMorseKernelVisualizationDirect3DVtbl;

    interface IMorseKernelVisualizationDirect3D
    {
        CONST_VTBL struct IMorseKernelVisualizationDirect3DVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMorseKernelVisualizationDirect3D_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMorseKernelVisualizationDirect3D_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMorseKernelVisualizationDirect3D_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMorseKernelVisualizationDirect3D_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMorseKernelVisualizationDirect3D_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMorseKernelVisualizationDirect3D_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMorseKernelVisualizationDirect3D_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IMorseKernelVisualizationDirect3D_MoveLeftAtom(This)	\
    (This)->lpVtbl -> MoveLeftAtom(This)

#define IMorseKernelVisualizationDirect3D_MoveRightAtom(This)	\
    (This)->lpVtbl -> MoveRightAtom(This)

#define IMorseKernelVisualizationDirect3D_MoveUpAtom(This)	\
    (This)->lpVtbl -> MoveUpAtom(This)

#define IMorseKernelVisualizationDirect3D_MoveDownAtom(This)	\
    (This)->lpVtbl -> MoveDownAtom(This)

#define IMorseKernelVisualizationDirect3D_ZoomOutAtom(This)	\
    (This)->lpVtbl -> ZoomOutAtom(This)

#define IMorseKernelVisualizationDirect3D_ZoomInAtom(This)	\
    (This)->lpVtbl -> ZoomInAtom(This)

#define IMorseKernelVisualizationDirect3D_CenterView(This)	\
    (This)->lpVtbl -> CenterView(This)

#define IMorseKernelVisualizationDirect3D_SetGraph(This,graph)	\
    (This)->lpVtbl -> SetGraph(This,graph)

#define IMorseKernelVisualizationDirect3D_SetTestGraph(This)	\
    (This)->lpVtbl -> SetTestGraph(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirect3D_MoveLeftAtom_Proxy( 
    IMorseKernelVisualizationDirect3D * This);


void __RPC_STUB IMorseKernelVisualizationDirect3D_MoveLeftAtom_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirect3D_MoveRightAtom_Proxy( 
    IMorseKernelVisualizationDirect3D * This);


void __RPC_STUB IMorseKernelVisualizationDirect3D_MoveRightAtom_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirect3D_MoveUpAtom_Proxy( 
    IMorseKernelVisualizationDirect3D * This);


void __RPC_STUB IMorseKernelVisualizationDirect3D_MoveUpAtom_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirect3D_MoveDownAtom_Proxy( 
    IMorseKernelVisualizationDirect3D * This);


void __RPC_STUB IMorseKernelVisualizationDirect3D_MoveDownAtom_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirect3D_ZoomOutAtom_Proxy( 
    IMorseKernelVisualizationDirect3D * This);


void __RPC_STUB IMorseKernelVisualizationDirect3D_ZoomOutAtom_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirect3D_ZoomInAtom_Proxy( 
    IMorseKernelVisualizationDirect3D * This);


void __RPC_STUB IMorseKernelVisualizationDirect3D_ZoomInAtom_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirect3D_CenterView_Proxy( 
    IMorseKernelVisualizationDirect3D * This);


void __RPC_STUB IMorseKernelVisualizationDirect3D_CenterView_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [local][id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirect3D_SetGraph_Proxy( 
    IMorseKernelVisualizationDirect3D * This,
    /* [in] */ void **graph);


void __RPC_STUB IMorseKernelVisualizationDirect3D_SetGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirect3D_SetTestGraph_Proxy( 
    IMorseKernelVisualizationDirect3D * This);


void __RPC_STUB IMorseKernelVisualizationDirect3D_SetTestGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMorseKernelVisualizationDirect3D_INTERFACE_DEFINED__ */


#ifndef __IMorseKernelVisualizationDirectGraph3D_INTERFACE_DEFINED__
#define __IMorseKernelVisualizationDirectGraph3D_INTERFACE_DEFINED__

/* interface IMorseKernelVisualizationDirectGraph3D */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IMorseKernelVisualizationDirectGraph3D;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("ADE7B805-2B13-46CC-9F90-7E4E6D1B9384")
    IMorseKernelVisualizationDirectGraph3D : public IMorseKernelVisualizationDirect3D
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE MoveFromEye( 
            /* [in] */ DOUBLE x,
            /* [in] */ DOUBLE y,
            /* [in] */ DOUBLE z) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetEyeFrom( 
            /* [in] */ FLOAT x,
            /* [in] */ FLOAT y,
            /* [in] */ FLOAT z) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetEyeTo( 
            /* [in] */ FLOAT x,
            /* [in] */ FLOAT y,
            /* [in] */ FLOAT z) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Rotate( 
            /* [in] */ FLOAT onX,
            /* [in] */ FLOAT onY,
            /* [in] */ FLOAT onZ) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMorseKernelVisualizationDirectGraph3DVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMorseKernelVisualizationDirectGraph3D * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMorseKernelVisualizationDirectGraph3D * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMorseKernelVisualizationDirectGraph3D * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMorseKernelVisualizationDirectGraph3D * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMorseKernelVisualizationDirectGraph3D * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMorseKernelVisualizationDirectGraph3D * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMorseKernelVisualizationDirectGraph3D * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveLeftAtom )( 
            IMorseKernelVisualizationDirectGraph3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveRightAtom )( 
            IMorseKernelVisualizationDirectGraph3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveUpAtom )( 
            IMorseKernelVisualizationDirectGraph3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveDownAtom )( 
            IMorseKernelVisualizationDirectGraph3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *ZoomOutAtom )( 
            IMorseKernelVisualizationDirectGraph3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *ZoomInAtom )( 
            IMorseKernelVisualizationDirectGraph3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CenterView )( 
            IMorseKernelVisualizationDirectGraph3D * This);
        
        /* [local][id] */ HRESULT ( STDMETHODCALLTYPE *SetGraph )( 
            IMorseKernelVisualizationDirectGraph3D * This,
            /* [in] */ void **graph);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetTestGraph )( 
            IMorseKernelVisualizationDirectGraph3D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveFromEye )( 
            IMorseKernelVisualizationDirectGraph3D * This,
            /* [in] */ DOUBLE x,
            /* [in] */ DOUBLE y,
            /* [in] */ DOUBLE z);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetEyeFrom )( 
            IMorseKernelVisualizationDirectGraph3D * This,
            /* [in] */ FLOAT x,
            /* [in] */ FLOAT y,
            /* [in] */ FLOAT z);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetEyeTo )( 
            IMorseKernelVisualizationDirectGraph3D * This,
            /* [in] */ FLOAT x,
            /* [in] */ FLOAT y,
            /* [in] */ FLOAT z);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Rotate )( 
            IMorseKernelVisualizationDirectGraph3D * This,
            /* [in] */ FLOAT onX,
            /* [in] */ FLOAT onY,
            /* [in] */ FLOAT onZ);
        
        END_INTERFACE
    } IMorseKernelVisualizationDirectGraph3DVtbl;

    interface IMorseKernelVisualizationDirectGraph3D
    {
        CONST_VTBL struct IMorseKernelVisualizationDirectGraph3DVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMorseKernelVisualizationDirectGraph3D_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMorseKernelVisualizationDirectGraph3D_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMorseKernelVisualizationDirectGraph3D_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMorseKernelVisualizationDirectGraph3D_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMorseKernelVisualizationDirectGraph3D_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMorseKernelVisualizationDirectGraph3D_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMorseKernelVisualizationDirectGraph3D_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IMorseKernelVisualizationDirectGraph3D_MoveLeftAtom(This)	\
    (This)->lpVtbl -> MoveLeftAtom(This)

#define IMorseKernelVisualizationDirectGraph3D_MoveRightAtom(This)	\
    (This)->lpVtbl -> MoveRightAtom(This)

#define IMorseKernelVisualizationDirectGraph3D_MoveUpAtom(This)	\
    (This)->lpVtbl -> MoveUpAtom(This)

#define IMorseKernelVisualizationDirectGraph3D_MoveDownAtom(This)	\
    (This)->lpVtbl -> MoveDownAtom(This)

#define IMorseKernelVisualizationDirectGraph3D_ZoomOutAtom(This)	\
    (This)->lpVtbl -> ZoomOutAtom(This)

#define IMorseKernelVisualizationDirectGraph3D_ZoomInAtom(This)	\
    (This)->lpVtbl -> ZoomInAtom(This)

#define IMorseKernelVisualizationDirectGraph3D_CenterView(This)	\
    (This)->lpVtbl -> CenterView(This)

#define IMorseKernelVisualizationDirectGraph3D_SetGraph(This,graph)	\
    (This)->lpVtbl -> SetGraph(This,graph)

#define IMorseKernelVisualizationDirectGraph3D_SetTestGraph(This)	\
    (This)->lpVtbl -> SetTestGraph(This)


#define IMorseKernelVisualizationDirectGraph3D_MoveFromEye(This,x,y,z)	\
    (This)->lpVtbl -> MoveFromEye(This,x,y,z)

#define IMorseKernelVisualizationDirectGraph3D_SetEyeFrom(This,x,y,z)	\
    (This)->lpVtbl -> SetEyeFrom(This,x,y,z)

#define IMorseKernelVisualizationDirectGraph3D_SetEyeTo(This,x,y,z)	\
    (This)->lpVtbl -> SetEyeTo(This,x,y,z)

#define IMorseKernelVisualizationDirectGraph3D_Rotate(This,onX,onY,onZ)	\
    (This)->lpVtbl -> Rotate(This,onX,onY,onZ)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirectGraph3D_MoveFromEye_Proxy( 
    IMorseKernelVisualizationDirectGraph3D * This,
    /* [in] */ DOUBLE x,
    /* [in] */ DOUBLE y,
    /* [in] */ DOUBLE z);


void __RPC_STUB IMorseKernelVisualizationDirectGraph3D_MoveFromEye_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirectGraph3D_SetEyeFrom_Proxy( 
    IMorseKernelVisualizationDirectGraph3D * This,
    /* [in] */ FLOAT x,
    /* [in] */ FLOAT y,
    /* [in] */ FLOAT z);


void __RPC_STUB IMorseKernelVisualizationDirectGraph3D_SetEyeFrom_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirectGraph3D_SetEyeTo_Proxy( 
    IMorseKernelVisualizationDirectGraph3D * This,
    /* [in] */ FLOAT x,
    /* [in] */ FLOAT y,
    /* [in] */ FLOAT z);


void __RPC_STUB IMorseKernelVisualizationDirectGraph3D_SetEyeTo_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMorseKernelVisualizationDirectGraph3D_Rotate_Proxy( 
    IMorseKernelVisualizationDirectGraph3D * This,
    /* [in] */ FLOAT onX,
    /* [in] */ FLOAT onY,
    /* [in] */ FLOAT onZ);


void __RPC_STUB IMorseKernelVisualizationDirectGraph3D_Rotate_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMorseKernelVisualizationDirectGraph3D_INTERFACE_DEFINED__ */


#ifndef __IMorseKernelVisualizationDirectGraph2D_INTERFACE_DEFINED__
#define __IMorseKernelVisualizationDirectGraph2D_INTERFACE_DEFINED__

/* interface IMorseKernelVisualizationDirectGraph2D */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IMorseKernelVisualizationDirectGraph2D;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("31146F99-AA89-4E63-94B2-CFF1358E46ED")
    IMorseKernelVisualizationDirectGraph2D : public IMorseKernelVisualizationDirect3D
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IMorseKernelVisualizationDirectGraph2DVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMorseKernelVisualizationDirectGraph2D * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMorseKernelVisualizationDirectGraph2D * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMorseKernelVisualizationDirectGraph2D * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMorseKernelVisualizationDirectGraph2D * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMorseKernelVisualizationDirectGraph2D * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMorseKernelVisualizationDirectGraph2D * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMorseKernelVisualizationDirectGraph2D * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveLeftAtom )( 
            IMorseKernelVisualizationDirectGraph2D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveRightAtom )( 
            IMorseKernelVisualizationDirectGraph2D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveUpAtom )( 
            IMorseKernelVisualizationDirectGraph2D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *MoveDownAtom )( 
            IMorseKernelVisualizationDirectGraph2D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *ZoomOutAtom )( 
            IMorseKernelVisualizationDirectGraph2D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *ZoomInAtom )( 
            IMorseKernelVisualizationDirectGraph2D * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CenterView )( 
            IMorseKernelVisualizationDirectGraph2D * This);
        
        /* [local][id] */ HRESULT ( STDMETHODCALLTYPE *SetGraph )( 
            IMorseKernelVisualizationDirectGraph2D * This,
            /* [in] */ void **graph);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetTestGraph )( 
            IMorseKernelVisualizationDirectGraph2D * This);
        
        END_INTERFACE
    } IMorseKernelVisualizationDirectGraph2DVtbl;

    interface IMorseKernelVisualizationDirectGraph2D
    {
        CONST_VTBL struct IMorseKernelVisualizationDirectGraph2DVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMorseKernelVisualizationDirectGraph2D_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMorseKernelVisualizationDirectGraph2D_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMorseKernelVisualizationDirectGraph2D_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMorseKernelVisualizationDirectGraph2D_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMorseKernelVisualizationDirectGraph2D_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMorseKernelVisualizationDirectGraph2D_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMorseKernelVisualizationDirectGraph2D_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IMorseKernelVisualizationDirectGraph2D_MoveLeftAtom(This)	\
    (This)->lpVtbl -> MoveLeftAtom(This)

#define IMorseKernelVisualizationDirectGraph2D_MoveRightAtom(This)	\
    (This)->lpVtbl -> MoveRightAtom(This)

#define IMorseKernelVisualizationDirectGraph2D_MoveUpAtom(This)	\
    (This)->lpVtbl -> MoveUpAtom(This)

#define IMorseKernelVisualizationDirectGraph2D_MoveDownAtom(This)	\
    (This)->lpVtbl -> MoveDownAtom(This)

#define IMorseKernelVisualizationDirectGraph2D_ZoomOutAtom(This)	\
    (This)->lpVtbl -> ZoomOutAtom(This)

#define IMorseKernelVisualizationDirectGraph2D_ZoomInAtom(This)	\
    (This)->lpVtbl -> ZoomInAtom(This)

#define IMorseKernelVisualizationDirectGraph2D_CenterView(This)	\
    (This)->lpVtbl -> CenterView(This)

#define IMorseKernelVisualizationDirectGraph2D_SetGraph(This,graph)	\
    (This)->lpVtbl -> SetGraph(This,graph)

#define IMorseKernelVisualizationDirectGraph2D_SetTestGraph(This)	\
    (This)->lpVtbl -> SetTestGraph(This)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IMorseKernelVisualizationDirectGraph2D_INTERFACE_DEFINED__ */



#ifndef __MorseKernelVisualizationATL_LIBRARY_DEFINED__
#define __MorseKernelVisualizationATL_LIBRARY_DEFINED__

/* library MorseKernelVisualizationATL */
/* [helpstring][custom][uuid][version] */ 


EXTERN_C const IID LIBID_MorseKernelVisualizationATL;

EXTERN_C const CLSID CLSID_CCompReg;

#ifdef __cplusplus

class DECLSPEC_UUID("C5F4E1EE-5450-4DED-B0A0-97941189B524")
CCompReg;
#endif

#ifndef ___IMorseKernelVisualizationDirect3DEvents_DISPINTERFACE_DEFINED__
#define ___IMorseKernelVisualizationDirect3DEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IMorseKernelVisualizationDirect3DEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IMorseKernelVisualizationDirect3DEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("FE6F9A99-FF69-44D9-89AD-685E6C7303CA")
    _IMorseKernelVisualizationDirect3DEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IMorseKernelVisualizationDirect3DEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IMorseKernelVisualizationDirect3DEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IMorseKernelVisualizationDirect3DEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IMorseKernelVisualizationDirect3DEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IMorseKernelVisualizationDirect3DEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IMorseKernelVisualizationDirect3DEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IMorseKernelVisualizationDirect3DEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IMorseKernelVisualizationDirect3DEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IMorseKernelVisualizationDirect3DEventsVtbl;

    interface _IMorseKernelVisualizationDirect3DEvents
    {
        CONST_VTBL struct _IMorseKernelVisualizationDirect3DEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IMorseKernelVisualizationDirect3DEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define _IMorseKernelVisualizationDirect3DEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define _IMorseKernelVisualizationDirect3DEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define _IMorseKernelVisualizationDirect3DEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define _IMorseKernelVisualizationDirect3DEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define _IMorseKernelVisualizationDirect3DEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define _IMorseKernelVisualizationDirect3DEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IMorseKernelVisualizationDirect3DEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_CMorseKernelVisualizationDirectGraph3D;

#ifdef __cplusplus

class DECLSPEC_UUID("3CF9772B-CC75-4596-A5EC-903D6ABD4983")
CMorseKernelVisualizationDirectGraph3D;
#endif

EXTERN_C const CLSID CLSID_CMorseKernelVisualizationDirectGraph2D;

#ifdef __cplusplus

class DECLSPEC_UUID("2BBDCC1B-8356-4536-9C86-0CBABD9158B0")
CMorseKernelVisualizationDirectGraph2D;
#endif
#endif /* __MorseKernelVisualizationATL_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

unsigned long             __RPC_USER  LPSAFEARRAY_UserSize(     unsigned long *, unsigned long            , LPSAFEARRAY * ); 
unsigned char * __RPC_USER  LPSAFEARRAY_UserMarshal(  unsigned long *, unsigned char *, LPSAFEARRAY * ); 
unsigned char * __RPC_USER  LPSAFEARRAY_UserUnmarshal(unsigned long *, unsigned char *, LPSAFEARRAY * ); 
void                      __RPC_USER  LPSAFEARRAY_UserFree(     unsigned long *, LPSAFEARRAY * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


