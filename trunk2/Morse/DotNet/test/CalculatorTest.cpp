#include "StdAfx.h"
#include ".\calculatortest.h"
#include "objects.h"
#include <math.h>
#include "../calculator/FunctionContext.h"
#include "../systemfunction/segmentprojectiveextendedsystemfunction.h"

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

    RUNEX( TestSystemFunctionIteration(1) );
    RUNEX( TestSystemFunctionIteration(4) );
    RUNEX( TestSystemFunctionIteration(2) );
    RUNEX( TestSystemFunctionIteration(20) );

    RUN (TestSystemFunctionDerivate);
    RUN (TestSystemFunctionDerivateMultiple);

	RUN ( TestSystemFunctionSegmentPojectiveExtension);

   
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

void CalculatorTest::TestSystemFunctionIteration(int n) {

    char buff[255];
    sprintf(buff, "Iteration test for %d iterations", n);
    this->Message(buff);

    FunctionFactory fac("y1=x1+1;");
    SystemFunction func(&fac, 1, n);

    func.getInput()[0] = 0;
    func.evaluate();

    sprintf(buff, "answer = %f", func.getOutput()[0]);
    this->Message(buff);
    
    AssertTrue( func.getOutput()[0] == n, "Itaration failed");
}


void CalculatorTest::TestSystemFunctionDerivate() {
    FunctionFactory factory("y1=x1");

    ISystemFunctionDerivate* function = new SystemFunctionDerivate(&factory, 1, 1);

    double* input = function->getInput();
    double* output = function->getOutput();

    input[0] = 0;

    function->evaluate();

    AssertTrue(*output == 0 && output[1] == 1, "TestSystemFunctionDerivate 1d failed");

    delete function;
}

void CalculatorTest::TestSystemFunctionDerivateMultiple() {
    FunctionFactory factory("y1=x1+x2;y2=0;");
    ISystemFunctionDerivate* funciton = new SystemFunctionDerivate(&factory, 2, 1);

    double* input = funciton ->getInput();
    double* output = funciton->getOutput();

    input[0] = input[1] = 0;
    
    funciton->evaluate();

    AssertTrue(output[0] == 0 && output[1] == 0 && output[2] == 1 && output[3] == 1 && output[4] == 0 && output[5] == 0, "TestSystemFunctionDerivateMultiple failed");

    delete funciton;
}


void CalculatorTest::TestSystemFunctionSegmentPojectiveExtension() {
	FunctionFactory factory("y1=x1;y2=x2;");
	ISystemFunctionDerivate* function = new SystemFunctionDerivate(&factory, 2, 1);
	ISystemFunctionDerivate* exfunction = new SegmentProjectiveExtendedSystemFunction(function);

	double* input = function->getInput();
	double* output = function->getOutput();

	input[0] = input[1] = 0;
	input[2] = input[3] = 1;

	exfunction->evaluate();
/*
	cout<<"My Failed\n";

	for (int i=0; i<8; i++) {
		cout<<i<<" -> "<<output[i]<<"\n";
	}
*/
	AssertTrue(output[0] == 0 && output[1] == 0 && output[2] == 1 && 
		       output[3] == 0 && output[4] == 0 && output[5] == 1 &&
			   output[6] == 1 && abs(output[7]- 1) < 1e-8, "SegmentFunction Test failed");

	delete function;
	delete exfunction;
}
