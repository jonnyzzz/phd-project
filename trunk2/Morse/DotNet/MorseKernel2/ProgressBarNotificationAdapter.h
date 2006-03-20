#pragma once

#include "..\cellimagebuilders\progressbarinfo.h"
#include "progressBarInfo.h"

class ProgressBarNotificationAdapter :
	public ProgressBarInfo
{
public:
	ProgressBarNotificationAdapter(IProgressBarInfo* notification);
	virtual ~ProgressBarNotificationAdapter();


public:
	virtual double Length();
	virtual void Advance(double next);
	virtual bool NeedStop();
	virtual void Stop();
	virtual void Start();


private:
	IProgressBarInfo* notification;
	bool isFinished;

};
