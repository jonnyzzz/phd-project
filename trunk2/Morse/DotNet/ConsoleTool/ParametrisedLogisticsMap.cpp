#include "stdafx.h"
#include "ParametrisedLogisticsMap.h"
#include "../graph/Graph.h"
#include "../graph/GraphUtil.h"
#include "../graph/FileStream.h"
#include "../graph/LoopIterator.h"

#include <list>
using namespace std;

const int ParametrisedLogisticsMapFactory::Dim = 1;
double ParametrisedLogisticsMap::mju = 0;

ParametrisedLogisticsMap::ParametrisedLogisticsMap(void) : FunctionBase(1, 1)
{
}

ParametrisedLogisticsMap::ParametrisedLogisticsMap(double* in, double* out) : FunctionBase(1, 1, in, out)
{
}

ParametrisedLogisticsMap::~ParametrisedLogisticsMap(void)
{
}

void ParametrisedLogisticsMap::evaluate() {	
	output[0] = mju*input[0]*(1-input[0]);
}

double ParametrisedLogisticsMap::f(double d) {
	return mju*d*(1-d);
}

Graph* ParametrisedLogisticsMapFactory::CreateGraph() {
	double _min[] = { 0};
	double _max[] = {1};
	int _grid[] = {10};

	Graph* g = new Graph(1, _min, _max, _grid, false);
	g->maximize();
	return g;
}

double ParametrisedLogisticsMap::derivate(double d) {
	return mju - 2*mju*d;
}


void ParametrisedLogisticsMapFactory::Dump() {
	cout<<"Logistics Map with parameter "<<ParametrisedLogisticsMap::mju<<endl;
}


double inline ParametrisedLogisticsMapFactory::Abs(double d) {
	return ( d > 0) ? d : -d;
}
/*
void ParametrisedLogisticsMapFactory::SaveOnlyUnstable(double mju, Graph* graph, FileOutputStream& fs) {
	LoopIterator it(graph);

	LoopIterator::NodeLists lists = it.process();
	int loopsCnt = 0;
	int errorCnt = 0;

	ParametrisedLogisticsMap::mju = mju;

	const double eps = graph->getEps()[0]*4;

	for (LoopIterator::NodeLists::iterator it = lists.begin(); it != lists.end(); it++) {
		double dfs = 1;
		bool isTruePeriod = true;
		
		LoopIterator::NodeList::iterator first = it->begin();
		LoopIterator::NodeList::iterator second = (it->size() == 1) ? it->begin() : ++it->begin();

		double px = graph->toExternal(graph->getCells(*first)[0], 0);

		while (second != it->end()) {
			double x = graph->toExternal(graph->getCells(*second)[0], 0);
			double fx = ParametrisedLogisticsMap::f(px);
			double dfx = ParametrisedLogisticsMap::derivate(x);
			px = x;

			dfs *= dfx;

			if (!(Abs(x - fx) < eps)) {
				// cout<<"Computational Error period Found"<<endl;
				isTruePeriod = false;
				errorCnt++;
				break;
			}

			loopsCnt++;

			first = second;
			second++;
		}

		if (isTruePeriod && (Abs(dfs) > 1 - eps)) {
			for (LoopIterator::NodeList::iterator itt = it->begin(); itt != it->end(); itt++) {
				fs<<mju<<graph->toExternal(graph->getCells(*itt)[0],0);
				fs.stress();
			}			
		}
		
	}

	fs.stress();
	cout<<"Truly loop found: "<<loopsCnt<<" Wrong loops :"<<errorCnt<<endl;
}
*/


//////////////////////////////////////////////////////////////////////////////////////////////

class UnstableFinder : private MemoryManager {

public:
	UnstableFinder(Graph* graph, FileOutputStream& fs);



public:

	struct NodeEx {
		Node* node;
		int deep;
		NodeEx* parent;

		NodeEx(Node* node, NodeEx* parent, int deep) : node(node), parent(parent), deep(deep) {};
	};


	typedef list<NodeEx*> NodeExList;
	typedef list<Node*> NodeList;


	void process();


private:
	const int visitedFlagID;
	const int decidedFlagID;
	const int maxDeep;
	const double eps;

	FileOutputStream& fs;

	Graph* graph;


	void DFS(NodeExList& start, NodeExList& stop);

	void CheckLoop(NodeList& loop);
	
	double Image(Node* node);
	double Value(Node* node);
	double Derivate(Node* node);
	bool IsClose(NodeEx* node1, Node* node2);
	double Abs(double x);
};


void UnstableFinder::process() {
	NodeExList list1;
	NodeExList list2;

	//	typedef list<NodeExLost> TasksList;
	//TasksList tmp;

	GraphNodeEnumerator ne(graph);
	Node* to;
	while ((to = ne.next())!=NULL){
	    list1.clear();
	    list2.clear();
 	    graph->setFlag(to, visitedFlagID, true);
	    NodeEx* node = ALLOCATE(NodeEx, (to, NULL, 0));

	    list1.push_front(node);

	    while (!list1.empty()) {
		   DFS(list1, list2);
		   DFS(list2, list1);

		   if (list1.size() > graph->getNumberOfNodes()){
		     //tmp.push_back(list1)
			 cout<<"?";
		       break;
		   }
 	    }
	}
}



UnstableFinder::UnstableFinder(Graph* graph, FileOutputStream& fs) : 
	MemoryManager((16 + graph->getNumberOfNodes())*sizeof(NodeEx)), 
	graph(graph), 
	visitedFlagID(graph->registerFlag()),
	decidedFlagID(graph->registerFlag()),
	maxDeep(graph->getNumberOfNodes()+1),
	eps(graph->getEps()[0]*4),
	fs(fs)
{

}

double UnstableFinder::Abs(double x) {
	return x>0? x: -x;
}

bool UnstableFinder::IsClose(NodeEx* nodeEx, Node* node) {
	return  !(Abs(Image(nodeEx->node) - Value(node)) > eps);
}

double UnstableFinder::Value(Node* node) {
	return graph->toExternal(graph->getCells(node)[0],0);
}

double UnstableFinder::Image(Node* node) {
	return ParametrisedLogisticsMap::f(Value(node));
}

double UnstableFinder::Derivate(Node* node) {
	return ParametrisedLogisticsMap::derivate(Value(node));
}


void UnstableFinder::DFS(NodeExList& start, NodeExList& stop) {
	cout<<"DFS with "<<start.size()<<endl;
	stop.clear();

	for (NodeExList::iterator it = start.begin(); it != start.end(); it++) {
		if ((*it)->deep < maxDeep && !graph->readFlag((*it)->node, decidedFlagID)) {
			GraphEdgeEnumerator ee(graph, (*it)->node);
			Node* to;
			while ((to = ee.nextTo()) != NULL) {
				bool nCont = true;
				if (graph->readFlag(to, visitedFlagID)) {
					NodeList list;
					NodeEx* cur = *it;

					while (cur != NULL) {
						list.push_front(cur->node);
						if (cur->node == to) {
							CheckLoop(list);
							nCont = false;
							break;
						}
						cur = cur->parent;
					}
				}

				if (nCont) {
					graph->setFlag(to, visitedFlagID, true);
					NodeEx* node = ALLOCATE(NodeEx, (to, *it, (*it)->deep+1));
					stop.push_back(node);
				}							
			}
		}
	}
}

void UnstableFinder::CheckLoop(NodeList& loop) {
        cout<<"!";
	double dfs = 1;
	bool isTruePeriod = true;
	
	NodeList::iterator first = loop.begin();
	NodeList::iterator second = (loop.size() == 1) ? loop.begin() : ++loop.begin();

	double px = graph->toExternal(graph->getCells(*first)[0], 0);

	while (second != loop.end()) {
		double x = graph->toExternal(graph->getCells(*second)[0], 0);
		double fx = ParametrisedLogisticsMap::f(px);
		double dfx = ParametrisedLogisticsMap::derivate(x);
		px = x;

		dfs *= dfx;

		if (Abs(x - fx) >= eps) {
			// cout<<"Computational Error period Found"<<endl;
			isTruePeriod = false;
			break;
		}

		first = second;
		second++;
	}

	if (isTruePeriod && (Abs(dfs) > 1 - eps)) {
		for (NodeList::iterator itt = loop.begin(); itt != loop.end(); itt++) {
			fs<<ParametrisedLogisticsMap::mju<<graph->toExternal(graph->getCells(*itt)[0],0);
			graph->setFlag(*itt, decidedFlagID, true);
			fs.stress();
		}			
	}
}



void ParametrisedLogisticsMapFactory::SaveOnlyUnstable(double mju, Graph* graph, FileOutputStream& fs) {
	ParametrisedLogisticsMap::mju = mju;
	UnstableFinder fi(graph, fs);

	fi.process();	
}




