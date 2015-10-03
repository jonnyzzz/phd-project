#include "StdAfx.h"
#include ".\actionperformerbase.h"
#include "ProgressBarNotificationAdapter.h"

ActionPerformerBase::ActionPerformerBase(void)
{
}

ActionPerformerBase::~ActionPerformerBase(void)
{
}



ProgressBarInfo* ActionPerformerBase::CreateProgressBarInfo(IParams* params) {
	IProgressBarNotification* notify;
	params->GetProgressBarNotification(&notify);
	ProgressBarInfo* info = new ProgressBarNotificationAdapter(notify);
	notify->Release();
	return info;
}