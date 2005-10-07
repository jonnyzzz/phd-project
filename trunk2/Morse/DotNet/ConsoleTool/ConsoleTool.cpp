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


GraphSet Process(GraphSet set) {

	ISystemFunction *func = new TorstenFunction();//IteratatedSystemFunction<TorstenFactory, 5>(); //

	int factor[] = {2,2};
	ConsoleProgressBarInfo info;

	AbstractProcess* ps = new SimpleBoxProcess(set[0], func, factor, &info);
	TarjanProcess* ts = new TarjanProcess(false, &info);

	return AbstractProcess::Apply(ts, AbstractProcess::Apply(ps, set));
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
}
	


int main(int argc, char** argv) {
	
	TorstenFactory::Dump();

	cout<<argc<<endl;
	
	
	if (argc == 3) {
		if (strcmp(argv[1], "-init") != 0) DIE(-1);


		GraphSet set(TorstenFactory::CreateGraph());
		Util::SaveGraphSet(set, argv[2]);

	} else if (argc == 5) {
	        if (strcmp(argv[1], "-iter") != 0) DIE(-1);
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
	} else DIE(-1);

	cout<<endl<<endl<<endl;

	return 0;
}

