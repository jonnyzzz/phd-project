#pragma once

class ProgressBarInfo
{
public:
	virtual ~ProgressBarInfo() {};
public:
	virtual int Length() { return 1<<30;};
	virtual void Next(int length = 1) {};
	virtual bool NeedStop() { return false;};
};
