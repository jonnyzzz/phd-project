#pragma once
#include "resultSet.h"


template <class Result = IResultBase>
class ResultSetIterator
{
private:
	IResultSet* resultSet;
	int index;

private:
	void init(IResultSet* resultSet, int index) {
		resultSet->QueryInterface(&this->resultSet);
		ATLASSERT(this->resultSet != NULL);
		this->index = index;
	}

public:
	ResultSetIterator(IResultSet* resultSet) {
		init(resultSet, 0);
	}
	~ResultSetIterator(void) {
		SAFE_RELEASE(resultSet);
	}


public:
	Result* Current() {
		Result* result;
		IResultBase* resultBase;
		HRESULT hr = resultSet->GetResult(index, &resultBase);
		ATLASSERT(SUCCEEDED(hr));
		ATLASSERT(resultBase != NULL);

		resultBase->QueryInterface(&result);
		ATLASSERT(result != NULL);

		resultBase->Release();

		return result;
	}

	bool HasNext() {
		int last;
		resultSet->GetCount(&last);
		return (index < last);
	}

	void Next() {
		ATLASSERT(HasNext());
		index++;
	}

	operator Result*() {
		return Current();
	}

	Result* operator->() {
		return Current();
	}
};
