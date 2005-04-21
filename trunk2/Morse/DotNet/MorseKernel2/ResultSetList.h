#pragma once

#include "resultMetadata.h"
#include "SmartInterface.h"
#include "writableResultSet.h"
#include "resultSet.h"
#include "resultsetimpl.h"

template <class Source = IResult, class Cast = IResult>
class ResultSetList
{
private:
	SmartInterface<IWritableResultSet> writableResultSet;

public:
	ResultSetList() {
		CResultSetImpl::CreateInstance(writableResultSet.extract());
		ATLASSERT(writableResultSet != NULL);
	}

	void AddResult(const SmartInterface<Cast>& cast) {
		SmartInterface<Source> data;
		cast->QueryInterface(data.extract());

		writableResultSet->AddResult(data);
	}

	SmartInterface<IResultSet> ToResultSet() {
		SmartInterface<IResultSet> ret;
		writableResultSet->QueryInterface(ret.extract());

		ATLASSERT(ret != NULL);

		return ret;
	}
};
