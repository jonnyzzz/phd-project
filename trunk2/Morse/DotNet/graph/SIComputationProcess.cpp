// SIComputationProcess.cpp: implementation of the SIComputationProcess class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "SIComputationProcess.h"
#include "Graph.h"
#include "Function.h"
#include "../cellImagebuilders/ProgressBarInfo.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

SIComputationProcess::SIComputationProcess(Function* function, Graph* graph, JInt* factor, ProgressBarInfo* info) :
 dimention(graph->getDimention()), graph(graph), factor(factor), function(function), info(info)
{
	 x   = function->getVariables();
	 x0  = new JDouble[dimention];
	 min = new JDouble[dimention];
	 max = new JDouble[dimention];

	 b = new JInt[dimention + 1];
	 c = new JInt[dimention + 1];
	 point = new JInt[dimention];

	 this->factor = new JInt[dimention+1];
	 for (int i=0; i<dimention; i++) {
		 this->factor[i] = factor[i];
	 }
	 	 
	 dest = createGraph();
}

SIComputationProcess::~SIComputationProcess()
{
	delete[] min;
	delete[] max;
	delete[] x0;

	delete[] b;
	delete[] point;
	delete[] c;

	delete[] factor;
}


//////////////////////////////////////////////////////////////////////

Graph* SIComputationProcess::createGraph() {
	for (int i=0; i<dimention; i++) {
		point[i] = graph->getGrid()[i]*factor[i];
	}
	return new Graph(dimention, graph->getMin(), graph->getMax(), point);	
}


void SIComputationProcess::nextStep(Graph* graph) {

	ASSERT(graph->equals(this->graph));
	ASSERT(info != NULL);
	this->graph = graph;

	int c = 0;
	int step = graph->getNumberOfNodes() / info->Length();

	NodeEnumerator* en = graph->getNodeRoot();
	Node* node;
	while (node = graph->getNode(en)) {
		this->buildNodeMultiplication(node);
		c++;
		if (c > step) {
			c = 0;
			step = graph->getNumberOfNodes() / info->Length();
			info->Next();
		}
	}
	graph->freeNodeEnumerator(en);
}

Graph* SIComputationProcess::getComputationResult() {
	return dest;
}


void SIComputationProcess::buildNodeMultiplication(Node* node) {
	for (int i=0; i<=dimention; i++) {
		b[i] = 0;
	}

	while (b[dimention] == 0) {
		
		for (i=0; i<dimention; i++) {
			point[i] = (graph->getCells(node)[i])*factor[i] + b[i];
		}
		Node* n = dest->browseTo(point);
		
		ASSERT(n != NULL);
		
		this->buildNodeImage(n);

		b[0]++;
		for ( i=0;i<dimention;i++) {
			if (b[i] >= factor[i]) {
				b[i] = 0;
				b[i+1]++;
			}
		}		
	}
}

//int count = 0;

void SIComputationProcess::buildNodeImage(Node* node) {
	for (int i=0; i<dimention; i++) {
		c[i] = 0;
		x0[i] = dest->toExternal((dest->getCells(node)[i]),i);
		x[i] = x0[i] + (dest->getEps()[i])/2;
	}
	c[dimention] = 0;

	function->t();

	JDouble t;
	for (i=0;i<dimention;i++) {
		t = function->tF(i);
		min[i] = t;
		max[i] = t;
	}

	while (c[dimention] == 0) {
		for (i=0; i<dimention; i++) {
			x[i] = x0[i] + ((c[i]==1)?(dest->getEps()[i]):0);
		}
		c[0]++;
		for (i=0; i<dimention; i++) {
			t = function->tF(i);
			if (t < min[i]) min[i] = t;
			if (t > max[i]) max[i] = t;
			if (c[i] > 1) {
				c[i] = 0;
				c[i+1]++;
			}
		}
	}

	dest->addEdges(node, min, max);
}