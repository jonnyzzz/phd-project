// KernelNodeWrapper.h : Declaration of the CKernelNodeWrapper

#pragma once
#include "resource.h"       // main symbols
#include "nodebase.h"


// IKernelNodeWrapper
[
	object,
	uuid("571AE1AC-932B-4725-BF87-9291AB21DC54"),
	dual,	helpstring("IKernelNodeWrapper Interface"),
	pointer_default(unique)
]
__interface IKernelNodeWrapper : IDispatch
{
    [propputref, id(1)]
    HRESULT KernelNode([in] IKernelNode* node);

    [propget, id(1)]
    HRESULT KernelNode([out, retval] IKernelNode** node);
};



// CKernelNodeWrapper

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.KernelNodeWrapper"),
	progid("MorseKernelATL.KernelNodeWrapper.1"),
	version(1.0),
	uuid("DA8FF7C4-8DA4-44C0-8D73-C34485B2E3D6"),
	helpstring("KernelNodeWrapper Class")
]
class ATL_NO_VTABLE CKernelNodeWrapper : 
	public IKernelNodeWrapper
{
private:
    IKernelNode* node;

public:
	CKernelNodeWrapper()
	{
        node = NULL;
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}
	
	void FinalRelease() 
	{
        SAFE_RELEASE(node);
	}


public:

    STDMETHOD(putref_KernelNode)(IKernelNode *node) {
        SAFE_RELEASE(this->node);
        node->QueryInterface(&this->node);
        ATLASSERT(this->node != NULL);
        return S_OK;
    }

    STDMETHOD(get_KernelNode)(IKernelNode** node) {
        this->node->QueryInterface(node);
        ATLASSERT(*node != NULL);
        return S_OK;
    }
};

