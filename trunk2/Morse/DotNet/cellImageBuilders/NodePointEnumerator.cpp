#include "StdAfx.h"
#include ".\nodepointenumerator.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



NodePointEnumerator::NodePointEnumerator(int dimension, int* factor) :
dimension(dimension), factor(factor)
{
	b = new int[dimension+1];
	x = new int[dimension];
	x0 = new int[dimension];
}

NodePointEnumerator::~NodePointEnumerator(void)
{
	delete[] x;
	delete[] b;
	delete[] x0;
}

void NodePointEnumerator::start(const JInt* node) {
	ZeroMemory(b, sizeof(int)*(dimension+1));
	for (int i=0;i<dimension;i++) {
        x0[i] = node[i]*factor[i];
	}
}

bool NodePointEnumerator::next() {
	if (b[dimension] == 1) return false;

	for (int i=0; i<dimension;i++) {
		x[i] = x0[i] + b[i];
	}

	b[dimension++];
	for (int i=0; i<dimension;i++) {
		if (b[i] >= factor[i]) {
			b[i] = 0;
			b[i+1]++;
		}
	}
	return true;
}

JInt* NodePointEnumerator::getCurrent() {
	return x;
}