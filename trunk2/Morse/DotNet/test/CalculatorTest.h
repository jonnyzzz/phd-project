#pragma once

#include "TestBase.h"

class CalculatorTest : public TestBase
{
public:
    CalculatorTest(ostream& o);
    virtual ~CalculatorTest(void);


public:
    virtual void Test();

protected:
    void TestMax();
    void TestMaxCompiled();
    void TestComputation(double x, double y, double z);

    void TestStable(double x, double y, double z);
};
