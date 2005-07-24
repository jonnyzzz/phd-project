#include "StdAfx.h"
#include ".\functionnodefunction.h"
#include ".\FunctionContext.h"
#include ".\FunctionDictionary.h"
#include ".\FunctionFactoryParseException.h"
#include ".\FunctionNodeVisitor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


typedef FunctionNodeFunctionParameters::iterator ParsIterator;

FunctionNodeFunction::FunctionNodeFunction(int functionNameID, FunctionNodeFunctionParameters& pars)
{
   this->functionNameID = functionNameID;
   this->pars = FunctionNodeFunctionParameters(pars);
}

FunctionNodeFunction::~FunctionNodeFunction(void)
{
   for (ParsIterator it = pars.begin(); it != pars.end(); it++){
      delete *it;
   }
}

double FunctionNodeFunction::evaluate(FunctionContext* cx) {
   FunctionNodeUserFunctionEvaluator ev;
   for (ParsIterator it = pars.begin(); it != pars.end(); it++){
      ev.push_back((*it)->evaluate(cx));
   }
   return cx->getFunctionSubstitute(functionNameID)->evaluate(ev);
}

bool FunctionNodeFunction::canSimplify(FunctionContext* cx) {
   for (ParsIterator it = pars.begin(); it != pars.end(); it++){
      if (!(*it)->canSimplify(cx)) return false;
   }
   return true;
}

FunctionNode* FunctionNodeFunction::simplify(FunctionContext* cx) {

   FunctionNodeUserFunction* func = cx->getFunctionSubstitute(functionNameID);

   if (func != NULL) {
      FunctionNode* src = func->getSubstitution(pars);   

      FunctionNode* ret = src->simplify(cx);

      delete src;
      return ret;
   } else {
      FunctionNodeFunctionParameters ps;
      for (ParsIterator it = pars.begin(); it != pars.end(); it++) {       
         ps.push_back((*it)->simplify(cx));
      }
      return new FunctionNodeFunction(functionNameID, ps);
   }
}
   
FunctionNode* FunctionNodeFunction::diff(int variableID) {
	throw FunctionFactoryParseException(FunctionFactoryParseException_DiffUnImplemented);
   return NULL;
}

FunctionNode* FunctionNodeFunction::clone() {
   FunctionNodeFunctionParameters pr;
   for (ParsIterator it = pars.begin(); it != pars.end(); it++){
      pr.push_back((*it)->clone());
   }
   return new FunctionNodeFunction(functionNameID, pr);
}

void FunctionNodeFunction::print(ostream&o, FunctionDictionary* dic) {
   o<<dic->getName(functionNameID)<<"(";
   for (ParsIterator it = pars.begin(); it != pars.end(); it++){
      (*it)->print(o, dic);
      o<<" ";
   }
   o<<")";
}

void FunctionNodeFunction::appendDependency(FunctionNodeDependency* dep) {
   for (ParsIterator it = pars.begin(); it != pars.end(); it++){
      (*it)->appendDependency(dep);
   }
}

FunctionNodeType FunctionNodeFunction::type() {
   return FunctionNodeType_UserFunction;
}

void FunctionNodeFunction::Accept(FunctionNodeVisitor* visitor) {
	visitor->VisitFunction(this);
}