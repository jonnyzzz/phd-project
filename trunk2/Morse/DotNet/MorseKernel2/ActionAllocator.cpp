// ActionAllocator.cpp : Implementation of CActionAllocator

#include "stdafx.h"
#include "ActionAllocator.h"


// CActionAllocator

CActionAllocator::CActionAllocator() {

}


HRESULT CActionAllocator::FinalConstruct() {
	return S_OK;
}



void CActionAllocator::FinalRelease() {
	for (FactoryList::iterator it = factoryList.begin(); it != factoryList.end(); it++) {
		(*it)->Release();
	}
}



STDMETHODIMP CActionAllocator::AllocateActionManager(INode* forNode, IActionManager ** manager) {
	for (FactoryList::iterator it = factoryList.begin(); it != factoryList.end(); it++) {
		

	}
	*manager = NULL;
	return E_NOTIMPL;
}

STDMETHODIMP CActionAllocator::RegisterActionFactory(IActionFactory* action) {
	IActionFactory* myFactory;
	action->QueryInterface(&myFactory);

	factoryList.push_back(myFactory);
	return S_OK;
}