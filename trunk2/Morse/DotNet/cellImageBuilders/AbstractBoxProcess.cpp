#include "stdafx.h"
#include "AbstractBoxProcess.h"
#include "../graph/GraphUtil.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


AbstractBoxProcess::AbstractBoxProcess(Graph* graph, ISystemFunction* function, int* factor, ProgressBarInfo* pinfo) : 
	AbstractProcessExt(graph, pinfo), function(function), hasDerivate(function->hasDerivative()), 
	dimension(function->getFunctionDimension()),
	dimension2(function->getFunctionDimension()*function->getFunctionDimension() + function->getFunctionDimension()),
	graphDimension(graph->getDimention())
{
	this->input = function->getInput();
	this->output = function->getOutput();

	ASSERT(graph_source != NULL);
	ASSERT(dimension <= graphDimension);

	cout<<"Abstract box process with function dimension "<<dimension<<" and graph dimension "<<graphDimension<<endl;
		
	this->v0 = new JDouble[dimension2];
	this->vx0 = new JDouble[dimension];

	this->x0 = new JDouble[dimension+1];
	this->b = new JInt[graphDimension+1];
	this->value_min = new JDouble[graphDimension];
	this->value_max = new JDouble[graphDimension];
	this->a = new JInt[graphDimension+1];
	this->point = new JInt[graphDimension+1];
	this->pointT = new JInt[graphDimension+1];
	this->eps2 = new JDouble[graphDimension];
	this->eps = new JDouble[graphDimension];
	this->factor = new int[graphDimension];
	memcpy(this->factor, factor, sizeof(int)*graphDimension);
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
	delete[] vx0;
}


void AbstractBoxProcess::start() {
	AbstractProcessExt::start();

	submitGraphResult(createGraph());


	for (int i=0; i<graphDimension; i++) {
		eps[i] = graph_result->getEps()[i];
		eps2[i] = eps[i]/2;
	}

}


void AbstractBoxProcess::processNextGraph(Graph* graph) {

	ProgressBarAdapter ad(info, graph->getNumberOfNodes());

	cout<<"Processing Next graph nodes: "<<graph->getNumberOfNodes()<<"\n";

	GraphNodeEnumerator ne(graph);
	Node* node;
	while (node = ne.next()) {
		multiplyNode(node, graph);
		if (!ad.Next()) {
			break;
		}
	}
}

Graph* AbstractBoxProcess::createGraph() {
	return graph_source->copyCoordinatesDevided(factor, true);
}

void AbstractBoxProcess::multiplyNode(Node* node, Graph* graph) {
	for (int i=0; i<graphDimension; i++) {
		point[i] = graph->getCells(node)[i]*factor[i];
		a[i] = 0;
	}
	a[graphDimension] = 0;

	while (a[graphDimension] == 0 ) {
		for (int i=0; i<graphDimension; i++) {
			pointT[i] = point[i] + a[i];
		}

		Node* newNode = graph_result->browseTo(pointT);
		//if (newNode != NULL) {
			processNode(newNode, graph_result);
		//}

		a[0]++;

		for (int i=0; i<graphDimension; i++) {
			if (a[i] >= factor[i]) {
				a[i] = 0;
				a[i+1]++;
			} else break;
		}
	}
}

//b, x0, input, output, value_min, value_max
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
			input[i] = x0[i] + ((b[i]==1)?eps[i]:(JDouble)0.0);
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


void AbstractBoxProcess::vectorCopy(const JDouble* from, JDouble* to) {
	memcpy(to, from, sizeof(JDouble)*dimension);
}



void AbstractBoxProcess::setApproximationCenter() {
	function->evaluate();

	if (hasDerivate) {	
		memcpy(vx0, input, sizeof(JDouble)*dimension);
		memcpy(v0, output, sizeof(JDouble)*dimension2);
	}
}

const double* AbstractBoxProcess::getCurrentCenterPoint() {
	return vx0;
}

const double* AbstractBoxProcess::getCurrentCenterValue() {
	return v0;
}


void AbstractBoxProcess::evaluate() {
	if (hasDerivate) {
		for (int i=0; i<dimension; i++) {
			JDouble t = v0[i];
			for (int j=0; j<dimension; j++) {
				t += v0[dimension + dimension*i + j]*(input[j]-vx0[j]);
			}
			output[i] = t;
		}
	} else {
		function->evaluate();
	}
}
