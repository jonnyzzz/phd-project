#pragma once


#define RUN(x) {Message("start: "#x); {x();} Message("success: "#x);};
#define RUNEX(x) {Message("start: "#x); {x;} Message("success: "#x);};

class TestBase
{
public:
    TestBase(const char* testName, ostream& o);
    virtual ~TestBase(void);

public:
    virtual void Test();

protected:
    void Fail(const char* message, int line = 0);
    void AssertTrue(bool v, const char* message, int line = 0);

    void getTestName(char* message);

    void Message(const char* message);

protected:
    ostream& o;
    char testName[1024];
};


class TestBaseFailException {
public:
    TestBaseFailException(const char* message, int line=0);

public:
    void getMessage(char* message);

private:
    char message[4096];
    int line;
};

