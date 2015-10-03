#include "StdAfx.h"
#include ".\functionnodevisitor.h"

FunctionNodeVisitor::FunctionNodeVisitor(void)
{
}

FunctionNodeVisitor::~FunctionNodeVisitor(void)
{
}


void FunctionNodeVisitor::VisitSub(FunctionNodeSub* node) {
}
void FunctionNodeVisitor::VisitSum(FunctionNodeSum* node) {
}
void FunctionNodeVisitor::VisitUMinus(FunctionNodeUMinus* node){
}
void FunctionNodeVisitor::VisitATan(FunctionNodeUnaryATan* node){
}
void FunctionNodeVisitor::VisitCos(FunctionNodeUnaryCos* node){
}
void FunctionNodeVisitor::VisitExp(FunctionNodeUnaryExp* node){
}
void FunctionNodeVisitor::VisitLn(FunctionNodeUnaryLn* node) {
}
void FunctionNodeVisitor::VisitTg(FunctionNodeUnaryTg* node){
}
void FunctionNodeVisitor::VisitSin(FunctionNodeUnarySin* node) {
}
void FunctionNodeVisitor::VisitVariable(FunctionNodeVariable* node){
}
void FunctionNodeVisitor::VisitPower(FunctionNodePower* node) {
}
void FunctionNodeVisitor::VisitMul(FunctionNodeMul* node) {
}
void FunctionNodeVisitor::VisitMin(FunctionNodeMin* node){
}
void FunctionNodeVisitor::VisitMax(FunctionNodeMax* node) {
}
void FunctionNodeVisitor::VisitIfLZ(FunctionNodeIfLZ* node) {
}
void FunctionNodeVisitor::VisitDiv(FunctionNodeDiv* node) {
}
void FunctionNodeVisitor::VisitConstant(FunctionNodeConstant* node){
}
void FunctionNodeVisitor::VisitFunction(FunctionNodeFunction* node) {
}
