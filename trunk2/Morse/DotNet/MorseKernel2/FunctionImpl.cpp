// FunctionImpl.cpp : Implementation of CFunctionImpl

#include "stdafx.h"
#include "FunctionImpl.h"
#include "kernellexception.h"
#include "../graph/functionInclude.h"
#include "../graph/GraphException.h"
#include "../graph/graph.h"
#include "../systemFunction/systemfunction.h"
#include "../systemFunction/systemFunctionDerivate.h"
#include "../calculator/IntervalEvaluator.h"
#include "../calculator/LipsitzFinder.h"



// CFunctionImpl

CFunctionImpl::CFunctionImpl() {

}


HRESULT CFunctionImpl::FinalConstruct() {
	Reset();

	return S_OK;
}


void CFunctionImpl::FinalRelease() {
	CleanUp();
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

STDMETHODIMP CFunctionImpl::SetIterations(int its) {
	if (!isInitialized) return E_FAIL;
	this->iterations = its;
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
	cout<<"Setting Function in CFunctionImpl\n";
	
	CleanUp();
	isInitialized = false;

	this->equations = CString(equations);
	bool b = initializeContent();


	return b?S_OK:E_INVALIDARG;
}

STDMETHODIMP CFunctionImpl::GetLastError(BSTR* message) {
	*message = lastErrorMessage.AllocSysString();
	return S_OK;
}

STDMETHODIMP CFunctionImpl::CreateGraph(void** graph) {
	cout<<"Getting Graph From CFunctionImpl\n";

	if (!isInitialized) {
		*graph = NULL;
		return E_FAIL;
	} else {
		*graph = new Graph(dimension, space_min, space_max, grid, false);
		return S_OK;
	}
}

//////////////////////////////////////////////////

void CFunctionImpl::Reset() {
	equations = "";
	lastErrorMessage = "";
	isInitialized = false;
	functionFactory = NULL;
	dimension = 0;
	iterations = 0;
	space_min = NULL;
	space_max = NULL;
	grid = NULL;
	scope = NULL;
	lipshitz = NULL;
}

void CFunctionImpl::CleanUp() {
	SAFE_DELETE( functionFactory);

	SAFE_DELETE_ARR( space_min);
	SAFE_DELETE_ARR( space_max);
	SAFE_DELETE_ARR( grid );
	SAFE_DELETE_ARR( scope );
	SAFE_DELETE_ARR( lipshitz );
	
	Reset();
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

		if (this->dimension <= 0) { 
			throw KernelException(KernelException_NegativeDimention);
		}

		delete node;

		this->space_max = new JDouble[dimension];
		this->space_min = new JDouble[dimension];
		this->grid = new JInt[dimension];
		this->scope = new Interval[dimension];
		this->lipshitz = new JDouble[dimension];

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

        FunctionContext* lowerBound = new FunctionContext();
		FunctionContext* upperBound = new FunctionContext();
		
		for (int i=0; i<this->dimension; i++) {
			sprintf(buf, "x%d", i+1);
			int variableID = functionFactory->getFunctionDictionary()->lookUp(buf);
			cx.addSubstitute(variableID, new FunctionNodeConstant(0));
			lowerBound->addSubstitute(variableID, new FunctionNodeConstant(space_min[i]));
			upperBound->addSubstitute(variableID, new FunctionNodeConstant(space_max[i]));
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

		cout<<"\nExtrama and Lipshitz computations\n";

		for (int i=0; i<dimension; i++) {
			node = NULL;
			sprintf(buf, "y%d", i+1);
			node = safeGetNode(buf, KernelException(KernelException_NoFunctionEquation, i));
			IntervalEvaluator evaluator(lowerBound, upperBound);
			node->Accept(&evaluator);
			scope[i] = evaluator.getValue();
			LipsitzFinder lip(lowerBound, upperBound);
			node->Accept(&lip);
			lipshitz[i] = lip.getValue();
			delete node;
		}
        delete lowerBound;
        delete upperBound;

		cout<<"\nExtrema computation finished\n\n";

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


////////////////////////////////////////////////

STDMETHODIMP CFunctionImpl::GetMinimum(int i, double* value) {
	if (!isInitialized) return E_FAIL;
	if (i < 0 || i >= dimension) return E_INVALIDARG;

	*value = scope[i].lower();

	return S_OK;
}


STDMETHODIMP CFunctionImpl::GetMaximum(int i, double* value) {
	if (!isInitialized) return E_FAIL;
	if (i < 0 || i >= dimension) return E_INVALIDARG;

	*value = scope[i].upper();

	return S_OK;
}

STDMETHODIMP CFunctionImpl::GetLipshitz(int i, double* value) {
	if (!isInitialized) return E_FAIL;
	if (i < 0 || i >= dimension) return E_INVALIDARG;

	*value = lipshitz[i];

	return S_OK;
}