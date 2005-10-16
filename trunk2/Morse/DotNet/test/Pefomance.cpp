#include "StdAfx.h"
#include ".\pefomance.h"
#include "objects.h"
#include "time.h"

Pefomance::Pefomance(void)
{
}

Pefomance::~Pefomance(void)
{
}


int2 Pefomance::getAvg() {
	int2 i;
	i.first = 0;
	i.second = 0;
	int c = 0;
	for (stat_t::iterator it = stat.begin(); it != stat.end(); it++) {
		i.first += it->first;
		i.second += it->second;
		c++;
	}

	i.first/= c;
	i.second /=c;

	return i;
}


void Pefomance::dimpStat() {
	cout<<"\n";
	for (stat_t::iterator it = stat.begin(); it != stat.end(); it++) {
		cout<<it->first<<"\t"<<it->second<<"\n";
	}
	cout<<"\n";
}

typedef smartPointer<GraphComponents> Gc;
typedef smartPointer<Function> Func;
typedef smartPointer<Graph> Gr;

clock_t testPoint(Gr& graph, Func& function, JInt* factor, JInt* ks) {
	
	clock_t tt = clock();
/*
	Computator cm;
	Gc gc = cm.performSIPoint(graph, function, factor, ks);

	tt =  clock() - tt;

	cout<<"result Components: "<<gc->length()<<"\n";
*/
	return tt;
}

clock_t testTaylor(Gr& graph, Func& function, JInt* factor) {
	
	clock_t tt = clock();
/*
	Computator cm;
	Gc gc = cm.performSI(graph, function, factor);

	tt = clock() - tt;

	cout<<"result Components: "<<gc->length()<<"\n";
*/
	return tt;
}


int toMilliSeconds(clock_t t) {
	return (t * 1000 / (CLOCKS_PER_SEC));
}



void Pefomance::test() {

	/*
	
	Func function = new Function(
		  new FunctionFactory("y1=x1*0.5; y2=x2*2; _dimension=2;"),
		  2
		);

	function->print();

	JDouble min[] = {-10, -10};
	JDouble max[] = {10, 10};
	JInt grid[] = {50, 50};


	Graph* t;
	Gr graph = t = new Graph(2, min, max, grid);
	
	graph->maximize();


	cout<<"Nodes: "<<graph->getNumberOfNodes()<<"\n";
	cout<<"Nodes: "<<t->getNumberOfNodes()<<"\n";

	JInt ks[] = {2,2};
	JInt factor[] = {3, 3};

	int timePoint = toMilliSeconds( testPoint(graph, function, factor, ks));

	int timeTaylor = toMilliSeconds( testTaylor(graph, function, factor));

	stat.push_back(int2(timePoint, timeTaylor));

	cout<<"Test pefomance comlete.\n\n";
	cout<<"Test First Step:\n";
	cout<<"\t Point Method:\t"<<timePoint<<"\n";
	cout<<"\t TaylorMethod:\t"<<timeTaylor<<"\n";

	cout<<"\t Factor :\t"<<factor[0]<<"\n";
	cout<<"\t ks[] :\t"<<ks[0]<<", "<<ks[1]<<"\n";

	*/
	cout<<"Complete!\n";
}




void Pefomance::test2() {
	/*
	Func function = new Function(
		  new FunctionFactory("y1=1 - 1.4*x1*x1-0.3*x2; y2=x1; _dimension=2;"),
		  2
		);

	function->print();

	JDouble min[] = {-10, -10};
	JDouble max[] = {10, 10};
	JInt grid[] = {50, 50};


	Graph* t;
	Gr graph = t = new Graph(2, min, max, grid);
	
	graph->maximize();


	cout<<"Nodes: "<<graph->getNumberOfNodes()<<"\n";
	cout<<"Nodes: "<<t->getNumberOfNodes()<<"\n";

	JInt ks[] = {6,6};
	JInt factor[] = {9, 9};

	int timePoint = toMilliSeconds( testPoint(graph, function, factor, ks));

	int timeTaylor = toMilliSeconds( testTaylor(graph, function, factor));

	stat.push_back(int2(timePoint, timeTaylor));

	cout<<"Test pefomance comlete.\n\n";
	cout<<"Test First Step:\n";
	cout<<"\t Point Method:\t"<<timePoint<<"\n";
	cout<<"\t TaylorMethod:\t"<<timeTaylor<<"\n";

	cout<<"\t Factor :\t"<<factor[0]<<"\n";
	cout<<"\t ks[] :\t"<<ks[0]<<", "<<ks[1]<<"\n";

	cout<<"Complete!\n";
	*/
}