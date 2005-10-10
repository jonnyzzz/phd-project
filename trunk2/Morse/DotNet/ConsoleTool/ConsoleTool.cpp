// ConsoleTool.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <iostream>
#include <fstream>
using namespace std;

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
#include "../SegmentIterator/SegmentIterator.h"

#include "../cellImageBuilders/TarjanProcess.h"
#include "LogisticsMap.h"



#define FACTORY TorstenFactory
//#define FACTORY LogisticsMapFactory
#define SYSTEM  TorstenFunction
//#define SYSTEM  LogisticsMap


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
   cout<<"prog -line 5 in out ; line iterations"<<endl;
}
	


int main(int argc, char** argv) {
	
	FACTORY::Dump();

	cout<<argc<<endl;

	/*
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

		for (int i=0; i<its; i++) {
			cout<<endl<<endl<<"Iteration "<<i+1<<" from "<<its<<endl<<endl;
			in = Process(in);
			char buff[2048];
			sprintf(buff,"%s.temp.%d", output, i);

			Util::SaveGraphSet(in, buff);

		}

		Util::SaveGraphSet(in, output);

		cout<<"Program Ended"<<endl<<endl;
	} else if (strcmp(argv[1], "-export") == 0) {
            cout<<"Loading from "<<argv[2]<<endl<<"Saving results to "<<argv[3]<<endl<<endl;
			Util::ExportPoints(Util::LoadGraphSet(argv[2]), argv[3]);
	} else if (strcmp(argv[1], "-line") == 0) {*/
		ISystemFunction *func = new SYSTEM();
		SegmentIterator it(func);
		//int its = 0;
		//sscanf(argv[2],"%d", &its);

		//it.Start(argv[3]);
		double one[] = {0,0};
		double two[] = {0.1, 0.1};
		it.Start(one, two);

		double prec[] = {0.1, 0.1};

		//for (int i=0; i<its; i++) 
			it.Iterate(prec);

		//it.ExportToFile(argv[4]);

			cout<<"Done!\n";
		
		delete func;	/*	
	}else DIE(-1);*/

	cout<<endl<<endl<<endl;

	return 0;
}

