// SymbolicImageGroup.cpp : Implementation of CSymbolicImageGroup

#include "stdafx.h"
#include "SymbolicImageGroup.h"
#include ".\Kernel.h"
#include ".\function.h"
#include ".\KernelException.h"
#include ".\ProjectiveBundle.h"
#include ".\ProjectiveBundleGraph.h"
#include ".\allBackProgressBarInfo.h"
#include ".\ComputationGraphResult.h"


CSymbolicImageGroup::CSymbolicImageGroup() {
	this->kernel = NULL;	
}


HRESULT CSymbolicImageGroup::FinalConstruct() {

	TRACE_CREATE(CSymbolicImageGroup);

	return S_OK;
}

void CSymbolicImageGroup::FinalRelease() {
	SAFE_RELEASE(kernel);
	for (ISymbolicImageListIterator it = nodeList.begin(); it != nodeList.end(); it++) {
		(*it)->Release();
	}

	TRACE_DESTRUCT(CSymbolicImageGroup);
}


//IGroupNode

STDMETHODIMP CSymbolicImageGroup::addNode(ISymbolicImageGraph* im) {
	im->AddRef();
	nodeList.push_back(im);
   
	if (kernel == NULL) {		
        IKernelPointer* ukernel;
		im->get_kernel(&ukernel);
		putref_kernel(ukernel);
        ukernel->Release();
	}
	return S_OK;
}

STDMETHODIMP CSymbolicImageGroup::removeNode(ISymbolicImageGraph* im) {
	im->Release(); //addRef from addNode method
	nodeList.remove(im);
	return S_OK;
}

STDMETHODIMP CSymbolicImageGroup::nodeCount(int* val) {
	*val = (int)nodeList.size();
	return S_OK;
}

STDMETHODIMP CSymbolicImageGroup::getNode(int index, IKernelNode** node) {
	ISymbolicImageListIterator it = nodeList.begin();
	while (index-- > 0) it++;
	if (it == nodeList.end()) return E_FAIL;

	*node = *it;
	return S_OK;
}

///////////////////////////////////////////////////////////////////////////////////////////
//IKernelNode

STDMETHODIMP CSymbolicImageGroup::get_kernel(IKernelPointer** pVal)
{
	kernel->QueryInterface(pVal);
	return S_OK;
}

STDMETHODIMP CSymbolicImageGroup::putref_kernel(IKernelPointer* newVal)
{
	SAFE_RELEASE(kernel);
	newVal->QueryInterface(&kernel);
    
    ATLASSERT(kernel != NULL);

	return S_OK;
}

///////////////////////////////////////////////////////////////////////////////////////////
//IComputationExtendingResult

STDMETHODIMP CSymbolicImageGroup::PointMethodProjectiveExtensionDimension(int* value) {
	int val;
	this->graphDimension(&val);
	*value = val*2;
	return S_OK;
}

STDMETHODIMP CSymbolicImageGroup::PointMethodProjectiveExtension(IExtendablePointParams* params) {

  	CallBackProgressBarInfo* pinfo = new CallBackProgressBarInfo(params);
	pinfo->start();

	int dim;
    this->PointMethodProjectiveExtensionDimension(&dim);

    GraphComponents* cms = createGraphComponents();    
    
    ATLASSERT(cms->length() > 0);

    Graph* graph = cms->getAt(0);
    
	
	JInt* factor = new JInt[dim];
	for (int i = 0; i<dim; i++) {
		params->getCellDevider(i, &factor[i]);
	}

    IFunction* function;
    kernel->get_Function(&function);
    ISystemFunctionDerivate* dfunc;
    function->getSystemFunctionDerivate((void**)&dfunc);

    SermentProjectiveExtensionInfo info(dfunc);

    AbstractProcess* proc = info.graphExtender(graph, factor, pinfo);
    proc->start();
    for (int i=0; i<cms->length(); i++) {
        proc->processNextGraph(cms->getAt(i));
    }

    Graph* result = proc->result();

    delete proc;
		
	IProjectiveBundleGraph* im;
	CProjectiveBundleGraph::CreateInstance(&im);
    
	im->putref_kernel(kernel);
	im->setGraph((void*)result);			

    kernel->EventNewNode(this, im);

	delete[] factor;
    delete cms;
    pinfo->finish();
    delete pinfo;

    SAFE_RELEASE(function);

	return S_OK;
}

STDMETHODIMP CSymbolicImageGroup::Extend() {
    this->AddRef();
    kernel->EventNewComputationResult(this, this);

    return S_OK;
}



STDMETHODIMP CSymbolicImageGroup::Subdevide(ISubdevideParams* params) {
	CallBackProgressBarInfo* pinfo = new CallBackProgressBarInfo(params);
	pinfo->start();

	IFunction* function;
	kernel->get_Function(&function);

	Function* func;
	function->getFunction((void**)&func);

	GraphComponents* cmst = createGraphComponents();

	if (cmst->length() == 0) {
        kernel->EventNoChilds(this);
		delete cmst;
		return S_OK;
	}

	int dim = cmst->getAt(0)->getDimention();
	
	JInt* factor = new JInt[dim];
	
	for (int i=0; i<dim; i++) {
		params->getCellDevider(i, &factor[i]);
	}

	SIComputationProcess* cs = new SIComputationProcess(func, cmst->getAt(0), factor);

	for (int i=0; i<cmst->length(); i++) {
		cs->nextStep(cmst->getAt(i));
	}

	Graph* result = cs->getComputationResult();

	delete cs;

	IComputationGraphResultExt *ret;
	CComputationGraphResult::CreateInstance(&ret);

	ret->setRootGraph((void**)&result);
	ret->setGraphNode(this);

	delete cmst;
	SAFE_RELEASE(function);
	delete[] factor;

    kernel->EventNewComputationResult(this, ret);

	pinfo->finish();
	delete pinfo;

	return S_OK;
}


STDMETHODIMP CSymbolicImageGroup::SubdevidePoint(ISubdevidePointParams* params) {
	CallBackProgressBarInfo* pinfo = new CallBackProgressBarInfo(params);
	pinfo->start();

	IFunction* function;
	kernel->get_Function(&function);

    ISystemFunction* func;
    function->getSystemFunction((void**)&func);
   
	GraphComponents* cmst = createGraphComponents();

	if (cmst->length() == 0) {
        kernel->EventNoChilds(this);
		delete cmst;
		return S_OK;
	}

	int dim = cmst->getAt(0)->getDimention();

	JInt* factor = new JInt[dim];
	JInt* ks = new JInt[dim];

	for (int i=0; i<dim; i++) {
		params->getCellDevider(i, &factor[i]);
		params->getCellPoints(i, &ks[i]);
	}

	SIPointBuilder* sbp = new SIPointBuilder(cmst->getAt(0), factor, ks, func, pinfo);
	sbp->start();
	for (int i=0; i<cmst->length(); i++) {		
		sbp->processNextGraph(cmst->getAt(i));
	}

	Graph* result = sbp->result();
	delete sbp;

	IComputationGraphResultExt *ret;
	CComputationGraphResult::CreateInstance(&ret);

	ret->setRootGraph((void**)&result);
	ret->setGraphNode(this);

	SAFE_RELEASE(function);
	delete[] factor;
	delete[] ks;
	delete cmst;

    kernel->EventNewComputationResult(this, ret);

	pinfo->finish();
	delete pinfo;

	return S_OK;
}

STDMETHODIMP CSymbolicImageGroup::acceptChilds(void** data) {
	GraphComponents* cms = *(GraphComponents**) data;
	
	cout<<"Accept childs\n";

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

STDMETHODIMP CSymbolicImageGroup::graphInfo(IGraphInfo** info) {
	IGraphInfo* pinfo;
	CGraphInfo::CreateInstance(&pinfo);

	GraphComponents* cms = createGraphComponents();
	pinfo->setGraphComponents((void**)&cms);

	*info = pinfo;

	return S_OK;
}

STDMETHODIMP CSymbolicImageGroup::graphDimension(int* val) {
	GraphComponents* cms = createGraphComponents();
	if (cms->length() == 0) {
		*val = 0;
	} else {
		*val = cms->getAt(0)->getDimention();
	}
	delete cms;
	return S_OK;
}

STDMETHODIMP CSymbolicImageGroup::ExportData(BSTR fileName) {
	GraphComponents* cms = createGraphComponents();
	HRESULT hr = SaveGraphToFile(cms, CString(fileName));
	delete cms;
	return hr;
}

/////////////////////////////////////////////////////////////////////////////////////////////
// Internal

GraphComponents* CSymbolicImageGroup::createGraphComponents() {
	GraphComponents* cms = new GraphComponents();

	for (ISymbolicImageListIterator it = nodeList.begin(); it != nodeList.end(); it++) {
		Graph* graph;
		(*it)->getGraph((void**)&graph);
		cms->addGraphAsComponent(graph);
	}

	return cms;
}
