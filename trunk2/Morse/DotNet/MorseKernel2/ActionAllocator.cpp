// ActionAllocator.cpp : Implementation of CActionAllocator

#include "stdafx.h"
#include "ActionAllocator.h"
#include "ActionManagerImpl.h"


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



STDMETHODIMP CActionAllocator::AllocateActionManagerForNode(INode* forNode, IActionManager ** manager) {
	IWritableActionManager* actionManager;
	CActionManagerImpl::CreateInstance(&actionManager);

	for (FactoryList::iterator it = factoryList.begin(); it != factoryList.end(); it++) {
		IActionFactory* factory = *it;
		VARIANT_BOOL canCreate;
		factory->CanCreateActionFromNode(forNode, &canCreate);
		if (canCreate) {
			IActionBase* action = NULL;
			factory->CreateActionFromNode(forNode, &action);
			ATLASSERT(action != NULL);
			actionManager->AddAction(action);
			action->Release();
		}
	}
	actionManager->QueryInterface(manager);
	actionManager->Release();	
	return S_OK;
}

STDMETHODIMP CActionAllocator::AllocateActionManagerForAction(IActionBase* forNode, IActionManager ** manager) {
	IWritableActionManager* actionManager;
	CActionManagerImpl::CreateInstance(&actionManager);

	for (FactoryList::iterator it = factoryList.begin(); it != factoryList.end(); it++) {
		IActionFactory* factory = *it;		
		VARIANT_BOOL canCreate;
		factory->CanCreateActionFromAction(forNode, &canCreate);
		if (canCreate) {
			IActionBase* action = NULL;
			factory->CreateActionFromAction(forNode, &action);
			ATLASSERT(action != NULL);
			actionManager->AddAction(action);
			action->Release();
		}
	}
	actionManager->QueryInterface(manager);
	actionManager->Release();	
	return S_OK;
}

STDMETHODIMP CActionAllocator::RegisterActionFactory(IActionFactory* action) {
	IActionFactory* myFactory;
	action->QueryInterface(&myFactory);

	factoryList.push_back(myFactory);
	return S_OK;
}