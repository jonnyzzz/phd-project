#pragma once
#include "ResultSet.h"
#include "ResultSetIterator.h"
#include "ResultMetadata.h"
#include "SmartInterface.h"
class AbstractProcess;

class GraphResultUtil {

public:
	template <class I> 
	static bool ContainsOnlyType(IResultSet* resultSet);

	template <class I>
	static bool ContainsMetadataOnly(IResultSet* resultSet);

public:
	static bool HasSameMetadataType(IResultSet* resultSet);
	static void GetMetadata(IResultSet* resultSet, IResultMetadata** data);
	static void GetMetadataCloned(IResultSet* resultSet, IResultMetadata** data);

public:
	static void PerformProcess(AbstractProcess* process, IResultSet* input, bool isStrongComponent, IResultMetadata* metadata, IResultSet** output);

};


template <class Result>
bool GraphResultUtil::ContainsOnlyType(IResultSet* resultSet) {
	bool inFlag = false;
	for (ResultSetIterator<IResultBase> it(resultSet); it.HasNext(); it.Next()) {
		SmartInterface<IResultBase> resultBase = it;
		SmartInterface<Result> result;
		resultBase->QueryInterface(&result);
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
		result->GetMetadata(&aMetadata);
		ATLASSERT(aMetadata != NULL);
		SmartInterface<Metadata> meta;
		aMetadata->QueryInterface(&meta);
		if (meta == NULL) {
			return false;
		}
		inFlag = true;
	}
	return inFlag;
}