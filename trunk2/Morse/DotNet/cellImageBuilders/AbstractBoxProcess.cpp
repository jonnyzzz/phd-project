#include "StdAfx.h"
#include ".\abstractboxprocess.h"
#include "../graph/graphutil.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


AbstractBoxProcess::AbstractBoxProcess(Graph* graph, ISystemFunction* function, int* factor, ProgressBarInfo* pinfo) : 
	AbstractProcessExt(graph, pinfo), function(function)
{
	this->input = function->getInput();
	this->output = function->getOutput();

	ASSERT(graph_source != NULL);

	this->hasDerivate = function->hasDerivative();
	

	this->dimension = graph_source->getDimention();
	this->dimension2 = dimension*dimension + dimension;

	this->v0 = new JDouble[dimension2];

	this->x0 = new JDouble[dimension+1];
	this->b = new JInt[dimension+1];
	this->value_min = new JDouble[dimension];
	this->value_max = new JDouble[dimension];
	this->a = new JInt[dimension+1];
	this->point = new JInt[dimension+1];
	this->pointT = new JInt[dimension+1];
	this->eps2 = new JDouble[dimension];
	this->eps = new JDouble[dimension];
	this->factor = new int[dimension];
	memcpy(this->factor, factor, sizeof(int)*dimension);
}

AbstractBoxProcess::~AbstractBoxProcess(void)
{
	delete[] x0;
	delete[] b;
	delete[] value_max;
	delete[] value_min;
	delete[] a;
	delete[] point;
	delete[] pointT;
	delete[] eps2;
	delete[] eps;
	delete[] factor;
	delete[] v0;
}


void AbstractBoxProcess::start() {
	AbstractProcessExt::start();

	submitGraphResult(createGraph());


	for (int i=0; i<dimension; i++) {
		eps[i] = graph_result->getEps()[i];
		eps2[i] = eps[i]/2;
	}

}


void AbstractBoxProcess::processNextGraph(Graph* graph) {

	int maxCnt = info->Length();
	int cnt = 0;

	cout<<"Processing Next graph nodes: "<<graph->getNumberOfNodes()<<"\n";

	GraphNodeEnumerator ne(graph);
	Node* node;
	while (node = ne.next()) {
		cnt++;
		multiplyNode(node, graph);
		if (cnt > maxCnt) {
			cnt = 0;
			info->Next();
		}
	}
}

Graph* AbstractBoxProcess::createGraph() {
	return graph_source->copyCoordinatesDevided(factor);
}

void AbstractBoxProcess::multiplyNode(Node* node, Graph* graph) {
	for (int i=0; i<dimension; i++) {
		point[i] = graph->getCells(node)[i]*factor[i];
		a[i] = 0;
	}
	a[dimension] = 0;

	while (a[dimension] == 0 ) {
		for (int i=0; i<dimension; i++) {
			pointT[i] = point[i] + a[i];
		}

		Node* newNode = graph_result->browseTo(pointT);
		if (newNode != NULL) {
			processNode(newNode, graph_result);
		}

		a[0]++;

		for (int i=0; i<dimension; i++) {
			if (a[i] >= factor[i]) {
				a[i] = 0;
				a[i+1]++;
			}
		}
	}
}

void AbstractBoxProcess::processNode(Node* node, Graph* graph) {

	b[dimension] = 0;
	for (int i=0; i<dimension; i++) {
        b[i] = 0;
		x0[i] = graph_result->toExternal(graph_result->getCells(node)[i], i);
		input[i] = x0[i] + eps2[i];
	}
	
	setApproximationCenter();
	
	vectorCopy(output, value_min);
	vectorCopy(output, value_max);

	while (b[dimension] == 0) {
		for (int i=0; i<dimension; i++) {
			input[i] = x0[i] + ((b[i]==1)?eps[i]:0.0);
		}

		evaluate();

		for (int i=0; i<dimension; i++) {
			if (output[i] > value_max[i]) {
				value_max[i] = output[i];
			}

			if (output[i] < value_min[i]) {
				value_min[i] = output[i];
			}
		}

		b[0]++;

		for (int i=0; i<dimension; i++) {
			if (b[i] > 1) {
				b[i] = 0;
				b[i+1]++;
			}
		}
	}

	processNodeAndImage(value_min, value_max, node, graph);
}


void AbstractBoxProcess::vectorCopy(JDouble* from, JDouble* to) {
	memcpy(to, from, sizeof(JDouble)*dimension);
}



void AbstractBoxProcess::setApproximationCenter() {
	function->evaluate();
	if (hasDerivate) {		
		memcpy(output, v0, sizeof(JDouble)*dimension2);
	}
}


void AbstractBoxProcess::evaluate() {
	if (hasDerivate) {
		for (int i=0; i<dimension; i++) {
			JDouble t = v0[i];
			for (int j=0; j<dimension; j++) {
				t += v0[dimension + dimension*i + j]*input[j];
			}
			output[i] = t;
		}
	} else {
		function->evaluate();
	}
}
