#include "Rom.h"

class ISystemFunctionDerivate;
class Graph;
struct Node;

class SIRom : public CRom
{
public:
	SIRom(Graph* graph, ISystemFunctionDerivate* function);
	virtual ~SIRom();


protected:
	virtual double cost(Node* node);


private:
	Graph* graph;
	ISystemFunctionDerivate* function;
	double* input;
	double* output;
	int dimension;

private:
	double& getAt(int i, int j);
	double Abs(double x);

	double exhaussDet();
};
