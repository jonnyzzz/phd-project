#include "stdafx.h"
#include "ProgressBarInfo.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


ProgressBarInfo::ProgressBarInfo() {
}


ProgressBarInfo::~ProgressBarInfo() {	
}

ProgressBarAdapter::ProgressBarAdapter(ProgressBarInfo* pinfo, double units) {
	this->pinfo = pinfo;
	this->cnt = 0;
	this->step = units/pinfo->Length();	
	pinfo->Start();
}

ProgressBarAdapter::~ProgressBarAdapter() {
	pinfo->Stop();
}


bool ProgressBarAdapter::Next() {
	if (++cnt >= step) {
		cnt -= step;
		pinfo->Advance(step);
		return pinfo->NeedStop();
	}
	return true;
}