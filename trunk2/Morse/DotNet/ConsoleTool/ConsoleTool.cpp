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



// The one and only application object

int main(int argc, char** argv) {
	
	if (argc != 2) {
		cout<<" file <input> <output>";
		return -1;
	}

	char* input = argv[1];
	char* output = argv[2];

	ISystemFunction *func = new TorstenFunction();//IteratatedSystemFunction<TorstenFactory, 5>();
	GraphSet in = Util::LoadGraphSet(input);

	int factor[] = {2,2};
	ConsoleProgressBarInfo info;

	AbstractProcess* ps = new SimpleBoxProcess(in[0], func, factor, &info);
	GraphSet result = AbstractProcess::Apply(ps, in);

	Util::SaveGraphSet(result, output);

	return 0;
}