#include "StdAfx.h"
#include ".\abstractpointbuilder.h"
#include ".\NodeMultiplicator.h"
#include ".\NodePointEnumerator.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

AbstractPointBuilder::AbstractPointBuilder(Graph* graph,  int* factor, int* ks, ProgressBarInfo* info) :
dimension(graph->getDimention()), factor(factor), ks(ks), AbstractProcess(graph, info)
{
	 x   = NULL;
	 x0  = new JDouble[dimension];
	 min = new JDouble[dimension];
	 max = new JDouble[dimension];
	 eps = new JDouble[dimension];

	 b = new JInt[dimension + 1];
	 c = new JInt[dimension + 1];
	 tpoint = new JInt[dimension+1];
	 point = new JInt[dimension+1];
	 
}

AbstractPointBuilder::~AbstractPointBuilder()
{
	delete[] min;
	delete[] max;
	delete[] x0;

	delete[] b;
	delete[] point;
	delete[] c;

	delete[] eps;
	delete[] tpoint;
}


//////////////////////////////////////////////////////////////////////

void AbstractPointBuilder::start(){
	submitGraphResult(createGraph());
	x = getFunctionX();
}


Graph* AbstractPointBuilder::createGraph() {
	for (int i=0; i<dimension; i++) {			
		point[i] = graph_source->getGrid()[i]*factor[i];
		eps[i] = graph_source->getEps()[i]/factor[i]/ks[i];

		cout<<graph_source->getMin()[i]<<"\t"<<graph_source->getMax()[i]<<"\t"<<graph_source->getGrid()[i]<<"\n";
		cout<<"eps = "<<eps[i]<<"\n";
		cout<<"factor = "<<factor[i]<<"\n";
		cout<<"ks = "<<ks[i]<<"\n";
	}
	return new Graph(dimension, graph_source->getMin(), graph_source->getMax(), point);	
}


void AbstractPointBuilder::processNextGraph(Graph* graph) {

	if (!graph_source->equals(graph)) throw "Unable to continue;";

	this->graph = graph;

	int step;
	if (info != NULL) {
		step = graph->getNumberOfNodes() / (info->getLengthPart());
	} else {
		step = 1<<30;
	}
	int c = 0;

	NodeEnumerator* en = graph->getNodeRoot();
	Node* node;
	while (node = graph->getNode(en)) {
		this->buildNodeMultiplication(node);
		c++;
		if (c >= step && info != NULL) {
			info->next();
			c = 0;
		}
	}
	graph->freeNodeEnumerator(en);
}

void AbstractPointBuilder::buildNodeMultiplication(Node* node) {
	for (int i=0; i<dimension; i++) {
		b[i] = 0;
		tpoint[i] = (graph->getCells(node)[i])*factor[i];
	}
	b[dimension] = 0;

	while (b[dimension] == 0) {		
		for (i=0; i<dimension; i++) {
			point[i] = tpoint[i] + b[i];
		}
		Node* n = graph_result->browseTo(point);
		
		ASSERT(n != NULL);
		
		this->buildNodeImage(n);

		b[0]++;
		for ( i=0;i<dimension;i++) {
			if (b[i] >= factor[i]) {
				b[i] = 0;
				b[i+1]++;
			}
		}		
	}
}

void AbstractPointBuilder::buildNodeImage(Node* node) {
	for (int i=0; i<dimension; i++) {
		c[i] = 0;
		//it's defined before call this function!
		x0[i] = graph_result->toExternal(point[i],i);
	}
	c[dimension] = 0;

	while (c[dimension] == 0) {
		for (i=0; i<dimension; i++) {
			x[i] = x0[i] + eps[i]*( (double)c[i] + 0.5 );
		}

		//todo -> to abstract for optimization in MS
		/*
		for (int i=0; i<dimention; i++) {			
			point[i] = graph_result->toInternal(F(i), i);			
		}
		*/

		buildImage(graph_result, point);


		Node* t = graph_result->browseTo(point);
		if (t != NULL) {			
			graph_result->browseTo(node, t);
		} 

		c[0]++;
		for (i=0; i<dimension; i++) {
			if (c[i] >= ks[i]) {
				c[i] = 0;
				c[i+1]++;
			}
		}
	}

	
}