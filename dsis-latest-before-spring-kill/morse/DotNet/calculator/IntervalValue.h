#pragma once
#include <iostream>

class IntervalValue
{
public:
	IntervalValue(void);
	//IntervalValue(const double& left, const double& right);
	IntervalValue(double left, double right);
	IntervalValue(const IntervalValue& value);
	IntervalValue(const double& value);

	~IntervalValue(void);

public:
	double Left() const;
	double Right() const;
	bool IsNaN() const;
	bool Contatins(const double& x) const;


public:
	IntervalValue operator + (const IntervalValue& value) const;
	IntervalValue operator - (const IntervalValue& value) const;
	IntervalValue operator * (const IntervalValue& value) const;
	IntervalValue operator / (const IntervalValue& value) const;

	bool operator >= (const IntervalValue& value) const;
	bool operator == (const IntervalValue& value) const;
	bool operator <= (const IntervalValue& value) const;	

private:
	double left;
	double right;

private:
	double min(double x, double y) const;
	double max(double x, double y) const;

private:
	static const IntervalValue ZERO;

public:
	void print(std::ostream& stream = std::cout);
};
