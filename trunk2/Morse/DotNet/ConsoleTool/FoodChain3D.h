#pragma once

#include "FunctionBase.h"
#include "../SystemFunction/ISystemFunctionDerivate.h"
class Graph;

 
class FoodChain3D : public FunctionBase
{
 public:
	FoodChain3D(void);
	FoodChain3D(double *input, double* output);
	virtual ~FoodChain3D(void);

public: 
	virtual void evaluate();
	virtual int getFunctionDimension();

private:
	double g(double x);
	double Max(double x, double y);
public:
	static double a;
	static double b;
	static double c;
	static double d;
};


class FoodChain3DFactory {
public:
	ISystemFunction* Create(double* in, double* out) {
		return new FoodChain3D(in, out);
	}
	static const int Dim;	

	static Graph* CreateGraph();
	
	static void Dump();

};