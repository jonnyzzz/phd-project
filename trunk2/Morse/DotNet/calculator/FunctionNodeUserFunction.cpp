#include "StdAfx.h"
#include ".\functionnodeuserfunction.h"
#include ".\FunctionNode.h"
#include ".\FunctionDictionary.h"
#include ".\FunctionContext.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionFactoryParseException.h"
#include ".\FunctionNodeVariable.h"
#include <map>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


typedef FunctionNodeUserFunctionParametesIDs::iterator IDsIterator;
typedef FunctionNodeUserFunctionEvaluator::iterator EvIterator;
typedef FunctionNodeFunctionParameters::iterator ParIterator;

FunctionNodeUserFunction::FunctionNodeUserFunction(int funcNameID, FunctionNodeUserFunctionParametesIDs& ids, FunctionNode* func)
{
   this->func = func;
   this->ids = ids;
   this->funcNameID = funcNameID;
   this->currentOffset = 0;
}

FunctionNodeUserFunction::~FunctionNodeUserFunction(void)
{  

   delete func;
}


size_t FunctionNodeUserFunction::getVariableCount() {
   return ids.size();
}

int FunctionNodeUserFunction::getFunctionNameID() {
   return funcNameID;
}

FunctionNode* FunctionNodeUserFunction::getFunction() {
   return func->clone();
}

int FunctionNodeUserFunction::offset = -10;

FunctionNode* FunctionNodeUserFunction::getSubstitution(FunctionNodeFunctionParameters& par) {

   //cout<<"->\n";

   FunctionContext cx;

   FunctionNode* tmp = func->clone();
   FunctionNodeDependency dep;
   tmp->appendDependency(&dep);
   map<int, int> mp;

   offset--;
   currentOffset++;
   
   for (FunctionNodeDependency::iterator itv = dep.begin(); itv != dep.end(); itv++) {
      int v = (*itv)->getVariableID();
      //cout<<"v="<<v;

      if (v > 0) {
         map<int, int>::const_iterator it = mp.find(v);
         if (it == mp.end()) {
            mp[(*itv)->setVariableID(offset)] = offset;
            //cout<<"<->"<<offset;
            offset--;
            currentOffset++;
         } else  {
            //cout<<"<!>"<<(it->second);
            (*itv)->setVariableID(it->second);
         }
         //cout<<"\n";
      }
   }  

   if (par.size() != ids.size()) throw FunctionFactoryParseException(FunctionFactoryParseException_WrongParamCount);

   ParIterator it = par.begin();
   IDsIterator isit = ids.begin();

   for (; it != par.end(); it++, isit++) {
      //cout<<"id="<<mp[*isit]<<"\n";     
      cx.addSubstitute(mp[*isit], (*it)->clone());
   }

   FunctionNode* ret = tmp->simplify(&cx);
   delete tmp;

   //cout<<"E\n";

   offset += currentOffset;
   currentOffset = 0;

   //cout<<"<-\n";

   return ret;
}



void FunctionNodeUserFunction::print(ostream &o, FunctionDictionary* dic) {
   o<<dic->getName(funcNameID)<<"(";

   for (IDsIterator it = ids.begin(); it != ids.end(); ++it) {
      o<<dic->getName(*it)<<" ";
   }
   o<<") = ";
   func->print(o, dic);
}

double FunctionNodeUserFunction::evaluate(FunctionNodeUserFunctionEvaluator& ev) {
   FunctionContext cx;
   EvIterator evit = ev.begin();
   IDsIterator isit = ids.begin();
   if (ev.size() != ids.size()) throw FunctionFactoryParseException(FunctionFactoryParseException_WrongParamCount);
   
   for (; evit != ev.end(); evit++, isit++) {
      cx.addSubstitute(*isit, new FunctionNodeConstant(*evit));
   }
   return func->evaluate(&cx);
}

FunctionNodeUserFunction* FunctionNodeUserFunction::clone() {
   return new FunctionNodeUserFunction(funcNameID, FunctionNodeUserFunctionParametesIDs(ids), func->clone());
}