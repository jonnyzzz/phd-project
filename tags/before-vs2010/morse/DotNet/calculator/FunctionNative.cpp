#include "StdAfx.h"
#include ".\functionnative.h"
#include ".\functionNode.h"
#include ".\FunctionContext.h"
#include ".\FunctionDictionary.h"
#include ".\FunctionNodeVariable.h"
#include ".\FunctionNodeConstant.h"
#include ".\FunctionNodeSum.h"
#include ".\FunctionNodeSub.h"
#include ".\FunctionNodeMul.h"
#include ".\FunctionNodeDiv.h"
#include ".\FunctionNodePower.h"
#include ".\FunctionNodeUMinus.h"
#include ".\FunctionNodeUnary.h"
#include ".\FunctionFactoryParseException.h"
#include ".\FunctionNodeMin.h"
#include ".\FunctionNodeMax.h"
#include ".\FunctionNodeIfLZ.h"
#include ".\FunctionNodeUnaryCos.h"
#include ".\FunctionNodeUnatySin.h"
#include <algorithm>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


FunctionNative::FunctionNative(FunctionNode* source, FunctionNativeVariableSequence& seq, double* variables)
{
   this->source = source->simplify(&FunctionContext());
   delete source;
   this->dependency = new FunctionNodeDependency;
   this->variables = variables;
   this->sequence = FunctionNativeVariableSequence(seq);

   createVariables();

   compile();
}

FunctionNative::~FunctionNative(void)
{
   delete dependency;
   delete source;
   delete[] procedure;
   //if (variables != NULL) delete[] variables;
}


void FunctionNative::createVariables() {
   source->appendDependency(dependency);

   for (FunctionNativeVariableSequence::iterator it = sequence.begin();
      it != sequence.end();
      it++)
   {
	   variablesID.push_back(*it);
   }

   for (FunctionNodeDependency::iterator it = dependency->begin(); 
      it != dependency->end();
      it++)
   {
      int v = (*it)->getVariableID();
	  
      if (find(variablesID.begin(), variablesID.end(), v) == variablesID.end()) {
         variablesID.push_back(v);
		 throw FunctionFactoryParseException(FunctionFactoryParseException_Native_VariableNotDefined);
      }
   }

   length = variablesID.size();
 
   //variables = new double[length]; due to constructor entry
   double* tmp = variables;

   for (Variables::iterator it = variablesID.begin(); it != variablesID.end(); it++) {
      substitution[*it] = tmp++;
   }
}


void FunctionNative::publishCode(uchar* code) {
	uchar* p = procedure;

	while (p != procedure_end) {
		*code++ = *p++;
	}
}

void FunctionNative::compile() {

   procedure = new uchar[1<<18];
   uchar* code = procedure;

   stackUse = 0;

   code = compileFunctionNode(code, source);
   
   //fld [esp]
   *code++ = 0xdd;
   *code++ = 0x04;
   *code++ = 0x24;

   //add esp,8h
   *code++ = 0x83;
   *code++ = 0xc4;
   *code++ = 0x08;

   //ret
   *code++ = 0xc3;   

   procedure_end = code;

   DWORD dummy;
   DWORD ret = VirtualProtect(procedure, 1<<18, PAGE_EXECUTE_READWRITE, &dummy);
   if (ret == 0) {
	   cout<<"Failed to protect memory\n";
   }
}


void FunctionNative::print(ostream& o, FunctionDictionary* dic) {
   o<<"Function to compile:\n";
   source->print(o, dic);
   o<<"\nDependency raw:\n";
   for (FunctionNodeDependency::iterator it = dependency->begin(); it != dependency->end(); it++) {
      o<<(*it)->getVariableID()<<"\t"<<dic->getName((*it)->getVariableID())<<"\n";
   }
   o<<"\nSet of variables:\n";
   for (Variables::iterator it = variablesID.begin(); it != variablesID.end(); it++) {
      o<<*it<<"\t"<<dic->getName(*it)<<"\n";
   }
   o<<"\nLength="<<(unsigned int)length<<"\n";
   o<<"\nDump complete\n\n";
}


double* FunctionNative::getVariables() {
   return variables;
}

double FunctionNative::evaluate() {
   void* proc = (void*)this->procedure;
   _asm {
      push eax
      mov eax, proc
      call eax

      pop eax
   }
   //answer is in st(0)
}

//////////////////// asm  ///////////////////////////////

uchar* FunctionNative::compileDWord(uchar* code, uint value) {
   *code++ = (value>>0) & 0xff;
   *code++ = (value>>8) & 0xff;
   *code++ = (value>>16) & 0xff;
   *code++ = (value>>24) & 0xff;
   return code;
}

uchar* FunctionNative::compileDoubleDoubleNCall(uchar* code, void* routine, int paramCount) {

   //mov eax, (uint)routine
   *code++ = 0xb8;
#pragma warning(push)
#pragma warning (disable : 4311)
   code = compileDWord(code, (uint)routine);
#pragma warning(pop)

   //all params from stack, suppose it was double
   //call eax
   *code++ = 0xff;
   *code++ = 0xd0;

   //cleanup stack
   //add esp, (8*(paramCount - 1)
   *code++ = 0x83;
   *code++ = 0xc4;
   *code++ = (uchar)(8*(paramCount - 1));

   //fstp [esp]
   *code++ = 0xdd;
   *code++ = 0x1c;
   *code++ = 0x24;

   return code;
}

//put value to CPU stack
uchar* FunctionNative::compileConstant(uchar* code, double value) {
   //push *(uint*)&value[1]
   *code++ = 0x68;
   code = compileDWord(code, ((uint*)&value)[1]);
   //push *(uint*)&value[0]
   *code++ = 0x68;
   code = compileDWord(code, ((uint*)&value)[0]);
   return code;
}

uchar* FunctionNative::compileVariable(uchar* code, FunctionNodeVariable* var) {
   double* value = substitution[var->getVariableID()];   
	#pragma warning(push)
	#pragma warning (disable : 4311)
   uint addr_b = (uint)((uint*)value + 1);
   #pragma warning(pop)

   //mov eax, int
   *code++ = 0xb8;
   code = compileDWord(code, addr_b);
   //push [eax]
   *code++ = 0xff;
   *code++ = 0x30;
   //sub eax, 4h // eax == addr_a
   *code++ = 0x83;
   *code++ = 0xe8;
   *code++ = 0x04;
   //push [eax]
   *code++ = 0xff;
   *code++ = 0x30;

   return code;
}

uchar* FunctionNative::compileSum(uchar* code, FunctionNodeSum* node) {
   code = compileFunctionNode(code, node->getRight());
   code = compileFunctionNode(code, node->getLeft()); 

   //fld [esp]
   *code++ = 0xdd;
   *code++ = 0x04;
   *code++ = 0x24;

   //add esp, 8
   *code++ = 0x83;
   *code++ = 0xc4;
   *code++ = 0x08;

   //fadd [esp]
   *code++ = 0xdc;
   *code++ = 0x04;
   *code++ = 0x24;

   //fstp [esp]
    *code++ = 0xdd;
   *code++ = 0x1c;
   *code++ = 0x24;

   return code;
}

uchar* FunctionNative::compileSub(uchar* code, FunctionNodeSub* node) {
   code = compileFunctionNode(code, node->getRight());
   code = compileFunctionNode(code, node->getLeft()); 

   //fld [esp]
   *code++ = 0xdd;
   *code++ = 0x04;
   *code++ = 0x24;

   //add esp, 8
   *code++ = 0x83;
   *code++ = 0xc4;
   *code++ = 0x08;

   //fsub [esp]
   *code++ = 0xdc;
   *code++ = 0x24;
   *code++ = 0x24;

   //fstp [esp]
    *code++ = 0xdd;
   *code++ = 0x1c;
   *code++ = 0x24;


   return code;
}

uchar* FunctionNative::compileMul(uchar* code, FunctionNodeMul* node) { 
   code = compileFunctionNode(code, node->getRight());
   code = compileFunctionNode(code, node->getLeft());

   //fld [esp]
   *code++ = 0xdd;
   *code++ = 0x04;
   *code++ = 0x24;

   //add esp, 8
   *code++ = 0x83;
   *code++ = 0xc4;
   *code++ = 0x08;

   //fmul [esp]
   *code++ = 0xdc;
   *code++ = 0x0c;
   *code++ = 0x24;

   //fstp [esp]
    *code++ = 0xdd;
   *code++ = 0x1c;
   *code++ = 0x24;

   return code;
}

uchar* FunctionNative::compileDiv(uchar* code, FunctionNodeDiv* node) {
   code = compileFunctionNode(code, node->getRight());
   code = compileFunctionNode(code, node->getLeft()); 

   //fld [esp]
   *code++ = 0xdd;
   *code++ = 0x04;
   *code++ = 0x24;

   //add esp, 8
   *code++ = 0x83;
   *code++ = 0xc4;
   *code++ = 0x08;

   //fdiv [esp]
   *code++ = 0xdc;
   *code++ = 0x34;
   *code++ = 0x24;

   //fstp [esp]
    *code++ = 0xdd;
   *code++ = 0x1c;
   *code++ = 0x24;

   return code;
}

uchar* FunctionNative::compileUMinus(uchar* code, FunctionNodeUMinus* node) {
   code = compileFunctionNode(code, node->getValue());

   //fld [esp]
   *code++ = 0xdd;
   *code++ = 0x04;
   *code++ = 0x24;

   //fchs 
   *code++ = 0xd9;
   *code++ = 0xe0;

   //fstp [esp]
    *code++ = 0xdd;
   *code++ = 0x1c;
   *code++ = 0x24;

   return code;
}

uchar* FunctionNative::compileCos(uchar* code, FunctionNodeUnaryCos* node) {
   code = compileFunctionNode(code, node->getValue());

   //fld [esp]
   *code++ = 0xdd;
   *code++ = 0x04;
   *code++ = 0x24;

   //fcos
   *code++ = 0xd9;
   *code++ = 0xff;

   //fstp [esp]
    *code++ = 0xdd;
   *code++ = 0x1c;
   *code++ = 0x24;

   return code;
}

uchar* FunctionNative::compileSin(uchar* code, FunctionNodeUnarySin* node) {
   code = compileFunctionNode(code, node->getValue());

   //fld [esp]
   *code++ = 0xdd;
   *code++ = 0x04;
   *code++ = 0x24;

   //fsin
   *code++ = 0xd9;
   *code++ = 0xfe;

   //fstp [esp]
    *code++ = 0xdd;
   *code++ = 0x1c;
   *code++ = 0x24;

   return code;
}


double inline mypow(double a, double b) {
   return pow(a,b);
}

double inline myatan(double a) {
   return atan(a);
}

double inline myexp(double a) {
   return exp(a);
}

double inline mylog(double a) {
   return log(a);
}

double inline mytan(double a) {
   return tan(a);
}

double inline mymin(double a, double b) {
   return (a<b)?a:b;
}

double inline mymax(double a, double b) {
   return (a>b)?a:b;
}

double inline myiflz(double c, double a, double b) {
   return (c<0)?a:b;
}

//todo:TBD
uchar* FunctionNative::compileIntPower(uchar* code, FunctionNodePower* pw, int power) {
	/*
	if (power == 0) {		
		return code;
	} else if (power % 2 == 0) {
		//fmul st(0), st
		*code++ = 0xdc;
		*code++ = 0xc8;
		return compileIntPower(code, pw, power/2);
	} else  {
		
		code = compileFunctionNode(code, node->getBase()); 

		//fmul st(1), st(0)
		*code++ = 0xdc;
		*code++ = 0xc9;
		//fld pw->getExponent()->evaluate() -> st(1) any time
		//fmul
		return compileIntPower(code, pw, power-1);
	}

	*/

	ASSERT(false);
	return NULL;
}

uchar* FunctionNative::compilePower(uchar* code, FunctionNodePower* node) {
    code = compileFunctionNode(code, node->getExponent());
	code = compileFunctionNode(code, node->getBase()); 

	code = compileDoubleDoubleNCall(code, &mypow, 2);
	
   return code;
}

//routine is function: double->double
uchar* FunctionNative::compileFunctionNodeUnary(uchar* code, FunctionNodeUnary* node, void* routine) {
   code = compileFunctionNode(code, node->getValue());

   code = compileDoubleDoubleNCall(code, routine, 1);

   return code;
}

uchar* FunctionNative::compileMin(uchar* code, FunctionNodeMin* node) {
   code = compileFunctionNode(code, node->getRight());
   code = compileFunctionNode(code, node->getLeft());
   code = compileDoubleDoubleNCall(code, &mymin, 2);

   return code;
}

uchar* FunctionNative::compileMax(uchar* code, FunctionNodeMax* node) {
   code = compileFunctionNode(code, node->getRight());
   code = compileFunctionNode(code, node->getLeft());
   code = compileDoubleDoubleNCall(code, &mymax, 2);

   return code;
}


uchar* FunctionNative::compileIfLZ(uchar* code, FunctionNodeIfLZ* node) {
   code = compileFunctionNode(code, node->getCs());
   code = compileFunctionNode(code, node->getTr());
   code = compileFunctionNode(code, node->getFl());   
   code = compileDoubleDoubleNCall(code, &myiflz, 3);

   return code;
}


uchar* FunctionNative::compileFunctionNode(uchar* code, FunctionNode* node) {
   switch (node->type()) {
      case FunctionNodeType_Constant:
         code = compileConstant(code, ((FunctionNodeConstant*)node)->getValue());
         break;
      case FunctionNodeType_Variable:
         code = compileVariable(code, (FunctionNodeVariable*)node);
         break;
      case FunctionNodeType_Sum:
         code = compileSum(code, (FunctionNodeSum*)node);
         break;
      case FunctionNodeType_Sub:
         code = compileSub(code, (FunctionNodeSub*)node);
         break;
      case FunctionNodeType_Mul:
         code = compileMul(code, (FunctionNodeMul*)node);
         break;
      case FunctionNodeType_Div:
         code = compileDiv(code, (FunctionNodeDiv*)node);
         break;
      case FunctionNodeType_UMinus:
         code = compileUMinus(code, (FunctionNodeUMinus*)node);
         break;
      case FunctionNodeType_Power:
         code = compilePower(code, (FunctionNodePower*)node);
         break;
      case FunctionNodeType_ArcTg:
         code = compileFunctionNodeUnary(code, (FunctionNodeUnary*) node, &myatan);
         break;
      case FunctionNodeType_Cos:
         code = compileCos(code, (FunctionNodeUnaryCos*) node);
         break;
      case FunctionNodeType_Exp:
         code = compileFunctionNodeUnary(code, (FunctionNodeUnary*) node, &myexp);
         break;
      case FunctionNodeType_Ln:
         code = compileFunctionNodeUnary(code, (FunctionNodeUnary*) node, &mylog);
         break;
      case FunctionNodeType_Sin:
         code = compileSin(code, (FunctionNodeUnarySin*) node);
         break;
      case FunctionNodeType_Tg:
         code = compileFunctionNodeUnary(code, (FunctionNodeUnary*) node, &mytan);
         break;
      case FunctionNodeType_Min:
         code = compileMin(code, (FunctionNodeMin*) node);
         break;
      case FunctionNodeType_Max:
         code = compileMax(code, (FunctionNodeMax*) node);
         break;
      case FunctionNodeType_IfLZ:
         code = compileIfLZ(code, (FunctionNodeIfLZ*) node);
         break;

      default:
		  throw FunctionFactoryParseException(FunctionFactoryParseException_Native_UnableToCompileNode);
         break;
   }
   return code;
}


///////////////////////////////////////////////////////////

