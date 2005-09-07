#pragma once
#include "ResultSet.h"
#include "ResultSetIterator.h"
#include "ResultMetadata.h"
#include "GraphResult.h"
#include "SmartInterface.h"
class AbstractProcess;
class Graph;
#include "../cellImageBuilders/GraphSet.h"

class GraphResultUtil {

public:
	template <class I> 
	static bool ContainsOnlyType(IResultSet* resultSet);

	template <class I>
	static bool ContainsMetadataOnly(IResultSet* resultSet);

	static bool ContainsGraphOnly(IResultSet* resultSet, bool isStrongComponent, int dimension = -1);

public:
	static bool HasSameMetadataType(IResultSet* resultSet);
	static void GetMetadata(IResultSet* resultSet, IResultMetadata** data);
	static void GetMetadataCloned(IResultSet* resultSet, IResultMetadata** data);

    template <class Metadata>
    static void GetMetadataClonedEx(IResultSet* resultSet, Metadata** out) {
        SmartInterface<IResultMetadata> data;
        GetMetadataCloned(resultSet, data.extract());
        data->QueryInterface(out);
        ATLASSERT(*out != NULL);
    }

public:
	static void PerformProcess(AbstractProcess* process, IResultSet* input, bool isStrongComponent, IResultMetadata* metadata, IResultSet** output);

	static Graph* GetGraph(IGraphResult* result);
    static GraphSet GetGraphs(IResultSet* result);

};


template <class Result>
bool GraphResultUtil::ContainsOnlyType(IResultSet* resultSet) {
	bool inFlag = false;
	for (ResultSetIterator<IResultBase> it(resultSet); it.HasNext(); it.Next()) {
		SmartInterface<IResultBase> resultBase = it;
		SmartInterface<Result> result;
		resultBase->QueryInterface(result.extract());
		if (result == NULL) {
			return false;
		}
		inFlag = true;
	}
	return inFlag;
}

template <class Metadata>
bool GraphResultUtil::ContainsMetadataOnly(IResultSet* resultSet) {
	bool inFlag = false;
	for (ResultSetIterator<IResult> it(resultSet); it.HasNext(); it.Next()) {
		SmartInterface<IResult> result = it;
		SmartInterface<IResultMetadata> aMetadata;
		result->GetMetadata(aMetadata.extract());
		ATLASSERT(aMetadata != NULL);
		SmartInterface<Metadata> meta;
		aMetadata->QueryInterface(meta.extract());
		if (meta == NULL) {
			return false;
		}
		inFlag = true;
	}
	return inFlag;
}