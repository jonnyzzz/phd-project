
// SymbolicImageGraph.cpp : Implementation of CSymbolicImageGraph

#include "stdafx.h"
#include "SymbolicImageGraph.h"
#include "Kernel.h"
#include "function.h"
#include "KernelException.h"
#include "ProjectiveBundle.h"
#include "ProjectiveBundleGraph.h"
#include "ComputationGraphResult.h"
#include "../Homotop/IsolatingSet.h"
#include "../cellimagebuilders/ProgressBarInfo.h"

// CSymbolicImageGraph


CSymbolicImageGraph::CSymbolicImageGraph() {
	this->graph = NULL;
	this->kernel = NULL;	
}

HRESULT CSymbolicImageGraph::FinalConstruct() {

	TRACE_CREATE(CSymbolicImageGraph);

	return S_OK;
}

void CSymbolicImageGraph::FinalRelease() {
	SAFE_DELETE(graph);
	SAFE_RELEASE(kernel);

	TRACE_DESTRUCT(CSymbolicImageGraph);
}


//////////////////////////////////////////////////////////////////////////////////////
//ISubdevideable

STDMETHODIMP CSymbolicImageGraph::Subdevide(ISubdevideParams* params) {
	ProgressBarInfo* pinfo = CreateProgressBarInfo(params);

	int dim = graph->getDimention();
	JInt* factor = new JInt[dim];
	for (int i=0; i<dim; i++) {
		params->getCellDevider(i, &factor[i]);
	}

	IFunction* function = NULL;	
	kernel->get_Function(&function);

	Function* func;
	function->getFunction((void**)&func);

	SIComputationProcess* cs = new SIComputationProcess(func, graph, factor, pinfo);
	
	cs->nextStep(graph);

	Graph* result = cs->getComputationResult();

	delete cs;

	IComputationGraphResultExt* res;
	CComputationGraphResult::CreateInstance(&res);

	res->setRootGraph((void**)&result);
	res->setGraphNode(this);

    kernel->EventNewComputationResult(this, res);

	delete[] factor;
	SAFE_RELEASE(function);
	
	delete pinfo;

	return S_OK;
}

//////////////////////////////////////////////////////////////////////////////////////
//ISubdevidablePoint

STDMETHODIMP CSymbolicImageGraph::SubdevidePoint(ISubdevidePointParams* params) {
	ProgressBarInfo* pinfo = CreateProgressBarInfo(params);

	int dim = graph->getDimention();
	JInt* factor = new JInt[dim];
	JInt* ks = new JInt[dim];
	for (int i=0; i<dim; i++) {
		params->getCellDevider(i, &factor[i]);
		params->getCellPoints(i, &ks[i]);
	}

	IFunction* function = NULL;	
	kernel->get_Function(&function);

	SystemFunction* func;
	function->getSystemFunction((void**)&func);

	SIPointBuilder* pbs = new SIPointBuilder(graph, factor, ks, func, pinfo);
	pbs->start();

	pbs->processNextGraph(graph);
	Graph* result = pbs->result();
	delete pbs;

	IComputationGraphResultExt* res;
	CComputationGraphResult::CreateInstance(&res);

	res->setRootGraph((void**)&result);
	res->setGraphNode(this);
    
	delete[] factor;
	delete[] ks;
	SAFE_RELEASE(function);	

	kernel->EventNewComputationResult(this, res);

    res->Release();
	delete pinfo;

	return S_OK;
}

//////////////////////////////////////////////////////////////////////////////////
//IExtendible


STDMETHODIMP CSymbolicImageGraph::Extend() {
    this->AddRef();
    kernel->EventNewComputationResult(this, this);

    return S_OK;
}

///////////////////////////////////////////////////////////////////////////////////
//IComputationExtendingResult

STDMETHODIMP CSymbolicImageGraph::PointMethodProjectiveExtensionDimension(int* value) {

    IFunction* function;
    kernel->get_Function(&function);

    ISystemFunctionDerivate* dfunc;
    function->getSystemFunctionDerivate((void**)&dfunc);
    
	SermentProjectiveExtensionInfo info(dfunc);
    
    *value = info.extendedGraphDimension();

    SAFE_RELEASE(function);

	return S_OK;
}

STDMETHODIMP CSymbolicImageGraph::PointMethodProjectiveExtension(IExtendablePointParams* params) {
	ProgressBarInfo* pinfo = CreateProgressBarInfo(params);

	int dim;
    this->PointMethodProjectiveExtensionDimension(&dim);

    cout<<"Dimension = "<<dim <<"\n";

	
    cout<<"Dumping factor\n";
	JInt* factor = new JInt[dim];
	for (int i = 0; i<dim; i++) {
		params->getCellDevider(i, &factor[i]);
        cout<<factor[i]<<", ";
	}
    cout<<"\n";

    IFunction* function;
    kernel->get_Function(&function);
    ISystemFunctionDerivate* dfunc;
    function->getSystemFunctionDerivate((void**)&dfunc);


    SermentProjectiveExtensionInfo info(dfunc);

    cout<<"Segment info complete \n";

    AbstractProcess* proc = info.graphExtender(graph, factor, pinfo);
    proc->start();
    proc->processNextGraph(this->graph);

    Graph* result = proc->result();

    delete proc;
		
	IProjectiveBundleGraph* im;
	CProjectiveBundleGraph::CreateInstance(&im);
    
	im->putref_kernel(kernel);
	im->setGraph((void*)result);			

    cout<<" before Event \n";
    kernel->EventNewNode(this, im);
    cout<<" after event \n";

	delete[] factor;
	delete pinfo;

    SAFE_RELEASE(function);

	return S_OK;
}

//////////////////////////////////////////////////////////////////////////////
//IGraph

STDMETHODIMP CSymbolicImageGraph::setGraph(void* graph) {
	if (graph != NULL) {
		SAFE_DELETE(this->graph);
		this->graph = (Graph*)graph;
		
	}
	
	return S_OK;
}

STDMETHODIMP CSymbolicImageGraph::getGraph(void** graph) {
	if (graph != NULL) {
		*(Graph**)graph = this->graph;
	}

	return S_OK;
}

STDMETHODIMP CSymbolicImageGraph::graphInfo(IGraphInfo** info) {
	IGraphInfo* inf = NULL;
	CGraphInfo::CreateInstance(&inf);

	inf->setGraph((void**)(&graph));

	*info = inf;

	return S_OK;
}

STDMETHODIMP CSymbolicImageGraph::graphDimension(int* value) {
	*value = graph->getDimention();
	return S_OK;
}

STDMETHODIMP CSymbolicImageGraph::acceptChilds(void ** data) {
	GraphComponents *cms = *(GraphComponents**)data;

	cout<<"\n------>Accept childs\n";

	for (int i=0; i<cms->length(); i++) {
		ISymbolicImageGraph* ret;
		CSymbolicImageGraph::CreateInstance(&ret);

		ATLASSERT(ret != NULL);

		ret->putref_kernel(this->kernel);
		Graph* graph = cms->getAt(i);
		ret->setGraph((void*)graph);	

        kernel->EventNewNode(this, ret);
	}

	if (cms->length() == 0) {
        kernel->EventNoChilds(this);        
	}
	
	cout<<cms->length()<<" nodes was added \n";

	delete cms;

	return S_OK;
}

///////////////////////////////////////////////////////////////////////////////
//IKernelNode

STDMETHODIMP CSymbolicImageGraph::get_kernel(IKernelPointer** pVal)
{
	kernel->QueryInterface(pVal);
	
	ATLASSERT(pVal != NULL);

	return S_OK;
}

STDMETHODIMP CSymbolicImageGraph::putref_kernel(IKernelPointer* newVal)
{
	SAFE_RELEASE(kernel);

	newVal->QueryInterface(&kernel);

	ATLASSERT(kernel != NULL);

	return S_OK;
}

//////////////////////////////////////////////////////////////////////////////////
//IExportable


STDMETHODIMP CSymbolicImageGraph::ExportData(BSTR file) {
	return SaveGraphToFile(graph, CString(file));	

}

//////////////////////////////////////////////////////////////////////////////////
// IHomotopFind

STDMETHODIMP CSymbolicImageGraph::Homotop(IHomotopParams* params) {
	ProgressBarInfo* pinfo = CreateProgressBarInfo(params);

	int dim = graph->getDimention();
	JInt* array = new JInt[dim];
	for (int i=0; i<dim; i++) {
		double d;
		params->getCoordinateAt(i, &d);
		array[i] = graph->toInternal(d, i);
	}

	Node* node = graph->findNode(array);

	if (node == NULL) {
		VARIANT_BOOL b;
		params->notifyNodeNotFound(&b);
		if (b) return Homotop(params);

		return S_OK;
	} else {
		
		IsolatingSetProcess* process = new IsolatingSetProcess(graph, node, pinfo);
		process->start();
		process->processNextGraph(graph);

		Graph* result = process->result();
		
		GraphComponents* cms = new GraphComponents();
		cms->addGraphAsComponent(result);

		this->acceptChilds((void**)&cms);

		return S_OK;
	}

	delete pinfo;
}