#include "StdAfx.h"
#include ".\functionnodesum.h"
#include ".\FunctionContext.h"
#include ".\FunctionNodeConstant.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeSum::FunctionNodeSum(FunctionNode* left, FunctionNode* right)
{
   this->left = left;
   this->right = right;
}

FunctionNodeSum::~FunctionNodeSum(void)
{
   delete left;
   delete right;
}

double FunctionNodeSum::evaluate(FunctionContext* cx) {
   return left->evaluate(cx) + right->evaluate(cx);
}

bool FunctionNodeSum::canSimplify(FunctionContext* cx) {
   return left->canSimplify(cx) && right->canSimplify(cx);
}

FunctionNode* FunctionNodeSum::simplify(FunctionContext* cx) {
   bool ls = left->canSimplify(cx);
   bool rs = right->canSimplify(cx);

   if (ls) {
      if (rs) {
         return new FunctionNodeConstant(this->evaluate(cx));
      } else {
         if (isZero(left->evaluate(cx))) {
            return right->simplify(cx);
         }
      }
   } else {
      if (rs) {
         if (isZero(right->evaluate(cx))) {
            return left->simplify(cx);
         }
      }
   }

   return new FunctionNodeSum(left->simplify(cx), right->simplify(cx));
}

FunctionNode* FunctionNodeSum::diff(int variableID) {
   FunctionNode* tmp = new FunctionNodeSum(left->diff(variableID), right->diff(variableID));
   FunctionContext nullContext;
   FunctionNode* ret = tmp->simplify(&nullContext);
   delete tmp;
   return ret;
}
      
FunctionNode* FunctionNodeSum::clone() {
   return new FunctionNodeSum(left->clone(), right->clone());
}
   
void FunctionNodeSum::print(ostream& o, FunctionDictionary * dic) {
   cout<<"(";
   left->print(o, dic);
   o<<"+";
   right->print(o, dic);
   cout<<")";
}

void FunctionNodeSum::appendDependency(FunctionNodeDependency *dep) {
   left->appendDependency(dep);
   right->appendDependency(dep);
}

FunctionNodeType FunctionNodeSum::type() {
   return FunctionNodeType_Sum;
}

FunctionNode* FunctionNodeSum::getLeft() {
   return left;
}

FunctionNode* FunctionNodeSum::getRight() {
   return right;
}