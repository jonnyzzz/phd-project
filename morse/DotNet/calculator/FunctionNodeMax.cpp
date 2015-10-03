#include "StdAfx.h"
#include ".\functionnodemax.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeIfLZ.h"
#include ".\FunctionNodeSub.h"
#include ".\FunctionNodeMax.h"
#include ".\FunctionNodeVisitor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeMax::FunctionNodeMax(FunctionNode* left, FunctionNode* right)
{
   this->left = left;
   this->right = right;
}

FunctionNodeMax::~FunctionNodeMax(void)
{
   delete left;
   delete right;
}

double inline max(double a, double b) {
   return (a>b)?a:b;
}

double FunctionNodeMax::evaluate(FunctionContext* cx) {
   return max(left->evaluate(cx), right->evaluate(cx));
}

bool FunctionNodeMax::canSimplify(FunctionContext* cx) {
   return left->canSimplify(cx) && right->canSimplify(cx);
}

FunctionNode* FunctionNodeMax::simplify(FunctionContext* cx) {
   if (canSimplify(cx)) {
      return new FunctionNodeConstant(this->evaluate(cx));
   } else {
      return new FunctionNodeMax(left->simplify(cx), right->simplify(cx));
   }
}

FunctionNode* FunctionNodeMax::diff(int variableID) {
   return new FunctionNodeIfLZ(
      new FunctionNodeSub(right->clone(), left->clone()),
      left->diff(variableID),
      right->diff(variableID)
      );
}
FunctionNode* FunctionNodeMax::clone() {
   return new FunctionNodeMax(left->clone(), right->clone());
}

void FunctionNodeMax::print(ostream&o, FunctionDictionary* dic) {
   o<<"max(";
   left->print(o, dic);
   o<<",";
   right->print(o, dic);
   o<<")";
}

void FunctionNodeMax::appendDependency(FunctionNodeDependency* dep) {
   left->appendDependency(dep);
   right->appendDependency(dep);
}

FunctionNodeType FunctionNodeMax::type() {
   return FunctionNodeType_Max;
}

FunctionNode* FunctionNodeMax::getLeft() {
   return left;
}

FunctionNode* FunctionNodeMax::getRight() {
   return right;
}

void FunctionNodeMax::Accept(FunctionNodeVisitor* visitor) {
	visitor->VisitMax(this);
}