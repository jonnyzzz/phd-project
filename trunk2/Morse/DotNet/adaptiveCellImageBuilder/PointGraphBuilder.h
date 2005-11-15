#include "PointGraph.h"

class PointGraphBuilder
{
public:
    PointGraphBuilder(int dimention, double* eps, PointGraph& graph);
    ~PointGraphBuilder(void);

public:
    void BuildInitialGraph(double* x);

private:    
    //find GraphNode with triple coordinates
    PointGraph::Node* FindNode(const int* b);

    void Build2D(const int* b0, const int* ax0, const int* ax1);

private:
    double* eps;
    double* eps2;
    double* fx;
    double* x;

    int dimension;
    int* b;
    int mx;

    PointGraph::Node** node;
    PointGraph& graph;
};
