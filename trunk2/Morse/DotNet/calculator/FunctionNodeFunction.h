#pragma once
#include "functionnode.h"
#include "FunctionNodeUserFunction.h"

class FunctionNodeFunction :
	public FunctionNode
{
public:
	FunctionNodeFunction(int functionNameID, FunctionNodeFunctionParameters& params);
	virtual ~FunctionNodeFunction(void);

public:
	virtual double evaluate(FunctionContext* cx);
	virtual bool canSimplify(FunctionContext* cx);
	virtual FunctionNode* simplify(FunctionContext* cx);
	virtual FunctionNode* diff(int variableID);
	virtual FunctionNode* clone();

public:
	virtual void print(ostream& o, FunctionDictionary* dic);

public:
	virtual void appendDependency(FunctionNodeDependency* dependency);
	virtual FunctionNodeType type();

private:
	FunctionNodeFunctionParameters pars;
	int functionNameID;
};
