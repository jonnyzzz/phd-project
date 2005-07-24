#pragma once

#include "functionnode.h"
#include "functionnodeSub.h"
#include "functionNodeSum.h"
#include "functionNodeUMinus.h"
#include "functionNodeUnaryATan.h"
#include "functionNodeUnaryCos.h"
#include "functionNodeUnaryExp.h"
#include "functionNodeUnaryLn.h"
#include "functionNodeUnaryTg.h"
#include "functionNodeUnatySin.h"
#include "functionNodeVariable.h"
#include "functionNodePower.h"
#include "functionNodeMul.h"
#include "functionNodeMin.h"
#include "functionNodeMax.h"
#include "functionNodeIfLZ.h"
#include "functionNodeDiv.h"
#include "functionNodeConstant.h"
#include "functionNodeFunction.h"

class FunctionNodeVisitor
{
public:
	FunctionNodeVisitor(void);
	virtual ~FunctionNodeVisitor(void);


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
};
