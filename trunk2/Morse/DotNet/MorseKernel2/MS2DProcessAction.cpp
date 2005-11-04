// MS2DProcessAction.cpp : Implementation of CMS2DProcessAction

#include "stdafx.h"
#include "MS2DProcessAction.h"
#include "AdaptiveMethodAction.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResult.h"
#include "GraphResultImpl.h"
#include "ProgressBarNotificationAdapter.h"
#include "SmartInterface.h"
#include "../systemFunction/isystemFunctionDerivate.h"
#include "../cellImageBuilders/AbstractProcess.h"
#include "../cellImageBuilders/MS2DBoxProcess.h"
#include "MS2Metadata.h"
#include "SymbolicImageMetadata.h"
#include "../adaptiveCellImageBuilder/AdaptiveProvess.h"
#include "../systemFunction/ms2dangleFunction.h"
#include "../cellImageBuilders/MS2DSIBoxProcess.h"


// CMS2DProcessAction

CMS2DProcessAction::CMS2DProcessAction() {
}

HRESULT CMS2DProcessAction::FinalConstruct() {
    return S_OK;
}

void CMS2DProcessAction::FinalRelease() {
}


STDMETHODIMP CMS2DProcessAction::CanDo(IResultSet* in, VARIANT_BOOL* out) {
     if  (GraphResultUtil::ContainsOnlyType<IGraphResult>(in) && 
         GraphResultUtil::ContainsMetadataOnly<IMS2Metadata>(in)) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}


STDMETHODIMP CMS2DProcessAction::Do(IResultSet* in, IResultSet **out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter pinfo(info);

    HRESULT hr;

    int factor[3];
    factor[0] = factor[1] = 1;
    hr = parameters->GetFactor(&factor[2]);
    ATLASSERT(SUCCEEDED(hr));
    
    SmartInterface<IFunction> function;
	parameters->GetFunction(function.extract());
	ATLASSERT(function != NULL);

    ISystemFunctionDerivate* func;
    hr = function->GetSystemFunctionDerivate((void**)&func);
	ATLASSERT(SUCCEEDED(hr));
	
    SmartInterface<IMS2Metadata> metadata;
    GraphResultUtil::GetMetadataClonedEx(in, metadata.extract());

    SmartInterface<IResultSet> original;
    metadata->GetSIGraphResult(original.extract());    
    GraphSet graph = GraphResultUtil::GetGraphs(original);

    GraphResultGraphIterator it(in);
    
    MS2DAngleFunction msFucntion(func);

    MS2DBoxProcess process(&msFucntion, it, graph, factor, &pinfo);
    
    GraphResultUtil::PerformProcess(&process, in, false, metadata, out);
    ATLASSERT(*out != NULL);

    delete func;
    return S_OK;
}