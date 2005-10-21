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
#include "../cellImageBuilders/StableLocalizationProcess.h"
#include "../cellImageBuilders/SIPointBuilder.h"
#include "../cellImageBuilders/MS2DBoxProcess.h"
#include "../cellImageBuilders/MS2DCreationProcess.h"
#include "../SystemFunction/MS2DAngleFunction.h"
#include "../SystemFunction/MS2DAngleMorseFunction.h"
#include "../graph_simplex/RomFunction2N.h"
#include "../cellImageBuilders/MS2DSIBoxProcess.h"

#include "LogisticsMap.h"
#include "ParametrisedLogisticsMap.h"
#include <math.h>



#define FACTORY TorstenFactory
//#define FACTORY LogisticsMapFactory
//#define FACTORY ParametrisedLogisticsMapFactory
#define SYSTEM  TorstenFunction
//#define SYSTEM  LogisticsMap
//#define SYSTEM  ParametrisedLogisticsMap


GraphSet Process(GraphSet set) {
                                //new LogisticsMap();//
	ISystemFunction *func = new SYSTEM();//IteratatedSystemFunction<TorstenFactory, 5>(); //

	int factor[] = {2,2};
	int ks[] = {4,1};
	ConsoleProgressBarInfo info;

	AbstractProcess* ps = new SimpleBoxProcess(set[0], func, factor, &info);
	//SIPointBuilder* ps = new SIPointBuilder(set[0], factor, ks, func, &info);
	TarjanProcess* ts = new TarjanProcess(true, &info);
	//StableLocalizationProcess *ss = new StableLocalizationProcess(&info);

	GraphSet it = AbstractProcess::Apply(ps, set);
	GraphSet res = AbstractProcess::Apply(ts, it);
	//GraphSet ans = AbstractProcess::Apply(ss, res);

	delete ps;
	delete ts;
	delete func;
	//res.DeleteGraphs();
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
   cout<<"prog -line 5 1 in out ; line iterations"<<endl;
   cout<<"prog -iter_m 5 1 inSI inMS out ; line iterations"<<endl;
   cout<<"prog -iter_all 5 5 text_out; iterate 5 steps in SI, 5 steps in MS, Morse to out"<<endl;
}
	


void ProcessMS(GraphSet& set, MS2DAngleFunction* afunc, bool needEdge, int* factor, ProgressBarInfo* info) {
	MS2DSIBoxProcess* ps = new MS2DSIBoxProcess(afunc, set[0], factor, info);
	GraphSet tmp = AbstractProcess::Apply(ps, set);
	set.DeleteGraphs();
	set = tmp;

	TarjanProcess* ts = new TarjanProcess(needEdge, info);
	tmp = AbstractProcess::Apply(ts, set);
	set.DeleteGraphs();
	set = tmp;
}



int main(int argc, char** argv) {
	
	FACTORY::Dump();

	cout<<argc<<endl;

       
	if ( strcmp(argv[1], "-init") == 0 ) {
		GraphSet set(FACTORY::CreateGraph());
		Util::SaveGraphSet(set, argv[2]);
	}else if ( strcmp(argv[1], "-iter_all") == 0 ) {
		int itsSI = 0;
		int itsMSOnly = 0;
		int itsMSSym = 0;
		sscanf(argv[2],"%d", &itsSI);
		sscanf(argv[3],"%d", &itsMSOnly);
		sscanf(argv[4],"%d", &itsMSSym);
		
		char* output = argv[5];

		TorstenFunction::beta = 3.5;
		TorstenFunctionDerivate::beta = 3.5;

		TorstenFactory::Dump();

		cout<<"Loading from "<<endl<<"Saving results to "<<output<<endl<<endl;

		GraphSet set(TorstenFactory::CreateGraph());

		ConsoleProgressBarInfo* info = new ConsoleProgressBarInfo();
		ISystemFunction* func = new IteratatedSystemFunction<TorstenFunction>(5);// new TorstenFunction();
		ISystemFunctionDerivate* dfunc = new TorstenFunctionDerivate();
		MS2DAngleFunction* afunc = new MS2DAngleFunction(dfunc);
		MS2DAngleMorseFunction* mfunc = new MS2DAngleMorseFunction(dfunc);

		for (int i=0; i<itsSI; i++) {
			cout<<endl<<endl<<"Iteration SI"<<i+1<<" from "<<itsSI<<endl<<endl;
			
			int factor[] = {2,2};
			AbstractProcess* ps = new SimpleBoxProcess(set[0], func, factor, info);
			TarjanProcess* ts = new TarjanProcess(false, info);

			GraphSet it = AbstractProcess::Apply(ps, set);
			GraphSet res = AbstractProcess::Apply(ts, it);

			delete ps;
			delete ts;
			set.DeleteGraphs();
			it. DeleteGraphs();

			set = res;
		}

		if (itsMSSym != 0 || itsMSOnly != 0) {

			cout<<endl<<"SI State Finished"<<endl<<"Extending graph..."<<endl<<endl;

			{
				int factor[] = {1,1,1};
				MS2DCreationProcess* ps = new MS2DCreationProcess(set[0], factor, info);
				GraphSet res = AbstractProcess::Apply(ps, set);
				set.DeleteGraphs();
				set = res;
			}

			cout<<endl<<"Performing MS Stage Sym"<<endl;

			for (int i=0; i<itsMSSym; i++) {
				cout<<endl<<"MS Sym iteration step "<<i+1<<" from "<<itsMSSym<<" Components : "<<set.Length()<<endl;
				{
					int factor[] = {1,1,2};			
					ProcessMS(set, afunc, false, factor, info);
				}

				{
					int factor[] = {1,2,1};			
					ProcessMS(set, afunc, false, factor, info);
				}
				{
					int factor[] = {2,1,1};			
					ProcessMS(set, afunc, (i+1 == itsMSSym) && (itsMSOnly == 0) , factor, info);
				}			
			}

			cout<<endl<<"Performing MS Stage Only"<<endl;

			for (int i=0; i<itsMSOnly; i++) {
				cout<<endl<<"MS Only iteration step "<<i+1<<" from "<<itsMSOnly<<" Components : "<<set.Length()<<endl;
				int factor[] = {1,1,2};
				ProcessMS(set, afunc, (i+1 == itsMSOnly), factor, info);
			}


		     
			
			cout<<"Computation of Morse Spectrum Started\n";
			cout<<"We have "<<set.Length()<<" strong components"<<endl;

			char buff[2048];
			sprintf(buff, "%s.morse", output);
			ofstream fo;
			fo.open(buff);

			for (GraphSetIterator it = set.iterator(); it.HasNext(); it.Next()) {
				CRomFunction2N rom(mfunc, it);
				rom.minimize();

				double lower = rom.getAnswer();
				int lowerL = rom.getAnswerLength();
				fo<<rom.getAnswer()<<" "<<rom.getAnswerLength()<<endl;
				fo.flush();

				rom.maximize();

				double upper = rom.getAnswer();
				int upperL = rom.getAnswerLength();

				fo<<rom.getAnswer()<<rom.getAnswerLength();
				fo.flush();


				fo<<"Estimated Morse Spectrum for Component of "<<it->getNumberOfNodes()<<":"<<it->getNumberOfArcs()<<" finished with result"<<endl;
				fo<<"[ "<<scientific<<lower<<" ,   "<<scientific<<upper<<" ]"<<endl<<endl;
				fo.flush();
			}

			fo.close();
		} else {
		  Util::ExportPoints(set, output);
		}

		cout<<"Program Ended"<<endl<<endl;
	}else if ( strcmp(argv[1], "-iter_tst") == 0 ) {
		int itsSI = 0;		
		sscanf(argv[2],"%d", &itsSI);		
		char* output = argv[3];

		TorstenFunction::beta = 3.5;
		TorstenFunctionDerivate::beta = 3.5;

		TorstenFactory::Dump();

		cout<<"Loading from "<<endl<<"Saving results to "<<output<<endl<<endl;

		

		ConsoleProgressBarInfo* info = new ConsoleProgressBarInfo();

		int fpower = 1;
		bool isOk = false;

		ofstream fo;
		char buff[2048];
		sprintf(buff, "%s.power", output);
		fo.open(buff);

		GraphSet set;
		
		do {
			isOk = true;
			//cout<<"Trying iteration of function : "<<fpower<<endl<<endl;
			fo<<"try power "<<fpower<<"....";
			fo.flush();

			ISystemFunction* func = new IteratatedSystemFunction<TorstenFunction>(fpower);// new TorstenFunction();
			set = GraphSet(TorstenFactory::CreateGraphEx());

			for (int i=0; i<itsSI; i++) {
				//cout<<endl<<endl<<"Iteration SI"<<i+1<<" from "<<itsSI<<endl<<endl;

				if (set.Length() == 0) {
				  //cout<<"No Strong Component was founded at all. Breaking at i="<<i+1<<endl;
					isOk = false;
					break;
				}
				
				int factor[] = {2,2};
				AbstractProcess* ps = new SimpleBoxProcess(set[0], func, factor, info);
				TarjanProcess* ts = new TarjanProcess(false, info);

				GraphSet it = AbstractProcess::Apply(ps, set);
				GraphSet res = AbstractProcess::Apply(ts, it);

				delete ps;
				delete ts;
				set.DeleteGraphs();
				it. DeleteGraphs();

				set = res;			
			}

			fo<<"Result for power "<<fpower<<" is "<<(isOk ? "Success": "Failed") <<endl;
			fo.flush();

			//Util::ExportPoints(set, output);

			fpower++;
			delete func;

			if (isOk) {
			  char buff[2044];
			  sprintf(buff, "%s.points", output);
			  Util::ExportPoints(set, buff);
			}
			set.DeleteGraphs();
		} while (!isOk);

		cout<<"Computation was finished for power "<<fpower<<" with "<<set.Length()<<" components"<<endl;

		cout<<"Program Ended"<<endl<<endl;
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
	} else if ( strcmp(argv[1], "-iter_m") == 0 ) {
		int its = 0;
		sscanf(argv[2],"%d", &its);
					
		char* inputSI = argv[3];
		char* inputMS = argv[4];
		char* output = argv[5];

		cout<<"Loading from "<<inputMS<<" and "<<inputSI<<" as SI "<<endl<<"Saving results to "<<output<<endl<<endl;
		GraphSet inSI = Util::LoadGraphSet(inputSI);
		GraphSet inMS = Util::LoadGraphSet(inputMS, false);

		TorstenFunction::beta = 3;
		TorstenFunctionDerivate::beta = 3;
		
		TorstenFunctionDerivate* func = new TorstenFunctionDerivate();
		MS2DAngleFunction* funcMS = new MS2DAngleFunction(func);
		MS2DAngleMorseFunction* funcRom = new MS2DAngleMorseFunction(func);
		ProgressBarInfo* pinfo = new ConsoleProgressBarInfo();

		for (int i=0; i<its; i++) {
			cout<<endl<<endl<<"Iteration "<<i+1<<" from "<<its<<endl<<endl;
			
			int factor[] = {1,1,2};
			MS2DBoxProcess* ps = new MS2DBoxProcess(funcMS, inMS[0], inSI, factor, pinfo);
			GraphSet res = AbstractProcess::Apply(ps, inMS);
			TarjanProcess* ts = new TarjanProcess(true, pinfo);
			GraphSet cms = AbstractProcess::Apply(ts, res);

			res.DeleteGraphs();
			inMS.DeleteGraphs();
			inMS = cms;

			char buff[2048];
			sprintf(buff,"tmp/%s.temp.%d", output, i);			
			Util::SaveGraphSet(inMS, buff);
		}
		if (its != 0)
			Util::SaveGraphSet(inMS, output);

		char buff[2048];

		sprintf(buff, "%s.morse", output);
		ofstream fo;
		fo.open(buff);

		cout<<"Computation of Morse Spectrum Started\n";

		for (GraphSetIterator it = inMS.iterator(); it.HasNext(); it.Next()) {
			CRomFunction2N rom(funcRom, inMS[0]);
			rom.minimize();

			double lower = rom.getAnswer();
			int lowerL = rom.getAnswerLength();
			fo<<rom.getAnswer()<<" "<<rom.getAnswerLength()<<endl;
			fo.flush();

			rom.maximize();

			double upper = rom.getAnswer();
			int upperL = rom.getAnswerLength();

			fo<<rom.getAnswer()<<rom.getAnswerLength();
			fo.flush();


			fo<<"Estimated Morse Spectrum for Component of "<<it->getNumberOfNodes()<<":"<<it->getNumberOfArcs()<<" finished with result"<<endl;
			fo<<"[ "<<scientific<<lower<<" ,   "<<scientific<<upper<<" ]"<<endl<<endl;
			fo.flush();
		}

		fo.close();

		delete func;
		delete funcMS;
		delete funcRom;
		delete pinfo;
		
		cout<<"Program Ended"<<endl<<endl;
	} else if (strcmp(argv[1], "-export") == 0) {
            cout<<"Loading from "<<argv[2]<<endl<<"Saving results to "<<argv[3]<<endl<<endl;
			Util::ExportPoints(Util::LoadGraphSet(argv[2]), argv[3]);
	}else if (strcmp(argv[1], "-init_m") == 0) {
		char* input = argv[2];
		char* output = argv[3];

		GraphSet in = Util::LoadGraphSet(input);


		int factor[] = {1,1,2};
		ProgressBarInfo* pinfo = new ConsoleProgressBarInfo();

		cout<<"Applying process of Creation MS"<<endl;
		
		MS2DCreationProcess* ps = new MS2DCreationProcess(in[0], factor, pinfo);
		GraphSet out = AbstractProcess::Apply(ps, in);

		cout<<"Done"<<endl<<"Saving..."<<endl;
		
		Util::SaveGraphSet(out, output);
		delete pinfo;
		delete ps;            
	} else if (strcmp(argv[1], "-line") == 0) {		
		int its = 0;
		sscanf(argv[2],"%d", &its);
		int hist = 1;
		sscanf(argv[3],"%d", &hist);

		ISystemFunction *func = new SYSTEM();
		SegmentIterator it(func,hist);


		it.Start(argv[4]);		
		double prec[] = {0.05, 0.05};

		for (int i=0; i<its; i++) 
			it.Iterate(prec);

		it.ExportToFile(argv[5]);		
		delete func;
	} else if ( strcmp(argv[1], "-iter2") == 0 ) {
		int its = 0;
		sscanf(argv[2],"%d", &its);
					
		char input[2000];// = argv[3];
		char output[2000];// = argv[4];

		double minM = 3;
		double maxM = 10;
		double step = 0.5;

		/*
		sprintf(output, "%s.p", argv[4]);

		FileOutputStream points(output);
		*/
		
		for (double d=minM; d<=maxM; d+= step) {
			//sprintf(input, "%s.%f", argv[3], d);
			sprintf(input, "%s", argv[3]);
			sprintf(output, "%s.%f", argv[4], d);
			//ParametrisedLogisticsMap::mju = d;
			TorstenFunction::beta = d;

			cout<<"Loading from "<<input<<endl<<"Saving results to "<<output<<endl<<endl;

			GraphSet in = Util::LoadGraphSet(input);

			for (int i=0; i<its; i++) {
				cout<<endl<<endl<<"Iteration "<<i+1<<" from "<<its<<endl<<endl;
				in = Process(in);
				char buff[2048];
				sprintf(buff,"tmp/%s.temp.%d", output, i);
				Util::SaveGraphSet(in, buff);
				
			}

			cout<<"\nIteration finished. ["<<d<<"]\n";

		        Util::SaveGraphSet(in, output);

			/*
			for (GraphSetIterator it = in.iterator(); it.HasNext(); it.Next()) {
				ParametrisedLogisticsMapFactory::SaveOnlyUnstable(d, it.Current(), points);
			}
			*/

			cout<<"Exporting points list to: points/"<<output<<endl;
			Util::ExportPoints(in, output, "points/");
			
			in.DeleteGraphs();

			cout<<"Iteration passed for fixed mju = "<<d<<endl;
		}
		cout<<"Program Ended"<<endl<<endl;
	}else DIE(-1);

	cout<<endl<<endl<<endl;

	return 0;
}

