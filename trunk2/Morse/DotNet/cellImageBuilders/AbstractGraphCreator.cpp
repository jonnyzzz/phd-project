#include "stdafx.h"
#include "AbstractGraphCreator.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



AbstractGraphCreator::AbstractGraphCreator(Graph* graph, int* factor, ProgressBarInfo* info) :
factor(factor), AbstractProcessExt(graph, info)
{
	dimensionOld = graph->getDimention();

	b = NULL;
	point = NULL;
	tpoint = NULL;
}

AbstractGraphCreator::~AbstractGraphCreator(void)
{
    if (b != NULL) {
	    delete[] b;
	    delete[] point;
	    delete[] tpoint;
    }
}


void AbstractGraphCreator::start() {
    this->dimensionNew = this->getNewDimension();
    ASSERT(dimensionNew > dimensionOld);

    b = new int[dimensionNew+1];
	point = new JInt[dimensionNew];
	tpoint = new JInt[dimensionNew];

    
    this->submitGraphResult(createEmptyGraph(graph_source)); 
}


Graph* AbstractGraphCreator::createEmptyGraph(Graph* graph) {
	JDouble* smin = new JDouble[dimensionNew];
	JDouble* smax = new JDouble[dimensionNew];

        int i;
	for (i=0; i<dimensionOld; i++) {
		smin[i] = graph->getMin()[i];
		smax[i] = graph->getMax()[i];
		point[i] = graph->getGrid()[i] * factor[i];
	}
	for (; i<dimensionNew; i++) {
		smin[i] = getMin(i);
		smax[i] = getMax(i);
		point[i] = factor[i];
	}

	cout<<"t dim: "<<dimensionNew<<"\n";

	Graph* g = new Graph(dimensionNew, smin, smax, point, false);

	delete[] smin;
	delete[] smax;

	return g;
}


void AbstractGraphCreator::processNextGraph(Graph* graph) {
	
	ASSERT(graph_result != NULL);
	ASSERT(info != NULL);

	int step = graph->getNumberOfNodes() / info->Length();
	int c = 0;

	NodeEnumerator* ne = graph->getNodeRoot();
	Node* node;
	while (node = graph->getNode(ne)) {
		putNodes(graph, graph_result, node);
		c++;
		if (c > step) {
			step = graph->getNumberOfNodes() / info->Length();
			info->Next();
			c = 0;
		}
	}
	graph->freeNodeEnumerator(ne);
}


void AbstractGraphCreator::putNodes(Graph* from, Graph* to, Node* node) {
        int i;
	for (i=0; i<dimensionOld; i++) {
		b[i] = 0;
		tpoint[i] = from->getCells(node)[i] * factor[i];
	}
	for (;i<dimensionNew; i++) {
		b[i] = 0;
		tpoint[i] = 0;
	}
	b[dimensionNew]=0;

	while (b[dimensionNew] == 0) {
    		int i;
		for (i=0; i<dimensionOld; i++) {
			point[i] = tpoint[i] + b[i];
		}
		for(;i<dimensionNew; i++) {
			point[i] = b[i];
		}
		to->browseTo(point);

		b[0]++;
		for (i=0; i<dimensionNew; i++) {
			if (b[i] >= factor[i]) {
				b[i] = 0;
				b[i+1]++;
			}
		}
	}
}
