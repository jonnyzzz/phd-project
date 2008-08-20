#pragma once
#include "functionnode.h"

class FunctionNodeVariable :
	public FunctionNode
{
public:
	FunctionNodeVariable(int variableID);
	virtual ~FunctionNodeVariable(void);
public:
	virtual double evaluate(FunctionContext* cx);
	virtual bool canSimplify(FunctionContext* cx);
	virtual FunctionNode* simplify(FunctionContext* cx);
	virtual FunctionNode* diff(int variableID);
	virtual FunctionNode* clone();
	virtual void print(ostream& o, FunctionDictionary* dic);

public:
	virtual void appendDependency(FunctionNodeDependency* dependency);
	virtual FunctionNodeType type();
	virtual void Accept(FunctionNodeVisitor* visitor);

public:
	int getVariableID();
	int setVariableID(int variableID);

private:
	int variableID;
};
