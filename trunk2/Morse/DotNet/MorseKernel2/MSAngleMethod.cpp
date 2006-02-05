// MSAngleMethod.cpp : Implementation of CMSAngleMethod

#include "stdafx.h"
#include "MSAngleMethod.h"
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
#include "MSAngleMetadata.h"
#include "../adaptiveCellImageBuilder/MSAngleProcess.h"

// CMSAngleMethod

CMSAngleMethod::CMSAngleMethod() { 
}

HRESULT CMSAngleMethod::FinalConstruct() {
	return S_OK;
}

void CMSAngleMethod::FinalRelease() {
}



STDMETHODIMP CMSAngleMethod::GetRecomendedPrecision(IResultSet* in, int index, double* prec) {
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

STDMETHODIMP CMSAngleMethod::GetDimension(IResultSet* in, int* dim) {
    VARIANT_BOOL test;
	CanDo(in, &test);

	if (test = VARIANT_FALSE) return E_INVALIDARG;

	GraphResultGraphIterator it(in);
	*dim = it->getDimention();

	return S_OK;
}




STDMETHODIMP CMSAngleMethod::CanDo(IResultSet* in, VARIANT_BOOL* out) {
     if  (GraphResultUtil::ContainsOnlyType<IGraphResult>(in) && 
         GraphResultUtil::ContainsMetadataOnly<IMSAngleMetadata>(in)) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}

STDMETHODIMP CMSAngleMethod::Do(IResultSet* in, IResultSet **out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter* pinfo = new ProgressBarNotificationAdapter(info);

	SmartInterface<IFunction> function;
	parameters->GetFunction(function.extract());
	ATLASSERT(function != NULL);

    HRESULT hr;
    
	ISystemFunction* func;
    hr = function->GetSystemFunction((void**)&func);
	ATLASSERT(SUCCEEDED(hr));

	ISystemFunctionDerivate* dfunc;
	hr = function->GetSystemFunctionDerivate((void**)&dfunc);
	ATLASSERT(SUCCEEDED(hr));

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

	MSAngleProcess process(func, dfunc, it, factor, prec, (size_t)upperLimit, (size_t)upperLimit, pinfo);    
    SmartInterface<IResultMetadata> metadata;
    GraphResultUtil::GetMetadataCloned(in, metadata.extract());

    GraphResultUtil::PerformProcess(&process, in, false, metadata, out);
    ATLASSERT(*out != NULL);

    delete[] factor;
    delete[] prec;
    delete func;
	delete dfunc;
	delete pinfo;

    return S_OK;
}
