#include "StdAfx.h"
#include ".\functionnodemul.h"
#include ".\FunctionNodeSum.h"
#include ".\FunctionContext.h"
#include ".\FunctionNodeUMinus.h"
#include ".\FunctionNodeConstant.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeMul::FunctionNodeMul(FunctionNode* left, FunctionNode* right)
{
   this->left = left;
   this->right = right;
}

FunctionNodeMul::~FunctionNodeMul(void)
{
   delete left;
   delete right;
}

//////////////////////////////////////////////
double FunctionNodeMul::evaluate(FunctionContext* cx) {
   return left->evaluate(cx)*right->evaluate(cx);
}

bool FunctionNodeMul::canSimplify(FunctionContext* cx) {
   return left->canSimplify(cx) && right->canSimplify(cx);
}

FunctionNode* FunctionNodeMul::simplify(FunctionContext* cx) {
   bool leftS = left->canSimplify(cx);
   bool rightS = right->canSimplify(cx);

   if (leftS) {
      if (rightS) {
         return new FunctionNodeConstant(this->evaluate(cx));
      } else {
         if (isZero(left->evaluate(cx))) {
            return new FunctionNodeConstant(0);
         } else if (isZero(left->evaluate(cx)-1)) {
            return right->simplify(cx);
         } else if (isZero(left->evaluate(cx)+1)) {
            return new FunctionNodeUMinus(right->simplify(cx));
         }
      }
   } else {
      if (rightS) {
         if (isZero(right->evaluate(cx))) {
            return new FunctionNodeConstant(0);
         } else if (isZero(right->evaluate(cx)-1)) {
            return left->simplify(cx);
         } else if (isZero(right->evaluate(cx)+1)) {
            return new FunctionNodeUMinus(left->simplify(cx));
         }
      }
   }
   return new FunctionNodeMul(left->simplify(cx), right->simplify(cx));
}

FunctionNode* FunctionNodeMul::diff(int variableID) {
   FunctionNode* tmp = new FunctionNodeSum(
      new FunctionNodeMul(left->clone(), right->diff(variableID)),
      new FunctionNodeMul(left->diff(variableID), right->clone())
      );
   FunctionContext nullContext;
   FunctionNode* ret = tmp->simplify(&nullContext);
   delete tmp;
   return ret;
}

FunctionNode* FunctionNodeMul::clone() {
   return new FunctionNodeMul(left->clone(), right->clone());
}

void FunctionNodeMul::print(ostream& o, FunctionDictionary* dic) {
   cout<<"(";
   left->print(o, dic);
   o<<"*";
   right->print(o, dic);
   cout<<")";
}


void FunctionNodeMul::appendDependency(FunctionNodeDependency *dep) {
   left->appendDependency(dep);
   right->appendDependency(dep);
}
      
FunctionNodeType FunctionNodeMul::type() {
   return FunctionNodeType_Mul;
}

FunctionNode* FunctionNodeMul::getLeft() {
   return left;
}

FunctionNode* FunctionNodeMul::getRight() {
   return right;
}