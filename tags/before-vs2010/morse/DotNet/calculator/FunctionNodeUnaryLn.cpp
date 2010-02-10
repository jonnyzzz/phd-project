#include "StdAfx.h"
#include ".\functionnodeunaryln.h"
#include ".\functionNodeMul.h"
#include ".\FunctionNodeDiv.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeVisitor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeUnaryLn::FunctionNodeUnaryLn(FunctionNode* value) :
FunctionNodeUnary(value)
{
}

FunctionNodeUnaryLn::~FunctionNodeUnaryLn(void)
{
}

double FunctionNodeUnaryLn::evaluate(FunctionContext* cx) {
   return log(value->evaluate(cx));
}

bool FunctionNodeUnaryLn::canSimplify(FunctionContext* cx) {
   return value->canSimplify(cx);
}

FunctionNode* FunctionNodeUnaryLn::simplify(FunctionContext* cx) {
   if (value->canSimplify(cx)) {
      return new FunctionNodeConstant(this->evaluate(cx));
   } else {
      return new FunctionNodeUnaryLn(value->simplify(cx));
   }
}

FunctionNode* FunctionNodeUnaryLn::diff(int variableID) {
   return new FunctionNodeDiv(
      value->diff(variableID), 
      value->clone()
   );
}

FunctionNode* FunctionNodeUnaryLn::clone() {
   return new FunctionNodeUnaryLn(value->clone());
}

FunctionNodeType FunctionNodeUnaryLn::type() {
   return FunctionNodeType_Ln;
}

void FunctionNodeUnaryLn::print(ostream& o, FunctionDictionary* dic) {
   o<<"ln(";
   value->print(o, dic);
   o<<")";
}


void FunctionNodeUnaryLn::Accept(FunctionNodeVisitor* visitor) {
	visitor->VisitLn(this);
}