// TarjanAction.cpp : Implementation of CTarjanAction

#include "stdafx.h"
#include "TarjanAction.h"
#include "graphResult.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResultImpl.h"
#include "ProgressBarNotificationAdapter.h"
#include "../graph/graph.h"
#include "../graph/graphComponents.h"
#include "../cellImageBuilders/TarjanProcess.h"
#include "SmartInterface.h"
#include "symbolicImageMetadata.h"

// CTarjanAction

CTarjanAction::CTarjanAction() {
}


HRESULT CTarjanAction::FinalConstruct() {
	parameters = NULL;
	info = NULL;
	return S_OK;
}

void CTarjanAction::FinalRelease() {
	SAFE_RELEASE(parameters);
	SAFE_RELEASE(info);
}

STDMETHODIMP CTarjanAction::SetActionParameters(IParameters* pars) {
	SAFE_RELEASE(parameters);

	pars->QueryInterface(&parameters);

	ATLASSERT(parameters != NULL);

	return S_OK;
}

STDMETHODIMP CTarjanAction::SetProgressBarInfo(IProgressBarInfo* info) {
	SAFE_RELEASE(this->info);

	info->QueryInterface(&this->info);

	ATLASSERT(this->info != NULL);

	return S_OK;
}

STDMETHODIMP CTarjanAction::CanDo(IResultSet* in, VARIANT_BOOL* out) {
	
	*out = GraphResultUtil::ContainsOnlyType<IGraphResult>(in)?TRUE:FALSE;

	return S_OK;
}


STDMETHODIMP CTarjanAction::Do(IResultSet* in, IResultSet** out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	if (canDo != TRUE) return E_INVALIDARG;
	
	HRESULT hr = parameters->NeedEdgeResolve(&canDo);
	ATLASSERT(SUCCEEDED(hr));

	bool needEdgeResolve = (canDo == TRUE);

	ProgressBarNotificationAdapter pinfo(info);

	TarjanProcess ps(needEdgeResolve, &pinfo);

	SmartInterface<IResultMetadata> metadata;
	GraphResultUtil::GetMetadataCloned(in, &metadata);

	GraphResultUtil::PerformProcess(&ps, in, needEdgeResolve, metadata, out);

	ATLASSERT(*out != NULL);

	return S_OK;

}