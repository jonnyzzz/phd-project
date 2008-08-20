#include "StdAfx.h"
#include ".\msanglecreationprocess.h"

MSAngleCreationProcess::MSAngleCreationProcess(Graph* base, int* factor, ProgressBarInfo* info) :
AbstractGraphCreator(base, factor, info)
{
	ASSERT(base->getDimention() == 3);
}

MSAngleCreationProcess::~MSAngleCreationProcess(void)
{
}

JDouble MSAngleCreationProcess::getMax(int i) {
	switch(i) {
		case 3+0:
			return M_PI;
		case 3+1:
			return M_PI_2;
	}
	return 0;
}

JDouble MSAngleCreationProcess::getMin(int i) {
	switch(i) {
		case 3+0:
			return -M_PI;
		case 3+1:
			return 0;
	}
	return 0;
}

int MSAngleCreationProcess::getNewDimension() {
	return  2 * graph_source->getDimention() - 1;
}