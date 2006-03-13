// LoopsLocalizationAction.cpp : Implementation of CLoopsLocalizationAction

#include "stdafx.h"
#include "LoopsLocalizationAction.h"
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
#include "../cellImageBuilders/loopslocalizationprocess.h"

// CLoopsLocalizationAction

CLoopsLocalizationAction::CLoopsLocalizationAction() {}

HRESULT CLoopsLocalizationAction::FinalConstruct() {
	return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CLoopsLocalizationAction::FinalRelease() {
    m_pUnkMarshaler.Release();
}



STDMETHODIMP CLoopsLocalizationAction::CanDo(IResultSet* in, VARIANT_BOOL* out) {
	if  (GraphResultUtil::ContainsGraphOnly(in, true) ) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}


STDMETHODIMP CLoopsLocalizationAction::Do(IResultSet* in, IResultSet** out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter pinfo(info);

	LoopsLocalizationProcess ps(&pinfo);
	
	SmartInterface<IResultMetadata> meta;
	GraphResultUtil::GetMetadataCloned(in, meta.extract());

	GraphResultUtil::PerformProcess(&ps, in, false, meta, out);
	ATLASSERT(*out != NULL);

	return S_OK;
}