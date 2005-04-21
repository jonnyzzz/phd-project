// SIRomAction.cpp : Implementation of CSIRomAction

#include "stdafx.h"
#include "SIRomAction.h"
#include "GraphResult.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "symbolicimagemetadata.h"
#include "ProgressBarNotificationAdapter.h"
#include "ResultSetList.h"
#include "spectrumResultImpl.h"
#include "SmartInterface.h"
#include "../systemfunction/isystemfunctionderivate.h"
#include "SpectrumMetadata.h"
#include "../graph_simplex/sirom.h"
// CSIRomAction

CSIRomAction::CSIRomAction() {

}

HRESULT CSIRomAction::FinalConstruct() {
	return S_OK;
}

void CSIRomAction::FinalRelease() {

}


STDMETHODIMP CSIRomAction::CanDo(IResultSet* result, VARIANT_BOOL* can) {

	bool v = GraphResultUtil::ContainsGraphOnly(result, true);

	*can = v?VARIANT_TRUE:VARIANT_FALSE;

	return S_OK;
}


STDMETHODIMP CSIRomAction::Do(IResultSet* input, IResultSet** output) {
	VARIANT_BOOL canDo;
	CanDo(input, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	HRESULT hr;

	SmartInterface<IFunction> function;
	hr = parameters->GetFunction(function.extract());
	ATLASSERT(SUCCEEDED(hr) && function != NULL);

	ISystemFunctionDerivate* func;
	hr = function->GetSystemFunctionDerivate((void**)&func);
	ATLASSERT(SUCCEEDED(hr));

	ProgressBarNotificationAdapter* pinfo = new ProgressBarNotificationAdapter(info);
	GraphResultGraphIterator it(input);

	ResultSetList<ISpectrumResult, IWritableSpectrumResult> outputList;

	SmartInterface<ISpectrumMetadata> metadata;
	CSpectrumMetadata::CreateInstance(metadata.extract());

	for (GraphResultGraphIterator it(input); it.HasNext(); it.Next()) {
		SIRom rom(it, func);

		SmartInterface<IWritableSpectrumResult> aResult;
		CSpectrumResultImpl::CreateInstance(aResult.extract());	

		rom.minimize();
		aResult->SetLowerBound(rom.getAnswer());
		aResult->SetLowerLength(rom.getAnswerLength());

		rom.maximize();
		aResult->SetUpperBound(rom.getAnswer());
		aResult->SetUpperLength(rom.getAnswerLength());

		aResult->SetMetadata(metadata);

		outputList.AddResult(aResult);
	}

	outputList.ToResultSet()->QueryInterface(output);

	delete func;
	delete pinfo;

	ATLASSERT(*output != NULL);

	return S_OK;
}