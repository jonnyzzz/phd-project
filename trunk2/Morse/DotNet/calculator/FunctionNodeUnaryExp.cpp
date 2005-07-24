#include "StdAfx.h"
#include ".\functionnodeunaryexp.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeMul.h"
#include ".\FunctionNodeVisitor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeUnaryExp::FunctionNodeUnaryExp(FunctionNode* value) :
FunctionNodeUnary(value)
{
}

FunctionNodeUnaryExp::~FunctionNodeUnaryExp(void)
{
}

double FunctionNodeUnaryExp::evaluate(FunctionContext* cx) {
   return exp(value->evaluate(cx));
}

bool FunctionNodeUnaryExp::canSimplify(FunctionContext* cx) {
   return value->canSimplify(cx);
}

FunctionNode* FunctionNodeUnaryExp::simplify(FunctionContext* cx) {
   if (value->canSimplify(cx)) {
      return new FunctionNodeConstant(this->evaluate(cx));
   } else {
      return new FunctionNodeUnaryExp(value->simplify(cx));
   }
}

FunctionNode* FunctionNodeUnaryExp::diff(int variableID) {
   return new FunctionNodeMul(
      value->diff(variableID), 
      new FunctionNodeUnaryExp(value->clone())
   );
}

FunctionNode* FunctionNodeUnaryExp::clone() {
   return new FunctionNodeUnaryExp(value->clone());
}

FunctionNodeType FunctionNodeUnaryExp::type() {
   return FunctionNodeType_Exp;
}

void FunctionNodeUnaryExp::print(ostream& o, FunctionDictionary* dic) {
   o<<"exp(";
   value->print(o, dic);
   o<<")";
}

void FunctionNodeUnaryExp::Accept(FunctionNodeVisitor* visitor) {
	visitor->VisitExp(this);
}