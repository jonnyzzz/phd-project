#pragma once
#include "functionnodevisitor.h"

class FunctionContext;

class LipsitzFinder :
	public FunctionNodeVisitor
{
public:
	LipsitzFinder(FunctionContext* leftBound, FunctionContext* rightBound);
	virtual ~LipsitzFinder(void);

public:
	virtual void VisitSub(FunctionNodeSub* node);
	virtual void VisitSum(FunctionNodeSum* node);
	virtual void VisitUMinus(FunctionNodeUMinus* node);
	virtual void VisitATan(FunctionNodeUnaryATan* node);
	virtual void VisitCos(FunctionNodeUnaryCos* node);
	virtual void VisitExp(FunctionNodeUnaryExp* node);
	virtual void VisitLn(FunctionNodeUnaryLn* node);
	virtual void VisitTg(FunctionNodeUnaryTg* node);
	virtual void VisitSin(FunctionNodeUnarySin* node);
	virtual void VisitVariable(FunctionNodeVariable* node);
	virtual void VisitPower(FunctionNodePower* node);
	virtual void VisitMul(FunctionNodeMul* node);
	virtual void VisitMin(FunctionNodeMin* node);
	virtual void VisitMax(FunctionNodeMax* node);
	virtual void VisitIfLZ(FunctionNodeIfLZ* node);
	virtual void VisitDiv(FunctionNodeDiv* node);
	virtual void VisitConstant(FunctionNodeConstant* node);
	virtual void VisitFunction(FunctionNodeFunction* node);

private:
	double ret_val;
	FunctionContext* leftBound;
	FunctionContext* rightBound;
};
