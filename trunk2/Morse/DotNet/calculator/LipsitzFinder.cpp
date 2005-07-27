#include "StdAfx.h"
#include ".\lipsitzfinder.h"
#include ".\IntervalEvaluator.h"

LipsitzFinder::LipsitzFinder(FunctionContext* leftBound, FunctionContext* rightBound) :
leftBound(leftBound), rightBound(rightBound)
{
}

LipsitzFinder::~LipsitzFinder(void)
{
}


double LipsitzFinder::getValue() {
	return this->ret_val;
}


void LipsitzFinder::VisitSub(FunctionNodeSub* node) {
	node->getLeft()->Accept(this);
	double left = this->ret_val;
	node->getRight()->Accept(this);
	double right = this->ret_val;

	this->ret_val = left + right;
}
void LipsitzFinder::VisitSum(FunctionNodeSum* node) {
	node->getLeft()->Accept(this);
	double left = this->ret_val;
	node->getRight()->Accept(this);
	double right = this->ret_val;

	this->ret_val = left + right;
}
void LipsitzFinder::VisitUMinus(FunctionNodeUMinus* node){
	node->getValue()->Accept(this);
}
void LipsitzFinder::VisitATan(FunctionNodeUnaryATan* node){
	node->getValue()->Accept(this);

	//atan'(x)= 1 / (1 + x^2) <= 1

	IntervalEvaluator evaluator(leftBound, rightBound);	
	node->getValue()->Accept(&evaluator);
	double x2 = square(evaluator.getValue()).upper();
	this->ret_val  =  this->ret_val / (1 + x2);
}
void LipsitzFinder::VisitCos(FunctionNodeUnaryCos* node){
	node->getValue()->Accept(this);
    
	//cos'(x) = -sin(x) <= 1

	IntervalEvaluator evaluator(leftBound, rightBound);	
	node->getValue()->Accept(&evaluator);
	double sin_x = abs(sin(evaluator.getValue())).upper();
	cout<<"Debug: MinMax:"<<"[ "<<evaluator.getValue().lower()<<" , "<<evaluator.getValue().upper()<<" ]"<<"\n";
	Interval ss = sin(evaluator.getValue());
	cout<<"Debug: Sin:"<<"[ "<<ss.lower()<<" , "<<ss.upper()<<" ]"<<"\n";
	cout<<"Debug: Sin_x ="<<sin_x<<"\n";
	this->ret_val  =  this->ret_val * sin_x;
}
void LipsitzFinder::VisitExp(FunctionNodeUnaryExp* node){
	node->getValue()->Accept(this);
    
	//exp'(f(x)) = f(x)*exp(f(x)) * f'(x)

	IntervalEvaluator evaluator(leftBound, rightBound);	
	node->getValue()->Accept(&evaluator);
	double max_x = abs(evaluator.getValue()).upper();
	this->ret_val  =  this->ret_val * max_x;
}
void LipsitzFinder::VisitLn(FunctionNodeUnaryLn* node) {
	node->getValue()->Accept(this);
    
	//ln'(x) = 1/x

	IntervalEvaluator evaluator(leftBound, rightBound);	
	node->getValue()->Accept(&evaluator);
	double min_x = abs( evaluator.getValue() ).lower();
	this->ret_val  =  this->ret_val / min_x;

}
void LipsitzFinder::VisitTg(FunctionNodeUnaryTg* node){
	node->getValue()->Accept(this);
    
	//tan'(x) = 1/cos^2(x) >= 1

	IntervalEvaluator evaluator(leftBound, rightBound);	
	node->getValue()->Accept(&evaluator);
	double cos_x = square(cos(evaluator.getValue())).lower();
	this->ret_val  =  this->ret_val / cos_x;
}
void LipsitzFinder::VisitSin(FunctionNodeUnarySin* node) {
	node->getValue()->Accept(this);
    
	//sin'(x) = cos(x) <= 1

	IntervalEvaluator evaluator(leftBound, rightBound);	
	node->getValue()->Accept(&evaluator);
	double cos_x = abs(cos(evaluator.getValue())).lower();
	this->ret_val  =  this->ret_val * cos_x;
}
void LipsitzFinder::VisitVariable(FunctionNodeVariable* node){
	this->ret_val = 1;
}
void LipsitzFinder::VisitPower(FunctionNodePower* node) {
	//a^b = exp(ln(a)b)
	//(a^b)' = ln(a)b exp(ln(a)b) (ln(a)b)'
	//todo:
	ASSERT(false);
}
void LipsitzFinder::VisitMul(FunctionNodeMul* node) {
	node->getLeft()->Accept(this);
	double leftL = this->ret_val;
	node->getRight()->Accept(this);
	double rightL = this->ret_val;

	IntervalEvaluator evaluator(leftBound, rightBound);
	node->getLeft()->Accept(&evaluator);
	double leftMax = abs(evaluator.getValue()).upper();

	node->getRight()->Accept(&evaluator);
	double rightMax = abs(evaluator.getValue()).upper();

	this->ret_val = leftL*rightMax + rightL*leftMax;
}
void LipsitzFinder::VisitMin(FunctionNodeMin* node){
	node->getLeft()->Accept(this);
	double left = this->ret_val;

	node->getRight()->Accept(this);
	double right = this->ret_val;

	this->ret_val = max(left, right);
}
void LipsitzFinder::VisitMax(FunctionNodeMax* node) {
	node->getLeft()->Accept(this);
	double left = this->ret_val;

	node->getRight()->Accept(this);
	double right = this->ret_val;

	this->ret_val = max(left, right);
}
void LipsitzFinder::VisitIfLZ(FunctionNodeIfLZ* node) {
	node->getFl()->Accept(this);
	double left = this->ret_val;

	node->getTr()->Accept(this);
	double right = this->ret_val;

	this->ret_val = max(left, right);
}
void LipsitzFinder::VisitDiv(FunctionNodeDiv* node) {
	node->getLeft()->Accept(this);
	double leftL = this->ret_val;

	IntervalEvaluator evaluator(leftBound, rightBound);
	node->getRight()->Accept(&evaluator);
	double rightMin = abs(evaluator.getValue()).lower();

	node->getRight()->Accept(&evaluator);
	double leftMax = abs(evaluator.getValue()).upper();

	node->getRight()->Accept(this);
	double rightL = this->ret_val;

	this->ret_val = leftL/rightMin - leftMax*rightL/rightMin/rightMin;	
}
void LipsitzFinder::VisitConstant(FunctionNodeConstant* node){
	this->ret_val = 0;
}
void LipsitzFinder::VisitFunction(FunctionNodeFunction* node) {
	ASSERT(FALSE);
}
