#include "StdAfx.h"
#include ".\functionnodepower.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionFactoryParseException.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodePower::FunctionNodePower(FunctionNode* base, FunctionNode* exponent)
{
   this->base = base;
   this->exponent = exponent;
}

FunctionNodePower::~FunctionNodePower(void)
{
   delete base;
   delete exponent;
}

///////////////////////////////////////////

double FunctionNodePower::evaluate(FunctionContext* cx) {
   double baseValue = base->evaluate(cx);
   double exponentValue = exponent->evaluate(cx);

   return pow(baseValue, exponentValue);
}

bool FunctionNodePower::canSimplify(FunctionContext* cx) {
   return base->canSimplify(cx) && exponent->canSimplify(cx);
}

FunctionNode* FunctionNodePower::simplify(FunctionContext* cx) {
   bool baseS = base->canSimplify(cx);
   bool exponentS = exponent->canSimplify(cx);

   if (baseS) {
      if (exponentS) {
         return new FunctionNodeConstant(evaluate(cx));
      } else {
         if (isZero(base->evaluate(cx)-1)) {
            return new FunctionNodeConstant(1);
         } else if (isZero(base->evaluate(cx))) {
            return new FunctionNodeConstant(0);
         }
      }
   } else {
      if (exponentS) {
         return new FunctionNodePower(base->simplify(cx), exponent->simplify(cx));
      }
   }

   return new FunctionNodePower(base->simplify(cx), exponent->simplify(cx));

}

FunctionNode* FunctionNodePower::diff(int variableID) {
	throw FunctionFactoryParseException(FunctionFactoryParseException_DiffUnImplemented);
   return NULL;
}

FunctionNode* FunctionNodePower::clone() {
   return new FunctionNodePower(base->clone(), exponent->clone());
}

void FunctionNodePower::print(ostream& o, FunctionDictionary* dic) {
   base->print(o, dic);
   o<<"^(";
   exponent->print(o, dic);
   o<<")";
}


void FunctionNodePower::appendDependency(FunctionNodeDependency* dep) {
   base->appendDependency(dep);
   exponent->appendDependency(dep);
}


FunctionNodeType FunctionNodePower::type() {
   return FunctionNodeType_Power;
}

FunctionNode* FunctionNodePower::getBase() {
   return base;
}

FunctionNode* FunctionNodePower::getExponent() {
   return exponent;
}