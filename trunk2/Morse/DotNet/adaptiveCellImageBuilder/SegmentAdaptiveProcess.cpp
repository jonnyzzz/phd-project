#include "stdafx.h"
#include "..\graph\graphUtil.h"
#include "SegmentAdaptiveProcess.h"
#include "SegmentPointGraph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SegmentAdaptiveProcess::SegmentAdaptiveProcess(SegmentProjectiveExtendedSystemFunction* function, Graph* graph, JInt* division, double* precision, size_t upperLimit, ProgressBarInfo* info)
: AdaptiveProcessBase(function, graph, division, precision, info)
{	
	processor = new SegmentPointGraphProcessor(this->resultGraph, function, graph->getDimention(), precision, upperLimit);
	dim = graph->getDimention();
	dimBase = dim/2;
	grid = new JInt[dim];
	this->division = new JInt[dim];
	for(int i=0; i<dim; i++) {
		//see CoordinateSystem.cpp :: Interfsects(JInt*) for details
		grid[i] = graph->getGrid()[i]-1;
		this->division[i] = division[i] - 1;
	}
}

SegmentAdaptiveProcess::~SegmentAdaptiveProcess(void)
{
	delete[] grid;
	delete[] division;
	delete processor;
}

void SegmentAdaptiveProcess::initB(JInt* b, const JInt* cell) {
	for (int i=0; i<dimBase; i++) {
		b[i] = 0;
	}
	for (int i=dimBase; i<dim; i++) {
		b[i] = (b[i] == grid[i]) ? this->division[i] : 0;
	}
	b[dim] = 0;
}

void SegmentAdaptiveProcess::processResultNode(Node* node) {    
    processor->ProcessNode(node);
}
