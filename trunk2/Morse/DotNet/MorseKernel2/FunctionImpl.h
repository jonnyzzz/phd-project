// FunctionImpl.h : Declaration of the CFunctionImpl

#pragma once
#include "resource.h"       // main symbols
#include "Function.h"
#include "WritableFunction.h"
#include "../graph/typedefs.h"

class FunctionFactory;
class KernelException;
class FunctionNode;

// CFunctionImpl

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.FunctionImpl"),
	progid("MorseKernel2.FunctionImpl.1"),
	version(1.0),
	uuid("FDFB8D0E-74FF-439C-A13B-4A39387B7037"),
	helpstring("FunctionImpl Class")
]
class ATL_NO_VTABLE CFunctionImpl : 
	public IFunction,
	public IWritableFunction
{
public:
	CFunctionImpl();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

public:

	//IFunction
	STDMETHOD(GetSystemFunction)(void** function);
	STDMETHOD(GetSystemFunctionDerivate)(void** function);
	STDMETHOD(GetEquations)(BSTR* eqations);
	STDMETHOD(GetDimension)(int* dim);
	STDMETHOD(GetIterations)(int* dim);
	STDMETHOD(CreateGraph)(void** graph);

	//IWritableFunction
	STDMETHOD(SetEquations)(BSTR equations);
	STDMETHOD(GetLastError)(BSTR* message);

private:
	bool isInitialized;
	CString equations;
	CString lastErrorMessage;
	FunctionFactory* functionFactory;

	JDouble* space_min;
	JDouble* space_max;
	JInt* grid;

	int dimension;
	int iterations;


private:
	void CleanUp();
	bool initializeContent();
	FunctionNode* safeGetNode(const char* name, KernelException fail);
};