#include "StdAfx.h"
#include ".\segmentprojectiveextendedsystemfunctionbase.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SegmentProjectiveExtendedSystemFunctionBase::SegmentProjectiveExtendedSystemFunctionBase(int real_dimension) : 
real_dimension(real_dimension)
{
	ATLASSERT(real_dimension > 0);
}

SegmentProjectiveExtendedSystemFunctionBase::~SegmentProjectiveExtendedSystemFunctionBase(void)
{
}


double inline SegmentProjectiveExtendedSystemFunctionBase::Abs(double x) {
    return (x>0)?x:-x;
}

void SegmentProjectiveExtendedSystemFunctionBase::computeEx(double* v, double* d, double* output) {
    //v - vector v
    //d - differential vector
    //output - vector v

	//cout<<"real dim = "<<real_dimension<<"\n";

    int amax = 0;
    for (int i=0; i<real_dimension; i++) {
        output[i] = 0;
        for (int j=0; j<real_dimension; j++) {
            output[i] += d[i*real_dimension + j] * v[j];
        }
        if (Abs(output[amax]) < Abs(output[i])) {
            amax = i;
        }
    }

	//cout<<"max = "<<amax<<"\n";

	double tmp = output[amax];
	if (Abs(tmp) > 1e-8) {
		for (int i=0; i<real_dimension; i++) {
			output[i] /= tmp;
		}
	} else {
		ZeroMemory(output, sizeof(double)*real_dimension);
	}
}
