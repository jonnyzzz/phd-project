#include "StdAfx.h"
#include ".\calculatortest.h"
#include "objects.h"
#include <math.h>
#include "../calculator/FunctionContext.h"

CalculatorTest::CalculatorTest(ostream& o) : TestBase("CalculatorTest", o)
{
}

CalculatorTest::~CalculatorTest(void)
{
}


void CalculatorTest::Test() {
    RUN( TestMax);
    RUN( TestMaxCompiled);
    RUNEX( TestComputation(0.01,0.01,0.01));
    RUNEX( TestComputation(3.235937, 0.247393, 0.692910));
    RUNEX( TestComputation(3.235937, 0.247393, 0.686406 ));
    RUNEX( TestComputation(3.235937, 0.247393, 0.689658 ));

    RUNEX( TestStable(3.235937, 0.247393, 0.689658));
    RUNEX( TestStable(3.235937, 0.247393, 0.692910));
    RUNEX( TestStable(3.235937, 0.247393, 0.686406));

   
    Message("Test: Success");
}


void CalculatorTest::TestMax() {

    FunctionFactory fac("x=max(0,10);");
    sFunctionNode node(fac.getEquation("x"));
    
    AssertTrue((FunctionNode*)node != NULL, "Node is NULL!");
    double d = node->evaluate();
    char buff[512];
    sprintf(buff, "max(0, 10) = %f", d);
    Message(buff);

    AssertTrue( (d == (double)10), "Max function implemented incorrectly"); 
}


void CalculatorTest::TestMaxCompiled() {
    FunctionFactory fac("x=max(a,b)");
    
    FunctionNativeVariableSequence seq;
    seq.push_back(fac.getFunctionDictionary()->lookUp("a")); 
    seq.push_back(fac.getFunctionDictionary()->lookUp("b"));
    double x[2] = {-0, -10};

    FunctionNative native(fac.getEquation("x"), seq, x);

    double d = native.evaluate();

    char buff[512];
    sprintf(buff, "max(0, 10) = %f", d);
    Message(buff);

    AssertTrue( d == 0, "Max function implemented incorrectly"); 
}

void CalculatorTest::TestComputation(double x, double y, double z) { 
    double kz=(1-exp(-z))/z;
    double ky=(1-exp(-y))/y;
    double u=4*y*z;
    double ku=(1-exp(-u))/u;
    double fx=4.522*x*exp(-y)/(1+x*max(exp(-y),kz*ky));
    double fy=0.962*ky*x*y*exp(-z)*ku;
    double fz=4*y*z;


    FunctionFactory fac ("y1=fx;y2=fy;y3=fz;space_min1=0.01;space_min2=0.01;space_min3=0.01;space_max1=10;space_max2=10;space_max3=10;grid1=3;grid2=3;grid3=3;iteration=1;kz=(1-exp(-z))/z;ky=(1-exp(-y))/y;u=4*y*z;ku=(1-exp(-u))/u;fx=4.522*x*exp(-y)/(1+x*max(exp(-y),kz*ky));fy=0.962*ky*x*y*exp(-z)*ku;fz=4*y*z;x=x1;y=x2;z=x3;_dimension=3;");

    FunctionContext cx;
    cx.addSubstitute(fac.getFunctionDictionary()->lookUp("x1"), new FunctionNodeConstant(x));
    cx.addSubstitute(fac.getFunctionDictionary()->lookUp("x2"), new FunctionNodeConstant(y));
    cx.addSubstitute(fac.getFunctionDictionary()->lookUp("x3"), new FunctionNodeConstant(z));

    char buff[512];
    sprintf(buff, "1.%f == %f", fac.getEquation("fx")->evaluate(cx), fx);
    Message(buff);
    sprintf(buff, "1.%f == %f", fac.getEquation("fy")->evaluate(cx), fy);
    Message(buff);
    sprintf(buff, "1.%f == %f", fac.getEquation("fz")->evaluate(cx), fz);
    Message(buff);


    AssertTrue(abs(fac.getEquation("fx")->evaluate(cx) - fx) <1e-8, "Computation failed 1");
    AssertTrue(abs(fac.getEquation("fy")->evaluate(cx) - fy) <1e-8, "Computation failed 2");
    AssertTrue(abs(fac.getEquation("fz")->evaluate(cx) - fz) <1e-8, "Computation failed 3");
}

void CalculatorTest::TestStable(double x, double y, double z) {
    double kz=(1-exp(-z))/z;
    double ky=(1-exp(-y))/y;
    double u=4*y*z;
    double ku=(1-exp(-u))/u;
    double fx=4.522*x*exp(-y)/(1+x*max(exp(-y),kz*ky));
    double fy=0.962*ky*x*y*exp(-z)*ku;
    double fz=4*y*z;
    
    FunctionFactory fac ("y1=fx;y2=fy;y3=fz;space_min1=0.01;space_min2=0.01;space_min3=0.01;space_max1=10;space_max2=10;space_max3=10;grid1=3;grid2=3;grid3=3;iteration=1;kz=(1-exp(-z))/z;ky=(1-exp(-y))/y;u=4*y*z;ku=(1-exp(-u))/u;fx=4.522*x*exp(-y)/(1+x*max(exp(-y),kz*ky));fy=0.962*ky*x*y*exp(-z)*ku;fz=4*y*z;x=x1;y=x2;z=x3;_dimension=3;");

    FunctionContext cx;
    cx.addSubstitute(fac.getFunctionDictionary()->lookUp("x1"), new FunctionNodeConstant(x));
    cx.addSubstitute(fac.getFunctionDictionary()->lookUp("x2"), new FunctionNodeConstant(y));
    cx.addSubstitute(fac.getFunctionDictionary()->lookUp("x3"), new FunctionNodeConstant(z));

    char buff[512];
    sprintf(buff, "1.%f == %f", fac.getEquation("fx")->evaluate(cx), fx);
    Message(buff);
    sprintf(buff, "1.%f == %f", fac.getEquation("fy")->evaluate(cx), fy);
    Message(buff);
    sprintf(buff, "1.%f == %f", fac.getEquation("fz")->evaluate(cx), fz);
    Message(buff);


    AssertTrue(abs(fac.getEquation("fx")->evaluate(cx) - fx) <1e-8, "Computation failed 1");
    AssertTrue(abs(fac.getEquation("fy")->evaluate(cx) - fy) <1e-8, "Computation failed 2");
    AssertTrue(abs(fac.getEquation("fz")->evaluate(cx) - fz) <1e-8, "Computation failed 3");


    AssertTrue(abs(fac.getEquation("fx")->evaluate(cx) - x) <1e-1, "Stable failed 1");
    AssertTrue(abs(fac.getEquation("fy")->evaluate(cx) - y) <1e-1, "Stable failed 2");
    AssertTrue(abs(fac.getEquation("fz")->evaluate(cx) - z) <1e-1, "Stable failed 3");
}