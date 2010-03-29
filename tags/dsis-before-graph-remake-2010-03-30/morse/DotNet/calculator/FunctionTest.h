#pragma once

class FunctionTest
{
public:
	FunctionTest(void);
	~FunctionTest(void);

public:
	void test();

private:
	void assert(bool b);
	void assertEQ(double a, double b);
	double abs(double a);
	

private:
	void testPlus();

	bool justATest();

	bool testFunctionSubstitution();
	bool testFunctionComplexSubstitution();
};
