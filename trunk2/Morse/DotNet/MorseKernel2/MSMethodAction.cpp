// MSMethodAction.cpp : Implementation of CMSMethodAction

#include "stdafx.h"
#include "MSMethodAction.h"

#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "GraphResultImpl.h"
#include "GraphResult.h"

#include "ProgressBarNotificationAdapter.h"
#include "SmartInterface.h"
#include "../systemFunction/ISystemFunctionDerivate.h"
#include "../systemFunction/SegmentProjectiveExtendedSystemFunction.h"
#include "../cellImageBuilders/AbstractProcess.h"
#include "../cellImageBuilders/MS2DBoxProcess.h"
#include "../cellImageBuilders/MSPointBuilder.h"
#include "../cellImageBuilders/MSOverlapedPointBuilder.h"
#include "MSSegmentMetadata.h"

#include "ProgressBarNotificationAdapter.h"
#include "ResultSetList.h"


// CMSMethodAction

CMSMethodAction::CMSMethodAction() {
}

HRESULT CMSMethodAction::FinalConstruct() {
    return S_OK;
}

void CMSMethodAction::FinalRelease() {
}


STDMETHODIMP CMSMethodAction::CanDo(IResultSet* in, VARIANT_BOOL* out) {
    if  (GraphResultUtil::ContainsGraphOnly(in, false) && 
         GraphResultUtil::ContainsMetadataOnly<IMSSegmentMetadata>(in)) {
             *out = VARIANT_TRUE;
         } else {
             *out = VARIANT_FALSE;
         }
         return S_OK;
}


STDMETHODIMP CMSMethodAction::GetDimensionForParameters(IResultSet* resultSet, int* dim) {
	VARIANT_BOOL data;
	this->CanDo(resultSet, &data);
	ATLASSERT(data == VARIANT_TRUE);

	GraphResultGraphIterator it(resultSet);
	*dim = it->getDimention();

	return S_OK;
}




STDMETHODIMP CMSMethodAction::Do(IResultSet* in, IResultSet** out) {
	VARIANT_BOOL data;
	HRESULT hr;
	CanDo(in, &data);

	ATLASSERT(data == VARIANT_TRUE);

	SmartInterface<IFunction> function;
	hr = parameters->GetFunction(function.extract());
	ATLASSERT(SUCCEEDED(hr) && function != NULL);

	ISystemFunctionDerivate* funcDer;
	hr = function->GetSystemFunctionDerivate((void**)&funcDer);
	ATLASSERT(SUCCEEDED(hr));
	ISystemFunction* func;
	hr = function->GetSystemFunction((void**)&func);
	ATLASSERT(SUCCEEDED(hr));
	
    SegmentProjectiveExtendedSystemFunction* projFunc = new SegmentProjectiveExtendedSystemFunction(funcDer, func);

	hr = parameters->UseOffsets(&data);
	bool useOffset = (data == VARIANT_TRUE)?true:false;

	int dimension;
	hr = GetDimensionForParameters(in, &dimension);
	ATLASSERT(SUCCEEDED(hr));

	cout<<"Dimenstion = "<<dimension<<"\n";

	int* factor = new int[dimension];
	int* ks = new int[dimension];
	double* off1 = new double[dimension];
	double* off2 = new double[dimension];

	ProgressBarNotificationAdapter* pinfo = new ProgressBarNotificationAdapter(info);
	GraphResultGraphIterator it(in);

	for (int i=0; i<dimension; i++) {
		hr = parameters->GetFactor(i, &factor[i]);
		ATLASSERT(SUCCEEDED(hr));

		hr = parameters->GetPoints(i, &ks[i]);
		ATLASSERT(SUCCEEDED(hr));

		if (useOffset) {
			hr = parameters->GetOffset(i, &off1[i], &off2[i]);
			ATLASSERT(SUCCEEDED(hr));
		}
	}

	AbstractProcess* process;
	if (useOffset) {        
		process = new MSOverlapedPointBuilder(it, factor, ks, off1, off2, projFunc, pinfo);
	} else {
		process = new MSPointBuilder(it, factor, ks, projFunc, pinfo);
	}


	SmartInterface<IMSSegmentMetadata> metadata;
    CMSSegmentMetadata::CreateInstance(metadata.extract());

	GraphResultUtil::PerformProcess(process, in, false, metadata, out);
	ATLASSERT(*out != NULL);

	delete[] factor;
	delete[] ks;
	delete[] off1;
	delete[] off2;

    delete projFunc;
	delete func;
	delete funcDer;
	delete pinfo;
	delete process;

	return S_OK;
}