#include "StdAfx.h"
#include ".\testrunner.h"

TestRunner::TestRunner(ostream& o) : o(o)
{
}

TestRunner::~TestRunner(void)
{
}


bool TestRunner::RunTest(TestBase* test) {
    try {
        test->Test();
        return true;
    } catch (TestBaseFailException e) {
        char buff[5555];
        e.getMessage(buff);
        o<<"\n\n\nTestFailed: \n"<<buff<<"\n\n";
        return false;
    }     
}
