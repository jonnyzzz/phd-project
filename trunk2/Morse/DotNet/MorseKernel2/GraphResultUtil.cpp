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

	*output = list.GetResultSet();
}



bool GraphResultUtil::HasSameMetadataType(IResultSet* resultSet) {
	ResultSetIterator<IResult> it(resultSet);

	SmartInterface<IResultMetadata> metadata;
	it->GetMetadata(&metadata);

	for (it.Next(); it.HasNext(); it.Next()) {
		SmartInterface<IResultMetadata> tmp;
		it->GetMetadata(&tmp);

		VARIANT_BOOL answ;
		metadata->EqualType(tmp, &answ);

		if (answ == FALSE) {
			return false;
		} 
	}

	return true;
}



IResultMetadata* GraphResultUtil::GetMetadataCloned(IResultSet* resultSet) {
	SmartInterface<IResultMetadata> data = GetMetadata(resultSet);
	IResultMetadata* ret;
	data->Clone(&ret);
	ATLASSERT(ret != NULL);
	return ret;
}

IResultMetadata* GraphResultUtil::GetMetadata(IResultSet* resultSet) {
	ATLASSERT(HasSameMetadataType(resultSet));

	ResultSetIterator<IResult> it(resultSet);
	IResultMetadata* meta;
	it->GetMetadata(&meta);

	ATLASSERT(meta != NULL);

	return meta;
}
