#include "StdAfx.h"
#include ".\morsetest.h"
#include "objects.h"

MorseTest::MorseTest(void)
{
}

MorseTest::~MorseTest(void)
{
}



typedef smartPointer<ISystemFunction> SmartFunction;


typedef smartPointer<Graph> SmartGraph;
typedef smartPointer<SIPointBuilder> SmartSIPointBuilder;
typedef smartPointer<GraphComponents> SmartComponents;
typedef smartPointer<ISystemFunctionDerivate> SmartDFunction;
typedef smartPointer<AbstractProcess> SmartProcess;
typedef smartPointer<IMorseFunction> SmartMFunction;

typedef pair<double, double> MorsePair;
typedef list< MorsePair > MorseResults;

#define MULTI(x,y) {for(int i=0;i<y;i++){x;}};

void MorseTest::statr() {
	FunctionFactory fac("y1=3*x1;y2=0.2*x2;");

	SmartFunction func = new SystemFunction(&fac, 2);
	SmartDFunction dfunc = new SystemFunctionDerivate(&fac, 2);

	JInt grid[] = {10,10};
	JDouble amin[] = {-1, -1};
	JDouble amax[] = {1, 1};

	
	SmartGraph graph = new Graph(2, amin, amax, grid);
	graph->maximize();

	int factor2[] = {2, 2, 2, 2};
	int factor[] = {5, 5, 5, 5};
	int ks[] = {2, 2, 2, 2};

	//SI image step
	SmartSIPointBuilder sipb = new SIPointBuilder(graph, factor, ks, func);
	sipb->start();
	sipb->processNextGraph(graph);

	SmartGraph result = sipb->result();
	SmartComponents cms = result->localazeStrongComponents();
    
	
	//Extending
	SermentProjectiveExtensionInfo info(dfunc);
	SmartProcess proc = info.graphExtender(cms->getAt(0), factor2, NULL);
	proc->start();
	for (int i=0; i<cms->length(); i++) {
		proc->processNextGraph(cms->getAt(i));
	}

	cms = new GraphComponents();
	cms->addGraphAsComponent(proc->result());

	//MS_Step
	MULTI(
	{
		SmartDFunction dfuncEx = info.systemFunction();
		SmartProcess pb = new MSPointBuilder(cms->getAt(0), factor2, ks, dfuncEx);
		pb->start();
		for (int i=0; i<cms->length(); i++) {
			pb->processNextGraph(cms->getAt(i));
		}
		cms = (result = pb->result())->localazeStrongComponents();
	}, 5);
	

	//Morse
	SmartMFunction mfunc = info.morseFunction();

	MorseResults mresult;

	for (int i=0; i<cms->length(); i++) {
		cms->getAt(i)->resolveEdges(result);

		MorsePair apair;

		CRomFunction2N rom(mfunc, cms->getAt(i));
		rom.minimize();
		cout<<"Minimim = "<<(apair.first = rom.getAnswer())<<"\t";
		rom.maximize();
		cout<<"Maximum = "<<(apair.second = rom.getAnswer())<<"\n";

		mresult.push_back(apair);
	}

	cout<<"\n\n\n\n";
	cout<<"---------------------------------------------------------------------------";
	cout<<"\n\n\n\n";

	for (MorseResults::iterator it = mresult.begin(); it != mresult.end(); it++) {
		MorsePair apair = *it;
		cout<<"Minimim = "<<apair.first<<"\t";
		cout<<"Maximum = "<<apair.second<<"\n";
	}
}



