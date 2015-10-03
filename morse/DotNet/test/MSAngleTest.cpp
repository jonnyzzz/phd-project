#include "StdAfx.h"
#include ".\msangletest.h"

#include "objects.h"
#include "../cellImageBuilders/SimpleBoxProcess.h"
#include "../cellImageBuilders/MS2DCreationProcess.h"
#include "../cellImageBuilders/MS2DBoxProcess.h"
#include "../systemFunction/ISystemFunction.h"
#include "../systemFunction/ISystemFunctionDerivate.h"
#include "../systemFunction/MS2DAngleFunction.h"
#include "../systemFunction/MS2DAngleMorseFunction.h"
#include "../cellImageBuilders/MS2DSIBoxProcess.h"
#include "../cellImageBuilders/SegmentProjectiveBundleMSCreationProcess.h"
#include "../cellImageBuilders/MSAngleCreationProcess.h"
#include "../cellImageBuilders/onsoleProgressBarInfo.h"

#include "../AdaptiveCellImageBuilder/MSAngleProcess.h"
#include "../SystemFunction/MSAngleMorseFunction.h"
#include "../SystemFunction/MSAngleFunction.h"

#include <iostream>
using namespace std;

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MSAngleTest::MSAngleTest(void) : TestBase("MSAngle 3D", cout)
{
}

MSAngleTest::~MSAngleTest(void)
{
}


typedef smartPointer<ISystemFunction> SmartFunction;
typedef smartPointer<Graph> SmartGraph;
typedef smartPointer<GraphComponents> SmartComponents;
typedef smartPointer<ISystemFunctionDerivate> SmartDFunction;
typedef smartPointer<AbstractProcess> SmartProcess;
typedef smartPointer<IMorseFunction> SmartMFunction;
typedef smartPointer<FunctionFactory> SmartFactory;

typedef pair<double, double> MorsePair;
typedef list< MorsePair > MorseResults;

#define MULTI(x,y) {for(int i=0;i<y;i++){x;}};


Graph* MergeGraphs(GraphComponents* cms);

void MSAngleTest::Test() {
	FunctionFactory* fac = new FunctionFactory("y1=1/2*x1;y2=1/2*x2;y3=1*x3;");

	SmartFunction func = new SystemFunction(fac, 3);
	SmartDFunction dfunc = new SystemFunctionDerivate(fac, 3);

	JInt grid[] =    {  1,   1,   1,  1,  1, 1};
	JDouble amin[] = {-10, -10, -10, -1, -1,-1};
	JDouble amax[] = { 10,  10,  10,  1,  1, 1};

	
	SmartGraph graph = new Graph(3, amin, amax, grid, true);
	graph->maximize();
 
	JDouble offset1[] = {0.4, 0.4, 0.4, 0.4};
	ConsoleProgressBarInfo pinfo;

	int factor2[] = {2, 2, 2, 2, 2, 2};
	int factor[] = {4, 4, 4, 4, 4, 4};
	int ks[] = {1, 1, 1, 2, 2, 2};
    int msFactor[] =  {1, 1, 1, 1, 1, 1};
    int msFactor2[] = {1, 1, 1, 2, 2, 2};
	double precision[6];

	//SI image step
    SmartProcess sipb = new SimpleBoxProcess(graph, func, factor, &pinfo);
	sipb->start();
	sipb->processNextGraph(graph);

	SmartGraph aResult = sipb->results()[0];
	SmartComponents cms = aResult->localazeStrongComponents();
    GraphSet siGraph(aResult);

    cout<<"SI Components:"<<cms->length()<<"\n";
    		
	SmartProcess proc = new MSAngleCreationProcess(aResult, msFactor, &pinfo);
	proc->start();
	for (int i=0; i<cms->length(); i++) {
		proc->processNextGraph(cms->getAt(i));
	}

	cms = new GraphComponents();
	cms->addGraphAsComponent(proc->results()[0]);

	cout<<"Graph nodes :"<<cms->getAt(0)->getNumberOfNodes()<<endl;

    //Just to make it work with smarp pointers.
    SmartGraph result(new Graph(1, amin, amax,grid, true));
    
	cout<<"---> CMS "<<cms->length()<<endl;

	//MS_Step
	MULTI(
	{
        cout<<"\n\nStarting MSAdaptiveProcess!\n\n";

		for (int i=0; i<6; i++) {
			precision[i] = cms->getAt(0)->getEps()[i]/3/msFactor2[i];
		}
		
		SmartProcess pb = new MSAngleProcess(func, dfunc, cms->getAt(0), msFactor2, precision, &pinfo);
		pb->start();
		for (int i=0; i<cms->length(); i++) {
			pb->processNextGraph(cms->getAt(i));
		}
        
		cms = (result = (pb->results()[0]))->localazeStrongComponents();

        cout<<"cms Length = "<<cms->length()<<"\n";
 	},3);

	//Morse
	MorseResults mresult;

	for (int i=0; i<cms->length(); i++) {
		cms->getAt(i)->resolveEdges(result);

		MorsePair apair;
		MSAngleMorseFunction* jfunc = new MSAngleMorseFunction(dfunc);

        CRomFunction2N* rom = new CRomFunction2N(jfunc, cms->getAt(i));

		rom->minimize();
		cout<<"Minimim = "<<(apair.first = rom->getAnswer())<<"\t";
		rom->maximize();
		cout<<"Maximum = "<<(apair.second = rom->getAnswer())<<"\n";

		delete rom;
		delete jfunc;

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

	pinfo.Next();

	delete fac;
}

