#pragma once

class ProgressBarInfo
{
public:
	ProgressBarInfo();
	virtual ~ProgressBarInfo(void);

public:
	virtual void setBounds(int sections = 1, int maxValue = 1000, int minValue = 0 );
	virtual void next();
	virtual int current();
	virtual int getLengthPart();
	virtual void finish();

protected:
	int minValue;
	int maxValue;
	int currentValue;
	int sections;
};