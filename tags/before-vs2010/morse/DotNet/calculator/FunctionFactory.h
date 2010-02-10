#pragma once

#include <map>

class FunctionNode;
class FunctionContext;
class FunctionDictionary;
class FunctionNodeVariable;
class FunctionNodeUserFunction;

class FunctionNodeEquation;
typedef map<int, FunctionNodeEquation*> FunctionEquations;
typedef map<int, FunctionNodeUserFunction*> FunctionUserFunctions;



class FunctionFactory
{
public:
	FunctionFactory(const char* source);
	~FunctionFactory(void);

public:
	FunctionDictionary* getFunctionDictionary();

	FunctionNode* getEquation(const char* name);
	FunctionNode* getEquation(int variableID);

	void print(ostream& o);

private:
	bool isDelim(const char ch);
	bool isEnd(const char ch);
	bool isAcceptable(const char ch);

private:
	void parse();
	void substitute();
	void parseFormula();

	void appendEquation(FunctionNodeEquation* equ);
	void appendFunction(FunctionNodeUserFunction* func);

	int getVariable();
	
	FunctionNode* parseValue();
	FunctionNode* parsePredefinedFunction(char* source);
	FunctionNode* parsePower();
	FunctionNode* parseMul();
	FunctionNode* parseSum();

	FunctionNode* parseEquation();

private:
	char* source;
	char* f_source;
	size_t length;
	
	FunctionDictionary* functionDictionary;
	FunctionEquations functionEquations;
	FunctionUserFunctions functionUsers;
};
