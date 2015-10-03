#pragma once
#include "..\cellimagebuilders\progressbarinfo.h"
#include "nodebase.h"

class ProgressBarNotificationAdapter :
	public ProgressBarInfo
{
public:
	ProgressBarNotificationAdapter(IProgressBarNotification* notification);
	virtual ~ProgressBarNotificationAdapter();


public:
	virtual int Length();
	virtual void Next(int length = 1);
	virtual bool NeedStop();


private:
	IProgressBarNotification* notification;

};
