#pragma once
#include "functionnode.h"

class FunctionNodeDiv :
	public FunctionNode
{
public:
	FunctionNodeDiv(FunctionNode* left, FunctionNode* right);
	virtual ~FunctionNodeDiv(void);

public:
	virtual double evaluate(FunctionContext* cx);
	virtual bool canSimplify(FunctionContext* cx);
	virtual FunctionNode* simplify(FunctionContext* cx);
	virtual FunctionNode* diff(int variableID);
	virtual FunctionNode* clone();

	virtual void Accept(FunctionNodeVisitor* visitor);

public:
	virtual void print(ostream& o, FunctionDictionary* dic);

public:
	virtual void appendDependency(FunctionNodeDependency* dependency);
	virtual FunctionNodeType type();

public:
	FunctionNode* getLeft();
	FunctionNode* getRight();

private:
	FunctionNode* left;
	FunctionNode* right;
};
