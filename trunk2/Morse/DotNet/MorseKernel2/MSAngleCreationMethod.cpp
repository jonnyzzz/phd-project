// MSAngleCreationMethod.cpp : Implementation of CMSAngleCreationMethod

#include "stdafx.h"
#include "MSAngleCreationMethod.h"
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
#include "MSAngleMetadata.h"
#include "../cellImageBuilders/MSAngleCreationProcess.h"



CMSAngleCreationMethod::CMSAngleCreationMethod() {
}

HRESULT CMSAngleCreationMethod::FinalConstruct() {
	return S_OK;
}

void CMSAngleCreationMethod::FinalRelease() {
}

// CMSAngleCreationMethod

STDMETHODIMP CMSAngleCreationMethod::CanDo(IResultSet* in, VARIANT_BOOL* out) {
     if  (GraphResultUtil::ContainsGraphOnly(in, false) && 
         GraphResultUtil::ContainsMetadataOnly<ISymbolicImageMetadata>(in)) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}

STDMETHODIMP CMSAngleCreationMethod::GetDimension(IResultSet* in, int *dim) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

    GraphResultGraphIterator it(in);
    *dim = it.Current()->getDimention()*2 - 1;

    return S_OK;
}

STDMETHODIMP CMSAngleCreationMethod::Do(IResultSet* in, IResultSet **out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter* pinfo = new ProgressBarNotificationAdapter(info);

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
    
	MSAngleCreationProcess process(it, factor, pinfo);
    SmartInterface<IMSAngleMetadata> metadata;    
    CMSAngleMetadata::CreateInstance(metadata.extract());

    GraphResultUtil::PerformProcess(&process, in, false, metadata, out);
    ATLASSERT(*out != NULL);

	delete[] factor;
	delete pinfo;

    return S_OK;
}