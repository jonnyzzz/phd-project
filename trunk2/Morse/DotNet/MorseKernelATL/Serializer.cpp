// Serializer.cpp : Implementation of CSerializer

#include "stdafx.h"
#include "Serializer.h"
#include "../graph/graph.h"



const int SIGRAPH_CODE = 1;
const int SIGROUP_CODE = 2;
const int PBGRAPH_CODE = 3;
const int PBGROUP_CODE = 4;
const int MORSE_CODE = 5;

#define TEST_OR_RET(x) {if (x) return S_OK;}
// CSerializer

HRESULT CSerializer::FinalConstruct() {
	return S_OK;
}

void CSerializer::FinalRelease() {

}

STDMETHODIMP CSerializer::SupportSerialization(IKernelNode* node, VARIANT_BOOL* result) {
	*result = TRUE;
	return S_OK;
}


STDMETHODIMP CSerializer::LoadKernelNode(ISerializerInputData* data, IKernel* kernel, IKernelNode** node) {
	BSTR fileName;
	data->FileName(&fileName);
	CString file(fileName);
	FileInputStream fi(file);
	int code;
	fi>>code;

	switch (code) {
		case SIGRAPH_CODE:
			*node = LoadGraph<ISymbolicImageGraph, CSymbolicImageGraph>(fi);
			break;
		case SIGROUP_CODE:
			*node = LoadGroup<ISymbolicImageGroup, ISymbolicImageGraph, CSymbolicImageGroup>(fi, data);
			break;
		case PBGRAPH_CODE:
			*node = LoadGraph<IProjectiveBundleGraph, CProjectiveBundleGraph>(fi);
			break;
		case PBGROUP_CODE:
			*node = LoadGroup<IProjectiveBundleGroup, IProjectiveBundleGraph, CProjectiveBundleGroup>(fi, data);
			break;
		case MORSE_CODE:
			*node = LoadMorseSpectrum(fi);
			break;
		default:
			*node = NULL;
			break;
	} 
	if (*node != NULL) {
		(*node)->putref_kernel(kernel);
		return S_OK;
	} else {
		return E_FAIL;
	}
}

STDMETHODIMP CSerializer::SaveKernelNode(ISerializerOutputData* data, IKernelNode* anode) {
	BSTR fileName;
	data->FileName(&fileName);
	CString file(fileName);
	FileOutputStream fo(file);

	if (testAndSaveGraph<ISymbolicImageGraph, SIGRAPH_CODE>(anode, fo)) {
		return S_OK;
	}

	if (testAndSaveGraph<IProjectiveBundleGraph, PBGRAPH_CODE>(anode, fo)) {
		return S_OK;
	}

	if (testAndSaveGroup<ISymbolicImageGroup, SIGROUP_CODE>(anode, fo, data)) {
		return S_OK;
	}

	if (testAndSaveGroup<IProjectiveBundleGroup, PBGROUP_CODE>(anode, fo, data)) {
		return S_OK;
	}

	IMorseSpectrum* morse;
	anode->QueryInterface(&morse);
	if (morse != NULL) {
		fo<<MORSE_CODE;
		fo.stress();
		SaveMorseSpectrum(morse, fo);
		morse->Release();
		return S_OK;
	}
	return E_FAIL;
}


void CSerializer::SaveGraph(FileOutputStream& fo, Graph* graph) {
	saveGraph(fo, graph);
}

Graph* CSerializer::LoadGraph(FileInputStream& fi) {	
	return createGraph(fi);
}

/////////////////////////////////////////////////////////////////////////////////
// Graph


template <typename IGraph>
void CSerializer::SaveGraph(IGraph* node, FileOutputStream& fo) {

	Graph* graph;
	node->getGraph((void**)&graph);

	this->SaveGraph(fo, graph);
}

template <typename IGraph, typename CGraph>
IKernelNode* CSerializer::LoadGraph(FileInputStream& fi) {
	IGraph* node;
	CGraph::CreateInstance(&node);

	ATLASSERT(node != NULL);
	
	Graph* graph = LoadGraph(fi);

	node->setGraph((void*)graph);

	IKernelNode* ret;
	node->QueryInterface(&ret);

	node->Release();

	ATLASSERT(ret != NULL);

	return ret;
}

/////////////////////////////////////////////////////////////////////////////////
// Group

template <typename IGroup>
void CSerializer::SaveGroup(IGroup* groupnode, FileOutputStream& fo, ISerializerOutputData* data) {
	IGroupNode* group;
	groupnode->QueryInterface(&group);

	ATLASSERT(group != NULL);

	int length;
	group->nodeCount(&length);

	fo<<length;
	fo.stress();

	for (int i=0; i<length; i++) {
		IKernelNode* node;
		group->getNode(i, &node);
		int id;
		data->SaveWithID(node, &id);

		fo<<id;
	}
}

template <typename IGroup, typename IGraph, typename CGroup>
IKernelNode* CSerializer::LoadGroup(FileInputStream& fi, ISerializerInputData* data) {
	int length;
	fi>>length;

	IGroup* group;
	CGroup::CreateInstance(&group);

	ATLASSERT(group != NULL);

	for (int i=0;i<length;i++) {
		IKernelNode* node;
		int id;
		fi>>id;
		data->LoadByID(id, &node);
		IGraph* img;
		node->QueryInterface(&img);
		ATLASSERT(img != NULL);

		group->addNode(img);
		img->Release();
		node->Release();
	}

	IKernelNode* ret;
	group->QueryInterface(&ret);
	group->Release();
	return ret;
}

/////////////////////////////////////////////////////////////////////////////////////
// IMorseSpectrum


const char MORSE_BEGIN[] = "<MorseSpectrum>";
const char MORSE_END[]   = "</MorseSpectrum>"; 

void CSerializer::SaveMorseSpectrum(IMorseSpectrum* node, FileOutputStream& fo) {
	
	fo<<MORSE_BEGIN;
	fo.stress();

	DOUBLE bound;
	node->get_lowerBound(&bound);
	fo<<bound;

	node->get_upperBound(&bound);
	fo<<bound;

	fo.stress();

	LONG length;
	node->get_lowerLength(&length);
	fo<<(int)length;

	node->get_upperLength(&length);
	fo<<(int)length;

	fo.stress();
	fo<<MORSE_END;

	fo.stress();
}


IKernelNode* CSerializer::LoadMorseSpectrum(FileInputStream& fi) {
	IMorseSpectrum* morse;
	CMorseSpectrum::CreateInstance(&morse);

	char buff[1024];
	fi>>buff;
	ATLASSERT(strcmp(buff, MORSE_BEGIN) == 0);

	double d;
	fi>>d;
	morse->put_lowerBound(d);
	fi>>d;
	morse->put_upperBound(d);

	int l;
	fi>>l;
	morse->put_lowerLength(l);
	fi>>l;
	morse->put_upperLength(l);

	fi>>buff;
	ATLASSERT(strcmp(buff, MORSE_END) == 0);

	IKernelNode* ret;
	morse->QueryInterface(&ret);
	morse->Release();

	ATLASSERT(ret != NULL);

	return ret;
}


//////////////////////////////////////////////////////////////////////////////////////////////////////

template <typename Node>
Node* CSerializer::Cast(IKernelNode* node) {
	Node* anode;
	node->QueryInterface(&anode);
	return anode;
}

template <typename IGraph, int CODE>
bool CSerializer::testAndSaveGraph(IKernelNode* anode, FileOutputStream& fo) {
	IGraph* node = Cast<IGraph>(anode);
	if (node != NULL) {
		fo<<CODE;
		fo.stress();

		SaveGraph<IGraph>(node, fo);
		node->Release();
		return true;
	}
	return false;
}

template <typename IGroup, int CODE>
bool CSerializer::testAndSaveGroup(IKernelNode* anode, FileOutputStream& fo, ISerializerOutputData* data) {
	IGroup* node = Cast<IGroup>(anode);
	if (node != NULL) {
		fo<<CODE;
		fo.stress();

		SaveGroup<IGroup>(node, fo, data);

		node->Release();

		return true;
	} 
	return false;
}