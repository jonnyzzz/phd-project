#pragma once
#include "functionnodeunary.h"

class FunctionNodeUnaryATan :
	public FunctionNodeUnary
{
public:
	FunctionNodeUnaryATan(FunctionNode* node);
	virtual ~FunctionNodeUnaryATan(void);

public:
	virtual double evaluate(FunctionContext* cx);
	virtual bool canSimplify(FunctionContext* cx);
	virtual FunctionNode* simplify(FunctionContext* cx);
	virtual FunctionNode* diff(int variableID);
	virtual FunctionNode* clone();
	virtual FunctionNodeType type();
	virtual void print(ostream& o, FunctionDictionary* dic);
};
