#include "stdafx.h"
#include "MSCreationProcess.h"
#define _USE_MATH_DEFINES
#include <math.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif




MSCreationProcess::MSCreationProcess(Graph* graph, int* factor) : 
AbstractGraphCreator(graph, factor, NULL)
{
}

MSCreationProcess::~MSCreationProcess(void)
{
}


int MSCreationProcess::getNewDimension() {
	return  2 * graph_source->getDimention();
}


JDouble MSCreationProcess::getMin(int i) {
	cout<<"dim : "<< graph_source->getDimention()<<"\n";
	switch (graph_source->getDimention()) {
		case 2:
			return 0;
		case 3:
			switch (i) {
				case 3:
					return -M_PI;
				case 4:
					return 0;
			}
	}
	VERIFY(false);
	return 0;
}

JDouble MSCreationProcess::getMax(int i) {
	switch (graph_source->getDimention()) {
		case 2:
			return M_PI;
		case 3:
			switch (i) {
				case 3:
					return M_PI;
				case 4:
					return M_PI_2;
			}
	}
	VERIFY(false);
	return 0;
}


