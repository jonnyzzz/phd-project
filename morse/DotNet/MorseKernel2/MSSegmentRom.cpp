// MSSegmentRom.cpp : Implementation of CMSSegmentRom

#include "stdafx.h"
#include "MSSegmentRom.h"

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
#include "MSSegmentMetadata.h"

#include "../SystemFunction/SegmentProjectiveExtensionMorseFunction.h"
#include "SpectrumMetadata.h"
#include "../graph_simplex/romFunction2N.h"

#include "symbolicimagemetadata.h"
#include "ProgressBarNotificationAdapter.h"
#include "ResultSetList.h"

#include "../graph_simplex/sirom.h"


// CMSSegmentRom

CMSSegmentRom::CMSSegmentRom() {
}

HRESULT CMSSegmentRom::FinalConstruct() {
    return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CMSSegmentRom::FinalRelease() {
    m_pUnkMarshaler.Release();
}



STDMETHODIMP CMSSegmentRom::CanDo(IResultSet* in, VARIANT_BOOL* out) {
    if  (GraphResultUtil::ContainsGraphOnly(in, true) && 
        GraphResultUtil::ContainsMetadataOnly<IMSSegmentMetadata>(in)) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
    return S_OK;    
}


STDMETHODIMP CMSSegmentRom::Do(IResultSet* in, IResultSet** out) {
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

    SegmentProjectiveExtensionMorseFunction morseFunction(func);

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
