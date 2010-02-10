#pragma once
#include "testbase.h"

class PointGraphTest :
    public TestBase
{
public:
    PointGraphTest(const char* testName, ostream& o);
    virtual ~PointGraphTest(void);


public:
    virtual void Test();
};
