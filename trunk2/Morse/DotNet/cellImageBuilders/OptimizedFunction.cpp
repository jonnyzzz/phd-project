#include "StdAfx.h"
#include ".\optimizedfunction.h"
#include "BuildersException.h"

#include "../calculator/functionNative.h"
#include "../calculator/functionFactory.h"
#include "../calculator/functionContext.h"
#include "../calculator/functionNode.h"
#include "../calculator/functionFactoryParseException.h"


const char Function::FunctionName[] = "y%d";
const char Function::VariableName[] = "x%d";


OptimizedFunction::OptimizedFunction(FunctionFactory* factory) :
	factory(factory)
{

	const int code_len = 65535;

	dimension = (int)factory->getEquation("_dimension")->evaluate(FunctionContext());

	//todo:
	if (dimension <1) throw BuildersException(BuildersException_Wrong_Dimension);

	function = new uchar*[dimension];
	dfunction = new uchar**[dimension];

	char buff[255];

	FunctionNativeVariableSequence seq;
	FunctionDictionary* dic = factory->getFunctionDictionary();

	for (int i=0; i<dimension; i++) {
		sprintf(buff, VariableName, i+1);
		seq.push_back(dic->lookUp(buff));
	}

	variable = new double[dimension * 3]; //double === JDouble!!! ^%)// *3 = whole for MS mode. Not used in FunctionNative

	for (int i=0; i<dimension; i++) {

		sprintf(buff,FunctionName, i+1);
		FunctionNode* node = factory->getEquation(buff);

		function[i] = new uchar[code_len];

		FunctionNative nativeF(node->clone(), seq, variable);		
		nativeF.publishCode(function[i]);

		dfunction[i] = new uchar*[dimension];

		for (int j=0; j<dimension;j++) {
			sprintf(buff, VariableName, j+1);
			FunctionNode* dnode = node->diff(dic->lookUp(buff));
			FunctionNative nF(dnode, seq, variable);
			dfunction[i][j] = new uchar[code_len];
			nF.publishCode(dfunction[i][j]);
		}
		delete node;
	}

}

OptimizedFunction::~OptimizedFunction(void)
{	
	delete factory;
	for (int i=0; i<dimension; i++) {
		delete[] function[i];
	}

	delete[] function;
}



double OptimizedFunction::call(uchar* address) {
   void* proc = (void*)address;
   _asm {
      push eax
      mov eax, proc
      call eax

      pop eax
   }
   //answer is in st(0)
}



uchar* OptimizedFunction::compileDWord(uchar* code, uint value) {
   *code++ = (value>>0) & 0xff;
   *code++ = (value>>8) & 0xff;
   *code++ = (value>>16) & 0xff;
   *code++ = (value>>24) & 0xff;
   return code;
}

///call for a function double f();
uchar* OptimizedFunction::writeCallFunction(uchar* code, void* routine) {
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
   //dec esp, 8. //there is 0 params, but 1 as return
   *code++ = 0x83;
   *code++ = 0xe4;
   *code++ = (uchar)8;

   //fstp [esp]
   *code++ = 0xdd;
   *code++ = 0x1c;
   *code++ = 0x24;

   return code;
}
