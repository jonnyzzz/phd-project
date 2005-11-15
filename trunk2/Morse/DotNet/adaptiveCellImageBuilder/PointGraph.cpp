#include "StdAfx.h"
#include ".\pointgraph.h"

#include <iostream>
#include <set>
#include <functional>

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
}

PointGraph::~PointGraph(void)
{
    
}

void PointGraph::Reset() {
    manager.Reset();
    nodes.clear();
    edges.clear();
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

    left->edges.insert(right);
    right->edges.insert(left);    
    edges.push_back(edge);

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

bool PointGraph::chackEdgeLength(PointGraph::Edge* edge, double* precision) {
    evaluateNodeCache(edge->left);
    evaluateNodeCache(edge->right);

    for (int i=0; i<dimension; i++) {
        if (Abs(edge->left->valueCache[i] - edge->right->valueCache[i]) > precision[i]){
            return false;
        }
    }
    return true;
}

PointGraph::Node* PointGraph::split(PointGraph::Edge* edge) {
    Node* left = edge->left;
    Node* right = edge->right;
    
    double* myDouble = createArray();
    for (int i=0; i<dimension; i++) {
        myDouble[i] = (left->points[i] + right->points[i])/2;
    }

    left->edges.erase(right);
    right->edges.erase(left);
    Node* myNode = AddNodeInternal(myDouble);

    NodeSet::const_iterator fst = left->edges.begin();
    NodeSet::const_iterator fst_e = left->edges.end();
    NodeSet::const_iterator snd = right->edges.begin();
    NodeSet::const_iterator snd_e = right->edges.end();
    NodeSet::key_compare cmp;

    while (fst != fst_e && snd != snd_e) {
        if (*fst == *snd) {
            AddEdge(myNode, *fst);
            fst++;
            snd++;
        } else {
            if (cmp(*fst, *snd)) { //fst < snd
                fst++;
            } else {
                snd++;
            }
        }
    }
       
    AddEdge(myNode, right);
    AddEdge(left, myNode);

    return myNode;
}

void PointGraph::Iterate(double* precision) {

    while (!edges.empty()) {
        Edge* edge = edges.front();
        edges.pop_front();
        
        if (!this->chackEdgeLength(edge, precision)) {
            split(edge);
        } 
    }
}

const PointGraph::NodeList& PointGraph::Points() {
    return nodes;
}


void PointGraph::Dump(ostream& o) {
    o<<"\n\nDumping Point Graph\nNodes = "<<nodes.size()<<"\n";
    o<<"Edges counter: \n";
    int cnt = 0;
    for (NodeList::iterator it = nodes.begin(); it != nodes.end(); ++it) {
        cout<<"Node["<<(*it)->points[0]<<"]->Edges="<<(*it)->edges.size()<<"\n";
    }
    cout<<"\n\n";

    cout<<"Adj matrix :\n";
    for (NodeList::iterator it = nodes.begin(); it != nodes.end(); ++it) {
        cout<<"Node "<<(*it)->points[0]<<" -> ";
        for (NodeSet::iterator itt = (*it)->edges.begin(); itt != (*it)->edges.end(); itt++) {
            Node* tmp = *itt;            
            cout<<"Node["<<tmp->points[0]<<"], ";
        }
        cout<<"\n";
    }
    cout<<"\n\n";
}      