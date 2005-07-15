#pragma once

class IntervalValue
{
public:
	IntervalValue(void);
	IntervalValue(const double& left, const double& right);
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
	double min(const double& x, const double& y);
	double max(const double& x, const double& y);

private:
	static const IntervalValue ZERO;
};
