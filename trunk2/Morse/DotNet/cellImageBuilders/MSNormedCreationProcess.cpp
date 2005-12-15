#include "StdAfx.h"
#include ".\msnormedcreationprocess.h"

MSNormedCreationProcess::MSNormedCreationProcess(Graph* base, int* factor, ProgressBarInfo* info) :
AbstractGraphCreator(base, factor, info)
{
}

MSNormedCreationProcess::~MSNormedCreationProcess(void)
{
}



JDouble MSNormedCreationProcess::getMax(int i) {
	return 1;
}

JDouble MSNormedCreationProcess::getMin(int i) {
	return -1;
}

int MSNormedCreationProcess::getNewDimension() {
	return  2 * graph_source->getDimention();
}