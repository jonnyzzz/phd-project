#include "StdAfx.h"
#include ".\adaptiveprocessbase.h"
#include "..\graph\graphUtil.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


AdaptiveProcessBase::AdaptiveProcessBase(ISystemFunction* function, Graph* graph, JInt* division, double* precision, ProgressBarInfo* info)
: AbstractProcess(info), rootGraph(graph), function(function)
{
    this->dimension = graph->getDimention();
    this->resultGraph = graph->copyCoordinatesDevided(division);
    this->division = new int[dimension];
    this->x = new JInt[dimension];
    this->b = new JInt[dimension+1];
    this->precision = new JDouble[dimension];

    for (int i=0; i<dimension; i++) {
        this->division[i] = division[i];    
        this->precision[i] = precision[i];
    }
}

AdaptiveProcessBase::~AdaptiveProcessBase(void)
{
    delete[] precision;
    delete[] division;
    delete[] x;
    delete[] b;
}


GraphSet AdaptiveProcessBase::results() {
    return GraphSet(resultGraph);
}


void AdaptiveProcessBase::processNextGraph(Graph* graph) {
	int maxCnt = graph->getNumberOfNodes()/info->Length()+1;
	int cnt = 0;

    GraphNodeEnumerator en(graph);
    Node* node;
    while (node = en.next()) {
        processNode(graph, node);
		if (cnt++ > maxCnt) {
			cnt = 0;
			info->Next();
		}
    }
}

void AdaptiveProcessBase::processNode(Graph* graph, Node* node) {
    	
    ZeroMemory(b, sizeof(JInt)*(dimension+1));

    while (b[dimension] == 0) {
        for (int i=0; i<dimension; i++) {
            x[i] = graph->getCells(node)[i]*division[i] + b[i];
        }

        Node* resultNode = resultGraph->browseTo(x);
        //cout<<"\n\nNode....\n\n";

        processResultNode(resultNode);               
        
        b[0]++;
        for (int i=0; i<dimension; i++) {
            if (b[i] >= division[i]) {
                b[i] = 0;
                b[i+1] ++;
            } else {
                break;
            }
        }
    }
}
