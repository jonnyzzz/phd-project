#include "StdAfx.h"
#include ".\functionnodevariable.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionContext.h"
#include ".\FunctionDictionary.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



FunctionNodeVariable::FunctionNodeVariable(int variableID)
{
   this->variableID = variableID;
}

FunctionNodeVariable::~FunctionNodeVariable(void)
{
}

///////////////////////////////////////////////////////////

double FunctionNodeVariable::evaluate(FunctionContext* cx) {
   return cx->getSubstitute(variableID)->evaluate(cx);
}

bool FunctionNodeVariable::canSimplify(FunctionContext* cx) {
   FunctionNode* tmp = cx->getSubstitute(variableID);
   return (tmp != NULL) && (tmp->canSimplify(cx));
}

FunctionNode* FunctionNodeVariable::simplify(FunctionContext* cx) {
   FunctionNode* tmp = cx->getSubstitute(variableID);
   if (tmp == NULL) {
      return clone();
   } else {
      return tmp->simplify(cx);
   }
}

FunctionNode* FunctionNodeVariable::diff(int variableID) {  
   return new FunctionNodeConstant( (this->variableID == variableID)?1:0);
}

FunctionNode* FunctionNodeVariable::clone() {
   return new FunctionNodeVariable(variableID);
}

void FunctionNodeVariable::print(ostream& o, FunctionDictionary* dic) {
   cout<<dic->getName(variableID);
}

void FunctionNodeVariable::appendDependency(FunctionNodeDependency* dep) {
   dep->push_back(this);
}

int FunctionNodeVariable::getVariableID() {
   return variableID;
}

FunctionNodeType FunctionNodeVariable::type() {
   return FunctionNodeType_Variable;
}

int FunctionNodeVariable::setVariableID(int newID) {
   int old = variableID;
   variableID = newID;
   return old;
}
