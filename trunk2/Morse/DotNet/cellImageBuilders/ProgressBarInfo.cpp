#include "StdAfx.h"
#include ".\progressbarinfo.h"


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