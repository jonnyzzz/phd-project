// ResultSetImpl.h : Declaration of the CResultSetImpl

#pragma once
#include "resource.h"       // main symbols
#include "resultSet.h"
#include "writableResultSet.h"
#include "resultBase.h"

#include <list>
using namespace std;

// CResultSetImpl

[
	coclass,
	threading("free"),
	vi_progid("MorseKernel2.ResultSetImpl"),
	progid("MorseKernel2.ResultSetImpl.1"),
	version(1.0),
	uuid("5FAAF083-60CC-4A9B-AAC0-4FDB29047B08"),
	helpstring("ResultSetImpl Class")
]
class ATL_NO_VTABLE CResultSetImpl : 
	public IResultSet,
	public IWritableResultSet
{
public:
	CResultSetImpl();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();
	
	void FinalRelease();

	//IResultSet
public:
	STDMETHOD(GetCount)(int* count);
	STDMETHOD(GetResult)(int index, IResultBase** result);

	//IWrutableResultSet
public:
	STDMETHOD(AddResult)(IResultBase* result);

private:
	typedef list<IResultBase*> ResultList;
	ResultList resultList;

};

