// PointMethodAction.cpp : Implementation of CPointMethodAction

#include "stdafx.h"
#include "PointMethodAction.h"
#include "GraphResult.h"
#include "GraphResultWrapper.h"
#include "GraphResultUtil.h"
#include "symbolicimagemetadata.h"
#include "../systemFunction/isystemfunction.h"
#include "../cellImageBuilders/sipointbuilder.h"
#include "../cellImageBuilders/sioverlapedpointBuilder.h"
#include "ProgressBarNotificationAdapter.h"



// CPointMethodAction

CPointMethodAction::CPointMethodAction() {

}


HRESULT CPointMethodAction::FinalConstruct() {
	this->parameters = NULL;
	this->info = NULL;
	return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CPointMethodAction::FinalRelease() {
	SAFE_RELEASE(parameters);
	SAFE_RELEASE(info);
    m_pUnkMarshaler.Release();
}



STDMETHODIMP CPointMethodAction::GetDimensionForParameters(IResultSet* resultSet, int* dim) {
	VARIANT_BOOL data;
	this->CanDo(resultSet, &data);
	ATLASSERT(data == VARIANT_TRUE);

	GraphResultGraphIterator it(resultSet);
	*dim = it->getDimention();

	return S_OK;
}


STDMETHODIMP CPointMethodAction::SetActionParameters(IParameters* pars) {
	SAFE_RELEASE(this->parameters);

	pars->QueryInterface(&parameters);

	ATLASSERT(parameters != NULL);

	return S_OK;
}

STDMETHODIMP CPointMethodAction::SetProgressBarInfo(IProgressBarInfo* info) {
	SAFE_RELEASE(this->info);
	info->QueryInterface(&this->info);
	ATLASSERT(this->info != NULL);
	return S_OK;
}

STDMETHODIMP CPointMethodAction::CanDo(IResultSet* in, VARIANT_BOOL* out) {
	*out = (GraphResultUtil::ContainsOnlyType<IGraphResult>(in) && 
		GraphResultUtil::ContainsMetadataOnly<ISymbolicImageMetadata>(in))?VARIANT_TRUE:VARIANT_FALSE;
	return S_OK;
}


STDMETHODIMP CPointMethodAction::Do(IResultSet* in, IResultSet** out) {
	VARIANT_BOOL data;
	HRESULT hr;
	CanDo(in, &data);

	ATLASSERT(data == VARIANT_TRUE);

	SmartInterface<IFunction> function;
	hr = parameters->GetFunction(function.extract());
	ATLASSERT(SUCCEEDED(hr) && function != NULL);

	ISystemFunction* func;
	hr = function->GetSystemFunction((void**)&func);
	ATLASSERT(SUCCEEDED(hr));

	hr = parameters->UseOffsets(&data);
	bool useOffset = (data == VARIANT_TRUE)?true:false;

	int dimension;
	hr = function->GetDimension(&dimension);
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
		process = new SIOverlapedPointBuilder(it, factor, ks, off1, off2, func, pinfo);
	} else {
		process = new SIPointBuilder(it, factor, ks, func, pinfo);
	}


	SmartInterface<ISymbolicImageMetadata> metadata;
	CSymbolicImageMetadata::CreateInstance(metadata.extract());

	GraphResultUtil::PerformProcess(process, in, false, metadata, out);
	ATLASSERT(*out != NULL);

	delete[] factor;
	delete[] ks;
	delete[] off1;
	delete[] off2;

	delete func;
	delete pinfo;
	delete process;

	return S_OK;
}