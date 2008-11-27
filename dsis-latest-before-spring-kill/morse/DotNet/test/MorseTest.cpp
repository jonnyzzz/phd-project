#include "StdAfx.h"
#include ".\morsetest.h"
#include "objects.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MorseTest::MorseTest(void)
{
}

MorseTest::~MorseTest(void)
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

void MorseTest::statr() {
	FunctionFactory fac("y1=3*x1;y2=1/3*x2;");

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
	int factor[] = {5, 5, 5, 5};
	int ks[] = {2, 2, 2, 2};

	//SI image step
	SmartProcess sipb = new SIOverlapedPointBuilder(graph, factor, ks, offset1, offset1, func, &pinfo);
	sipb->start();
	sipb->processNextGraph(graph);

	SmartGraph result = sipb->result();
	SmartComponents cms = result->localazeStrongComponents();
    
	
	//Extending
	SermentProjectiveExtensionInfo info(dfunc);
	SmartProcess proc = info.graphExtender(cms->getAt(0), factor2, &pinfo);
	proc->start();
	for (int i=0; i<cms->length(); i++) {
		proc->processNextGraph(cms->getAt(i));
	}

	cms = new GraphComponents();
	cms->addGraphAsComponent(proc->result());

	//MS_Step
	MULTI(
	{
		SmartDFunction dfuncEx = info.getSystemFunction();        
		SmartProcess pb = new MSOverlapedPointBuilder(cms->getAt(0), factor2, ks, offset1, offset1, (SegmentProjectiveExtendedSystemFunction*)(dfuncEx.object()), &pinfo);
		pb->start();
		for (int i=0; i<cms->length(); i++) {
			pb->processNextGraph(cms->getAt(i));
		}
		cms = (result = pb->result())->localazeStrongComponents();
	}, 5);
	

	//Morse
	MorseResults mresult;

	for (int i=0; i<cms->length(); i++) {
		cms->getAt(i)->resolveEdges(result);

		MorsePair apair;

		CRom* rom = info.morse(cms->getAt(i));
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



