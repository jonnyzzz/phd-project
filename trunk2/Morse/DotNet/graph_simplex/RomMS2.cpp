#include "StdAfx.h"
#include ".\romms2.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


CRomMS::CRomMS(FunctionMS* function, Graph* graph) : 
function(function), 
CRom(graph), 
variables(function->getVariables())
{
}

CRomMS::~CRomMS(void)
{
}


double inline CRomMS::cost(Node* node) {
	for (int i=0; i<graph->getDimention(); i++) {
		variables[i] = graph->toExternal(graph->getCells(node)[i], i);
	}
	return function->Ro() * factor;
}