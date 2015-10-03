#include "StdAfx.h"
#include ".\progressbarnotificationadapter.h"

ProgressBarNotificationAdapter::ProgressBarNotificationAdapter(IProgressBarInfo* notification)
{
	notification->QueryInterface(&this->notification);
	ATLASSERT(this->notification != NULL);
	isFinished = false;
}

ProgressBarNotificationAdapter::~ProgressBarNotificationAdapter(void)
{
	if (!isFinished) 
		this->notification->Finish();
	this->notification->Release();
}

double ProgressBarNotificationAdapter::Length() {
	double len;
	this->notification->Length(&len);
	return len;
}


bool ProgressBarNotificationAdapter::NeedStop() {
	VARIANT_BOOL b;
	this->notification->NeedStop(&b);
	return (b == VARIANT_TRUE)?true:false;
}

void ProgressBarNotificationAdapter::Advance(double d) {	
	this->notification->Next(d);
}

void ProgressBarNotificationAdapter::Stop() {
	this->notification->Finish();
	this->isFinished = true;
}


void ProgressBarNotificationAdapter::Start() {
	this->notification->Start();
}