#include "StdAfx.h"
#include ".\graphresultutil.h"
#include "../cellImageBuilders/AbstractProcess.h"
#include "../cellImageBuilders/GraphSet.h"
#include "GraphResultWrapper.h"
#include "SmartInterface.h"
#include <iostream>
using namespace std;

void GraphResultUtil::PerformProcess(AbstractProcess* process, IResultSet* input, bool isStrongComponent, IResultMetadata* metadata, IResultSet** output) {
	process->start();

	for (GraphResultGraphIterator it(input); it.HasNext(); it.Next()) {
		process->processNextGraph(it);
	}

	GraphSet graphSet = process->results();

	cout<<"GraphSet contents : "<< graphSet.Length()<<"\n";

	GraphResultGraphList list(metadata);
	list.AddGraphs(graphSet, isStrongComponent);

	list.GetResultSet(output);
}



bool GraphResultUtil::HasSameMetadataType(IResultSet* resultSet) {
	ResultSetIterator<IResult> it(resultSet);

	SmartInterface<IResultMetadata> metadata;
	it->GetMetadata(metadata.extract());

	for (it.Next(); it.HasNext(); it.Next()) {
		SmartInterface<IResultMetadata> tmp;
		it->GetMetadata(tmp.extract());

		VARIANT_BOOL answ;
		metadata->EqualType(tmp, &answ);

		if (answ == VARIANT_FALSE) {
			return false;
		} 
	}

	return true;
}



void GraphResultUtil::GetMetadataCloned(IResultSet* resultSet, IResultMetadata** rdata) {
	SmartInterface<IResultMetadata> data;
	GetMetadata(resultSet, data.extract());
	
	ATLASSERT(data != NULL);

	HRESULT hr = data->Clone(rdata);
	ATLASSERT(SUCCEEDED(hr));
	ATLASSERT(*rdata != NULL);	
}

void GraphResultUtil::GetMetadata(IResultSet* resultSet, IResultMetadata** data) {
	ATLASSERT(HasSameMetadataType(resultSet));

	ResultSetIterator<IResult> it(resultSet);
	SmartInterface<IResultMetadata> meta;
	it->GetMetadata(meta.extract());
	ATLASSERT(meta != NULL);

	meta->QueryInterface(data);
	ATLASSERT(*data != NULL);
}


Graph* GraphResultUtil::GetGraph(IGraphResult* result) {
	Graph* graph;
	HRESULT hr;
	hr = result->GetGraph((void**)&graph);
	ATLASSERT(SUCCEEDED(hr));

	return graph;
}

GraphSet GraphResultUtil::GetGraphs(IResultSet* result) {
    GraphSet ret;
    for (GraphResultGraphIterator it(result); it.HasNext(); it.Next()) {
        ret.AddGraph(it);
    }
    return ret;
}


bool GraphResultUtil::ContainsGraphOnly(IResultSet* resultSet, bool isStrongComponent, int dim) {
	if (!ContainsOnlyType<IGraphResult>(resultSet)) return false;
	if (dim <= 0 && !isStrongComponent) return true;

	ResultSetIterator<IGraphResult> it(resultSet);

	while (it.HasNext()) {
		VARIANT_BOOL v;
		HRESULT hr;
		if (isStrongComponent) {
			hr = it.Current()->IsStrongComponent(&v);
			ATLASSERT(SUCCEEDED(hr));

			if (v != VARIANT_TRUE) return false;
		}

        if (dim > 0) {
            Graph* graph = GetGraph(it.Current());
            if (graph->getDimention() != dim) return false;
        }

		it.Next();
	}
		
	return true;
}