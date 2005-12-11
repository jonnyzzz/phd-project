#include "StdAfx.h"
#include ".\progressbarnotificationadapter.h"

ProgressBarNotificationAdapter::ProgressBarNotificationAdapter(IProgressBarInfo* notification)
{
	notification->QueryInterface(&this->notification);
	ATLASSERT(this->notification != NULL);

	this->notification->Start();
}

ProgressBarNotificationAdapter::~ProgressBarNotificationAdapter(void)
{
	this->notification->Finish();
	this->notification->Release();
}



int ProgressBarNotificationAdapter::Length() {
	int len;
	this->notification->Length(&len);
	return len;
}


bool ProgressBarNotificationAdapter::NeedStop() {
	VARIANT_BOOL b;
	this->notification->NeedStop(&b);
	return (b == VARIANT_TRUE)?true:false;
}

void ProgressBarNotificationAdapter::Next() {
	cout<<".";
	this->notification->Next();
}
