#include "StdAfx.h"
#include ".\functioncontext.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeUserFunction.h"
#include ".\FunctionFactoryParseException.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



FunctionContext::FunctionContext(void)
{
}

FunctionContext::~FunctionContext(void)
{
   for (Context::iterator it = context.begin(); it != context.end(); it++) {
      delete it->second;
   }
   for (FuncContext::iterator it = fContext.begin(); it != fContext.end(); it++) {
      delete it->second;
   }
}

FunctionNode* FunctionContext::getSubstitute(int variableID) {
   FunctionNode* node = context[variableID];
   return node;
}

void FunctionContext::addSubstitute(int variableID, FunctionNode* node) {
   FunctionNode* tmp = context[variableID];
   if (tmp != NULL) {
      delete tmp;
   }
   context[variableID] = node;
}

FunctionNodeUserFunction* FunctionContext::getFunctionSubstitute(int variableID) {
   FunctionNodeUserFunction* uf = fContext[variableID];
   return uf;
}

void FunctionContext::addFunctionSubstitute(int variableID, FunctionNodeUserFunction* node) {
   FunctionNodeUserFunction* tmp = fContext[variableID];
   if (tmp != NULL) {
      delete tmp;
   }
   fContext[variableID] = node;
}

void FunctionContext::copyFunctionContext(const FunctionContext& cx) {
   for (FuncContext::const_iterator it = cx.fContext.begin(); it != cx.fContext.end(); it++) {
      addFunctionSubstitute(it->first, it->second->clone());
   }
}

