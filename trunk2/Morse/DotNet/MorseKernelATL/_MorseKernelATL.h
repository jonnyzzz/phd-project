

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Thu Feb 10 14:27:50 2005
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

#ifndef ___MorseKernelATL_h__
#define ___MorseKernelATL_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IGraphInfo_FWD_DEFINED__
#define __IGraphInfo_FWD_DEFINED__
typedef interface IGraphInfo IGraphInfo;
#endif 	/* __IGraphInfo_FWD_DEFINED__ */


#ifndef __IParams_FWD_DEFINED__
#define __IParams_FWD_DEFINED__
typedef interface IParams IParams;
#endif 	/* __IParams_FWD_DEFINED__ */


#ifndef __ISubdevideParams_FWD_DEFINED__
#define __ISubdevideParams_FWD_DEFINED__
typedef interface ISubdevideParams ISubdevideParams;
#endif 	/* __ISubdevideParams_FWD_DEFINED__ */


#ifndef __IExtendableParams_FWD_DEFINED__
#define __IExtendableParams_FWD_DEFINED__
typedef interface IExtendableParams IExtendableParams;
#endif 	/* __IExtendableParams_FWD_DEFINED__ */


#ifndef __IExtendablePointParams_FWD_DEFINED__
#define __IExtendablePointParams_FWD_DEFINED__
typedef interface IExtendablePointParams IExtendablePointParams;
#endif 	/* __IExtendablePointParams_FWD_DEFINED__ */


#ifndef __ISubdevidePointParams_FWD_DEFINED__
#define __ISubdevidePointParams_FWD_DEFINED__
typedef interface ISubdevidePointParams ISubdevidePointParams;
#endif 	/* __ISubdevidePointParams_FWD_DEFINED__ */


#ifndef __IHomotopParams_FWD_DEFINED__
#define __IHomotopParams_FWD_DEFINED__
typedef interface IHomotopParams IHomotopParams;
#endif 	/* __IHomotopParams_FWD_DEFINED__ */


#ifndef __IKernelPointer_FWD_DEFINED__
#define __IKernelPointer_FWD_DEFINED__
typedef interface IKernelPointer IKernelPointer;
#endif 	/* __IKernelPointer_FWD_DEFINED__ */


#ifndef __IKernelNode_FWD_DEFINED__
#define __IKernelNode_FWD_DEFINED__
typedef interface IKernelNode IKernelNode;
#endif 	/* __IKernelNode_FWD_DEFINED__ */


#ifndef __IGraph_FWD_DEFINED__
#define __IGraph_FWD_DEFINED__
typedef interface IGraph IGraph;
#endif 	/* __IGraph_FWD_DEFINED__ */


#ifndef __ISubdevidable_FWD_DEFINED__
#define __ISubdevidable_FWD_DEFINED__
typedef interface ISubdevidable ISubdevidable;
#endif 	/* __ISubdevidable_FWD_DEFINED__ */


#ifndef __ISubdevidablePoint_FWD_DEFINED__
#define __ISubdevidablePoint_FWD_DEFINED__
typedef interface ISubdevidablePoint ISubdevidablePoint;
#endif 	/* __ISubdevidablePoint_FWD_DEFINED__ */


#ifndef __IExtendable_FWD_DEFINED__
#define __IExtendable_FWD_DEFINED__
typedef interface IExtendable IExtendable;
#endif 	/* __IExtendable_FWD_DEFINED__ */


#ifndef __IMorsable_FWD_DEFINED__
#define __IMorsable_FWD_DEFINED__
typedef interface IMorsable IMorsable;
#endif 	/* __IMorsable_FWD_DEFINED__ */


#ifndef __IExportData_FWD_DEFINED__
#define __IExportData_FWD_DEFINED__
typedef interface IExportData IExportData;
#endif 	/* __IExportData_FWD_DEFINED__ */


#ifndef __IHomotopFind_FWD_DEFINED__
#define __IHomotopFind_FWD_DEFINED__
typedef interface IHomotopFind IHomotopFind;
#endif 	/* __IHomotopFind_FWD_DEFINED__ */


#ifndef __IComputationResult_FWD_DEFINED__
#define __IComputationResult_FWD_DEFINED__
typedef interface IComputationResult IComputationResult;
#endif 	/* __IComputationResult_FWD_DEFINED__ */


#ifndef __IComputationGraphResult_FWD_DEFINED__
#define __IComputationGraphResult_FWD_DEFINED__
typedef interface IComputationGraphResult IComputationGraphResult;
#endif 	/* __IComputationGraphResult_FWD_DEFINED__ */


#ifndef __IComputationExtendingResult_FWD_DEFINED__
#define __IComputationExtendingResult_FWD_DEFINED__
typedef interface IComputationExtendingResult IComputationExtendingResult;
#endif 	/* __IComputationExtendingResult_FWD_DEFINED__ */


#ifndef __IComputationMorseResult_FWD_DEFINED__
#define __IComputationMorseResult_FWD_DEFINED__
typedef interface IComputationMorseResult IComputationMorseResult;
#endif 	/* __IComputationMorseResult_FWD_DEFINED__ */


#ifndef __IGroupNode_FWD_DEFINED__
#define __IGroupNode_FWD_DEFINED__
typedef interface IGroupNode IGroupNode;
#endif 	/* __IGroupNode_FWD_DEFINED__ */


#ifndef __IComponentRegistrar_FWD_DEFINED__
#define __IComponentRegistrar_FWD_DEFINED__
typedef interface IComponentRegistrar IComponentRegistrar;
#endif 	/* __IComponentRegistrar_FWD_DEFINED__ */


#ifndef __IFunctionEvents_FWD_DEFINED__
#define __IFunctionEvents_FWD_DEFINED__
typedef interface IFunctionEvents IFunctionEvents;
#endif 	/* __IFunctionEvents_FWD_DEFINED__ */


#ifndef __IFunction_FWD_DEFINED__
#define __IFunction_FWD_DEFINED__
typedef interface IFunction IFunction;
#endif 	/* __IFunction_FWD_DEFINED__ */


#ifndef __IKernel_FWD_DEFINED__
#define __IKernel_FWD_DEFINED__
typedef interface IKernel IKernel;
#endif 	/* __IKernel_FWD_DEFINED__ */


#ifndef __IComputationGraphResultExt_FWD_DEFINED__
#define __IComputationGraphResultExt_FWD_DEFINED__
typedef interface IComputationGraphResultExt IComputationGraphResultExt;
#endif 	/* __IComputationGraphResultExt_FWD_DEFINED__ */


#ifndef __IDummy_FWD_DEFINED__
#define __IDummy_FWD_DEFINED__
typedef interface IDummy IDummy;
#endif 	/* __IDummy_FWD_DEFINED__ */


#ifndef __IMorseSpectrum_FWD_DEFINED__
#define __IMorseSpectrum_FWD_DEFINED__
typedef interface IMorseSpectrum IMorseSpectrum;
#endif 	/* __IMorseSpectrum_FWD_DEFINED__ */


#ifndef __IProjectiveBundle_FWD_DEFINED__
#define __IProjectiveBundle_FWD_DEFINED__
typedef interface IProjectiveBundle IProjectiveBundle;
#endif 	/* __IProjectiveBundle_FWD_DEFINED__ */


#ifndef __ISymbolicImage_FWD_DEFINED__
#define __ISymbolicImage_FWD_DEFINED__
typedef interface ISymbolicImage ISymbolicImage;
#endif 	/* __ISymbolicImage_FWD_DEFINED__ */


#ifndef __ISymbolicImageGraph_FWD_DEFINED__
#define __ISymbolicImageGraph_FWD_DEFINED__
typedef interface ISymbolicImageGraph ISymbolicImageGraph;
#endif 	/* __ISymbolicImageGraph_FWD_DEFINED__ */


#ifndef __ISymbolicImageGroup_FWD_DEFINED__
#define __ISymbolicImageGroup_FWD_DEFINED__
typedef interface ISymbolicImageGroup ISymbolicImageGroup;
#endif 	/* __ISymbolicImageGroup_FWD_DEFINED__ */


#ifndef __IProjectiveBundleGraph_FWD_DEFINED__
#define __IProjectiveBundleGraph_FWD_DEFINED__
typedef interface IProjectiveBundleGraph IProjectiveBundleGraph;
#endif 	/* __IProjectiveBundleGraph_FWD_DEFINED__ */


#ifndef __IProjectiveBundleGroup_FWD_DEFINED__
#define __IProjectiveBundleGroup_FWD_DEFINED__
typedef interface IProjectiveBundleGroup IProjectiveBundleGroup;
#endif 	/* __IProjectiveBundleGroup_FWD_DEFINED__ */


#ifndef __ISerializerOutputData_FWD_DEFINED__
#define __ISerializerOutputData_FWD_DEFINED__
typedef interface ISerializerOutputData ISerializerOutputData;
#endif 	/* __ISerializerOutputData_FWD_DEFINED__ */


#ifndef __ISerializerInputData_FWD_DEFINED__
#define __ISerializerInputData_FWD_DEFINED__
typedef interface ISerializerInputData ISerializerInputData;
#endif 	/* __ISerializerInputData_FWD_DEFINED__ */


#ifndef __ISerializer_FWD_DEFINED__
#define __ISerializer_FWD_DEFINED__
typedef interface ISerializer ISerializer;
#endif 	/* __ISerializer_FWD_DEFINED__ */


#ifndef __CGraphInfo_FWD_DEFINED__
#define __CGraphInfo_FWD_DEFINED__

#ifdef __cplusplus
typedef class CGraphInfo CGraphInfo;
#else
typedef struct CGraphInfo CGraphInfo;
#endif /* __cplusplus */

#endif 	/* __CGraphInfo_FWD_DEFINED__ */


#ifndef __CCompReg_FWD_DEFINED__
#define __CCompReg_FWD_DEFINED__

#ifdef __cplusplus
typedef class CCompReg CCompReg;
#else
typedef struct CCompReg CCompReg;
#endif /* __cplusplus */

#endif 	/* __CCompReg_FWD_DEFINED__ */


#ifndef __CFunction_FWD_DEFINED__
#define __CFunction_FWD_DEFINED__

#ifdef __cplusplus
typedef class CFunction CFunction;
#else
typedef struct CFunction CFunction;
#endif /* __cplusplus */

#endif 	/* __CFunction_FWD_DEFINED__ */


#ifndef __IKernelEvents_FWD_DEFINED__
#define __IKernelEvents_FWD_DEFINED__
typedef interface IKernelEvents IKernelEvents;
#endif 	/* __IKernelEvents_FWD_DEFINED__ */


#ifndef __CKernel_FWD_DEFINED__
#define __CKernel_FWD_DEFINED__

#ifdef __cplusplus
typedef class CKernel CKernel;
#else
typedef struct CKernel CKernel;
#endif /* __cplusplus */

#endif 	/* __CKernel_FWD_DEFINED__ */


#ifndef __CComputationGraphResult_FWD_DEFINED__
#define __CComputationGraphResult_FWD_DEFINED__

#ifdef __cplusplus
typedef class CComputationGraphResult CComputationGraphResult;
#else
typedef struct CComputationGraphResult CComputationGraphResult;
#endif /* __cplusplus */

#endif 	/* __CComputationGraphResult_FWD_DEFINED__ */


#ifndef __CDummy_FWD_DEFINED__
#define __CDummy_FWD_DEFINED__

#ifdef __cplusplus
typedef class CDummy CDummy;
#else
typedef struct CDummy CDummy;
#endif /* __cplusplus */

#endif 	/* __CDummy_FWD_DEFINED__ */


#ifndef __CMorseSpectrum_FWD_DEFINED__
#define __CMorseSpectrum_FWD_DEFINED__

#ifdef __cplusplus
typedef class CMorseSpectrum CMorseSpectrum;
#else
typedef struct CMorseSpectrum CMorseSpectrum;
#endif /* __cplusplus */

#endif 	/* __CMorseSpectrum_FWD_DEFINED__ */


#ifndef __CSymbolicImageGraph_FWD_DEFINED__
#define __CSymbolicImageGraph_FWD_DEFINED__

#ifdef __cplusplus
typedef class CSymbolicImageGraph CSymbolicImageGraph;
#else
typedef struct CSymbolicImageGraph CSymbolicImageGraph;
#endif /* __cplusplus */

#endif 	/* __CSymbolicImageGraph_FWD_DEFINED__ */


#ifndef __CSymbolicImageGroup_FWD_DEFINED__
#define __CSymbolicImageGroup_FWD_DEFINED__

#ifdef __cplusplus
typedef class CSymbolicImageGroup CSymbolicImageGroup;
#else
typedef struct CSymbolicImageGroup CSymbolicImageGroup;
#endif /* __cplusplus */

#endif 	/* __CSymbolicImageGroup_FWD_DEFINED__ */


#ifndef __CProjectiveBundleGraph_FWD_DEFINED__
#define __CProjectiveBundleGraph_FWD_DEFINED__

#ifdef __cplusplus
typedef class CProjectiveBundleGraph CProjectiveBundleGraph;
#else
typedef struct CProjectiveBundleGraph CProjectiveBundleGraph;
#endif /* __cplusplus */

#endif 	/* __CProjectiveBundleGraph_FWD_DEFINED__ */


#ifndef __CProjectiveBundleGroup_FWD_DEFINED__
#define __CProjectiveBundleGroup_FWD_DEFINED__

#ifdef __cplusplus
typedef class CProjectiveBundleGroup CProjectiveBundleGroup;
#else
typedef struct CProjectiveBundleGroup CProjectiveBundleGroup;
#endif /* __cplusplus */

#endif 	/* __CProjectiveBundleGroup_FWD_DEFINED__ */


#ifndef __CSerializer_FWD_DEFINED__
#define __CSerializer_FWD_DEFINED__

#ifdef __cplusplus
typedef class CSerializer CSerializer;
#else
typedef struct CSerializer CSerializer;
#endif /* __cplusplus */

#endif 	/* __CSerializer_FWD_DEFINED__ */


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

#ifndef __IGraphInfo_INTERFACE_DEFINED__
#define __IGraphInfo_INTERFACE_DEFINED__

/* interface IGraphInfo */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IGraphInfo;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("CE2B6190-CBC5-4104-A0E0-D7B3FE567867")
    IGraphInfo : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE dimension( 
            /* [retval][out] */ LONG *dimension) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE gridNumber( 
            /* [in] */ LONG id,
            /* [retval][out] */ LONG *grid) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE gridSize( 
            /* [in] */ LONG id,
            /* [retval][out] */ DOUBLE *size) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE spaceMin( 
            /* [in] */ LONG id,
            /* [retval][out] */ DOUBLE *size) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE spaceMax( 
            /* [in] */ LONG id,
            /* [retval][out] */ DOUBLE *size) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE edges( 
            /* [retval][out] */ LONG *num) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE nodes( 
            /* [retval][out] */ LONG *num) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE setGraph( 
            /* [in] */ void **graph) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE setGraphComponents( 
            /* [in] */ void **gcmps) = 0;
        
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
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *dimension )( 
            IGraphInfo * This,
            /* [retval][out] */ LONG *dimension);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *gridNumber )( 
            IGraphInfo * This,
            /* [in] */ LONG id,
            /* [retval][out] */ LONG *grid);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *gridSize )( 
            IGraphInfo * This,
            /* [in] */ LONG id,
            /* [retval][out] */ DOUBLE *size);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *spaceMin )( 
            IGraphInfo * This,
            /* [in] */ LONG id,
            /* [retval][out] */ DOUBLE *size);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *spaceMax )( 
            IGraphInfo * This,
            /* [in] */ LONG id,
            /* [retval][out] */ DOUBLE *size);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *edges )( 
            IGraphInfo * This,
            /* [retval][out] */ LONG *num);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *nodes )( 
            IGraphInfo * This,
            /* [retval][out] */ LONG *num);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *setGraph )( 
            IGraphInfo * This,
            /* [in] */ void **graph);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *setGraphComponents )( 
            IGraphInfo * This,
            /* [in] */ void **gcmps);
        
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


#define IGraphInfo_dimension(This,dimension)	\
    (This)->lpVtbl -> dimension(This,dimension)

#define IGraphInfo_gridNumber(This,id,grid)	\
    (This)->lpVtbl -> gridNumber(This,id,grid)

#define IGraphInfo_gridSize(This,id,size)	\
    (This)->lpVtbl -> gridSize(This,id,size)

#define IGraphInfo_spaceMin(This,id,size)	\
    (This)->lpVtbl -> spaceMin(This,id,size)

#define IGraphInfo_spaceMax(This,id,size)	\
    (This)->lpVtbl -> spaceMax(This,id,size)

#define IGraphInfo_edges(This,num)	\
    (This)->lpVtbl -> edges(This,num)

#define IGraphInfo_nodes(This,num)	\
    (This)->lpVtbl -> nodes(This,num)

#define IGraphInfo_setGraph(This,graph)	\
    (This)->lpVtbl -> setGraph(This,graph)

#define IGraphInfo_setGraphComponents(This,gcmps)	\
    (This)->lpVtbl -> setGraphComponents(This,gcmps)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_dimension_Proxy( 
    IGraphInfo * This,
    /* [retval][out] */ LONG *dimension);


void __RPC_STUB IGraphInfo_dimension_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_gridNumber_Proxy( 
    IGraphInfo * This,
    /* [in] */ LONG id,
    /* [retval][out] */ LONG *grid);


void __RPC_STUB IGraphInfo_gridNumber_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_gridSize_Proxy( 
    IGraphInfo * This,
    /* [in] */ LONG id,
    /* [retval][out] */ DOUBLE *size);


void __RPC_STUB IGraphInfo_gridSize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_spaceMin_Proxy( 
    IGraphInfo * This,
    /* [in] */ LONG id,
    /* [retval][out] */ DOUBLE *size);


void __RPC_STUB IGraphInfo_spaceMin_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_spaceMax_Proxy( 
    IGraphInfo * This,
    /* [in] */ LONG id,
    /* [retval][out] */ DOUBLE *size);


void __RPC_STUB IGraphInfo_spaceMax_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_edges_Proxy( 
    IGraphInfo * This,
    /* [retval][out] */ LONG *num);


void __RPC_STUB IGraphInfo_edges_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_nodes_Proxy( 
    IGraphInfo * This,
    /* [retval][out] */ LONG *num);


void __RPC_STUB IGraphInfo_nodes_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_setGraph_Proxy( 
    IGraphInfo * This,
    /* [in] */ void **graph);


void __RPC_STUB IGraphInfo_setGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IGraphInfo_setGraphComponents_Proxy( 
    IGraphInfo * This,
    /* [in] */ void **gcmps);


void __RPC_STUB IGraphInfo_setGraphComponents_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IGraphInfo_INTERFACE_DEFINED__ */


#ifndef __IParams_INTERFACE_DEFINED__
#define __IParams_INTERFACE_DEFINED__

/* interface IParams */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IParams;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("E478D112-3D56-478E-86C0-D51986519502")
    IParams : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE updateProgressBar( 
            /* [in] */ int minValue,
            /* [in] */ int maxValue,
            /* [in] */ int currentValue) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IParamsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IParams * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IParams * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IParams * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IParams * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IParams * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IParams * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IParams * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *updateProgressBar )( 
            IParams * This,
            /* [in] */ int minValue,
            /* [in] */ int maxValue,
            /* [in] */ int currentValue);
        
        END_INTERFACE
    } IParamsVtbl;

    interface IParams
    {
        CONST_VTBL struct IParamsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IParams_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IParams_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IParams_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IParams_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IParams_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IParams_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IParams_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IParams_updateProgressBar(This,minValue,maxValue,currentValue)	\
    (This)->lpVtbl -> updateProgressBar(This,minValue,maxValue,currentValue)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IParams_updateProgressBar_Proxy( 
    IParams * This,
    /* [in] */ int minValue,
    /* [in] */ int maxValue,
    /* [in] */ int currentValue);


void __RPC_STUB IParams_updateProgressBar_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IParams_INTERFACE_DEFINED__ */


#ifndef __ISubdevideParams_INTERFACE_DEFINED__
#define __ISubdevideParams_INTERFACE_DEFINED__

/* interface ISubdevideParams */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_ISubdevideParams;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("F8ED2FD5-C65C-4C11-ABD0-6DC53A7F05CD")
    ISubdevideParams : public IParams
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getCellDevider( 
            /* [in] */ int axis,
            /* [retval][out] */ int *value) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISubdevideParamsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISubdevideParams * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISubdevideParams * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISubdevideParams * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISubdevideParams * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISubdevideParams * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISubdevideParams * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISubdevideParams * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *updateProgressBar )( 
            ISubdevideParams * This,
            /* [in] */ int minValue,
            /* [in] */ int maxValue,
            /* [in] */ int currentValue);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getCellDevider )( 
            ISubdevideParams * This,
            /* [in] */ int axis,
            /* [retval][out] */ int *value);
        
        END_INTERFACE
    } ISubdevideParamsVtbl;

    interface ISubdevideParams
    {
        CONST_VTBL struct ISubdevideParamsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISubdevideParams_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISubdevideParams_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISubdevideParams_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISubdevideParams_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISubdevideParams_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISubdevideParams_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISubdevideParams_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISubdevideParams_updateProgressBar(This,minValue,maxValue,currentValue)	\
    (This)->lpVtbl -> updateProgressBar(This,minValue,maxValue,currentValue)


#define ISubdevideParams_getCellDevider(This,axis,value)	\
    (This)->lpVtbl -> getCellDevider(This,axis,value)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE ISubdevideParams_getCellDevider_Proxy( 
    ISubdevideParams * This,
    /* [in] */ int axis,
    /* [retval][out] */ int *value);


void __RPC_STUB ISubdevideParams_getCellDevider_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISubdevideParams_INTERFACE_DEFINED__ */


#ifndef __IExtendableParams_INTERFACE_DEFINED__
#define __IExtendableParams_INTERFACE_DEFINED__

/* interface IExtendableParams */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IExtendableParams;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("CC76B166-5482-4EA8-977D-D47005F2BB17")
    IExtendableParams : public ISubdevideParams
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IExtendableParamsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IExtendableParams * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IExtendableParams * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IExtendableParams * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IExtendableParams * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IExtendableParams * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IExtendableParams * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IExtendableParams * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *updateProgressBar )( 
            IExtendableParams * This,
            /* [in] */ int minValue,
            /* [in] */ int maxValue,
            /* [in] */ int currentValue);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getCellDevider )( 
            IExtendableParams * This,
            /* [in] */ int axis,
            /* [retval][out] */ int *value);
        
        END_INTERFACE
    } IExtendableParamsVtbl;

    interface IExtendableParams
    {
        CONST_VTBL struct IExtendableParamsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IExtendableParams_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IExtendableParams_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IExtendableParams_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IExtendableParams_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IExtendableParams_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IExtendableParams_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IExtendableParams_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IExtendableParams_updateProgressBar(This,minValue,maxValue,currentValue)	\
    (This)->lpVtbl -> updateProgressBar(This,minValue,maxValue,currentValue)


#define IExtendableParams_getCellDevider(This,axis,value)	\
    (This)->lpVtbl -> getCellDevider(This,axis,value)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IExtendableParams_INTERFACE_DEFINED__ */


#ifndef __IExtendablePointParams_INTERFACE_DEFINED__
#define __IExtendablePointParams_INTERFACE_DEFINED__

/* interface IExtendablePointParams */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IExtendablePointParams;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("E389B4B7-E438-4701-8719-5CD37F56D0CD")
    IExtendablePointParams : public ISubdevideParams
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IExtendablePointParamsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IExtendablePointParams * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IExtendablePointParams * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IExtendablePointParams * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IExtendablePointParams * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IExtendablePointParams * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IExtendablePointParams * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IExtendablePointParams * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *updateProgressBar )( 
            IExtendablePointParams * This,
            /* [in] */ int minValue,
            /* [in] */ int maxValue,
            /* [in] */ int currentValue);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getCellDevider )( 
            IExtendablePointParams * This,
            /* [in] */ int axis,
            /* [retval][out] */ int *value);
        
        END_INTERFACE
    } IExtendablePointParamsVtbl;

    interface IExtendablePointParams
    {
        CONST_VTBL struct IExtendablePointParamsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IExtendablePointParams_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IExtendablePointParams_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IExtendablePointParams_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IExtendablePointParams_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IExtendablePointParams_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IExtendablePointParams_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IExtendablePointParams_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IExtendablePointParams_updateProgressBar(This,minValue,maxValue,currentValue)	\
    (This)->lpVtbl -> updateProgressBar(This,minValue,maxValue,currentValue)


#define IExtendablePointParams_getCellDevider(This,axis,value)	\
    (This)->lpVtbl -> getCellDevider(This,axis,value)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IExtendablePointParams_INTERFACE_DEFINED__ */


#ifndef __ISubdevidePointParams_INTERFACE_DEFINED__
#define __ISubdevidePointParams_INTERFACE_DEFINED__

/* interface ISubdevidePointParams */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_ISubdevidePointParams;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("E6F9519F-6BF8-45E0-ACA2-4E710F23F80C")
    ISubdevidePointParams : public ISubdevideParams
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getCellPoints( 
            /* [in] */ int axis,
            /* [retval][out] */ int *value) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISubdevidePointParamsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISubdevidePointParams * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISubdevidePointParams * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISubdevidePointParams * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISubdevidePointParams * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISubdevidePointParams * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISubdevidePointParams * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISubdevidePointParams * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *updateProgressBar )( 
            ISubdevidePointParams * This,
            /* [in] */ int minValue,
            /* [in] */ int maxValue,
            /* [in] */ int currentValue);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getCellDevider )( 
            ISubdevidePointParams * This,
            /* [in] */ int axis,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getCellPoints )( 
            ISubdevidePointParams * This,
            /* [in] */ int axis,
            /* [retval][out] */ int *value);
        
        END_INTERFACE
    } ISubdevidePointParamsVtbl;

    interface ISubdevidePointParams
    {
        CONST_VTBL struct ISubdevidePointParamsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISubdevidePointParams_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISubdevidePointParams_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISubdevidePointParams_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISubdevidePointParams_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISubdevidePointParams_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISubdevidePointParams_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISubdevidePointParams_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISubdevidePointParams_updateProgressBar(This,minValue,maxValue,currentValue)	\
    (This)->lpVtbl -> updateProgressBar(This,minValue,maxValue,currentValue)


#define ISubdevidePointParams_getCellDevider(This,axis,value)	\
    (This)->lpVtbl -> getCellDevider(This,axis,value)


#define ISubdevidePointParams_getCellPoints(This,axis,value)	\
    (This)->lpVtbl -> getCellPoints(This,axis,value)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE ISubdevidePointParams_getCellPoints_Proxy( 
    ISubdevidePointParams * This,
    /* [in] */ int axis,
    /* [retval][out] */ int *value);


void __RPC_STUB ISubdevidePointParams_getCellPoints_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISubdevidePointParams_INTERFACE_DEFINED__ */


#ifndef __IHomotopParams_INTERFACE_DEFINED__
#define __IHomotopParams_INTERFACE_DEFINED__

/* interface IHomotopParams */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IHomotopParams;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("3C17C825-1C25-4F2D-8E0B-630953AD9596")
    IHomotopParams : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getCoordinateAt( 
            /* [in] */ int axis,
            /* [retval][out] */ double *value) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE notifyNodeNotFound( 
            /* [retval][out] */ VARIANT_BOOL *tryAgain) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IHomotopParamsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IHomotopParams * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IHomotopParams * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IHomotopParams * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IHomotopParams * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IHomotopParams * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IHomotopParams * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IHomotopParams * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getCoordinateAt )( 
            IHomotopParams * This,
            /* [in] */ int axis,
            /* [retval][out] */ double *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *notifyNodeNotFound )( 
            IHomotopParams * This,
            /* [retval][out] */ VARIANT_BOOL *tryAgain);
        
        END_INTERFACE
    } IHomotopParamsVtbl;

    interface IHomotopParams
    {
        CONST_VTBL struct IHomotopParamsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IHomotopParams_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IHomotopParams_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IHomotopParams_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IHomotopParams_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IHomotopParams_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IHomotopParams_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IHomotopParams_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IHomotopParams_getCoordinateAt(This,axis,value)	\
    (This)->lpVtbl -> getCoordinateAt(This,axis,value)

#define IHomotopParams_notifyNodeNotFound(This,tryAgain)	\
    (This)->lpVtbl -> notifyNodeNotFound(This,tryAgain)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IHomotopParams_getCoordinateAt_Proxy( 
    IHomotopParams * This,
    /* [in] */ int axis,
    /* [retval][out] */ double *value);


void __RPC_STUB IHomotopParams_getCoordinateAt_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IHomotopParams_notifyNodeNotFound_Proxy( 
    IHomotopParams * This,
    /* [retval][out] */ VARIANT_BOOL *tryAgain);


void __RPC_STUB IHomotopParams_notifyNodeNotFound_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IHomotopParams_INTERFACE_DEFINED__ */


#ifndef __IKernelPointer_INTERFACE_DEFINED__
#define __IKernelPointer_INTERFACE_DEFINED__

/* interface IKernelPointer */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IKernelPointer;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("18C498C5-231C-4F6A-A401-3C76F5D9D7A8")
    IKernelPointer : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IKernelPointerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IKernelPointer * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IKernelPointer * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IKernelPointer * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IKernelPointer * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IKernelPointer * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IKernelPointer * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IKernelPointer * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IKernelPointerVtbl;

    interface IKernelPointer
    {
        CONST_VTBL struct IKernelPointerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IKernelPointer_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IKernelPointer_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IKernelPointer_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IKernelPointer_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IKernelPointer_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IKernelPointer_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IKernelPointer_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IKernelPointer_INTERFACE_DEFINED__ */


#ifndef __IKernelNode_INTERFACE_DEFINED__
#define __IKernelNode_INTERFACE_DEFINED__

/* interface IKernelNode */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IKernelNode;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("E7A4DBC7-26F3-487B-9EAD-E2A7F6AF82E1")
    IKernelNode : public IDispatch
    {
    public:
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_kernel( 
            /* [retval][out] */ IKernelPointer **pVal) = 0;
        
        virtual /* [helpstring][id][propputref] */ HRESULT STDMETHODCALLTYPE putref_kernel( 
            /* [in] */ IKernelPointer *newVal) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IKernelNodeVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IKernelNode * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IKernelNode * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IKernelNode * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IKernelNode * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IKernelNode * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IKernelNode * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IKernelNode * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_kernel )( 
            IKernelNode * This,
            /* [retval][out] */ IKernelPointer **pVal);
        
        /* [helpstring][id][propputref] */ HRESULT ( STDMETHODCALLTYPE *putref_kernel )( 
            IKernelNode * This,
            /* [in] */ IKernelPointer *newVal);
        
        END_INTERFACE
    } IKernelNodeVtbl;

    interface IKernelNode
    {
        CONST_VTBL struct IKernelNodeVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IKernelNode_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IKernelNode_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IKernelNode_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IKernelNode_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IKernelNode_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IKernelNode_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IKernelNode_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IKernelNode_get_kernel(This,pVal)	\
    (This)->lpVtbl -> get_kernel(This,pVal)

#define IKernelNode_putref_kernel(This,newVal)	\
    (This)->lpVtbl -> putref_kernel(This,newVal)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IKernelNode_get_kernel_Proxy( 
    IKernelNode * This,
    /* [retval][out] */ IKernelPointer **pVal);


void __RPC_STUB IKernelNode_get_kernel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propputref] */ HRESULT STDMETHODCALLTYPE IKernelNode_putref_kernel_Proxy( 
    IKernelNode * This,
    /* [in] */ IKernelPointer *newVal);


void __RPC_STUB IKernelNode_putref_kernel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IKernelNode_INTERFACE_DEFINED__ */


#ifndef __IGraph_INTERFACE_DEFINED__
#define __IGraph_INTERFACE_DEFINED__

/* interface IGraph */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IGraph;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("3A59CE0B-D214-4BD9-BB1A-577822A582EE")
    IGraph : public IKernelNode
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE graphDimension( 
            /* [retval][out] */ int *value) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE graphInfo( 
            /* [retval][out] */ IGraphInfo **info) = 0;
        
        virtual /* [helpstring][hidden][local][id] */ HRESULT STDMETHODCALLTYPE acceptChilds( 
            /* [in] */ void **data) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IGraphVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IGraph * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IGraph * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IGraph * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IGraph * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IGraph * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IGraph * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IGraph * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_kernel )( 
            IGraph * This,
            /* [retval][out] */ IKernelPointer **pVal);
        
        /* [helpstring][id][propputref] */ HRESULT ( STDMETHODCALLTYPE *putref_kernel )( 
            IGraph * This,
            /* [in] */ IKernelPointer *newVal);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphDimension )( 
            IGraph * This,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphInfo )( 
            IGraph * This,
            /* [retval][out] */ IGraphInfo **info);
        
        /* [helpstring][hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *acceptChilds )( 
            IGraph * This,
            /* [in] */ void **data);
        
        END_INTERFACE
    } IGraphVtbl;

    interface IGraph
    {
        CONST_VTBL struct IGraphVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IGraph_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IGraph_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IGraph_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IGraph_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IGraph_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IGraph_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IGraph_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IGraph_get_kernel(This,pVal)	\
    (This)->lpVtbl -> get_kernel(This,pVal)

#define IGraph_putref_kernel(This,newVal)	\
    (This)->lpVtbl -> putref_kernel(This,newVal)


#define IGraph_graphDimension(This,value)	\
    (This)->lpVtbl -> graphDimension(This,value)

#define IGraph_graphInfo(This,info)	\
    (This)->lpVtbl -> graphInfo(This,info)

#define IGraph_acceptChilds(This,data)	\
    (This)->lpVtbl -> acceptChilds(This,data)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IGraph_graphDimension_Proxy( 
    IGraph * This,
    /* [retval][out] */ int *value);


void __RPC_STUB IGraph_graphDimension_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraph_graphInfo_Proxy( 
    IGraph * This,
    /* [retval][out] */ IGraphInfo **info);


void __RPC_STUB IGraph_graphInfo_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][hidden][local][id] */ HRESULT STDMETHODCALLTYPE IGraph_acceptChilds_Proxy( 
    IGraph * This,
    /* [in] */ void **data);


void __RPC_STUB IGraph_acceptChilds_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IGraph_INTERFACE_DEFINED__ */


#ifndef __ISubdevidable_INTERFACE_DEFINED__
#define __ISubdevidable_INTERFACE_DEFINED__

/* interface ISubdevidable */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_ISubdevidable;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("02431842-302A-4760-80A0-1FD2C161D6AC")
    ISubdevidable : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Subdevide( 
            /* [in] */ ISubdevideParams *params) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISubdevidableVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISubdevidable * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISubdevidable * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISubdevidable * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISubdevidable * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISubdevidable * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISubdevidable * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISubdevidable * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Subdevide )( 
            ISubdevidable * This,
            /* [in] */ ISubdevideParams *params);
        
        END_INTERFACE
    } ISubdevidableVtbl;

    interface ISubdevidable
    {
        CONST_VTBL struct ISubdevidableVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISubdevidable_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISubdevidable_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISubdevidable_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISubdevidable_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISubdevidable_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISubdevidable_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISubdevidable_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISubdevidable_Subdevide(This,params)	\
    (This)->lpVtbl -> Subdevide(This,params)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE ISubdevidable_Subdevide_Proxy( 
    ISubdevidable * This,
    /* [in] */ ISubdevideParams *params);


void __RPC_STUB ISubdevidable_Subdevide_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISubdevidable_INTERFACE_DEFINED__ */


#ifndef __ISubdevidablePoint_INTERFACE_DEFINED__
#define __ISubdevidablePoint_INTERFACE_DEFINED__

/* interface ISubdevidablePoint */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_ISubdevidablePoint;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("2EBA1301-AB35-4CC6-BA28-D2FCB0CED02B")
    ISubdevidablePoint : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SubdevidePoint( 
            /* [in] */ ISubdevidePointParams *params) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISubdevidablePointVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISubdevidablePoint * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISubdevidablePoint * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISubdevidablePoint * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISubdevidablePoint * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISubdevidablePoint * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISubdevidablePoint * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISubdevidablePoint * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SubdevidePoint )( 
            ISubdevidablePoint * This,
            /* [in] */ ISubdevidePointParams *params);
        
        END_INTERFACE
    } ISubdevidablePointVtbl;

    interface ISubdevidablePoint
    {
        CONST_VTBL struct ISubdevidablePointVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISubdevidablePoint_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISubdevidablePoint_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISubdevidablePoint_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISubdevidablePoint_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISubdevidablePoint_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISubdevidablePoint_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISubdevidablePoint_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISubdevidablePoint_SubdevidePoint(This,params)	\
    (This)->lpVtbl -> SubdevidePoint(This,params)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE ISubdevidablePoint_SubdevidePoint_Proxy( 
    ISubdevidablePoint * This,
    /* [in] */ ISubdevidePointParams *params);


void __RPC_STUB ISubdevidablePoint_SubdevidePoint_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISubdevidablePoint_INTERFACE_DEFINED__ */


#ifndef __IExtendable_INTERFACE_DEFINED__
#define __IExtendable_INTERFACE_DEFINED__

/* interface IExtendable */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IExtendable;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("26DF2357-91F9-4C63-9417-2762B0F83401")
    IExtendable : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Extend( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IExtendableVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IExtendable * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IExtendable * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IExtendable * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IExtendable * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IExtendable * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IExtendable * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IExtendable * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Extend )( 
            IExtendable * This);
        
        END_INTERFACE
    } IExtendableVtbl;

    interface IExtendable
    {
        CONST_VTBL struct IExtendableVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IExtendable_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IExtendable_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IExtendable_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IExtendable_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IExtendable_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IExtendable_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IExtendable_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IExtendable_Extend(This)	\
    (This)->lpVtbl -> Extend(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IExtendable_Extend_Proxy( 
    IExtendable * This);


void __RPC_STUB IExtendable_Extend_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IExtendable_INTERFACE_DEFINED__ */


#ifndef __IMorsable_INTERFACE_DEFINED__
#define __IMorsable_INTERFACE_DEFINED__

/* interface IMorsable */
/* [unique][uuid][object] */ 


EXTERN_C const IID IID_IMorsable;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("AF4F6B4B-C82F-49B9-9B01-167D5E38AD69")
    IMorsable : public IUnknown
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Morse( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMorsableVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMorsable * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMorsable * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMorsable * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Morse )( 
            IMorsable * This);
        
        END_INTERFACE
    } IMorsableVtbl;

    interface IMorsable
    {
        CONST_VTBL struct IMorsableVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMorsable_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMorsable_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMorsable_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMorsable_Morse(This)	\
    (This)->lpVtbl -> Morse(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMorsable_Morse_Proxy( 
    IMorsable * This);


void __RPC_STUB IMorsable_Morse_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMorsable_INTERFACE_DEFINED__ */


#ifndef __IExportData_INTERFACE_DEFINED__
#define __IExportData_INTERFACE_DEFINED__

/* interface IExportData */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IExportData;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("424DB12A-2DE1-4A38-9CA0-2F52DF62944D")
    IExportData : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE ExportData( 
            /* [in] */ BSTR file) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IExportDataVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IExportData * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IExportData * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IExportData * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IExportData * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IExportData * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IExportData * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IExportData * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *ExportData )( 
            IExportData * This,
            /* [in] */ BSTR file);
        
        END_INTERFACE
    } IExportDataVtbl;

    interface IExportData
    {
        CONST_VTBL struct IExportDataVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IExportData_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IExportData_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IExportData_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IExportData_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IExportData_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IExportData_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IExportData_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IExportData_ExportData(This,file)	\
    (This)->lpVtbl -> ExportData(This,file)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IExportData_ExportData_Proxy( 
    IExportData * This,
    /* [in] */ BSTR file);


void __RPC_STUB IExportData_ExportData_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IExportData_INTERFACE_DEFINED__ */


#ifndef __IHomotopFind_INTERFACE_DEFINED__
#define __IHomotopFind_INTERFACE_DEFINED__

/* interface IHomotopFind */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IHomotopFind;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("A395C00D-8306-4AA8-9A9F-EA9E79E74C92")
    IHomotopFind : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Homotop( 
            /* [in] */ IHomotopParams *params) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IHomotopFindVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IHomotopFind * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IHomotopFind * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IHomotopFind * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IHomotopFind * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IHomotopFind * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IHomotopFind * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IHomotopFind * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Homotop )( 
            IHomotopFind * This,
            /* [in] */ IHomotopParams *params);
        
        END_INTERFACE
    } IHomotopFindVtbl;

    interface IHomotopFind
    {
        CONST_VTBL struct IHomotopFindVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IHomotopFind_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IHomotopFind_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IHomotopFind_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IHomotopFind_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IHomotopFind_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IHomotopFind_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IHomotopFind_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IHomotopFind_Homotop(This,params)	\
    (This)->lpVtbl -> Homotop(This,params)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IHomotopFind_Homotop_Proxy( 
    IHomotopFind * This,
    /* [in] */ IHomotopParams *params);


void __RPC_STUB IHomotopFind_Homotop_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IHomotopFind_INTERFACE_DEFINED__ */


#ifndef __IComputationResult_INTERFACE_DEFINED__
#define __IComputationResult_INTERFACE_DEFINED__

/* interface IComputationResult */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IComputationResult;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("EA038030-124F-4F15-ACD4-E0500C5110A3")
    IComputationResult : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IComputationResultVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IComputationResult * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IComputationResult * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IComputationResult * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IComputationResult * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IComputationResult * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IComputationResult * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IComputationResult * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IComputationResultVtbl;

    interface IComputationResult
    {
        CONST_VTBL struct IComputationResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IComputationResult_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IComputationResult_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IComputationResult_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IComputationResult_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IComputationResult_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IComputationResult_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IComputationResult_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IComputationResult_INTERFACE_DEFINED__ */


#ifndef __IComputationGraphResult_INTERFACE_DEFINED__
#define __IComputationGraphResult_INTERFACE_DEFINED__

/* interface IComputationGraphResult */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IComputationGraphResult;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("5195A2BC-243D-4DA4-B68F-9015D3382DB9")
    IComputationGraphResult : public IComputationResult
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE StrongComponents( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE StrongComponentsEdges( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Loops( void) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DoNothing( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IComputationGraphResultVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IComputationGraphResult * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IComputationGraphResult * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IComputationGraphResult * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IComputationGraphResult * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IComputationGraphResult * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IComputationGraphResult * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IComputationGraphResult * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *StrongComponents )( 
            IComputationGraphResult * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *StrongComponentsEdges )( 
            IComputationGraphResult * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Loops )( 
            IComputationGraphResult * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DoNothing )( 
            IComputationGraphResult * This);
        
        END_INTERFACE
    } IComputationGraphResultVtbl;

    interface IComputationGraphResult
    {
        CONST_VTBL struct IComputationGraphResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IComputationGraphResult_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IComputationGraphResult_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IComputationGraphResult_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IComputationGraphResult_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IComputationGraphResult_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IComputationGraphResult_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IComputationGraphResult_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IComputationGraphResult_StrongComponents(This)	\
    (This)->lpVtbl -> StrongComponents(This)

#define IComputationGraphResult_StrongComponentsEdges(This)	\
    (This)->lpVtbl -> StrongComponentsEdges(This)

#define IComputationGraphResult_Loops(This)	\
    (This)->lpVtbl -> Loops(This)

#define IComputationGraphResult_DoNothing(This)	\
    (This)->lpVtbl -> DoNothing(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IComputationGraphResult_StrongComponents_Proxy( 
    IComputationGraphResult * This);


void __RPC_STUB IComputationGraphResult_StrongComponents_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IComputationGraphResult_StrongComponentsEdges_Proxy( 
    IComputationGraphResult * This);


void __RPC_STUB IComputationGraphResult_StrongComponentsEdges_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IComputationGraphResult_Loops_Proxy( 
    IComputationGraphResult * This);


void __RPC_STUB IComputationGraphResult_Loops_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IComputationGraphResult_DoNothing_Proxy( 
    IComputationGraphResult * This);


void __RPC_STUB IComputationGraphResult_DoNothing_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IComputationGraphResult_INTERFACE_DEFINED__ */


#ifndef __IComputationExtendingResult_INTERFACE_DEFINED__
#define __IComputationExtendingResult_INTERFACE_DEFINED__

/* interface IComputationExtendingResult */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IComputationExtendingResult;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("76314083-5CCF-4EB5-91F4-0DE79E549340")
    IComputationExtendingResult : public IComputationResult
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE PointMethodProjectiveExtension( 
            /* [in] */ IExtendablePointParams *params) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE PointMethodProjectiveExtensionDimension( 
            /* [retval][out] */ int *dim) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IComputationExtendingResultVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IComputationExtendingResult * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IComputationExtendingResult * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IComputationExtendingResult * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IComputationExtendingResult * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IComputationExtendingResult * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IComputationExtendingResult * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IComputationExtendingResult * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *PointMethodProjectiveExtension )( 
            IComputationExtendingResult * This,
            /* [in] */ IExtendablePointParams *params);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *PointMethodProjectiveExtensionDimension )( 
            IComputationExtendingResult * This,
            /* [retval][out] */ int *dim);
        
        END_INTERFACE
    } IComputationExtendingResultVtbl;

    interface IComputationExtendingResult
    {
        CONST_VTBL struct IComputationExtendingResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IComputationExtendingResult_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IComputationExtendingResult_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IComputationExtendingResult_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IComputationExtendingResult_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IComputationExtendingResult_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IComputationExtendingResult_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IComputationExtendingResult_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IComputationExtendingResult_PointMethodProjectiveExtension(This,params)	\
    (This)->lpVtbl -> PointMethodProjectiveExtension(This,params)

#define IComputationExtendingResult_PointMethodProjectiveExtensionDimension(This,dim)	\
    (This)->lpVtbl -> PointMethodProjectiveExtensionDimension(This,dim)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IComputationExtendingResult_PointMethodProjectiveExtension_Proxy( 
    IComputationExtendingResult * This,
    /* [in] */ IExtendablePointParams *params);


void __RPC_STUB IComputationExtendingResult_PointMethodProjectiveExtension_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IComputationExtendingResult_PointMethodProjectiveExtensionDimension_Proxy( 
    IComputationExtendingResult * This,
    /* [retval][out] */ int *dim);


void __RPC_STUB IComputationExtendingResult_PointMethodProjectiveExtensionDimension_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IComputationExtendingResult_INTERFACE_DEFINED__ */


#ifndef __IComputationMorseResult_INTERFACE_DEFINED__
#define __IComputationMorseResult_INTERFACE_DEFINED__

/* interface IComputationMorseResult */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IComputationMorseResult;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("6C613BDB-C2CE-47EA-9BA0-9F2B2D259016")
    IComputationMorseResult : public IComputationResult
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE toResult( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IComputationMorseResultVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IComputationMorseResult * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IComputationMorseResult * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IComputationMorseResult * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IComputationMorseResult * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IComputationMorseResult * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IComputationMorseResult * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IComputationMorseResult * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *toResult )( 
            IComputationMorseResult * This);
        
        END_INTERFACE
    } IComputationMorseResultVtbl;

    interface IComputationMorseResult
    {
        CONST_VTBL struct IComputationMorseResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IComputationMorseResult_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IComputationMorseResult_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IComputationMorseResult_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IComputationMorseResult_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IComputationMorseResult_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IComputationMorseResult_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IComputationMorseResult_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IComputationMorseResult_toResult(This)	\
    (This)->lpVtbl -> toResult(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IComputationMorseResult_toResult_Proxy( 
    IComputationMorseResult * This);


void __RPC_STUB IComputationMorseResult_toResult_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IComputationMorseResult_INTERFACE_DEFINED__ */


#ifndef __IGroupNode_INTERFACE_DEFINED__
#define __IGroupNode_INTERFACE_DEFINED__

/* interface IGroupNode */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IGroupNode;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("243208B9-C9C1-429C-92E5-A1589F156376")
    IGroupNode : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE nodeCount( 
            /* [retval][out] */ int *val) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getNode( 
            /* [in] */ int index,
            /* [retval][out] */ IKernelNode **node) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IGroupNodeVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IGroupNode * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IGroupNode * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IGroupNode * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IGroupNode * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IGroupNode * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IGroupNode * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IGroupNode * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *nodeCount )( 
            IGroupNode * This,
            /* [retval][out] */ int *val);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getNode )( 
            IGroupNode * This,
            /* [in] */ int index,
            /* [retval][out] */ IKernelNode **node);
        
        END_INTERFACE
    } IGroupNodeVtbl;

    interface IGroupNode
    {
        CONST_VTBL struct IGroupNodeVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IGroupNode_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IGroupNode_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IGroupNode_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IGroupNode_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IGroupNode_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IGroupNode_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IGroupNode_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IGroupNode_nodeCount(This,val)	\
    (This)->lpVtbl -> nodeCount(This,val)

#define IGroupNode_getNode(This,index,node)	\
    (This)->lpVtbl -> getNode(This,index,node)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IGroupNode_nodeCount_Proxy( 
    IGroupNode * This,
    /* [retval][out] */ int *val);


void __RPC_STUB IGroupNode_nodeCount_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGroupNode_getNode_Proxy( 
    IGroupNode * This,
    /* [in] */ int index,
    /* [retval][out] */ IKernelNode **node);


void __RPC_STUB IGroupNode_getNode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IGroupNode_INTERFACE_DEFINED__ */


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


#ifndef __IFunctionEvents_INTERFACE_DEFINED__
#define __IFunctionEvents_INTERFACE_DEFINED__

/* interface IFunctionEvents */
/* [dual][uuid][object] */ 


EXTERN_C const IID IID_IFunctionEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("47A8D8C4-8744-4150-A8F9-278AE08C4DA4")
    IFunctionEvents : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE FunctionWrongInput( 
            /* [in] */ BSTR description) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE FunctionChanged( 
            /* [in] */ BSTR oldFunction,
            /* [in] */ BSTR newFunction) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE FunctionAccepted( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IFunctionEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IFunctionEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IFunctionEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IFunctionEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IFunctionEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IFunctionEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IFunctionEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IFunctionEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *FunctionWrongInput )( 
            IFunctionEvents * This,
            /* [in] */ BSTR description);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *FunctionChanged )( 
            IFunctionEvents * This,
            /* [in] */ BSTR oldFunction,
            /* [in] */ BSTR newFunction);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *FunctionAccepted )( 
            IFunctionEvents * This);
        
        END_INTERFACE
    } IFunctionEventsVtbl;

    interface IFunctionEvents
    {
        CONST_VTBL struct IFunctionEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IFunctionEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IFunctionEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IFunctionEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IFunctionEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IFunctionEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IFunctionEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IFunctionEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IFunctionEvents_FunctionWrongInput(This,description)	\
    (This)->lpVtbl -> FunctionWrongInput(This,description)

#define IFunctionEvents_FunctionChanged(This,oldFunction,newFunction)	\
    (This)->lpVtbl -> FunctionChanged(This,oldFunction,newFunction)

#define IFunctionEvents_FunctionAccepted(This)	\
    (This)->lpVtbl -> FunctionAccepted(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IFunctionEvents_FunctionWrongInput_Proxy( 
    IFunctionEvents * This,
    /* [in] */ BSTR description);


void __RPC_STUB IFunctionEvents_FunctionWrongInput_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IFunctionEvents_FunctionChanged_Proxy( 
    IFunctionEvents * This,
    /* [in] */ BSTR oldFunction,
    /* [in] */ BSTR newFunction);


void __RPC_STUB IFunctionEvents_FunctionChanged_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IFunctionEvents_FunctionAccepted_Proxy( 
    IFunctionEvents * This);


void __RPC_STUB IFunctionEvents_FunctionAccepted_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IFunctionEvents_INTERFACE_DEFINED__ */


#ifndef __IFunction_INTERFACE_DEFINED__
#define __IFunction_INTERFACE_DEFINED__

/* interface IFunction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IFunction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("83229BF2-7EB9-428D-B832-831CACFAE78C")
    IFunction : public IDispatch
    {
    public:
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_SystemSource( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_SystemSource( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE getFunction( 
            /* [unique][out] */ void **func) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE createGraph( 
            /* [unique][out] */ void **graph) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE getSystemFunction( 
            /* [unique][out] */ void **function) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE getSystemFunctionDerivate( 
            /* [unique][out] */ void **function) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IFunctionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IFunction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IFunction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IFunction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IFunction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IFunction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IFunction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IFunction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_SystemSource )( 
            IFunction * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_SystemSource )( 
            IFunction * This,
            /* [in] */ BSTR newVal);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *getFunction )( 
            IFunction * This,
            /* [unique][out] */ void **func);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *createGraph )( 
            IFunction * This,
            /* [unique][out] */ void **graph);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *getSystemFunction )( 
            IFunction * This,
            /* [unique][out] */ void **function);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *getSystemFunctionDerivate )( 
            IFunction * This,
            /* [unique][out] */ void **function);
        
        END_INTERFACE
    } IFunctionVtbl;

    interface IFunction
    {
        CONST_VTBL struct IFunctionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IFunction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IFunction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IFunction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IFunction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IFunction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IFunction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IFunction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IFunction_get_SystemSource(This,pVal)	\
    (This)->lpVtbl -> get_SystemSource(This,pVal)

#define IFunction_put_SystemSource(This,newVal)	\
    (This)->lpVtbl -> put_SystemSource(This,newVal)

#define IFunction_getFunction(This,func)	\
    (This)->lpVtbl -> getFunction(This,func)

#define IFunction_createGraph(This,graph)	\
    (This)->lpVtbl -> createGraph(This,graph)

#define IFunction_getSystemFunction(This,function)	\
    (This)->lpVtbl -> getSystemFunction(This,function)

#define IFunction_getSystemFunctionDerivate(This,function)	\
    (This)->lpVtbl -> getSystemFunctionDerivate(This,function)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IFunction_get_SystemSource_Proxy( 
    IFunction * This,
    /* [retval][out] */ BSTR *pVal);


void __RPC_STUB IFunction_get_SystemSource_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE IFunction_put_SystemSource_Proxy( 
    IFunction * This,
    /* [in] */ BSTR newVal);


void __RPC_STUB IFunction_put_SystemSource_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IFunction_getFunction_Proxy( 
    IFunction * This,
    /* [unique][out] */ void **func);


void __RPC_STUB IFunction_getFunction_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IFunction_createGraph_Proxy( 
    IFunction * This,
    /* [unique][out] */ void **graph);


void __RPC_STUB IFunction_createGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IFunction_getSystemFunction_Proxy( 
    IFunction * This,
    /* [unique][out] */ void **function);


void __RPC_STUB IFunction_getSystemFunction_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IFunction_getSystemFunctionDerivate_Proxy( 
    IFunction * This,
    /* [unique][out] */ void **function);


void __RPC_STUB IFunction_getSystemFunctionDerivate_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IFunction_INTERFACE_DEFINED__ */


#ifndef __IKernel_INTERFACE_DEFINED__
#define __IKernel_INTERFACE_DEFINED__

/* interface IKernel */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IKernel;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("8D366F71-EA60-4812-AFCD-BC5A20297FDD")
    IKernel : public IKernelPointer
    {
    public:
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_Function( 
            /* [retval][out] */ IFunction **pVal) = 0;
        
        virtual /* [helpstring][id][propputref] */ HRESULT STDMETHODCALLTYPE putref_Function( 
            /* [in] */ IFunction *newVal) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CreateRootSymbolicImage( 
            /* [retval][out] */ IKernelNode **pVal) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE CreateSymbolicImageGroup( 
            /* [retval][out] */ IKernelNode **node) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE CreateProjectiveBundleGroup( 
            /* [retval][out] */ IKernelNode **node) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EventNewNode( 
            /* [in] */ IKernelNode *nodeParent,
            /* [in] */ IKernelNode *nodeChild) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EventNewComputationResult( 
            /* [in] */ IKernelNode *nodeParent,
            /* [in] */ IComputationResult *nodeCResult) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EventNoChilds( 
            /* [in] */ IKernelNode *nodeParent) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EventNoImplementation( 
            /* [in] */ IKernelNode *nodeParent) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IKernelVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IKernel * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IKernel * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IKernel * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IKernel * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IKernel * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IKernel * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IKernel * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_Function )( 
            IKernel * This,
            /* [retval][out] */ IFunction **pVal);
        
        /* [helpstring][id][propputref] */ HRESULT ( STDMETHODCALLTYPE *putref_Function )( 
            IKernel * This,
            /* [in] */ IFunction *newVal);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CreateRootSymbolicImage )( 
            IKernel * This,
            /* [retval][out] */ IKernelNode **pVal);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CreateSymbolicImageGroup )( 
            IKernel * This,
            /* [retval][out] */ IKernelNode **node);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CreateProjectiveBundleGroup )( 
            IKernel * This,
            /* [retval][out] */ IKernelNode **node);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EventNewNode )( 
            IKernel * This,
            /* [in] */ IKernelNode *nodeParent,
            /* [in] */ IKernelNode *nodeChild);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EventNewComputationResult )( 
            IKernel * This,
            /* [in] */ IKernelNode *nodeParent,
            /* [in] */ IComputationResult *nodeCResult);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EventNoChilds )( 
            IKernel * This,
            /* [in] */ IKernelNode *nodeParent);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EventNoImplementation )( 
            IKernel * This,
            /* [in] */ IKernelNode *nodeParent);
        
        END_INTERFACE
    } IKernelVtbl;

    interface IKernel
    {
        CONST_VTBL struct IKernelVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IKernel_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IKernel_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IKernel_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IKernel_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IKernel_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IKernel_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IKernel_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IKernel_get_Function(This,pVal)	\
    (This)->lpVtbl -> get_Function(This,pVal)

#define IKernel_putref_Function(This,newVal)	\
    (This)->lpVtbl -> putref_Function(This,newVal)

#define IKernel_CreateRootSymbolicImage(This,pVal)	\
    (This)->lpVtbl -> CreateRootSymbolicImage(This,pVal)

#define IKernel_CreateSymbolicImageGroup(This,node)	\
    (This)->lpVtbl -> CreateSymbolicImageGroup(This,node)

#define IKernel_CreateProjectiveBundleGroup(This,node)	\
    (This)->lpVtbl -> CreateProjectiveBundleGroup(This,node)

#define IKernel_EventNewNode(This,nodeParent,nodeChild)	\
    (This)->lpVtbl -> EventNewNode(This,nodeParent,nodeChild)

#define IKernel_EventNewComputationResult(This,nodeParent,nodeCResult)	\
    (This)->lpVtbl -> EventNewComputationResult(This,nodeParent,nodeCResult)

#define IKernel_EventNoChilds(This,nodeParent)	\
    (This)->lpVtbl -> EventNoChilds(This,nodeParent)

#define IKernel_EventNoImplementation(This,nodeParent)	\
    (This)->lpVtbl -> EventNoImplementation(This,nodeParent)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IKernel_get_Function_Proxy( 
    IKernel * This,
    /* [retval][out] */ IFunction **pVal);


void __RPC_STUB IKernel_get_Function_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propputref] */ HRESULT STDMETHODCALLTYPE IKernel_putref_Function_Proxy( 
    IKernel * This,
    /* [in] */ IFunction *newVal);


void __RPC_STUB IKernel_putref_Function_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IKernel_CreateRootSymbolicImage_Proxy( 
    IKernel * This,
    /* [retval][out] */ IKernelNode **pVal);


void __RPC_STUB IKernel_CreateRootSymbolicImage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IKernel_CreateSymbolicImageGroup_Proxy( 
    IKernel * This,
    /* [retval][out] */ IKernelNode **node);


void __RPC_STUB IKernel_CreateSymbolicImageGroup_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IKernel_CreateProjectiveBundleGroup_Proxy( 
    IKernel * This,
    /* [retval][out] */ IKernelNode **node);


void __RPC_STUB IKernel_CreateProjectiveBundleGroup_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IKernel_EventNewNode_Proxy( 
    IKernel * This,
    /* [in] */ IKernelNode *nodeParent,
    /* [in] */ IKernelNode *nodeChild);


void __RPC_STUB IKernel_EventNewNode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IKernel_EventNewComputationResult_Proxy( 
    IKernel * This,
    /* [in] */ IKernelNode *nodeParent,
    /* [in] */ IComputationResult *nodeCResult);


void __RPC_STUB IKernel_EventNewComputationResult_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IKernel_EventNoChilds_Proxy( 
    IKernel * This,
    /* [in] */ IKernelNode *nodeParent);


void __RPC_STUB IKernel_EventNoChilds_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IKernel_EventNoImplementation_Proxy( 
    IKernel * This,
    /* [in] */ IKernelNode *nodeParent);


void __RPC_STUB IKernel_EventNoImplementation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IKernel_INTERFACE_DEFINED__ */


#ifndef __IComputationGraphResultExt_INTERFACE_DEFINED__
#define __IComputationGraphResultExt_INTERFACE_DEFINED__

/* interface IComputationGraphResultExt */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IComputationGraphResultExt;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("A16233C4-8412-43B1-B8FB-C339F86EFB55")
    IComputationGraphResultExt : public IComputationGraphResult
    {
    public:
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE setRootGraph( 
            /* [in] */ void **graph) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE setGraphNode( 
            /* [in] */ IGraph *node) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IComputationGraphResultExtVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IComputationGraphResultExt * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IComputationGraphResultExt * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IComputationGraphResultExt * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IComputationGraphResultExt * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IComputationGraphResultExt * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IComputationGraphResultExt * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IComputationGraphResultExt * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *StrongComponents )( 
            IComputationGraphResultExt * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *StrongComponentsEdges )( 
            IComputationGraphResultExt * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Loops )( 
            IComputationGraphResultExt * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DoNothing )( 
            IComputationGraphResultExt * This);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *setRootGraph )( 
            IComputationGraphResultExt * This,
            /* [in] */ void **graph);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *setGraphNode )( 
            IComputationGraphResultExt * This,
            /* [in] */ IGraph *node);
        
        END_INTERFACE
    } IComputationGraphResultExtVtbl;

    interface IComputationGraphResultExt
    {
        CONST_VTBL struct IComputationGraphResultExtVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IComputationGraphResultExt_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IComputationGraphResultExt_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IComputationGraphResultExt_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IComputationGraphResultExt_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IComputationGraphResultExt_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IComputationGraphResultExt_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IComputationGraphResultExt_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IComputationGraphResultExt_StrongComponents(This)	\
    (This)->lpVtbl -> StrongComponents(This)

#define IComputationGraphResultExt_StrongComponentsEdges(This)	\
    (This)->lpVtbl -> StrongComponentsEdges(This)

#define IComputationGraphResultExt_Loops(This)	\
    (This)->lpVtbl -> Loops(This)

#define IComputationGraphResultExt_DoNothing(This)	\
    (This)->lpVtbl -> DoNothing(This)


#define IComputationGraphResultExt_setRootGraph(This,graph)	\
    (This)->lpVtbl -> setRootGraph(This,graph)

#define IComputationGraphResultExt_setGraphNode(This,node)	\
    (This)->lpVtbl -> setGraphNode(This,node)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IComputationGraphResultExt_setRootGraph_Proxy( 
    IComputationGraphResultExt * This,
    /* [in] */ void **graph);


void __RPC_STUB IComputationGraphResultExt_setRootGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IComputationGraphResultExt_setGraphNode_Proxy( 
    IComputationGraphResultExt * This,
    /* [in] */ IGraph *node);


void __RPC_STUB IComputationGraphResultExt_setGraphNode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IComputationGraphResultExt_INTERFACE_DEFINED__ */


#ifndef __IDummy_INTERFACE_DEFINED__
#define __IDummy_INTERFACE_DEFINED__

/* interface IDummy */
/* [dual][unique][uuid][object] */ 


EXTERN_C const IID IID_IDummy;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("ECACE910-6692-4ACC-85C2-3EF448BF2638")
    IDummy : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IDummyVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IDummy * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IDummy * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IDummy * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IDummy * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IDummy * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IDummy * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IDummy * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IDummyVtbl;

    interface IDummy
    {
        CONST_VTBL struct IDummyVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IDummy_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IDummy_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IDummy_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IDummy_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IDummy_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IDummy_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IDummy_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IDummy_INTERFACE_DEFINED__ */


#ifndef __IMorseSpectrum_INTERFACE_DEFINED__
#define __IMorseSpectrum_INTERFACE_DEFINED__

/* interface IMorseSpectrum */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IMorseSpectrum;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("E9A021D4-77A7-458E-BB1F-2F84DF48B982")
    IMorseSpectrum : public IKernelNode
    {
    public:
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_lowerBound( 
            /* [retval][out] */ DOUBLE *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_lowerBound( 
            /* [in] */ DOUBLE pVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_upperBound( 
            /* [retval][out] */ DOUBLE *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_upperBound( 
            /* [in] */ DOUBLE pVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_lowerLength( 
            /* [retval][out] */ LONG *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_lowerLength( 
            /* [in] */ LONG newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_upperLength( 
            /* [retval][out] */ LONG *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_upperLength( 
            /* [in] */ LONG newVal) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMorseSpectrumVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMorseSpectrum * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMorseSpectrum * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMorseSpectrum * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMorseSpectrum * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMorseSpectrum * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMorseSpectrum * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMorseSpectrum * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_kernel )( 
            IMorseSpectrum * This,
            /* [retval][out] */ IKernelPointer **pVal);
        
        /* [helpstring][id][propputref] */ HRESULT ( STDMETHODCALLTYPE *putref_kernel )( 
            IMorseSpectrum * This,
            /* [in] */ IKernelPointer *newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_lowerBound )( 
            IMorseSpectrum * This,
            /* [retval][out] */ DOUBLE *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_lowerBound )( 
            IMorseSpectrum * This,
            /* [in] */ DOUBLE pVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_upperBound )( 
            IMorseSpectrum * This,
            /* [retval][out] */ DOUBLE *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_upperBound )( 
            IMorseSpectrum * This,
            /* [in] */ DOUBLE pVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_lowerLength )( 
            IMorseSpectrum * This,
            /* [retval][out] */ LONG *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_lowerLength )( 
            IMorseSpectrum * This,
            /* [in] */ LONG newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_upperLength )( 
            IMorseSpectrum * This,
            /* [retval][out] */ LONG *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_upperLength )( 
            IMorseSpectrum * This,
            /* [in] */ LONG newVal);
        
        END_INTERFACE
    } IMorseSpectrumVtbl;

    interface IMorseSpectrum
    {
        CONST_VTBL struct IMorseSpectrumVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMorseSpectrum_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMorseSpectrum_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMorseSpectrum_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMorseSpectrum_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMorseSpectrum_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMorseSpectrum_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMorseSpectrum_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IMorseSpectrum_get_kernel(This,pVal)	\
    (This)->lpVtbl -> get_kernel(This,pVal)

#define IMorseSpectrum_putref_kernel(This,newVal)	\
    (This)->lpVtbl -> putref_kernel(This,newVal)


#define IMorseSpectrum_get_lowerBound(This,pVal)	\
    (This)->lpVtbl -> get_lowerBound(This,pVal)

#define IMorseSpectrum_put_lowerBound(This,pVal)	\
    (This)->lpVtbl -> put_lowerBound(This,pVal)

#define IMorseSpectrum_get_upperBound(This,pVal)	\
    (This)->lpVtbl -> get_upperBound(This,pVal)

#define IMorseSpectrum_put_upperBound(This,pVal)	\
    (This)->lpVtbl -> put_upperBound(This,pVal)

#define IMorseSpectrum_get_lowerLength(This,pVal)	\
    (This)->lpVtbl -> get_lowerLength(This,pVal)

#define IMorseSpectrum_put_lowerLength(This,newVal)	\
    (This)->lpVtbl -> put_lowerLength(This,newVal)

#define IMorseSpectrum_get_upperLength(This,pVal)	\
    (This)->lpVtbl -> get_upperLength(This,pVal)

#define IMorseSpectrum_put_upperLength(This,newVal)	\
    (This)->lpVtbl -> put_upperLength(This,newVal)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IMorseSpectrum_get_lowerBound_Proxy( 
    IMorseSpectrum * This,
    /* [retval][out] */ DOUBLE *pVal);


void __RPC_STUB IMorseSpectrum_get_lowerBound_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE IMorseSpectrum_put_lowerBound_Proxy( 
    IMorseSpectrum * This,
    /* [in] */ DOUBLE pVal);


void __RPC_STUB IMorseSpectrum_put_lowerBound_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IMorseSpectrum_get_upperBound_Proxy( 
    IMorseSpectrum * This,
    /* [retval][out] */ DOUBLE *pVal);


void __RPC_STUB IMorseSpectrum_get_upperBound_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE IMorseSpectrum_put_upperBound_Proxy( 
    IMorseSpectrum * This,
    /* [in] */ DOUBLE pVal);


void __RPC_STUB IMorseSpectrum_put_upperBound_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IMorseSpectrum_get_lowerLength_Proxy( 
    IMorseSpectrum * This,
    /* [retval][out] */ LONG *pVal);


void __RPC_STUB IMorseSpectrum_get_lowerLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE IMorseSpectrum_put_lowerLength_Proxy( 
    IMorseSpectrum * This,
    /* [in] */ LONG newVal);


void __RPC_STUB IMorseSpectrum_put_lowerLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IMorseSpectrum_get_upperLength_Proxy( 
    IMorseSpectrum * This,
    /* [retval][out] */ LONG *pVal);


void __RPC_STUB IMorseSpectrum_get_upperLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE IMorseSpectrum_put_upperLength_Proxy( 
    IMorseSpectrum * This,
    /* [in] */ LONG newVal);


void __RPC_STUB IMorseSpectrum_put_upperLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMorseSpectrum_INTERFACE_DEFINED__ */


#ifndef __IProjectiveBundle_INTERFACE_DEFINED__
#define __IProjectiveBundle_INTERFACE_DEFINED__

/* interface IProjectiveBundle */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IProjectiveBundle;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("1C62FD1D-F7D8-417E-9DAA-5AECF07CF7D3")
    IProjectiveBundle : public IGraph
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IProjectiveBundleVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IProjectiveBundle * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IProjectiveBundle * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IProjectiveBundle * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IProjectiveBundle * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IProjectiveBundle * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IProjectiveBundle * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IProjectiveBundle * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_kernel )( 
            IProjectiveBundle * This,
            /* [retval][out] */ IKernelPointer **pVal);
        
        /* [helpstring][id][propputref] */ HRESULT ( STDMETHODCALLTYPE *putref_kernel )( 
            IProjectiveBundle * This,
            /* [in] */ IKernelPointer *newVal);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphDimension )( 
            IProjectiveBundle * This,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphInfo )( 
            IProjectiveBundle * This,
            /* [retval][out] */ IGraphInfo **info);
        
        /* [helpstring][hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *acceptChilds )( 
            IProjectiveBundle * This,
            /* [in] */ void **data);
        
        END_INTERFACE
    } IProjectiveBundleVtbl;

    interface IProjectiveBundle
    {
        CONST_VTBL struct IProjectiveBundleVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IProjectiveBundle_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IProjectiveBundle_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IProjectiveBundle_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IProjectiveBundle_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IProjectiveBundle_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IProjectiveBundle_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IProjectiveBundle_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IProjectiveBundle_get_kernel(This,pVal)	\
    (This)->lpVtbl -> get_kernel(This,pVal)

#define IProjectiveBundle_putref_kernel(This,newVal)	\
    (This)->lpVtbl -> putref_kernel(This,newVal)


#define IProjectiveBundle_graphDimension(This,value)	\
    (This)->lpVtbl -> graphDimension(This,value)

#define IProjectiveBundle_graphInfo(This,info)	\
    (This)->lpVtbl -> graphInfo(This,info)

#define IProjectiveBundle_acceptChilds(This,data)	\
    (This)->lpVtbl -> acceptChilds(This,data)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IProjectiveBundle_INTERFACE_DEFINED__ */


#ifndef __ISymbolicImage_INTERFACE_DEFINED__
#define __ISymbolicImage_INTERFACE_DEFINED__

/* interface ISymbolicImage */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ISymbolicImage;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("FA9817A1-3666-41E7-8FCF-0985A43D5FA6")
    ISymbolicImage : public IGraph
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ISymbolicImageVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISymbolicImage * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISymbolicImage * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISymbolicImage * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISymbolicImage * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISymbolicImage * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISymbolicImage * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISymbolicImage * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_kernel )( 
            ISymbolicImage * This,
            /* [retval][out] */ IKernelPointer **pVal);
        
        /* [helpstring][id][propputref] */ HRESULT ( STDMETHODCALLTYPE *putref_kernel )( 
            ISymbolicImage * This,
            /* [in] */ IKernelPointer *newVal);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphDimension )( 
            ISymbolicImage * This,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphInfo )( 
            ISymbolicImage * This,
            /* [retval][out] */ IGraphInfo **info);
        
        /* [helpstring][hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *acceptChilds )( 
            ISymbolicImage * This,
            /* [in] */ void **data);
        
        END_INTERFACE
    } ISymbolicImageVtbl;

    interface ISymbolicImage
    {
        CONST_VTBL struct ISymbolicImageVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISymbolicImage_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISymbolicImage_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISymbolicImage_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISymbolicImage_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISymbolicImage_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISymbolicImage_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISymbolicImage_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISymbolicImage_get_kernel(This,pVal)	\
    (This)->lpVtbl -> get_kernel(This,pVal)

#define ISymbolicImage_putref_kernel(This,newVal)	\
    (This)->lpVtbl -> putref_kernel(This,newVal)


#define ISymbolicImage_graphDimension(This,value)	\
    (This)->lpVtbl -> graphDimension(This,value)

#define ISymbolicImage_graphInfo(This,info)	\
    (This)->lpVtbl -> graphInfo(This,info)

#define ISymbolicImage_acceptChilds(This,data)	\
    (This)->lpVtbl -> acceptChilds(This,data)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ISymbolicImage_INTERFACE_DEFINED__ */


#ifndef __ISymbolicImageGraph_INTERFACE_DEFINED__
#define __ISymbolicImageGraph_INTERFACE_DEFINED__

/* interface ISymbolicImageGraph */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ISymbolicImageGraph;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9ACF69A8-E19E-424A-AEAB-A1573408F0AE")
    ISymbolicImageGraph : public ISymbolicImage
    {
    public:
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE setGraph( 
            /* [in] */ void *graph) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE getGraph( 
            /* [out] */ void **graph) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISymbolicImageGraphVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISymbolicImageGraph * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISymbolicImageGraph * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISymbolicImageGraph * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISymbolicImageGraph * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISymbolicImageGraph * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISymbolicImageGraph * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISymbolicImageGraph * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_kernel )( 
            ISymbolicImageGraph * This,
            /* [retval][out] */ IKernelPointer **pVal);
        
        /* [helpstring][id][propputref] */ HRESULT ( STDMETHODCALLTYPE *putref_kernel )( 
            ISymbolicImageGraph * This,
            /* [in] */ IKernelPointer *newVal);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphDimension )( 
            ISymbolicImageGraph * This,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphInfo )( 
            ISymbolicImageGraph * This,
            /* [retval][out] */ IGraphInfo **info);
        
        /* [helpstring][hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *acceptChilds )( 
            ISymbolicImageGraph * This,
            /* [in] */ void **data);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *setGraph )( 
            ISymbolicImageGraph * This,
            /* [in] */ void *graph);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *getGraph )( 
            ISymbolicImageGraph * This,
            /* [out] */ void **graph);
        
        END_INTERFACE
    } ISymbolicImageGraphVtbl;

    interface ISymbolicImageGraph
    {
        CONST_VTBL struct ISymbolicImageGraphVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISymbolicImageGraph_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISymbolicImageGraph_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISymbolicImageGraph_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISymbolicImageGraph_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISymbolicImageGraph_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISymbolicImageGraph_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISymbolicImageGraph_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISymbolicImageGraph_get_kernel(This,pVal)	\
    (This)->lpVtbl -> get_kernel(This,pVal)

#define ISymbolicImageGraph_putref_kernel(This,newVal)	\
    (This)->lpVtbl -> putref_kernel(This,newVal)


#define ISymbolicImageGraph_graphDimension(This,value)	\
    (This)->lpVtbl -> graphDimension(This,value)

#define ISymbolicImageGraph_graphInfo(This,info)	\
    (This)->lpVtbl -> graphInfo(This,info)

#define ISymbolicImageGraph_acceptChilds(This,data)	\
    (This)->lpVtbl -> acceptChilds(This,data)



#define ISymbolicImageGraph_setGraph(This,graph)	\
    (This)->lpVtbl -> setGraph(This,graph)

#define ISymbolicImageGraph_getGraph(This,graph)	\
    (This)->lpVtbl -> getGraph(This,graph)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE ISymbolicImageGraph_setGraph_Proxy( 
    ISymbolicImageGraph * This,
    /* [in] */ void *graph);


void __RPC_STUB ISymbolicImageGraph_setGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE ISymbolicImageGraph_getGraph_Proxy( 
    ISymbolicImageGraph * This,
    /* [out] */ void **graph);


void __RPC_STUB ISymbolicImageGraph_getGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISymbolicImageGraph_INTERFACE_DEFINED__ */


#ifndef __ISymbolicImageGroup_INTERFACE_DEFINED__
#define __ISymbolicImageGroup_INTERFACE_DEFINED__

/* interface ISymbolicImageGroup */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ISymbolicImageGroup;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("148EBD9B-8DB6-44DF-8148-0F71F2B07890")
    ISymbolicImageGroup : public ISymbolicImage
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE addNode( 
            /* [in] */ ISymbolicImageGraph *img) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE removeNode( 
            /* [in] */ ISymbolicImageGraph *img) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISymbolicImageGroupVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISymbolicImageGroup * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISymbolicImageGroup * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISymbolicImageGroup * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISymbolicImageGroup * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISymbolicImageGroup * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISymbolicImageGroup * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISymbolicImageGroup * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_kernel )( 
            ISymbolicImageGroup * This,
            /* [retval][out] */ IKernelPointer **pVal);
        
        /* [helpstring][id][propputref] */ HRESULT ( STDMETHODCALLTYPE *putref_kernel )( 
            ISymbolicImageGroup * This,
            /* [in] */ IKernelPointer *newVal);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphDimension )( 
            ISymbolicImageGroup * This,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphInfo )( 
            ISymbolicImageGroup * This,
            /* [retval][out] */ IGraphInfo **info);
        
        /* [helpstring][hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *acceptChilds )( 
            ISymbolicImageGroup * This,
            /* [in] */ void **data);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *addNode )( 
            ISymbolicImageGroup * This,
            /* [in] */ ISymbolicImageGraph *img);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *removeNode )( 
            ISymbolicImageGroup * This,
            /* [in] */ ISymbolicImageGraph *img);
        
        END_INTERFACE
    } ISymbolicImageGroupVtbl;

    interface ISymbolicImageGroup
    {
        CONST_VTBL struct ISymbolicImageGroupVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISymbolicImageGroup_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISymbolicImageGroup_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISymbolicImageGroup_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISymbolicImageGroup_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISymbolicImageGroup_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISymbolicImageGroup_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISymbolicImageGroup_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISymbolicImageGroup_get_kernel(This,pVal)	\
    (This)->lpVtbl -> get_kernel(This,pVal)

#define ISymbolicImageGroup_putref_kernel(This,newVal)	\
    (This)->lpVtbl -> putref_kernel(This,newVal)


#define ISymbolicImageGroup_graphDimension(This,value)	\
    (This)->lpVtbl -> graphDimension(This,value)

#define ISymbolicImageGroup_graphInfo(This,info)	\
    (This)->lpVtbl -> graphInfo(This,info)

#define ISymbolicImageGroup_acceptChilds(This,data)	\
    (This)->lpVtbl -> acceptChilds(This,data)



#define ISymbolicImageGroup_addNode(This,img)	\
    (This)->lpVtbl -> addNode(This,img)

#define ISymbolicImageGroup_removeNode(This,img)	\
    (This)->lpVtbl -> removeNode(This,img)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISymbolicImageGroup_addNode_Proxy( 
    ISymbolicImageGroup * This,
    /* [in] */ ISymbolicImageGraph *img);


void __RPC_STUB ISymbolicImageGroup_addNode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE ISymbolicImageGroup_removeNode_Proxy( 
    ISymbolicImageGroup * This,
    /* [in] */ ISymbolicImageGraph *img);


void __RPC_STUB ISymbolicImageGroup_removeNode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISymbolicImageGroup_INTERFACE_DEFINED__ */


#ifndef __IProjectiveBundleGraph_INTERFACE_DEFINED__
#define __IProjectiveBundleGraph_INTERFACE_DEFINED__

/* interface IProjectiveBundleGraph */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IProjectiveBundleGraph;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9A232764-6785-421F-811A-D47B6F3BC9BE")
    IProjectiveBundleGraph : public IProjectiveBundle
    {
    public:
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE setGraph( 
            /* [in] */ void *graph) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE getGraph( 
            /* [out] */ void **graph) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IProjectiveBundleGraphVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IProjectiveBundleGraph * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IProjectiveBundleGraph * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IProjectiveBundleGraph * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IProjectiveBundleGraph * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IProjectiveBundleGraph * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IProjectiveBundleGraph * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IProjectiveBundleGraph * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_kernel )( 
            IProjectiveBundleGraph * This,
            /* [retval][out] */ IKernelPointer **pVal);
        
        /* [helpstring][id][propputref] */ HRESULT ( STDMETHODCALLTYPE *putref_kernel )( 
            IProjectiveBundleGraph * This,
            /* [in] */ IKernelPointer *newVal);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphDimension )( 
            IProjectiveBundleGraph * This,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphInfo )( 
            IProjectiveBundleGraph * This,
            /* [retval][out] */ IGraphInfo **info);
        
        /* [helpstring][hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *acceptChilds )( 
            IProjectiveBundleGraph * This,
            /* [in] */ void **data);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *setGraph )( 
            IProjectiveBundleGraph * This,
            /* [in] */ void *graph);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *getGraph )( 
            IProjectiveBundleGraph * This,
            /* [out] */ void **graph);
        
        END_INTERFACE
    } IProjectiveBundleGraphVtbl;

    interface IProjectiveBundleGraph
    {
        CONST_VTBL struct IProjectiveBundleGraphVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IProjectiveBundleGraph_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IProjectiveBundleGraph_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IProjectiveBundleGraph_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IProjectiveBundleGraph_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IProjectiveBundleGraph_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IProjectiveBundleGraph_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IProjectiveBundleGraph_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IProjectiveBundleGraph_get_kernel(This,pVal)	\
    (This)->lpVtbl -> get_kernel(This,pVal)

#define IProjectiveBundleGraph_putref_kernel(This,newVal)	\
    (This)->lpVtbl -> putref_kernel(This,newVal)


#define IProjectiveBundleGraph_graphDimension(This,value)	\
    (This)->lpVtbl -> graphDimension(This,value)

#define IProjectiveBundleGraph_graphInfo(This,info)	\
    (This)->lpVtbl -> graphInfo(This,info)

#define IProjectiveBundleGraph_acceptChilds(This,data)	\
    (This)->lpVtbl -> acceptChilds(This,data)



#define IProjectiveBundleGraph_setGraph(This,graph)	\
    (This)->lpVtbl -> setGraph(This,graph)

#define IProjectiveBundleGraph_getGraph(This,graph)	\
    (This)->lpVtbl -> getGraph(This,graph)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IProjectiveBundleGraph_setGraph_Proxy( 
    IProjectiveBundleGraph * This,
    /* [in] */ void *graph);


void __RPC_STUB IProjectiveBundleGraph_setGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IProjectiveBundleGraph_getGraph_Proxy( 
    IProjectiveBundleGraph * This,
    /* [out] */ void **graph);


void __RPC_STUB IProjectiveBundleGraph_getGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IProjectiveBundleGraph_INTERFACE_DEFINED__ */


#ifndef __IProjectiveBundleGroup_INTERFACE_DEFINED__
#define __IProjectiveBundleGroup_INTERFACE_DEFINED__

/* interface IProjectiveBundleGroup */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IProjectiveBundleGroup;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("979E3895-84BD-489D-A0A9-C6C73D623CE2")
    IProjectiveBundleGroup : public IProjectiveBundle
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE addNode( 
            /* [in] */ IProjectiveBundleGraph *bn) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE removeNode( 
            /* [in] */ IProjectiveBundleGraph *img) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IProjectiveBundleGroupVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IProjectiveBundleGroup * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IProjectiveBundleGroup * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IProjectiveBundleGroup * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IProjectiveBundleGroup * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IProjectiveBundleGroup * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IProjectiveBundleGroup * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IProjectiveBundleGroup * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_kernel )( 
            IProjectiveBundleGroup * This,
            /* [retval][out] */ IKernelPointer **pVal);
        
        /* [helpstring][id][propputref] */ HRESULT ( STDMETHODCALLTYPE *putref_kernel )( 
            IProjectiveBundleGroup * This,
            /* [in] */ IKernelPointer *newVal);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphDimension )( 
            IProjectiveBundleGroup * This,
            /* [retval][out] */ int *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *graphInfo )( 
            IProjectiveBundleGroup * This,
            /* [retval][out] */ IGraphInfo **info);
        
        /* [helpstring][hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *acceptChilds )( 
            IProjectiveBundleGroup * This,
            /* [in] */ void **data);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *addNode )( 
            IProjectiveBundleGroup * This,
            /* [in] */ IProjectiveBundleGraph *bn);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *removeNode )( 
            IProjectiveBundleGroup * This,
            /* [in] */ IProjectiveBundleGraph *img);
        
        END_INTERFACE
    } IProjectiveBundleGroupVtbl;

    interface IProjectiveBundleGroup
    {
        CONST_VTBL struct IProjectiveBundleGroupVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IProjectiveBundleGroup_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IProjectiveBundleGroup_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IProjectiveBundleGroup_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IProjectiveBundleGroup_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IProjectiveBundleGroup_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IProjectiveBundleGroup_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IProjectiveBundleGroup_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IProjectiveBundleGroup_get_kernel(This,pVal)	\
    (This)->lpVtbl -> get_kernel(This,pVal)

#define IProjectiveBundleGroup_putref_kernel(This,newVal)	\
    (This)->lpVtbl -> putref_kernel(This,newVal)


#define IProjectiveBundleGroup_graphDimension(This,value)	\
    (This)->lpVtbl -> graphDimension(This,value)

#define IProjectiveBundleGroup_graphInfo(This,info)	\
    (This)->lpVtbl -> graphInfo(This,info)

#define IProjectiveBundleGroup_acceptChilds(This,data)	\
    (This)->lpVtbl -> acceptChilds(This,data)



#define IProjectiveBundleGroup_addNode(This,bn)	\
    (This)->lpVtbl -> addNode(This,bn)

#define IProjectiveBundleGroup_removeNode(This,img)	\
    (This)->lpVtbl -> removeNode(This,img)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IProjectiveBundleGroup_addNode_Proxy( 
    IProjectiveBundleGroup * This,
    /* [in] */ IProjectiveBundleGraph *bn);


void __RPC_STUB IProjectiveBundleGroup_addNode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IProjectiveBundleGroup_removeNode_Proxy( 
    IProjectiveBundleGroup * This,
    /* [in] */ IProjectiveBundleGraph *img);


void __RPC_STUB IProjectiveBundleGroup_removeNode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IProjectiveBundleGroup_INTERFACE_DEFINED__ */


#ifndef __ISerializerOutputData_INTERFACE_DEFINED__
#define __ISerializerOutputData_INTERFACE_DEFINED__

/* interface ISerializerOutputData */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_ISerializerOutputData;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("F42FA761-5767-4C66-8E91-4AC5EC15AE2E")
    ISerializerOutputData : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE FileName( 
            /* [retval][out] */ BSTR *fileName) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SaveWithID( 
            /* [in] */ IKernelNode *node,
            /* [retval][out] */ int *ID) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISerializerOutputDataVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISerializerOutputData * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISerializerOutputData * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISerializerOutputData * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISerializerOutputData * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISerializerOutputData * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISerializerOutputData * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISerializerOutputData * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *FileName )( 
            ISerializerOutputData * This,
            /* [retval][out] */ BSTR *fileName);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SaveWithID )( 
            ISerializerOutputData * This,
            /* [in] */ IKernelNode *node,
            /* [retval][out] */ int *ID);
        
        END_INTERFACE
    } ISerializerOutputDataVtbl;

    interface ISerializerOutputData
    {
        CONST_VTBL struct ISerializerOutputDataVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISerializerOutputData_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISerializerOutputData_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISerializerOutputData_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISerializerOutputData_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISerializerOutputData_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISerializerOutputData_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISerializerOutputData_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISerializerOutputData_FileName(This,fileName)	\
    (This)->lpVtbl -> FileName(This,fileName)

#define ISerializerOutputData_SaveWithID(This,node,ID)	\
    (This)->lpVtbl -> SaveWithID(This,node,ID)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE ISerializerOutputData_FileName_Proxy( 
    ISerializerOutputData * This,
    /* [retval][out] */ BSTR *fileName);


void __RPC_STUB ISerializerOutputData_FileName_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE ISerializerOutputData_SaveWithID_Proxy( 
    ISerializerOutputData * This,
    /* [in] */ IKernelNode *node,
    /* [retval][out] */ int *ID);


void __RPC_STUB ISerializerOutputData_SaveWithID_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISerializerOutputData_INTERFACE_DEFINED__ */


#ifndef __ISerializerInputData_INTERFACE_DEFINED__
#define __ISerializerInputData_INTERFACE_DEFINED__

/* interface ISerializerInputData */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_ISerializerInputData;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("5F688D62-BCE3-4787-95C5-36118686C2D1")
    ISerializerInputData : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE FileName( 
            /* [retval][out] */ BSTR *fileName) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE LoadByID( 
            /* [in] */ int ID,
            /* [retval][out] */ IKernelNode **node) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISerializerInputDataVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISerializerInputData * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISerializerInputData * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISerializerInputData * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISerializerInputData * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISerializerInputData * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISerializerInputData * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISerializerInputData * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *FileName )( 
            ISerializerInputData * This,
            /* [retval][out] */ BSTR *fileName);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *LoadByID )( 
            ISerializerInputData * This,
            /* [in] */ int ID,
            /* [retval][out] */ IKernelNode **node);
        
        END_INTERFACE
    } ISerializerInputDataVtbl;

    interface ISerializerInputData
    {
        CONST_VTBL struct ISerializerInputDataVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISerializerInputData_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISerializerInputData_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISerializerInputData_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISerializerInputData_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISerializerInputData_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISerializerInputData_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISerializerInputData_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISerializerInputData_FileName(This,fileName)	\
    (This)->lpVtbl -> FileName(This,fileName)

#define ISerializerInputData_LoadByID(This,ID,node)	\
    (This)->lpVtbl -> LoadByID(This,ID,node)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE ISerializerInputData_FileName_Proxy( 
    ISerializerInputData * This,
    /* [retval][out] */ BSTR *fileName);


void __RPC_STUB ISerializerInputData_FileName_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE ISerializerInputData_LoadByID_Proxy( 
    ISerializerInputData * This,
    /* [in] */ int ID,
    /* [retval][out] */ IKernelNode **node);


void __RPC_STUB ISerializerInputData_LoadByID_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISerializerInputData_INTERFACE_DEFINED__ */


#ifndef __ISerializer_INTERFACE_DEFINED__
#define __ISerializer_INTERFACE_DEFINED__

/* interface ISerializer */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ISerializer;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("EEDA2826-2706-49B4-9896-D3454C400754")
    ISerializer : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE LoadKernelNode( 
            /* [in] */ ISerializerInputData *data,
            /* [in] */ IKernel *kernel,
            /* [retval][out] */ IKernelNode **node) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SaveKernelNode( 
            /* [in] */ ISerializerOutputData *output,
            /* [in] */ IKernelNode *node) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SupportSerialization( 
            /* [in] */ IKernelNode *node,
            /* [retval][out] */ VARIANT_BOOL *result) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISerializerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISerializer * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISerializer * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISerializer * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISerializer * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISerializer * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISerializer * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISerializer * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *LoadKernelNode )( 
            ISerializer * This,
            /* [in] */ ISerializerInputData *data,
            /* [in] */ IKernel *kernel,
            /* [retval][out] */ IKernelNode **node);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SaveKernelNode )( 
            ISerializer * This,
            /* [in] */ ISerializerOutputData *output,
            /* [in] */ IKernelNode *node);
        
        HRESULT ( STDMETHODCALLTYPE *SupportSerialization )( 
            ISerializer * This,
            /* [in] */ IKernelNode *node,
            /* [retval][out] */ VARIANT_BOOL *result);
        
        END_INTERFACE
    } ISerializerVtbl;

    interface ISerializer
    {
        CONST_VTBL struct ISerializerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISerializer_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISerializer_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISerializer_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISerializer_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISerializer_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISerializer_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISerializer_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISerializer_LoadKernelNode(This,data,kernel,node)	\
    (This)->lpVtbl -> LoadKernelNode(This,data,kernel,node)

#define ISerializer_SaveKernelNode(This,output,node)	\
    (This)->lpVtbl -> SaveKernelNode(This,output,node)

#define ISerializer_SupportSerialization(This,node,result)	\
    (This)->lpVtbl -> SupportSerialization(This,node,result)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE ISerializer_LoadKernelNode_Proxy( 
    ISerializer * This,
    /* [in] */ ISerializerInputData *data,
    /* [in] */ IKernel *kernel,
    /* [retval][out] */ IKernelNode **node);


void __RPC_STUB ISerializer_LoadKernelNode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE ISerializer_SaveKernelNode_Proxy( 
    ISerializer * This,
    /* [in] */ ISerializerOutputData *output,
    /* [in] */ IKernelNode *node);


void __RPC_STUB ISerializer_SaveKernelNode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE ISerializer_SupportSerialization_Proxy( 
    ISerializer * This,
    /* [in] */ IKernelNode *node,
    /* [retval][out] */ VARIANT_BOOL *result);


void __RPC_STUB ISerializer_SupportSerialization_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISerializer_INTERFACE_DEFINED__ */



#ifndef __MorseKernelATL_LIBRARY_DEFINED__
#define __MorseKernelATL_LIBRARY_DEFINED__

/* library MorseKernelATL */
/* [helpstring][custom][uuid][version] */ 


EXTERN_C const IID LIBID_MorseKernelATL;

EXTERN_C const CLSID CLSID_CGraphInfo;

#ifdef __cplusplus

class DECLSPEC_UUID("A7C5C80A-DA2F-4900-8042-9EBA1C1B0F4B")
CGraphInfo;
#endif

EXTERN_C const CLSID CLSID_CCompReg;

#ifdef __cplusplus

class DECLSPEC_UUID("58BF9B64-D15E-4C43-9BA5-D579CF30099C")
CCompReg;
#endif

EXTERN_C const CLSID CLSID_CFunction;

#ifdef __cplusplus

class DECLSPEC_UUID("95B0D0F5-D7BD-48D8-B13A-5E5538F334E9")
CFunction;
#endif

#ifndef __IKernelEvents_DISPINTERFACE_DEFINED__
#define __IKernelEvents_DISPINTERFACE_DEFINED__

/* dispinterface IKernelEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID_IKernelEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("7B44B0BB-0C63-4216-80B1-E228565DF73D")
    IKernelEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct IKernelEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IKernelEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IKernelEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IKernelEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IKernelEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IKernelEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IKernelEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IKernelEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IKernelEventsVtbl;

    interface IKernelEvents
    {
        CONST_VTBL struct IKernelEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IKernelEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IKernelEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IKernelEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IKernelEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IKernelEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IKernelEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IKernelEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __IKernelEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_CKernel;

#ifdef __cplusplus

class DECLSPEC_UUID("4C18DA89-C2C3-480B-8099-149918E4AE43")
CKernel;
#endif

EXTERN_C const CLSID CLSID_CComputationGraphResult;

#ifdef __cplusplus

class DECLSPEC_UUID("83FCA237-5E87-49D4-81EE-95BC812422FE")
CComputationGraphResult;
#endif

EXTERN_C const CLSID CLSID_CDummy;

#ifdef __cplusplus

class DECLSPEC_UUID("6C167CEC-20C8-45B4-B6C5-E59E15B3D19E")
CDummy;
#endif

EXTERN_C const CLSID CLSID_CMorseSpectrum;

#ifdef __cplusplus

class DECLSPEC_UUID("BF5438F7-B6B4-457C-843E-C46539C7A2F7")
CMorseSpectrum;
#endif

EXTERN_C const CLSID CLSID_CSymbolicImageGraph;

#ifdef __cplusplus

class DECLSPEC_UUID("A3AE65EC-004B-4CA9-937B-12565400662C")
CSymbolicImageGraph;
#endif

EXTERN_C const CLSID CLSID_CSymbolicImageGroup;

#ifdef __cplusplus

class DECLSPEC_UUID("00414483-2F27-43B5-B7A6-68A9E9674CC9")
CSymbolicImageGroup;
#endif

EXTERN_C const CLSID CLSID_CProjectiveBundleGraph;

#ifdef __cplusplus

class DECLSPEC_UUID("0FF20A2F-2518-4146-838A-EB5C0B42DD7B")
CProjectiveBundleGraph;
#endif

EXTERN_C const CLSID CLSID_CProjectiveBundleGroup;

#ifdef __cplusplus

class DECLSPEC_UUID("520018A2-475A-4FB5-A780-E1291049BAB5")
CProjectiveBundleGroup;
#endif

EXTERN_C const CLSID CLSID_CSerializer;

#ifdef __cplusplus

class DECLSPEC_UUID("3B39CBCB-C514-44FA-9FB3-79A822F13C3C")
CSerializer;
#endif
#endif /* __MorseKernelATL_LIBRARY_DEFINED__ */

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


