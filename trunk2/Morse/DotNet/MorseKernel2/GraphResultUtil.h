#pragma once
#include "ResultSet.h"
#include "ResultSetIterator.h"
class AbstractProcess;

class GraphResultUtil {

public:
	template <class I> 
	static bool ContainsOnlyType(IResultSet* resultSet);

public:
	static void PerformProcess(AbstractProcess* process, IResultSet* input, bool isStrongComponent, IResultSet** output);

};


template <class Result>
bool GraphResultUtil::ContainsOnlyType(IResultSet* resultSet) {
	for (ResultSetIterator<IResultBase> it(resultSet); it.HasNext(); it.Next()) {
		IResultBase* resultBase = it;
		Result* result;
		resultBase->QueryInterface(&result);
		if (result != NULL) {
			result->Release();
			resultBase->Release();
		} else {
			resultBase->Release();
			return false;
		}
	}
	return true;
}