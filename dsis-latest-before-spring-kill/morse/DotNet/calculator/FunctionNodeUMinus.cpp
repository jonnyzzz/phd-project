#include "StdAfx.h"
#include ".\functionnodeuminus.h"
#include ".\functionContext.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeVisitor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeUMinus::FunctionNodeUMinus(FunctionNode* value)
{
   this->value = value;
}

FunctionNodeUMinus::~FunctionNodeUMinus(void)
{
   delete value;
}

double FunctionNodeUMinus::evaluate(FunctionContext* cx) {
   return -value->evaluate(cx);
}
bool FunctionNodeUMinus::canSimplify(FunctionContext* cx) {
   return value->canSimplify(cx);
}

FunctionNode* FunctionNodeUMinus::simplify(FunctionContext* cx) { 
   if (value->canSimplify(cx)) {
      return new FunctionNodeConstant(-value->evaluate(cx));
   } else {
      return new FunctionNodeUMinus(value->simplify(cx));
   }
}

FunctionNode* FunctionNodeUMinus::diff(int variableID) {
   FunctionNode* tmp = new FunctionNodeUMinus(value->diff(variableID));
   FunctionContext nullContext;
   FunctionNode* result = tmp->simplify(&nullContext);
   delete tmp;
   return result;
}

FunctionNode* FunctionNodeUMinus::clone() {
   return new FunctionNodeUMinus(value->clone());
}

void FunctionNodeUMinus::print(ostream& o, FunctionDictionary *dic) {
   o<<"-";
   value->print(o, dic);
}

void FunctionNodeUMinus::appendDependency(FunctionNodeDependency* dep) {
   value->appendDependency(dep);
}

FunctionNodeType FunctionNodeUMinus::type() {
   return FunctionNodeType_UMinus;
}

FunctionNode* FunctionNodeUMinus::getValue() {
   return value;
}

void FunctionNodeUMinus::Accept(FunctionNodeVisitor* visitor){
	visitor->VisitUMinus(this);
}