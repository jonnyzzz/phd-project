// FunctionImpl.cpp : Implementation of CFunctionImpl

#include "stdafx.h"
#include "FunctionImpl.h"
#include "kernellexception.h"
#include "../graph/functionInclude.h"
#include "../graph/GraphException.h"
#include "../graph/graph.h"
#include "../systemFunction/systemfunction.h"
#include "../systemFunction/systemFunctionDerivate.h"



// CFunctionImpl

CFunctionImpl::CFunctionImpl() {

}


HRESULT CFunctionImpl::FinalConstruct() {
	equations = "";
	isInitialized = false;
	functionFactory = NULL;
	space_min = NULL;
	space_max = NULL;
	grid = NULL;

	return S_OK;
}


void CFunctionImpl::FinalRelease() {
	SAFE_DELETE( functionFactory);

	SAFE_DELETE_ARR( space_min);
	SAFE_DELETE_ARR( space_max);
	SAFE_DELETE_ARR( grid );
}


STDMETHODIMP CFunctionImpl::GetEquations(BSTR* equations) {
	if (!isInitialized) return E_FAIL;

	*equations = this->equations.AllocSysString();
	return S_OK;
}

STDMETHODIMP CFunctionImpl::GetDimension(int* dim) {
	if (!isInitialized) return E_FAIL;
	*dim = this->dimension;
	return S_OK;
}

STDMETHODIMP CFunctionImpl::GetIterations(int* its) {
	if (!isInitialized) return E_FAIL;
	*its = this->iterations;
	return S_OK;
}


STDMETHODIMP CFunctionImpl::GetSystemFunction(void** function) {
	if (!isInitialized) {
		*function = NULL;
		return E_FAIL;
	}

	*function = (void*) new SystemFunction(functionFactory, dimension, iterations);

	return S_OK;
}

STDMETHODIMP CFunctionImpl::GetSystemFunctionDerivate(void** function) {
	if (!isInitialized) {
		*function = NULL;
		return E_FAIL;
	}

	*function = (void*) new SystemFunctionDerivate(functionFactory, dimension, iterations);

	return S_OK;
}


STDMETHODIMP CFunctionImpl::SetEquations(BSTR equations) {
	isInitialized = false;

	this->equations = CString(equations);

	return (initializeContent())?S_OK:E_INVALIDARG;
}

STDMETHODIMP CFunctionImpl::GetLastError(BSTR* message) {
	*message = lastErrorMessage.AllocSysString();
	return S_OK;
}

STDMETHODIMP CFunctionImpl::CreateGraph(void** graph) {
	if (!isInitialized) {
		*graph = NULL;
		return E_FAIL;
	} else {
		*graph = new Graph(dimension, space_min, space_max, grid);
		return S_OK;
	}
}

//////////////////////////////////////////////////

void CFunctionImpl::CleanUp() {
	FinalRelease();
	FinalConstruct();
}


FunctionNode* CFunctionImpl::safeGetNode(const char* name, KernelException fail) {
	if (functionFactory == NULL) throw KernelException(KernelException_NoFunctionFactory);
	try {
		return functionFactory->getEquation(name);
	} catch (FunctionFactoryParseException ex) {
		if (ex.getType() == FunctionFactoryParseException_NoSuchEquation) throw fail;
		throw;
	}
}


bool CFunctionImpl::initializeContent() {
	//todo: FIX Throw memory leaks
	try {
		functionFactory = new FunctionFactory((LPCTSTR)this->equations);

		cout<<"\ninputed:\n"<<(LPCTSTR)this->equations<<"\nEnded\n\n";

		functionFactory->print(cout);
		
		cout<<"\nEnd of functionSource dump\n\n";

		FunctionNode* node = NULL;

		node = safeGetNode("_dimension", KernelException(KernelException_NoDimention));
		if (!node->canSimplify(&(FunctionContext()))) 
			throw KernelException(KernelException_UnableToEvaluateDimension);

		this->dimension = (int)node->evaluate(&FunctionContext());

		cout<<"Internal Function Dimension = "<<dimension<<"\n";

		if (this->dimension <= 0) 
			throw KernelException(KernelException_NegativeDimention);

		delete node;

		this->space_max = new JDouble[dimension];
		this->space_min = new JDouble[dimension];

		this->grid = new JInt[dimension];

		char buf[255];
		for (int i=0; i<dimension;i++) {
			node = NULL;
			sprintf(buf, "space_min%d", i+1);
			node = safeGetNode(buf, KernelException(KernelException_NoSpaceMin, i));
			if (!node->canSimplify(&FunctionContext())) {
				delete node;
				throw KernelException(KernelException_UnableToEvaluateSpaceMin, i);
			} else {
				space_min[i] = (JDouble)node->evaluate(&FunctionContext());
				delete node;
			}

			node = NULL;
			sprintf(buf, "space_max%d", i+1);
			node = safeGetNode(buf, KernelException(KernelException_NoSpaceMax, i));
			if (!node->canSimplify(&FunctionContext())) {
				delete node;
				throw KernelException(KernelException_UnableToEvaluateSpaceMax, i);
			} else {
				space_max[i] = (JDouble)node->evaluate(&FunctionContext());
				delete node;
			}

			node = NULL;
			sprintf(buf, "grid%d", i+1);
			node = safeGetNode(buf, KernelException(KernelException_NoGrid, i));
			if (!node->canSimplify(&FunctionContext())) {
				delete node;
				throw KernelException(KernelException_UnableToEvaluateGrid, 1);
			} else {
				grid[i] = (JInt)node->evaluate(&FunctionContext());
				delete node;
			}
			node = NULL;
		}

		for (int i=0; i<dimension; i++) {
			if (space_min[i] >= space_max[i]) throw KernelException(KernelException_NegativeSpace, i);
			if (grid[i] <= 0) throw KernelException(KernelException_NegativeGrid);
		}

		//parse function source
		FunctionContext cx;
		
		for (int i=0; i<this->dimension; i++) {
			sprintf(buf, "x%d", i+1);
			cx.addSubstitute(functionFactory->getFunctionDictionary()->lookUp(buf), new FunctionNodeConstant(0));
		}
		
		for (int i=0; i<this->dimension; i++) {
			node = NULL;
			sprintf(buf, "y%d", i+1);
			node = safeGetNode(buf, KernelException(KernelException_NoFunctionEquation, i));
			if (!node->canSimplify(&cx)) {
				delete node;
				throw KernelException( KernelException_UnexpectedVariableDependency, i);
			} else {
				delete node;
			}			
		}

		node = NULL;
		iterations = 1;
		try {
			node = functionFactory->getEquation("iteration");
			if (node->canSimplify(&cx)) {
				iterations = (int)node->evaluate(&cx);
				if (iterations < 1) throw KernelException(KernelException_WrongIterations);
			}			
		} catch (FunctionFactoryParseException e) {
			if (e.getType() != FunctionFactoryParseException_NoSuchEquation) {
				throw;
			}
		}
		SAFE_DELETE(node);

		cout<<"Current iteration : "<<iterations<<"\n";

		isInitialized = true;

		lastErrorMessage = "";

		return true;

	} catch (FunctionFactoryParseException ex) {
		lastErrorMessage = KernelException(ex).getMessage();
	} catch (GraphException ex) {
		lastErrorMessage = KernelException(ex).getMessage();
	} catch (KernelException ex) {
		lastErrorMessage = ex.getMessage();
	} catch (...) {
		lastErrorMessage = KernelException().getMessage();
	}

	return false;
}