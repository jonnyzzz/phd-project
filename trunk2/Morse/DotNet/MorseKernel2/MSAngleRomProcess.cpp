// MSAngleRomProcess.cpp : Implementation of CMSAngleRomProcess

#include "stdafx.h"
#include "MSAngleRomProcess.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResultImpl.h"
#include "GraphResult.h"
#include "spectrumResultImpl.h"

#include "ProgressBarNotificationAdapter.h"
#include "SmartInterface.h"
#include "../systemFunction/isystemFunctionDerivate.h"
#include "../cellImageBuilders/AbstractProcess.h"
#include "../cellImageBuilders/MS2DBoxProcess.h"
#include "MS2Metadata.h"

#include "../systemFunction/ms2dangleMorseFunction.h"
#include "SpectrumMetadata.h"
#include "../graph_simplex/romFunction2N.h"

#include "symbolicimagemetadata.h"
#include "ProgressBarNotificationAdapter.h"
#include "ResultSetList.h"

#include "../graph_simplex/sirom.h"
#include "../SystemFunction/MSAngleMorseFunction.h"


#include "MSAngleMetadata.h"


// CMSAngleRomProcess

CMSAngleRomProcess::CMSAngleRomProcess() {
}

HRESULT CMSAngleRomProcess::FinalConstruct() {
	return S_OK;
}

void CMSAngleRomProcess::FinalRelease() {
}


STDMETHODIMP CMSAngleRomProcess::CanDo(IResultSet* in, VARIANT_BOOL* out) {
    if  (GraphResultUtil::ContainsGraphOnly(in, true) && 
         GraphResultUtil::ContainsMetadataOnly<IMSAngleMetadata>(in)) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}


STDMETHODIMP CMSAngleRomProcess::Do(IResultSet* in, IResultSet **out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter* pinfo = new ProgressBarNotificationAdapter(info);
    HRESULT hr;
        
    SmartInterface<IFunction> function;
	parameters->GetFunction(function.extract());
	ATLASSERT(function != NULL);

    ISystemFunctionDerivate* func;
    hr = function->GetSystemFunctionDerivate((void**)&func);
	ATLASSERT(SUCCEEDED(hr));
	
    ResultSetList<ISpectrumResult, IWritableSpectrumResult> outputList;

	SmartInterface<ISpectrumMetadata> metadata;
	CSpectrumMetadata::CreateInstance(metadata.extract());

	MSAngleMorseFunction morseFunction(func);

	for (GraphResultGraphIterator it(in); it.HasNext(); it.Next()) {
        CRomFunction2N rom(&morseFunction, it);

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

	outputList.ToResultSet()->QueryInterface(out);

    ATLASSERT(out != NULL);

    delete func;
	delete pinfo;

    return S_OK;
}