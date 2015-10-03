#pragma once
#include "resultSet.h"
#include "SmartInterface.h"


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
	SmartInterface<Result> Current() {
		SmartInterface<Result> result;
		SmartInterface<IResultBase> resultBase;
		HRESULT hr = resultSet->GetResult(index, resultBase.extract());
		ATLASSERT(SUCCEEDED(hr));
		ATLASSERT(resultBase != NULL);

		resultBase->QueryInterface(result.extract());
		ATLASSERT(result != NULL);

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

	operator SmartInterface<Result>() {
		return Current();
	}

	SmartInterface<Result> operator->() {
		return Current();
	}
};
