#include "StdAfx.h"
#include ".\pointgraphprocessor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


PointGraphProcessor::PointGraphProcessor(Graph* graph, ISystemFunction *function, int dimension, double* precision)
: graph(graph), dimension(dimension), pointGraph(graph, function, dimension),
  pointGraphBuilder(dimension, graph->getEps(), pointGraph)
{
    x = new JDouble[dimension];
    x0 = new JDouble[dimension];
    b = new JInt[dimension+1];
    a = new JInt[dimension+1];
    overlap1 = new JDouble[dimension];
    overlap2 = new JDouble[dimension];
    this->precision = new JDouble[dimension];
    for (int i=0; i<dimension; i++) {
        this->precision[i] = precision[i];
        overlap1[i] = precision[i];
        overlap2[i] = precision[i];
    }    
}

PointGraphProcessor::~PointGraphProcessor(void)
{
    delete[] x;
    delete[] x0;
    delete[] a;
    delete[] b;
    delete[] overlap1;
    delete[] overlap2;
    delete[] precision;
}


void PointGraphProcessor::ProcessNode(Node* node) {        
    pointGraph.Reset();

    for (int i=0; i<dimension; i++) {
        x[i] = graph->toExternal(graph->getCells(node)[i],i);
    }   
    pointGraphBuilder.BuildInitialGraph(x);
    
    pointGraph.Iterate(precision);

    const PointGraph::NodeList& list = pointGraph.Points();
    //cout<<"Out arcs: "<<list.size()<<"\n\n";
    for (PointGraph::NodeList::const_iterator it = list.begin(); it != list.end(); ++it) {
        graph->addEdgeWithOverlaping(node, (*it)->valueCache, overlap1, overlap2);
    }
}

PointGraphProcessor::PointGraphEx::PointGraphEx(Graph* graph, ISystemFunction* function, int dim) : PointGraph(function, dim), graph(graph) {}
PointGraphProcessor::PointGraphEx::~PointGraphEx() {}

double inline PointGraphProcessor::PointGraphEx::Abs(double x) {
    return (x>0)?x:-x;
}

bool PointGraphProcessor::PointGraphEx::NeedDevideEdge(const double* left, const double* right, const double* precision) {
    if (!graph->intersects(left) || !graph->intersects(right)) 
        return false;
    for (int i=0;i<dimension; i++) {
        if (Abs(left-right) > precision[i]) return false;
    }
    return true;
}