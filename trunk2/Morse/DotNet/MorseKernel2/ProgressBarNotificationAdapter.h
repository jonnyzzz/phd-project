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
	virtual int Length();
	virtual void Next();
	virtual bool NeedStop();


private:
	IProgressBarInfo* notification;

};
