#include "StdAfx.h"
#include ".\functionnodeconstant.h"
#include ".\functionnodevisitor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeConstant::FunctionNodeConstant(double value)
{
   this->value = value;
}

FunctionNodeConstant::~FunctionNodeConstant(void)
{
}

////////////////////////////////////////////////////////////////

double FunctionNodeConstant::evaluate(FunctionContext*) {
   return value;
}

bool FunctionNodeConstant::canSimplify(FunctionContext*) {
   return true;
}

FunctionNode* FunctionNodeConstant::simplify(FunctionContext*) {
   return clone();
}

FunctionNode* FunctionNodeConstant::diff(int) {
   return new FunctionNodeConstant(0);
}

FunctionNode* FunctionNodeConstant::clone() {
   return new FunctionNodeConstant(value);
}

void FunctionNodeConstant::print(ostream& o, FunctionDictionary*) {
   o<<"[C]"<<value;
}

void FunctionNodeConstant::appendDependency(FunctionNodeDependency* ) {
}

FunctionNodeType FunctionNodeConstant::type() {
   return FunctionNodeType_Constant;
}

double FunctionNodeConstant::getValue() {
   return value;
}

/////////////////////////////////////////////////////////////////////

void FunctionNodeConstant::Accept(FunctionNodeVisitor* visitor) {
	visitor->VisitConstant(this);
}