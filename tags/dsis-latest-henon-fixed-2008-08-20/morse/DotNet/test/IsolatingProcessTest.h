#pragma once
#include "testbase.h"
#include "simpleGraphApi.h"

class IsolatingProcessTest :
	public TestBase, private SimpleGraphApi
{
public:
	IsolatingProcessTest(ostream& o);
	virtual ~IsolatingProcessTest(void);

public:
	virtual void Test();

private:
	void testLen(int length, Graph* start);
};
