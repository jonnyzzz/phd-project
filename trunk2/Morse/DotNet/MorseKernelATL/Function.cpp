// Function.cpp : Implementation of CFunction

#include "stdafx.h"
#include "Function.h"
#include ".\function.h"
#include ".\KernelException.h"

// CFunction

#define SAFE_DELETE_ARR(x) {if((x)!=NULL){{delete[] (x);}{(x)=NULL;}}}

CFunction::CFunction() {
	dimension = 0;
	grid = NULL;
	space_max = NULL;
	space_min = NULL;
	function = NULL;
	factory = NULL;
    systemFunction = NULL;
    systemFunctionDerivate = NULL;
    projectiveExtensionInfo = NULL;
	created = false;
}

HRESULT CFunction::FinalConstruct() {
	TRACE_CREATE(CFunction);
	return S_OK;
}


void CFunction::FinalRelease() {
	cleanUP();
	

	TRACE_DESTRUCT(CFunction);
}


STDMETHODIMP CFunction::get_SystemSource(BSTR* pVal)
{
	*pVal = source.AllocSysString();

	return S_OK;
}

STDMETHODIMP CFunction::put_SystemSource(BSTR newVal)
{
	CString nSource (newVal);
	
	if (created) {
		__raise FunctionChanged(source.AllocSysString(), nSource.AllocSysString());
		return E_FAIL;
	}

	cleanUP();

	source = nSource;
	initializeContent();

	return S_OK;
}


void CFunction::cleanUP() {
	SAFE_DELETE_ARR(grid);
	SAFE_DELETE_ARR(space_max);
	SAFE_DELETE_ARR(space_min);

	SAFE_DELETE(factory);
    SAFE_DELETE(systemFunction);
    SAFE_DELETE(systemFunctionDerivate);
    SAFE_DELETE(projectiveExtensionInfo);
	SAFE_DELETE(function);
    
}


FunctionNode* CFunction::safeGetNode(const char* name, KernelException fail) {
	if (factory == NULL) throw KernelException(KernelException_NoFunctionFactory);
	try {
		return factory->getEquation(name);
	} catch (FunctionFactoryParseException ex) {
		if (ex.getType() == FunctionFactoryParseException_NoSuchEquation) throw fail;
		throw;
	}
}

void CFunction::initializeContent() {
	try { 
		factory = new FunctionFactory((LPCTSTR)this->source);
		FunctionNode* node = NULL;

		node = safeGetNode("_dimension", KernelException(KernelException_NoDimention));
		if (!node->canSimplify(&(FunctionContext()))) 
			throw KernelException(KernelException_UnableToEvaluateDimension);

		this->dimension = (int)node->evaluate(&FunctionContext());

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
			if (!node->canSimplify(&FunctionContext())) throw KernelException(KernelException_UnableToEvaluateSpaceMin, i);
			space_min[i] = (JDouble)node->evaluate(&FunctionContext());
			delete node;

			node = NULL;
			sprintf(buf, "space_max%d", i+1);
			node = node = safeGetNode(buf, KernelException(KernelException_NoSpaceMax, i));
			if (!node->canSimplify(&FunctionContext())) throw KernelException(KernelException_UnableToEvaluateSpaceMax, i);
			space_max[i] = (JDouble)node->evaluate(&FunctionContext());
			delete node;

			node = NULL;
			sprintf(buf, "grid%d", i+1);
			node = safeGetNode(buf, KernelException(KernelException_NoGrid, i));
			if (!node->canSimplify(&FunctionContext())) throw KernelException(KernelException_UnableToEvaluateGrid, 1);
			grid[i] = (JInt)node->evaluate(&FunctionContext());
			delete node;
			node = NULL;
		}

		for (int i=0; i<dimension; i++) {
			if (space_min[i] >= space_max[i]) throw KernelException(KernelException_NegativeSpace, i);
			if (grid[i] <= 0) throw KernelException(KernelException_NegativeGrid);
		}

		//parse function source
		FunctionContext cx;
		
		for (int i=0; i<this->dimension; i++) {
			sprintf(buf, Function::VariableName, i+1);
			cx.addSubstitute(factory->getFunctionDictionary()->lookUp(buf), new FunctionNodeConstant(0));
		}
		
		for (int i=0; i<this->dimension; i++) {
			node = NULL;
			sprintf(buf, Function::FunctionName, i+1);
			node = safeGetNode(buf, KernelException(KernelException_NoFunctionEquation, i));
			if (!node->canSimplify(&cx)) throw KernelException( KernelException_UnexpectedVariableDependency, i);
			delete node;
		}

		node = NULL;
		int iterations = 1;
		try {
			node = factory->getEquation("iteration");
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

		function = new Function(factory, dimension, iterations);
        systemFunction = new SystemFunction(factory, dimension, iterations);
        systemFunctionDerivate = new SystemFunctionDerivate(factory, dimension, iterations);
        projectiveExtensionInfo = new SermentProjectiveExtensionInfo(systemFunctionDerivate);

		created = true;

		cout<<"Creation of fucntion is completed sucessfully";

		__raise FunctionAccepted();

	} catch (FunctionFactoryParseException ex) {
		__raise FunctionWrongInput(KernelException(ex).getMessage().AllocSysString());
	} catch (GraphException ex) {
		__raise FunctionWrongInput(KernelException(ex).getMessage().AllocSysString());
	} catch (KernelException ex) {
		__raise FunctionWrongInput(ex.getMessage().AllocSysString());
	} catch (...) {
		__raise FunctionWrongInput(KernelException().getMessage().AllocSysString());
	}
}

Function* CFunction::getFunction() {
	return function;
}

FunctionFactory* CFunction::getFunctionFactory() {
	return factory;
}

void CFunction::print(ostream& o) {
	o<<"CFuntion dump:\nFactory:\n";
	if (created) {
		factory->print(o);
		o<<"\n\nDimension="<<dimension<<"\n";

		for (int i=0; i<dimension;i++) {
			o<<i<<": min="<<space_min[i]<<"\tmax="
				<<space_max[i]<<"\tgrid="<<grid[i]<<"\n";
		}

	} else {
		o<<"No source\n";
	}

	o<<"Dump complete\n\n";
}

Graph* CFunction::createGraph() {
	cout<<"dim_in = "<<dimension<<"\n";
	return new Graph(dimension, space_min, space_max, grid);
}

STDMETHODIMP CFunction::getFunction(void** func) {
	if (func != NULL) {
		*func = this->function;
	}

	return S_OK;
}

STDMETHODIMP CFunction::createGraph(void** graph) {
	if (graph != NULL) {
		*((Graph**)graph) = createGraph();
	}
	return S_OK;
}

STDMETHODIMP CFunction::getSystemFunction(void** function) {
    *function = (void*)systemFunction;
    return S_OK;
}

STDMETHODIMP CFunction::getSystemFunctionDerivate(void** function) {
    *function = (void*)systemFunctionDerivate;
    return S_OK;
}

STDMETHODIMP CFunction::getProjectiveExtensionInfo(void** info) {
    *info = (void*) projectiveExtensionInfo;
    return S_OK;
}
