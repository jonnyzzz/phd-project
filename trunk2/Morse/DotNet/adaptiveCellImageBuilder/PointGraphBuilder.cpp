#include "stdafx.h"
#include "PointGraphBuilder.h"
#include <math.h>

PointGraphBuilder::PointGraphBuilder(int dimension, double* eps, PointGraph& graph) :
dimension(dimension), eps(eps), graph(graph)
{
    mx = 1;
    eps2 = new double[dimension];
    for (int i=0; i<dimension; i++) {
        eps2[i] = eps[i]/2;
        mx*=3;
    }
    b = new int[dimension];    
    node = new PointGraph::Node*[mx];
    for (int i=0; i<mx; i++) {
        node[i] = NULL;
    }
    double* fx = new double[dimension];
    double* x = new double[dimension];
}

PointGraphBuilder::~PointGraphBuilder(void)
{
    delete[] eps2;
    delete[] b;
    delete[] fx;
    delete[] node;
    delete[] x;
}

PointGraph::Node* PointGraphBuilder::FindNode(const int* b) {
    int index = 0;
    int pow = 1;
    for(int i=0; i<dimension; i++) {
        index += b[i]*pow;
        pow *= 3;
    }

    if (node[index] == NULL) {
        for (int i=0; i<dimension; i++) {
            fx[i] = x[i] + b[i]*eps2[i];
        }
        node[index] = graph.AddNode(fx);
    }
    return node[index];
}



void PointGraphBuilder::Build2D(const int* b0, const int* ax0, const int* ax1) {
    for (int i=0; i<dimension; i++) {
        b[i] = b0[i];
    }

    PointGraph::Node* n00 = FindNode(b);
    for (int i=0; i<dimension; i++) {
        b[i] = b0[i] + 2*ax0[i];
    }    
    PointGraph::Node* n10 = FindNode(b);
    for (int i=0; i<dimension; i++) {
        b[i] = b0[i] + 2*ax1[i];
    }    
    PointGraph::Node* n01 = FindNode(b);
    for (int i=0; i<dimension; i++) {
        b[i] = b0[i] + 2*ax0[i] + 2*ax1[i];
    }    
    PointGraph::Node* n11 = FindNode(b);
    for (int i=0; i<dimension; i++) {
        b[i] = b0[i] + ax0[i] + ax1[i];
    }    
    PointGraph::Node* c = FindNode(b);

    graph.AddEdge(n00, n10);
    graph.AddEdge(n10, n11);
    graph.AddEdge(n11, n01);
    graph.AddEdge(n01, n00);
    graph.AddEdge(n00, c);
    graph.AddEdge(n10, c);
    graph.AddEdge(n01, c);
    graph.AddEdge(n11, c);

}


void PointGraphBuilder::BuildInitialGraph(double* x) {
    graph.Reset();
    for (int i=0; i<mx; i++) {
        node[i] = NULL;
    }
    if (dimension == 1) {
        PointGraph::Node* n1 = graph.AddNode(x);
        x[0]+= eps[0];
        PointGraph::Node* n2 = graph.AddNode(x);
        graph.AddEdge(n1, n2);
    } else if (dimension == 2) {
        PointGraph::Node* n00 = graph.AddNode(x);
        x[0]+= eps[i];
        PointGraph::Node* n10 = graph.AddNode(x);
        x[0]-= eps[i];
        x[1]+= eps[i];
        PointGraph::Node* n01 = graph.AddNode(x);
        x[0]+= eps[i];
        PointGraph::Node* n11 = graph.AddNode(x);
        x[0]-= eps2[i];
        x[1]-= eps2[i];
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
        x[0]+=eps2[0]; x[1]-=eps2[1]; x[2]-=eps2[2];
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
    }
}
