// Function.h : Declaration of the CFunction

#pragma once
#include "resource.h"       // main symbols

class SystemFunction;
class SystemFunctionDerivate;
class IProjectiveExtensionInfo;

[
	object,
	uuid("47A8D8C4-8744-4150-A8F9-278AE08C4DA4"),
	dual
] 
__interface IFunctionEvents {
	[id(1), helpstring("Wrong parametes notify")]
		HRESULT FunctionWrongInput([in] BSTR description);
	[id(2)]
		HRESULT FunctionChanged([in] BSTR oldFunction, [in] BSTR newFunction);
	[id(3)]
		HRESULT FunctionAccepted();
};


// IFunction
[
	object,
	uuid("83229BF2-7EB9-428D-B832-831CACFAE78C"),
	dual,	helpstring("IFunction Interface"),
	pointer_default(unique)
]
__interface IFunction : IDispatch
{
	[propget, id(1), helpstring("property SystemSource")] 
		HRESULT SystemSource([out, retval] BSTR* pVal);
	[propput, id(1), helpstring("property SystemSource")] 
		HRESULT SystemSource([in] BSTR newVal);
	[id(2), local, hidden]
		HRESULT getFunction([out, unique] void ** func);
	[id(3), local, hidden]
		HRESULT createGraph([out, unique] void ** graph);
    [id(4), local, hidden]
        HRESULT getSystemFunction([out, unique] void** function);
    [id(5), local, hidden]
        HRESULT getSystemFunctionDerivate([out, unique] void** function);
    [id(6), local, hidden]
        HRESULT getProjectiveExtensionInfo([out, unique] void **pinfo);
};

class Function;
class KernelException;


// CFunction

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.Function"),
	progid("MorseKernelATL.Function.1"),
	version(1.0),
	uuid("95B0D0F5-D7BD-48D8-B13A-5E5538F334E9"),
	helpstring("Function Class"),
	event_source("com")
]
class ATL_NO_VTABLE CFunction : 
	public IFunction
{
public:
	CFunction();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();
	

	__event __interface IFunctionEvents;

private:
	int dimension;
	int* grid;
	JDouble* space_min;
	JDouble* space_max;
	
	Function* function;
	FunctionFactory* factory;

    ISystemFunction* systemFunction;
    ISystemFunctionDerivate* systemFunctionDerivate;
    IProjectiveExtensionInfo* projectiveExtensionInfo;
   
	CString source;

	bool created;

private:
	void cleanUP();
	void initializeContent();

	FunctionNode* safeGetNode(const char* name, KernelException fail);

public:
	Function* getFunction();
	FunctionFactory* getFunctionFactory();
	Graph* createGraph();

	void print(ostream& o);

public:

	STDMETHOD(get_SystemSource)(BSTR* pVal);
	STDMETHOD(put_SystemSource)(BSTR newVal);
	STDMETHOD(getFunction)(void** function);
	STDMETHOD(createGraph)(void** graph);

    STDMETHOD(getSystemFunction)(void** function);
    STDMETHOD(getSystemFunctionDerivate)(void** function);
    STDMETHOD(getProjectiveExtensionInfo)(void** pinfo);

};

