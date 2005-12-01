// MS2DCreationAction.cpp : Implementation of CMS2DCreationAction

#include "stdafx.h"
#include "MS2DCreationAction.h"
#include "AdaptiveMethodAction.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResult.h"
#include "GraphResultImpl.h"
#include "ProgressBarNotificationAdapter.h"
#include "SmartInterface.h"
#include "../systemFunction/isystemFunctionDerivate.h"
#include "../cellImageBuilders/AbstractProcess.h"
#include "../cellImageBuilders/MS2DCreationProcess.h"
#include "MS2Metadata.h"
#include "SymbolicImageMetadata.h"
#include "../adaptiveCellImageBuilder/AdaptiveProvess.h"


// CMS2DCreationAction

CMS2DCreationAction::CMS2DCreationAction() {
    info = NULL;
    parameters = NULL;
}

HRESULT CMS2DCreationAction::FinalConstruct() {
    return S_OK;
}

void CMS2DCreationAction::FinalRelease() {
    SAFE_RELEASE(info);
    SAFE_RELEASE(parameters);
}

STDMETHODIMP CMS2DCreationAction::SetActionParameters(IParameters* pars) {
    SAFE_RELEASE(parameters);

    pars->QueryInterface(&this->parameters);

    ATLASSERT(parameters != NULL);

    return S_OK;
}

STDMETHODIMP CMS2DCreationAction::SetProgressBarInfo(IProgressBarInfo* info) {
    info->QueryInterface(&this->info);
    ATLASSERT(info != NULL);
    return S_OK;
}


STDMETHODIMP CMS2DCreationAction::CanDo(IResultSet* in, VARIANT_BOOL* out) {
    int count;
    in->GetCount(&count);       
     if  (GraphResultUtil::ContainsGraphOnly(in, false, 2) && 
         GraphResultUtil::ContainsMetadataOnly<ISymbolicImageMetadata>(in)) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}

STDMETHODIMP CMS2DCreationAction::Do(IResultSet* in, IResultSet **out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter pinfo(info);

    HRESULT hr;
    
    int factor[3];
    for (int i=0; i<3; i++) {    
        hr = parameters->GetFactor(i, &factor[i]);
        ATLASSERT(SUCCEEDED(hr));
    }
    	    
    GraphResultGraphIterator it(in);
    
    MS2DCreationProcess process(it, factor, &pinfo);
    SmartInterface<IMS2Metadata> metadata;
    
    CMS2Metadata::CreateInstance(metadata.extract());
    if (factor[0] == 1 && factor[1] == 1 && GraphResultUtil::ContainsGraphOnly(in, true)) {
        metadata->SetSIGraphResult(in);
    }

    GraphResultUtil::PerformProcess(&process, in, false, metadata, out);
    ATLASSERT(*out != NULL);

    return S_OK;
}