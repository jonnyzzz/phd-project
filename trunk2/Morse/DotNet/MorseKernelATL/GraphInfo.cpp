// GraphInfo.cpp : Implementation of CGraphInfo

#include "stdafx.h"
#include "GraphInfo.h"


// CGraphInfo

HRESULT CGraphInfo::FinalConstruct() {
	gcms = NULL;

	TRACE_CREATE(CGraphInfo);

	return S_OK;
}

void CGraphInfo::FinalRelease() {
	SAFE_DELETE(gcms);

	TRACE_DESTRUCT(CGraphInfo)
}


void CGraphInfo::initDimension() {
	dim = gcms->getAt(0)->getDimention();
//	cout<<"dim_b = "<<dim<<"\n";
	for (int i=1; i<gcms->length(); i++) {
		if (gcms->getAt(i)->getDimention() != dim) {
			dim = -1;
//			cout<<"Break\n";
			break;
		}		
	}

//	cout<<"dim :"<<dim<<"\n";
}

bool CGraphInfo::verify(LONG dim) {
	if (gcms == NULL) return false;
	
	return (dim >=0 && dim < this->dim);
}

STDMETHODIMP CGraphInfo::dimension(LONG* dimension) {
	if (gcms!= NULL) {
		*dimension = this->dim;
	} else {
		*dimension = -1;
	}
	return S_OK;
}


STDMETHODIMP CGraphInfo::gridNumber(LONG id, LONG* grid) {
	if (verify(id)) {
		*grid = gcms->getAt(0)->getGrid()[id];		
	} else {
		*grid = 0;
	}
	return S_OK;
}

STDMETHODIMP CGraphInfo::gridSize(LONG id, DOUBLE* grid) {
	if (verify(id)) {
		*grid = gcms->getAt(0)->getEps()[id];
	} else {
		*grid = 0;
	}
	return S_OK;
}


STDMETHODIMP CGraphInfo::spaceMin(LONG id, DOUBLE* grid) {
	if (verify(id)) {
		*grid = gcms->getAt(0)->getMin()[id];
	} else {
		*grid = 0;
	}
	return S_OK;
}


STDMETHODIMP CGraphInfo::spaceMax(LONG id, DOUBLE* grid) {
	if (verify(id)) {
		*grid = gcms->getAt(0)->getMax()[id];
	} else {
		*grid = 0;
	}
	return S_OK;
}

STDMETHODIMP CGraphInfo::edges(LONG* num) {
	if (gcms != NULL) {
		*num = 0;
		for (int i=0; i<gcms->length(); i++) {
			*num += gcms->getAt(i)->getNumberOfArcs();
		}
	} else {
		*num = 0;
	}
	return S_OK;
}

STDMETHODIMP CGraphInfo::nodes(LONG* num) {
	if (gcms  != NULL) {
		*num = 0;
		for (int i =0; i<gcms->length(); i++) {
			*num += gcms->getAt(i)->getNumberOfNodes();
		}
	} else {
		*num = 0;
	}
	return S_OK;
}

STDMETHODIMP CGraphInfo::setGraph(void** graph) {
	GraphComponents* cms = new GraphComponents();
	cms->addGraphAsComponent(*(Graph**)graph);	
	HRESULT hr = setGraphComponents((void**)&cms);
	return hr;
}

STDMETHODIMP CGraphInfo::setGraphComponents(void** gcms) {
//	cout<<"StartGC\n";
	if (gcms != NULL && *gcms != NULL) {
		SAFE_DELETE(this->gcms);
		this->gcms = *(GraphComponents**)gcms;
//		cout<<"initGC\n";

//		cout<<"length = "<<this->gcms->length()<<"\n";
		initDimension();
	}
//	cout<<"setGC comlete\n";
	return S_OK;
}