

#include "ProgressBarInfo.h"
#include <iostream>
using namespace std;

class ConsoleProgressBarInfo :
	public ProgressBarInfo
{
public:
	ConsoleProgressBarInfo(void)
	{		
	}

	~ConsoleProgressBarInfo(void)
	{
	}

public:
	virtual double Length() { return 50; }
	virtual void Advance(double d) { cout<<"."; cout.flush(); }
	virtual bool NeedStop() { return false; }
	virtual void Stop() { }
	virtual void Start() {}
};
