#include "stdafx.h"
#include "ZeroSafeDouble.h"

const double ZeroSafeDouble::prec = 1e-8;

ZeroSafeDouble::ZeroSafeDouble(void) : value(0), state(POSITIVE)
{
}

ZeroSafeDouble::ZeroSafeDouble(double d) : value(d), state(GetState(d)){
}

ZeroSafeDouble::ZeroSafeDouble(double v, ZeroSafeDouble::State x) : value(v), state(x) {
}

ZeroSafeDouble::ZeroSafeDouble(const ZeroSafeDouble& d) : value(d.value), state(d.state)
{
}

///////////////////////////////////////////////

double inline ZeroSafeDouble::Abs(double x) {
	return x>0 ? x : -x;
}

ZeroSafeDouble::State inline ZeroSafeDouble::GetState(double x) {
	if (Abs(x) < prec)
		return OUT_OF_PREC;
	else 
		return x > 0 ? POSITIVE : NEGATIVE;
}

ZeroSafeDouble ZeroSafeDouble::operator +(const ZeroSafeDouble& d) const{
	double v = value + d.value;

	return ZeroSafeDouble(v); 
}
