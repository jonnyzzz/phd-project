#include "StdAfx.h"
#include ".\functionnodediv.h"
#include ".\FunctionNodeSub.h"
#include ".\FunctionNodeMul.h"
#include ".\FunctionContext.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeUMinus.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeDiv::FunctionNodeDiv(FunctionNode* left, FunctionNode* right)
{
   this->left = left;
   this->right = right;
}

FunctionNodeDiv::~FunctionNodeDiv(void)
{
   delete left;
   delete right;
}

//////////////////////////////////////////////
double FunctionNodeDiv::evaluate(FunctionContext* cx) {
   return left->evaluate(cx)/right->evaluate(cx);
}

bool FunctionNodeDiv::canSimplify(FunctionContext* cx) {
   return left->canSimplify(cx) && right->canSimplify(cx);
}

FunctionNode* FunctionNodeDiv::simplify(FunctionContext* cx) {
   bool leftS = left->canSimplify(cx);
   bool rightS = right->canSimplify(cx);

   if (leftS) {
      if (rightS) {
         return new FunctionNodeConstant(this->evaluate(cx));
      } else {
         if (isZero(left->evaluate(cx))) {
            return new FunctionNodeConstant(0);
         }
      }
   } else {
      if (rightS) {
         if (isZero(right->evaluate(cx) - 1)) {
            return left->simplify(cx);
         } else if (isZero(right->evaluate(cx)+1)) {
            return new FunctionNodeUMinus(left->simplify(cx));
         }
      }
   }
   return new FunctionNodeDiv(left->simplify(cx), right->simplify(cx));
}

FunctionNode* FunctionNodeDiv::diff(int variableID) {
   FunctionNode* tmp = new FunctionNodeSub(
      new FunctionNodeDiv(left->diff(variableID), right->clone()),
      new FunctionNodeDiv(
            new FunctionNodeMul(left->clone(), right->diff(variableID)),
            new FunctionNodeMul(right->clone(), right->clone())
         )
      );
   FunctionContext nullContext;
   FunctionNode* ret = tmp->simplify(&nullContext);
   delete tmp;
   return ret;
}

FunctionNode* FunctionNodeDiv::clone() {
   return new FunctionNodeDiv(left->clone(), right->clone());
}

void FunctionNodeDiv::print(ostream& o, FunctionDictionary* dic) {
   cout<<"(";
   left->print(o, dic);
   o<<"/";
   right->print(o, dic);
   cout<<")";
}
   
void FunctionNodeDiv::appendDependency(FunctionNodeDependency *dep) {
   left->appendDependency(dep);
   right->appendDependency(dep);
}
      

FunctionNodeType FunctionNodeDiv::type() {
   return FunctionNodeType_Div;
}

FunctionNode* FunctionNodeDiv::getLeft() {
   return left;
}

FunctionNode* FunctionNodeDiv::getRight() {
   return right;
}