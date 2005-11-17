#include "stdafx.h"
#include "AdaptiveBoxTest.h"
#include <iostream>
using namespace std;
#include "objects.h"
#include "../cellImageBuilders/SimpleBoxProcess.h"
#include "../systemFunction/ISystemFunction.h"
#include "../systemFunction/ISystemFunctionDerivate.h"
#include "../adaptiveCellImageBuilder/AdaptiveBoxMethod.h"


typedef smartPointer<ISystemFunction> SmartFunction;
typedef smartPointer<Graph> SmartGraph;
typedef smartPointer<GraphComponents> SmartComponents;
typedef smartPointer<ISystemFunctionDerivate> SmartDFunction;
typedef smartPointer<AbstractProcess> SmartProcess;


AdaptiveBoxTest::AdaptiveBoxTest(void) : TestBase("Adaptive Box", cout)
{
}

AdaptiveBoxTest::~AdaptiveBoxTest(void)
{
}



void AdaptiveBoxTest::Test() {
	FunctionFactory fac("y1=5*x1;y2=x2/10;");

	SmartFunction func = new SystemFunction(&fac, 2);
	SmartDFunction dfunc = new SystemFunctionDerivate(&fac, 2);

	JInt grid[] = {10,10};
	JDouble amin[] = {-1, -1};
	JDouble amax[] = {1, 1};

	
	SmartGraph graph = new Graph(2, amin, amax, grid, true);
	graph->maximize();

	JDouble offset1[] = {0.4, 0.4, 0.4, 0.4};
	ProgressBarInfo pinfo;

	int factor2[] = {2, 2, 2, 2};
	int factor[] = {15, 15, 15, 5};
	int ks[] = {2, 2, 2, 2};
    int msFactor[] = {1, 1, 5};
    
    JDouble precision[2];

    
    for (int i=0; i<graph->getDimention(); i++) {precision[i] = graph->getEps()[i]; }
    SmartProcess process = new AdaptiveBoxMethod(func, graph, factor2, precision, &pinfo);
    process->start();
    process->processNextGraph(graph);

    SmartGraph result = process->results()[0];

    SmartComponents cms = result->localazeStrongComponents();

    cout<<"cms->length() = "<<cms->length()<<"\n";

}