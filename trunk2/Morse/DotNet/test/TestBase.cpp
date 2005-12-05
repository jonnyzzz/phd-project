#include "StdAfx.h"
#include ".\testbase.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


TestBase::TestBase(const char* testName, ostream& o) : o(o)
{
    strcpy(this->testName, testName);
}

TestBase::~TestBase(void)
{
}


void TestBase::Message(const char* message) {
    o<<"Test: "<<this->testName<<": "<<message<<"\n";
}


void TestBase::Fail(const char* message, int line) {
    o<<"\n\nFail: "<<testName<<" with message "<<message<<" at "<<line<<"\n";
    throw TestBaseFailException(message, line);
}

void TestBase::AssertTrue(bool v, const char* message, int line) {
    if (!v) {
        Fail(message, line);        
    }
}

void TestBase::getTestName(char* message) {
    strcpy(message, this->testName);
}


TestBaseFailException::TestBaseFailException(const char* message, int line) {
    this->line = line;
    strcpy(this->message, message);
}

void TestBaseFailException::getMessage(char* message) {
    sprintf(message, "Message %s at line %d", this->message, this->line);
};


void TestBase::Test() {
    AssertTrue(true, "true");
    AssertTrue(false, "false");
}
