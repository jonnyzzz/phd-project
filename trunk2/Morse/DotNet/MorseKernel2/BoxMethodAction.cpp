// BoxMethodAction.cpp : Implementation of CBoxMethodAction

#include "stdafx.h"
#include "BoxMethodAction.h"
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


// CBoxMethodAction

CBoxMethodAction::CBoxMethodAction() {
}


HRESULT CBoxMethodAction::FinalConstruct() {
	parameters = NULL;
	info = NULL;
	return S_OK;
}

void CBoxMethodAction::FinalRelease() {
	SAFE_RELEASE(info);
	SAFE_RELEASE(parameters);
}


STDMETHODIMP CBoxMethodAction::SetActionParameters(IParameters* pars) {
	SAFE_RELEASE(parameters);

	pars->QueryInterface(&parameters);

	ATLASSERT(parameters != NULL);

	return S_OK;
}

STDMETHODIMP CBoxMethodAction::SetProgressBarInfo(IProgressBarInfo* info) {
	info->QueryInterface(&this->info);

	ATLASSERT(this->info != NULL);

	return S_OK;
}


STDMETHODIMP CBoxMethodAction::CanDo(IResultSet* in, VARIANT_BOOL* out) {
	*out = (GraphResultUtil::ContainsOnlyType<IGraphResult>(in)&& GraphResultUtil::ContainsMetadataOnly<ISymbolicImageMetadata>(in)) ?TRUE:FALSE;

	return S_OK;
}


STDMETHODIMP CBoxMethodAction::Do(IResultSet* in, IResultSet** out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == TRUE);

	ProgressBarNotificationAdapter pinfo(info);

	SmartInterface<IFunction> function;
	parameters->GetFunction(&function);
	ATLASSERT(function != NULL);

	ISystemFunction* func;

	HRESULT hr = parameters->UseDerivate(&canDo);
	ATLASSERT(SUCCEEDED(hr));

	if (canDo == TRUE) {
		hr = function->GetSystemFunctionDerivate((void**)&func);
		ATLASSERT(SUCCEEDED(hr));
	} else {
		hr = function->GetSystemFunction((void**)&func);
		ATLASSERT(SUCCEEDED(hr));
	}
	
	int dimension;
	hr = function->GetDimension(&dimension);
	ATLASSERT(SUCCEEDED(hr));

	int* factor = new int[dimension];
	for (int i=0; i<dimension; i++) {
		hr = parameters->GetFactor(i, &factor[i]);
		ATLASSERT(SUCCEEDED(hr));
	}

	GraphResultGraphIterator it(in);

	SimpleBoxProcess process(it, func, factor, &pinfo);

	SmartInterface<IResultMetadata> metadata;
	CSymbolicImageMetadata::CreateInstance(&metadata);

	GraphResultUtil::PerformProcess(&process, in, false, metadata, out);
	ATLASSERT(*out != NULL);

	delete[] factor;
	delete func;

	return S_OK;
}