#include "StdAfx.h"
#include ".\ms2pointbuilder.h"
#define _USE_MATH_DEFINES
#include <math.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


#define dimention2 2


MS2PointBuilder::MS2PointBuilder(Graph* graph, int* factor, int* ks, Function* function) : 
	SIPointBuilder(graph, factor, ks, function)
{
}

MS2PointBuilder::~MS2PointBuilder(void)
{
}


void MS2PointBuilder::buildImage(Graph* graph, JInt* answer) {
	for (int i=0; i<dimention2; i++) {
		answer[i] = graph->toInternal(function->F(i), i);
	}

	answer[2] = graph->toInternal(tR(), 2);
}


JDouble MS2PointBuilder::tR() {
	JDouble ret0 = function->dF(0, 0)*cos(x[2]) + function->dF(0, 1)*sin(x[2]);
	JDouble ret1 = function->dF(1, 0)*cos(x[2]) + function->dF(1, 1)*sin(x[2]);
	double ret = atan2(ret1, ret0);
	ret = (ret>0)?ret:(ret+M_PI);
	VERIFY(ret >= 0);
	return ret;
}
