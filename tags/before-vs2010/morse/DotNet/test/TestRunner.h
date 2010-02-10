#pragma once

#include "TestBase.h"

class TestRunner
{
public:
    TestRunner(ostream& o);
    virtual ~TestRunner(void);


public:
    bool RunTest(TestBase* test);

protected:
    ostream& o;
};
