#pragma once

#include "FunctionBase.h"
#include "../SystemFunction/ISystemFunctionDerivate.h"
class Graph;

class FoodChain3DBase {

private:
	double g(double x);

public:
	static double a;
	static double b;
	static double c;
	static double d;

protected:
	void Evaluate(double* input, double* output, bool needDerivate);
};

 
class FoodChain3D : public FunctionBase, public FoodChain3DBase
{
 public:
	FoodChain3D(void);
	FoodChain3D(double *input, double* output);
	virtual ~FoodChain3D(void);

public: 
	virtual void evaluate();   
};

class FoodChain3DDerivate : public FunctionBaseDerivate, public FoodChain3DBase
{
 public:
	FoodChain3DDerivate(void);
	FoodChain3DDerivate(double *input, double* output);
	virtual ~FoodChain3DDerivate(void);

public: 
	virtual void evaluate();   
};


class FoodChain3DFactory {
public:
	static const int Dim;	

	static Graph* CreateGraph();
	
	static void Dump();
};