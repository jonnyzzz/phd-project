#pragma once

class ProgressBarInfo
{
public:
	ProgressBarInfo();
	virtual ~ProgressBarInfo();
public:
	virtual int Length();
	virtual void Next();
	virtual void Next(int length);
	virtual bool NeedStop();
};
