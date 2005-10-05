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

int ProgressBarInfo::Length() {
	return 1<<30;
}


void ProgressBarInfo::Next() {

}

void ProgressBarInfo::Next(int length) {
	while (length-- >= 0) {
		Next();
	}
}

bool ProgressBarInfo::NeedStop() {
	return false;
}