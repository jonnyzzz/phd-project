// MinimalLoopLocalizationAction.cpp : Implementation of CMinimalLoopLocalizationAction

#include "stdafx.h"
#include "MinimalLoopLocalizationAction.h"
#include "graphResult.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResultImpl.h"
#include "../graph/graph.h"
#include "../homotop/minimalLoopFinderProcess.h"
#include "ProgressBarNotificationAdapter.h"
#include "SmartInterface.h"


// CMinimalLoopLocalizationAction

CMinimalLoopLocalizationAction::CMinimalLoopLocalizationAction() {
	
}


HRESULT CMinimalLoopLocalizationAction::FinalConstruct() {
	pinfo = NULL;
	parameters = NULL;
	return S_OK;
}

void CMinimalLoopLocalizationAction::FinalRelease() {
	SAFE_RELEASE(pinfo);
	SAFE_RELEASE(parameters);
}


STDMETHODIMP CMinimalLoopLocalizationAction::SetActionParameters(IParameters* params) {
	SAFE_RELEASE(parameters);
	params->QueryInterface(&parameters);

	ATLASSERT(parameters != NULL);

	return S_OK;
}

STDMETHODIMP CMinimalLoopLocalizationAction::SetProgressBarInfo(IProgressBarInfo* info) {
	SAFE_RELEASE(pinfo);
	info->QueryInterface(&pinfo);

	ATLASSERT(pinfo != NULL);

	return S_OK;
}

STDMETHODIMP CMinimalLoopLocalizationAction::CanDo(IResultSet* resultSet, VARIANT_BOOL* result) {
	*result = GraphResultUtil::ContainsOnlyType<IGraphResult>(resultSet)?true:false;
	return S_OK;	
}

STDMETHODIMP CMinimalLoopLocalizationAction::GetDimension(IResultSet* resultSet, int* result) {
	VARIANT_BOOL canDo;
	CanDo(resultSet, &canDo);
	ATLASSERT(canDo);

	GraphResultGraphIterator it (resultSet);
	*result = it->getDimention();

	return S_OK;
}


STDMETHODIMP CMinimalLoopLocalizationAction::Do(IResultSet* input, IResultSet** output) {
	VARIANT_BOOL canDo;
	CanDo(input, &canDo);
	ATLASSERT(canDo);

	int dimension;
	GetDimension(input, &dimension);

	JDouble* data = new JDouble[dimension];
	for (int i=0; i<dimension; i++) {
		HRESULT hr = parameters->GetCoordinate(i, &data[i]);
		ATLASSERT(SUCCEEDED(hr));
		cout<<"data["<<i<<"] = "<<data[i]<<"\n";
	}
	ProgressBarNotificationAdapter pinfo(this->pinfo);

	MinimalLoopFinderProcess ps(data, dimension, &pinfo);

	SmartInterface<IResultMetadata> metadata;
	GraphResultUtil::GetMetadataCloned(input, &metadata);

	GraphResultUtil::PerformProcess(&ps, input, false, metadata, output);

	ATLASSERT(*output != NULL);


	delete[] data;

	return S_OK;
}