#pragma once

#include <list>

class FunctionContext;
class FunctionDictionary;
class FunctionNodeVariable;

enum FunctionNodeType {
	FunctionNodeType_Sum,
	FunctionNodeType_Sub,
	FunctionNodeType_Mul,
	FunctionNodeType_Div,
	FunctionNodeType_UMinus,
	FunctionNodeType_Power,
	FunctionNodeType_Constant,
	FunctionNodeType_Variable,
	FunctionNodeType_Cos,
	FunctionNodeType_Sin,
	FunctionNodeType_Tg,
	FunctionNodeType_ArcTg,
	FunctionNodeType_Exp,
	FunctionNodeType_Ln,
	FunctionNodeType_Min,
	FunctionNodeType_Max,
	FunctionNodeType_IfLZ,
	FunctionNodeType_UserFunction
};

typedef list<FunctionNodeVariable*> FunctionNodeDependency;


class FunctionNode
{
public:
	FunctionNode(void);
	virtual ~FunctionNode(void);

public:
	virtual double evaluate(FunctionContext* cx) = 0;
	double evaluate(FunctionContext& cx);
    double evaluate();

	virtual bool canSimplify(FunctionContext* cx) = 0;
	virtual FunctionNode* simplify(FunctionContext* cx) = 0;
	virtual FunctionNode* diff(int variableID) = 0;
	virtual FunctionNode* clone() = 0;

    FunctionNode* simplify();

public:
	virtual void print(ostream& o, FunctionDictionary* dic) = 0;

public:
	virtual void appendDependency(FunctionNodeDependency* dependency) = 0;
	virtual FunctionNodeType type() = 0;	

protected:
	bool isZero(double value);

};
