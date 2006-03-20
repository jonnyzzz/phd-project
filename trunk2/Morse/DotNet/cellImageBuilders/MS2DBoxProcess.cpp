#include "stdafx.h"
#include "MS2DBoxProcess.h"
#include "../graph/Graph.h"
#include "../graph/GraphUtil.h"
#include "../graph/GraphException.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MS2DBoxProcess::MS2DBoxProcess(MS2DAngleFunction* function, Graph* original, GraphSet si, int* factor, ProgressBarInfo* info)
:AbstractProcessExt(original, info), siGraph(si), function(function)
{
    this->dimension = original->getDimention();
    VERIFY(dimension == 3);
    VERIFY(factor[0] == factor[1] == 1);

    this->factor = new int[dimension];
	memcpy(this->factor, factor, sizeof(int)*dimension);

    this->input = function->getInput();
    this->output = function->getOutput();
    this->x = new JDouble[dimension];
    this->xi = new JInt[dimension];
    this->amin = new JDouble[dimension];
    this->amax = new JDouble[dimension];
}

MS2DBoxProcess::~MS2DBoxProcess(void)
{
    delete[] factor;
    delete[] x;
    delete[] xi;
    delete[] amin;
    delete[] amax;
}



void MS2DBoxProcess::start() {
    AbstractProcessExt::start();

    submitGraphResult(graph_source->copyCoordinatesDevided(factor));
}


void MS2DBoxProcess::processNextGraph(Graph* graph) {

	ProgressBarAdapter ad(info, graph->getNumberOfNodes());
	
	cout<<"Processing Next graph nodes: "<<graph->getNumberOfNodes()<<"\n";

	GraphNodeEnumerator ne(graph);
	Node* node;
	while ((node = ne.next())!= NULL) {		
		multiplyNode(node, graph);
		if (!ad.Next())
			break;
	}
}


pair<Node*,Graph*> MS2DBoxProcess::FindSIGraphNode(const JInt* coord) {
    for (GraphSetIterator it = siGraph.iterator(); it.HasNext(); it.Next()) {
        Node* node = it->findNode(coord);
        if (node != NULL) 
            return pair<Node*,Graph*>(node, it);
    }  

    ASSERT(false);
    throw GraphException(GraphException_NoSuchResult);
}

void MS2DBoxProcess::multiplyNode(Node* node, Graph* graph) {

    SegmentList segments;

    const JInt* coord = graph->getCells(node);
    pair<Node*,Graph*> siGraphNode = FindSIGraphNode(coord);
    Graph* siGraph = siGraphNode.second;
    Node* originalGraphNode = siGraphNode.first;

    ATLASSERT(originalGraphNode != NULL);

    xi[0] = coord[0];
    xi[1] = coord[1];
    xi[2] = coord[2] * factor[2];

    //center point
    input[0] = graph->toExternal(coord[0], 0) + graph->getEps()[0]/2;
    input[1] = graph->toExternal(coord[1], 1) + graph->getEps()[1]/2;

    function->evaluateFunction();


    for (int step = 0; step < factor[2]; step++) {
        
        Node* resultNode = graph_result->browseTo(xi);

        ATLASSERT(resultNode != NULL);

        processNode(resultNode, segments);

        xi[2]++;
    }

    
    GraphEdgeEnumerator ee(siGraph, originalGraphNode);
    Node* toNode;
    while( (toNode = ee.nextTo()) != NULL) {
        //amin[0] = amax[0] = siGraph->toExternal(siGraph->getCells(toNode)[0],0) + siGraph->getEps()[0]/2;
        //amin[1] = amax[1] = siGraph->toExternal(siGraph->getCells(toNode)[1],1) + siGraph->getEps()[1]/2;

        for (SegmentList::iterator it = segments.begin(); it != segments.end(); it++) {
            amin[2] = it->left;
            amax[2] = it->right;
            graph_result->addEdgesPartial(it->node, 2, siGraph->getCells(toNode), amin, amax);
        }        
    }
}


void MS2DBoxProcess::processNode(Node* resultNode, SegmentList& list) {
    double left;
    double center;
    double right;
       
    input[2] = graph_result->toExternal(graph_result->getCells(resultNode)[2],2);
    left = function->evaluateAngle();

    input[2]+= graph_result->getEps()[2]/2;
    center = function->evaluateAngle();

    input[2]+= graph_result->getEps()[2]/2;
    right = function->evaluateAngle();

    if (right < left) {
        double t = left;
        left = right;
        right = t;
    }

    //cout<<"["<<left<<", "<<center<<", "<<right<<"\n";
    
    if (left <= center && center <= right) {
        list.push_back(Segment(resultNode, left, right));        
    } else {
        list.push_back(Segment(resultNode, -M_PI_2, left));
        list.push_back(Segment(resultNode, right, M_PI_2));
    }    
}
