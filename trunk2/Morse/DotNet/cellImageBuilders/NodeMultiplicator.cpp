#include "StdAfx.h"
#include ".\nodemultiplicator.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



NodeMultiplicator::NodeMultiplicator(int dimension, const JDouble* pre_eps, int* factors) :
factors(factors), dimension(dimension)
{
	eps = new JDouble[dimension];
	b = new int[dimension+1];
	x0 = NULL;
	x = NULL;

	for (int i=0; i<dimension; i++) {
		VERIFY(factors[i] > 0);
		eps[i] = pre_eps[i]/factors[i];
		b[i] = 0;
	}
	b[dimension] = !0;
}

NodeMultiplicator::~NodeMultiplicator() {
	delete[] eps;
	delete[] b;
}

void NodeMultiplicator::setCoordinateReturn(JDouble* x) {
	VERIFY(this->x == NULL);
	this->x = x;
}

void NodeMultiplicator::start(JDouble* node) {
	x0 = node;
	ZeroMemory(b, sizeof(int)*(dimension+1));
}

bool NodeMultiplicator::next() {
	
	if (b[dimension] != 0) return false;

	for (int i=0; i<dimension; i++) {
		x[i] = x0[i] + eps[i]*b[i];
	}

	b[0]++;
	for (int i=0; i<dimension;i++) {
		if (b[i] >= factors[i]) {
			b[i] = 0;
			b[i+1]++;
		}
	}
	return true;
}
