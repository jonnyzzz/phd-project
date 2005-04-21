// IsolatedSetAction.cpp : Implementation of CIsolatedSetAction

#include "stdafx.h"
#include "IsolatedSetAction.h"
#include "graphResult.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResultImpl.h"
#include "../graph/graph.h"
#include "../homotop/minimalLoopFinderProcess.h"
#include "../homotop/IsolatingSet.h"
#include "ProgressBarNotificationAdapter.h"
#include "SmartInterface.h"


// CIsolatedSetAction

CIsolatedSetAction::CIsolatedSetAction() {

}


HRESULT CIsolatedSetAction::FinalConstruct() {
	pinfo = NULL;
	parameters = NULL;
	return S_OK;
}

void CIsolatedSetAction::FinalRelease() {
	SAFE_RELEASE(pinfo);
	SAFE_RELEASE(parameters);
}


STDMETHODIMP CIsolatedSetAction::SetActionParameters(IParameters* params) {
	SAFE_RELEASE(parameters);
	params->QueryInterface(&parameters);

	ATLASSERT(parameters != NULL);

	return S_OK;
}

STDMETHODIMP CIsolatedSetAction::SetProgressBarInfo(IProgressBarInfo* info) {
	SAFE_RELEASE(pinfo);
	info->QueryInterface(&pinfo);

	ATLASSERT(pinfo != NULL);

	return S_OK;
}

STDMETHODIMP CIsolatedSetAction::CanDo(IResultSet* resultSet, VARIANT_BOOL* result) {
	*result = GraphResultUtil::ContainsOnlyType<IGraphResult>(resultSet)?VARIANT_TRUE:VARIANT_FALSE;
	return S_OK;	
}

STDMETHODIMP CIsolatedSetAction::Do(IResultSet* input, IResultSet** output) {
	VARIANT_BOOL canDo;
	CanDo(input, &canDo);
	ATLASSERT(canDo == VARIANT_TRUE);


	SmartInterface<IGraphResult> graphResult;
	HRESULT hr = parameters->GetStartSet(graphResult.extract());
	ATLASSERT(SUCCEEDED(hr));

	GraphResultGraphIterator it(input);
	ProgressBarNotificationAdapter pinfo(this->pinfo);

	IsolatingSetProcess ps(it, GraphResultUtil::GetGraph(graphResult), &pinfo);

	SmartInterface<IResultMetadata> metadata;
	GraphResultUtil::GetMetadataCloned(input, metadata.extract());

	GraphResultUtil::PerformProcess(&ps, input, false, metadata, output);

	ATLASSERT(*output != NULL);

	return S_OK;
}