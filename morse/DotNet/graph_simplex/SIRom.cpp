#include "stdafx.h"
#include "SIRom.h"
#include "../graph/Graph.h"
#include "../SystemFunction/ISystemFunctionDerivate.h"
#include <math.h>

SIRom::SIRom(Graph* graph, ISystemFunctionDerivate* function) : CRom(graph), graph(graph), function(function)
{
	input = function->getInput();
	output = function->getOutput();
	dimension = graph->getDimention();

	cout<<"SI Rom for dimension = "<<dimension<<endl;
}

SIRom::~SIRom(void)
{
	cout<<"SIRom dispose"<<endl;
}



double SIRom::cost(Node* node) {
	for (int i=0; i<dimension; i++) {
        input[i] = graph->toExternal(graph->getCells(node)[i], i) + graph->getEps()[i]/2;
    }
    function->evaluate();	
	return log(Abs(exhaussDet())) * factor;
}



double inline SIRom::getAt(int i, int j) {
	return output[i+j*dimension + dimension];
}

double inline SIRom::Abs(double x) {
	return (x>0)?x:-x;
}

double inline SIRom::exhaussDet() {
	
	//gaus method for triangle matrix

	switch (dimension) {
		case 1:
			return getAt(0,0);
		case 2:
			return getAt(0,0)*getAt(1,1)-getAt(1,0)*getAt(0,1);
		case 3:
			//maple generated
			return getAt(0,0)*getAt(1,1)*getAt(2,2)
			  -getAt(0,0)*getAt(1,2)*getAt(2,1)			  
			  +getAt(1,0)*getAt(0,2)*getAt(2,1)
			  -getAt(1,0)*getAt(0,1)*getAt(2,2)
			  +getAt(2,0)*getAt(0,1)*getAt(1,2)
			  -getAt(2,0)*getAt(0,2)*getAt(1,1);
		default:
			ASSERT(false);
	}

	return 0;
}
