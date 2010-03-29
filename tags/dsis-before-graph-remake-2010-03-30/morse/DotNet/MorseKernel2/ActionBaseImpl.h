#pragma once

#include "smartInterface.h"

template <class Source>
class ActionBaseImpl
{
public:
	SmartInterface<Source> parameters;
	SmartInterface<IProgressBarInfo> info;

	HRESULT _ActionBaseImpl_SetParameters(IParameters* pars) {		
		pars->QueryInterface(parameters.extract());
		ATLASSERT(parameters != NULL);
		return S_OK;
	}

	HRESULT _ActionBaseImpl_SetProgressBarInfo(IProgressBarInfo* info) {
		info->QueryInterface(this->info.extract());
		ATLASSERT(this->info != NULL);
		return S_OK;
	}
};

#define DECLARE_ACTION_BASE_IMPL() \
	public: \
	STDMETHOD(SetActionParameters)(IParameters* pars) { return _ActionBaseImpl_SetParameters(pars); } \
	STDMETHOD(SetProgressBarInfo)(IProgressBarInfo* info) { return _ActionBaseImpl_SetProgressBarInfo(info); }

