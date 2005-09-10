// AdaptiveBoxMethod.cpp : Implementation of CAdaptiveBoxMethod

#include "stdafx.h"
#include "AdaptiveBoxMethod.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResultImpl.h"
#include "GraphResult.h"

#include "../adaptiveCellImageBuilder/AdaptiveBoxMethod.h"
#include "SymbolicImageMetadata.h"

#include "ProgressBarNotificationAdapter.h"
#include "ResultSetList.h"

// CAdaptiveBoxMethod

CAdaptiveBoxMethod::CAdaptiveBoxMethod() {}

HRESULT CAdaptiveBoxMethod::FinalConstruct() {
    return S_OK;
}

void CAdaptiveBoxMethod::FinalRelease() {

}



STDMETHODIMP CAdaptiveBoxMethod::CanDo(IResultSet* in, VARIANT_BOOL* out) {
    *out = (GraphResultUtil::ContainsOnlyType<IGraphResult>(in) && 
	GraphResultUtil::ContainsMetadataOnly<ISymbolicImageMetadata>(in)) ?VARIANT_TRUE:VARIANT_FALSE;

    return S_OK;
}

STDMETHODIMP CAdaptiveBoxMethod::Do(IResultSet* in, IResultSet** out) {
    VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter pinfo(info);

	SmartInterface<IFunction> function;
	parameters->GetFunction(function.extract());
	ATLASSERT(function != NULL);

    HRESULT hr;

	ISystemFunction* func;
    hr = function->GetSystemFunction((void**)&func);
	ATLASSERT(SUCCEEDED(hr));

	int dimension;
	hr = function->GetDimension(&dimension);
	ATLASSERT(SUCCEEDED(hr));

	cout<<"Dimension = "<<dimension<<"\n";

	int* factor = new int[dimension];
    double* prec = new double[dimension];
	for (int i=0; i<dimension; i++) {
		hr = parameters->GetFactor(i, &factor[i]);
		cout<<"factor = "<<factor[i]<<"\n";
		ATLASSERT(SUCCEEDED(hr));
        hr = parameters->GetPrecision(i, &prec[i]);
        ATLASSERT(SUCCEEDED(hr));
	}

	GraphResultGraphIterator it(in);

    AdaptiveBoxMethod process(func, it, factor, prec, &pinfo);

	SmartInterface<IResultMetadata> metadata;
	CSymbolicImageMetadata::CreateInstance(metadata.extract());

	GraphResultUtil::PerformProcess(&process, in, false, metadata, out);
	ATLASSERT(*out != NULL);

	delete[] factor;
    delete[] prec;
	delete func;

    return S_OK;
}


STDMETHODIMP CAdaptiveBoxMethod::GetDimensionFromParameters(IResultSet* in, int* dim) {
    VARIANT_BOOL test;
	CanDo(in, &test);

	if (test = VARIANT_FALSE) return E_INVALIDARG;

	GraphResultGraphIterator it(in);
	*dim = it->getDimention();

	return S_OK;
}



STDMETHODIMP CAdaptiveBoxMethod::GetRecomendedPrecision(IResultSet* in, int id, double* prec) {
    VARIANT_BOOL test;
	CanDo(in, &test);

	if (test = VARIANT_FALSE) return E_INVALIDARG;

	GraphResultGraphIterator it(in);
	*prec = 0.95 * it->getEps()[id];

	return S_OK;
}