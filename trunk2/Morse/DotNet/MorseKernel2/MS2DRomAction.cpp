// MS2DRomAction.cpp : Implementation of CMS2DRomAction

#include "stdafx.h"
#include "MS2DRomAction.h"

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




// CMS2DRomAction

CMS2DRomAction::CMS2DRomAction() {}

HRESULT CMS2DRomAction::FinalConstruct() {
    return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CMS2DRomAction::FinalRelease() {
    m_pUnkMarshaler.Release();
}



STDMETHODIMP CMS2DRomAction::CanDo(IResultSet* in, VARIANT_BOOL* out) {
    if  (GraphResultUtil::ContainsGraphOnly(in, true, 3) && 
         GraphResultUtil::ContainsMetadataOnly<IMS2Metadata>(in)) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}


STDMETHODIMP CMS2DRomAction::Do(IResultSet* in, IResultSet **out) {
	VARIANT_BOOL canDo;
	CanDo(in, &canDo);

	ATLASSERT(canDo == VARIANT_TRUE);

	ProgressBarNotificationAdapter pinfo(info);

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

    MS2DAngleMorseFunction morseFunction(func);

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
    return S_OK;
}