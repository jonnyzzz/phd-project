#include "StdAfx.h"
#include ".\functionfactory.h"
#include ".\FunctionFactoryParseException.h"
#include ".\FunctionDictionary.h"
#include ".\FunctionContext.h"
#include ".\FunctionNodeVariable.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeSum.h"
#include ".\FunctionNodeSub.h"
#include ".\FunctionNodeMul.h"
#include ".\FunctionNodeDiv.h"
#include ".\FunctionNodePower.h"
#include ".\FunctionNodeUMinus.h"
#include ".\FunctionNodeEquation.h"
#include ".\FunctionNodeUnaryCos.h"
#include ".\FunctionNodeUnatySin.h"
#include ".\FunctionNodeUnaryExp.h"
#include ".\FunctionNodeUnaryLn.h"
#include ".\FunctionNodeUnaryTg.h"
#include ".\FunctionNodeUnaryATan.h"
#include ".\FunctionNodeMin.h"
#include ".\FunctionNodeMax.h"
#include ".\FunctionNodeIfLZ.h"
#include ".\FunctionNodeUserFunction.h"
#include ".\FunctionNodeFunction.h"
#include <stdio.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionFactory::FunctionFactory(const char* src)
{
   length = strlen(src);   
   
   this->source = new char[length+2];    
   char* tmp = source;
   f_source = source;

   while (*src != 0 ) {
      if (isAcceptable(*src)) {
         *tmp++ = *src;
      } 
      src++;
   }
   *tmp++ = '\0';
   *tmp++ = '\0';
   length = strlen(this->source);

   functionDictionary = new FunctionDictionary();  

   parse();

   //print(cout);

   substitute();
}

FunctionFactory::~FunctionFactory(void)
{
   delete[] f_source;
   delete functionDictionary;
   for (FunctionEquations::iterator i = functionEquations.begin(); 
      i != functionEquations.end(); 
      ++i) {
      delete i->second;
   }
   for (FunctionUserFunctions::iterator i = functionUsers.begin(); 
      i != functionUsers.end(); 
      ++i) {
      delete i->second;
   }
}


/////////////  parser   /////////////////////////////////

bool inline FunctionFactory::isDelim(const char ch) {
   switch (ch) {
      case '+':
      case '-':
      case '=':
      case '(':
      case ')':
      case ';':
      case '*':
      case '/':
      case ',':	
      case '\0':
      case '^':
         return true;
      default:
         return false;
   }
}

bool inline FunctionFactory::isEnd(const char ch) {
   switch (ch) {
      case '\0':
      case ';':
         return true;
      default:
         return false;
   }
}

bool inline FunctionFactory::isAcceptable(const char ch) {
   return isalnum(ch) || isDelim(ch) || ch=='.' || ch=='_';
}

int FunctionFactory::getVariable() {
   char *buffer = new char[length + 2];

   char *tmp = buffer;
   while (!isEnd(*source) && !isDelim(*source)) {
      *tmp++ = *source++;
   }
   *tmp++ = '\0';


   char *link;
   strtod(buffer, &link);

   if (*link == '\0') throw FunctionFactoryParseException(FunctionFactoryParseException_IndeferExpected);
   
   int id = functionDictionary->registerVariable(buffer);

   delete[] buffer;

   return id;
}

void FunctionFactory::parse() {
   while (*source != '\0') {
      parseFormula();               
   }
}

void FunctionFactory::appendEquation(FunctionNodeEquation* equ) {
   functionEquations[equ->getVariableID()] = equ;
}

void FunctionFactory::appendFunction(FunctionNodeUserFunction* func) {
   functionUsers[func->getFunctionNameID()] = func;
}

void FunctionFactory::parseFormula() {
   int lexID = getVariable();
   if (*source == '(') {
      //parseFunction
      FunctionNodeUserFunctionParametesIDs ids;    
      do {
		  if (*source != ',' && *source != '(') throw FunctionFactoryParseException(FunctionFactoryParseException_BracketExpected, source);
         source++;
         ids.push_back( getVariable() );
      } while (*source == ',');
      if (*source++ != ')') throw FunctionFactoryParseException(FunctionFactoryParseException_BracketExpected, source);
	  if (*source++ != '=') throw FunctionFactoryParseException(FunctionFactoryParseException_EqualsExpected, source);

      appendFunction( new FunctionNodeUserFunction(lexID, ids, parseEquation()));

      
   } else {
      //parse equation
      if (*source != '=') throw FunctionFactoryParseException(FunctionFactoryParseException_EqualsExpected, source);
      source++;
      
      appendEquation(new FunctionNodeEquation(lexID, parseEquation()));    
      
      
   }
}

///////////////////////////////// ordinary parser  ////////////////////
FunctionNode* FunctionFactory::parseValue() {
   if (*source == '(') {
      source++;
      FunctionNode* ret = parseSum();
      if (*source != ')') throw FunctionFactoryParseException(FunctionFactoryParseException_BracketExpected, source);
      source++;
      return ret;
   }

   if (*source == '-') {
      source++;
      return new FunctionNodeUMinus(parseValue());
   }

   char* buffer = new char[length];
   char* tmp = buffer;

   while (!isEnd(*source) && !isDelim(*source)) {
      *tmp++ = *source++;
   }
   *tmp++ ='\0';

   FunctionNode* ret;

   if (*source == '(') {
      ret = parsePredefinedFunction(buffer);
   } else {

      char* end;

      double value = strtod(buffer, &end);
      if (end < tmp-1) {
         ret = new FunctionNodeVariable(functionDictionary->registerVariable(buffer));
      } else {
         ret = new FunctionNodeConstant(value);
      }
   }

   delete[] buffer;

   return ret;
}

FunctionNode* FunctionFactory::parsePredefinedFunction(char* buffer) {
   FunctionNode* ret = NULL;
   source++;
   if (stricmp(buffer, "cos") == 0) {
      ret = new FunctionNodeUnaryCos(parseSum());
   } else if (stricmp(buffer, "sin") == 0) {
      ret = new FunctionNodeUnarySin(parseSum());
   } else if (stricmp(buffer, "tg") == 0 || stricmp(buffer, "tan") == 0 ) {
      ret = new FunctionNodeUnaryTg(parseSum());
   } else if (stricmp(buffer, "exp") == 0) {
      ret = new FunctionNodeUnaryExp(parseSum());
   } else if (stricmp(buffer, "ln") == 0) {
      ret = new FunctionNodeUnaryLn(parseSum());
   } else if ((stricmp(buffer, "atan") == 0) || (stricmp(buffer, "arctg") == 0)) {
      ret = new FunctionNodeUnaryATan(parseSum());
   } else if (stricmp(buffer, "max") == 0) {
      FunctionNode* a = parseSum();
	  if (*source++ != ',') throw FunctionFactoryParseException(FunctionFactoryParseException_SemicolumnExpected, source);
      FunctionNode* b = parseSum();
      ret = new FunctionNodeMax(a, b);
   } else if (stricmp(buffer, "min") == 0) {
      FunctionNode* a = parseSum();
      if (*source++ != ',') throw FunctionFactoryParseException(FunctionFactoryParseException_SemicolumnExpected, source);
      FunctionNode* b = parseSum();
      ret = new FunctionNodeMin(a, b);
   } else if (stricmp(buffer, "iflz") == 0) {
      FunctionNode* a = parseSum();
      if (*source++ != ',') throw FunctionFactoryParseException(FunctionFactoryParseException_SemicolumnExpected, source);
      FunctionNode* b = parseSum();
      if (*source++ != ',') throw FunctionFactoryParseException(FunctionFactoryParseException_SemicolumnExpected, source);
      FunctionNode* c = parseSum();
      ret = new FunctionNodeIfLZ(a, b,c);
   } else {
      FunctionNodeFunctionParameters pars;
      source--;
      do {
         if (*source != ',' && *source !='(') throw FunctionFactoryParseException(FunctionFactoryParseException_SemicolumnExpected, source);
         source++;
         pars.push_back(parseSum());
      } while (*source == ',');
        
      ret = new FunctionNodeFunction(functionDictionary->registerVariable(buffer), pars);
   }

   if (*source++ != ')') throw FunctionFactoryParseException(FunctionFactoryParseException_BracketExpected, source);

    return ret;
}


FunctionNode* FunctionFactory::parsePower() {
   FunctionNode* a = parseValue();

   while (!isEnd(*source) && *source == '^') {
      source++;
      a = new FunctionNodePower(a, parseValue());
   }
   return a;
}

FunctionNode* FunctionFactory::parseMul() {
   FunctionNode* a = parsePower();

   while (!isEnd(*source) && (*source == '*' || *source == '/')) {      
      switch (*source) {
         case '*': 
            source++;
            a = new FunctionNodeMul(a, parsePower());
            break;
         case '/':
            source++;
            a = new FunctionNodeDiv(a, parsePower());
            break;
      }
   }
   return a;
}

FunctionNode* FunctionFactory::parseSum() {
   FunctionNode* a = parseMul();

   while (!isEnd(*source) && (*source == '+' || *source == '-')) {
      switch (*source) {
         case '+': 
            source++;
            a = new FunctionNodeSum(a, parseMul());
            break;
         case '-':
            source++;
            a = new FunctionNodeSub(a, parseMul());
            break;
      }
   }
   return a;
}

FunctionNode* FunctionFactory::parseEquation() {
   FunctionNode* node = parseSum();
   if (!isEnd(*source)) throw FunctionFactoryParseException(FunctionFactoryParseException_FormulaEndExpected, source);
   source++;
   return node;
}


void FunctionFactory::print(ostream& o) {
   o<<"FunctionFactoryContext:\n";
   for (FunctionEquations::iterator it = functionEquations.begin(); it != functionEquations.end(); it++) {
      o<<(it->first)<<"\t"<<functionDictionary->getName(it->first)<<"\t";
      it->second->print(o, functionDictionary);
      o<<"\n";
   }

   o<<"Functions:\n";
   for (FunctionUserFunctions::iterator it = functionUsers.begin(); it!= functionUsers.end(); it++) {
      o<<(it->first)<<"\t"<<functionDictionary->getName(it->first)<<"\t";
      it->second->print(o, functionDictionary);
      o<<"\n";
   }
   o<<"End.\n\n";
}

FunctionDictionary* FunctionFactory::getFunctionDictionary() {
   return functionDictionary;
}

void FunctionFactory::substitute() {
   FunctionContext context;
   
   //fill context up   
   for (FunctionEquations::iterator it = functionEquations.begin(); it != functionEquations.end(); it++) {
      context.addSubstitute(it->first, it->second->getFunctionNode()->clone());
   }
   
   for (FunctionUserFunctions::iterator it = functionUsers.begin(); it!= functionUsers.end(); it++) {
	   context.addFunctionSubstitute(it->first, it->second->clone());
   }


   //substitute if possible. [it's not so perfect way.]
   //todo: check for loops in substitutions -- in FunctionNodeEquation constructor
   //todo:? substitutions in function bodys (but not implemented working with functions at all)
   for (FunctionEquations::iterator it = functionEquations.begin(); it != functionEquations.end(); it++) {
      FunctionNodeEquation* tmp = it->second;
      it->second = new FunctionNodeEquation(it->first, tmp->getFunctionNode()->simplify(&context));
      delete tmp;
   }
}

FunctionNode* FunctionFactory::getEquation(int variableID) {
	if (functionEquations[variableID] == NULL) throw FunctionFactoryParseException(FunctionFactoryParseException_NoSuchEquation);
   return functionEquations[variableID]->getFunctionNode()->clone();
}

FunctionNode* FunctionFactory::getEquation(const char* variable) {
   return getEquation(functionDictionary->lookUp(variable));
}