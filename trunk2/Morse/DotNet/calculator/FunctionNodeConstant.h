#pragma once
#include "functionnode.h"

class FunctionNodeConstant :
	public FunctionNode
{
public:
	FunctionNodeConstant(double value);
	virtual ~FunctionNodeConstant(void);

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

public:
	double getValue();

private:
	double value;
};
