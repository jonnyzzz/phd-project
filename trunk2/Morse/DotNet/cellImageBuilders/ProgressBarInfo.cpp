#include "StdAfx.h"
#include ".\progressbarinfo.h"

ProgressBarInfo::ProgressBarInfo()
{
	this->minValue = 0;
	this->maxValue = 1;
	this->sections = 1;
	this->currentValue = minValue;
}

ProgressBarInfo::~ProgressBarInfo(void)
{
}

void ProgressBarInfo::setBounds(int sections, int maxValue, int minValue ) {
	this->sections = sections;
	this->minValue = minValue;
	this->maxValue = maxValue * sections;	
	this->currentValue = minValue;
}

int ProgressBarInfo::current() {
	return currentValue;
}


void ProgressBarInfo::next() {
	if (currentValue < maxValue)
		currentValue++;
}

int ProgressBarInfo::getLengthPart() {
	return abs(maxValue - minValue) / sections;
}

void ProgressBarInfo::finish() {
	currentValue = maxValue;
}