#include "stdafx.h"
#include "PointGraphBuilder.h"
#include <math.h>

PointGraphBuilder::PointGraphBuilder(int dimension, const double* eps, PointGraph& graph) :
dimension(dimension), eps(eps), graph(graph)
{
    eps2 = new double[dimension];
    for (int i=0; i<dimension; i++) {
        eps2[i] = eps[i]/2;
    }
}

PointGraphBuilder::~PointGraphBuilder(void)
{
    delete[] eps2;
}

void PointGraphBuilder::BuildInitialGraph(double* x) {    
    if (dimension == 1) {
        PointGraph::Node* n1 = graph.AddNode(x);
        x[0]+= eps[0];
        PointGraph::Node* n2 = graph.AddNode(x);
        graph.AddEdge(n1, n2);
    } else if (dimension == 2) {
        PointGraph::Node* n00 = graph.AddNode(x);
        x[0]+= eps[0];
        PointGraph::Node* n10 = graph.AddNode(x);
        x[0]-= eps[0];
        x[1]+= eps[1];
        PointGraph::Node* n01 = graph.AddNode(x);
        x[0]+= eps[0];
        PointGraph::Node* n11 = graph.AddNode(x);
        x[0]-= eps2[0];
        x[1]-= eps2[1];
        PointGraph::Node* c = graph.AddNode(x);

        graph.AddEdge(n00, n10);
        graph.AddEdge(n10, n11);
        graph.AddEdge(n11, n01);
        graph.AddEdge(n01, n00);
        graph.AddEdge(n00, c);
        graph.AddEdge(n10, c);
        graph.AddEdge(n01, c);
        graph.AddEdge(n11, c);
    } else if (dimension == 3) {
        PointGraph::Node* n000 = graph.AddNode(x);
        x[0]+=eps[0];
        PointGraph::Node* n001 = graph.AddNode(x);
        x[0]-=eps[0]; x[1] += eps[1];
        PointGraph::Node* n010 = graph.AddNode(x);
        x[0]+=eps[0];
        PointGraph::Node* n011 = graph.AddNode(x);
        x[0]-=eps[0];x[1]-=eps[1]; x[2]+=eps[2];
        PointGraph::Node* n100 = graph.AddNode(x);
        x[0]+=eps[0];
        PointGraph::Node* n101 = graph.AddNode(x);
        x[0]-=eps[0];x[1]+=eps[1];
        PointGraph::Node* n110 = graph.AddNode(x);
        x[0]+=eps[0];
        PointGraph::Node* n111 = graph.AddNode(x);
        x[0]-=eps2[0];x[1]-=eps2[1];x[2]-=eps2[2];
        PointGraph::Node* c = graph.AddNode(x);
        x[0]-=eps2[0];x[1]-=eps2[1];x[2]-=eps2[2];

        x[0]+=eps2[0]; x[1]+=eps2[1];
        PointGraph::Node* m01 = graph.AddNode(x);
        x[2]+=eps[2];
        PointGraph::Node* s01 = graph.AddNode(x);
        x[1]-=eps2[1]; x[2]-=eps2[2];
        PointGraph::Node* m02 = graph.AddNode(x);
        x[1]+=eps[1];
        PointGraph::Node* s02 = graph.AddNode(x);
        x[0]-=eps2[0]; x[1]-=eps2[1];
        PointGraph::Node* m12 = graph.AddNode(x);
        x[0]+=eps[0];
        PointGraph::Node* s12 = graph.AddNode(x);
        x[0]-=eps[0];x[1]-=eps2[1];x[2]-=eps2[2];

        graph.AddEdge(n000, c);
        graph.AddEdge(n001, c);
        graph.AddEdge(n010, c);
        graph.AddEdge(n011, c);
        graph.AddEdge(n100, c);
        graph.AddEdge(n101, c);
        graph.AddEdge(n110, c);
        graph.AddEdge(n111, c);

        graph.AddEdge(m01, c);
        graph.AddEdge(s01, c);
        graph.AddEdge(m02, c);
        graph.AddEdge(s02, c);
        graph.AddEdge(m12, c);
        graph.AddEdge(s12, c);

        graph.AddEdge(n000, n001);
        graph.AddEdge(n000, n010);
        graph.AddEdge(n000, n100);
        graph.AddEdge(n000, m01);
        graph.AddEdge(n000, m12);
        graph.AddEdge(n000, m02);
        
        graph.AddEdge(n001, n011);
        graph.AddEdge(n001, n101);
        graph.AddEdge(n001, m01);
        graph.AddEdge(n001, m02);
        graph.AddEdge(n001, s12);
        
        graph.AddEdge(n010, n011);
        graph.AddEdge(n010, n110);
        graph.AddEdge(n010, m12);
        graph.AddEdge(n010, m01);
        graph.AddEdge(n010, s02);
        
        graph.AddEdge(n100, n110);
        graph.AddEdge(n100, n101);
        graph.AddEdge(n100, m12);
        graph.AddEdge(n100, m02);
        graph.AddEdge(n100, s01);

        graph.AddEdge(n011, n111);
        graph.AddEdge(n011, m01);
        graph.AddEdge(n011, s02);
        graph.AddEdge(n011, s12);
        
        graph.AddEdge(n101, n111);
        graph.AddEdge(n101, m02);
        graph.AddEdge(n101, s01);
        graph.AddEdge(n101, s12);
                
        graph.AddEdge(n110, n111);
        graph.AddEdge(n110, m12);
        graph.AddEdge(n110, s02);
        graph.AddEdge(n110, s01);
        
        graph.AddEdge(n111, s01);
        graph.AddEdge(n111, s02);
        graph.AddEdge(n111, s12);     
    
      } else ATLASSERT(false);
}

    
    
    