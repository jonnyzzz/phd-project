

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Sun Feb 27 22:40:44 2005
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

#ifndef ___MorseKernel2_h__
#define ___MorseKernel2_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IActionBase_FWD_DEFINED__
#define __IActionBase_FWD_DEFINED__
typedef interface IActionBase IActionBase;
#endif 	/* __IActionBase_FWD_DEFINED__ */


#ifndef __IResult_FWD_DEFINED__
#define __IResult_FWD_DEFINED__
typedef interface IResult IResult;
#endif 	/* __IResult_FWD_DEFINED__ */


#ifndef __IActionManager_FWD_DEFINED__
#define __IActionManager_FWD_DEFINED__
typedef interface IActionManager IActionManager;
#endif 	/* __IActionManager_FWD_DEFINED__ */


#ifndef __IParameters_FWD_DEFINED__
#define __IParameters_FWD_DEFINED__
typedef interface IParameters IParameters;
#endif 	/* __IParameters_FWD_DEFINED__ */


#ifndef __IProgressBarInfo_FWD_DEFINED__
#define __IProgressBarInfo_FWD_DEFINED__
typedef interface IProgressBarInfo IProgressBarInfo;
#endif 	/* __IProgressBarInfo_FWD_DEFINED__ */


#ifndef __IAction_FWD_DEFINED__
#define __IAction_FWD_DEFINED__
typedef interface IAction IAction;
#endif 	/* __IAction_FWD_DEFINED__ */


#ifndef __INode_FWD_DEFINED__
#define __INode_FWD_DEFINED__
typedef interface INode INode;
#endif 	/* __INode_FWD_DEFINED__ */


#ifndef __IActionFactory_FWD_DEFINED__
#define __IActionFactory_FWD_DEFINED__
typedef interface IActionFactory IActionFactory;
#endif 	/* __IActionFactory_FWD_DEFINED__ */


#ifndef __IActionAllocator_FWD_DEFINED__
#define __IActionAllocator_FWD_DEFINED__
typedef interface IActionAllocator IActionAllocator;
#endif 	/* __IActionAllocator_FWD_DEFINED__ */


#ifndef __IWritableActionAllocator_FWD_DEFINED__
#define __IWritableActionAllocator_FWD_DEFINED__
typedef interface IWritableActionAllocator IWritableActionAllocator;
#endif 	/* __IWritableActionAllocator_FWD_DEFINED__ */


#ifndef __IWritableActionManager_FWD_DEFINED__
#define __IWritableActionManager_FWD_DEFINED__
typedef interface IWritableActionManager IWritableActionManager;
#endif 	/* __IWritableActionManager_FWD_DEFINED__ */


#ifndef __IComponentRegistrar_FWD_DEFINED__
#define __IComponentRegistrar_FWD_DEFINED__
typedef interface IComponentRegistrar IComponentRegistrar;
#endif 	/* __IComponentRegistrar_FWD_DEFINED__ */


#ifndef __IGraphInfo_FWD_DEFINED__
#define __IGraphInfo_FWD_DEFINED__
typedef interface IGraphInfo IGraphInfo;
#endif 	/* __IGraphInfo_FWD_DEFINED__ */


#ifndef __IWritableGraphInfo_FWD_DEFINED__
#define __IWritableGraphInfo_FWD_DEFINED__
typedef interface IWritableGraphInfo IWritableGraphInfo;
#endif 	/* __IWritableGraphInfo_FWD_DEFINED__ */


#ifndef __IGraphResult_FWD_DEFINED__
#define __IGraphResult_FWD_DEFINED__
typedef interface IGraphResult IGraphResult;
#endif 	/* __IGraphResult_FWD_DEFINED__ */


#ifndef __IWritableGraphResult_FWD_DEFINED__
#define __IWritableGraphResult_FWD_DEFINED__
typedef interface IWritableGraphResult IWritableGraphResult;
#endif 	/* __IWritableGraphResult_FWD_DEFINED__ */


#ifndef __CActionAllocator_FWD_DEFINED__
#define __CActionAllocator_FWD_DEFINED__

#ifdef __cplusplus
typedef class CActionAllocator CActionAllocator;
#else
typedef struct CActionAllocator CActionAllocator;
#endif /* __cplusplus */

#endif 	/* __CActionAllocator_FWD_DEFINED__ */


#ifndef __CActionManagerImpl_FWD_DEFINED__
#define __CActionManagerImpl_FWD_DEFINED__

#ifdef __cplusplus
typedef class CActionManagerImpl CActionManagerImpl;
#else
typedef struct CActionManagerImpl CActionManagerImpl;
#endif /* __cplusplus */

#endif 	/* __CActionManagerImpl_FWD_DEFINED__ */


#ifndef __CCompReg_FWD_DEFINED__
#define __CCompReg_FWD_DEFINED__

#ifdef __cplusplus
typedef class CCompReg CCompReg;
#else
typedef struct CCompReg CCompReg;
#endif /* __cplusplus */

#endif 	/* __CCompReg_FWD_DEFINED__ */


#ifndef __CGraphInfoImpl_FWD_DEFINED__
#define __CGraphInfoImpl_FWD_DEFINED__

#ifdef __cplusplus
typedef class CGraphInfoImpl CGraphInfoImpl;
#else
typedef struct CGraphInfoImpl CGraphInfoImpl;
#endif /* __cplusplus */

#endif 	/* __CGraphInfoImpl_FWD_DEFINED__ */


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

#ifndef __IActionBase_INTERFACE_DEFINED__
#define __IActionBase_INTERFACE_DEFINED__

/* interface IActionBase */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IActionBase;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("285691E1-BFC9-4E8B-BE17-5B1CC2302ED9")
    IActionBase : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IActionBaseVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IActionBase * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IActionBase * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IActionBase * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IActionBase * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IActionBase * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IActionBase * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IActionBase * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IActionBaseVtbl;

    interface IActionBase
    {
        CONST_VTBL struct IActionBaseVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IActionBase_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IActionBase_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IActionBase_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IActionBase_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IActionBase_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IActionBase_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IActionBase_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IActionBase_INTERFACE_DEFINED__ */


#ifndef __IResult_INTERFACE_DEFINED__
#define __IResult_INTERFACE_DEFINED__

/* interface IResult */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IResult;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7D45A5-77FD-4E97-8C4A-76D3610CC875")
    IResult : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IResultVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IResult * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IResult * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IResult * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IResult * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IResult * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IResult * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IResult * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IResultVtbl;

    interface IResult
    {
        CONST_VTBL struct IResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IResult_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IResult_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IResult_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IResult_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IResult_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IResult_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IResult_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IResult_INTERFACE_DEFINED__ */


#ifndef __IActionManager_INTERFACE_DEFINED__
#define __IActionManager_INTERFACE_DEFINED__

/* interface IActionManager */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IActionManager;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("5EB44493-8FF9-486A-8ABD-09B9F232628A")
    IActionManager : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetLength( 
            /* [in] */ int *count) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetAction( 
            /* [in] */ int index,
            /* [retval][out] */ IActionBase **action) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IActionManagerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IActionManager * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IActionManager * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IActionManager * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IActionManager * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IActionManager * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IActionManager * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IActionManager * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetLength )( 
            IActionManager * This,
            /* [in] */ int *count);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetAction )( 
            IActionManager * This,
            /* [in] */ int index,
            /* [retval][out] */ IActionBase **action);
        
        END_INTERFACE
    } IActionManagerVtbl;

    interface IActionManager
    {
        CONST_VTBL struct IActionManagerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IActionManager_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IActionManager_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IActionManager_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IActionManager_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IActionManager_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IActionManager_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IActionManager_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IActionManager_GetLength(This,count)	\
    (This)->lpVtbl -> GetLength(This,count)

#define IActionManager_GetAction(This,index,action)	\
    (This)->lpVtbl -> GetAction(This,index,action)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IActionManager_GetLength_Proxy( 
    IActionManager * This,
    /* [in] */ int *count);


void __RPC_STUB IActionManager_GetLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IActionManager_GetAction_Proxy( 
    IActionManager * This,
    /* [in] */ int index,
    /* [retval][out] */ IActionBase **action);


void __RPC_STUB IActionManager_GetAction_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IActionManager_INTERFACE_DEFINED__ */


#ifndef __IParameters_INTERFACE_DEFINED__
#define __IParameters_INTERFACE_DEFINED__

/* interface IParameters */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IParameters;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("16C62C7B-6775-4D2B-9BD2-43624E01738B")
    IParameters : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IParametersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IParameters * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IParameters * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IParameters * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IParameters * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IParameters * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IParameters * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IParameters * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IParametersVtbl;

    interface IParameters
    {
        CONST_VTBL struct IParametersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IParameters_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IParameters_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IParameters_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IParameters_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IParameters_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IParameters_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IParameters_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IParameters_INTERFACE_DEFINED__ */


#ifndef __IProgressBarInfo_INTERFACE_DEFINED__
#define __IProgressBarInfo_INTERFACE_DEFINED__

/* interface IProgressBarInfo */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IProgressBarInfo;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("54E003E2-EAA0-4321-9A14-31CF8E5BCB84")
    IProgressBarInfo : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IProgressBarInfoVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IProgressBarInfo * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IProgressBarInfo * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IProgressBarInfo * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IProgressBarInfo * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IProgressBarInfo * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IProgressBarInfo * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IProgressBarInfo * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IProgressBarInfoVtbl;

    interface IProgressBarInfo
    {
        CONST_VTBL struct IProgressBarInfoVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IProgressBarInfo_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IProgressBarInfo_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IProgressBarInfo_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IProgressBarInfo_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IProgressBarInfo_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IProgressBarInfo_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IProgressBarInfo_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IProgressBarInfo_INTERFACE_DEFINED__ */


#ifndef __IAction_INTERFACE_DEFINED__
#define __IAction_INTERFACE_DEFINED__

/* interface IAction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IAction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("B94E10D8-08BD-405C-A435-0868DD86CD3C")
    IAction : public IActionBase
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetNextActionManager( 
            /* [retval][out] */ IActionManager **manager) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetActionParameters( 
            /* [in] */ IParameters *parameters) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Do( 
            /* [in] */ IResult *input,
            /* [retval][out] */ IResult **output) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetProgressBarInfo( 
            /* [in] */ IProgressBarInfo *pinfo) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IActionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IAction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IAction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IAction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IAction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IAction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IAction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IAction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetNextActionManager )( 
            IAction * This,
            /* [retval][out] */ IActionManager **manager);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            IAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            IAction * This,
            /* [in] */ IResult *input,
            /* [retval][out] */ IResult **output);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            IAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        END_INTERFACE
    } IActionVtbl;

    interface IAction
    {
        CONST_VTBL struct IActionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IAction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IAction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IAction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IAction_GetNextActionManager(This,manager)	\
    (This)->lpVtbl -> GetNextActionManager(This,manager)

#define IAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define IAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)

#define IAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IAction_GetNextActionManager_Proxy( 
    IAction * This,
    /* [retval][out] */ IActionManager **manager);


void __RPC_STUB IAction_GetNextActionManager_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IAction_SetActionParameters_Proxy( 
    IAction * This,
    /* [in] */ IParameters *parameters);


void __RPC_STUB IAction_SetActionParameters_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IAction_Do_Proxy( 
    IAction * This,
    /* [in] */ IResult *input,
    /* [retval][out] */ IResult **output);


void __RPC_STUB IAction_Do_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IAction_SetProgressBarInfo_Proxy( 
    IAction * This,
    /* [in] */ IProgressBarInfo *pinfo);


void __RPC_STUB IAction_SetProgressBarInfo_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAction_INTERFACE_DEFINED__ */


#ifndef __INode_INTERFACE_DEFINED__
#define __INode_INTERFACE_DEFINED__

/* interface INode */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_INode;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("D3BEDA0D-1771-4493-BB5C-E93384792B2A")
    INode : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetActionManager( 
            /* [retval][out] */ IActionManager **manager) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetResult( 
            /* [retval][out] */ IResult **result) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct INodeVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            INode * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            INode * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            INode * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            INode * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            INode * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            INode * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            INode * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetActionManager )( 
            INode * This,
            /* [retval][out] */ IActionManager **manager);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetResult )( 
            INode * This,
            /* [retval][out] */ IResult **result);
        
        END_INTERFACE
    } INodeVtbl;

    interface INode
    {
        CONST_VTBL struct INodeVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define INode_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define INode_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define INode_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define INode_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define INode_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define INode_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define INode_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define INode_GetActionManager(This,manager)	\
    (This)->lpVtbl -> GetActionManager(This,manager)

#define INode_GetResult(This,result)	\
    (This)->lpVtbl -> GetResult(This,result)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE INode_GetActionManager_Proxy( 
    INode * This,
    /* [retval][out] */ IActionManager **manager);


void __RPC_STUB INode_GetActionManager_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE INode_GetResult_Proxy( 
    INode * This,
    /* [retval][out] */ IResult **result);


void __RPC_STUB INode_GetResult_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __INode_INTERFACE_DEFINED__ */


#ifndef __IActionFactory_INTERFACE_DEFINED__
#define __IActionFactory_INTERFACE_DEFINED__

/* interface IActionFactory */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IActionFactory;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("35F624D3-EB6C-4F79-AB1E-C01795A08C5A")
    IActionFactory : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE CanCreateAction( 
            /* [in] */ INode *node,
            /* [retval][out] */ VARIANT_BOOL **result) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CreateAction( 
            /* [in] */ INode *node,
            /* [retval][out] */ IActionBase **action) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IActionFactoryVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IActionFactory * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IActionFactory * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IActionFactory * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IActionFactory * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IActionFactory * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IActionFactory * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IActionFactory * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanCreateAction )( 
            IActionFactory * This,
            /* [in] */ INode *node,
            /* [retval][out] */ VARIANT_BOOL **result);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CreateAction )( 
            IActionFactory * This,
            /* [in] */ INode *node,
            /* [retval][out] */ IActionBase **action);
        
        END_INTERFACE
    } IActionFactoryVtbl;

    interface IActionFactory
    {
        CONST_VTBL struct IActionFactoryVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IActionFactory_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IActionFactory_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IActionFactory_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IActionFactory_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IActionFactory_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IActionFactory_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IActionFactory_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IActionFactory_CanCreateAction(This,node,result)	\
    (This)->lpVtbl -> CanCreateAction(This,node,result)

#define IActionFactory_CreateAction(This,node,action)	\
    (This)->lpVtbl -> CreateAction(This,node,action)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IActionFactory_CanCreateAction_Proxy( 
    IActionFactory * This,
    /* [in] */ INode *node,
    /* [retval][out] */ VARIANT_BOOL **result);


void __RPC_STUB IActionFactory_CanCreateAction_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IActionFactory_CreateAction_Proxy( 
    IActionFactory * This,
    /* [in] */ INode *node,
    /* [retval][out] */ IActionBase **action);


void __RPC_STUB IActionFactory_CreateAction_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IActionFactory_INTERFACE_DEFINED__ */


#ifndef __IActionAllocator_INTERFACE_DEFINED__
#define __IActionAllocator_INTERFACE_DEFINED__

/* interface IActionAllocator */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IActionAllocator;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9D90D301-E998-4229-98C0-27C59690308D")
    IActionAllocator : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE AllocateActionManager( 
            /* [in] */ INode *node,
            /* [retval][out] */ IActionManager **manager) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IActionAllocatorVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IActionAllocator * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IActionAllocator * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IActionAllocator * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IActionAllocator * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IActionAllocator * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IActionAllocator * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IActionAllocator * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *AllocateActionManager )( 
            IActionAllocator * This,
            /* [in] */ INode *node,
            /* [retval][out] */ IActionManager **manager);
        
        END_INTERFACE
    } IActionAllocatorVtbl;

    interface IActionAllocator
    {
        CONST_VTBL struct IActionAllocatorVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IActionAllocator_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IActionAllocator_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IActionAllocator_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IActionAllocator_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IActionAllocator_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IActionAllocator_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IActionAllocator_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IActionAllocator_AllocateActionManager(This,node,manager)	\
    (This)->lpVtbl -> AllocateActionManager(This,node,manager)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IActionAllocator_AllocateActionManager_Proxy( 
    IActionAllocator * This,
    /* [in] */ INode *node,
    /* [retval][out] */ IActionManager **manager);


void __RPC_STUB IActionAllocator_AllocateActionManager_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IActionAllocator_INTERFACE_DEFINED__ */


#ifndef __IWritableActionAllocator_INTERFACE_DEFINED__
#define __IWritableActionAllocator_INTERFACE_DEFINED__

/* interface IWritableActionAllocator */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IWritableActionAllocator;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BC2B7099-B5A6-4D0B-BDE0-DA027E87FF93")
    IWritableActionAllocator : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE RegisterActionFactory( 
            /* [in] */ IActionFactory *action) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWritableActionAllocatorVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWritableActionAllocator * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWritableActionAllocator * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWritableActionAllocator * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IWritableActionAllocator * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IWritableActionAllocator * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IWritableActionAllocator * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IWritableActionAllocator * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *RegisterActionFactory )( 
            IWritableActionAllocator * This,
            /* [in] */ IActionFactory *action);
        
        END_INTERFACE
    } IWritableActionAllocatorVtbl;

    interface IWritableActionAllocator
    {
        CONST_VTBL struct IWritableActionAllocatorVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWritableActionAllocator_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IWritableActionAllocator_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IWritableActionAllocator_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IWritableActionAllocator_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IWritableActionAllocator_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IWritableActionAllocator_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IWritableActionAllocator_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IWritableActionAllocator_RegisterActionFactory(This,action)	\
    (This)->lpVtbl -> RegisterActionFactory(This,action)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IWritableActionAllocator_RegisterActionFactory_Proxy( 
    IWritableActionAllocator * This,
    /* [in] */ IActionFactory *action);


void __RPC_STUB IWritableActionAllocator_RegisterActionFactory_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IWritableActionAllocator_INTERFACE_DEFINED__ */


#ifndef __IWritableActionManager_INTERFACE_DEFINED__
#define __IWritableActionManager_INTERFACE_DEFINED__

/* interface IWritableActionManager */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IWritableActionManager;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("E20C06D8-1C51-455C-B306-33D0635F1E52")
    IWritableActionManager : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE AddAction( 
            /* [in] */ IActionBase *action) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWritableActionManagerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWritableActionManager * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWritableActionManager * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWritableActionManager * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IWritableActionManager * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IWritableActionManager * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IWritableActionManager * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IWritableActionManager * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *AddAction )( 
            IWritableActionManager * This,
            /* [in] */ IActionBase *action);
        
        END_INTERFACE
    } IWritableActionManagerVtbl;

    interface IWritableActionManager
    {
        CONST_VTBL struct IWritableActionManagerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWritableActionManager_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IWritableActionManager_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IWritableActionManager_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IWritableActionManager_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IWritableActionManager_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IWritableActionManager_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IWritableActionManager_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IWritableActionManager_AddAction(This,action)	\
    (This)->lpVtbl -> AddAction(This,action)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IWritableActionManager_AddAction_Proxy( 
    IWritableActionManager * This,
    /* [in] */ IActionBase *action);


void __RPC_STUB IWritableActionManager_AddAction_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IWritableActionManager_INTERFACE_DEFINED__ */


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


#ifndef __IGraphInfo_INTERFACE_DEFINED__
#define __IGraphInfo_INTERFACE_DEFINED__

/* interface IGraphInfo */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IGraphInfo;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("0641C669-B362-48C9-8B73-D02B6E252A9D")
    IGraphInfo : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetNodes( 
            /* [retval][out] */ int *value) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetEdges( 
            /* [retval][out] */ int *value) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetDimension( 
            /* [retval][out] */ int *value) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetMinimum( 
            /* [in] */ int index,
            /* [retval][out] */ double *value) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetMaximum( 
            /* [in] */ int index,
            /* [retval][out] */ double *value) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetGridNumber( 
            /* [in] */ int index,
            /* [retval][out] */ int *value) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetGridSize( 
            /* [in] */ int index,
            /* [retval][out] */ double *value) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IGraphInfoVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IGraphInfo * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IGraphInfo * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IGraphInfo * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IGraphInfo * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IGraphInfo * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IGraphInfo * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IGraphInfo * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetNodes )( 
            IGraphInfo * This,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetEdges )( 
            IGraphInfo * This,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetDimension )( 
            IGraphInfo * This,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetMinimum )( 
            IGraphInfo * This,
            /* [in] */ int index,
            /* [retval][out] */ double *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetMaximum )( 
            IGraphInfo * This,
            /* [in] */ int index,
            /* [retval][out] */ double *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetGridNumber )( 
            IGraphInfo * This,
            /* [in] */ int index,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetGridSize )( 
            IGraphInfo * This,
            /* [in] */ int index,
            /* [retval][out] */ double *value);
        
        END_INTERFACE
    } IGraphInfoVtbl;

    interface IGraphInfo
    {
        CONST_VTBL struct IGraphInfoVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IGraphInfo_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IGraphInfo_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IGraphInfo_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IGraphInfo_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IGraphInfo_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IGraphInfo_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IGraphInfo_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IGraphInfo_GetNodes(This,value)	\
    (This)->lpVtbl -> GetNodes(This,value)

#define IGraphInfo_GetEdges(This,value)	\
    (This)->lpVtbl -> GetEdges(This,value)

#define IGraphInfo_GetDimension(This,value)	\
    (This)->lpVtbl -> GetDimension(This,value)

#define IGraphInfo_GetMinimum(This,index,value)	\
    (This)->lpVtbl -> GetMinimum(This,index,value)

#define IGraphInfo_GetMaximum(This,index,value)	\
    (This)->lpVtbl -> GetMaximum(This,index,value)

#define IGraphInfo_GetGridNumber(This,index,value)	\
    (This)->lpVtbl -> GetGridNumber(This,index,value)

#define IGraphInfo_GetGridSize(This,index,value)	\
    (This)->lpVtbl -> GetGridSize(This,index,value)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_GetNodes_Proxy( 
    IGraphInfo * This,
    /* [retval][out] */ int *value);


void __RPC_STUB IGraphInfo_GetNodes_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_GetEdges_Proxy( 
    IGraphInfo * This,
    /* [retval][out] */ int *value);


void __RPC_STUB IGraphInfo_GetEdges_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_GetDimension_Proxy( 
    IGraphInfo * This,
    /* [retval][out] */ int *value);


void __RPC_STUB IGraphInfo_GetDimension_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_GetMinimum_Proxy( 
    IGraphInfo * This,
    /* [in] */ int index,
    /* [retval][out] */ double *value);


void __RPC_STUB IGraphInfo_GetMinimum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_GetMaximum_Proxy( 
    IGraphInfo * This,
    /* [in] */ int index,
    /* [retval][out] */ double *value);


void __RPC_STUB IGraphInfo_GetMaximum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_GetGridNumber_Proxy( 
    IGraphInfo * This,
    /* [in] */ int index,
    /* [retval][out] */ int *value);


void __RPC_STUB IGraphInfo_GetGridNumber_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_GetGridSize_Proxy( 
    IGraphInfo * This,
    /* [in] */ int index,
    /* [retval][out] */ double *value);


void __RPC_STUB IGraphInfo_GetGridSize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IGraphInfo_INTERFACE_DEFINED__ */


#ifndef __IWritableGraphInfo_INTERFACE_DEFINED__
#define __IWritableGraphInfo_INTERFACE_DEFINED__

/* interface IWritableGraphInfo */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IWritableGraphInfo;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("5F89F9F3-AB8D-4129-A752-8A4258A8ECE9")
    IWritableGraphInfo : public IDispatch
    {
    public:
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE AddGraph( 
            /* [in] */ void **graph) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWritableGraphInfoVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWritableGraphInfo * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWritableGraphInfo * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWritableGraphInfo * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IWritableGraphInfo * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IWritableGraphInfo * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IWritableGraphInfo * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IWritableGraphInfo * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *AddGraph )( 
            IWritableGraphInfo * This,
            /* [in] */ void **graph);
        
        END_INTERFACE
    } IWritableGraphInfoVtbl;

    interface IWritableGraphInfo
    {
        CONST_VTBL struct IWritableGraphInfoVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWritableGraphInfo_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IWritableGraphInfo_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IWritableGraphInfo_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IWritableGraphInfo_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IWritableGraphInfo_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IWritableGraphInfo_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IWritableGraphInfo_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IWritableGraphInfo_AddGraph(This,graph)	\
    (This)->lpVtbl -> AddGraph(This,graph)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IWritableGraphInfo_AddGraph_Proxy( 
    IWritableGraphInfo * This,
    /* [in] */ void **graph);


void __RPC_STUB IWritableGraphInfo_AddGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IWritableGraphInfo_INTERFACE_DEFINED__ */


#ifndef __IGraphResult_INTERFACE_DEFINED__
#define __IGraphResult_INTERFACE_DEFINED__

/* interface IGraphResult */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IGraphResult;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("6E606370-04E2-4BCB-852C-313A7D4BAD15")
    IGraphResult : public IResult
    {
    public:
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE GetGraph( 
            /* [in] */ int index,
            /* [retval][out] */ void **graph) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE GetCount( 
            /* [retval][out] */ int *count) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetGraphInfo( 
            /* [retval][out] */ IGraphInfo **info) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetGraphInfoAt( 
            /* [in] */ int index,
            /* [retval][out] */ IGraphInfo **info) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE IsStrongComponent( 
            /* [retval][out] */ VARIANT_BOOL *value) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IGraphResultVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IGraphResult * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IGraphResult * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IGraphResult * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IGraphResult * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IGraphResult * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IGraphResult * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IGraphResult * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *GetGraph )( 
            IGraphResult * This,
            /* [in] */ int index,
            /* [retval][out] */ void **graph);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *GetCount )( 
            IGraphResult * This,
            /* [retval][out] */ int *count);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetGraphInfo )( 
            IGraphResult * This,
            /* [retval][out] */ IGraphInfo **info);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetGraphInfoAt )( 
            IGraphResult * This,
            /* [in] */ int index,
            /* [retval][out] */ IGraphInfo **info);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *IsStrongComponent )( 
            IGraphResult * This,
            /* [retval][out] */ VARIANT_BOOL *value);
        
        END_INTERFACE
    } IGraphResultVtbl;

    interface IGraphResult
    {
        CONST_VTBL struct IGraphResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IGraphResult_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IGraphResult_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IGraphResult_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IGraphResult_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IGraphResult_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IGraphResult_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IGraphResult_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IGraphResult_GetGraph(This,index,graph)	\
    (This)->lpVtbl -> GetGraph(This,index,graph)

#define IGraphResult_GetCount(This,count)	\
    (This)->lpVtbl -> GetCount(This,count)

#define IGraphResult_GetGraphInfo(This,info)	\
    (This)->lpVtbl -> GetGraphInfo(This,info)

#define IGraphResult_GetGraphInfoAt(This,index,info)	\
    (This)->lpVtbl -> GetGraphInfoAt(This,index,info)

#define IGraphResult_IsStrongComponent(This,value)	\
    (This)->lpVtbl -> IsStrongComponent(This,value)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IGraphResult_GetGraph_Proxy( 
    IGraphResult * This,
    /* [in] */ int index,
    /* [retval][out] */ void **graph);


void __RPC_STUB IGraphResult_GetGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IGraphResult_GetCount_Proxy( 
    IGraphResult * This,
    /* [retval][out] */ int *count);


void __RPC_STUB IGraphResult_GetCount_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphResult_GetGraphInfo_Proxy( 
    IGraphResult * This,
    /* [retval][out] */ IGraphInfo **info);


void __RPC_STUB IGraphResult_GetGraphInfo_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphResult_GetGraphInfoAt_Proxy( 
    IGraphResult * This,
    /* [in] */ int index,
    /* [retval][out] */ IGraphInfo **info);


void __RPC_STUB IGraphResult_GetGraphInfoAt_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphResult_IsStrongComponent_Proxy( 
    IGraphResult * This,
    /* [retval][out] */ VARIANT_BOOL *value);


void __RPC_STUB IGraphResult_IsStrongComponent_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IGraphResult_INTERFACE_DEFINED__ */


#ifndef __IWritableGraphResult_INTERFACE_DEFINED__
#define __IWritableGraphResult_INTERFACE_DEFINED__

/* interface IWritableGraphResult */
/* [local][hidden][unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IWritableGraphResult;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("6ED8D0EA-3E9C-441A-96C6-EEB2AFCBE27D")
    IWritableGraphResult : public IDispatch
    {
    public:
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE AddGraph( 
            /* [in] */ void *graph) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWritableGraphResultVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWritableGraphResult * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWritableGraphResult * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWritableGraphResult * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IWritableGraphResult * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IWritableGraphResult * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IWritableGraphResult * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IWritableGraphResult * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *AddGraph )( 
            IWritableGraphResult * This,
            /* [in] */ void *graph);
        
        END_INTERFACE
    } IWritableGraphResultVtbl;

    interface IWritableGraphResult
    {
        CONST_VTBL struct IWritableGraphResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWritableGraphResult_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IWritableGraphResult_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IWritableGraphResult_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IWritableGraphResult_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IWritableGraphResult_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IWritableGraphResult_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IWritableGraphResult_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IWritableGraphResult_AddGraph(This,graph)	\
    (This)->lpVtbl -> AddGraph(This,graph)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IWritableGraphResult_AddGraph_Proxy( 
    IWritableGraphResult * This,
    /* [in] */ void *graph);


void __RPC_STUB IWritableGraphResult_AddGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IWritableGraphResult_INTERFACE_DEFINED__ */



#ifndef __MorseKernel2_LIBRARY_DEFINED__
#define __MorseKernel2_LIBRARY_DEFINED__

/* library MorseKernel2 */
/* [helpstring][custom][uuid][version] */ 


EXTERN_C const IID LIBID_MorseKernel2;

EXTERN_C const CLSID CLSID_CActionAllocator;

#ifdef __cplusplus

class DECLSPEC_UUID("43EAE42D-D986-4DAB-9D7D-D4B725E77AB0")
CActionAllocator;
#endif

EXTERN_C const CLSID CLSID_CActionManagerImpl;

#ifdef __cplusplus

class DECLSPEC_UUID("860DAF52-F263-4F92-A8BE-673E99A9959F")
CActionManagerImpl;
#endif

EXTERN_C const CLSID CLSID_CCompReg;

#ifdef __cplusplus

class DECLSPEC_UUID("84035475-16DE-4504-ABF2-5C734E46A96A")
CCompReg;
#endif

EXTERN_C const CLSID CLSID_CGraphInfoImpl;

#ifdef __cplusplus

class DECLSPEC_UUID("1FCB1E52-C321-4E44-8BA6-83DA8C532365")
CGraphInfoImpl;
#endif
#endif /* __MorseKernel2_LIBRARY_DEFINED__ */

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


