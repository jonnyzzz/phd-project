#pragma once

class CRom;
class ProgressBarInfo;

struct CRomResultValue {
	double value;
	int length;

	CRomResultValue(double value, int length) : value(value), length(length) {}
};

struct CRomResult {
	CRomResultValue left;
	CRomResultValue right;

	CRomResult(CRomResultValue left, CRomResultValue right) : left(left), right(right) {}
};

class CRomAdapter
{
public:
	CRomAdapter(CRom* rom);
	virtual ~CRomAdapter(void);

public:
	CRomResult Compute(ProgressBarInfo* info);

private:
	CRom* rom;
};
