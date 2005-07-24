#pragma once
#include "functionnode.h"

class FunctionNodeUMinus :
	public FunctionNode
{
public:
	FunctionNodeUMinus(FunctionNode* value);
	virtual ~FunctionNodeUMinus(void);
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
	FunctionNode* getValue();


private:
	FunctionNode* value;

};
