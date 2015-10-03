#include "StdAfx.h"
#include ".\functionnodeequation.h"
#include ".\functionNode.h"
#include ".\FunctionDictionary.h"
#include ".\FunctionFactoryParseException.h"
#include ".\FunctionNodeVariable.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNodeEquation::FunctionNodeEquation(int variableID, FunctionNode* root)
{
   this->variableID = variableID;
   this->root = root;
   FunctionNodeDependency dep;
   root->appendDependency(&dep);

   for (FunctionNodeDependency::iterator it = dep.begin(); it != dep.end(); it++) {
      if ((*it)->getVariableID() == variableID) 
		  throw FunctionFactoryParseException(FunctionFactoryParseException_RecursiveDefinition);
   }

}

FunctionNodeEquation::~FunctionNodeEquation(void)
{
   delete root;
}

FunctionNode* FunctionNodeEquation::getFunctionNode() {
	return root;
}

int FunctionNodeEquation::getVariableID() {
   return variableID;
}


void FunctionNodeEquation::print(ostream& o, FunctionDictionary* dic) {
   o<<dic->getName(variableID)<<"=";
   root->print(o, dic);
   o<<";\n";
}