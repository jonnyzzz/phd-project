#include "StdAfx.h"
#include ".\ms3pointbuilder.h"
#define _USE_MATH_DEFINES
#include <math.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define dimention3 3

MS3PointBuilder::MS3PointBuilder(Graph* graph, int* factor, int* ks, Function* function) : SIPointBuilder(graph, factor, ks, function)
{
}

MS3PointBuilder::~MS3PointBuilder(void)
{
}


MS3PointBuilder::angle inline MS3PointBuilder::getAngle(const double* v) {
	angle a;

	a.phi = atan2(v[1], v[0]);
	a.psi = atan2(abs(v[2]), sqrt(sqr(v[0]) + sqr(v[1])));

	if (abs(a.psi) < (1e-12) && a.phi < 0) {
		a.phi += M_PI;
	}
	if (a.phi == M_PI) a.phi = 0;

	VERIFY(a.psi >= 0 && a.psi <= M_PI_2);
	VERIFY(a.phi >= -M_PI && a.phi <= M_PI);

	return a;
}


void MS3PointBuilder::buildImage(Graph* graph, JInt* answer) {
	for (int i=0; i<dimention3; i++) {
		answer[i] = graph->toInternal(function->F(i),i);
	}
  
	JDouble ccx = cos(x[3]);
	JDouble ccy = cos(x[4]);
	JDouble ssx = sin(x[3]);
	JDouble ssy = sin(x[4]);

	JDouble v[] = { ccx*ccy, ssx*ccy, ssy};

	JDouble ret[3];
	for (int i=0; i<3; i++) {
		ret[i] = 0;
		for (int j=0; j<3;j++) {
			ret[i] += function->dF(i, j)*v[j];
		}
	}

	angle a = getAngle(ret);

	answer[3] = graph->toInternal(a.phi, 3);
	answer[4] = graph->toInternal(a.psi, 3);
}