// ProjectiveBundleGraph.cpp : Implementation of CProjectiveBundleGraph

#include "stdafx.h"
#include "ProjectiveBundleGraph.h"
#include "../graph_simplex/romfunction2n.h"
#include "../systemfunction/IMorseFunction.h"

// CProjectiveBundleGraph


CProjectiveBundleGraph::CProjectiveBundleGraph() {
	graph = NULL;
	kernel = NULL;
}

HRESULT CProjectiveBundleGraph::FinalConstruct() {

	TRACE_CREATE(CProjectiveBundleGraph);

	return S_OK;
}


void CProjectiveBundleGraph::FinalRelease() {
	SAFE_RELEASE(kernel);
	SAFE_DELETE(graph);

	TRACE_DESTRUCT(CProjectiveBundleGraph);
}


STDMETHODIMP CProjectiveBundleGraph::setGraph(void* graph) {
	if (graph != NULL) {
		SAFE_DELETE(this->graph);
		this->graph = (Graph*)graph;
	}
	
	return S_OK;
}

STDMETHODIMP CProjectiveBundleGraph::getGraph(void** graph) {
	if (graph != NULL) {

		*(Graph**)graph = this->graph;
	}
	
	return S_OK;
}


STDMETHODIMP CProjectiveBundleGraph::get_kernel(IKernelPointer** pVal)
{
	if (kernel != NULL) {
		kernel->QueryInterface(pVal);
	}
	return S_OK;
}

STDMETHODIMP CProjectiveBundleGraph::putref_kernel(IKernelPointer* newVal)
{
	SAFE_RELEASE(kernel);

	newVal->QueryInterface(&kernel);

    ATLASSERT(kernel != NULL);

	return S_OK;
}


STDMETHODIMP CProjectiveBundleGraph::Subdevide(ISubdevideParams* params) {
	int dim = graph->getDimention();
	JInt* factor = new JInt[dim];

	for (int i=0; i<dim; i++) {
		params->getCellDevider(i, &factor[i]);
	}

	IFunction* function = NULL;
	kernel->get_Function(&function);
	
	ATLVERIFY(function != NULL);

	Function* func = NULL;
	function->getFunction((void**)&func);

	GraphComponents* cms = NULL;
	try {
		cms = Computator().performMS(graph, func, factor);
	} catch (GraphException) {
		//__raise noImplementation();
		SAFE_RELEASE(function);
		delete[] factor;
		return S_OK;
	}

	for (int i=0;i<cms->length(); i++) {
		IProjectiveBundleGraph* im;
		CProjectiveBundleGraph::CreateInstance(&im);

		im->putref_kernel(kernel);
		Graph* gr = cms->getAt(i);
		im->setGraph((void*)gr);
		//__raise newChildProjectiveBundle(im);
		//__raise newKernelNode(im);
	}

	if (cms->length() == 0) {
		//__raise noChilds();
	}

	SAFE_RELEASE(function);
	delete[] factor;
	delete cms;

	return S_OK;
}

STDMETHODIMP CProjectiveBundleGraph::SubdevidePoint(ISubdevidePointParams* params) {
	int dim = graph->getDimention();
	JInt* factor = new JInt[dim];
	JInt* ks = new JInt[dim];

	for (int i=0; i<dim; i++) {
		params->getCellDevider(i, &factor[i]);
		params->getCellPoints(i, &ks[i]);
	}

	IFunction* function = NULL;
	kernel->get_Function(&function);

    ISystemFunctionDerivate* func = NULL;
	function->getSystemFunctionDerivate((void**)&func);

    SermentProjectiveExtensionInfo info(func);

    ISystemFunctionDerivate* dfunc = info.systemFunction();

    MSPointBuilder* msb = new MSPointBuilder(this->graph, factor, ks, dfunc);
    msb->start();

    msb->processNextGraph(graph);

    Graph* result = msb->result();

    delete msb;
    delete dfunc;

    IComputationGraphResultExt* cresult;
    CComputationGraphResult::CreateInstance(&cresult);

    cresult->setRootGraph((void**)&result);
	cresult->setGraphNode(this);

    kernel->EventNewComputationResult(this, cresult);
  	

	SAFE_RELEASE(function);
	delete[] factor;
	delete[] ks;

	return S_OK;
}


STDMETHODIMP CProjectiveBundleGraph::Morse() {
	IMorseSpectrum* ms;
	CMorseSpectrum::CreateInstance(&ms);

	IFunction* function = NULL;		
	kernel->get_Function(&function);

    ISystemFunctionDerivate* func = NULL;
    function->getSystemFunctionDerivate((void**)&func);

    SermentProjectiveExtensionInfo info(func);
    IMorseFunction* mfunc = info.morseFunction();

    CRomFunction2N rom(mfunc, graph);

    rom.minimize();

    ms->put_lowerBound(rom.getAnswer());	
    ms->put_lowerLength(rom.getAnswerLength());

    rom.maximize();

    ms->put_upperBound(rom.getAnswer());
    ms->put_upperLength(rom.getAnswerLength());

    delete mfunc;

    kernel->EventNewNode(this, ms);

    SAFE_RELEASE(function);	
	return S_OK;
}

STDMETHODIMP CProjectiveBundleGraph::graphInfo(IGraphInfo** info) {
	IGraphInfo* inf = NULL;
	CGraphInfo::CreateInstance(&inf);

	inf->setGraph((void**)(&graph));

	*info = inf;

	return S_OK;
}

STDMETHODIMP CProjectiveBundleGraph::graphDimension(int* value) {
	*value = graph->getDimention();
	return S_OK;
}

STDMETHODIMP CProjectiveBundleGraph::ExportData(BSTR fileName) {
	return SaveGraphToFile(graph, CString(fileName));
}


STDMETHODIMP CProjectiveBundleGraph::acceptChilds(void** graphComponents) {
    GraphComponents* cms = *(GraphComponents**)graphComponents;

    for (int i=0;i<cms->length(); i++) {
		IProjectiveBundleGraph* im;
		CProjectiveBundleGraph::CreateInstance(&im);

		im->putref_kernel(kernel);
		Graph* gr = cms->getAt(i);
		im->setGraph((void*)gr);
        kernel->EventNewNode(this, im);
	}

	if (cms->length() == 0) {
        kernel->EventNoChilds(this);
	}

    return S_OK;
}