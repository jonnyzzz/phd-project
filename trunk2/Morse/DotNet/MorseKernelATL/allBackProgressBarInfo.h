#pragma once
#include "..\cellimagebuilders\progressbarinfo.h"
#include "./nodeBase.h"

class CallBackProgressBarInfo :
	public ProgressBarInfo
{
private:
	IParams* callBack;

public:
	CallBackProgressBarInfo(IParams* callBack) : ProgressBarInfo() {
		callBack->QueryInterface(&this->callBack);
	}
	virtual ~CallBackProgressBarInfo(void) {
		callBack->Release();
	}

public:
	virtual void start() {
		callBack->updateProgressBar(minValue, maxValue, minValue);
	}

	virtual void next() {
		ProgressBarInfo::next();
		callBack->updateProgressBar(minValue, maxValue, current());
	}

	virtual void finish() {
		ProgressBarInfo::finish();
		callBack->updateProgressBar(minValue, maxValue, maxValue);
	}
};
