#include "StdAfx.h"
#include ".\functionnodeunarytg.h"
#include ".\functionNodeDiv.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeMul.h"
#include ".\FunctionNodeUnaryCos.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeUnaryTg::FunctionNodeUnaryTg(FunctionNode* node) :
FunctionNodeUnary(node)
{
}

FunctionNodeUnaryTg::~FunctionNodeUnaryTg(void)
{
}

double FunctionNodeUnaryTg::evaluate(FunctionContext* cx) {
   return tan(value->evaluate(cx));
}

bool FunctionNodeUnaryTg::canSimplify(FunctionContext* cx) {
   return value->canSimplify(cx);
}

FunctionNode* FunctionNodeUnaryTg::simplify(FunctionContext* cx) {
   if (value->canSimplify(cx)) {
      return new FunctionNodeConstant(this->evaluate(cx));
   } else {
      return new FunctionNodeUnaryTg(value->simplify(cx));
   }
}

FunctionNode* FunctionNodeUnaryTg::diff(int variableID) {
   return new FunctionNodeDiv(
      value->diff(variableID), 
      new FunctionNodeMul(
         new FunctionNodeUnaryCos(value->clone()),
         new FunctionNodeUnaryCos(value->clone())
         )
   );
}

FunctionNode* FunctionNodeUnaryTg::clone() {
   return new FunctionNodeUnaryTg(value->clone());
}

FunctionNodeType FunctionNodeUnaryTg::type() {
   return FunctionNodeType_Tg;
}

void FunctionNodeUnaryTg::print(ostream& o, FunctionDictionary* dic) {
   o<<"tg(";
   value->print(o, dic);
   o<<")";
}