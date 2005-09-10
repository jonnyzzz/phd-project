// AdaptiveMethodAction.cpp : Implementation of CAdaptiveMethodAction

#include "stdafx.h"
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
#include "../adaptiveCellImageBuilder/AdaptiveProvess.h"



// CAdaptiveMethodAction

CAdaptiveMethodAction::CAdaptiveMethodAction() {
    info = NULL;
    parameters = NULL;
}

HRESULT CAdaptiveMethodAction::FinalConstruct() {
    return S_OK;
}

void CAdaptiveMethodAction::FinalRelease() {
    SAFE_RELEASE(info);
    SAFE_RELEASE(parameters);
}


STDMETHODIMP CAdaptiveMethodAction::SetActionParameters(IParameters* pars) {
    SAFE_RELEASE(parameters);

    pars->QueryInterface(&this->parameters);

    ATLASSERT(parameters != NULL);

    return S_OK;
}

STDMETHODIMP CAdaptiveMethodAction::SetProgressBarInfo(IProgressBarInfo* info) {
    info->QueryInterface(&this->info);
    ATLASSERT(info != NULL);
    return S_OK;
}

STDMETHODIMP CAdaptiveMethodAction::CanDo(IResultSet* in, VARIANT_BOOL* out) {
     if  (GraphResultUtil::ContainsOnlyType<IGraphResult>(in) && 
         GraphResultUtil::ContainsMetadataOnly<ISymbolicImageMetadata>(in)) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}

STDMETHODIMP CAdaptiveMethodAction::Do(IResultSet* in, IResultSet **out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter pinfo(info);

	SmartInterface<IFunction> function;
	parameters->GetFunction(function.extract());
	ATLASSERT(function != NULL);

    HRESULT hr;

    double precision;
    hr = parameters->GetPrecision(&precision);
    ATLASSERT(SUCCEEDED(hr));

	ISystemFunction* func;
    hr = function->GetSystemFunction((void**)&func);
	ATLASSERT(SUCCEEDED(hr));

    int dimension;
	hr = function->GetDimension(&dimension);
	ATLASSERT(SUCCEEDED(hr));

	cout<<"Dimension = "<<dimension<<"\n";
    cout<<"Precision = "<<precision<<"\n";

	int* factor = new int[dimension];
    double* prec = new double[dimension];
	for (int i=0; i<dimension; i++) {
		hr = parameters->GetFactor(i, &factor[i]);
		cout<<"factor = "<<factor[i]<<"\n";
		ATLASSERT(SUCCEEDED(hr));
        prec[i] = precision;
	}

    GraphResultGraphIterator it(in);

    AdaptiveProvess process(func, it, factor, prec, &pinfo);
    SmartInterface<IResultMetadata> metadata;
    GraphResultUtil::GetMetadataCloned(in, metadata.extract());

    GraphResultUtil::PerformProcess(&process, in, false, metadata, out);
    ATLASSERT(*out != NULL);

    delete[] factor;
    delete[] prec;
    delete func;

    return S_OK;
}


STDMETHODIMP CAdaptiveMethodAction::GetRecomendedPrecision(IResultSet* in, double* prec) {
    VARIANT_BOOL test;
	CanDo(in, &test);

	if (test = VARIANT_FALSE) return E_INVALIDARG;

	GraphResultGraphIterator it(in);

    Graph* graph = it;
    double d = graph->getEps()[0];
    for (int i=1; i<graph->getDimention(); i++) {
        if (d < graph->getEps()[i]) {
            d = graph->getEps()[i];
        }
    }

    *prec = d/3;

    return S_OK;
}

STDMETHODIMP CAdaptiveMethodAction::GetDimension(IResultSet* in, int* dim) {
    VARIANT_BOOL test;
	CanDo(in, &test);

	if (test = VARIANT_FALSE) return E_INVALIDARG;

	GraphResultGraphIterator it(in);
	*dim = it->getDimention();

	return S_OK;
}