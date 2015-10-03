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



PointGraph::PointGraph(ISystemFunction* function, int dimension, size_t upperLimit):
function(function), dimension(dimension), 
manager((2*sizeof(Node)+4*sizeof(double)*dimension+sizeof(Edge))*100),
upperLimit(upperLimit), maxSize(0)
{
	ATLASSERT(dimension > 0);
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
    myNode->checkedEdges = 0;
    
    nodes.push_back(myNode);

    return myNode;
}

PointGraph::Node* PointGraph::AddNode(const double* node) {
    double* myDouble = arraycopy(node);
	
	NormalizePoint(myDouble);
    
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

PointGraphAction PointGraph::checkEdgeLength(PointGraph::Edge* edge, double* precision) {
    evaluateNodeCache(edge->left);
    evaluateNodeCache(edge->right);
    
    return NeedDevideEdge(edge->left->valueCache, edge->right->valueCache, precision);
}

PointGraphAction PointGraph::NeedDevideEdge(const double* left, const double* right, const double* precision) {
    for (int i=0; i<dimension; i++) {
        if (Abs(left[i] - right[i]) > precision[i]){
            return PointGraph_Devide;
        }
    }
    return PointGraph_NotDevide;
}

double PointGraph::EdgeLength(const double* left, const double* right) {
    double length = 0;
    for (int i=0; i<dimension; i++) {
        length += Abs(left[i] - right[i]);
    }
    return length;
}

void PointGraph::EdgeLength(const double* left, const double* right, double* lengths) {
    for (int i=0; i<dimension; i++) {
        lengths[i] = Abs(left[i] - right[i]);
    }    
}


void PointGraph::ComputeMiddle(const double* left, const double* right, double* v) {
	for (int i=0; i<dimension; i++) {
        *v++ = (*left++ + *right++)/2;
    }
}

void PointGraph::NormalizePoint(double* v) {
}

PointGraph::Node* PointGraph::split(PointGraph::Edge* edge) {
    Node* left = edge->left;
    Node* right = edge->right;
    
    double* myDouble = createArray();
	ComputeMiddle(left->points, right->points, myDouble);

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

bool PointGraph::Iterate(double* precision) {

    while (!edges.empty()) {		
        Edge* edge = edges.front();
        edges.pop_front();
              
		switch(this->checkEdgeLength(edge, precision)) {
			case PointGraph_Devide: 
				split(edge);
				break;
			case PointGraph_NotDevide:
	            edge->left->checkedEdges++;
				edge->right->checkedEdges++;
				break;
        }

        if (upperLimit != 0 && nodes.size() > upperLimit) {
            return false;
        }
    }
    return true;
}

const PointGraph::NodeList& PointGraph::Points() {
	if (maxSize < nodes.size())
		maxSize = nodes.size();
    return nodes;
}


bool PointGraph::IsCheckedNode(PointGraph::Node* node) {
    return (node->checkedEdges == edges.size());
}

double PointGraph::NodeLength(PointGraph::Node* node, double* lengths) {
    evaluateNodeCache(node);
    double length;
    bool isCheck = false;
    Node* toLength = NULL;

    for (NodeSet::iterator it = node->edges.begin(); it != node->edges.end(); it++) {
        Node* to = *it;
        if (!IsCheckedNode(to)) {
            evaluateNodeCache(to);
            double len = EdgeLength(node->valueCache, to->valueCache);
            if (!isCheck || len > length) {
                isCheck = true;
                length = len;
                toLength = to;
            }
        }
    }

    EdgeLength(node->valueCache, toLength->valueCache, lengths);

    return length;
}


void PointGraph::DumpNode(PointGraph::Node* node, ostream& o) {
    for (int i=0; i<dimension; i++) {
        o<<node->points[i];
        if (i+1 != dimension)
            o<<", ";
    }
}

void PointGraph::Dump(ostream& o) {
    o<<"\n\nDumping Point Graph\nNodes = "<<nodes.size()<<"\n";
    o<<"Edges counter: \n";
    int cnt = 0;
    for (NodeList::iterator it = nodes.begin(); it != nodes.end(); ++it) {
        o<<"Node[";
        DumpNode((*it),o);
        o<<"]->Edges="<<(*it)->edges.size()<<"\n";
    }
    o<<"\n\n";

    o<<"Adj matrix :\n";
    for (NodeList::iterator it = nodes.begin(); it != nodes.end(); ++it) {
        o<<"Node[";
        DumpNode((*it), o);
        o<<"] -> ";
        for (NodeSet::iterator itt = (*it)->edges.begin(); itt != (*it)->edges.end(); itt++) {
            Node* tmp = *itt;            
            o<<"Node[";
            DumpNode(tmp, o);
            o<<"], ";
        }
        o<<"\n";
    }
    o<<"\n\n";
}      


size_t PointGraph::GetMaximumNumberOfPoints() {
	return maxSize;
}