#pragma once
#include "functionnode.h"

class FunctionNodeUnary :
	public FunctionNode
{
public:
	FunctionNodeUnary(FunctionNode* node);
	virtual ~FunctionNodeUnary(void);

public:
	virtual double evaluate(FunctionContext* cx) = 0;
	virtual bool canSimplify(FunctionContext* cx) = 0;
	virtual FunctionNode* simplify(FunctionContext* cx) = 0;
	virtual FunctionNode* diff(int variableID) = 0;
	virtual FunctionNode* clone() = 0;

public:
	virtual void print(ostream& o, FunctionDictionary* dic) = 0;

public:
	virtual void appendDependency(FunctionNodeDependency* dependency);
	virtual FunctionNodeType type() = 0;

public:
	virtual FunctionNode* getValue();

protected:
	FunctionNode* value;   
};
