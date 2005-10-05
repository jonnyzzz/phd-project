#include "stdafx.h"
#include "AbstractPointBuilder.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

AbstractPointBuilder::AbstractPointBuilder(Graph* graph,  int* factor, int* ks, ProgressBarInfo* info) :
dimension(graph->getDimention()), AbstractProcessExt(graph, info)
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

     this->ks = new int[dimension + 1];
     this->factor = new int[dimension + 1];

     for (int i=0; i<dimension; i++) {
         this->factor[i] = factor[i];
         this->ks[i] = ks[i];
     }	 
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

    delete[] ks;
    delete[] factor;
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
	return new Graph(dimension, graph_source->getMin(), graph_source->getMax(), point, true);	
}


void AbstractPointBuilder::processNextGraph(Graph* graph) {

	if (!graph_source->equals(graph)) throw "Unable to continue;";

	ASSERT( this->result() != NULL);
	ASSERT( this->info != NULL);

	this->graph = graph;

	int step = graph->getNumberOfNodes() / info->Length();
	int c = 0;

	NodeEnumerator* en = graph->getNodeRoot();
	Node* node;
	while (node = graph->getNode(en)) {
		this->buildNodeMultiplication(node);
		c++;
		if ( c >= step ) {
			info->Next();
			step = graph->getNumberOfNodes() / info->Length();
			c = 0;
		}
	}
	graph->freeNodeEnumerator(en);
}

void AbstractPointBuilder::buildNodeMultiplication(Node* node) {
        int i;
	for (i=0; i<dimension; i++) {
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
        int i;
	for (i=0; i<dimension; i++) {
		c[i] = 0;
		//it's defined before call this function!
		x0[i] = graph_result->toExternal(point[i],i) + eps[i]/2;
	}
	c[dimension] = 0;

	while (c[dimension] == 0) {
		for (i=0; i<dimension; i++) {
			x[i] = x0[i] + eps[i]*(double)c[i];
		}

		//todo -> to abstract for optimization in MS
		/*
		for (int i=0; i<dimention; i++) {			
			point[i] = graph_result->toInternal(F(i), i);			
		}
		*/

		//todo: Extract -> virtual for SIOverlapedPointBuilder.
		buildImage(graph_result, node);


		c[0]++;
		for (i=0; i<dimension; i++) {
			if (c[i] >= ks[i]) {
				c[i] = 0;
				c[i+1]++;
			}
		}
	}	
}
