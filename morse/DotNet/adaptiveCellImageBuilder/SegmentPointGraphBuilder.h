#pragma once

class PointGraph;

class SegmentPointGraphBuilder
{
public:
	SegmentPointGraphBuilder(int ldimension, int udimension, const double* eps, PointGraph* graph);
	virtual ~SegmentPointGraphBuilder(void);

public:
	void BuildInitialGraph(double* x, int index);

private:
	double Abs(double x);

private:
	int ldim;
	int udim;
	int dim;
	PointGraph* graph;

	double* eps;
	double* eps2;
};
