// test.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "objects.h"
#include "Pefomance.h"



#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

void dumpGraphComponents(GraphComponents* cms, int number = -1);

void deleteGraphComponents(GraphComponents* cms) {
	for (int i=0; i<cms->length(); i++) {
		delete cms->getAt(i);
	}
	delete cms;
}


void testRomFromFile(char* fileIn) {
	char buff[555];
	strcpy(buff, fileIn);
	strcat(buff, ".result");
	ofstream o;
	o.open(buff);

	CRomDebug::ExGraph eg = CRomDebug::createFromFile(fileIn);
	CRomDebug rd(eg.graph, eg.values);

	cout<<"\n\n\nrd.minimize()\n\n";
	rd.minimize();
	cout<<"\n\nMinimum = "<<rd.getAnswer()<<"\n"
		<<"\n\n\nrd.maximize()\n\n\n";

	o<<"Minimum contour: "<<rd.getAnswer()<<"\nMinimum contour length: "<<rd.getAnswerLength()<<"\n";
	o.flush();

	rd.maximize();
	cout<<"\n\n\nMaximum = "<<rd.getAnswer()<<"\n\n\n";

	o<<"Maximum contour: "<<rd.getAnswer()<<"\nMaximum contour length: "<<rd.getAnswerLength()<<"\n";

	o.close();
	delete eg.graph;
}



typedef smartPointer<Graph> GraphPointer;
typedef smartPointer<GraphComponents>   GraphComps;


void testFunction(Function& f) { 
	f.getVariables()[0] = 0;
	f.getVariables()[1] = 0;
	f.getVariables()[2] = 10;

	cout<<"f(...)="<<f.F(2)<<"\n";
}





void t3d() {
	FunctionFactory fac("y1=0.5*x1; y2=0.5*x2; y3=0.5*x3;_dimension=2;");
	Function function(&fac, 2);

	fac.print(cout);

	function.print();

	//testFunction(function);
	
	JDouble mmin[] = {-1, -1, -1};
	JDouble mmax[] = {1 ,  1,  1};
	JInt grid[] = {5, 5, 5};

	
	GraphPointer g(new Graph(2, mmin, mmax, grid));

	g->maximize();

	Computator cm;
	GraphPointer p = cm.toMS(g, grid);

	cout<<p->getNumberOfNodes()<<"\n";
	cout<<p->getDimention()<<"\n";


	return;
/*
	GraphComps cmss(new GraphComponents());
	cmss->addGraphAsComponent(cm.toMS(g,1,2));
	dumpGraphComponents(cmss);

/**/
/*
	GraphComps cms( cm.performSI(g, &function, 2));
//	GraphComps cms1( cm.performSI(cms, &function, 2));
//	GraphComps cms2( cm.performSI(cms1, &function, 2));

	dumpGraphComponents(cms); //return;
	
	GraphPointer gm(cm.toMS(cms, 1, 5));

	GraphComponents cmt;
	cmt.addGraphAsComponent(gm);

	dumpGraphComponents(&cmt); //return;


	GraphComps ms2(cm.performMS(gm, &function, 1, 2));
	GraphComps ms3(cm.performMS(ms2, &function, 1, 2));

	cout<<"Result: "<<ms3->length()<<"\n";

	dumpGraphComponents(ms3);

	if (ms2->length() == 0) {
		cout<<"FUCK!\n"; return;
	}
	
	Computator::MorseResult r = cm.performMorse(ms3->getAt(0), &function);

	cout<<"Morse: "<<r.lower<<"\t"<<r.upper<<"\n";

	
//*/	
}


typedef smartPointer<SIPointBuilder> SIP;
typedef smartPointer<MS3PointBuilder> MIP;

int _factor[] = {2,2,2,2,2,2};
int _ks[] = {10,10,10,10,10,10};


template <class Process, class Gr>
void AStep(smartPointer<Process>& m, smartPointer<Gr>& cms, GraphPointer& g, Function* f, int* factor = _factor, int* ks = _ks ) {

	m = new Process(cms->getAt(0), factor, ks, f);
	m->start();
	for (int i=0; i<cms->length(); i++) {
		m->processNextGraph(cms->getAt(i));
	}

	g = m->result();
	cms = g->localazeStrongComponents();

	dumpGraphComponents(cms);
}

/*

void testPointer() {
	//FunctionFactory fac("y1=1-1.4*x1*x1+0.3*x2; y2=x1; y3=0.5*x3;_dimension=2;");
	FunctionFactory fac("y1=0.5*x1; y2=0.22*x2; y3=0.5*x3; _dimension=3;");
	Function function(&fac, 3);

	fac.print(cout);

	function.print();

	//testFunction(function);

	
	JDouble mmin[] = {-10, -10, -1};
	JDouble mmax[] = {10 ,  10,  1};
	JInt grid[] = {5, 5, 5, 5 ,5 };

	
	GraphPointer g = new Graph(3, mmin, mmax, grid);

	g->maximize();

	int v[] = {3,3,3,3,3};
	grid[0] = grid[1] = grid[2] = grid[3] = grid[4] = 2;

	SIP spb = new SIPointBuilder(g, grid, v, &function);
	spb->start();
	spb->processNextGraph(g);

	GraphPointer gr(spb->result());

	GraphComps cms = spb->result()->localazeStrongComponents();
	dumpGraphComponents(cms);

	AStep(spb, cms, gr, &function);
/*
	AStep(spb, cms, gr, &function);
	AStep(spb, cms, gr, &function);
	AStep(spb, cms, gr, &function);
	AStep(spb, cms, gr, &function);
	AStep(spb, cms, gr, &function);

	return;
*//*
	g = Computator().toMS(cms, 1 ,2);

	v[0] = v[1] = v[2] = 2;
	v[3] = v[4] = 3;
	grid[0] = grid[1] = grid[2] = 1;
	grid[3] = grid[4] = 2;

	MIP m = new MS3PointBuilder(g, grid, v, &function);
	m->start();
	m->processNextGraph(g);

	g = m->result();
	cms = g->localazeStrongComponents();

	dumpGraphComponents(cms);

	cout<<"First step ok\n";

//	return;

	v[0] = v[1] = v[2] = 2;
	v[3] = v[4] = 3;
	grid[0] = grid[1] = grid[2] = 1;
	grid[3] = grid[4] = 2;
	AStep(m, cms, g, &function, grid, v);
	AStep(m, cms, g, &function, grid, v);
	AStep(m, cms, g, &function, grid, v);
	AStep(m, cms, g, &function, grid, v);
	AStep(m, cms, g, &function, grid, v);
	AStep(m, cms, g, &function, grid, v);
	AStep(m, cms, g, &function, grid, v);
	AStep(m, cms, g, &function, grid, v);
	AStep(m, cms, g, &function, grid, v);
	AStep(m, cms, g, &function, grid, v);
	AStep(m, cms, g, &function, grid, v);

	list<Computator::MorseResult> mrl;

	for (int i=0; i<cms->length(); i++) {
		cms->getAt(i)->resolveEdges(g);
		mrl.push_back(Computator().performMorse(cms->getAt(i), &function));
	}

	cout<<"\n\nMorse:\n";

	for (list<Computator::MorseResult>::iterator it = mrl.begin(); it != mrl.end(); it++) {
		cout<<it->lower<<"\t"<<it->upper<<"\n";
	}
	
	return;

	AStep(m, cms, g, &function);
	AStep(m, cms, g, &function);
	AStep(m, cms, g, &function);

}


void perfomance() {

	Pefomance pf;
	pf.test2();
	pf.test2();
	pf.test2();
	pf.test2();
	pf.test2();
	pf.test2();
	pf.test2();

	int2 i = pf.getAvg();

	pf.dimpStat();

	cout<<i.first<<"\t"<<i.second<<"\n";
}
*/

int _tmain(int argc, _TCHAR* argv[])
{

	t3d();
	//testNodes();	
	//testPointer();

}






/*

////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////

int number = 0;

void dumpGraphComponents(GraphComponents* cms, int num) {
	if (num > 0) number += num;
	char file[255];

	sprintf(file, "g:\\%d_batch", ++number);

	FileOutputStream f(file);

	for (int i=0; i<cms->length(); i++) {
		sprintf(file, "g:\\%d_comp%d", number, i);
		f<<file;
		f.stress();
		saveGraph(FileOutputStream(file), cms->getAt(i));
	}	
}


//testRomFromFile(argv[1]);

	//testRomFromFile(argv[1]);
	
	/*
   FunctionFactory fac("y1=1-1.4*x1*x1+0.3*x2;y2=x1;_dimension=2;");
   Function function(&fac, 2);

   fac.print(cout);

   /*
   JDouble* v = function.getVariables();
   
   for (v[0] = -1; v[0] < 1; v[0]+= 0.13) {
	   for (v[1] = -1; v[1] < 1; v[1] += 0.17) {
		   if (function.F(0) != 2*v[0] + v[1]) cout<<"FAIL\n";
		   if (function.F(1) != v[0]) cout<<"FAIL2\n";
	   }
   }
   */
/*
   JDouble mn[] = {-2,-2, 0};
   JDouble mnn[] = {2, 2, M_PI};
   JInt grid[] = {10,10, 10};

   Graph* graph = new Graph(3, mn, mnn, grid);
   graph->maximize();
  
   Computator cm;
/*
   cout<<"SI:"<<"\n";
   GraphComponents* cms = cm.performSI(graph, &function, 2);

   cout<<"SI:Result: "<<cms->length()<<"\n";

   GraphComponents* cms1 = cm.performSI(cms, &function, 2);

   cout<<"SI: Result: "<<cms1->length()<<"\n";

   dumpGraphComponents(cms1);	

   Graph* cms2 = cm.toMS(cms1, 1, 2);

   Graph* cms2 = cm.toMS(graph, 1, 2);
   saveGraph(FileOutputStream("g:\\ms"), cms2);
/
   GraphComponents* cms3 = cm.performMS(graph, &function, 1, 4);

   cout<<"MS: Result: "<<cms3->length()<<"\n";

   GraphComponents* cms4 = cm.performMS(cms3, &function, 1, 2);

   cout<<"MS: Result: "<<cms4->length()<<"\n";

   dumpGraphComponents(cms4);
//	//*
   /*
   list<Computator::MorseResult> lm;

   int i=0;
   for (i=0; i<cms4->length(); i++)
   {
	Computator::MorseResult mr = cm.performMorse(cms4->getAt(i), &function);
	lm.push_back(mr);
	cout<<(i+1)<<"\t -> Morse ["<<mr.lower<<", "<<mr.upper<<"]\n";
	char c;
	cin>>c;
   }

   cout<<"\n\nResult "<<lm.size()<<":\n";
   
   i = 0;
   while (!lm.empty()) {
	   i++;
	   Computator::MorseResult mr = lm.front();
	   lm.pop_front();	   
	   cout<<i<<"\t -> Morse ["<<mr.lower<<",\t"<<mr.upper<<"]\n";
   }
   
 //  deleteGraphComponents(cms);
//   deleteGraphComponents(cms1);
   //*/  /*
   deleteGraphComponents(cms3);   
   deleteGraphComponents(cms4);
   delete graph;
//*/

   //Graph* g = createGraph(FileInputStream("g:\\11_comp0"));
/*
   cout<<"Opening file :"<<argv[1]<<"\nCheck if this file exists\n";

   Graph* g = createGraph(FileInputStream(argv[1]));

   Computator cm;
/*
   cout<<"MS";

   GraphComponents* cms = cm.performMS(g, &function, 1, 2);

   cout<<"MS: #="<<cms->length()<<"\n";

   dumpGraphComponents(cms, 10);

/* *//*-
   Computator::MorseResult ms = cm.performMorse(g, &function);

   

   cout<<"[ "<<ms.lower<<", "<<ms.upper<<" ]\n";
//*//*
   delete g;
   //deleteGraphComponents(cms);

   return 0;//**/
 
