

#include "ProgressBarInfo.h"
#include <iostream>
using namespace std;

class ConsoleProgressBarInfo :
	public ProgressBarInfo
{
public:
	ConsoleProgressBarInfo(void)
	{
		cnt=0;
	}

	~ConsoleProgressBarInfo(void)
	{
	}

public:
	virtual int Length() { return 50; }
	virtual void Next() { cout<<"."; cout.flush(); }
	virtual bool NeedStop() { return false; }

private:
	int cnt;
};
