// Serializer.cpp : Implementation of CSerializer

#include "stdafx.h"
#include "Serializer.h"
#include "../graph/graph.h"



const int SIGRAPH_CODE = 1;
const int PBGRAPH_CODE = 2;
const int MORSE_CODE = 3;


// CSerializer

HRESULT CSerializer::FinalConstruct() {
	return S_OK;
}

void CSerializer::FinalRelease() {

}


STDMETHODIMP CSerializer::LoadKernelNode(ISerializerInputData* data, IKernelNode** node) {
	BSTR fileName;
	data->FileName(&fileName);
	CString file(fileName);
	FileInputStream fi(file);
	int code;
	fi>>code;

	switch (code) {
		case SIGRAPH_CODE:
			*node = LoadSymbolicImageGraph(fi);
			break;
		case PBGRAPH_CODE:
			*node = LoadProjectiveBundleGraph(fi);
			break;
		case MORSE_CODE:
			*node = LoadMorseSpectrum(fi);
		default:
			*node = NULL;
			break;
	}  
	return (node == NULL)?E_FAIL:S_OK;
}

STDMETHODIMP CSerializer::SaveKernelNode(ISerializerOutputData* data, IKernelNode* anode) {
	BSTR fileName;
	data->FileName(&fileName);
	CString file(fileName);
	FileOutputStream fo(file);

	ISymbolicImageGraph* node;
	anode->QueryInterface(&node);
	if (node != NULL) {
		fo<<SIGRAPH_CODE;
		fo.stress();
		SaveSymbolicImageGraph(node, fo);
		node->Release();
		return S_OK;
	}

	IProjectiveBundleGraph* pnode;
	anode->QueryInterface(&pnode);
	if (pnode != NULL) {
		fo<< PBGRAPH_CODE;
		fo.stress();
		SaveProjectiveBundleGraph(pnode, fo);
		pnode->Release();	
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
// ISymbolicImageGraph



void CSerializer::SaveSymbolicImageGraph(ISymbolicImageGraph* node, FileOutputStream& fo) {

	Graph* graph;
	node->getGraph((void**)&graph);

	this->SaveGraph(fo, graph);
}

IKernelNode* CSerializer::LoadSymbolicImageGraph(FileInputStream& fi) {
	ISymbolicImageGraph* node;
	CSymbolicImageGraph::CreateInstance(&node);
	
	Graph* graph = LoadGraph(fi);

	node->setGraph((void*)graph);

	IKernelNode* ret;
	node->QueryInterface(&ret);

	node->Release();

	ATLASSERT(ret != NULL);

	return ret;
}

/////////////////////////////////////////////////////////////////////////////////
// IProjectiveBundleGraph


void CSerializer::SaveProjectiveBundleGraph(IProjectiveBundleGraph* node, FileOutputStream& fo) {
	Graph* graph;
	node->getGraph((void**)&graph);
    
	this->SaveGraph(fo, graph);
}

IKernelNode* CSerializer::LoadProjectiveBundleGraph(FileInputStream& fi) {
	IProjectiveBundleGraph* node;
	CProjectiveBundleGraph::CreateInstance(&node);
	
	Graph* graph = LoadGraph(fi);

	node->setGraph((void*)graph);

	IKernelNode* ret;
	node->QueryInterface(&ret);

	node->Release();

	ATLASSERT(ret != NULL);

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


