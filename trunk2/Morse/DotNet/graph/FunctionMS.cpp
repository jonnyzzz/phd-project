#include "StdAfx.h"
#include ".\functionms.h"
#include ".\function.h"

#include <math.h>


FunctionMS::FunctionMS(Function* function) 
: function(function)
{
	x = function->getVariables();
}

FunctionMS::~FunctionMS() {
}


JDouble* FunctionMS::getVariables() {
	return x;
}

JDouble FunctionMS::Ro() {
	switch (function->getDimension()) {
		case 2:
			return Ro2();
		case 3:
			return Ro3();
		default:
			return 0;
	}
}

JDouble inline FunctionMS::sqr(JDouble x) {
	return x*x;
}

JDouble inline FunctionMS::Ro2() {	
	JDouble ret =
		sqr(function->dF(0, 0) * cos(x[2]) + function->dF(0, 1) * sin(x[2])) + 
		sqr(function->dF(1, 0) * cos(x[2]) + function->dF(1, 1) * sin(x[2]));
	ret = log(ret)/2;
	
	return ret;
}

JDouble inline FunctionMS::Ro3() {
	JDouble v[] = {cos(x[3])*cos(x[4]), sin(x[3])*cos(x[4]), sin(x[4])};
	
	JDouble r = 0;
	for (int i=0; i<3; i++) {
		JDouble t = 0;
		for (int j=0; j<3;j++) {
			t += function->dF(i,j)*v[j];
		}

		r += sqr(t);
	}
	
	return log(r)/2;
}