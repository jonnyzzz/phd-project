#include "StdAfx.h"
#include ".\functionnodeiflz.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeVisitor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeIfLZ::FunctionNodeIfLZ(FunctionNode* cs, FunctionNode* tr, FunctionNode* fl)
{
   this->cs = cs;
   this->tr = tr;
   this->fl = fl;
}

FunctionNodeIfLZ::~FunctionNodeIfLZ(void)
{
   delete cs;
   delete tr;
   delete fl;
}


double FunctionNodeIfLZ::evaluate(FunctionContext* cx) {
   if (cs->evaluate(cx) < 0 ) {
      return tr->evaluate(cx);
   } else {
      return fl->evaluate(cx);
   }
}

bool FunctionNodeIfLZ::canSimplify(FunctionContext* cx) {
   return tr->canSimplify(cx) || fl->canSimplify(cx) || cs->canSimplify(cx);
}


FunctionNode* FunctionNodeIfLZ::simplify(FunctionContext* cx) {
   if (canSimplify(cx)) {
      return new FunctionNodeConstant(this->evaluate(cx));
   } else if (cs->canSimplify(cx)) {
      if (cs->evaluate(cx) < 0 ) {
         return tr->simplify(cx);
      } else {
         return fl->simplify(cx);
      }
   } else {
      return new FunctionNodeIfLZ(cs->simplify(cx), tr->simplify(cx), fl->simplify(cx));
   }
}


FunctionNode* FunctionNodeIfLZ::diff(int variableID) {
   return new FunctionNodeIfLZ(cs->clone(), tr->diff(variableID), fl->diff(variableID));
}

FunctionNode* FunctionNodeIfLZ::clone() {
   return new FunctionNodeIfLZ(cs->clone(), tr->clone(), fl->clone());
}

void FunctionNodeIfLZ::print(ostream&o, FunctionDictionary* dic) {
   o<<"iflz(";
   cs->print(o, dic);
   o<<",";
   tr->print(o, dic);
   o<<",";
   fl->print(o, dic);
   o<<")";
}

void FunctionNodeIfLZ::appendDependency(FunctionNodeDependency* dep) {
   cs->appendDependency(dep);
   tr->appendDependency(dep);
   fl->appendDependency(dep);
}

FunctionNodeType FunctionNodeIfLZ::type() {
   return FunctionNodeType_IfLZ;
}

FunctionNode* FunctionNodeIfLZ::getCs() {
   return cs;
}

FunctionNode* FunctionNodeIfLZ::getTr() {
   return tr;
}

FunctionNode* FunctionNodeIfLZ::getFl() {
   return fl;
}


void FunctionNodeIfLZ::Accept(FunctionNodeVisitor* visitor) {
	visitor->VisitIfLZ(this);
}