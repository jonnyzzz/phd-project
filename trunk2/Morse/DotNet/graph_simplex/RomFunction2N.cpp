#include "StdAfx.h"
#include ".\romfunction2n.h"
#include "../systemfunction/imorsefunction.h"

CRomFunction2N::CRomFunction2N(IMorseFunction* function, Graph* graph) : CRom(graph)
{
    this->input = function->getInput();
    this->output = function->getOutput();
    this->dimenstion = graph->getDimention();
    this->function = function;
    this->graph = graph;
}

CRomFunction2N::~CRomFunction2N(void)
{
}



double CRomFunction2N::cost(Node* node) {
    for (int i=0; i<dimenstion; i++) {
        input[i] = graph->toExternal(graph->getCells(node)[i], i);
    }
    function->evaluate();
    
    cout<<"Conted value = "<<*output<<"\n";

    return *output * factor;
}
