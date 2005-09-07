

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0361 */
/* at Thu Sep 08 00:36:59 2005
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


#ifndef __IParameters_FWD_DEFINED__
#define __IParameters_FWD_DEFINED__
typedef interface IParameters IParameters;
#endif 	/* __IParameters_FWD_DEFINED__ */


#ifndef __IProgressBarInfo_FWD_DEFINED__
#define __IProgressBarInfo_FWD_DEFINED__
typedef interface IProgressBarInfo IProgressBarInfo;
#endif 	/* __IProgressBarInfo_FWD_DEFINED__ */


#ifndef __IResultBase_FWD_DEFINED__
#define __IResultBase_FWD_DEFINED__
typedef interface IResultBase IResultBase;
#endif 	/* __IResultBase_FWD_DEFINED__ */


#ifndef __IResultSet_FWD_DEFINED__
#define __IResultSet_FWD_DEFINED__
typedef interface IResultSet IResultSet;
#endif 	/* __IResultSet_FWD_DEFINED__ */


#ifndef __IAction_FWD_DEFINED__
#define __IAction_FWD_DEFINED__
typedef interface IAction IAction;
#endif 	/* __IAction_FWD_DEFINED__ */


#ifndef __IFunction_FWD_DEFINED__
#define __IFunction_FWD_DEFINED__
typedef interface IFunction IFunction;
#endif 	/* __IFunction_FWD_DEFINED__ */


#ifndef __IComputationParameters_FWD_DEFINED__
#define __IComputationParameters_FWD_DEFINED__
typedef interface IComputationParameters IComputationParameters;
#endif 	/* __IComputationParameters_FWD_DEFINED__ */


#ifndef __IAdaptiveMethodAction_FWD_DEFINED__
#define __IAdaptiveMethodAction_FWD_DEFINED__
typedef interface IAdaptiveMethodAction IAdaptiveMethodAction;
#endif 	/* __IAdaptiveMethodAction_FWD_DEFINED__ */


#ifndef __IAdaptiveMethodParameters_FWD_DEFINED__
#define __IAdaptiveMethodParameters_FWD_DEFINED__
typedef interface IAdaptiveMethodParameters IAdaptiveMethodParameters;
#endif 	/* __IAdaptiveMethodParameters_FWD_DEFINED__ */


#ifndef __IResultMetadata_FWD_DEFINED__
#define __IResultMetadata_FWD_DEFINED__
typedef interface IResultMetadata IResultMetadata;
#endif 	/* __IResultMetadata_FWD_DEFINED__ */


#ifndef __IResult_FWD_DEFINED__
#define __IResult_FWD_DEFINED__
typedef interface IResult IResult;
#endif 	/* __IResult_FWD_DEFINED__ */


#ifndef __IGraphInfo_FWD_DEFINED__
#define __IGraphInfo_FWD_DEFINED__
typedef interface IGraphInfo IGraphInfo;
#endif 	/* __IGraphInfo_FWD_DEFINED__ */


#ifndef __IGraphResult_FWD_DEFINED__
#define __IGraphResult_FWD_DEFINED__
typedef interface IGraphResult IGraphResult;
#endif 	/* __IGraphResult_FWD_DEFINED__ */


#ifndef __IWritableGraphResult_FWD_DEFINED__
#define __IWritableGraphResult_FWD_DEFINED__
typedef interface IWritableGraphResult IWritableGraphResult;
#endif 	/* __IWritableGraphResult_FWD_DEFINED__ */


#ifndef __IWritableResultSet_FWD_DEFINED__
#define __IWritableResultSet_FWD_DEFINED__
typedef interface IWritableResultSet IWritableResultSet;
#endif 	/* __IWritableResultSet_FWD_DEFINED__ */


#ifndef __IGraphResultImpl_FWD_DEFINED__
#define __IGraphResultImpl_FWD_DEFINED__
typedef interface IGraphResultImpl IGraphResultImpl;
#endif 	/* __IGraphResultImpl_FWD_DEFINED__ */


#ifndef __ISymbolicImageMetadata_FWD_DEFINED__
#define __ISymbolicImageMetadata_FWD_DEFINED__
typedef interface ISymbolicImageMetadata ISymbolicImageMetadata;
#endif 	/* __ISymbolicImageMetadata_FWD_DEFINED__ */


#ifndef __IBoxMethodAction_FWD_DEFINED__
#define __IBoxMethodAction_FWD_DEFINED__
typedef interface IBoxMethodAction IBoxMethodAction;
#endif 	/* __IBoxMethodAction_FWD_DEFINED__ */


#ifndef __IBoxMethodParameters_FWD_DEFINED__
#define __IBoxMethodParameters_FWD_DEFINED__
typedef interface IBoxMethodParameters IBoxMethodParameters;
#endif 	/* __IBoxMethodParameters_FWD_DEFINED__ */


#ifndef __IComponentRegistrar_FWD_DEFINED__
#define __IComponentRegistrar_FWD_DEFINED__
typedef interface IComponentRegistrar IComponentRegistrar;
#endif 	/* __IComponentRegistrar_FWD_DEFINED__ */


#ifndef __ITarjanAction_FWD_DEFINED__
#define __ITarjanAction_FWD_DEFINED__
typedef interface ITarjanAction ITarjanAction;
#endif 	/* __ITarjanAction_FWD_DEFINED__ */


#ifndef __ITarjanParameters_FWD_DEFINED__
#define __ITarjanParameters_FWD_DEFINED__
typedef interface ITarjanParameters ITarjanParameters;
#endif 	/* __ITarjanParameters_FWD_DEFINED__ */


#ifndef __IPointMethodAction_FWD_DEFINED__
#define __IPointMethodAction_FWD_DEFINED__
typedef interface IPointMethodAction IPointMethodAction;
#endif 	/* __IPointMethodAction_FWD_DEFINED__ */


#ifndef __IPointMethodParameters_FWD_DEFINED__
#define __IPointMethodParameters_FWD_DEFINED__
typedef interface IPointMethodParameters IPointMethodParameters;
#endif 	/* __IPointMethodParameters_FWD_DEFINED__ */


#ifndef __IDummy_FWD_DEFINED__
#define __IDummy_FWD_DEFINED__
typedef interface IDummy IDummy;
#endif 	/* __IDummy_FWD_DEFINED__ */


#ifndef __IIsolatedSetAction_FWD_DEFINED__
#define __IIsolatedSetAction_FWD_DEFINED__
typedef interface IIsolatedSetAction IIsolatedSetAction;
#endif 	/* __IIsolatedSetAction_FWD_DEFINED__ */


#ifndef __IIsolatedSetParameters_FWD_DEFINED__
#define __IIsolatedSetParameters_FWD_DEFINED__
typedef interface IIsolatedSetParameters IIsolatedSetParameters;
#endif 	/* __IIsolatedSetParameters_FWD_DEFINED__ */


#ifndef __IMinimalLoopLocalizationAction_FWD_DEFINED__
#define __IMinimalLoopLocalizationAction_FWD_DEFINED__
typedef interface IMinimalLoopLocalizationAction IMinimalLoopLocalizationAction;
#endif 	/* __IMinimalLoopLocalizationAction_FWD_DEFINED__ */


#ifndef __IMinimalLoopLocalizationParameters_FWD_DEFINED__
#define __IMinimalLoopLocalizationParameters_FWD_DEFINED__
typedef interface IMinimalLoopLocalizationParameters IMinimalLoopLocalizationParameters;
#endif 	/* __IMinimalLoopLocalizationParameters_FWD_DEFINED__ */


#ifndef __ISIRomActionParameters_FWD_DEFINED__
#define __ISIRomActionParameters_FWD_DEFINED__
typedef interface ISIRomActionParameters ISIRomActionParameters;
#endif 	/* __ISIRomActionParameters_FWD_DEFINED__ */


#ifndef __ISIRomAction_FWD_DEFINED__
#define __ISIRomAction_FWD_DEFINED__
typedef interface ISIRomAction ISIRomAction;
#endif 	/* __ISIRomAction_FWD_DEFINED__ */


#ifndef __ISpectrumMetadata_FWD_DEFINED__
#define __ISpectrumMetadata_FWD_DEFINED__
typedef interface ISpectrumMetadata ISpectrumMetadata;
#endif 	/* __ISpectrumMetadata_FWD_DEFINED__ */


#ifndef __ISpectrumResult_FWD_DEFINED__
#define __ISpectrumResult_FWD_DEFINED__
typedef interface ISpectrumResult ISpectrumResult;
#endif 	/* __ISpectrumResult_FWD_DEFINED__ */


#ifndef __IDummy1_FWD_DEFINED__
#define __IDummy1_FWD_DEFINED__
typedef interface IDummy1 IDummy1;
#endif 	/* __IDummy1_FWD_DEFINED__ */


#ifndef __IDummy2_FWD_DEFINED__
#define __IDummy2_FWD_DEFINED__
typedef interface IDummy2 IDummy2;
#endif 	/* __IDummy2_FWD_DEFINED__ */


#ifndef __IMS2DCreationAction_FWD_DEFINED__
#define __IMS2DCreationAction_FWD_DEFINED__
typedef interface IMS2DCreationAction IMS2DCreationAction;
#endif 	/* __IMS2DCreationAction_FWD_DEFINED__ */


#ifndef __IMS2DCreationParameters_FWD_DEFINED__
#define __IMS2DCreationParameters_FWD_DEFINED__
typedef interface IMS2DCreationParameters IMS2DCreationParameters;
#endif 	/* __IMS2DCreationParameters_FWD_DEFINED__ */


#ifndef __IDummy3_FWD_DEFINED__
#define __IDummy3_FWD_DEFINED__
typedef interface IDummy3 IDummy3;
#endif 	/* __IDummy3_FWD_DEFINED__ */


#ifndef __IMS2DProcessAction_FWD_DEFINED__
#define __IMS2DProcessAction_FWD_DEFINED__
typedef interface IMS2DProcessAction IMS2DProcessAction;
#endif 	/* __IMS2DProcessAction_FWD_DEFINED__ */


#ifndef __IMS2DProcessParameters_FWD_DEFINED__
#define __IMS2DProcessParameters_FWD_DEFINED__
typedef interface IMS2DProcessParameters IMS2DProcessParameters;
#endif 	/* __IMS2DProcessParameters_FWD_DEFINED__ */


#ifndef __IDummy4_FWD_DEFINED__
#define __IDummy4_FWD_DEFINED__
typedef interface IDummy4 IDummy4;
#endif 	/* __IDummy4_FWD_DEFINED__ */


#ifndef __IWritableFunction_FWD_DEFINED__
#define __IWritableFunction_FWD_DEFINED__
typedef interface IWritableFunction IWritableFunction;
#endif 	/* __IWritableFunction_FWD_DEFINED__ */


#ifndef __IWritableGraphInfo_FWD_DEFINED__
#define __IWritableGraphInfo_FWD_DEFINED__
typedef interface IWritableGraphInfo IWritableGraphInfo;
#endif 	/* __IWritableGraphInfo_FWD_DEFINED__ */


#ifndef __IGraphInfoImpl_FWD_DEFINED__
#define __IGraphInfoImpl_FWD_DEFINED__
typedef interface IGraphInfoImpl IGraphInfoImpl;
#endif 	/* __IGraphInfoImpl_FWD_DEFINED__ */


#ifndef __IResultSetImpl_FWD_DEFINED__
#define __IResultSetImpl_FWD_DEFINED__
typedef interface IResultSetImpl IResultSetImpl;
#endif 	/* __IResultSetImpl_FWD_DEFINED__ */


#ifndef __IKernell_FWD_DEFINED__
#define __IKernell_FWD_DEFINED__
typedef interface IKernell IKernell;
#endif 	/* __IKernell_FWD_DEFINED__ */


#ifndef __IWritableKernell_FWD_DEFINED__
#define __IWritableKernell_FWD_DEFINED__
typedef interface IWritableKernell IWritableKernell;
#endif 	/* __IWritableKernell_FWD_DEFINED__ */


#ifndef __IKernellImpl_FWD_DEFINED__
#define __IKernellImpl_FWD_DEFINED__
typedef interface IKernellImpl IKernellImpl;
#endif 	/* __IKernellImpl_FWD_DEFINED__ */


#ifndef __IMS2Metadata_FWD_DEFINED__
#define __IMS2Metadata_FWD_DEFINED__
typedef interface IMS2Metadata IMS2Metadata;
#endif 	/* __IMS2Metadata_FWD_DEFINED__ */


#ifndef __IMS2DRomAction_FWD_DEFINED__
#define __IMS2DRomAction_FWD_DEFINED__
typedef interface IMS2DRomAction IMS2DRomAction;
#endif 	/* __IMS2DRomAction_FWD_DEFINED__ */


#ifndef __IWritableSpectrumResult_FWD_DEFINED__
#define __IWritableSpectrumResult_FWD_DEFINED__
typedef interface IWritableSpectrumResult IWritableSpectrumResult;
#endif 	/* __IWritableSpectrumResult_FWD_DEFINED__ */


#ifndef __CAdaptiveMethodAction_FWD_DEFINED__
#define __CAdaptiveMethodAction_FWD_DEFINED__

#ifdef __cplusplus
typedef class CAdaptiveMethodAction CAdaptiveMethodAction;
#else
typedef struct CAdaptiveMethodAction CAdaptiveMethodAction;
#endif /* __cplusplus */

#endif 	/* __CAdaptiveMethodAction_FWD_DEFINED__ */


#ifndef __CGraphResultImpl_FWD_DEFINED__
#define __CGraphResultImpl_FWD_DEFINED__

#ifdef __cplusplus
typedef class CGraphResultImpl CGraphResultImpl;
#else
typedef struct CGraphResultImpl CGraphResultImpl;
#endif /* __cplusplus */

#endif 	/* __CGraphResultImpl_FWD_DEFINED__ */


#ifndef __CSymbolicImageMetadata_FWD_DEFINED__
#define __CSymbolicImageMetadata_FWD_DEFINED__

#ifdef __cplusplus
typedef class CSymbolicImageMetadata CSymbolicImageMetadata;
#else
typedef struct CSymbolicImageMetadata CSymbolicImageMetadata;
#endif /* __cplusplus */

#endif 	/* __CSymbolicImageMetadata_FWD_DEFINED__ */


#ifndef __CBoxMethodAction_FWD_DEFINED__
#define __CBoxMethodAction_FWD_DEFINED__

#ifdef __cplusplus
typedef class CBoxMethodAction CBoxMethodAction;
#else
typedef struct CBoxMethodAction CBoxMethodAction;
#endif /* __cplusplus */

#endif 	/* __CBoxMethodAction_FWD_DEFINED__ */


#ifndef __CCompReg_FWD_DEFINED__
#define __CCompReg_FWD_DEFINED__

#ifdef __cplusplus
typedef class CCompReg CCompReg;
#else
typedef struct CCompReg CCompReg;
#endif /* __cplusplus */

#endif 	/* __CCompReg_FWD_DEFINED__ */


#ifndef __CTarjanAction_FWD_DEFINED__
#define __CTarjanAction_FWD_DEFINED__

#ifdef __cplusplus
typedef class CTarjanAction CTarjanAction;
#else
typedef struct CTarjanAction CTarjanAction;
#endif /* __cplusplus */

#endif 	/* __CTarjanAction_FWD_DEFINED__ */


#ifndef __CPointMethodAction_FWD_DEFINED__
#define __CPointMethodAction_FWD_DEFINED__

#ifdef __cplusplus
typedef class CPointMethodAction CPointMethodAction;
#else
typedef struct CPointMethodAction CPointMethodAction;
#endif /* __cplusplus */

#endif 	/* __CPointMethodAction_FWD_DEFINED__ */


#ifndef __CDummy_FWD_DEFINED__
#define __CDummy_FWD_DEFINED__

#ifdef __cplusplus
typedef class CDummy CDummy;
#else
typedef struct CDummy CDummy;
#endif /* __cplusplus */

#endif 	/* __CDummy_FWD_DEFINED__ */


#ifndef __CIsolatedSetAction_FWD_DEFINED__
#define __CIsolatedSetAction_FWD_DEFINED__

#ifdef __cplusplus
typedef class CIsolatedSetAction CIsolatedSetAction;
#else
typedef struct CIsolatedSetAction CIsolatedSetAction;
#endif /* __cplusplus */

#endif 	/* __CIsolatedSetAction_FWD_DEFINED__ */


#ifndef __CMinimalLoopLocalizationAction_FWD_DEFINED__
#define __CMinimalLoopLocalizationAction_FWD_DEFINED__

#ifdef __cplusplus
typedef class CMinimalLoopLocalizationAction CMinimalLoopLocalizationAction;
#else
typedef struct CMinimalLoopLocalizationAction CMinimalLoopLocalizationAction;
#endif /* __cplusplus */

#endif 	/* __CMinimalLoopLocalizationAction_FWD_DEFINED__ */


#ifndef __CSIRomAction_FWD_DEFINED__
#define __CSIRomAction_FWD_DEFINED__

#ifdef __cplusplus
typedef class CSIRomAction CSIRomAction;
#else
typedef struct CSIRomAction CSIRomAction;
#endif /* __cplusplus */

#endif 	/* __CSIRomAction_FWD_DEFINED__ */


#ifndef __CSpectrumMetadata_FWD_DEFINED__
#define __CSpectrumMetadata_FWD_DEFINED__

#ifdef __cplusplus
typedef class CSpectrumMetadata CSpectrumMetadata;
#else
typedef struct CSpectrumMetadata CSpectrumMetadata;
#endif /* __cplusplus */

#endif 	/* __CSpectrumMetadata_FWD_DEFINED__ */


#ifndef __CDummy1_FWD_DEFINED__
#define __CDummy1_FWD_DEFINED__

#ifdef __cplusplus
typedef class CDummy1 CDummy1;
#else
typedef struct CDummy1 CDummy1;
#endif /* __cplusplus */

#endif 	/* __CDummy1_FWD_DEFINED__ */


#ifndef __CDummy2_FWD_DEFINED__
#define __CDummy2_FWD_DEFINED__

#ifdef __cplusplus
typedef class CDummy2 CDummy2;
#else
typedef struct CDummy2 CDummy2;
#endif /* __cplusplus */

#endif 	/* __CDummy2_FWD_DEFINED__ */


#ifndef __CMS2DCreationAction_FWD_DEFINED__
#define __CMS2DCreationAction_FWD_DEFINED__

#ifdef __cplusplus
typedef class CMS2DCreationAction CMS2DCreationAction;
#else
typedef struct CMS2DCreationAction CMS2DCreationAction;
#endif /* __cplusplus */

#endif 	/* __CMS2DCreationAction_FWD_DEFINED__ */


#ifndef __CDummy3_FWD_DEFINED__
#define __CDummy3_FWD_DEFINED__

#ifdef __cplusplus
typedef class CDummy3 CDummy3;
#else
typedef struct CDummy3 CDummy3;
#endif /* __cplusplus */

#endif 	/* __CDummy3_FWD_DEFINED__ */


#ifndef __CMS2DProcessAction_FWD_DEFINED__
#define __CMS2DProcessAction_FWD_DEFINED__

#ifdef __cplusplus
typedef class CMS2DProcessAction CMS2DProcessAction;
#else
typedef struct CMS2DProcessAction CMS2DProcessAction;
#endif /* __cplusplus */

#endif 	/* __CMS2DProcessAction_FWD_DEFINED__ */


#ifndef __CDummy4_FWD_DEFINED__
#define __CDummy4_FWD_DEFINED__

#ifdef __cplusplus
typedef class CDummy4 CDummy4;
#else
typedef struct CDummy4 CDummy4;
#endif /* __cplusplus */

#endif 	/* __CDummy4_FWD_DEFINED__ */


#ifndef __CFunctionImpl_FWD_DEFINED__
#define __CFunctionImpl_FWD_DEFINED__

#ifdef __cplusplus
typedef class CFunctionImpl CFunctionImpl;
#else
typedef struct CFunctionImpl CFunctionImpl;
#endif /* __cplusplus */

#endif 	/* __CFunctionImpl_FWD_DEFINED__ */


#ifndef __CGraphInfoImpl_FWD_DEFINED__
#define __CGraphInfoImpl_FWD_DEFINED__

#ifdef __cplusplus
typedef class CGraphInfoImpl CGraphInfoImpl;
#else
typedef struct CGraphInfoImpl CGraphInfoImpl;
#endif /* __cplusplus */

#endif 	/* __CGraphInfoImpl_FWD_DEFINED__ */


#ifndef __CResultSetImpl_FWD_DEFINED__
#define __CResultSetImpl_FWD_DEFINED__

#ifdef __cplusplus
typedef class CResultSetImpl CResultSetImpl;
#else
typedef struct CResultSetImpl CResultSetImpl;
#endif /* __cplusplus */

#endif 	/* __CResultSetImpl_FWD_DEFINED__ */


#ifndef __CKernellImpl_FWD_DEFINED__
#define __CKernellImpl_FWD_DEFINED__

#ifdef __cplusplus
typedef class CKernellImpl CKernellImpl;
#else
typedef struct CKernellImpl CKernellImpl;
#endif /* __cplusplus */

#endif 	/* __CKernellImpl_FWD_DEFINED__ */


#ifndef __CMS2Metadata_FWD_DEFINED__
#define __CMS2Metadata_FWD_DEFINED__

#ifdef __cplusplus
typedef class CMS2Metadata CMS2Metadata;
#else
typedef struct CMS2Metadata CMS2Metadata;
#endif /* __cplusplus */

#endif 	/* __CMS2Metadata_FWD_DEFINED__ */


#ifndef __CMS2DRomAction_FWD_DEFINED__
#define __CMS2DRomAction_FWD_DEFINED__

#ifdef __cplusplus
typedef class CMS2DRomAction CMS2DRomAction;
#else
typedef struct CMS2DRomAction CMS2DRomAction;
#endif /* __cplusplus */

#endif 	/* __CMS2DRomAction_FWD_DEFINED__ */


#ifndef __CSpectrumResultImpl_FWD_DEFINED__
#define __CSpectrumResultImpl_FWD_DEFINED__

#ifdef __cplusplus
typedef class CSpectrumResultImpl CSpectrumResultImpl;
#else
typedef struct CSpectrumResultImpl CSpectrumResultImpl;
#endif /* __cplusplus */

#endif 	/* __CSpectrumResultImpl_FWD_DEFINED__ */


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
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Length( 
            /* [retval][out] */ int *length) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Next( void) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE NeedStop( 
            /* [retval][out] */ VARIANT_BOOL *stop) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Start( void) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Finish( void) = 0;
        
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
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Length )( 
            IProgressBarInfo * This,
            /* [retval][out] */ int *length);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Next )( 
            IProgressBarInfo * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *NeedStop )( 
            IProgressBarInfo * This,
            /* [retval][out] */ VARIANT_BOOL *stop);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Start )( 
            IProgressBarInfo * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Finish )( 
            IProgressBarInfo * This);
        
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


#define IProgressBarInfo_Length(This,length)	\
    (This)->lpVtbl -> Length(This,length)

#define IProgressBarInfo_Next(This)	\
    (This)->lpVtbl -> Next(This)

#define IProgressBarInfo_NeedStop(This,stop)	\
    (This)->lpVtbl -> NeedStop(This,stop)

#define IProgressBarInfo_Start(This)	\
    (This)->lpVtbl -> Start(This)

#define IProgressBarInfo_Finish(This)	\
    (This)->lpVtbl -> Finish(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IProgressBarInfo_Length_Proxy( 
    IProgressBarInfo * This,
    /* [retval][out] */ int *length);


void __RPC_STUB IProgressBarInfo_Length_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IProgressBarInfo_Next_Proxy( 
    IProgressBarInfo * This);


void __RPC_STUB IProgressBarInfo_Next_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IProgressBarInfo_NeedStop_Proxy( 
    IProgressBarInfo * This,
    /* [retval][out] */ VARIANT_BOOL *stop);


void __RPC_STUB IProgressBarInfo_NeedStop_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IProgressBarInfo_Start_Proxy( 
    IProgressBarInfo * This);


void __RPC_STUB IProgressBarInfo_Start_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IProgressBarInfo_Finish_Proxy( 
    IProgressBarInfo * This);


void __RPC_STUB IProgressBarInfo_Finish_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IProgressBarInfo_INTERFACE_DEFINED__ */


#ifndef __IResultBase_INTERFACE_DEFINED__
#define __IResultBase_INTERFACE_DEFINED__

/* interface IResultBase */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IResultBase;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("92F4EEEF-602A-496D-8067-5184F4F1D37B")
    IResultBase : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IResultBaseVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IResultBase * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IResultBase * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IResultBase * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IResultBase * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IResultBase * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IResultBase * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IResultBase * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IResultBaseVtbl;

    interface IResultBase
    {
        CONST_VTBL struct IResultBaseVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IResultBase_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IResultBase_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IResultBase_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IResultBase_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IResultBase_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IResultBase_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IResultBase_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IResultBase_INTERFACE_DEFINED__ */


#ifndef __IResultSet_INTERFACE_DEFINED__
#define __IResultSet_INTERFACE_DEFINED__

/* interface IResultSet */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IResultSet;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("5498E339-8014-4366-9092-13EB8AD35E1D")
    IResultSet : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetCount( 
            /* [retval][out] */ int *count) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetResult( 
            /* [in] */ int index,
            /* [retval][out] */ IResultBase **result) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IResultSetVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IResultSet * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IResultSet * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IResultSet * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IResultSet * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IResultSet * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IResultSet * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IResultSet * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetCount )( 
            IResultSet * This,
            /* [retval][out] */ int *count);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetResult )( 
            IResultSet * This,
            /* [in] */ int index,
            /* [retval][out] */ IResultBase **result);
        
        END_INTERFACE
    } IResultSetVtbl;

    interface IResultSet
    {
        CONST_VTBL struct IResultSetVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IResultSet_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IResultSet_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IResultSet_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IResultSet_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IResultSet_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IResultSet_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IResultSet_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IResultSet_GetCount(This,count)	\
    (This)->lpVtbl -> GetCount(This,count)

#define IResultSet_GetResult(This,index,result)	\
    (This)->lpVtbl -> GetResult(This,index,result)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IResultSet_GetCount_Proxy( 
    IResultSet * This,
    /* [retval][out] */ int *count);


void __RPC_STUB IResultSet_GetCount_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IResultSet_GetResult_Proxy( 
    IResultSet * This,
    /* [in] */ int index,
    /* [retval][out] */ IResultBase **result);


void __RPC_STUB IResultSet_GetResult_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IResultSet_INTERFACE_DEFINED__ */


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
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetActionParameters( 
            /* [in] */ IParameters *parameters) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetProgressBarInfo( 
            /* [in] */ IProgressBarInfo *pinfo) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE CanDo( 
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Do( 
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output) = 0;
        
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
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            IAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            IAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanDo )( 
            IAction * This,
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            IAction * This,
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output);
        
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



#define IAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define IAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#define IAction_CanDo(This,result,can)	\
    (This)->lpVtbl -> CanDo(This,result,can)

#define IAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IAction_SetActionParameters_Proxy( 
    IAction * This,
    /* [in] */ IParameters *parameters);


void __RPC_STUB IAction_SetActionParameters_Stub(
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


/* [id] */ HRESULT STDMETHODCALLTYPE IAction_CanDo_Proxy( 
    IAction * This,
    /* [in] */ IResultSet *result,
    /* [retval][out] */ VARIANT_BOOL *can);


void __RPC_STUB IAction_CanDo_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IAction_Do_Proxy( 
    IAction * This,
    /* [in] */ IResultSet *input,
    /* [retval][out] */ IResultSet **output);


void __RPC_STUB IAction_Do_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAction_INTERFACE_DEFINED__ */


#ifndef __IFunction_INTERFACE_DEFINED__
#define __IFunction_INTERFACE_DEFINED__

/* interface IFunction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IFunction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("63B946E2-2AEE-4034-BA1C-1B4CFD68CEC0")
    IFunction : public IDispatch
    {
    public:
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE GetSystemFunction( 
            /* [out] */ void **function) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE GetSystemFunctionDerivate( 
            /* [out] */ void **function) = 0;
        
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE CreateGraph( 
            /* [out] */ void **graph) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetEquations( 
            /* [retval][out] */ BSTR *equations) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetDimension( 
            /* [retval][out] */ int *dimenstion) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetIterations( 
            /* [retval][out] */ int *iterations) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetMinimum( 
            /* [in] */ int id,
            /* [retval][out] */ double *value) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetMaximum( 
            /* [in] */ int id,
            /* [retval][out] */ double *value) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetLipshitz( 
            /* [in] */ int id,
            /* [retval][out] */ double *value) = 0;
        
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
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *GetSystemFunction )( 
            IFunction * This,
            /* [out] */ void **function);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *GetSystemFunctionDerivate )( 
            IFunction * This,
            /* [out] */ void **function);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *CreateGraph )( 
            IFunction * This,
            /* [out] */ void **graph);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetEquations )( 
            IFunction * This,
            /* [retval][out] */ BSTR *equations);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetDimension )( 
            IFunction * This,
            /* [retval][out] */ int *dimenstion);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetIterations )( 
            IFunction * This,
            /* [retval][out] */ int *iterations);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetMinimum )( 
            IFunction * This,
            /* [in] */ int id,
            /* [retval][out] */ double *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetMaximum )( 
            IFunction * This,
            /* [in] */ int id,
            /* [retval][out] */ double *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetLipshitz )( 
            IFunction * This,
            /* [in] */ int id,
            /* [retval][out] */ double *value);
        
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


#define IFunction_GetSystemFunction(This,function)	\
    (This)->lpVtbl -> GetSystemFunction(This,function)

#define IFunction_GetSystemFunctionDerivate(This,function)	\
    (This)->lpVtbl -> GetSystemFunctionDerivate(This,function)

#define IFunction_CreateGraph(This,graph)	\
    (This)->lpVtbl -> CreateGraph(This,graph)

#define IFunction_GetEquations(This,equations)	\
    (This)->lpVtbl -> GetEquations(This,equations)

#define IFunction_GetDimension(This,dimenstion)	\
    (This)->lpVtbl -> GetDimension(This,dimenstion)

#define IFunction_GetIterations(This,iterations)	\
    (This)->lpVtbl -> GetIterations(This,iterations)

#define IFunction_GetMinimum(This,id,value)	\
    (This)->lpVtbl -> GetMinimum(This,id,value)

#define IFunction_GetMaximum(This,id,value)	\
    (This)->lpVtbl -> GetMaximum(This,id,value)

#define IFunction_GetLipshitz(This,id,value)	\
    (This)->lpVtbl -> GetLipshitz(This,id,value)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IFunction_GetSystemFunction_Proxy( 
    IFunction * This,
    /* [out] */ void **function);


void __RPC_STUB IFunction_GetSystemFunction_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IFunction_GetSystemFunctionDerivate_Proxy( 
    IFunction * This,
    /* [out] */ void **function);


void __RPC_STUB IFunction_GetSystemFunctionDerivate_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IFunction_CreateGraph_Proxy( 
    IFunction * This,
    /* [out] */ void **graph);


void __RPC_STUB IFunction_CreateGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IFunction_GetEquations_Proxy( 
    IFunction * This,
    /* [retval][out] */ BSTR *equations);


void __RPC_STUB IFunction_GetEquations_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IFunction_GetDimension_Proxy( 
    IFunction * This,
    /* [retval][out] */ int *dimenstion);


void __RPC_STUB IFunction_GetDimension_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IFunction_GetIterations_Proxy( 
    IFunction * This,
    /* [retval][out] */ int *iterations);


void __RPC_STUB IFunction_GetIterations_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IFunction_GetMinimum_Proxy( 
    IFunction * This,
    /* [in] */ int id,
    /* [retval][out] */ double *value);


void __RPC_STUB IFunction_GetMinimum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IFunction_GetMaximum_Proxy( 
    IFunction * This,
    /* [in] */ int id,
    /* [retval][out] */ double *value);


void __RPC_STUB IFunction_GetMaximum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IFunction_GetLipshitz_Proxy( 
    IFunction * This,
    /* [in] */ int id,
    /* [retval][out] */ double *value);


void __RPC_STUB IFunction_GetLipshitz_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IFunction_INTERFACE_DEFINED__ */


#ifndef __IComputationParameters_INTERFACE_DEFINED__
#define __IComputationParameters_INTERFACE_DEFINED__

/* interface IComputationParameters */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IComputationParameters;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("AB57FCFD-2759-4E43-8095-34FD20EAAA8B")
    IComputationParameters : public IParameters
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetFunction( 
            /* [retval][out] */ IFunction **function) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IComputationParametersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IComputationParameters * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IComputationParameters * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IComputationParameters * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IComputationParameters * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IComputationParameters * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IComputationParameters * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IComputationParameters * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFunction )( 
            IComputationParameters * This,
            /* [retval][out] */ IFunction **function);
        
        END_INTERFACE
    } IComputationParametersVtbl;

    interface IComputationParameters
    {
        CONST_VTBL struct IComputationParametersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IComputationParameters_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IComputationParameters_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IComputationParameters_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IComputationParameters_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IComputationParameters_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IComputationParameters_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IComputationParameters_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IComputationParameters_GetFunction(This,function)	\
    (This)->lpVtbl -> GetFunction(This,function)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IComputationParameters_GetFunction_Proxy( 
    IComputationParameters * This,
    /* [retval][out] */ IFunction **function);


void __RPC_STUB IComputationParameters_GetFunction_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IComputationParameters_INTERFACE_DEFINED__ */


#ifndef __IAdaptiveMethodAction_INTERFACE_DEFINED__
#define __IAdaptiveMethodAction_INTERFACE_DEFINED__

/* interface IAdaptiveMethodAction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IAdaptiveMethodAction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("6EBF68E3-4686-40C8-9F63-3ABC3504923A")
    IAdaptiveMethodAction : public IAction
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetRecomendedPrecision( 
            /* [in] */ IResultSet *in,
            /* [retval][out] */ double *prec) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetDimension( 
            /* [in] */ IResultSet *in,
            /* [retval][out] */ int *dim) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAdaptiveMethodActionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IAdaptiveMethodAction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IAdaptiveMethodAction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IAdaptiveMethodAction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IAdaptiveMethodAction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IAdaptiveMethodAction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IAdaptiveMethodAction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IAdaptiveMethodAction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            IAdaptiveMethodAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            IAdaptiveMethodAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanDo )( 
            IAdaptiveMethodAction * This,
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            IAdaptiveMethodAction * This,
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetRecomendedPrecision )( 
            IAdaptiveMethodAction * This,
            /* [in] */ IResultSet *in,
            /* [retval][out] */ double *prec);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetDimension )( 
            IAdaptiveMethodAction * This,
            /* [in] */ IResultSet *in,
            /* [retval][out] */ int *dim);
        
        END_INTERFACE
    } IAdaptiveMethodActionVtbl;

    interface IAdaptiveMethodAction
    {
        CONST_VTBL struct IAdaptiveMethodActionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAdaptiveMethodAction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAdaptiveMethodAction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAdaptiveMethodAction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAdaptiveMethodAction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IAdaptiveMethodAction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IAdaptiveMethodAction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IAdaptiveMethodAction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IAdaptiveMethodAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define IAdaptiveMethodAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#define IAdaptiveMethodAction_CanDo(This,result,can)	\
    (This)->lpVtbl -> CanDo(This,result,can)

#define IAdaptiveMethodAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)


#define IAdaptiveMethodAction_GetRecomendedPrecision(This,in,prec)	\
    (This)->lpVtbl -> GetRecomendedPrecision(This,in,prec)

#define IAdaptiveMethodAction_GetDimension(This,in,dim)	\
    (This)->lpVtbl -> GetDimension(This,in,dim)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IAdaptiveMethodAction_GetRecomendedPrecision_Proxy( 
    IAdaptiveMethodAction * This,
    /* [in] */ IResultSet *in,
    /* [retval][out] */ double *prec);


void __RPC_STUB IAdaptiveMethodAction_GetRecomendedPrecision_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IAdaptiveMethodAction_GetDimension_Proxy( 
    IAdaptiveMethodAction * This,
    /* [in] */ IResultSet *in,
    /* [retval][out] */ int *dim);


void __RPC_STUB IAdaptiveMethodAction_GetDimension_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAdaptiveMethodAction_INTERFACE_DEFINED__ */


#ifndef __IAdaptiveMethodParameters_INTERFACE_DEFINED__
#define __IAdaptiveMethodParameters_INTERFACE_DEFINED__

/* interface IAdaptiveMethodParameters */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IAdaptiveMethodParameters;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("554362EE-42C4-48EB-B5C3-8C10273D73B5")
    IAdaptiveMethodParameters : public IComputationParameters
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetFactor( 
            /* [in] */ int index,
            /* [retval][out] */ int *factor) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetPrecision( 
            /* [retval][out] */ double *prec) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAdaptiveMethodParametersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IAdaptiveMethodParameters * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IAdaptiveMethodParameters * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IAdaptiveMethodParameters * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IAdaptiveMethodParameters * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IAdaptiveMethodParameters * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IAdaptiveMethodParameters * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IAdaptiveMethodParameters * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFunction )( 
            IAdaptiveMethodParameters * This,
            /* [retval][out] */ IFunction **function);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFactor )( 
            IAdaptiveMethodParameters * This,
            /* [in] */ int index,
            /* [retval][out] */ int *factor);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetPrecision )( 
            IAdaptiveMethodParameters * This,
            /* [retval][out] */ double *prec);
        
        END_INTERFACE
    } IAdaptiveMethodParametersVtbl;

    interface IAdaptiveMethodParameters
    {
        CONST_VTBL struct IAdaptiveMethodParametersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAdaptiveMethodParameters_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAdaptiveMethodParameters_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAdaptiveMethodParameters_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAdaptiveMethodParameters_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IAdaptiveMethodParameters_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IAdaptiveMethodParameters_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IAdaptiveMethodParameters_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IAdaptiveMethodParameters_GetFunction(This,function)	\
    (This)->lpVtbl -> GetFunction(This,function)


#define IAdaptiveMethodParameters_GetFactor(This,index,factor)	\
    (This)->lpVtbl -> GetFactor(This,index,factor)

#define IAdaptiveMethodParameters_GetPrecision(This,prec)	\
    (This)->lpVtbl -> GetPrecision(This,prec)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IAdaptiveMethodParameters_GetFactor_Proxy( 
    IAdaptiveMethodParameters * This,
    /* [in] */ int index,
    /* [retval][out] */ int *factor);


void __RPC_STUB IAdaptiveMethodParameters_GetFactor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IAdaptiveMethodParameters_GetPrecision_Proxy( 
    IAdaptiveMethodParameters * This,
    /* [retval][out] */ double *prec);


void __RPC_STUB IAdaptiveMethodParameters_GetPrecision_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAdaptiveMethodParameters_INTERFACE_DEFINED__ */


#ifndef __IResultMetadata_INTERFACE_DEFINED__
#define __IResultMetadata_INTERFACE_DEFINED__

/* interface IResultMetadata */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IResultMetadata;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("A8E4F6FF-93DA-489A-A6C3-22A5884932C9")
    IResultMetadata : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EqualType( 
            /* [in] */ IResultMetadata *metadata,
            /* [retval][out] */ VARIANT_BOOL *out) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Clone( 
            /* [retval][out] */ IResultMetadata **metadata) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IResultMetadataVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IResultMetadata * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IResultMetadata * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IResultMetadata * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IResultMetadata * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IResultMetadata * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IResultMetadata * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IResultMetadata * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EqualType )( 
            IResultMetadata * This,
            /* [in] */ IResultMetadata *metadata,
            /* [retval][out] */ VARIANT_BOOL *out);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Clone )( 
            IResultMetadata * This,
            /* [retval][out] */ IResultMetadata **metadata);
        
        END_INTERFACE
    } IResultMetadataVtbl;

    interface IResultMetadata
    {
        CONST_VTBL struct IResultMetadataVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IResultMetadata_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IResultMetadata_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IResultMetadata_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IResultMetadata_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IResultMetadata_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IResultMetadata_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IResultMetadata_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IResultMetadata_EqualType(This,metadata,out)	\
    (This)->lpVtbl -> EqualType(This,metadata,out)

#define IResultMetadata_Clone(This,metadata)	\
    (This)->lpVtbl -> Clone(This,metadata)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IResultMetadata_EqualType_Proxy( 
    IResultMetadata * This,
    /* [in] */ IResultMetadata *metadata,
    /* [retval][out] */ VARIANT_BOOL *out);


void __RPC_STUB IResultMetadata_EqualType_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IResultMetadata_Clone_Proxy( 
    IResultMetadata * This,
    /* [retval][out] */ IResultMetadata **metadata);


void __RPC_STUB IResultMetadata_Clone_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IResultMetadata_INTERFACE_DEFINED__ */


#ifndef __IResult_INTERFACE_DEFINED__
#define __IResult_INTERFACE_DEFINED__

/* interface IResult */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IResult;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7D45A5-77FD-4E97-8C4A-76D3610CC875")
    IResult : public IResultBase
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetMetadata( 
            /* [retval][out] */ IResultMetadata **out) = 0;
        
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
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetMetadata )( 
            IResult * This,
            /* [retval][out] */ IResultMetadata **out);
        
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



#define IResult_GetMetadata(This,out)	\
    (This)->lpVtbl -> GetMetadata(This,out)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IResult_GetMetadata_Proxy( 
    IResult * This,
    /* [retval][out] */ IResultMetadata **out);


void __RPC_STUB IResult_GetMetadata_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IResult_INTERFACE_DEFINED__ */


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
            /* [out] */ void **graph) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetGraphInfo( 
            /* [retval][out] */ IGraphInfo **info) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE IsStrongComponent( 
            /* [retval][out] */ VARIANT_BOOL *value) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SaveText( 
            /* [in] */ BSTR file) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SaveGraph( 
            /* [in] */ BSTR file) = 0;
        
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
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetMetadata )( 
            IGraphResult * This,
            /* [retval][out] */ IResultMetadata **out);
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *GetGraph )( 
            IGraphResult * This,
            /* [out] */ void **graph);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetGraphInfo )( 
            IGraphResult * This,
            /* [retval][out] */ IGraphInfo **info);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *IsStrongComponent )( 
            IGraphResult * This,
            /* [retval][out] */ VARIANT_BOOL *value);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SaveText )( 
            IGraphResult * This,
            /* [in] */ BSTR file);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SaveGraph )( 
            IGraphResult * This,
            /* [in] */ BSTR file);
        
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



#define IGraphResult_GetMetadata(This,out)	\
    (This)->lpVtbl -> GetMetadata(This,out)


#define IGraphResult_GetGraph(This,graph)	\
    (This)->lpVtbl -> GetGraph(This,graph)

#define IGraphResult_GetGraphInfo(This,info)	\
    (This)->lpVtbl -> GetGraphInfo(This,info)

#define IGraphResult_IsStrongComponent(This,value)	\
    (This)->lpVtbl -> IsStrongComponent(This,value)

#define IGraphResult_SaveText(This,file)	\
    (This)->lpVtbl -> SaveText(This,file)

#define IGraphResult_SaveGraph(This,file)	\
    (This)->lpVtbl -> SaveGraph(This,file)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IGraphResult_GetGraph_Proxy( 
    IGraphResult * This,
    /* [out] */ void **graph);


void __RPC_STUB IGraphResult_GetGraph_Stub(
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


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphResult_IsStrongComponent_Proxy( 
    IGraphResult * This,
    /* [retval][out] */ VARIANT_BOOL *value);


void __RPC_STUB IGraphResult_IsStrongComponent_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphResult_SaveText_Proxy( 
    IGraphResult * This,
    /* [in] */ BSTR file);


void __RPC_STUB IGraphResult_SaveText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IGraphResult_SaveGraph_Proxy( 
    IGraphResult * This,
    /* [in] */ BSTR file);


void __RPC_STUB IGraphResult_SaveGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IGraphResult_INTERFACE_DEFINED__ */


#ifndef __IWritableGraphResult_INTERFACE_DEFINED__
#define __IWritableGraphResult_INTERFACE_DEFINED__

/* interface IWritableGraphResult */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IWritableGraphResult;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("6ED8D0EA-3E9C-441A-96C6-EEB2AFCBE27D")
    IWritableGraphResult : public IDispatch
    {
    public:
        virtual /* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE SetGraph( 
            /* [in] */ void **graph,
            /* [in] */ VARIANT_BOOL isStrongComponent) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetMetadata( 
            /* [in] */ IResultMetadata *metadata) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetGraphFromFile( 
            /* [in] */ BSTR file,
            /* [in] */ VARIANT_BOOL isStrongComponent) = 0;
        
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
        
        /* [hidden][local][id] */ HRESULT ( STDMETHODCALLTYPE *SetGraph )( 
            IWritableGraphResult * This,
            /* [in] */ void **graph,
            /* [in] */ VARIANT_BOOL isStrongComponent);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetMetadata )( 
            IWritableGraphResult * This,
            /* [in] */ IResultMetadata *metadata);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetGraphFromFile )( 
            IWritableGraphResult * This,
            /* [in] */ BSTR file,
            /* [in] */ VARIANT_BOOL isStrongComponent);
        
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


#define IWritableGraphResult_SetGraph(This,graph,isStrongComponent)	\
    (This)->lpVtbl -> SetGraph(This,graph,isStrongComponent)

#define IWritableGraphResult_SetMetadata(This,metadata)	\
    (This)->lpVtbl -> SetMetadata(This,metadata)

#define IWritableGraphResult_SetGraphFromFile(This,file,isStrongComponent)	\
    (This)->lpVtbl -> SetGraphFromFile(This,file,isStrongComponent)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][local][id] */ HRESULT STDMETHODCALLTYPE IWritableGraphResult_SetGraph_Proxy( 
    IWritableGraphResult * This,
    /* [in] */ void **graph,
    /* [in] */ VARIANT_BOOL isStrongComponent);


void __RPC_STUB IWritableGraphResult_SetGraph_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IWritableGraphResult_SetMetadata_Proxy( 
    IWritableGraphResult * This,
    /* [in] */ IResultMetadata *metadata);


void __RPC_STUB IWritableGraphResult_SetMetadata_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IWritableGraphResult_SetGraphFromFile_Proxy( 
    IWritableGraphResult * This,
    /* [in] */ BSTR file,
    /* [in] */ VARIANT_BOOL isStrongComponent);


void __RPC_STUB IWritableGraphResult_SetGraphFromFile_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IWritableGraphResult_INTERFACE_DEFINED__ */


#ifndef __IWritableResultSet_INTERFACE_DEFINED__
#define __IWritableResultSet_INTERFACE_DEFINED__

/* interface IWritableResultSet */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IWritableResultSet;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("A56A15AC-EAC4-4D8B-92FC-84CF84FC4F16")
    IWritableResultSet : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE AddResult( 
            /* [in] */ IResultBase *result) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWritableResultSetVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWritableResultSet * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWritableResultSet * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWritableResultSet * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IWritableResultSet * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IWritableResultSet * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IWritableResultSet * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IWritableResultSet * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *AddResult )( 
            IWritableResultSet * This,
            /* [in] */ IResultBase *result);
        
        END_INTERFACE
    } IWritableResultSetVtbl;

    interface IWritableResultSet
    {
        CONST_VTBL struct IWritableResultSetVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWritableResultSet_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IWritableResultSet_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IWritableResultSet_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IWritableResultSet_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IWritableResultSet_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IWritableResultSet_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IWritableResultSet_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IWritableResultSet_AddResult(This,result)	\
    (This)->lpVtbl -> AddResult(This,result)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IWritableResultSet_AddResult_Proxy( 
    IWritableResultSet * This,
    /* [in] */ IResultBase *result);


void __RPC_STUB IWritableResultSet_AddResult_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IWritableResultSet_INTERFACE_DEFINED__ */


#ifndef __IGraphResultImpl_INTERFACE_DEFINED__
#define __IGraphResultImpl_INTERFACE_DEFINED__

/* interface IGraphResultImpl */
/* [unique][uuid][dual][object] */ 


EXTERN_C const IID IID_IGraphResultImpl;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("150237B9-7739-4882-87E1-8FE926A96AFF")
    IGraphResultImpl : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IGraphResultImplVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IGraphResultImpl * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IGraphResultImpl * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IGraphResultImpl * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IGraphResultImpl * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IGraphResultImpl * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IGraphResultImpl * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IGraphResultImpl * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IGraphResultImplVtbl;

    interface IGraphResultImpl
    {
        CONST_VTBL struct IGraphResultImplVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IGraphResultImpl_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IGraphResultImpl_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IGraphResultImpl_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IGraphResultImpl_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IGraphResultImpl_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IGraphResultImpl_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IGraphResultImpl_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IGraphResultImpl_INTERFACE_DEFINED__ */


#ifndef __ISymbolicImageMetadata_INTERFACE_DEFINED__
#define __ISymbolicImageMetadata_INTERFACE_DEFINED__

/* interface ISymbolicImageMetadata */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ISymbolicImageMetadata;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("24EEB65B-81FF-42EA-8521-6B3F62665F84")
    ISymbolicImageMetadata : public IResultMetadata
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ISymbolicImageMetadataVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISymbolicImageMetadata * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISymbolicImageMetadata * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISymbolicImageMetadata * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISymbolicImageMetadata * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISymbolicImageMetadata * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISymbolicImageMetadata * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISymbolicImageMetadata * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EqualType )( 
            ISymbolicImageMetadata * This,
            /* [in] */ IResultMetadata *metadata,
            /* [retval][out] */ VARIANT_BOOL *out);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Clone )( 
            ISymbolicImageMetadata * This,
            /* [retval][out] */ IResultMetadata **metadata);
        
        END_INTERFACE
    } ISymbolicImageMetadataVtbl;

    interface ISymbolicImageMetadata
    {
        CONST_VTBL struct ISymbolicImageMetadataVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISymbolicImageMetadata_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISymbolicImageMetadata_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISymbolicImageMetadata_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISymbolicImageMetadata_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISymbolicImageMetadata_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISymbolicImageMetadata_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISymbolicImageMetadata_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISymbolicImageMetadata_EqualType(This,metadata,out)	\
    (This)->lpVtbl -> EqualType(This,metadata,out)

#define ISymbolicImageMetadata_Clone(This,metadata)	\
    (This)->lpVtbl -> Clone(This,metadata)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ISymbolicImageMetadata_INTERFACE_DEFINED__ */


#ifndef __IBoxMethodAction_INTERFACE_DEFINED__
#define __IBoxMethodAction_INTERFACE_DEFINED__

/* interface IBoxMethodAction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IBoxMethodAction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("586FAD2F-D9E4-4A30-A925-345C7E1BDC56")
    IBoxMethodAction : public IAction
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetDimensionForParameters( 
            /* [in] */ IResultSet *resultSet,
            /* [retval][out] */ int *dimension) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IBoxMethodActionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IBoxMethodAction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IBoxMethodAction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IBoxMethodAction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IBoxMethodAction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IBoxMethodAction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IBoxMethodAction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IBoxMethodAction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            IBoxMethodAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            IBoxMethodAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanDo )( 
            IBoxMethodAction * This,
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            IBoxMethodAction * This,
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetDimensionForParameters )( 
            IBoxMethodAction * This,
            /* [in] */ IResultSet *resultSet,
            /* [retval][out] */ int *dimension);
        
        END_INTERFACE
    } IBoxMethodActionVtbl;

    interface IBoxMethodAction
    {
        CONST_VTBL struct IBoxMethodActionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IBoxMethodAction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IBoxMethodAction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IBoxMethodAction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IBoxMethodAction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IBoxMethodAction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IBoxMethodAction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IBoxMethodAction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IBoxMethodAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define IBoxMethodAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#define IBoxMethodAction_CanDo(This,result,can)	\
    (This)->lpVtbl -> CanDo(This,result,can)

#define IBoxMethodAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)


#define IBoxMethodAction_GetDimensionForParameters(This,resultSet,dimension)	\
    (This)->lpVtbl -> GetDimensionForParameters(This,resultSet,dimension)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IBoxMethodAction_GetDimensionForParameters_Proxy( 
    IBoxMethodAction * This,
    /* [in] */ IResultSet *resultSet,
    /* [retval][out] */ int *dimension);


void __RPC_STUB IBoxMethodAction_GetDimensionForParameters_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IBoxMethodAction_INTERFACE_DEFINED__ */


#ifndef __IBoxMethodParameters_INTERFACE_DEFINED__
#define __IBoxMethodParameters_INTERFACE_DEFINED__

/* interface IBoxMethodParameters */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IBoxMethodParameters;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("EF3F28E7-DA5A-4294-9C12-656D0B7CB74A")
    IBoxMethodParameters : public IComputationParameters
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetFactor( 
            /* [in] */ int index,
            /* [retval][out] */ int *factor) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE UseDerivate( 
            /* [retval][out] */ VARIANT_BOOL *out) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IBoxMethodParametersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IBoxMethodParameters * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IBoxMethodParameters * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IBoxMethodParameters * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IBoxMethodParameters * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IBoxMethodParameters * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IBoxMethodParameters * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IBoxMethodParameters * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFunction )( 
            IBoxMethodParameters * This,
            /* [retval][out] */ IFunction **function);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFactor )( 
            IBoxMethodParameters * This,
            /* [in] */ int index,
            /* [retval][out] */ int *factor);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *UseDerivate )( 
            IBoxMethodParameters * This,
            /* [retval][out] */ VARIANT_BOOL *out);
        
        END_INTERFACE
    } IBoxMethodParametersVtbl;

    interface IBoxMethodParameters
    {
        CONST_VTBL struct IBoxMethodParametersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IBoxMethodParameters_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IBoxMethodParameters_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IBoxMethodParameters_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IBoxMethodParameters_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IBoxMethodParameters_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IBoxMethodParameters_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IBoxMethodParameters_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IBoxMethodParameters_GetFunction(This,function)	\
    (This)->lpVtbl -> GetFunction(This,function)


#define IBoxMethodParameters_GetFactor(This,index,factor)	\
    (This)->lpVtbl -> GetFactor(This,index,factor)

#define IBoxMethodParameters_UseDerivate(This,out)	\
    (This)->lpVtbl -> UseDerivate(This,out)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IBoxMethodParameters_GetFactor_Proxy( 
    IBoxMethodParameters * This,
    /* [in] */ int index,
    /* [retval][out] */ int *factor);


void __RPC_STUB IBoxMethodParameters_GetFactor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IBoxMethodParameters_UseDerivate_Proxy( 
    IBoxMethodParameters * This,
    /* [retval][out] */ VARIANT_BOOL *out);


void __RPC_STUB IBoxMethodParameters_UseDerivate_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IBoxMethodParameters_INTERFACE_DEFINED__ */


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


#ifndef __ITarjanAction_INTERFACE_DEFINED__
#define __ITarjanAction_INTERFACE_DEFINED__

/* interface ITarjanAction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ITarjanAction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("FAFD82A9-346E-4BD7-8316-F16B105A4653")
    ITarjanAction : public IAction
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ITarjanActionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITarjanAction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITarjanAction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITarjanAction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITarjanAction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITarjanAction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITarjanAction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITarjanAction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            ITarjanAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            ITarjanAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanDo )( 
            ITarjanAction * This,
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            ITarjanAction * This,
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output);
        
        END_INTERFACE
    } ITarjanActionVtbl;

    interface ITarjanAction
    {
        CONST_VTBL struct ITarjanActionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITarjanAction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ITarjanAction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ITarjanAction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ITarjanAction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ITarjanAction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ITarjanAction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ITarjanAction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define ITarjanAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define ITarjanAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#define ITarjanAction_CanDo(This,result,can)	\
    (This)->lpVtbl -> CanDo(This,result,can)

#define ITarjanAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ITarjanAction_INTERFACE_DEFINED__ */


#ifndef __ITarjanParameters_INTERFACE_DEFINED__
#define __ITarjanParameters_INTERFACE_DEFINED__

/* interface ITarjanParameters */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ITarjanParameters;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("8DB63B4A-7E18-4328-9335-419C4CE5A4E5")
    ITarjanParameters : public IParameters
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE NeedEdgeResolve( 
            /* [retval][out] */ VARIANT_BOOL *result) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ITarjanParametersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITarjanParameters * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITarjanParameters * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITarjanParameters * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITarjanParameters * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITarjanParameters * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITarjanParameters * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITarjanParameters * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *NeedEdgeResolve )( 
            ITarjanParameters * This,
            /* [retval][out] */ VARIANT_BOOL *result);
        
        END_INTERFACE
    } ITarjanParametersVtbl;

    interface ITarjanParameters
    {
        CONST_VTBL struct ITarjanParametersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITarjanParameters_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ITarjanParameters_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ITarjanParameters_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ITarjanParameters_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ITarjanParameters_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ITarjanParameters_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ITarjanParameters_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define ITarjanParameters_NeedEdgeResolve(This,result)	\
    (This)->lpVtbl -> NeedEdgeResolve(This,result)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE ITarjanParameters_NeedEdgeResolve_Proxy( 
    ITarjanParameters * This,
    /* [retval][out] */ VARIANT_BOOL *result);


void __RPC_STUB ITarjanParameters_NeedEdgeResolve_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ITarjanParameters_INTERFACE_DEFINED__ */


#ifndef __IPointMethodAction_INTERFACE_DEFINED__
#define __IPointMethodAction_INTERFACE_DEFINED__

/* interface IPointMethodAction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IPointMethodAction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("1B1FF1EE-4EB6-4F0A-B6AB-CCBFFA28B9F0")
    IPointMethodAction : public IAction
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetDimensionForParameters( 
            /* [in] */ IResultSet *resultSet,
            /* [retval][out] */ int *dimension) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IPointMethodActionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IPointMethodAction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IPointMethodAction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IPointMethodAction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IPointMethodAction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IPointMethodAction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IPointMethodAction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IPointMethodAction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            IPointMethodAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            IPointMethodAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanDo )( 
            IPointMethodAction * This,
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            IPointMethodAction * This,
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetDimensionForParameters )( 
            IPointMethodAction * This,
            /* [in] */ IResultSet *resultSet,
            /* [retval][out] */ int *dimension);
        
        END_INTERFACE
    } IPointMethodActionVtbl;

    interface IPointMethodAction
    {
        CONST_VTBL struct IPointMethodActionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IPointMethodAction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IPointMethodAction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IPointMethodAction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IPointMethodAction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IPointMethodAction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IPointMethodAction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IPointMethodAction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IPointMethodAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define IPointMethodAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#define IPointMethodAction_CanDo(This,result,can)	\
    (This)->lpVtbl -> CanDo(This,result,can)

#define IPointMethodAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)


#define IPointMethodAction_GetDimensionForParameters(This,resultSet,dimension)	\
    (This)->lpVtbl -> GetDimensionForParameters(This,resultSet,dimension)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IPointMethodAction_GetDimensionForParameters_Proxy( 
    IPointMethodAction * This,
    /* [in] */ IResultSet *resultSet,
    /* [retval][out] */ int *dimension);


void __RPC_STUB IPointMethodAction_GetDimensionForParameters_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IPointMethodAction_INTERFACE_DEFINED__ */


#ifndef __IPointMethodParameters_INTERFACE_DEFINED__
#define __IPointMethodParameters_INTERFACE_DEFINED__

/* interface IPointMethodParameters */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IPointMethodParameters;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("ADCEDDBC-441A-479D-8E7A-706921DA82AC")
    IPointMethodParameters : public IComputationParameters
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetFactor( 
            /* [in] */ int index,
            /* [retval][out] */ int *factor) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetPoints( 
            /* [in] */ int index,
            /* [retval][out] */ int *ks) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE UseOffsets( 
            /* [retval][out] */ VARIANT_BOOL *data) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetOffset( 
            /* [in] */ int index,
            /* [out] */ double *offset1,
            /* [out] */ double *offset2) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IPointMethodParametersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IPointMethodParameters * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IPointMethodParameters * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IPointMethodParameters * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IPointMethodParameters * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IPointMethodParameters * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IPointMethodParameters * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IPointMethodParameters * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFunction )( 
            IPointMethodParameters * This,
            /* [retval][out] */ IFunction **function);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFactor )( 
            IPointMethodParameters * This,
            /* [in] */ int index,
            /* [retval][out] */ int *factor);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetPoints )( 
            IPointMethodParameters * This,
            /* [in] */ int index,
            /* [retval][out] */ int *ks);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *UseOffsets )( 
            IPointMethodParameters * This,
            /* [retval][out] */ VARIANT_BOOL *data);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetOffset )( 
            IPointMethodParameters * This,
            /* [in] */ int index,
            /* [out] */ double *offset1,
            /* [out] */ double *offset2);
        
        END_INTERFACE
    } IPointMethodParametersVtbl;

    interface IPointMethodParameters
    {
        CONST_VTBL struct IPointMethodParametersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IPointMethodParameters_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IPointMethodParameters_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IPointMethodParameters_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IPointMethodParameters_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IPointMethodParameters_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IPointMethodParameters_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IPointMethodParameters_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IPointMethodParameters_GetFunction(This,function)	\
    (This)->lpVtbl -> GetFunction(This,function)


#define IPointMethodParameters_GetFactor(This,index,factor)	\
    (This)->lpVtbl -> GetFactor(This,index,factor)

#define IPointMethodParameters_GetPoints(This,index,ks)	\
    (This)->lpVtbl -> GetPoints(This,index,ks)

#define IPointMethodParameters_UseOffsets(This,data)	\
    (This)->lpVtbl -> UseOffsets(This,data)

#define IPointMethodParameters_GetOffset(This,index,offset1,offset2)	\
    (This)->lpVtbl -> GetOffset(This,index,offset1,offset2)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IPointMethodParameters_GetFactor_Proxy( 
    IPointMethodParameters * This,
    /* [in] */ int index,
    /* [retval][out] */ int *factor);


void __RPC_STUB IPointMethodParameters_GetFactor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IPointMethodParameters_GetPoints_Proxy( 
    IPointMethodParameters * This,
    /* [in] */ int index,
    /* [retval][out] */ int *ks);


void __RPC_STUB IPointMethodParameters_GetPoints_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IPointMethodParameters_UseOffsets_Proxy( 
    IPointMethodParameters * This,
    /* [retval][out] */ VARIANT_BOOL *data);


void __RPC_STUB IPointMethodParameters_UseOffsets_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IPointMethodParameters_GetOffset_Proxy( 
    IPointMethodParameters * This,
    /* [in] */ int index,
    /* [out] */ double *offset1,
    /* [out] */ double *offset2);


void __RPC_STUB IPointMethodParameters_GetOffset_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IPointMethodParameters_INTERFACE_DEFINED__ */


#ifndef __IDummy_INTERFACE_DEFINED__
#define __IDummy_INTERFACE_DEFINED__

/* interface IDummy */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IDummy;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("0A8C775B-8E19-4642-B2D7-5BBB437B7B97")
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


#ifndef __IIsolatedSetAction_INTERFACE_DEFINED__
#define __IIsolatedSetAction_INTERFACE_DEFINED__

/* interface IIsolatedSetAction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IIsolatedSetAction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("787DC58F-CD39-4BE2-9B58-D5B99ADCFC4D")
    IIsolatedSetAction : public IAction
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IIsolatedSetActionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IIsolatedSetAction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IIsolatedSetAction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IIsolatedSetAction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IIsolatedSetAction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IIsolatedSetAction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IIsolatedSetAction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IIsolatedSetAction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            IIsolatedSetAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            IIsolatedSetAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanDo )( 
            IIsolatedSetAction * This,
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            IIsolatedSetAction * This,
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output);
        
        END_INTERFACE
    } IIsolatedSetActionVtbl;

    interface IIsolatedSetAction
    {
        CONST_VTBL struct IIsolatedSetActionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IIsolatedSetAction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IIsolatedSetAction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IIsolatedSetAction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IIsolatedSetAction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IIsolatedSetAction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IIsolatedSetAction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IIsolatedSetAction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IIsolatedSetAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define IIsolatedSetAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#define IIsolatedSetAction_CanDo(This,result,can)	\
    (This)->lpVtbl -> CanDo(This,result,can)

#define IIsolatedSetAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IIsolatedSetAction_INTERFACE_DEFINED__ */


#ifndef __IIsolatedSetParameters_INTERFACE_DEFINED__
#define __IIsolatedSetParameters_INTERFACE_DEFINED__

/* interface IIsolatedSetParameters */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IIsolatedSetParameters;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("01C806AD-6003-4F5B-8405-AE3DD637D854")
    IIsolatedSetParameters : public IParameters
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetStartSet( 
            /* [retval][out] */ IGraphResult **result) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IIsolatedSetParametersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IIsolatedSetParameters * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IIsolatedSetParameters * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IIsolatedSetParameters * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IIsolatedSetParameters * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IIsolatedSetParameters * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IIsolatedSetParameters * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IIsolatedSetParameters * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetStartSet )( 
            IIsolatedSetParameters * This,
            /* [retval][out] */ IGraphResult **result);
        
        END_INTERFACE
    } IIsolatedSetParametersVtbl;

    interface IIsolatedSetParameters
    {
        CONST_VTBL struct IIsolatedSetParametersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IIsolatedSetParameters_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IIsolatedSetParameters_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IIsolatedSetParameters_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IIsolatedSetParameters_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IIsolatedSetParameters_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IIsolatedSetParameters_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IIsolatedSetParameters_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IIsolatedSetParameters_GetStartSet(This,result)	\
    (This)->lpVtbl -> GetStartSet(This,result)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IIsolatedSetParameters_GetStartSet_Proxy( 
    IIsolatedSetParameters * This,
    /* [retval][out] */ IGraphResult **result);


void __RPC_STUB IIsolatedSetParameters_GetStartSet_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IIsolatedSetParameters_INTERFACE_DEFINED__ */


#ifndef __IMinimalLoopLocalizationAction_INTERFACE_DEFINED__
#define __IMinimalLoopLocalizationAction_INTERFACE_DEFINED__

/* interface IMinimalLoopLocalizationAction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IMinimalLoopLocalizationAction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9FFB9554-2D64-45EE-9F79-B31098FF8512")
    IMinimalLoopLocalizationAction : public IAction
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetDimension( 
            /* [in] */ IResultSet *resultSet,
            /* [retval][out] */ int *dimension) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMinimalLoopLocalizationActionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMinimalLoopLocalizationAction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMinimalLoopLocalizationAction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMinimalLoopLocalizationAction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMinimalLoopLocalizationAction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMinimalLoopLocalizationAction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMinimalLoopLocalizationAction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMinimalLoopLocalizationAction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            IMinimalLoopLocalizationAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            IMinimalLoopLocalizationAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanDo )( 
            IMinimalLoopLocalizationAction * This,
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            IMinimalLoopLocalizationAction * This,
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetDimension )( 
            IMinimalLoopLocalizationAction * This,
            /* [in] */ IResultSet *resultSet,
            /* [retval][out] */ int *dimension);
        
        END_INTERFACE
    } IMinimalLoopLocalizationActionVtbl;

    interface IMinimalLoopLocalizationAction
    {
        CONST_VTBL struct IMinimalLoopLocalizationActionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMinimalLoopLocalizationAction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMinimalLoopLocalizationAction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMinimalLoopLocalizationAction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMinimalLoopLocalizationAction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMinimalLoopLocalizationAction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMinimalLoopLocalizationAction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMinimalLoopLocalizationAction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IMinimalLoopLocalizationAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define IMinimalLoopLocalizationAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#define IMinimalLoopLocalizationAction_CanDo(This,result,can)	\
    (This)->lpVtbl -> CanDo(This,result,can)

#define IMinimalLoopLocalizationAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)


#define IMinimalLoopLocalizationAction_GetDimension(This,resultSet,dimension)	\
    (This)->lpVtbl -> GetDimension(This,resultSet,dimension)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMinimalLoopLocalizationAction_GetDimension_Proxy( 
    IMinimalLoopLocalizationAction * This,
    /* [in] */ IResultSet *resultSet,
    /* [retval][out] */ int *dimension);


void __RPC_STUB IMinimalLoopLocalizationAction_GetDimension_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMinimalLoopLocalizationAction_INTERFACE_DEFINED__ */


#ifndef __IMinimalLoopLocalizationParameters_INTERFACE_DEFINED__
#define __IMinimalLoopLocalizationParameters_INTERFACE_DEFINED__

/* interface IMinimalLoopLocalizationParameters */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IMinimalLoopLocalizationParameters;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("B90D3C01-F6F8-4D06-8E01-C12C6D51F70A")
    IMinimalLoopLocalizationParameters : public IParameters
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetCoordinate( 
            /* [in] */ int id,
            /* [retval][out] */ double *data) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMinimalLoopLocalizationParametersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMinimalLoopLocalizationParameters * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMinimalLoopLocalizationParameters * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMinimalLoopLocalizationParameters * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMinimalLoopLocalizationParameters * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMinimalLoopLocalizationParameters * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMinimalLoopLocalizationParameters * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMinimalLoopLocalizationParameters * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetCoordinate )( 
            IMinimalLoopLocalizationParameters * This,
            /* [in] */ int id,
            /* [retval][out] */ double *data);
        
        END_INTERFACE
    } IMinimalLoopLocalizationParametersVtbl;

    interface IMinimalLoopLocalizationParameters
    {
        CONST_VTBL struct IMinimalLoopLocalizationParametersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMinimalLoopLocalizationParameters_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMinimalLoopLocalizationParameters_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMinimalLoopLocalizationParameters_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMinimalLoopLocalizationParameters_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMinimalLoopLocalizationParameters_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMinimalLoopLocalizationParameters_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMinimalLoopLocalizationParameters_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IMinimalLoopLocalizationParameters_GetCoordinate(This,id,data)	\
    (This)->lpVtbl -> GetCoordinate(This,id,data)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMinimalLoopLocalizationParameters_GetCoordinate_Proxy( 
    IMinimalLoopLocalizationParameters * This,
    /* [in] */ int id,
    /* [retval][out] */ double *data);


void __RPC_STUB IMinimalLoopLocalizationParameters_GetCoordinate_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMinimalLoopLocalizationParameters_INTERFACE_DEFINED__ */


#ifndef __ISIRomActionParameters_INTERFACE_DEFINED__
#define __ISIRomActionParameters_INTERFACE_DEFINED__

/* interface ISIRomActionParameters */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ISIRomActionParameters;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9CF385EA-26DB-4A19-AB20-5E735654D469")
    ISIRomActionParameters : public IComputationParameters
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ISIRomActionParametersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISIRomActionParameters * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISIRomActionParameters * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISIRomActionParameters * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISIRomActionParameters * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISIRomActionParameters * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISIRomActionParameters * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISIRomActionParameters * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFunction )( 
            ISIRomActionParameters * This,
            /* [retval][out] */ IFunction **function);
        
        END_INTERFACE
    } ISIRomActionParametersVtbl;

    interface ISIRomActionParameters
    {
        CONST_VTBL struct ISIRomActionParametersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISIRomActionParameters_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISIRomActionParameters_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISIRomActionParameters_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISIRomActionParameters_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISIRomActionParameters_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISIRomActionParameters_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISIRomActionParameters_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define ISIRomActionParameters_GetFunction(This,function)	\
    (This)->lpVtbl -> GetFunction(This,function)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ISIRomActionParameters_INTERFACE_DEFINED__ */


#ifndef __ISIRomAction_INTERFACE_DEFINED__
#define __ISIRomAction_INTERFACE_DEFINED__

/* interface ISIRomAction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ISIRomAction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("44DAD8BF-971F-485D-86C5-45FD1F67ACFE")
    ISIRomAction : public IAction
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ISIRomActionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISIRomAction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISIRomAction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISIRomAction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISIRomAction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISIRomAction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISIRomAction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISIRomAction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            ISIRomAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            ISIRomAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanDo )( 
            ISIRomAction * This,
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            ISIRomAction * This,
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output);
        
        END_INTERFACE
    } ISIRomActionVtbl;

    interface ISIRomAction
    {
        CONST_VTBL struct ISIRomActionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISIRomAction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISIRomAction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISIRomAction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISIRomAction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISIRomAction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISIRomAction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISIRomAction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define ISIRomAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define ISIRomAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#define ISIRomAction_CanDo(This,result,can)	\
    (This)->lpVtbl -> CanDo(This,result,can)

#define ISIRomAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ISIRomAction_INTERFACE_DEFINED__ */


#ifndef __ISpectrumMetadata_INTERFACE_DEFINED__
#define __ISpectrumMetadata_INTERFACE_DEFINED__

/* interface ISpectrumMetadata */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ISpectrumMetadata;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("139E4822-4DF9-44B1-8825-FAD074492505")
    ISpectrumMetadata : public IResultMetadata
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ISpectrumMetadataVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISpectrumMetadata * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISpectrumMetadata * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISpectrumMetadata * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISpectrumMetadata * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISpectrumMetadata * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISpectrumMetadata * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISpectrumMetadata * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EqualType )( 
            ISpectrumMetadata * This,
            /* [in] */ IResultMetadata *metadata,
            /* [retval][out] */ VARIANT_BOOL *out);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Clone )( 
            ISpectrumMetadata * This,
            /* [retval][out] */ IResultMetadata **metadata);
        
        END_INTERFACE
    } ISpectrumMetadataVtbl;

    interface ISpectrumMetadata
    {
        CONST_VTBL struct ISpectrumMetadataVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISpectrumMetadata_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISpectrumMetadata_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISpectrumMetadata_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISpectrumMetadata_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISpectrumMetadata_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISpectrumMetadata_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISpectrumMetadata_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISpectrumMetadata_EqualType(This,metadata,out)	\
    (This)->lpVtbl -> EqualType(This,metadata,out)

#define ISpectrumMetadata_Clone(This,metadata)	\
    (This)->lpVtbl -> Clone(This,metadata)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ISpectrumMetadata_INTERFACE_DEFINED__ */


#ifndef __ISpectrumResult_INTERFACE_DEFINED__
#define __ISpectrumResult_INTERFACE_DEFINED__

/* interface ISpectrumResult */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ISpectrumResult;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("2003DF4C-5367-4F11-A29C-447E7E45E5AA")
    ISpectrumResult : public IResult
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetLowerBound( 
            /* [retval][out] */ double *data) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetUpperBound( 
            /* [retval][out] */ double *data) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetLowerLength( 
            /* [retval][out] */ int *data) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetUpperLength( 
            /* [retval][out] */ int *data) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISpectrumResultVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISpectrumResult * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISpectrumResult * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISpectrumResult * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISpectrumResult * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISpectrumResult * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISpectrumResult * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISpectrumResult * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetMetadata )( 
            ISpectrumResult * This,
            /* [retval][out] */ IResultMetadata **out);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetLowerBound )( 
            ISpectrumResult * This,
            /* [retval][out] */ double *data);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetUpperBound )( 
            ISpectrumResult * This,
            /* [retval][out] */ double *data);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetLowerLength )( 
            ISpectrumResult * This,
            /* [retval][out] */ int *data);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetUpperLength )( 
            ISpectrumResult * This,
            /* [retval][out] */ int *data);
        
        END_INTERFACE
    } ISpectrumResultVtbl;

    interface ISpectrumResult
    {
        CONST_VTBL struct ISpectrumResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISpectrumResult_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISpectrumResult_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISpectrumResult_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISpectrumResult_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISpectrumResult_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISpectrumResult_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISpectrumResult_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define ISpectrumResult_GetMetadata(This,out)	\
    (This)->lpVtbl -> GetMetadata(This,out)


#define ISpectrumResult_GetLowerBound(This,data)	\
    (This)->lpVtbl -> GetLowerBound(This,data)

#define ISpectrumResult_GetUpperBound(This,data)	\
    (This)->lpVtbl -> GetUpperBound(This,data)

#define ISpectrumResult_GetLowerLength(This,data)	\
    (This)->lpVtbl -> GetLowerLength(This,data)

#define ISpectrumResult_GetUpperLength(This,data)	\
    (This)->lpVtbl -> GetUpperLength(This,data)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE ISpectrumResult_GetLowerBound_Proxy( 
    ISpectrumResult * This,
    /* [retval][out] */ double *data);


void __RPC_STUB ISpectrumResult_GetLowerBound_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE ISpectrumResult_GetUpperBound_Proxy( 
    ISpectrumResult * This,
    /* [retval][out] */ double *data);


void __RPC_STUB ISpectrumResult_GetUpperBound_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE ISpectrumResult_GetLowerLength_Proxy( 
    ISpectrumResult * This,
    /* [retval][out] */ int *data);


void __RPC_STUB ISpectrumResult_GetLowerLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE ISpectrumResult_GetUpperLength_Proxy( 
    ISpectrumResult * This,
    /* [retval][out] */ int *data);


void __RPC_STUB ISpectrumResult_GetUpperLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISpectrumResult_INTERFACE_DEFINED__ */


#ifndef __IDummy1_INTERFACE_DEFINED__
#define __IDummy1_INTERFACE_DEFINED__

/* interface IDummy1 */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IDummy1;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("5896F6EB-CFBF-406C-A0FD-EA25367673D0")
    IDummy1 : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IDummy1Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IDummy1 * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IDummy1 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IDummy1 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IDummy1 * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IDummy1 * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IDummy1 * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IDummy1 * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IDummy1Vtbl;

    interface IDummy1
    {
        CONST_VTBL struct IDummy1Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IDummy1_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IDummy1_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IDummy1_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IDummy1_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IDummy1_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IDummy1_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IDummy1_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IDummy1_INTERFACE_DEFINED__ */


#ifndef __IDummy2_INTERFACE_DEFINED__
#define __IDummy2_INTERFACE_DEFINED__

/* interface IDummy2 */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IDummy2;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("880BF42F-A1E3-4FA8-87AD-FB8D96F275A0")
    IDummy2 : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IDummy2Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IDummy2 * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IDummy2 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IDummy2 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IDummy2 * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IDummy2 * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IDummy2 * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IDummy2 * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IDummy2Vtbl;

    interface IDummy2
    {
        CONST_VTBL struct IDummy2Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IDummy2_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IDummy2_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IDummy2_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IDummy2_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IDummy2_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IDummy2_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IDummy2_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IDummy2_INTERFACE_DEFINED__ */


#ifndef __IMS2DCreationAction_INTERFACE_DEFINED__
#define __IMS2DCreationAction_INTERFACE_DEFINED__

/* interface IMS2DCreationAction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IMS2DCreationAction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("B56578FA-7E2F-4EDC-A2F0-1B3F9128F227")
    IMS2DCreationAction : public IAction
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IMS2DCreationActionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMS2DCreationAction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMS2DCreationAction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMS2DCreationAction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMS2DCreationAction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMS2DCreationAction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMS2DCreationAction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMS2DCreationAction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            IMS2DCreationAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            IMS2DCreationAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanDo )( 
            IMS2DCreationAction * This,
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            IMS2DCreationAction * This,
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output);
        
        END_INTERFACE
    } IMS2DCreationActionVtbl;

    interface IMS2DCreationAction
    {
        CONST_VTBL struct IMS2DCreationActionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMS2DCreationAction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMS2DCreationAction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMS2DCreationAction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMS2DCreationAction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMS2DCreationAction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMS2DCreationAction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMS2DCreationAction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IMS2DCreationAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define IMS2DCreationAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#define IMS2DCreationAction_CanDo(This,result,can)	\
    (This)->lpVtbl -> CanDo(This,result,can)

#define IMS2DCreationAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IMS2DCreationAction_INTERFACE_DEFINED__ */


#ifndef __IMS2DCreationParameters_INTERFACE_DEFINED__
#define __IMS2DCreationParameters_INTERFACE_DEFINED__

/* interface IMS2DCreationParameters */
/* [unique][dual][uuid][object] */ 


EXTERN_C const IID IID_IMS2DCreationParameters;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("52E2BF5B-0E91-4588-8B56-D7B49EF8DE0B")
    IMS2DCreationParameters : public IParameters
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetFactor( 
            /* [retval][out] */ int *factor) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMS2DCreationParametersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMS2DCreationParameters * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMS2DCreationParameters * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMS2DCreationParameters * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMS2DCreationParameters * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMS2DCreationParameters * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMS2DCreationParameters * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMS2DCreationParameters * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFactor )( 
            IMS2DCreationParameters * This,
            /* [retval][out] */ int *factor);
        
        END_INTERFACE
    } IMS2DCreationParametersVtbl;

    interface IMS2DCreationParameters
    {
        CONST_VTBL struct IMS2DCreationParametersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMS2DCreationParameters_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMS2DCreationParameters_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMS2DCreationParameters_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMS2DCreationParameters_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMS2DCreationParameters_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMS2DCreationParameters_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMS2DCreationParameters_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IMS2DCreationParameters_GetFactor(This,factor)	\
    (This)->lpVtbl -> GetFactor(This,factor)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMS2DCreationParameters_GetFactor_Proxy( 
    IMS2DCreationParameters * This,
    /* [retval][out] */ int *factor);


void __RPC_STUB IMS2DCreationParameters_GetFactor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMS2DCreationParameters_INTERFACE_DEFINED__ */


#ifndef __IDummy3_INTERFACE_DEFINED__
#define __IDummy3_INTERFACE_DEFINED__

/* interface IDummy3 */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IDummy3;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("506F850B-7CBA-4A7F-A16D-25B3D104F7BE")
    IDummy3 : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IDummy3Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IDummy3 * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IDummy3 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IDummy3 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IDummy3 * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IDummy3 * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IDummy3 * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IDummy3 * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IDummy3Vtbl;

    interface IDummy3
    {
        CONST_VTBL struct IDummy3Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IDummy3_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IDummy3_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IDummy3_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IDummy3_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IDummy3_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IDummy3_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IDummy3_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IDummy3_INTERFACE_DEFINED__ */


#ifndef __IMS2DProcessAction_INTERFACE_DEFINED__
#define __IMS2DProcessAction_INTERFACE_DEFINED__

/* interface IMS2DProcessAction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IMS2DProcessAction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("F8F384DC-FF2E-48B5-9FB3-958A828554C5")
    IMS2DProcessAction : public IAction
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IMS2DProcessActionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMS2DProcessAction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMS2DProcessAction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMS2DProcessAction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMS2DProcessAction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMS2DProcessAction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMS2DProcessAction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMS2DProcessAction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            IMS2DProcessAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            IMS2DProcessAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanDo )( 
            IMS2DProcessAction * This,
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            IMS2DProcessAction * This,
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output);
        
        END_INTERFACE
    } IMS2DProcessActionVtbl;

    interface IMS2DProcessAction
    {
        CONST_VTBL struct IMS2DProcessActionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMS2DProcessAction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMS2DProcessAction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMS2DProcessAction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMS2DProcessAction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMS2DProcessAction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMS2DProcessAction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMS2DProcessAction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IMS2DProcessAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define IMS2DProcessAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#define IMS2DProcessAction_CanDo(This,result,can)	\
    (This)->lpVtbl -> CanDo(This,result,can)

#define IMS2DProcessAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IMS2DProcessAction_INTERFACE_DEFINED__ */


#ifndef __IMS2DProcessParameters_INTERFACE_DEFINED__
#define __IMS2DProcessParameters_INTERFACE_DEFINED__

/* interface IMS2DProcessParameters */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IMS2DProcessParameters;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9FAD2A0A-2208-4F26-ABF7-01CEFE67B738")
    IMS2DProcessParameters : public IComputationParameters
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetFactor( 
            /* [retval][out] */ int *factor) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMS2DProcessParametersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMS2DProcessParameters * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMS2DProcessParameters * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMS2DProcessParameters * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMS2DProcessParameters * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMS2DProcessParameters * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMS2DProcessParameters * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMS2DProcessParameters * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFunction )( 
            IMS2DProcessParameters * This,
            /* [retval][out] */ IFunction **function);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFactor )( 
            IMS2DProcessParameters * This,
            /* [retval][out] */ int *factor);
        
        END_INTERFACE
    } IMS2DProcessParametersVtbl;

    interface IMS2DProcessParameters
    {
        CONST_VTBL struct IMS2DProcessParametersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMS2DProcessParameters_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMS2DProcessParameters_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMS2DProcessParameters_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMS2DProcessParameters_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMS2DProcessParameters_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMS2DProcessParameters_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMS2DProcessParameters_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IMS2DProcessParameters_GetFunction(This,function)	\
    (This)->lpVtbl -> GetFunction(This,function)


#define IMS2DProcessParameters_GetFactor(This,factor)	\
    (This)->lpVtbl -> GetFactor(This,factor)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMS2DProcessParameters_GetFactor_Proxy( 
    IMS2DProcessParameters * This,
    /* [retval][out] */ int *factor);


void __RPC_STUB IMS2DProcessParameters_GetFactor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMS2DProcessParameters_INTERFACE_DEFINED__ */


#ifndef __IDummy4_INTERFACE_DEFINED__
#define __IDummy4_INTERFACE_DEFINED__

/* interface IDummy4 */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IDummy4;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("4D810CEE-9913-438E-9883-BC055371B174")
    IDummy4 : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IDummy4Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IDummy4 * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IDummy4 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IDummy4 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IDummy4 * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IDummy4 * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IDummy4 * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IDummy4 * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IDummy4Vtbl;

    interface IDummy4
    {
        CONST_VTBL struct IDummy4Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IDummy4_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IDummy4_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IDummy4_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IDummy4_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IDummy4_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IDummy4_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IDummy4_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IDummy4_INTERFACE_DEFINED__ */


#ifndef __IWritableFunction_INTERFACE_DEFINED__
#define __IWritableFunction_INTERFACE_DEFINED__

/* interface IWritableFunction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IWritableFunction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B3DA2D8-E279-4552-99F4-13AA066642D5")
    IWritableFunction : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetEquations( 
            /* [in] */ BSTR equations) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetLastError( 
            /* [retval][out] */ BSTR *message) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWritableFunctionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWritableFunction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWritableFunction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWritableFunction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IWritableFunction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IWritableFunction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IWritableFunction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IWritableFunction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetEquations )( 
            IWritableFunction * This,
            /* [in] */ BSTR equations);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetLastError )( 
            IWritableFunction * This,
            /* [retval][out] */ BSTR *message);
        
        END_INTERFACE
    } IWritableFunctionVtbl;

    interface IWritableFunction
    {
        CONST_VTBL struct IWritableFunctionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWritableFunction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IWritableFunction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IWritableFunction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IWritableFunction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IWritableFunction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IWritableFunction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IWritableFunction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IWritableFunction_SetEquations(This,equations)	\
    (This)->lpVtbl -> SetEquations(This,equations)

#define IWritableFunction_GetLastError(This,message)	\
    (This)->lpVtbl -> GetLastError(This,message)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IWritableFunction_SetEquations_Proxy( 
    IWritableFunction * This,
    /* [in] */ BSTR equations);


void __RPC_STUB IWritableFunction_SetEquations_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IWritableFunction_GetLastError_Proxy( 
    IWritableFunction * This,
    /* [retval][out] */ BSTR *message);


void __RPC_STUB IWritableFunction_GetLastError_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IWritableFunction_INTERFACE_DEFINED__ */


#ifndef __IWritableGraphInfo_INTERFACE_DEFINED__
#define __IWritableGraphInfo_INTERFACE_DEFINED__

/* interface IWritableGraphInfo */
/* [hidden][local][unique][helpstring][dual][uuid][object] */ 


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


#ifndef __IGraphInfoImpl_INTERFACE_DEFINED__
#define __IGraphInfoImpl_INTERFACE_DEFINED__

/* interface IGraphInfoImpl */
/* [unique][uuid][dual][object] */ 


EXTERN_C const IID IID_IGraphInfoImpl;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("E8AC201A-48EE-4CC4-A7D3-D075C3016104")
    IGraphInfoImpl : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IGraphInfoImplVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IGraphInfoImpl * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IGraphInfoImpl * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IGraphInfoImpl * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IGraphInfoImpl * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IGraphInfoImpl * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IGraphInfoImpl * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IGraphInfoImpl * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IGraphInfoImplVtbl;

    interface IGraphInfoImpl
    {
        CONST_VTBL struct IGraphInfoImplVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IGraphInfoImpl_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IGraphInfoImpl_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IGraphInfoImpl_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IGraphInfoImpl_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IGraphInfoImpl_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IGraphInfoImpl_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IGraphInfoImpl_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IGraphInfoImpl_INTERFACE_DEFINED__ */


#ifndef __IResultSetImpl_INTERFACE_DEFINED__
#define __IResultSetImpl_INTERFACE_DEFINED__

/* interface IResultSetImpl */
/* [unique][uuid][dual][object] */ 


EXTERN_C const IID IID_IResultSetImpl;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("3EB38E81-F41E-44BD-85E3-486CF05FD1B2")
    IResultSetImpl : public IDispatch
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IResultSetImplVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IResultSetImpl * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IResultSetImpl * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IResultSetImpl * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IResultSetImpl * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IResultSetImpl * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IResultSetImpl * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IResultSetImpl * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IResultSetImplVtbl;

    interface IResultSetImpl
    {
        CONST_VTBL struct IResultSetImplVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IResultSetImpl_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IResultSetImpl_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IResultSetImpl_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IResultSetImpl_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IResultSetImpl_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IResultSetImpl_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IResultSetImpl_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IResultSetImpl_INTERFACE_DEFINED__ */


#ifndef __IKernell_INTERFACE_DEFINED__
#define __IKernell_INTERFACE_DEFINED__

/* interface IKernell */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IKernell;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("F2D78B39-D782-49DE-91B7-771CDA2ED0E0")
    IKernell : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetFunction( 
            /* [retval][out] */ IFunction **function) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE CreateInitialResultSet( 
            /* [retval][out] */ IResultSet **result) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IKernellVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IKernell * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IKernell * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IKernell * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IKernell * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IKernell * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IKernell * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IKernell * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetFunction )( 
            IKernell * This,
            /* [retval][out] */ IFunction **function);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CreateInitialResultSet )( 
            IKernell * This,
            /* [retval][out] */ IResultSet **result);
        
        END_INTERFACE
    } IKernellVtbl;

    interface IKernell
    {
        CONST_VTBL struct IKernellVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IKernell_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IKernell_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IKernell_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IKernell_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IKernell_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IKernell_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IKernell_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IKernell_GetFunction(This,function)	\
    (This)->lpVtbl -> GetFunction(This,function)

#define IKernell_CreateInitialResultSet(This,result)	\
    (This)->lpVtbl -> CreateInitialResultSet(This,result)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IKernell_GetFunction_Proxy( 
    IKernell * This,
    /* [retval][out] */ IFunction **function);


void __RPC_STUB IKernell_GetFunction_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IKernell_CreateInitialResultSet_Proxy( 
    IKernell * This,
    /* [retval][out] */ IResultSet **result);


void __RPC_STUB IKernell_CreateInitialResultSet_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IKernell_INTERFACE_DEFINED__ */


#ifndef __IWritableKernell_INTERFACE_DEFINED__
#define __IWritableKernell_INTERFACE_DEFINED__

/* interface IWritableKernell */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IWritableKernell;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("DB255DC6-645A-4D60-A7C6-5D3019C2DBB7")
    IWritableKernell : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetFunction( 
            /* [in] */ IFunction *function) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWritableKernellVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWritableKernell * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWritableKernell * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWritableKernell * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IWritableKernell * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IWritableKernell * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IWritableKernell * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IWritableKernell * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetFunction )( 
            IWritableKernell * This,
            /* [in] */ IFunction *function);
        
        END_INTERFACE
    } IWritableKernellVtbl;

    interface IWritableKernell
    {
        CONST_VTBL struct IWritableKernellVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWritableKernell_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IWritableKernell_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IWritableKernell_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IWritableKernell_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IWritableKernell_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IWritableKernell_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IWritableKernell_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IWritableKernell_SetFunction(This,function)	\
    (This)->lpVtbl -> SetFunction(This,function)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IWritableKernell_SetFunction_Proxy( 
    IWritableKernell * This,
    /* [in] */ IFunction *function);


void __RPC_STUB IWritableKernell_SetFunction_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IWritableKernell_INTERFACE_DEFINED__ */


#ifndef __IKernellImpl_INTERFACE_DEFINED__
#define __IKernellImpl_INTERFACE_DEFINED__

/* interface IKernellImpl */
/* [unique][uuid][dual][object] */ 


EXTERN_C const IID IID_IKernellImpl;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("0667C597-8C23-4B74-A298-821DB594ED01")
    IKernellImpl : public IWritableKernell
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IKernellImplVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IKernellImpl * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IKernellImpl * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IKernellImpl * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IKernellImpl * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IKernellImpl * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IKernellImpl * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IKernellImpl * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetFunction )( 
            IKernellImpl * This,
            /* [in] */ IFunction *function);
        
        END_INTERFACE
    } IKernellImplVtbl;

    interface IKernellImpl
    {
        CONST_VTBL struct IKernellImplVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IKernellImpl_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IKernellImpl_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IKernellImpl_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IKernellImpl_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IKernellImpl_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IKernellImpl_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IKernellImpl_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IKernellImpl_SetFunction(This,function)	\
    (This)->lpVtbl -> SetFunction(This,function)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IKernellImpl_INTERFACE_DEFINED__ */


#ifndef __IMS2Metadata_INTERFACE_DEFINED__
#define __IMS2Metadata_INTERFACE_DEFINED__

/* interface IMS2Metadata */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IMS2Metadata;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("5E5AEEE1-A73F-43C7-91A6-35249171D3C4")
    IMS2Metadata : public IResultMetadata
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetSIGraphResult( 
            /* [retval][out] */ IResultSet **out) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetSIGraphResult( 
            /* [in] */ IResultSet *in) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMS2MetadataVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMS2Metadata * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMS2Metadata * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMS2Metadata * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMS2Metadata * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMS2Metadata * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMS2Metadata * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMS2Metadata * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EqualType )( 
            IMS2Metadata * This,
            /* [in] */ IResultMetadata *metadata,
            /* [retval][out] */ VARIANT_BOOL *out);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Clone )( 
            IMS2Metadata * This,
            /* [retval][out] */ IResultMetadata **metadata);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetSIGraphResult )( 
            IMS2Metadata * This,
            /* [retval][out] */ IResultSet **out);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetSIGraphResult )( 
            IMS2Metadata * This,
            /* [in] */ IResultSet *in);
        
        END_INTERFACE
    } IMS2MetadataVtbl;

    interface IMS2Metadata
    {
        CONST_VTBL struct IMS2MetadataVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMS2Metadata_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMS2Metadata_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMS2Metadata_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMS2Metadata_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMS2Metadata_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMS2Metadata_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMS2Metadata_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IMS2Metadata_EqualType(This,metadata,out)	\
    (This)->lpVtbl -> EqualType(This,metadata,out)

#define IMS2Metadata_Clone(This,metadata)	\
    (This)->lpVtbl -> Clone(This,metadata)


#define IMS2Metadata_GetSIGraphResult(This,out)	\
    (This)->lpVtbl -> GetSIGraphResult(This,out)

#define IMS2Metadata_SetSIGraphResult(This,in)	\
    (This)->lpVtbl -> SetSIGraphResult(This,in)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMS2Metadata_GetSIGraphResult_Proxy( 
    IMS2Metadata * This,
    /* [retval][out] */ IResultSet **out);


void __RPC_STUB IMS2Metadata_GetSIGraphResult_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMS2Metadata_SetSIGraphResult_Proxy( 
    IMS2Metadata * This,
    /* [in] */ IResultSet *in);


void __RPC_STUB IMS2Metadata_SetSIGraphResult_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMS2Metadata_INTERFACE_DEFINED__ */


#ifndef __IMS2DRomAction_INTERFACE_DEFINED__
#define __IMS2DRomAction_INTERFACE_DEFINED__

/* interface IMS2DRomAction */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IMS2DRomAction;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("27633F37-3573-46D6-B45D-78AE25616DAD")
    IMS2DRomAction : public IAction
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct IMS2DRomActionVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMS2DRomAction * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMS2DRomAction * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMS2DRomAction * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMS2DRomAction * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMS2DRomAction * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMS2DRomAction * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMS2DRomAction * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetActionParameters )( 
            IMS2DRomAction * This,
            /* [in] */ IParameters *parameters);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetProgressBarInfo )( 
            IMS2DRomAction * This,
            /* [in] */ IProgressBarInfo *pinfo);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *CanDo )( 
            IMS2DRomAction * This,
            /* [in] */ IResultSet *result,
            /* [retval][out] */ VARIANT_BOOL *can);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Do )( 
            IMS2DRomAction * This,
            /* [in] */ IResultSet *input,
            /* [retval][out] */ IResultSet **output);
        
        END_INTERFACE
    } IMS2DRomActionVtbl;

    interface IMS2DRomAction
    {
        CONST_VTBL struct IMS2DRomActionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMS2DRomAction_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMS2DRomAction_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMS2DRomAction_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMS2DRomAction_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMS2DRomAction_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMS2DRomAction_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMS2DRomAction_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)



#define IMS2DRomAction_SetActionParameters(This,parameters)	\
    (This)->lpVtbl -> SetActionParameters(This,parameters)

#define IMS2DRomAction_SetProgressBarInfo(This,pinfo)	\
    (This)->lpVtbl -> SetProgressBarInfo(This,pinfo)

#define IMS2DRomAction_CanDo(This,result,can)	\
    (This)->lpVtbl -> CanDo(This,result,can)

#define IMS2DRomAction_Do(This,input,output)	\
    (This)->lpVtbl -> Do(This,input,output)


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IMS2DRomAction_INTERFACE_DEFINED__ */


#ifndef __IWritableSpectrumResult_INTERFACE_DEFINED__
#define __IWritableSpectrumResult_INTERFACE_DEFINED__

/* interface IWritableSpectrumResult */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IWritableSpectrumResult;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("80B6D423-1E6D-4236-B187-FFDEC3A2A139")
    IWritableSpectrumResult : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetLowerBound( 
            /* [in] */ double data) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetUpperBound( 
            /* [in] */ double data) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetLowerLength( 
            /* [in] */ int data) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetUpperLength( 
            /* [in] */ int data) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SetMetadata( 
            /* [in] */ IResultMetadata *data) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWritableSpectrumResultVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWritableSpectrumResult * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWritableSpectrumResult * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWritableSpectrumResult * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IWritableSpectrumResult * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IWritableSpectrumResult * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IWritableSpectrumResult * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IWritableSpectrumResult * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetLowerBound )( 
            IWritableSpectrumResult * This,
            /* [in] */ double data);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetUpperBound )( 
            IWritableSpectrumResult * This,
            /* [in] */ double data);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetLowerLength )( 
            IWritableSpectrumResult * This,
            /* [in] */ int data);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetUpperLength )( 
            IWritableSpectrumResult * This,
            /* [in] */ int data);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SetMetadata )( 
            IWritableSpectrumResult * This,
            /* [in] */ IResultMetadata *data);
        
        END_INTERFACE
    } IWritableSpectrumResultVtbl;

    interface IWritableSpectrumResult
    {
        CONST_VTBL struct IWritableSpectrumResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWritableSpectrumResult_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IWritableSpectrumResult_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IWritableSpectrumResult_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IWritableSpectrumResult_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IWritableSpectrumResult_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IWritableSpectrumResult_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IWritableSpectrumResult_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IWritableSpectrumResult_SetLowerBound(This,data)	\
    (This)->lpVtbl -> SetLowerBound(This,data)

#define IWritableSpectrumResult_SetUpperBound(This,data)	\
    (This)->lpVtbl -> SetUpperBound(This,data)

#define IWritableSpectrumResult_SetLowerLength(This,data)	\
    (This)->lpVtbl -> SetLowerLength(This,data)

#define IWritableSpectrumResult_SetUpperLength(This,data)	\
    (This)->lpVtbl -> SetUpperLength(This,data)

#define IWritableSpectrumResult_SetMetadata(This,data)	\
    (This)->lpVtbl -> SetMetadata(This,data)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IWritableSpectrumResult_SetLowerBound_Proxy( 
    IWritableSpectrumResult * This,
    /* [in] */ double data);


void __RPC_STUB IWritableSpectrumResult_SetLowerBound_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IWritableSpectrumResult_SetUpperBound_Proxy( 
    IWritableSpectrumResult * This,
    /* [in] */ double data);


void __RPC_STUB IWritableSpectrumResult_SetUpperBound_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IWritableSpectrumResult_SetLowerLength_Proxy( 
    IWritableSpectrumResult * This,
    /* [in] */ int data);


void __RPC_STUB IWritableSpectrumResult_SetLowerLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IWritableSpectrumResult_SetUpperLength_Proxy( 
    IWritableSpectrumResult * This,
    /* [in] */ int data);


void __RPC_STUB IWritableSpectrumResult_SetUpperLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IWritableSpectrumResult_SetMetadata_Proxy( 
    IWritableSpectrumResult * This,
    /* [in] */ IResultMetadata *data);


void __RPC_STUB IWritableSpectrumResult_SetMetadata_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IWritableSpectrumResult_INTERFACE_DEFINED__ */



#ifndef __MorseKernel2_LIBRARY_DEFINED__
#define __MorseKernel2_LIBRARY_DEFINED__

/* library MorseKernel2 */
/* [helpstring][custom][uuid][version] */ 


EXTERN_C const IID LIBID_MorseKernel2;

EXTERN_C const CLSID CLSID_CAdaptiveMethodAction;

#ifdef __cplusplus

class DECLSPEC_UUID("92548416-C178-460D-A026-3EADF256E19F")
CAdaptiveMethodAction;
#endif

EXTERN_C const CLSID CLSID_CGraphResultImpl;

#ifdef __cplusplus

class DECLSPEC_UUID("43037E6F-9884-4D5C-BB41-44D582888F9E")
CGraphResultImpl;
#endif

EXTERN_C const CLSID CLSID_CSymbolicImageMetadata;

#ifdef __cplusplus

class DECLSPEC_UUID("A5D5EA06-663E-4755-A3E7-A536E83B5AC2")
CSymbolicImageMetadata;
#endif

EXTERN_C const CLSID CLSID_CBoxMethodAction;

#ifdef __cplusplus

class DECLSPEC_UUID("FDA0C930-C1F5-40C0-A0B6-A978CDA93F50")
CBoxMethodAction;
#endif

EXTERN_C const CLSID CLSID_CCompReg;

#ifdef __cplusplus

class DECLSPEC_UUID("84035475-16DE-4504-ABF2-5C734E46A96A")
CCompReg;
#endif

EXTERN_C const CLSID CLSID_CTarjanAction;

#ifdef __cplusplus

class DECLSPEC_UUID("76C75A0A-AC4C-4CA9-8A4E-D8283388C361")
CTarjanAction;
#endif

EXTERN_C const CLSID CLSID_CPointMethodAction;

#ifdef __cplusplus

class DECLSPEC_UUID("A1A0ABCD-1591-4846-88A0-10AF62560C37")
CPointMethodAction;
#endif

EXTERN_C const CLSID CLSID_CDummy;

#ifdef __cplusplus

class DECLSPEC_UUID("8C3F6AAB-F725-4C70-A92A-7E4BD2A30C23")
CDummy;
#endif

EXTERN_C const CLSID CLSID_CIsolatedSetAction;

#ifdef __cplusplus

class DECLSPEC_UUID("5345FB53-5138-4D28-A6FC-294DF9D0A1E9")
CIsolatedSetAction;
#endif

EXTERN_C const CLSID CLSID_CMinimalLoopLocalizationAction;

#ifdef __cplusplus

class DECLSPEC_UUID("7D81B505-C5D6-4AEF-83EF-CFAF07767898")
CMinimalLoopLocalizationAction;
#endif

EXTERN_C const CLSID CLSID_CSIRomAction;

#ifdef __cplusplus

class DECLSPEC_UUID("8C4D17D1-3A75-4E95-8D6F-CF58743A12BD")
CSIRomAction;
#endif

EXTERN_C const CLSID CLSID_CSpectrumMetadata;

#ifdef __cplusplus

class DECLSPEC_UUID("3855504A-AE6E-4601-B6E5-026F7E073D9B")
CSpectrumMetadata;
#endif

EXTERN_C const CLSID CLSID_CDummy1;

#ifdef __cplusplus

class DECLSPEC_UUID("62172280-D7A2-46C1-AF3D-E8762035048E")
CDummy1;
#endif

EXTERN_C const CLSID CLSID_CDummy2;

#ifdef __cplusplus

class DECLSPEC_UUID("F47CA110-2F50-43F2-BB91-455C9FCE6B96")
CDummy2;
#endif

EXTERN_C const CLSID CLSID_CMS2DCreationAction;

#ifdef __cplusplus

class DECLSPEC_UUID("69D041A3-98CE-44FD-A384-3EA929F27075")
CMS2DCreationAction;
#endif

EXTERN_C const CLSID CLSID_CDummy3;

#ifdef __cplusplus

class DECLSPEC_UUID("8E730EE1-B837-42E1-BB4E-3D5F9954FEA1")
CDummy3;
#endif

EXTERN_C const CLSID CLSID_CMS2DProcessAction;

#ifdef __cplusplus

class DECLSPEC_UUID("A1BF0187-E515-4B73-9F0E-7CB55F74243B")
CMS2DProcessAction;
#endif

EXTERN_C const CLSID CLSID_CDummy4;

#ifdef __cplusplus

class DECLSPEC_UUID("365CB059-BEBE-4707-8475-67724C3DF50A")
CDummy4;
#endif

EXTERN_C const CLSID CLSID_CFunctionImpl;

#ifdef __cplusplus

class DECLSPEC_UUID("FDFB8D0E-74FF-439C-A13B-4A39387B7037")
CFunctionImpl;
#endif

EXTERN_C const CLSID CLSID_CGraphInfoImpl;

#ifdef __cplusplus

class DECLSPEC_UUID("1FCB1E52-C321-4E44-8BA6-83DA8C532365")
CGraphInfoImpl;
#endif

EXTERN_C const CLSID CLSID_CResultSetImpl;

#ifdef __cplusplus

class DECLSPEC_UUID("5FAAF083-60CC-4A9B-AAC0-4FDB29047B08")
CResultSetImpl;
#endif

EXTERN_C const CLSID CLSID_CKernellImpl;

#ifdef __cplusplus

class DECLSPEC_UUID("96E908D0-29BD-423D-8CA8-9F4343C796A0")
CKernellImpl;
#endif

EXTERN_C const CLSID CLSID_CMS2Metadata;

#ifdef __cplusplus

class DECLSPEC_UUID("C18A9780-7C3A-4CA7-BD07-C8CE20EE8D6B")
CMS2Metadata;
#endif

EXTERN_C const CLSID CLSID_CMS2DRomAction;

#ifdef __cplusplus

class DECLSPEC_UUID("8394D313-8E16-4A8D-9ECD-5C42F61601B1")
CMS2DRomAction;
#endif

EXTERN_C const CLSID CLSID_CSpectrumResultImpl;

#ifdef __cplusplus

class DECLSPEC_UUID("45FBC041-D2C1-495D-8CC9-58019691E9CC")
CSpectrumResultImpl;
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


