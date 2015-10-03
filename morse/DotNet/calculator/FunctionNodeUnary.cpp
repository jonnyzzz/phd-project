#include "StdAfx.h"
#include ".\functionnodeunary.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeUnary::FunctionNodeUnary(FunctionNode* node)
{
   this->value = node;
}

FunctionNodeUnary::~FunctionNodeUnary(void)
{
   delete value;
}


void FunctionNodeUnary::appendDependency(FunctionNodeDependency* dep) {
   value->appendDependency(dep);
}

FunctionNode* FunctionNodeUnary::getValue() {
   return value;
}

