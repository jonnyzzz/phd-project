#include "StdAfx.h"
#include ".\pointgraph.h"

#include <iostream>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



PointGraph::PointGraph(ISystemFunction* function, int dimension):
function(function), dimension(dimension), 
manager((2*sizeof(Node)+4*sizeof(double)*dimension+sizeof(Edge))*100)    
{
    function_input = function->getInput();
    function_output = function->getOutput();
    edge_counter = 0;
    cheched_counter = 0;
}

PointGraph::~PointGraph(void)
{
    
}

void PointGraph::Reset() {
    manager.Reset();
    nodes.clear();
    edges.clear();

    edge_counter = 0;
    cheched_counter = 0;
}

PointGraph::Edge* PointGraph::createEdge() {
    return manager.Allocate<Edge>();
}

PointGraph::Node* PointGraph::createNode() {
    return manager.AllocateDisposable<Node>();
}

void inline PointGraph::arraycopy(double* to, const double* from) {
    memcpy(to, from, sizeof(double)*dimension);
}

double* PointGraph::createArray() {
    return manager.AllocateArray<double>(dimension);
}

double* PointGraph::arraycopy(const double* node) {
    double* myDouble = createArray();
    arraycopy(myDouble, node);
    return myDouble;
}

PointGraph::Edge* PointGraph::AddEdge(PointGraph::Node* left, PointGraph::Node* right) {
    Edge* edge = createEdge();
    edge->left = left;
    edge->right = right;
    edge->checked = false;

    left->edges.push_back(edge);
    right->edges.push_back(edge);
    
    edge_counter++;

    edges.push_back(edge);

    cout<<"\nAdded edge "<<edge->left->points[0]<<"->"<<edge->right->points[0]<<"";

    return edge;
}

PointGraph::Node* PointGraph::AddNodeInternal(double* node) {
    Node* myNode = createNode();
    myNode->points = node;
    myNode->valueCache = NULL;

    nodes.push_back(myNode);

    return myNode;
}

PointGraph::Node* PointGraph::AddNode(const double* node) {
    double* myDouble = arraycopy(node);
    
    return AddNodeInternal(myDouble);
}

void PointGraph::evaluateNodeCache(PointGraph::Node* node) {
    if (node->valueCache != NULL) return;

    arraycopy(function_input, node->points);
    function->evaluate();
    node->valueCache = arraycopy(function_output);
}

double inline PointGraph::Abs(double x) {
    return x>0 ? x : -x;
}

double PointGraph::distance(double* left, double* right) {
    double cache = 0;
    for (int i=0; i<dimension; i++) {
        cache += Abs(left[i] - right[i]);
    }
    return cache;
}

double PointGraph::evaluateEdgeLength(PointGraph::Edge* edge) {
    evaluateNodeCache(edge->left);
    evaluateNodeCache(edge->right);

    return distance(edge->left->valueCache, edge->right->valueCache);    
}

PointGraph::Node* PointGraph::split(PointGraph::Edge* edge) {
    Node* left = edge->left;
    Node* right = edge->right;
    
    edge_counter--;

    double* myDouble = createArray();
    for (int i=0; i<dimension; i++) {
        myDouble[i] = (left->points[i] + right->points[i])/2;
    }

    left->edges.remove(edge);
    right->edges.remove(edge);
    edges.remove(edge);

    Node* myNode = AddNodeInternal(myDouble);

    /*
    for (EdgeList::iterator it = left->edges.begin(); it != left->edges.end(); ++it) {
        AddEdge(myNode, *it, left);
    }
    for (EdgeList::iterator it = right->edges.begin(); it != right->edges.end(); ++it) {
        AddEdge(myNode, *it, right);
    }
    */

    AddEdge(myNode, right);
    AddEdge(left, myNode);

    return myNode;
}

PointGraph::Edge* PointGraph::AddEdge(PointGraph::Node* newNode, PointGraph::Edge* edge, PointGraph::Node* from) {
    //if (edge->left == newNode || edge->right == newNode) return NULL;

    if (edge->left == from) {
        return AddEdge(newNode, edge->right);
    } else {
        return AddEdge(newNode, edge->left);
    }
}

PointGraph::Node*  PointGraph::AddNodeWithAllEdges(const double* node) {
    Node* myNode = AddNode(node);

    for (NodeList::iterator it = nodes.begin(); it != nodes.end(); ++it) {
        if (*it != myNode) {
            AddEdge(myNode, *it);
        }
    }
    return myNode;
}


void PointGraph::Iterate(double precision) {

    while (!edges.empty()) {
        Edge* edge = edges.front();
        edges.pop_front();

        cout<<"Processing edge "<<edge->left->points[0]<<"->"<<edge->right->points[0]<<" :";
        
        if (edge->checked) continue;

        double dist = evaluateEdgeLength(edge);
        if (dist >= precision) {
            cout<<"split";
            split(edge);
        } else {
            cout<<"OK";
            edge->checked = true;
            this->cheched_counter++;
        }

        cout<<"\n";
    }
}

const PointGraph::NodeList& PointGraph::Points() {
    return nodes;
}


void PointGraph::Dump(ostream& o) {
    o<<"\n\nDumping Point Graph\nNodes = "<<nodes.size()<<"\n";

    int cnt = 0;
    for (NodeList::iterator it = nodes.begin(); it != nodes.end(); ++it) {
        cnt++;
        cout<<"Node["<<cnt<<"]->Edges="<<(*it)->edges.size()<<"\n";
    }
    cout<<"\n\n";

    for (NodeList::iterator it = nodes.begin(); it != nodes.end(); ++it) {
        cout<<"Node "<<(*it)->points[0]<<" -> ";
        for (EdgeList::iterator itt = (*it)->edges.begin(); itt != (*it)->edges.end(); itt++) {
            Node* tmp;
            if ((*itt)->left == *it) {
                tmp = (*itt)->right;
            } else {
                tmp = (*itt)->left;
            }

            cout<<"Node["<<tmp->points[0]<<"], ";
        }
        cout<<"\n";
    }
    cout<<"\n";
}      