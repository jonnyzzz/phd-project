#pragma once
#include "FunctionBase.h"

class Graph;

class LogisticsMap :
	public FunctionBase
{
public:
	LogisticsMap(void);
	LogisticsMap(double *input, double* output);
	virtual ~LogisticsMap(void);

public: 
	virtual void evaluate();

public:
	virtual bool isNative() {return true;};
	virtual bool hasFunction() {return true;};
	virtual bool hasDerivative() {return false;};	

};


class LogisticsMapFactory {
public:
	ISystemFunction* Create(double* in, double* out) {
		return new LogisticsMap(in, out);
	}

	static const int Dim;	

	static Graph* CreateGraph();
	
	static void Dump();

};

