#include "StdAfx.h"
#include ".\ms2computationprocess.h"
#include ".\Graph.h"
#include ".\Function.h"
#include ".\FileStream.h"
#define _USE_MATH_DEFINES
#include <Math.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



MS2ComputationProcess::MS2ComputationProcess(Function* function, Graph* graph, JInt* factor) :
function(function), parent(graph)
{
	cout<<"MS2 Computation process\n";

	fDimension = 2;
	dimension = 3;

	x   = function->getVariables();
	x0  = new JDouble[dimension];
	v   = new JDouble[dimension];
	min = new JDouble[dimension];
	max = new JDouble[dimension];


	b = new JInt[dimension + 1];
	c = new JInt[dimension + 1];
	point = new JInt[dimension+1];

	this->factor = new JInt[dimension + 1];
	for (int i=0; i<dimension; i++) {
		this->factor[i] = factor[i];
	}

	result = createGraph();    
}

MS2ComputationProcess::~MS2ComputationProcess(void)
{
	delete[] x0;
	delete[] v;
	delete[] min;
	delete[] max;

	delete[] b;
	delete[] c;

	delete[] point;
}


int inline MS2ComputationProcess::Factor(int i) {
	return factor[i];
}


Graph* MS2ComputationProcess::getResult() {
	return result;
}

Graph* MS2ComputationProcess::createGraph() {
	for (int i=0; i<dimension; i++) {
		point[i] = parent->getGrid()[i] * Factor(i);
	}
	return new Graph(dimension, parent->getMin(), parent->getMax(), point); 
}

JDouble inline MS2ComputationProcess::Abs(JDouble x) {
	return (x>0)?x:-x;
}


JDouble MS2ComputationProcess::tR() {
	JDouble ret0 = function->tdF(0, 0)*cos(x[2]) + function->tdF(0, 1)*sin(x[2]);
	JDouble ret1 = function->tdF(1, 0)*cos(x[2]) + function->tdF(1, 1)*sin(x[2]);
	double ret = atan2(ret1, ret0);
	ret = (ret>0)?ret:(ret+M_PI);
	VERIFY(ret >= 0);
	return ret;
}


void MS2ComputationProcess::nextStep(Graph* graph) {
	if (!graph->equals(this->parent)) {
		cout<<"Unable to continue;";
		return;
	}

	this->graph = graph;

	NodeEnumerator* en = graph->getNodeRoot();
	Node* node;
	while (node = graph->getNode(en)) {
		this->buildNodeMultiplication(node);
	}
	graph->freeNodeEnumerator(en);
}


void MS2ComputationProcess::buildNodeMultiplication(Node* node) {
	for (int i=0; i<=dimension; i++) {
		b[i] = 0;
	}

	while (b[dimension] == 0) {      
		for (i=0; i<dimension; i++) {
			point[i] = (graph->getCells(node)[i]) * Factor(i) + b[i];
		}
		Node* n = result->browseTo(point);

		ASSERT(n != NULL);

		this->buildNodeImage(n);

		b[0]++;
		for ( i=0;i<dimension;i++) {
			if (b[i] >= Factor(i)) {
				b[i] = 0;
				b[i+1]++;
			}
		}     
	}
}


void MS2ComputationProcess::buildNodeImage(Node* node) {

	//Init point      3
	for (int i=0; i<dimension; i++) {
		c[i] = 0;
		x0[i] = result->toExternal((result->getCells(node)[i]),i);
		x[i] = x0[i] + (result->getEps()[i])/2;
	}
	c[dimension] = 0;

	//tAYLOR INIT
	function->t();


	//MS
	JDouble rc = tR();
	x[2] -= result->getEps()[2]/2;
	JDouble rl = tR();
	x[2] += result->getEps()[2];
	JDouble rr = tR();

	//SI
	JDouble t;
	for (i=0;i<fDimension;i++) {
		t = function->tF(i);
		min[i] = t;
		max[i] = t;
	}

	while (c[fDimension] == 0) {
		for (i=0; i<fDimension; i++) {
			x[i] = x0[i] + ((c[i]==1)?(result->getEps()[i]):0);
		}
		c[0]++;
		for (i=0; i<fDimension; i++) {
			t = function->tF(i);
			if (t < min[i]) min[i] = t;
			if (t > max[i]) max[i] = t;
			if (c[i] > 1) {
				c[i] = 0;
				c[i+1]++;
			}
		}
	}

	if (rl >= rr) {
		swap(rl, rr);
	}

	//Selection
	if ((rl <= rc) && (rc <= rr)) {
		min[2] = rl;
		max[2] = rr;
		result->addEdges(node, min, max);
	} else {
		min[2] = 0;
		max[2] = rl;
		result->addEdges(node, min, max);

		min[2] = rr;
		max[2] = M_PI;
		result->addEdges(node, min, max);
	}
}