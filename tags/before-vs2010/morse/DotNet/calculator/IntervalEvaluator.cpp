#include "StdAfx.h"
#include ".\intervalevaluator.h"
#include "FunctionContext.h"

IntervalEvaluator::IntervalEvaluator(FunctionContext* leftBound, FunctionContext* rightBound) : 
leftBound(leftBound), rightBound(rightBound)
{
}

IntervalEvaluator::~IntervalEvaluator(void)
{
}

Interval IntervalEvaluator::getValue() {
	return this->ret_value;
}


void IntervalEvaluator::VisitSub(FunctionNodeSub* node) {
	node->getLeft()->Accept(this);
	Interval left = this->ret_value;
	node->getRight()->Accept(this);
	Interval right = this->ret_value;

	this->ret_value = left - right;
}
void IntervalEvaluator::VisitSum(FunctionNodeSum* node) {
	node->getLeft()->Accept(this);
	Interval left = this->ret_value;
	node->getRight()->Accept(this);
	Interval right = this->ret_value;

	this->ret_value = left + right;
}
void IntervalEvaluator::VisitUMinus(FunctionNodeUMinus* node){
	node->getValue()->Accept(this);
	this->ret_value = -this->ret_value;
}

void IntervalEvaluator::VisitATan(FunctionNodeUnaryATan* node){
	node->getValue()->Accept(this);
	this->ret_value = atan(this->ret_value);
}

void IntervalEvaluator::VisitCos(FunctionNodeUnaryCos* node){
	node->getValue()->Accept(this);
	this->ret_value = cos(this->ret_value);
}
void IntervalEvaluator::VisitExp(FunctionNodeUnaryExp* node){
	node->getValue()->Accept(this);
	this->ret_value = exp(this->ret_value);
}
void IntervalEvaluator::VisitLn(FunctionNodeUnaryLn* node) {
	node->getValue()->Accept(this);
	this->ret_value = log(this->ret_value);
}
void IntervalEvaluator::VisitTg(FunctionNodeUnaryTg* node){
	node->getValue()->Accept(this);
	this->ret_value = tan(this->ret_value);
}
void IntervalEvaluator::VisitSin(FunctionNodeUnarySin* node) {
	node->getValue()->Accept(this);
	this->ret_value = sin(this->ret_value);
}
void IntervalEvaluator::VisitVariable(FunctionNodeVariable* node){
	ret_value = Interval( 
		leftBound ->getSubstitute(node->getVariableID())->evaluate(),
	   	rightBound->getSubstitute(node->getVariableID())->evaluate()
		);
}
void IntervalEvaluator::VisitPower(FunctionNodePower* node) {
	node->getBase()->Accept(this);
	Interval base = this->ret_value;
	node->getExponent()->Accept(this);
	Interval exponent = this->ret_value;
	this->ret_value = exp(log(base)*exponent); //todo:Implement it in case way
}
void IntervalEvaluator::VisitMul(FunctionNodeMul* node) {
	node->getLeft()->Accept(this);
	Interval left = this->ret_value;
	node->getRight()->Accept(this);
	Interval right = this->ret_value;

	this->ret_value = left * right;
}
void IntervalEvaluator::VisitMin(FunctionNodeMin* node){
	node->getLeft()->Accept(this);
	Interval left = this->ret_value;
	node->getRight()->Accept(this);
	Interval right = this->ret_value;

	this->ret_value = boost::numeric::min(left,right);
}
void IntervalEvaluator::VisitMax(FunctionNodeMax* node) {
node->getLeft()->Accept(this);
	Interval left = this->ret_value;
	node->getRight()->Accept(this);
	Interval right = this->ret_value;

	this->ret_value = boost::numeric::max(left,right);
}
void IntervalEvaluator::VisitIfLZ(FunctionNodeIfLZ* node) {
	node->getTr()->Accept(this);
	Interval tr = this->ret_value;
	node->getFl()->Accept(this);
	Interval fl = this->ret_value;
	node->getCs()->Accept(this);
	Interval cs = this->ret_value;

	//todo: Incorrect cases for that construction
    if (cs.upper() < 0)
		node->getTr()->Accept(this);
    else /*if (cs.lower() >0) */
		node->getFl()->Accept(this);
    
}
void IntervalEvaluator::VisitDiv(FunctionNodeDiv* node) {
	node->getLeft()->Accept(this);
	Interval left = this->ret_value;
	node->getRight()->Accept(this);
	Interval right = this->ret_value;

	this->ret_value = left/right;
}
void IntervalEvaluator::VisitConstant(FunctionNodeConstant* node){
	this->ret_value = Interval( node->getValue() );
}
void IntervalEvaluator::VisitFunction(FunctionNodeFunction* node) {
  this->ret_value = Interval::whole();	
}

