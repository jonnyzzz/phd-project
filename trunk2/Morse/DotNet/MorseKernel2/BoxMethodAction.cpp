// BoxMethodAction.cpp : Implementation of CBoxMethodAction

#include "stdafx.h"
#include "BoxMethodAction.h"
#include "GraphResultWrapper.h"
#include "GraphResult.h"
#include "GraphResultImpl.h"
#include "ProgressBarNotificationAdapter.h"
#include "SmartInterface.h"
#include "../systemFunction/isystemFunctionDerivate.h"
#include "../cellImageBuilders/AbstractProcess.h"
#include "../cellImageBuilders/SimpleBoxProcess.h"


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


STDMETHODIMP CBoxMethodAction::CanDo(IResultBase* in, VARIANT_BOOL* out) {
	IGraphResult* result;
	in->QueryInterface(&result);

	if (result != NULL) {
		result->Release();
		*out = TRUE;
	} else {
		*out = FALSE;
	}

	return S_OK;
}


STDMETHODIMP CBoxMethodAction::Do(IResultBase* in, IResultBase** out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == TRUE);

	IGraphResult* inputResult;
	in->QueryInterface(&inputResult);

	ATLASSERT(inputResult != NULL);

	ProgressBarNotificationAdapter adapter(info);

	SmartInterface<IFunction> function;
	parameters->GetFunction(&function);

	ATLASSERT(function != NULL);

	ISystemFunction* func;

	HRESULT hr = parameters->UseDerivate(&canDo);
	ATLASSERT(SUCCEEDED(hr));

	if (canDo == TRUE) {
		hr = function->GetSystemFunctionDerivate((void**)&func);
	} else {
		hr = function->GetSystemFunction((void**)&func);
	}

	ATLASSERT(SUCCEEDED(hr));

	int dimension;
	hr = function->GetDimension(&dimension);
	ATLASSERT(SUCCEEDED(hr));
	int* factor = new int[dimension];

	for (int i=0; i<dimension; i++) {
		hr = parameters->GetFactor(i, &factor[i]);
		ATLASSERT(SUCCEEDED(hr));
	}

	GraphResultGraphIterator it(inputResult);

	AbstractProcess* process = new SimpleBoxProcess(it, func, factor, &adapter);
	process->start();
	IWritableGraphResult* outResult;
	CGraphResultImpl::CreateInstance(&outResult);

	GraphResultUtil().PerformProcess(process, inputResult, outResult, false);
	
	delete process;
	delete[] factor;
	delete func;

	outResult->QueryInterface(out);
	ATLASSERT(*out != NULL);

	return S_OK;
}