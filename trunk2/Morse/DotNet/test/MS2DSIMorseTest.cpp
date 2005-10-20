#include "StdAfx.h"
#include ".\ms2dsimorsetest.h"

#include "objects.h"
#include "../cellImageBuilders/SimpleBoxProcess.h"
#include "../cellImageBuilders/MS2DCreationProcess.h"
#include "../cellImageBuilders/MS2DBoxProcess.h"
#include "../systemFunction/ISystemFunction.h"
#include "../systemFunction/ISystemFunctionDerivate.h"
#include "../systemFunction/MS2DAngleFunction.h"
#include "../systemFunction/MS2DAngleMorseFunction.h"
#include "../cellImageBuilders/MS2DSIBoxProcess.h"

#include <iostream>
using namespace std;

MS2DSIMorseTest::MS2DSIMorseTest(void) : TestBase("MS2DSI", cout)
{
}

MS2DSIMorseTest::~MS2DSIMorseTest(void)
{
}


typedef smartPointer<ISystemFunction> SmartFunction;
typedef smartPointer<Graph> SmartGraph;
typedef smartPointer<GraphComponents> SmartComponents;
typedef smartPointer<ISystemFunctionDerivate> SmartDFunction;
typedef smartPointer<AbstractProcessExt> SmartProcess;
typedef smartPointer<IMorseFunction> SmartMFunction;

typedef pair<double, double> MorsePair;
typedef list< MorsePair > MorseResults;

#define MULTI(x,y) {for(int i=0;i<y;i++){x;}};


Graph* MergeGraphs(GraphComponents* cms); /* {    
    Graph* result = cms->getAt(0)->copyCoordinates(true);

    for (int i=0; i<cms->length(); i++) {
        cms->getAt(i)->resolveEdges(result);

        GraphNodeEnumerator ne(cms->getAt(i));        
        Node* node;
        while( (node = ne.next()) != NULL) {
            Node* rnode = result->browseTo(node);

            GraphEdgeEnumerator ee(cms->getAt(i), node);
            Node* toNode;
            while (toNode = ee.nextTo()) {
                result->browseTo(rnode, result->browseTo(toNode));
            }
        }
    }

    return result;
}
*/

void MS2DSIMorseTest::Test() {
	FunctionFactory fac("y1=2*x1;y2=1/2*x2;");

	SmartFunction func = new SystemFunction(&fac, 2);
	SmartDFunction dfunc = new SystemFunctionDerivate(&fac, 2);

	JInt grid[] = {3,3,3};
	JDouble amin[] = {-1, -1};
	JDouble amax[] = {1, 1};

	
	SmartGraph graph = new Graph(2, amin, amax, grid, true);
	graph->maximize();

	JDouble offset1[] = {0.4, 0.4, 0.4, 0.4};
	ProgressBarInfo pinfo;

	int factor2[] = {2, 2, 2, 2};
	int factor[] = {15, 15, 15, 5};
	int ks[] = {2, 2, 2, 2};
    int msFactor[] = {2, 2, 2};

	//SI image step
    SmartProcess sipb = new SimpleBoxProcess(graph, func, factor, &pinfo);
	sipb->start();
	sipb->processNextGraph(graph);

	SmartGraph aResult = sipb->result();
	SmartComponents cms = aResult->localazeStrongComponents();
    GraphSet siGraph(aResult);

    cout<<"SI Components:"<<cms->length()<<"\n";
    
	SmartProcess proc = new MS2DCreationProcess(aResult, msFactor, &pinfo);
	proc->start();
	for (int i=0; i<cms->length(); i++) {
		proc->processNextGraph(cms->getAt(i));
	}

	cms = new GraphComponents();
	cms->addGraphAsComponent(proc->result());

    //Just to make it work with smarp pointers.
    SmartGraph result(new Graph(1, amin, amax,grid, true));
    
	//MS_Step
	MULTI(
	{
        cout<<"\n\nStarting MS2DPRocess!\n\n";


        MS2DAngleFunction jfunc(dfunc);		
		SmartProcess pb = new MS2DSIBoxProcess(&jfunc, cms->getAt(0), msFactor, &pinfo);
		pb->start();
		for (int i=0; i<cms->length(); i++) {
			pb->processNextGraph(cms->getAt(i));
		}
        
		cms = (result = (pb->result()))->localazeStrongComponents();

        cout<<"cms Length = "<<cms->length()<<"\n";
 	}, 5);

	//Morse
	MorseResults mresult;

	for (int i=0; i<cms->length(); i++) {
		cms->getAt(i)->resolveEdges(result);

		MorsePair apair;
        MS2DAngleMorseFunction jfunc(dfunc);

        CRomFunction2N* rom = new CRomFunction2N(&jfunc, cms->getAt(i));

		rom->minimize();
		cout<<"Minimim = "<<(apair.first = rom->getAnswer())<<"\t";
		rom->maximize();
		cout<<"Maximum = "<<(apair.second = rom->getAnswer())<<"\n";

		delete rom;

		mresult.push_back(apair);
	}

	cout<<"\n\n\n\n";
	cout<<"---------------------------------------------------------------------------";
	cout<<"\n\n\n\n";

	int c = 1;
	for (MorseResults::iterator it = mresult.begin(); it != mresult.end(); it++) {
		MorsePair apair = *it;
		cout<<c++<<"\t";
		cout<<"Minimim = "<<apair.first<<"\t";
		cout<<"Maximum = "<<apair.second<<"\n";
	}
}



