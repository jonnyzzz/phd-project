#pragma once

#include <map>

class FunctionNode;
class FunctionNodeUserFunction;
typedef map<int, FunctionNode*> Context;
typedef map<int, FunctionNodeUserFunction*> FuncContext;


class FunctionContext
{
public:
	FunctionContext(void);
	~FunctionContext(void);

public:
	FunctionNode* getSubstitute(int variableID);
	void addSubstitute(int variableID, FunctionNode* context);

	FunctionNodeUserFunction* getFunctionSubstitute(int funcNameID);
	void addFunctionSubstitute(int variableID, FunctionNodeUserFunction* function);

	void copyFunctionContext(const FunctionContext& cx);
	void copyContext(const FunctionContext& cx);

private:
	Context context;
	FuncContext fContext;

};
