#pragma once

class FunctionNode;
class FunctionContext;
class FunctionDictionary;


#include <list>
typedef list<int> FunctionNodeUserFunctionParametesIDs;
typedef list<double> FunctionNodeUserFunctionEvaluator;
typedef list<FunctionNode*> FunctionNodeFunctionParameters;


class FunctionNodeUserFunction
{
public:
	FunctionNodeUserFunction(int funcNameID, FunctionNodeUserFunctionParametesIDs& ids, FunctionNode* func);
	virtual ~FunctionNodeUserFunction(void);

public:
	size_t getVariableCount();
	int getFunctionNameID();
	FunctionNode* getFunction();
	FunctionNode* getSubstitution(FunctionNodeFunctionParameters& par);

	FunctionNodeUserFunction* clone();

public:
	double evaluate( FunctionNodeUserFunctionEvaluator& ev);

public:
	void print(ostream& o, FunctionDictionary* dictionary);
	
private:
	FunctionNodeUserFunctionParametesIDs ids;
	FunctionNode* func;
	int funcNameID;
	
	int currentOffset;

private:
	static int offset;

};
