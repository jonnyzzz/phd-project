// Kernel.cpp : Implementation of CKernel


#include <afx.h>
#include "stdafx.h"


#include "Kernel.h"
#include "SymbolicImage.h"
#include "KernelException.h"
#include "SymbolicImageGraph.h"
#include "SymbolicImageGroup.h"
#include "ProjectiveBundleGroup.h"


// CKernel
	

CKernel::CKernel() {	
	this->function = NULL;	
}

HRESULT CKernel::FinalConstruct() {	
		
	TRACE_CREATE(CKernel);

	return S_OK;
}

void CKernel::FinalRelease() {
	SAFE_RELEASE(this->function);

	TRACE_DESTRUCT(CKernel);
	
}


void CKernel::RaiseInternalExceptionEvent(const KernelException& ex) {
	__raise InternalException(ex.getMessage().AllocSysString());
}

void CKernel::print(ostream& o) {	
	o<<"Kernel:\n";

	o<<"Dump comlete\n\n";	
}


STDMETHODIMP CKernel::get_Function(IFunction** pVal) {
	if (function != NULL) {
		function->QueryInterface(pVal);
		*pVal = function;

		Function* f;
		function->getFunction((void**)&f);
		f->print();	

	} else {
		*pVal = NULL;
	}
	return S_OK;
}

STDMETHODIMP CKernel::putref_Function(IFunction* newVal) {
	if (function != NULL) {
		__raise KernelFunctionChanged(function, newVal);			
		function->Release();
	}
	newVal->QueryInterface(&function);
	return S_OK;
}

STDMETHODIMP CKernel::CreateRootSymbolicImage(IKernelNode** pVal) {
	ISymbolicImageGraph* im;
	CSymbolicImageGraph::CreateInstance(&im);

	Graph* graph;
	function->createGraph((void**)&graph);

	graph->maximize();

	im->setGraph((void*)graph);
	im->AddRef();

	im->putref_kernel(this);

	*pVal = (IKernelNode*)im;

#ifdef _DEBUG
	cout<<"\nvDEBUG\n";
#else
	cout<<"\nvRELEASE\n";
#endif
	
	return S_OK;
}

STDMETHODIMP CKernel::CreateSymbolicImageGroup(IKernelNode **node) {
	ISymbolicImageGroup* group = NULL;
	CSymbolicImageGroup::CreateInstance(&group);

	ATLVERIFY(group != NULL);
	
	group->putref_kernel(this);

	*node = group;

	return S_OK;
}


STDMETHODIMP CKernel::CreateProjectiveBundleGroup(IKernelNode **node) {
	IProjectiveBundleGroup* group = NULL;
	CProjectiveBundleGroup::CreateInstance(&group);
    
	ATLVERIFY(group != NULL);

	group->putref_kernel(this);

	*node = group;

	return S_OK;
}