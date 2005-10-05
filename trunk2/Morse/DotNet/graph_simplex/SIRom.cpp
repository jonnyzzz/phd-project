#include "stdafx.h"
#include "SIRom.h"
#include "../graph/Graph.h"
#include "../SystemFunction/ISystemFunctionDerivate.h"
#include <math.h>

SIRom::SIRom(Graph* graph, ISystemFunctionDerivate* function) : graph(graph), function(function), CRom(graph)
{
	input = function->getInput();
	output = function->getOutput();
	dimension = function->getFunctionDimension();
}

SIRom::~SIRom(void)
{
}



double SIRom::cost(Node* node) {
	graph->toExternal(graph->getCells(node), input);
	function->evaluate();

	double tmp = (exhaussDet());

	//cout<<"\n\n"<<getAt(0,0)<<"\t"<<getAt(1, 0)<<"\n"<<getAt(0,1)<<"\t"<<getAt(1,1)<<"\nResult="<<tmp<<"\n\n";

	return log(Abs(tmp)) * factor;
}



double& SIRom::getAt(int i, int j) {
	return output[i+j*dimension + dimension];
}

double inline SIRom::Abs(double x) {
	return (x>0)?x:-x;
}

double inline SIRom::exhaussDet() {
	
	//gaus method for triangle matrix

	
	if (dimension == 2) {	
		return getAt(0,0)*getAt(1,1)-getAt(1,0)*getAt(0,1);
	} else if (dimension == 3) {
		return  getAt(0,0) * ( getAt(1,1)*getAt(2,2) - getAt(2,1)*getAt(1,2))
			   -getAt(1,0) * ( getAt(0,1)*getAt(2,2) - getAt(2,1)*getAt(0,2))
			   +getAt(2,0) * ( getAt(0,1)*getAt(1,2) - getAt(1,1)*getAt(2,0));
	} else {
		ASSERT(FALSE);
	}

	return 0;
}
