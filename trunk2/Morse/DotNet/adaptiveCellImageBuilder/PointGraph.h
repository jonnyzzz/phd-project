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

    class Edge {
    public:
        Node* left;
        Node* right;
        bool checked;

        Edge* parent;
        int order;
    };

    class Node : public ExtendedMemoryManager::DisposeHandler {
    public:
        virtual ~Node() {};
    public:
        double* points;
        double* valueCache;
        EdgeList edges;
    };



private:
    Edge* createEdge();
    Node* createNode();
    double* createArray();



public:
    Edge* AddEdge(Node* left, Node* right, Edge* parent); //no duplicate checking!
    Node* AddNode(const double* node); //no duplicate checking!
    Node* AddNodeWithAllEdges(const double* node);

    void evaluateNodeCache(Node* node);
    bool chackEdgeLength(Edge* edge, double* precision);

    Node* split(Edge* edge);

    void Iterate(double* precision);

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

    bool ChechParentness(Edge* edgeR, Edge* edgeM);


public:

    void Dump(ostream& o);
    
};
