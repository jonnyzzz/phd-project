#include "StdAfx.h"
#include ".\sirom.h"
#include "../graph/graph.h"
#include "../systemFunction/isystemfunctionderivate.h"
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

	return log(exhaussDet());
}



double& SIRom::getAt(int i, int j) {
	return output[i+j*dimension + dimension];
}

double inline SIRom::Abs(double x) {
	return (x>0)?x:-x;
}

double inline SIRom::exhaussDet() {
	
	//gaus method for triangle matrix
	double mul = 1;

	for (int i=0; i< dimension; i++) {
		double& diag = getAt(i,i);
		if ( Abs(diag) < 1e-9) {			
			return 0;
		}
		
		for (int j=i+1; j<dimension; j++) {
			getAt(i,j) /= diag;
		}
		mul *= diag;

		diag = 1;
		for (j=i+1; j<dimension; j++) {
			for (int k=dimension-1; k>=i; k--) {
				getAt(j,k) -= getAt(j,i)*getAt(i,k);
			}
		}
	}
	return mul;
}