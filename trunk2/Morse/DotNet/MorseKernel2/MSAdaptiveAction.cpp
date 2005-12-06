// MSAdaptiveAction.cpp : Implementation of CMSAdaptiveAction

#include "stdafx.h"
#include "MSAdaptiveAction.h"
#include "AdaptiveMethodAction.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResult.h"
#include "GraphResultImpl.h"
#include "ProgressBarNotificationAdapter.h"
#include "SmartInterface.h"
#include "../systemFunction/isystemFunctionDerivate.h"
#include "../cellImageBuilders/AbstractProcess.h"
#include "../cellImageBuilders/SimpleBoxProcess.h"
#include "SymbolicImageMetadata.h"
#include "../adaptiveCellImageBuilder/SegmentAdaptiveProcess.h"
#include "../SystemFunction/SegmentProjectiveExtendedSystemFunction.h"
#include "MSSegmentMetadata.h"

// CMSAdaptiveAction

CMSAdaptiveAction::CMSAdaptiveAction() {
}

HRESULT CMSAdaptiveAction::FinalConstruct() {
	return S_OK;
}

void CMSAdaptiveAction::FinalRelease() {
}


STDMETHODIMP CMSAdaptiveAction::CanDo(IResultSet* in, VARIANT_BOOL* out) {
     if  (GraphResultUtil::ContainsOnlyType<IGraphResult>(in) && 		 
		 GraphResultUtil::ContainsMetadataOnly<IMSSegmentMetadata>(in)) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}

STDMETHODIMP CMSAdaptiveAction::Do(IResultSet* in, IResultSet **out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter pinfo(info);

	HRESULT hr;
	SmartInterface<IFunction> function;
	hr = parameters->GetFunction(function.extract());
	ATLASSERT(SUCCEEDED(hr));
	ATLASSERT(function != NULL);
        
	ISystemFunctionDerivate* funcDerivate;
	ISystemFunction* func;
    
	hr = function->GetSystemFunctionDerivate((void**)&funcDerivate);
	ATLASSERT(SUCCEEDED(hr));
	hr = function->GetSystemFunction((void**)&func);
	ATLASSERT(SUCCEEDED(hr));
	SegmentProjectiveExtendedSystemFunction* exFunc = new SegmentProjectiveExtendedSystemFunction(funcDerivate, func);

    int dimension;
	hr = GetDimension(in, &dimension);
	ATLASSERT(SUCCEEDED(hr));
   
	cout<<"Dimension = "<<dimension<<"\n";

	int* factor = new int[dimension];
    double* prec = new double[dimension];
	for (int i=0; i<dimension; i++) {
		hr = parameters->GetFactor(i, &factor[i]);		
		ATLASSERT(SUCCEEDED(hr));
        hr = parameters->GetPrecision(i, &prec[i]);
        ATLASSERT(SUCCEEDED(hr));
        cout<<"factor = "<<factor[i]<<"  prec = "<<prec[i]<<"\n";
	}
    int upperLimit;
    hr = parameters->GetUpperLimit(&upperLimit);
    ATLASSERT(SUCCEEDED(hr));

    GraphResultGraphIterator it(in);

	SegmentAdaptiveProcess process(exFunc, it, factor, prec, (size_t)upperLimit, &pinfo);
    SmartInterface<IResultMetadata> metadata;
    GraphResultUtil::GetMetadataCloned(in, metadata.extract());

    GraphResultUtil::PerformProcess(&process, in, false, metadata, out);
    ATLASSERT(*out != NULL);

    delete[] factor;
    delete[] prec;
    delete exFunc;
	delete func;
	delete funcDerivate;

    return S_OK;
}


STDMETHODIMP CMSAdaptiveAction::GetRecomendedPrecision(IResultSet* in, int index, double* prec) {
    VARIANT_BOOL test;
	CanDo(in, &test);

	if (test = VARIANT_FALSE) return E_INVALIDARG;

	GraphResultGraphIterator it(in);
    
    double d = it->getEps()[index];    
    for (; it.HasNext(); it.Next()) {
        if (d < it->getEps()[index]) {
            d = it->getEps()[index];
        }
    }

    *prec = d/3;

    return S_OK;
}

STDMETHODIMP CMSAdaptiveAction::GetDimension(IResultSet* in, int* dim) {
    VARIANT_BOOL test;
	CanDo(in, &test);

	if (test == VARIANT_FALSE) return E_INVALIDARG;

	GraphResultGraphIterator it(in);
	*dim = it->getDimention();

	return S_OK;
}