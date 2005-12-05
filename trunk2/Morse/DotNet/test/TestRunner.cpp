#include "StdAfx.h"
#include ".\testrunner.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


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
