#pragma once
#include "functionnode.h"

class FunctionNodeIfLZ :
	public FunctionNode
{
public:
	FunctionNodeIfLZ(FunctionNode* cs, FunctionNode* tr, FunctionNode* fl);
	virtual ~FunctionNodeIfLZ(void);

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
	FunctionNode* getCs();
	FunctionNode* getTr();
	FunctionNode* getFl();

private:
	FunctionNode* cs;
	FunctionNode* tr;
	FunctionNode* fl;
};
