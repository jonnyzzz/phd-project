#include "StdAfx.h"
#include ".\functionnode.h"
#include ".\FunctionContext.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNode::FunctionNode(void)
{
}

FunctionNode::~FunctionNode(void)
{
}


const double precision = 1e-17;
bool FunctionNode::isZero(double value) {
   return (value < precision && (-value) < precision);
}


double FunctionNode::evaluate(FunctionContext& cx) {
	return evaluate(&cx);
}

double FunctionNode::evaluate() {
    return evaluate(FunctionContext());
}