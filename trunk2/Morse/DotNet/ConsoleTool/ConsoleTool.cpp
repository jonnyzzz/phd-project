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


GraphSet Process(GraphSet set) {

	ISystemFunction *func = new TorstenFunction();//IteratatedSystemFunction<TorstenFactory, 5>(); //

	int factor[] = {2,2};
	ConsoleProgressBarInfo info;

	AbstractProcess* ps = new SimpleBoxProcess(set[0], func, factor, &info);
	return AbstractProcess::Apply(ps, set);
}



int main(int argc, char** argv) {

	TorstenFactory::Dump(); 	
	
	if (argc != 3) {
		cout<<" file <input> <output>"<<endl;

		GraphSet set(TorstenFactory::CreateGraph());
		Util::SaveGraphSet(set, "test");

		return -1;
	} 
	char* input = argv[1];
	char* output = argv[2];

	cout<<"Loading from "<<input<<endl<<"Saving results to "<<output<<endl<<endl;


	GraphSet in = Util::LoadGraphSet(input);

	return 0;

	GraphSet result = Process(in);

	Util::SaveGraphSet(result, output);

	return 0;
}