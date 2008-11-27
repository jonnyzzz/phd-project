#include "FunctionBase.h"
#include "../graph/Graph.h"


class ParametrisedLogisticsMap :
	public FunctionBase
{
public:
	ParametrisedLogisticsMap(void);
	ParametrisedLogisticsMap(double *input, double* output);
	virtual ~ParametrisedLogisticsMap(void);

public: 
	virtual void evaluate();

public:
	virtual bool isNative() {return true;};
	virtual bool hasFunction() {return true;};
	virtual bool hasDerivative() {return false;};	

public: 
	static double mju;
	static double derivate(double d);
	static double f( double d);
};


class ParametrisedLogisticsMapFactory {
public:
	ISystemFunction* Create(double* in, double* out) {
		return new ParametrisedLogisticsMap(in, out);
	}

	static const int Dim;	

	static Graph* CreateGraph();
	
	static void Dump();

public:
	static void SaveOnlyUnstable(double mju, Graph* graph, FileOutputStream& fs);

private:
	static double Abs(double d);
};

