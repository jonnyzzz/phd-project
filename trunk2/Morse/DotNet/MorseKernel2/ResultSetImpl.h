// ResultSetImpl.h : Declaration of the CResultSetImpl

#pragma once
#include "resource.h"       // main symbols
#include "resultSet.h"
#include "writableResultSet.h"
#include "resultBase.h"

#include <list>
using namespace std;


[	
	object,
	dual,
	uuid("3EB38E81-F41E-44BD-85E3-486CF05FD1B2"),
	pointer_default(unique)
]
__interface IResultSetImpl : IDispatch {

};


// CResultSetImpl

[
	coclass,
	threading("both"),
	vi_progid("MorseKernel2.ResultSetImpl"),
	progid("MorseKernel2.ResultSetImpl.1"),
	version(1.0),
	uuid("5FAAF083-60CC-4A9B-AAC0-4FDB29047B08"),
	helpstring("ResultSetImpl Class")
]
class ATL_NO_VTABLE CResultSetImpl : 
	public IResultSetImpl,
	public IWritableResultSet,
	public IResultSet
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

