// Kernel.h : Declaration of the CKernel

#pragma once
#include "resource.h"       // main symbols

#include "Function.h"
#include "NodeBase.h"
#include <list>

[
	dispinterface,
	uuid("7B44B0BB-0C63-4216-80B1-E228565DF73D"),
	helpstring("IKernelEvent class")
]
//, helpstring("Wrapper object will be Released after end of Event call. Hack for GarbageCollection in COM Interop")
__interface IKernelEvents {	
	[id(1), helpstring("Exception handler.")] 
		HRESULT InternalException([in] BSTR message);		 	
    [id(43)] 
        HRESULT newComputationResult([in] IKernelNode* nodeParent, [in] IComputationResult* result);
	[id(44)]
        HRESULT newKernelNode([in] IKernelNode* nodeParent, [in] IKernelNode* node);
	[id(45)]
        HRESULT noImplementation([in] IKernelNode* nodeParent);
	[id(46)]
        HRESULT noChilds([in] IKernelNode* nodeParent);

		
};


// IKernel
[
	object,
	uuid("8D366F71-EA60-4812-AFCD-BC5A20297FDD"),
	dual,	helpstring("IKernel Interface"),
	pointer_default(unique)	
]
__interface IKernel : IKernelPointer
{
	[propget, id(2),  helpstring("property Function")]
		HRESULT Function([out, retval] IFunction** pVal);
	[propputref, id(2), helpstring("property Function")]
		HRESULT Function([in] IFunction* newVal);

	[id(3), helpstring("Creates a initial graph node. type should be ISymbolicImage") ]
		HRESULT CreateRootSymbolicImage([out,retval] IKernelNode** pVal);

	[id(4)]
		HRESULT CreateSymbolicImageGroup([out, retval] IKernelNode** node);
	[id(5)]		
		HRESULT CreateProjectiveBundleGroup([out, retval] IKernelNode** node);


    //events optimization

    [id(6)]
        HRESULT EventNewNode([in] IKernelNode* nodeParent, [in] IKernelNode* nodeChild); 
    [id(7)]
        HRESULT EventNewComputationResult([in] IKernelNode* nodeParent, [in] IComputationResult* nodeCResult);        
    [id(8)]
        HRESULT EventNoChilds([in] IKernelNode* nodeParent);
    [id(9)]
        HRESULT EventNoImplementation([in] IKernelNode* nodeParent);       

	[id(10), helpstring("debugging purposes only")]
		HRESULT AllocateGarbage([in] int len);

}; 

class KernelException;

// CKernel

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.Kernel"),
	progid("MorseKernelATL.Kernel.1"),
	version(1.0),
	uuid("4C18DA89-C2C3-480B-8099-149918E4AE43"),
	helpstring("Kernel Class"),
	event_source("com")
]
class ATL_NO_VTABLE CKernel : 
	public IKernel
{
public:
	CKernel();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();	
	
	void FinalRelease(); 

	//internal functions and variables

private:
	IFunction* function;

private:
	void RaiseInternalExceptionEvent(const KernelException& ex);

private:
	void print(ostream& o);

public:
	__event __interface IKernelEvents;


public:
	STDMETHOD(get_Function)(IFunction** pVal);
	STDMETHOD(putref_Function)(IFunction* newVal);

	STDMETHOD(CreateRootSymbolicImage)(IKernelNode** pVal);

	STDMETHOD(CreateSymbolicImageGroup)(IKernelNode** node);
	STDMETHOD(CreateProjectiveBundleGroup)(IKernelNode** node);

public:
    STDMETHOD(EventNewNode)(IKernelNode* nodeParent, IKernelNode* nodeChild);
    STDMETHOD(EventNewComputationResult)(IKernelNode* parentNode, IComputationResult* nodeCResult);
    STDMETHOD(EventNoChilds)(IKernelNode* nodeParent);
    STDMETHOD(EventNoImplementation)(IKernelNode* nodeParent);


	STDMETHOD(AllocateGarbage)(int size);
};




