#pragma once
#include <set>
#include <list>
#include <map>

#include "FunctionNode.h"

class FunctionDictionary;
class FunctionContext;
class FunctionNodeSum;
class FunctionNodeSub;
class FunctionNodeMul;
class FunctionNodeDiv;
class FunctionNodeUMinus;
class FunctionNodePower;
class FunctionNodeUnary;
class FunctionNodeMin;
class FunctionNodeMax;
class FunctionNodeIfLZ;
class FunctionNodeUnaryCos;
class FunctionNodeUnarySin;

typedef map<int, double*> Substitution;
typedef list<int> Variables;
typedef unsigned char uchar;
typedef unsigned int uint;

typedef list<int> FunctionNativeVariableSequence;

///this class generate code for a function call, The return value should be placed in the top of co-processor stack
///Code array will be deleted after destructor call!

class FunctionNative
{
public:
	FunctionNative(FunctionNode* node, FunctionNativeVariableSequence& seq, double* variables);
	~FunctionNative(void);

private:
	void compile();

	void createVariables();
	
public:
	double evaluate();
	double* getVariables(); //never changes.
	
public:
	void print(ostream& o, FunctionDictionary* dic);

public:
	void publishCode(uchar* code);


private:
	uchar* procedure;
	uchar* procedure_end;
	double* variables;
	size_t length;


private:
	FunctionNode* source;
	FunctionNodeDependency* dependency;
	
	Substitution substitution; //varID -> double* relations
	Variables variablesID;

	FunctionNativeVariableSequence sequence;

	int stackUse;

public:
	static uchar* compileDWord(uchar* code, uint value);
	static uchar* compileDoubleDoubleNCall(uchar* code, void* routine, int paramCount);

private:
    uchar* compileConstant(uchar* code, double value);
	uchar* compileVariable(uchar* code, FunctionNodeVariable* var);
	uchar* compileSum(uchar* code, FunctionNodeSum* sum);
	uchar* compileSub(uchar* code, FunctionNodeSub* sub);
	uchar* compileMul(uchar* code, FunctionNodeMul* mul);
	uchar* compileDiv(uchar* code, FunctionNodeDiv* div);
	uchar* compileUMinus(uchar* code, FunctionNodeUMinus* um);
	uchar* compilePower(uchar* code, FunctionNodePower* pw);
	uchar* compileFunctionNodeUnary(uchar* code, FunctionNodeUnary* unary, void* double2double1);
	uchar* compileMin(uchar* code, FunctionNodeMin* node);
	uchar* compileMax(uchar* code, FunctionNodeMax* node);
	uchar* compileIfLZ(uchar* code, FunctionNodeIfLZ* node);
	uchar* compileCos(uchar* code, FunctionNodeUnaryCos* node);
	uchar* compileSin(uchar* code, FunctionNodeUnarySin* node);

	uchar* compileFunctionNode(uchar* code, FunctionNode* node);

};

