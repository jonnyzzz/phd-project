#pragma once

#include <list>
using namespace std;
#include "../SystemFunction/ISystemFunction.h"
#include "../graph/ExtendedMenoryManager.h"

class PointGraph
{
public:
    PointGraph(ISystemFunction* function, int dimension);
    virtual ~PointGraph(void);

public:

    class Node;
    class Edge;
    typedef list<Edge*> EdgeList;
    typedef list<Node*> NodeList;

    class PointGraph::Edge {
    public:
        PointGraph::Node* left;
        PointGraph::Node* right;
        bool checked;      
    };

    class PointGraph::Node : public ExtendedMemoryManager::DisposeHandler {
    public:
        virtual ~Node() {};
    public:
        double* points;
        double* valueCache;
        PointGraph::EdgeList edges;
    };



private:
    Edge* createEdge();
    Node* createNode();
    double* createArray();



public:
    Edge* AddEdge(Node* left, Node* right); //no duplicate checking!
    Node* AddNode(const double* node); //no duplicate checking!
    Node* AddNodeWithAllEdges(const double* node);

    void evaluateNodeCache(Node* node);
    double evaluateEdgeLength(Edge* edge);

    Node* split(Edge* edge);

    void Iterate(double precision);

    const NodeList& Points();

    void Reset();
        
private:
    ISystemFunction* function;
    int dimension;
    ExtendedMemoryManager manager;

    NodeList nodes;
    EdgeList edges;

    int edge_counter;
    int cheched_counter;

private:
    double* function_input;
    double* function_output;

private:
    double* arraycopy(const double* x);
    void arraycopy(double* to, const double* from);

    double distance(double* left, double* right);

    Node* AddNodeInternal(double* node);

    double Abs(double x);

    Edge* AddEdge(Node* newNode, Edge* edge, Node* from);


public:

    void Dump(ostream& o);
    
};
