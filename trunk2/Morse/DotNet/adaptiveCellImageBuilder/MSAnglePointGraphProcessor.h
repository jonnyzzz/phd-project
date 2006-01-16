#pragma once

class ISystemFunction;
class ISystemFunctionDerivate;
class Graph;
class PointGraph;
class PointGraphBuilder;
struct Node;


class MSAnglePointGraphProcessor
{
public:
	MSAnglePointGraphProcessor(Graph* graph, ISystemFunction* func, ISystemFunctionDerivate* dfunction, double* precision, size_t upperLimit);
	~MSAnglePointGraphProcessor(void);

public:

	void ProcessNode(Node* node);

private:
	void Concatinate(const double* left, const double* right, double* x);
	void AddCheckedNode(Node* graphNode, double* base, double* proj);

private:
	PointGraph* pointGraphBase;
	PointGraph* pointGraphProj;

	PointGraphBuilder* pointGraphBuilderBase;
	PointGraphBuilder* pointGraphBuilderProj;

	Graph* graph;

	int dimension;
	int dimensionBase;

	double* precision;

	ISystemFunction* functionBase;
	ISystemFunctionDerivate* dfunctionBase;
	ISystemFunction* functionProj;

private:

	double* dinput;

	double* x;
	double* x0;
	double* overlap1;
	double* overlap2;
};
