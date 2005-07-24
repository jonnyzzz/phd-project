#pragma once
#include "functionnode.h"

class FunctionNodeMin :
	public FunctionNode
{
public:
	FunctionNodeMin(FunctionNode* left, FunctionNode* right);
	virtual ~FunctionNodeMin(void);
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
	virtual void Accept(FunctionNodeVisitor* visitor);

public:
	FunctionNode* getLeft();
	FunctionNode* getRight();

private:
	FunctionNode* left;
	FunctionNode* right;
};
