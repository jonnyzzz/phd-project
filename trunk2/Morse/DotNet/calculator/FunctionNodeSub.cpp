#include "StdAfx.h"
#include ".\functionnodesub.h"
#include ".\FunctionContext.h"
#include ".\FunctionNodeUMinus.h"
#include ".\FunctionNodeConstant.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeSub::FunctionNodeSub(FunctionNode* left, FunctionNode* right)
{
   this->left = left;
   this->right = right;
}

FunctionNodeSub::~FunctionNodeSub(void)
{
   delete left;
   delete right;
}

double FunctionNodeSub::evaluate(FunctionContext* cx) {
   return left->evaluate(cx) - right->evaluate(cx);
}

bool FunctionNodeSub::canSimplify(FunctionContext* cx) {
   return left->canSimplify(cx) && right->canSimplify(cx);
}

FunctionNode* FunctionNodeSub::simplify(FunctionContext* cx) {
   bool ls = left->canSimplify(cx);
   bool rs = right->canSimplify(cx);

   if (ls) {
      if (rs) {
         return new FunctionNodeConstant(this->evaluate(cx));
      } else {
         if (isZero(left->evaluate(cx))) {
            return new FunctionNodeUMinus(right->simplify(cx));
         }
      }
   } else {
      if (rs) {
         if (isZero(right->evaluate(cx))) {
            return left->simplify(cx);
         }
      }
   }

   return new FunctionNodeSub(left->simplify(cx), right->simplify(cx));
}

FunctionNode* FunctionNodeSub::diff(int variableID) {
   FunctionNode* tmp = new FunctionNodeSub(left->diff(variableID), right->diff(variableID));
   FunctionContext nullContext;
   FunctionNode* ret = tmp->simplify(&nullContext);
   delete tmp;
   return ret;
}
      
FunctionNode* FunctionNodeSub::clone() {
   return new FunctionNodeSub(left->clone(), right->clone());
}

void FunctionNodeSub::print(ostream& o, FunctionDictionary * dic) {
   cout<<"(";
   left->print(o, dic);
   o<<"-";
   right->print(o, dic);
   cout<<")";
}

   
void FunctionNodeSub::appendDependency(FunctionNodeDependency* dep) {
   left->appendDependency(dep);
   right->appendDependency(dep);
}

FunctionNodeType FunctionNodeSub::type() {
   return FunctionNodeType_Sub;
}

FunctionNode* FunctionNodeSub::getLeft() {
   return left;
}

FunctionNode* FunctionNodeSub::getRight() {
   return right;
}