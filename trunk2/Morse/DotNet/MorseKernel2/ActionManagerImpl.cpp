// ActionManagerImpl.cpp : Implementation of CActionManagerImpl

#include "stdafx.h"
#include "ActionManagerImpl.h"


// CActionManagerImpl


CActionManagerImpl::CActionManagerImpl() {

}

HRESULT CActionManagerImpl::FinalConstruct() {
	return S_OK;
}

void CActionManagerImpl::FinalRelease() {
	for (ActionsList::iterator it = actionsList.begin(); it != actionsList.end(); it++) {
		(*it)->Release();
	}
}

STDMETHODIMP CActionManagerImpl::GetLength(int* cnt) {
	*cnt = (int)actionsList.size();
	return S_OK;
}


STDMETHODIMP CActionManagerImpl::GetAction(int index, IActionBase** action) {
	ActionsList::iterator it = actionsList.begin();
	while (index-- > 0) it++;
	if (it == actionsList.end()) {
		return E_INVALIDARG;
	} else {
		(*it) -> QueryInterface(action);
		return S_OK;
	}
}

STDMETHODIMP CActionManagerImpl::AddAction(IActionBase* action) {
	IActionBase* myAction;
	action->QueryInterface(&myAction);
	actionsList.push_back(myAction);
	return S_OK;
}


