class ZeroSafeDouble
{
private:
	enum State {
		OUT_OF_PREC,
		NEGATIVE,
		POSITIVE
	};

public:
	ZeroSafeDouble(void);
	ZeroSafeDouble(double value);
	ZeroSafeDouble(const ZeroSafeDouble& d);

private:
	ZeroSafeDouble(double v, State x);

public:
	ZeroSafeDouble operator + (const ZeroSafeDouble& d) const; //*this + d
	ZeroSafeDouble operator - (const ZeroSafeDouble& d) const;
	ZeroSafeDouble operator * (const ZeroSafeDouble& d) const;
	ZeroSafeDouble operator / (const ZeroSafeDouble& d) const;

	ZeroSafeDouble& operator += (const ZeroSafeDouble& d);
	
	ZeroSafeDouble& operator = (const ZeroSafeDouble& d);
	ZeroSafeDouble& operator = (double d);

	bool operator == (const ZeroSafeDouble& d) const;
	bool operator <= (const ZeroSafeDouble& d) const;

public:
	double ToDouble();

private:
	double Abs(double x);
	
	State GetState(double x);

private:
	double value;
	State state;
	static const double prec;
};
