#pragma once

#include "TestBase.h"

class CalculatorTest : public TestBase
{
public:
    CalculatorTest(ostream& o);
    virtual ~CalculatorTest(void);


public:
    virtual void Test();

public:
    void TestMax();
    void TestMaxCompiled();
    void TestComputation(double x, double y, double z);

    void TestStable(double x, double y, double z);

    void TestSystemFunctionIteration(int n);

    void TestSystemFunctionDerivate();
	
	void TestSystemFunctionDerivate2();

    void TestSystemFunctionDerivateMultiple();

	void TestSystemFunctionSegmentPojectiveExtension();
};
