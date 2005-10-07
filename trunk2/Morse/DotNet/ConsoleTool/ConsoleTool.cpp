// ConsoleTool.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "ConsoleTool.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#include "../SystemFunction/IteratatedSystemFunction.h"
#include "TorstenFunction.h"
#include "../cellImageBuilders/SimpleBoxProcess.h"
#include "../graph/Graph.h"
#include "../graph/FileStream.h"
#include "../cellImageBuilders/onsoleProgressBarInfo.h"
#include "Util.h"
#include "../graph/MemoryManager.h"
#include <stdio.h>
#include "../cellImageBuilders/TarjanProcess.h"
#include "LogisticsMap.h"


#define FACTORY TorstenFactory
//LogisticsMapFactory
#define SYSTEM  TorstenFunction
//LogisticsMap


GraphSet Process(GraphSet set) {
                                //new LogisticsMap();//
	ISystemFunction *func = new SYSTEM();//IteratatedSystemFunction<TorstenFactory, 5>(); //

	int factor[] = {2,2};
	ConsoleProgressBarInfo info;

	AbstractProcess* ps = new SimpleBoxProcess(set[0], func, factor, &info);
	TarjanProcess* ts = new TarjanProcess(false, &info);

	GraphSet it = AbstractProcess::Apply(ps, set);

	GraphSet res = AbstractProcess::Apply(ts, it);

	delete ps;
	delete ts;
	delete func;
	set.DeleteGraphs();
	it. DeleteGraphs();

	return res;
}


/**
*  prog -init file    ;create new inital file and exits
*  prog -iter 5 file out ; open file and do 5 iters
*
*
*
**/


#define DIE(x) {die(); return (x);}

void die() {
   cout<<"prog -init file    ;create new inital file and exits"<<endl;
   cout<<"prog -iter 5 file out ; open file and do 5 iters"<<endl;
   cout<<"prog -export file out ; exports file to a list of points"<<endl;
}
	


int main(int argc, char** argv) {
	
	FACTORY::Dump();

	cout<<argc<<endl;

	
	if ( strcmp(argv[1], "-init") == 0 ) {
		GraphSet set(FACTORY::CreateGraph());
		Util::SaveGraphSet(set, argv[2]);
	} else if ( strcmp(argv[1], "-iter") == 0 ) {
		int its = 0;
		sscanf(argv[2],"%d", &its);

					
		char* input = argv[3];
		char* output = argv[4];

		cout<<"Loading from "<<input<<endl<<"Saving results to "<<output<<endl<<endl;


		GraphSet in = Util::LoadGraphSet(input);

		for (int i=0; i<its; i++) 
			in = Process(in);

		Util::SaveGraphSet(in, output);

		cout<<"Program Ended"<<endl<<endl;
	} else if (strcmp(argv[1], "-export") == 0) {
            cout<<"Loading from "<<argv[2]<<endl<<"Saving results to "<<argv[3]<<endl<<endl;
	    Util::ExportPoints(Util::LoadGraphSet(argv[2]), argv[3]);
	} else DIE(-1);

	cout<<endl<<endl<<endl;

	return 0;
}

