// TarjanAction.cpp : Implementation of CTarjanAction

#include "stdafx.h"
#include "TarjanAction.h"
#include "graphResult.h"
#include "GraphResultWrapper.h"
#include "GraphResultImpl.h"
#include "../graph/graph.h"
#include "../graph/graphComponents.h"

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

STDMETHODIMP CTarjanAction::CanDo(IResultBase* in, VARIANT_BOOL* out) {
	IGraphResult* result = NULL;
	in->QueryInterface(&result);

	if (result != NULL) {
		result->Release();
		*out = TRUE;
	} else {
		*out = FALSE;
	}

	return S_OK;
}


STDMETHODIMP CTarjanAction::Do(IResultBase* in, IResultBase** out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	if (canDo != TRUE) return E_INVALIDARG;

	IGraphResult* inputGraph;
	in->QueryInterface(&inputGraph);

	ATLASSERT(inputGraph != NULL);

	IWritableGraphResult* outResult;
	CGraphResultImpl::CreateInstance(&outResult);

	ATLASSERT(outResult != NULL);

	HRESULT hr = parameters->NeedEdgeResolve(&canDo);

	ATLASSERT(SUCCEEDED(hr));

	bool needEdgeResolve = (canDo == TRUE);

	GraphResultGraphList resultList(outResult);

	info->Start();

	for (GraphResultGraphIterator it(inputGraph); it.hasNext(); it.Next()) {
		Graph* graph = it.Current();
		GraphComponents* cms = graph->localazeStrongComponents();

		for (int i = 0; i<cms->length(); i++) {
			Graph* tmp = cms->getAt(i);
			if (needEdgeResolve) {
				tmp->resolveEdges(graph);
			}
			resultList.AddGraph(tmp, needEdgeResolve);
		}
	}

	outResult->QueryInterface(out);
	ATLASSERT(*out != NULL);

	info->Finish();

	return S_OK;

}