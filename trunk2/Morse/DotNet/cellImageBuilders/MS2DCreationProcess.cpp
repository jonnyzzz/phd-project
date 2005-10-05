#include "stdafx.h"
#include "MS2DCreationProcess.h"


MS2DCreationProcess::MS2DCreationProcess(Graph* graph, int* factor, ProgressBarInfo* info) : 
AbstractGraphCreator(graph, factor, info)
{
    int dim = graph_source->getDimention();
    VERIFY(dim == 2);
}

MS2DCreationProcess::~MS2DCreationProcess(void)
{
}


int MS2DCreationProcess::getNewDimension() {
    int dim = graph_source->getDimention();
    VERIFY(dim == 2);
	return  3;
}


JDouble MS2DCreationProcess::getMin(int i) {
    int dim = graph_source->getDimention();
	cout<<"dim : "<< dim <<"\n";

    VERIFY(dim == 2);
    VERIFY(i == 2);

    return -M_PI_2;	
}

JDouble MS2DCreationProcess::getMax(int i) {
    int dim = graph_source->getDimention();
	cout<<"dim : "<< dim <<"\n";

    VERIFY(dim == 2);
    VERIFY(i == 2);

    return M_PI_2;
}