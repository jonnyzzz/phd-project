#include "StdAfx.h"
#include ".\abstractboxprocess.h"
#include "../graph/graphutil.h"

AbstractBoxProcess::AbstractBoxProcess(Graph* graph, SystemFunction* function, int* factor, ProgressBarInfo* pinfo) : 
	AbstractProcess(graph, pinfo), function(function), factor(factor)
{
	this->input = function->getInput();
	this->output = function->getOutput();

	ASSERT(graph_source != NULL);

	this->dimension = graph_source->getDimention();

	this->x0 = new JDouble[dimension+1];
	this->b = new JInt[dimension+1];
	this->value_min = new JDouble[dimension];
	this->value_max = new JDouble[dimension];
	this->a = new JInt[dimension+1];
	this->point = new JInt[dimension];
	this->pointT = new JInt[dimension];
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
}


void AbstractBoxProcess::start() {
	AbstractProcess::start();

	submitGraphResult(createGraph());
}


void AbstractBoxProcess::processNextGraph(Graph* graph) {

	GraphNodeEnumerator ne(graph);
	Node* node;
	while (node = ne.next()) {
		multiplyNode(node, graph);
	}
}

Graph* AbstractBoxProcess::createGraph() {
	return graph_source->copyCoordinatesDevided(factor);
}

void AbstractBoxProcess::multiplyNode(Node* node, Graph* graph) {
	for (int i=0; i<dimension; i++) {
		point[i] = graph->getCells(node)[i];
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
			if (a[i] > factor[i]) {
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
		x0[i] = graph->toExternal(graph->getCells(node)[i], i);
	}

	bool isFirst = true;

	while (b[dimension] == 0) {
		for (int i=0; i<dimension; i++) {
			input[i] = x0[i] + graph->getEps()[i];
		}

		function->evaluate();

		if (isFirst) {
			vectorCopy(output, value_min);
			vectorCopy(output, value_max);
		} else {
			for (int i=0; i<dimension; i++) {
				if (output[i] > value_max[i]) {
					value_max[i] = output[i];
				}

				if (output[i] < value_min[i]) {
					value_min[i] = output[i];
				}
			}
		}

		b[0]++;
		isFirst = false;

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
