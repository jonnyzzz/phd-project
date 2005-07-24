#include "StdAfx.h"
#include ".\functionnodemin.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeIfLZ.h"
#include ".\FunctionNodeSub.h"
#include ".\FunctionNodeVisitor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeMin::FunctionNodeMin(FunctionNode* left, FunctionNode* right)
{
   this->left = left;
   this->right = right;
}

FunctionNodeMin::~FunctionNodeMin(void)
{
   delete left;
   delete right;
}

double inline min(double a, double b) {
   return (a<b)?a:b;
}

double FunctionNodeMin::evaluate(FunctionContext* cx) {
   return min(left->evaluate(cx), right->evaluate(cx));
}

bool FunctionNodeMin::canSimplify(FunctionContext* cx) {
   return left->canSimplify(cx) && right->canSimplify(cx);
}

FunctionNode* FunctionNodeMin::simplify(FunctionContext* cx) {
   if (canSimplify(cx)) {
      return new FunctionNodeConstant(this->evaluate(cx));
   } else {
      return new FunctionNodeMin(left->simplify(cx), right->simplify(cx));
   }
}

FunctionNode* FunctionNodeMin::diff(int variableID) {
   return new FunctionNodeIfLZ(
      new FunctionNodeSub(left->clone(), right->clone()),
      left->diff(variableID),
      right->diff(variableID)
      );
}
FunctionNode* FunctionNodeMin::clone() {
   return new FunctionNodeMin(left->clone(), right->clone());
}

void FunctionNodeMin::print(ostream&o, FunctionDictionary* dic) {
   o<<"min(";
   left->print(o, dic);
   o<<",";
   right->print(o, dic);
   o<<")";
}

void FunctionNodeMin::appendDependency(FunctionNodeDependency* dep) {
   left->appendDependency(dep);
   right->appendDependency(dep);
}

FunctionNodeType FunctionNodeMin::type() {
   return FunctionNodeType_Min;
}

FunctionNode* FunctionNodeMin::getLeft() {
   return left;
}

FunctionNode* FunctionNodeMin::getRight() {
   return right;
}

void FunctionNodeMin::Accept(FunctionNodeVisitor* visitor) {
	visitor->VisitMin(this);
}