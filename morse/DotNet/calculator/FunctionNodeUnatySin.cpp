#include "StdAfx.h"
#include ".\functionnodeunatysin.h"
#include ".\FunctionNOdeConstant.h"
#include ".\FunctionNodeMul.h"
#include ".\FunctionNodeUnaryCos.h"
#include ".\FunctionNodeVisitor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeUnarySin::FunctionNodeUnarySin(FunctionNode* node) :
FunctionNodeUnary(node)
{
}

FunctionNodeUnarySin::~FunctionNodeUnarySin(void)
{
}


double FunctionNodeUnarySin::evaluate(FunctionContext* cx) {
   return sin(value->evaluate(cx));
}

bool FunctionNodeUnarySin::canSimplify(FunctionContext* cx) {
   return value->canSimplify(cx);
}

FunctionNode* FunctionNodeUnarySin::simplify(FunctionContext* cx) {
   if (value->canSimplify(cx)) {
      return new FunctionNodeConstant(this->evaluate(cx));
   } else {
      return new FunctionNodeUnarySin(value->simplify(cx));
   }
}

FunctionNode* FunctionNodeUnarySin::diff(int variableID) {
   return new FunctionNodeMul(
      value->diff(variableID), 
      new FunctionNodeUnaryCos(value->clone())
   );
}

FunctionNode* FunctionNodeUnarySin::clone() {
   return new FunctionNodeUnarySin(value->clone());
}

FunctionNodeType FunctionNodeUnarySin::type() {
   return FunctionNodeType_Sin;
}

void FunctionNodeUnarySin::print(ostream& o, FunctionDictionary* dic) {
   o<<"sin(";
   value->print(o, dic);
   o<<")";
}

void FunctionNodeUnarySin::Accept(FunctionNodeVisitor* visitor) {
	visitor->VisitSin(this);
}