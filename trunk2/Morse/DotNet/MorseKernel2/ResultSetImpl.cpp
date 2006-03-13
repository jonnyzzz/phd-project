// ResultSetImpl.cpp : Implementation of CResultSetImpl

#include "stdafx.h"
#include "ResultSetImpl.h"


// CResultSetImpl

CResultSetImpl::CResultSetImpl() {
}


HRESULT CResultSetImpl::FinalConstruct() {
	return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CResultSetImpl::FinalRelease() {
	for (ResultList::iterator it = resultList.begin(); it != resultList.end(); it++) {
		(*it)->Release();
	}
    m_pUnkMarshaler.Release();
}

STDMETHODIMP CResultSetImpl::GetCount(int* count) {
	*count = (int) resultList.size();
	return S_OK;
}

STDMETHODIMP CResultSetImpl::GetResult(int index, IResultBase** result) {
	ResultList::iterator it = resultList.begin();
	for (int i=0; i<index; i++) it++;
	if (it != resultList.end()) {
		(*it)->QueryInterface(result);
		ATLASSERT(*result != NULL);
		return S_OK;
	} else {
		return E_INVALIDARG;
	}
}

STDMETHODIMP CResultSetImpl::AddResult(IResultBase* result) {
	IResultBase* myResult;
	result->QueryInterface(&myResult);
	ATLASSERT(myResult != NULL);
	resultList.push_back(myResult);
	return S_OK;
}