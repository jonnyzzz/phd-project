// ProjectiveBundleGroup.cpp : Implementation of CProjectiveBundleGroup

#include "stdafx.h"
#include "ProjectiveBundleGroup.h"
#include "ProjectiveBundleGraph.h"
#include "../cellimagebuilders/AbstractProcessExt.h"

// CProjectiveBundleGroup

CProjectiveBundleGroup::CProjectiveBundleGroup() {
	kernel = NULL;
}

HRESULT CProjectiveBundleGroup::FinalConstruct() {

	TRACE_CREATE(CProjectiveBundleGroup);

	return S_OK;
}

IProjectiveExtensionInfo* CProjectiveBundleGroup::getProjectiveExtensionInfo() {
	IFunction* function;
	kernel->get_Function(&function);
	ATLASSERT(function != NULL);

	ISystemFunctionDerivate* dfunc;
	function->getSystemFunctionDerivate((void**)&dfunc);

	function->Release();

	return new SermentProjectiveExtensionInfo(dfunc);
}

void CProjectiveBundleGroup::FinalRelease() {
	SAFE_RELEASE(kernel);
	for (ListProjectiveBundleIterator it = nodeList.begin(); it != nodeList.end(); it++) {
		(*it)->Release();
	}

	TRACE_DESTRUCT(CProjectiveBundleGroup)
}


STDMETHODIMP CProjectiveBundleGroup::addNode(IProjectiveBundleGraph* graph) {
	//graph->AddRef();
	nodeList.push_back(graph);

	if (kernel == NULL) {
		IKernelPointer* krnl;
		graph->get_kernel(&krnl);
		putref_kernel(krnl);
        krnl->Release();
	}
	return S_OK;
}

STDMETHODIMP CProjectiveBundleGroup::removeNode(IProjectiveBundleGraph* gr) {
	nodeList.remove(gr);
	return S_OK;
}

STDMETHODIMP CProjectiveBundleGroup::nodeCount(int *val) {
	*val = (int)nodeList.size();
	return S_OK;
}

STDMETHODIMP CProjectiveBundleGroup::getNode(int index, IKernelNode** node) {
	ListProjectiveBundleIterator it = nodeList.begin();
	while (index-- > 0) it++;
	if (it == nodeList.end()) return E_FAIL;
	*node = *it;
	return S_OK;
}

STDMETHODIMP CProjectiveBundleGroup::get_kernel(IKernelPointer** pVal)
{
    ATLASSERT(kernel != NULL);
	kernel->QueryInterface(pVal);
	return S_OK;
}

STDMETHODIMP CProjectiveBundleGroup::putref_kernel(IKernelPointer* newVal)
{
	SAFE_RELEASE(kernel);

	newVal->QueryInterface(&kernel);

    ATLASSERT(kernel != NULL);
	return S_OK;
}


GraphComponents* CProjectiveBundleGroup::createGraphComponents() {
	GraphComponents* cms = new GraphComponents();
	for (ListProjectiveBundleIterator it = nodeList.begin(); it != nodeList.end(); it++) {
		Graph* graph;
		(*it)->getGraph((void**)&graph);
		cms->addGraphAsComponent(graph);
	}
	return cms;
}

STDMETHODIMP CProjectiveBundleGroup::SubdevidePoint(ISubdevidePointParams* params) {
	ProgressBarInfo* pinfo = CreateProgressBarInfo(params);
    GraphComponents* cms = createGraphComponents();
    ATLASSERT(cms->length() > 0);

    Graph* graph = cms->getAt(0);

	int dim = graph->getDimention();
	JInt* factor = new JInt[dim];
	JInt* ks = new JInt[dim];
	JDouble* offset1 = new JDouble[dim];
	JDouble* offset2 = new JDouble[dim];

	for (int i=0; i<dim; i++) {
		params->getCellDevider(i, &factor[i]);
		params->getCellPoints(i, &ks[i]);
		params->getOverlaping1(i, &offset1[i]);
		params->getOverlaping2(i, &offset2[i]);
	}

	IProjectiveExtensionInfo* info = getProjectiveExtensionInfo();
	AbstractProcessExt* msb = (AbstractProcessExt*)info->nextStepProcess(graph, factor, ks, offset1, offset2, pinfo );
    msb->start();

    for (int i=0; i<cms->length(); i++) {
        msb->processNextGraph(cms->getAt(i));
    }

    Graph* result = msb->result();

    delete msb;
	delete info;

    IComputationGraphResultExt* cresult;
    CComputationGraphResult::CreateInstance(&cresult);

    cresult->setRootGraph((void**)&result);
	cresult->setGraphNode(this);

    kernel->EventNewComputationResult(this, cresult);
 	
	delete[] factor;
	delete[] ks;
	delete[] offset1;
	delete[] offset2;		
    delete cms;

	delete pinfo;

    return S_OK;
}

STDMETHODIMP CProjectiveBundleGroup::graphInfo(IGraphInfo** info) {
	
	IGraphInfo* inf = NULL;
	CGraphInfo::CreateInstance(&inf);

	GraphComponents* cms = createGraphComponents();
	inf->setGraphComponents((void**)&cms);
	*info = inf;
	
	return S_OK;
}

STDMETHODIMP CProjectiveBundleGroup::graphDimension(int* value) {
	GraphComponents* cms = createGraphComponents();
	if (cms->length() == 0) {
		*value = 0;
	} else {
		*value = cms->getAt(0)->getDimention();
	}
	delete cms;
	return S_OK;
}

STDMETHODIMP CProjectiveBundleGroup::ExportData(BSTR fileName) {
	GraphComponents* cms = createGraphComponents();
	HRESULT hr = SaveGraphToFile(cms, CString(fileName));
	delete cms;
	return hr;
}


STDMETHODIMP CProjectiveBundleGroup::acceptChilds(void** graphComponents) {
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