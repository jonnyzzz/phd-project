#include "StdAfx.h"
#include "../systemfunction/isystemfunction.h"
#include ".\computator.h"
#include ".\Function.h"
#include ".\Graph.h"
#include ".\SIComputationProcess.h"
#include ".\MS2ComputationProcess.h"
#include ".\MS2CreationComputationProcess.h"
#include ".\GraphComponents.h"
#include ".\FileStream.h"
#include ".\FunctionMS.h"
#include "..\graph_simplex\Rom.h"
#include "..\graph_simplex\RomMS2.h"
#include ".\GraphException.h"
#include "../cellImageBuilders/SIPointBuilder.h"
#include "../cellImageBuilders/MSCreationProcess.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


Computator::Computator(void)
{
}

Computator::~Computator(void)
{
}


GraphComponents* Computator::performSIPoint(Graph* graph, ISystemFunction* function, JInt* devider, JInt* ks, ProgressBarInfo* info) {
	cout<<"Point method!\n";

	info->setBounds();

	SIPointBuilder* bls = new SIPointBuilder(graph, devider, ks, function, info);

	bls->start();
	bls->processNextGraph(graph);

	Graph* tmp = bls->result();

	GraphComponents* cm = strong_edges(tmp);

	delete tmp;
	delete bls;

	return cm;
}
GraphComponents* Computator::performSIPoint(GraphComponents* cms, ISystemFunction* function, JInt* devider, JInt* ks, ProgressBarInfo* info) {
	cout<<"Symbolic Image on Graph Components Points\n";

	if (cms->length() == 0) throw GraphException(GraphException_NoParameters);

	info->setBounds(cms->length());

	SIPointBuilder* bls = new SIPointBuilder(cms->getAt(0), devider, ks, function, info);
	bls->start();

	for (int i=0; i<cms->length(); i++) {
		bls->processNextGraph(cms->getAt(i));
	}

	Graph* preResult = bls->result();

	GraphComponents* cm = strong_edges(preResult);

	delete preResult;
	delete bls;

	return cm;  
}

Graph* Computator::toMS(Graph* graph, JInt* factor) {
	cout<<"Start\n";

	MSCreationProcess* ps = new MSCreationProcess(graph, factor);

	cout<<"Created\n";
	ps->start();

	cout<<"Started\n";
	ps->processNextGraph(graph);

	cout<<"processed\n";

	Graph* answ = ps->result();

	cout<<"result\n";

	delete ps;

	cout<<"deleted\n";

	return answ;
}

Graph* Computator::toMS(GraphComponents* cms, JInt* factor) {
	if (cms->length() == 0) throw GraphException(GraphException_NoParameters);

	MSCreationProcess* ps = new MSCreationProcess(cms->getAt(0), factor);
	ps->start();

	for (int i=0; i<cms->length(); i++) {
		ps->processNextGraph(cms->getAt(i));
	}

	Graph* answ = ps->result();

	delete ps;

	return answ;
}

GraphComponents* Computator::performSI(Graph* graph, Function* function, int* devider) {
	cout<<"Symbolic Image on Graph\n";

	SIComputationProcess pr(function, graph, devider);

	pr.nextStep(graph);

	Graph* preResult = pr.getComputationResult();

	GraphComponents* cm = strong_edges(preResult);

	delete preResult;
	return cm;  
}

GraphComponents* Computator::performSI(GraphComponents* cms, Function* function, int* devider) {
	cout<<"Symbolic Image on Graph Components\n";

	if (cms->length() == 0) throw GraphException(GraphException_NoParameters);

	SIComputationProcess pr(function, cms->getAt(0), devider);

	for (int i=0; i<cms->length(); i++) {
		pr.nextStep(cms->getAt(i));
	}

	Graph* preResult = pr.getComputationResult();

	GraphComponents* cm = strong_edges(preResult);

	delete preResult;

	return cm;  
}


template <class MSComputationProcess>
inline GraphComponents* Computator::_performMS(GraphComponents* cms, Function* function, JInt* factor) {
	if (cms->length() == 0) throw GraphException(GraphException_NoParameters);

	cout<<"Projective Bundle on GraphComponents\n";

	MSComputationProcess pr(function, cms->getAt(0), factor);

	for (int i=0; i<cms->length(); i++) {
		pr.nextStep(cms->getAt(i));
	}

	Graph* preResult = pr.getResult();

	GraphComponents* cm = strong_edges(preResult);

	delete preResult;

	cout<<"Projective Bundle on GraphComponents   -->> OK\n";

	return cm;  
}

template <class MSComputationProcess>
inline GraphComponents* Computator::_performMS(Graph* graph, Function* function, JInt* factor) {
	cout<<"Projective Bundle on Graph\n";

	MSComputationProcess pr(function, graph, factor);

	pr.nextStep(graph);

	Graph* preResult = pr.getResult();

	GraphComponents* cm = strong_edges(preResult);

	delete preResult;

	cout<<"Projective Bundle on Graph -> OK\n";

	return cm;  
}

GraphComponents* Computator::performMS(Graph* graph, Function* function, JInt* factor) {
	switch (graph->getDimention()) {
		default:
			throw GraphException(GraphException_NoImplementation);
			break;
		case 3:
			return _performMS<MS2ComputationProcess>(graph, function, factor);
	}
	return NULL;
}

GraphComponents* Computator::performMS(GraphComponents* cms, Function* function, JInt* factor) {
	if (cms->length() == 0) throw GraphException(GraphException_NoParameters);

	switch (cms->getAt(0)->getDimention()) {
		default:
			throw GraphException(GraphException_NoImplementation);
			break;
		case 3:
			return _performMS<MS2ComputationProcess>(cms, function, factor);
	}
	return NULL;
}


GraphComponents* Computator::performMSPoint(Graph* graph, Function* function, JInt* factor, int* ks) {
    /*
	MSUniversalPointBuilder* ub = new MSUniversalPointBuilder(graph, function, factor, ks);
	ub->start();

	ub->processNextGraph(graph);

	Graph* g = ub->result();

	GraphComponents* cms = strong_edges(g);
	delete g;

	delete ub;

	return cms;
    */
    ASSERT(false);
    return NULL;
}

GraphComponents* Computator::performMSPoint(GraphComponents* cms, Function* function, JInt* factor, int* ks) {
    /*
	if (cms->length() == 0) throw GraphException(GraphException_NoParameters);
	
	MSUniversalPointBuilder* ub = new MSUniversalPointBuilder(cms->getAt(0), function, factor, ks);
	ub->start();

	for (int i=0; i<cms->length(); i++) {
		ub->processNextGraph(cms->getAt(i));
	}

	Graph* g = ub->result();

	GraphComponents* cmst = strong_edges(g);
	delete g;

	delete ub;

	return cmst;    
    */
    ASSERT(false);
    return NULL;
}


Computator::MorseResult Computator::performMorse(Graph* graph, Function* function) {
	FunctionMS* functionMS = new FunctionMS(function);
	MorseResult res;
	{
		CRomMS rom(functionMS, graph);
		rom.minimize();
		res.lower = rom.getAnswer();
		res.lowerLength = rom.getAnswerLength();
	//}{
	//	CRom rom(graph, functionMS);
		rom.maximize();
		res.upper = rom.getAnswer();
		res.upperLength = rom.getAnswerLength();
	}
	return res;

}


GraphComponents* Computator::strong(Graph* graph) {
	return graph->localazeStrongComponents();
}

GraphComponents* Computator::strong_edges(Graph* graph) {
	GraphComponents* cm = strong(graph);
	for (int i=0; i<cm->length(); i++) {
		cm->getAt(i)->resolveEdges(graph);
	}
	return cm;
}





