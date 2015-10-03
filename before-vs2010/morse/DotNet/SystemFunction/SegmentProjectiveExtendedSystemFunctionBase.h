#pragma once

class SegmentProjectiveExtendedSystemFunctionBase
{
public:
	SegmentProjectiveExtendedSystemFunctionBase(int real_dimension);
	virtual ~SegmentProjectiveExtendedSystemFunctionBase(void);

protected:
    void computeEx(double* v, double* d, double* output);
    double Abs(double x);

private:
	int real_dimension;
};
