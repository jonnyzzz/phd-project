#pragma once

#include <list>
#include <set>
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
    typedef set<Node*> NodeSet;
    typedef list<Node*> NodeList;

    class Edge {
    public:
        Node* left;
        Node* right;        
    };

    class Node : public ExtendedMemoryManager::DisposeHandler {
    public:
        virtual ~Node() {};
    public:
        double* points;
        double* valueCache;
        NodeSet edges;
    };



private:
    Edge* createEdge();
    Node* createNode();
    double* createArray();

public:
    Edge* AddEdge(Node* left, Node* right); //no duplicate checking!
    Node* AddNode(const double* node); //no duplicate checking!

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

private:
    double* function_input;
    double* function_output;

private:
    double* arraycopy(const double* x);
    void arraycopy(double* to, const double* from);
    Node* AddNodeInternal(double* node);
    double Abs(double x);

public:

    void Dump(ostream& o);
    
};
