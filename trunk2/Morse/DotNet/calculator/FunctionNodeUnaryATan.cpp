#include "StdAfx.h"
#include ".\functionnodeunaryatan.h"
#include ".\FunctionNodeDiv.h"
#include ".\FunctionNodeMul.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeSum.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeUnaryATan::FunctionNodeUnaryATan(FunctionNode* node) :
FunctionNodeUnary(node)
{
}

FunctionNodeUnaryATan::~FunctionNodeUnaryATan(void)
{
}

double FunctionNodeUnaryATan::evaluate(FunctionContext* cx) {
   return atan(value->evaluate(cx));
}

bool FunctionNodeUnaryATan::canSimplify(FunctionContext* cx) {
   return value->canSimplify(cx);
}

FunctionNode* FunctionNodeUnaryATan::simplify(FunctionContext* cx) {
   if (value->canSimplify(cx)) {
      return new FunctionNodeConstant(this->evaluate(cx));
   } else {
      return new FunctionNodeUnaryATan(value->simplify(cx));
   }
}

FunctionNode* FunctionNodeUnaryATan::diff(int variableID) {
   return new FunctionNodeDiv(
      value->diff(variableID), 
      new FunctionNodeSum(
         new FunctionNodeConstant(1),
         new FunctionNodeMul(
            value->clone(),
            value->clone()
            )
         )
   );
}

FunctionNode* FunctionNodeUnaryATan::clone() {
   return new FunctionNodeUnaryATan(value->clone());
}

FunctionNodeType FunctionNodeUnaryATan::type() {
   return FunctionNodeType_ArcTg;
}

void FunctionNodeUnaryATan::print(ostream& o, FunctionDictionary* dic) {
   o<<"arctg(";
   value->print(o, dic);
   o<<")";
}