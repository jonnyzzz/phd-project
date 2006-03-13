// ProjectAction.cpp : Implementation of CProjectAction

#include "stdafx.h"
#include "ProjectAction.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResultImpl.h"
#include "GraphResult.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResult.h"
#include "GraphResultImpl.h"
#include "ProgressBarNotificationAdapter.h"
#include "SmartInterface.h"
#include "../cellImageBuilders/ProjectionProcess.h"



// CProjectAction

CProjectAction::CProjectAction() {}

HRESULT CProjectAction::FinalConstruct() {
    return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CProjectAction::FinalRelease() {
    m_pUnkMarshaler.Release();
}


STDMETHODIMP CProjectAction::CanDo(IResultSet* in, VARIANT_BOOL* out) {
	if  (GraphResultUtil::ContainsGraphOnly(in, false) ) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}
STDMETHODIMP CProjectAction::Do(IResultSet* in, IResultSet** out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter pinfo(info);

	int dimension;
	HRESULT hr = GetDimention(in, &dimension);
	ATLASSERT(SUCCEEDED(hr));

	int* devisor = new int[dimension];
	for (int i=0; i<dimension; i++) {
		hr = parameters->GetDevisor(i, &devisor[i]);
		cout<<"Devisor = "<<devisor[i]<<"\n";
		ATLASSERT(SUCCEEDED(hr));
	}

	ProjectionProcess ps(devisor, dimension, &pinfo);
	
	SmartInterface<IResultMetadata> meta;
	GraphResultUtil::GetMetadataCloned(in, meta.extract());

	GraphResultUtil::PerformProcess(&ps, in, false, meta, out);

	delete[] devisor;
	ATLASSERT(*out != NULL);

	return S_OK;
}

STDMETHODIMP CProjectAction::GetDimention(IResultSet* resultSet, int* dim) {
	VARIANT_BOOL test;
	CanDo(resultSet, &test);

	if (test = VARIANT_FALSE) return E_INVALIDARG;

	GraphResultGraphIterator it(resultSet);
	*dim = it->getDimention();

	return S_OK;
}