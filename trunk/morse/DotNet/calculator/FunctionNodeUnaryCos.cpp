#include "StdAfx.h"
#include ".\functionnodeunarycos.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeMul.h"
#include ".\FunctionNodeUnatySin.h"
#include ".\FunctionNodeUMinus.h"
#include ".\FunctionNodeVisitor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



FunctionNodeUnaryCos::FunctionNodeUnaryCos(FunctionNode* node) :
FunctionNodeUnary(node)
{
}

FunctionNodeUnaryCos::~FunctionNodeUnaryCos(void)
{
}

double FunctionNodeUnaryCos::evaluate(FunctionContext* cx) {
   return cos(value->evaluate(cx));
}

bool FunctionNodeUnaryCos::canSimplify(FunctionContext* cx) {
   return value->canSimplify(cx);
}

FunctionNode* FunctionNodeUnaryCos::simplify(FunctionContext* cx) {
   if (value->canSimplify(cx)) {
      return new FunctionNodeConstant(this->evaluate(cx));
   } else {
      return new FunctionNodeUnaryCos(value->simplify(cx));
   }
}

FunctionNode* FunctionNodeUnaryCos::diff(int variableID) {
   return new FunctionNodeMul(
      value->diff(variableID), 
      new FunctionNodeUMinus(new FunctionNodeUnarySin(value->clone()))
   );
}

FunctionNode* FunctionNodeUnaryCos::clone() {
   return new FunctionNodeUnaryCos(value->clone());
}

FunctionNodeType FunctionNodeUnaryCos::type() {
   return FunctionNodeType_Cos;
}

void FunctionNodeUnaryCos::print(ostream& o, FunctionDictionary* dic) {
   o<<"cos(";
   value->print(o, dic);
   o<<")";
}

void FunctionNodeUnaryCos::Accept(FunctionNodeVisitor* visitor) {
	visitor->VisitCos(this);
}