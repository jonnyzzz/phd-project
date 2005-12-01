// MSCreationProcess.cpp : Implementation of CMSCreationProcess

#include "stdafx.h"
#include "MSCreationProcess.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResult.h"
#include "GraphResultImpl.h"
#include "ProgressBarNotificationAdapter.h"
#include "SmartInterface.h"
#include "../cellImageBuilders/AbstractProcess.h"
#include "../cellImageBuilders/SegmentProjectiveBundleMSCreationProcess.h"
#include "MSSegmentMetadata.h"
#include "SymbolicImageMetadata.h"

// CMSCreationProcess

CMSCreationProcess::CMSCreationProcess() {
}

HRESULT CMSCreationProcess::FinalConstruct() {
    return S_OK;
}

void CMSCreationProcess::FinalRelease() {
}


STDMETHODIMP CMSCreationProcess::CanDo(IResultSet* in, VARIANT_BOOL* out) {
     if  (GraphResultUtil::ContainsGraphOnly(in, false) && 
         GraphResultUtil::ContainsMetadataOnly<ISymbolicImageMetadata>(in)) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}

STDMETHODIMP CMSCreationProcess::GetDimension(IResultSet* in, int *dim) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

    GraphResultGraphIterator it(in);
    *dim = it.Current()->getDimention()*2;

    return S_OK;
}

STDMETHODIMP CMSCreationProcess::Do(IResultSet* in, IResultSet **out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter pinfo(info);

    HRESULT hr;
    
    GraphResultGraphIterator it(in);
    int dim; 
    hr = GetDimension(in, &dim);
    ATLASSERT(SUCCEEDED(hr));

    int* factor = new int[dim];
    for (int i=0; i<dim; i++) {
        hr = parameters->GetFactor(i, &factor[i]);
        cout<<"factor = "<<factor[i]<<"\n";
        ATLASSERT(SUCCEEDED(hr));
    }  	    
    
    SegmentProjectiveBundleMSCreationProcess process(it, factor, &pinfo);
    SmartInterface<IMSSegmentMetadata> metadata;    
    CMSSegmentMetadata::CreateInstance(metadata.extract());

    GraphResultUtil::PerformProcess(&process, in, false, metadata, out);
    ATLASSERT(*out != NULL);

    return S_OK;
}